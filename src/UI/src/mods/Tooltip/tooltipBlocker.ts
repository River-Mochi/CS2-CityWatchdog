// File: src/UI/src/mods/Tooltip/tooltipBlocker.ts
// Purpose: Hide vanilla DOM tooltips (balloon popups) when the
//   DisableAllTooltips binding flips on. Subscribed once at register time.
//
// The C# side already toggles Game.UI.Tooltip.TooltipUISystem.hideTooltips,
// which short-circuits gameplay (mouse-following / world) tooltips at the
// source. This CSS injector handles the rest: DOM tooltips rendered by the
// vanilla cs2/ui Tooltip component on regular UI panels and buttons.
//
// CWD's own panel tooltips are still gated at the React layer via the
// optionalTooltip helper in NotificationPanel.tsx, so they short-circuit
// before reaching the DOM. The CSS here is the safety net for everything
// rendered outside our control.

import { disableAllTooltips$ } from "../Bindings/Bindings";

const STYLE_ELEMENT_ID = "cwd-tooltip-blocker";

const BLOCKER_CSS = `
[class*="balloon_"],
[class*="tooltip-base_"],
[class*="tooltip-fade_"] {
    display: none !important;
    pointer-events: none !important;
}
`;

let styleElement: HTMLStyleElement | null = null;

function applyBlocker(): void {
    if (styleElement) {
        return;
    }
    const existing = document.getElementById(STYLE_ELEMENT_ID) as HTMLStyleElement | null;
    if (existing) {
        styleElement = existing;
        return;
    }
    const element = document.createElement("style");
    element.id = STYLE_ELEMENT_ID;
    element.textContent = BLOCKER_CSS;
    document.head.appendChild(element);
    styleElement = element;
}

function removeBlocker(): void {
    styleElement?.remove();
    styleElement = null;
    const orphan = document.getElementById(STYLE_ELEMENT_ID);
    orphan?.remove();
}

export function initializeTooltipBlocker(): void {
    disableAllTooltips$.subscribe((disabled) => {
        if (disabled) {
            applyBlocker();
        } else {
            removeBlocker();
        }
    });

    if (disableAllTooltips$.value) {
        applyBlocker();
    }
}

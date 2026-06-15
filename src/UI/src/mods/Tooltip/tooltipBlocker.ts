// File: src/UI/src/mods/Tooltip/tooltipBlocker.ts
// Purpose: Hide vanilla DOM tooltips (balloon popups) when the
//   DisableAllTooltips binding flips on. Subscribed once at register time.
//
// The C# side already toggles Game.UI.Tooltip.TooltipUISystem.hideTooltips,
// which short-circuits gameplay (mouse-following / world) tooltips at the
// source. This CSS injector handles the rest: DOM tooltips rendered by the
// vanilla cs2/ui Tooltip component on regular UI panels and buttons.
//
// Tooltips that include a <span class="cwd-tooltip-keep" /> marker child
// are excluded via the :has() selector. This keeps a few CWD-owned
// tooltips visible even when the global toggle is on:
//   - The Info button (so users can read how to turn tooltips back on).
//   - The panel's title-bar icon help.
//   - CWD's money/population tooltip enhancements.

import { disableAllTooltips$ } from "../Bindings/Bindings";

const STYLE_ELEMENT_ID = "cwd-tooltip-blocker";

export const KEEP_MARKER_CLASS = "cwd-tooltip-keep";

// Marker child uses inline display:none, so this rule only needs the :has() exclusion.
const BLOCKER_CSS = `
[class*="balloon_"]:not(:has(.${KEEP_MARKER_CLASS})),
[class*="tooltip-base_"]:not(:has(.${KEEP_MARKER_CLASS})),
[class*="tooltip-fade_"]:not(:has(.${KEEP_MARKER_CLASS})) {
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

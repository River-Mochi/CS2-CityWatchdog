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

// Cohtml's CSS engine does NOT support :not() or :has() — both emit warnings and the rule
// is dropped silently. We have to use only basic CSS3 (attribute, class, descendant) and
// rely on override-by-specificity:
//   1. Blanket hide every balloon (low specificity).
//   2. Higher-specificity override re-shows balloons that carry the keep-marker class
//      directly OR whose ancestor carries it. Either match wins.
const BLOCKER_CSS = `
[class*="balloon_"],
[class*="tooltip-base_"],
[class*="tooltip-fade_"] {
    display: none !important;
    pointer-events: none !important;
}

[class*="balloon_"].${KEEP_MARKER_CLASS},
[class*="tooltip-base_"].${KEEP_MARKER_CLASS},
[class*="tooltip-fade_"].${KEEP_MARKER_CLASS},
.${KEEP_MARKER_CLASS} [class*="balloon_"],
.${KEEP_MARKER_CLASS} [class*="tooltip-base_"],
.${KEEP_MARKER_CLASS} [class*="tooltip-fade_"] {
    display: flex !important;
    pointer-events: auto !important;
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

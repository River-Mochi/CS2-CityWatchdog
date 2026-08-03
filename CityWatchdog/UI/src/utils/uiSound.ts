// File: src/UI/src/utils/uiSound.ts
// Best-effort vanilla UI click sound for raw <div>/<button> controls that can't use a cs2/ui
// Button's onSelect. Wrapped so a failed/missing sound can NEVER break the control's click action.

import { trigger } from "cs2/api";

// "select-item" is the vanilla button click sound; play it through the vanilla audio binding.
export const playSelectSound = () => {
    try {
        trigger("audio", "playSound", "select-item", 1);
    } catch {
        // Swallow — the click action must still run even if the sound can't play.
    }
};

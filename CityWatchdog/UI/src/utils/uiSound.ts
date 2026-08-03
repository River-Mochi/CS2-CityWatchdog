// File: src/UI/src/utils/uiSound.ts
// Vanilla UI click sound for raw <div>/<button> controls that can't use a cs2/ui Button's onSelect.

import { trigger } from "cs2/api";
import { UISound } from "cs2/ui";

// Same "select-item" sound the vanilla cs2/ui buttons play, via the vanilla audio binding.
export const playSelectSound = () => trigger("audio", "playSound", UISound.selectItem, 1);

// File: src/UI/src/components/panel/notification-panel/buttons/presetButtons.tsx
// Purpose: One slot of the "1 | 2" preset split button. Click a slot to load it; press-and-hold to
//          save the current notification checkboxes into it.

import { forwardRef, useCallback, useEffect, useRef, useState } from "react";
import styles from "./presetButtons.module.scss";

// Hold this long (ms) before a press counts as "save" instead of "load".
const HOLD_MS = 550;

// Click = onClick; press-and-hold past HOLD_MS = onLongPress (and the click that follows is
// suppressed). The timer is cleared on release, mouse-leave, and unmount, so no timer ever dangles.
// Uses only React state + refs — no DOM mutation.
const useLongPress = (onClick: () => void, onLongPress: () => void) => {
    const timer = useRef<ReturnType<typeof setTimeout> | null>(null);
    const longPressed = useRef(false);
    const [holding, setHolding] = useState(false);

    const clear = useCallback(() => {
        if (timer.current !== null) {
            clearTimeout(timer.current);
            timer.current = null;
        }
        setHolding(false);
    }, []);

    // Cancel any in-flight hold if the slot unmounts mid-press.
    useEffect(() => clear, [clear]);

    const onMouseDown = useCallback(() => {
        longPressed.current = false;
        setHolding(true);
        timer.current = setTimeout(() => {
            longPressed.current = true;
            timer.current = null;
            setHolding(false);
            onLongPress();
        }, HOLD_MS);
    }, [onLongPress, clear]);

    const onMouseUp = useCallback(() => clear(), [clear]);
    const onMouseLeave = useCallback(() => clear(), [clear]);

    const handleClick = useCallback(() => {
        // A completed hold already fired onLongPress; swallow the trailing click so it doesn't also load.
        if (longPressed.current) {
            longPressed.current = false;
            return;
        }
        onClick();
    }, [onClick]);

    return { holding, handlers: { onMouseDown, onMouseUp, onMouseLeave, onClick: handleClick } };
};

interface PresetSlotProps {
    label: string;
    saved: boolean;
    onLoad: () => void;
    onSave: () => void;
}

// forwardRef so the slot can be a CwdTooltip child (the vanilla Tooltip attaches to the child element).
export const PresetSlot = forwardRef<HTMLDivElement, PresetSlotProps>(
    ({ label, saved, onLoad, onSave }, ref) => {
        const { holding, handlers } = useLongPress(onLoad, onSave);

        const className = [
            styles.presetSlot,
            saved ? styles.presetSlotSaved : styles.presetSlotEmpty,
            holding ? styles.presetSlotHolding : "",
        ]
            .filter(Boolean)
            .join(" ");

        return (
            <div ref={ref} className={className} role="button" {...handlers}>
                {label}
            </div>
        );
    },
);

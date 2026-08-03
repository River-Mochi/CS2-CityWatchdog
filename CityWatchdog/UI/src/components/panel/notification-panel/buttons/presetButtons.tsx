// File: src/UI/src/components/panel/notification-panel/buttons/presetButtons.tsx
// Purpose: One slot of the "1 | 2" preset split button. Click a slot to load it; press-and-hold to
//          save the current notification checkboxes into it.

import { forwardRef, useCallback, useEffect, useRef, useState } from "react";
import styles from "./presetButtons.module.scss";

// Hold this long (ms) before a press counts as "save" instead of "load". Matches the fill-sweep
// duration in the scss so the box finishes "charging" exactly as the save fires.
const HOLD_MS = 800;

// A completed hold saves and suppresses the trailing load click.
// Cleanup cancels pending timers on release, leave, or unmount.
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
    // The currently-applied box: shows a blue border + dot so the player can tell which preset is on.
    active: boolean;
    onLoad: () => void;
    onSave: () => void;
}

// forwardRef so the slot can be a CwdTooltip child (the vanilla Tooltip attaches to the child element).
export const PresetSlot = forwardRef<HTMLDivElement, PresetSlotProps>(
    ({ label, saved, active, onLoad, onSave }, ref) => {
        const { holding, handlers } = useLongPress(onLoad, onSave);

        // the holding highlight overlays whatever state it's in.
        const stateClass = active
            ? styles.presetSlotActive
            : saved
                ? styles.presetSlotSaved
                : styles.presetSlotEmpty;

        const className = [styles.presetSlot, stateClass, holding ? styles.presetSlotHolding : ""]
            .filter(Boolean)
            .join(" ");

        // Fill-sweep overlay: rises from the bottom while holding, so a press visibly "charges" up to
        // the save. Kept behind the number (presetLabel is positioned above it).
        const fillClassName = holding
            ? `${styles.presetFill} ${styles.presetFilling}`
            : styles.presetFill;

        return (
            <div ref={ref} className={className} role="button" {...handlers}>
                <span className={fillClassName} />
                <span className={styles.presetLabel}>{label}</span>
                {active && <span className={styles.presetDot} />}
            </div>
        );
    },
);

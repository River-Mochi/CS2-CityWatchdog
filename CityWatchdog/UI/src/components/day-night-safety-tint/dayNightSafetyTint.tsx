// File: src/UI/src/components/day-night-safety-tint/dayNightSafetyTint.tsx
// Purpose: A1 test — briefly shades Day -> Night so the X-ray frames are less visible.

import { useValue } from "cs2/api";
import { useEffect, useRef, useState } from "react";
import {
    dayNightSafetyTintToken$,
    OnDayNightSafetyTintComplete,
    OnDayNightSafetyTintReady,
} from "../../bindings/dayNightSafetyTintBindings";
import styles from "./dayNightSafetyTint.module.scss";

const FADE_IN_MS = 50;
const COVERED_HOLD_MS = 120;
const FADE_OUT_MS = 80;
const TIMER_MARGIN_MS = 5;

type TintPhase =
    | "hidden"
    | "armed"
    | "fadeIn"
    | "hold"
    | "fadeOut";

const getPhaseClass = (phase: TintPhase) => {
    switch (phase) {
        case "armed":
            return styles.armed;
        case "fadeIn":
            return styles.fadeIn;
        case "hold":
            return styles.hold;
        case "fadeOut":
            return styles.fadeOut;
        default:
            return "";
    }
};

export const DayNightSafetyTint = () => {
    const token = useValue(dayNightSafetyTintToken$);
    const [phase, setPhase] = useState<TintPhase>("hidden");
    const timers = useRef<number[]>([]);

    useEffect(() => {
        for (const timer of timers.current) {
            window.clearTimeout(timer);
        }

        timers.current = [];

        if (token <= 0) {
            setPhase("hidden");
            return;
        }

        // Mount fully transparent first so Cohtml has a starting frame to animate from.
        setPhase("armed");

        const fadeInTimer = window.setTimeout(() => {
            setPhase("fadeIn");
        }, 1);

        // C# changes the clock only after the tint has reached 85%.
        const readyTimer = window.setTimeout(() => {
            setPhase("hold");
            OnDayNightSafetyTintReady(token);
        }, FADE_IN_MS + TIMER_MARGIN_MS);

        const fadeOutTimer = window.setTimeout(() => {
            setPhase("fadeOut");
        }, FADE_IN_MS + TIMER_MARGIN_MS + COVERED_HOLD_MS);

        const completeTimer = window.setTimeout(() => {
            setPhase("hidden");
            OnDayNightSafetyTintComplete(token);
        }, FADE_IN_MS + TIMER_MARGIN_MS + COVERED_HOLD_MS + FADE_OUT_MS + TIMER_MARGIN_MS);

        timers.current = [
            fadeInTimer,
            readyTimer,
            fadeOutTimer,
            completeTimer,
        ];

        return () => {
            for (const timer of timers.current) {
                window.clearTimeout(timer);
            }

            timers.current = [];
        };
    }, [token]);

    if (phase === "hidden") {
        return null;
    }

    return (
        <div
            aria-hidden="true"
            className={`${styles.tint} ${getPhaseClass(phase)}`}
        />
    );
};

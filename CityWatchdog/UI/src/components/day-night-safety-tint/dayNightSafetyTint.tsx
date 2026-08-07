// File: src/UI/src/components/day-night-safety-tint/dayNightSafetyTint.tsx
// Purpose: D1 timing handshake only. The visible darkening now comes from
// HDRP ColorAdjustments, so this component draws no flat screen overlay.

import { useValue } from "cs2/api";
import { useEffect, useRef } from "react";
import {
    dayNightSafetyTintToken$,
    OnDayNightSafetyTintComplete,
    OnDayNightSafetyTintReady,
} from "../../bindings/dayNightSafetyTintBindings";

const SHADE_FADE_IN_MS = 50;
const SHADE_HOLD_MS = 120;
const SHADE_FADE_OUT_MS = 80;
const TIMER_MARGIN_MS = 5;

export const DayNightSafetyTint = () => {
    const token = useValue(dayNightSafetyTintToken$);
    const timers = useRef<number[]>([]);

    useEffect(() => {
        for (const timer of timers.current) {
            window.clearTimeout(timer);
        }

        timers.current = [];

        if (token <= 0) {
            return;
        }

        // C# applies Night only after the HDRP shade has reached full weight.
        const readyTimer = window.setTimeout(() => {
            OnDayNightSafetyTintReady(token);
        }, SHADE_FADE_IN_MS + TIMER_MARGIN_MS);

        const completeTimer = window.setTimeout(() => {
            OnDayNightSafetyTintComplete(token);
        }, SHADE_FADE_IN_MS +
            TIMER_MARGIN_MS +
            SHADE_HOLD_MS +
            SHADE_FADE_OUT_MS +
            TIMER_MARGIN_MS);

        timers.current = [
            readyTimer,
            completeTimer,
        ];

        return () => {
            for (const timer of timers.current) {
                window.clearTimeout(timer);
            }

            timers.current = [];
        };
    }, [token]);

    return null;
};

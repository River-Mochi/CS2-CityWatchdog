// File: src/UI/src/bindings/dayNightSafetyTintBindings.ts
// Purpose: Handshake between the C# Day/Night controller and the temporary UI safety tint.

import { bindValue, trigger } from "cs2/api";
import mod from "../../mod.json";

export const dayNightSafetyTintToken$ =
    bindValue<number>(mod.id, "DayNightSafetyTintToken", 0);

export const OnDayNightSafetyTintReady = (token: number) =>
    trigger(mod.id, "DayNightSafetyTintReady", token);

export const OnDayNightSafetyTintComplete = (token: number) =>
    trigger(mod.id, "DayNightSafetyTintComplete", token);

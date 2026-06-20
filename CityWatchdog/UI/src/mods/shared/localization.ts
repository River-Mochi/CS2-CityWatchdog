// <copyright file="localization.ts" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>

// File: UI/src/mods/shared/localization.ts
// Purpose:
//   In-city UI locale lookup. The C# side (UIStringsJsonSource) loads lang/<locale>.json and
//   registers every entry with the game's LocalizationManager under "CityWatchdog.UI.<Key>".
//   useText() is a React hook that returns a text(key, fallback) function bound to the active
//   game language — when the player switches language, components rerender and pick up the new
//   translations automatically via useLocalization().
//
//   The static en-US.json import is the fallback for keys missing from the active locale's JSON
//   (and also covers a brief window during boot before the locale source loads).

import enUS from "../../../../lang/en-US.json";
import { useLocalization } from "cs2/l10n";

const KEY_PREFIX = "CityWatchdog.UI";
const enFallback = enUS as Record<string, string>;

export const useText = (): ((key: string, fallback?: string) => string) => {
    const { translate } = useLocalization();
    return (key: string, fallback?: string): string => {
        const translated = translate(`${KEY_PREFIX}.${key}`);
        if (translated !== null && translated !== undefined) {
            return translated;
        }
        return enFallback[key] ?? fallback ?? key;
    };
};

// <copyright file="localization.ts" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>

// File: UI/src/components/shared/localization.ts
// Purpose:
//   In-city UI locale lookup. The C# side (InCityLocalization.LoadEmbeddedJsonTranslations)
//   reads embedded lang/<locale>.json resources via Assembly.GetManifestResourceStream,
//   parses with Colossal.Json.JSON.Load, and registers each entry with the game's
//   LocalizationManager under "CityWatchdog.UI.<Key>" via Colossal.Localization.MemorySource.
//   Embedded resources mean no install-path resolution — works identically for local-dev and
//   PDX-subscribed installs.
//
//   useText() is a React hook that returns a text(key, fallback) function bound to the active
//   game language — when the player switches language, components rerender and pick up the new
//   translations automatically via useLocalization().
//
//   Static en-US.json import is the fallback for keys missing from the active locale's JSON
//   (also covers a brief window during boot before the locale source loads).

import enUS from "../../../../lang/en-US.json";
import { useLocalization } from "cs2/l10n";
import { useCallback } from "react";

// Make a type called TextKey that is the list of every key actually in en-US.json.
// VS Code uses this to autocomplete valid keys when you type text("...") in a .tsx file,
// and the English fallback list grows automatically whenever en-US.json gains a new entry.
// The `| (string & {})` widening trick keeps the literal-string autocomplete while still
// accepting plain `string` variables (used by notificationData.ts for data-driven section
// and item localeIds). Without the widening, TextKey | string would collapse to plain
// string and lose the autocomplete benefit.
type TextKey = keyof typeof enUS;

const KEY_PREFIX = "CityWatchdog.UI";
const enFallback = enUS as Record<string, string>;

export const useText = (): ((key: TextKey | (string & {}), fallback?: string) => string) => {
    const { translate } = useLocalization();
    return useCallback((key: TextKey | (string & {}), fallback?: string): string => {
        const translated = translate(`${KEY_PREFIX}.${key}`);
        if (translated !== null && translated !== undefined) {
            return translated;
        }
        return enFallback[key] ?? fallback ?? key;
    }, [translate]);
};

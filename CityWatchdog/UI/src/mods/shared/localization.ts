// <copyright file="localization.ts" company="River-Mochi">
// Copyright (c) 2026 River-Mochi, MIT License.
// See LICENSE file in the project root for full license info.
// </copyright>

// File: UI/src/mods/shared/localization.ts
// Purpose: In-city UI locale strings loaded from the mod language JSON file.

import enUS from "../../../../lang/en-US.json";

const locale = enUS as Record<string, string>;

export const text = (key: string, fallback?: string): string => {
    return locale[key] ?? fallback ?? key;
};

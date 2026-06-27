// File: src/UI/src/mods/shared/formatNotificationCount.ts
// Purpose: Keeps large notification totals compact in the panel and mini HUD.

const formatScaledCount = (value: number, divisor: number, suffix: string, decimals: number) => {
    const scaled = value / divisor;
    return `${scaled.toFixed(decimals).replace(/\.?0+$/, "")}${suffix}`;
};

export const formatMiniNotificationCount = (value: number) => {
    if (value >= 1_000_000) {
        return formatScaledCount(value, 1_000_000, "m", 1);
    }

    if (value >= 1_000) {
        return formatScaledCount(value, 1_000, "k", 1);
    }

    return value.toString();
};

export const formatPanelNotificationCount = (value: number) => {
    if (value >= 1_000_000) {
        return formatScaledCount(value, 1_000_000, "m", 2);
    }

    if (value >= 1_000) {
        return formatScaledCount(value, 1_000, "k", 2);
    }

    return value.toString();
};

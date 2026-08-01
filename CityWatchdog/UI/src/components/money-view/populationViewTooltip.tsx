// File: src/UI/src/components/money-view/populationViewTooltip.tsx
// Purpose: Adds CWD population flow rows to the vanilla population tooltip.

import { bindValue, useValue } from "cs2/api";
import { infoview, toolbarBottom } from "cs2/bindings";
import { LocalizedNumber, Unit, useLocalization, type Localization } from "cs2/l10n";
import { useText } from "../shared/localization";
import { Children, isValidElement, type CSSProperties, type ReactNode } from "react";
import { moneyView$, populationTooltipFontScale$ } from "../../bindings/bindings";
import styles from "./moneyView.module.scss";
import { getDisplayWholeValue, getNumericValue, getSignedAmountTone, POPULATION_ICON } from "./moneyViewShared";

// Vanilla exposes this binding, but the generated cs2/bindings type does not currently list it.
const homeless$ = bindValue<number>("populationInfo", "homeless", 0);

export const PopulationViewTooltipContent = ({ baseContent }: { readonly baseContent: ReactNode }) => {
    const localization = useLocalization();
    const text = useText();
    const moneyViewEnabled = useValue(moneyView$);
    const populationTooltipFontScale = useValue(populationTooltipFontScale$);
    const currentTrend = getNumericValue(useValue(toolbarBottom.populationDelta$));

    // These come from vanilla PopulationInfoviewUISystem, so CWD does not need its own sim queries.
    const births = getNumericValue(useValue(infoview.birthRate$));
    const deaths = getNumericValue(useValue(infoview.deathRate$));
    const homeless = getNumericValue(useValue(homeless$));
    const movedIn = getNumericValue(useValue(infoview.movedIn$));
    const movedAway = getNumericValue(useValue(infoview.movedAway$));

    if (!moneyViewEnabled) {
        return baseContent ? <>{baseContent}</> : null;
    }

    const tooltipStyle = {
        "--populationTooltipValueSize": getTooltipValueSize(populationTooltipFontScale),
    } as CSSProperties;

    return (
        <div className={styles.populationTooltipWrapper} style={tooltipStyle}>
            <div className={styles.tooltipTitle}>City Watchdog</div>
            <PopulationTooltipCurrentTrend
                localization={localization}
                label={text("PopulationTooltipCurrentTrend", "Current trend:")}
                value={currentTrend}
            />
            <div className={styles.populationTooltipExtra}>
                <PopulationTooltipPairRow
                    localization={localization}
                    label={text("PopulationTooltipBirthsDeaths", "Births / Deaths")}
                    positiveValue={births}
                    negativeValue={deaths}
                />
                <PopulationTooltipPairRow
                    localization={localization}
                    label={text("PopulationTooltipMovedInOut", "Moved in / out")}
                    positiveValue={movedIn}
                    negativeValue={movedAway}
                />
                <PopulationTooltipCount
                    localization={localization}
                    label={text("PopulationTooltipHomeless", "Homeless:")}
                    value={homeless}
                />
            </div>
        </div>
    );
};

export const isPopulationTooltip = (props: any): boolean => {
    return containsIcon(props?.children, POPULATION_ICON);
};

// Walk the vanilla tooltip tree instead of querying generated CSS class names.
const containsIcon = (node: ReactNode, icon: string): boolean => {
    if (!isValidElement(node)) {
        return false;
    }

    const props = node.props as any;
    if (props?.icon === icon) {
        return true;
    }

    return Children.toArray(props?.children).some((child) => containsIcon(child, icon));
};

// Two related flows on one compact row: "Births / Deaths    +693 / -218 /mo."
// The gain is a bare number; the loss carries the localized /mo. suffix so the pair reads as a
// single monthly figure while keeping per-language number formatting.
const PopulationTooltipPairRow = ({
    localization,
    label,
    positiveValue,
    negativeValue,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly positiveValue: number;
    readonly negativeValue: number;
}) => {
    const gain = getDisplayWholeValue(positiveValue);
    const loss = getDisplayWholeValue(negativeValue);

    const gainText = gain === 0
        ? formatLocalizedIntegerValue(localization, 0, Unit.Integer)
        : `+${formatLocalizedIntegerValue(localization, gain, Unit.Integer)}`;
    const lossText = loss === 0
        ? formatLocalizedIntegerValue(localization, 0, Unit.IntegerPerMonth)
        : `-${formatLocalizedIntegerValue(localization, loss, Unit.IntegerPerMonth)}`;

    return (
        <div className={styles.populationTooltipGroup}>
            <div className={styles.tooltipLabel}>{trimLabelPunctuation(label)}</div>
            <div className={styles.populationTooltipPairValue}>
                <span className={styles.positive}>{gainText}</span>
                <span className={styles.populationTooltipPairSep}> / </span>
                <span className={styles.negative}>{lossText}</span>
            </div>
        </div>
    );
};

const PopulationTooltipCount = ({
    localization,
    label,
    value,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
}) => {
    const displayValue = getDisplayWholeValue(value);

    return (
        <PopulationTooltipRate
            localization={localization}
            label={label}
            value={displayValue}
            unit={Unit.Integer}
            toneOverride="softNeutral"
            showSign={false}
        />
    );
};

const PopulationTooltipCurrentTrend = ({
    localization,
    label,
    value,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
}) => {
    const displayValue = getDisplayWholeValue(value);

    return (
        <PopulationTooltipRate
            localization={localization}
            label={label}
            value={displayValue}
            unit={Unit.IntegerPerHour}
            topRow={true}
        />
    );
};

const PopulationTooltipRate = ({
    localization,
    label,
    value,
    unit,
    topRow = false,
    toneOverride,
    showSign = true,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
    readonly unit: Unit;
    readonly topRow?: boolean;
        readonly toneOverride?: "positive" | "negative" | "neutral" | "softNeutral";
    readonly showSign?: boolean;
}) => {
    const tone = toneOverride ?? getSignedAmountTone(value);
    const formattedValue = showSign
        ? formatPopulationRateValue(localization, value, unit)
        : formatLocalizedIntegerValue(localization, value, unit);

    return (
        <div className={`${styles.populationTooltipGroup} ${topRow ? styles.populationTooltipTopTrend : ""}`}>
            <div className={styles.tooltipLabel}>{trimLabelPunctuation(label)}</div>
            <div className={`${styles.populationTooltipValueLine} ${styles[tone]}`}>{formattedValue}</div>
        </div>
    );
};

const formatPopulationRateValue = (localization: Localization, value: number, unit: Unit): string => {
    const magnitude = formatLocalizedIntegerValue(localization, Math.abs(value), unit);
    const spacer = "\u200A";

    if (value > 0) {
        return `+${spacer}${magnitude}`;
    }

    if (value < 0) {
        return `-${spacer}${magnitude}`;
    }

    return magnitude;
};

const formatLocalizedIntegerValue = (localization: Localization, value: number, unit: Unit): string => {
    try {
        // Vanilla formatter keeps separators and /h or /mo aligned with the selected game language.
        return LocalizedNumber.renderString(localization, {
            value,
            unit,
            signed: false,
        });
    } catch {
        const suffix =
            unit === Unit.IntegerPerMonth
                ? " /mo"
                : unit === Unit.IntegerPerHour
                    ? " /h"
                    : "";

        return `${Math.round(Math.abs(value)).toString()}${suffix}`;
    }
};

const getTooltipValueSize = (value: number): string => {
    const percent = Math.min(130, Math.max(90, Number(value) || 100));
    return `${percent / 100}em`;
};

const trimLabelPunctuation = (label: string): string => {
    return label.replace(/[\s:：]+$/u, "");
};

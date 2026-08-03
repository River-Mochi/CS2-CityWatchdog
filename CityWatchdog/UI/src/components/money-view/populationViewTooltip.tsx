// File: src/UI/src/components/money-view/populationViewTooltip.tsx
// Purpose: Adds CWD population flow rows to the vanilla population tooltip.

import { bindValue, useValue } from "cs2/api";
import { infoview } from "cs2/bindings";
import { LocalizedNumber, Unit, useLocalization, type Localization } from "cs2/l10n";
import { useText } from "../shared/localization";
import { Children, isValidElement, type CSSProperties, type ReactNode } from "react";
import { moneyView$, populationTooltipFontScale$ } from "../../bindings/bindings";
import styles from "./moneyView.module.scss";
import { getDisplayWholeValue, getNumericValue, getSignedAmountTone, POPULATION_ICON } from "./moneyViewShared";

// Every figure here comes from vanilla's PopulationInfoviewUISystem — the same source as the vanilla
// population info view (births, deaths, moved in/out, homeless), so CWD runs no sim queries of its own.
// unemployment IS in the generated cs2/bindings types, so it's read straight off infoview.* below.
// homeless (head-count) and homelessness (homeless as a % of residents) are NOT in the generated types
// yet, so bind them by name from the same "populationInfo" group. Both rates are pre-computed by the
// game as a 0–100 percent (Count*Data*System.*Rate = 100f * …), so CWD only displays — it never computes.
const homeless$ = bindValue<number>("populationInfo", "homeless", 0);
const homelessness$ = bindValue<number>("populationInfo", "homelessness", 0);

export const PopulationViewTooltipContent = ({ baseContent }: { readonly baseContent: ReactNode }) => {
    const localization = useLocalization();
    const text = useText();
    const moneyViewEnabled = useValue(moneyView$);
    const populationTooltipFontScale = useValue(populationTooltipFontScale$);
    const unemployment = getNumericValue(useValue(infoview.unemployment$));

    // These come from vanilla PopulationInfoviewUISystem, so CWD does not need its own sim queries.
    const births = getNumericValue(useValue(infoview.birthRate$));
    const deaths = getNumericValue(useValue(infoview.deathRate$));
    const homeless = getNumericValue(useValue(homeless$));
    const homelessRate = getNumericValue(useValue(homelessness$));
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
            <PopulationTooltipUnemployment
                localization={localization}
                label={text("PopulationTooltipUnemployment", "Unemployment:")}
                value={unemployment}
            />
            <div className={styles.populationTooltipExtra}>
                <PopulationTooltipFlow
                    localization={localization}
                    label={text("PopulationTooltipBirths", "Births:")}
                    value={births}
                    direction={1}
                />
                <PopulationTooltipFlow
                    localization={localization}
                    label={text("PopulationTooltipDeaths", "Deaths:")}
                    value={deaths}
                    direction={-1}
                />
                <PopulationTooltipFlow
                    localization={localization}
                    label={text("PopulationTooltipMovedIn", "Moved in:")}
                    value={movedIn}
                    direction={1}
                />
                <PopulationTooltipFlow
                    localization={localization}
                    label={text("PopulationTooltipMovedOut", "Moved out:")}
                    value={movedAway}
                    direction={-1}
                />
                <PopulationTooltipHomeless
                    localization={localization}
                    label={text("PopulationTooltipHomeless", "Homeless:")}
                    count={homeless}
                    rate={homelessRate}
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

const PopulationTooltipFlow = ({
    localization,
    label,
    value,
    direction,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
    readonly direction: 1 | -1;
}) => {
    const displayValue = getDisplayWholeValue(value);

    // Births/moved-in add population; deaths/moved-out subtract population.
    const signedValue = displayValue === 0 ? 0 : displayValue * direction;

    return (
        <PopulationTooltipRate
            localization={localization}
            label={label}
            value={signedValue}
            unit={Unit.IntegerPerMonth}
        />
    );
};

const PopulationTooltipHomeless = ({
    localization,
    label,
    count,
    rate,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly count: number;
    readonly rate: number;
}) => {
    // Vanilla shows both the homeless head-count and its share of residents — mirror that as "524 (0.5%)".
    // Count is a whole integer; the rate is a small 0–100 percent kept to one decimal so a sub-1% still reads.
    const countText = formatLocalizedIntegerValue(localization, getDisplayWholeValue(count), Unit.Integer);
    const rateText = formatLocalizedIntegerValue(localization, rate, Unit.PercentageSingleFraction);

    return (
        <div className={styles.populationTooltipGroup}>
            <div className={styles.tooltipLabel}>{trimLabelPunctuation(label)}</div>
            <div className={`${styles.populationTooltipValueLine} ${styles.softNeutral}`}>
                {`${countText} (${rateText})`}
            </div>
        </div>
    );
};

const PopulationTooltipUnemployment = ({
    localization,
    label,
    value,
}: {
    readonly localization: Localization;
    readonly label: string;
    readonly value: number;
}) => {
    // Unemployment is a level (a 0–100 percent), not a +/- flow: neutral tone, no sign, whole percent.
    const displayValue = getDisplayWholeValue(value);

    return (
        <PopulationTooltipRate
            localization={localization}
            label={label}
            value={displayValue}
            unit={Unit.Percentage}
            topRow={true}
            toneOverride="softNeutral"
            showSign={false}
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

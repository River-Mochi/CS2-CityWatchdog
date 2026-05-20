import { useValue } from "cs2/api";
import { economyBudget, toolbarBottom } from "cs2/bindings";
import type { ModuleRegistryExtend } from "cs2/modding";
import { Children, cloneElement, isValidElement, type ReactElement, type ReactNode } from "react";
import { minimalTrendTooltip$, trendDisplayMode$, trendTracker$ } from "../Bindings/Bindings";
import styles from "./ToolbarTrendTracker.module.scss";

const MONEY_ICON = "Media/Game/Icons/Money.svg";
const POPULATION_ICON = "Media/Game/Icons/Citizen.svg";
const TREND_DISPLAY_MODE_MONTHLY = 1;
const HOURS_PER_GAME_MONTH = 24;

type TrendTone = "positive" | "negative" | "neutral";

export const StatFieldTrendTrackerExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        const result = Component(props);
        const trendText = getTrendText(props);

        if (!trendText || !isValidElement(result)) {
            return result;
        }

        return appendTrendText(result, trendText);
    };
};

// MoneyField is already captured by the vanilla toolbar before this mod can reliably wrap it.
// Hook the shared DescriptionTooltip instead, then filter to the money toolbar child only.
export const DescriptionTooltipTrendTrackerExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        if (!isMoneyTooltip(props)) {
            return Component(props);
        }

        return Component({
            ...props,
            title: null,
            description: null,
            content: <MoneyTrendTooltipContent baseContent={props.content} />,
        });
    };
};

const getTrendText = (props: any): ReactNode | null => {
    if (props?.unlimited === true) {
        return null;
    }

    if (props?.icon === MONEY_ICON) {
        return <MoneyTrendText />;
    }

    if (props?.icon === POPULATION_ICON) {
        return <PopulationTrendText />;
    }

    return null;
};

const appendTrendText = (element: ReactElement<any>, trendText: ReactNode): ReactElement<any> => {
    return cloneElement(
        element,
        undefined,
        <>
            {element.props.children}
            {trendText}
        </>
    );
};

const MoneyTrendText = () => {
    const trendTracker = useValue(trendTracker$);
    const trendDisplayMode = useValue(trendDisplayMode$);
    const unlimitedMoney = useValue(toolbarBottom.unlimitedMoney$);
    const moneyDelta = useValue(toolbarBottom.moneyDelta$);
    const totalIncome = useValue(economyBudget.totalIncome$);
    const totalExpenses = useValue(economyBudget.totalExpenses$);

    if (!trendTracker || unlimitedMoney) {
        return null;
    }

    const monthlyMoney = getNumericValue(totalIncome) - Math.abs(getNumericValue(totalExpenses));
    const displayedValue = trendDisplayMode === TREND_DISPLAY_MODE_MONTHLY
        ? monthlyMoney
        : getNumericValue(moneyDelta);

    return <TrendText value={displayedValue} displayMode={trendDisplayMode} />;
};

const PopulationTrendText = () => {
    const trendTracker = useValue(trendTracker$);
    const trendDisplayMode = useValue(trendDisplayMode$);
    const populationDelta = useValue(toolbarBottom.populationDelta$);

    if (!trendTracker) {
        return null;
    }

    const displayedValue = trendDisplayMode === TREND_DISPLAY_MODE_MONTHLY
        ? getNumericValue(populationDelta) * HOURS_PER_GAME_MONTH
        : getNumericValue(populationDelta);

    return <TrendText value={displayedValue} displayMode={trendDisplayMode} />;
};

const TrendText = ({ value, displayMode }: { readonly value: number; readonly displayMode: number }) => {
    const tone = getTrendTone(value);
    const suffix = displayMode === TREND_DISPLAY_MODE_MONTHLY ? "/m" : "/h";
    const text = `${formatToolbarTrendValue(value)}\u00A0${suffix}`;

    return (
        <div className={`${styles.trendText} ${styles[tone]}`}>
            {text}
        </div>
    );
};

const MoneyTrendTooltipContent = ({ baseContent }: { readonly baseContent: ReactNode }) => {
    const trendTracker = useValue(trendTracker$);
    const minimalTrendTooltip = useValue(minimalTrendTooltip$);
    const hourlyTrend = getNumericValue(useValue(toolbarBottom.moneyDelta$));
    const monthlyIncome = getNumericValue(useValue(economyBudget.totalIncome$));
    const monthlyExpenses = -Math.abs(getNumericValue(useValue(economyBudget.totalExpenses$)));
    const monthlyBalance = monthlyIncome + monthlyExpenses;
    const hourlyIncome = monthlyIncome / HOURS_PER_GAME_MONTH;
    const hourlyExpenses = monthlyExpenses / HOURS_PER_GAME_MONTH;

    // Current total city money same as vanilla bottom toolbar.
    const totalMoney = getNumericValue(useValue(toolbarBottom.money$));

    if (!trendTracker) {
        return <>{baseContent}</>;
    }

    return (
        <div className={styles.tooltipRows}>
            <div className={styles.tooltipTitle}>WATCHDOG</div>
            <TrendTooltipGroup label="Income:" hourlyValue={hourlyIncome} monthlyValue={monthlyIncome} compact={minimalTrendTooltip} />
            <TrendTooltipGroup label="Expenses:" hourlyValue={hourlyExpenses} monthlyValue={monthlyExpenses} compact={minimalTrendTooltip} />
            <TrendTooltipGroup label="Net:" hourlyValue={hourlyTrend} monthlyValue={monthlyBalance} compact={minimalTrendTooltip} />
            {!minimalTrendTooltip && <TrendTooltipSingleValue label="Total:" value={totalMoney} />}
        </div>
    );
};





const isMoneyTooltip = (props: any): boolean => {
    return Boolean(props?.content) && containsIcon(props?.children, MONEY_ICON);
};

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

const TrendTooltipGroup = ({ label, hourlyValue, monthlyValue, compact }: { readonly label: string; readonly hourlyValue: number; readonly monthlyValue: number; readonly compact: boolean }) => {
    return (
        <div className={styles.tooltipGroup}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={styles.tooltipValueColumn}>
                <TrendTooltipValue value={hourlyValue} suffix="/h" compact={compact} />
                <TrendTooltipValue value={monthlyValue} suffix="/mo" compact={compact} />
            </div>
        </div>
    );
};


const TrendTooltipSingleValue = ({ label, value }: { readonly label: string; readonly value: number }) => {
    const tone = getTrendTone(value);
    const text = formatTooltipMoneyValue(value);

    return (
        <div className={styles.tooltipGroup}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={styles.tooltipValueColumn}>
                <div className={`${styles.tooltipValueLine} ${styles[tone]}`}>{text}</div>
            </div>
        </div>
    );
};


const TrendTooltipValue = ({ value, suffix, compact }: { readonly value: number; readonly suffix: string; readonly compact: boolean }) => {
    const tone = getTrendTone(value);
    const text = `${formatTooltipTrendValue(value, compact)}\u00A0${suffix}`;

    return <div className={`${styles.tooltipValueLine} ${styles[tone]}`}>{text}</div>;
};

const getTrendTone = (value: number): TrendTone => {
    if (value > 0) {
        return "positive";
    }

    if (value < 0) {
        return "negative";
    }

    return "neutral";
};

const getNumericValue = (value: number): number => {
    return Number.isFinite(value) ? value : 0;
};

// thin space after +/- sign for readability only in Tooltip.
const formatTrendValue = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+\u200A" : value < 0 ? "-\u200A" : "";
    return `${sign}${roundedValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")}`;
};

const formatTooltipTrendValue = (value: number, compact: boolean): string => {
    return compact ? formatToolbarTrendValue(value) : formatTrendValue(value);
};

// don't add plus sign for Total money.
const formatTooltipMoneyValue = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value < 0 ? "-\u200A" : "";
    return `${sign}${roundedValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")}`;
};

const formatToolbarTrendValue = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+" : value < 0 ? "-" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatCompactNumber(roundedValue / 1_000_000_000)}B`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatCompactNumber(roundedValue / 1_000_000)}M`;
    }

    return `${sign}${roundedValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")}`;
};

const formatCompactNumber = (value: number): string => {
    if (value >= 100) {
        return Math.round(value).toString();
    }

    if (value >= 10) {
        return value.toFixed(1).replace(/\.0$/, "");
    }

    return value.toFixed(2).replace(/\.?0+$/, "");
};

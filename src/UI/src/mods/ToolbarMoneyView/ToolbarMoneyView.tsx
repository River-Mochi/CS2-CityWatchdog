import { useValue } from "cs2/api";
import { economyBudget, toolbarBottom } from "cs2/bindings";
import { useLocalization } from "cs2/l10n";
import type { ModuleRegistryExtend } from "cs2/modding";
import { Children, cloneElement, isValidElement, type ReactElement, type ReactNode } from "react";
import { moneyTooltipMode$, moneyViewDisplayMode$, moneyView$ } from "../Bindings/Bindings";
import styles from "./ToolbarMoneyView.module.scss";

const MONEY_ICON = "Media/Game/Icons/Money.svg";
const POPULATION_ICON = "Media/Game/Icons/Citizen.svg";
const MONEY_VIEW_DISPLAY_MODE_MONTHLY = 1;
const MONEY_TOOLTIP_MODE_DEFAULT = 0;
const MONEY_TOOLTIP_MODE_COMPACT = 1;
const MONEY_TOOLTIP_MODE_MINI = 2;
// CS2 budget totals are monthly, while the vanilla toolbar trend is hourly.
const HOURS_PER_GAME_MONTH = 24;

type SignedAmountTone = "positive" | "negative" | "neutral";

const wholeNumberFormatter = new Intl.NumberFormat("en-US", {
    maximumFractionDigits: 0,
});

export const StatFieldMoneyViewExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        const result = Component(props);
        const moneyViewText = getMoneyViewText(props);

        if (!moneyViewText || !isValidElement(result)) {
            return result;
        }

        return appendMoneyViewText(result, moneyViewText);
    };
};

// MoneyField is already captured by the vanilla toolbar before this mod can reliably wrap it.
// Hook the shared DescriptionTooltip instead, then filter to the money toolbar child only.
export const DescriptionTooltipMoneyViewExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        if (!isMoneyTooltip(props)) {
            return Component(props);
        }

        return Component({
            ...props,
            title: null,
            description: null,
            content: <MoneyViewTooltipContent baseContent={props.content} />,
        });
    };
};

const getMoneyViewText = (props: any): ReactNode | null => {
    if (props?.unlimited === true) {
        return null;
    }

    if (props?.icon === MONEY_ICON) {
        return <ToolbarMoneyDelta />;
    }

    if (props?.icon === POPULATION_ICON) {
        return <ToolbarPopulationDelta />;
    }

    return null;
};

const appendMoneyViewText = (element: ReactElement<any>, moneyViewText: ReactNode): ReactElement<any> => {
    return cloneElement(
        element,
        undefined,
        <>
            {element.props.children}
            {moneyViewText}
        </>
    );
};

const ToolbarMoneyDelta = () => {
    const moneyViewEnabled = useValue(moneyView$);
    const moneyViewDisplayMode = useValue(moneyViewDisplayMode$);
    const unlimitedMoney = useValue(toolbarBottom.unlimitedMoney$);
    const moneyDelta = useValue(toolbarBottom.moneyDelta$);
    const totalIncome = useValue(economyBudget.totalIncome$);
    const totalExpenses = useValue(economyBudget.totalExpenses$);

    if (!moneyViewEnabled || unlimitedMoney) {
        return null;
    }

    // Normalize Budget expenses before net monthly income is calculated.
    const normalizedMonthlyExpenses = -Math.abs(getNumericValue(totalExpenses));
    const monthlyMoney = getNumericValue(totalIncome) + normalizedMonthlyExpenses;
    const displayedValue = moneyViewDisplayMode === MONEY_VIEW_DISPLAY_MODE_MONTHLY
        ? monthlyMoney
        : getNumericValue(moneyDelta);

    return <ToolbarTrendAmount value={displayedValue} displayMode={moneyViewDisplayMode} />;
};

const ToolbarPopulationDelta = () => {
    const moneyViewEnabled = useValue(moneyView$);
    const moneyViewDisplayMode = useValue(moneyViewDisplayMode$);
    const populationDelta = useValue(toolbarBottom.populationDelta$);

    if (!moneyViewEnabled) {
        return null;
    }

    const displayedValue = moneyViewDisplayMode === MONEY_VIEW_DISPLAY_MODE_MONTHLY
        ? getNumericValue(populationDelta) * HOURS_PER_GAME_MONTH
        : getNumericValue(populationDelta);

    return <ToolbarTrendAmount value={displayedValue} displayMode={moneyViewDisplayMode} />;
};

const ToolbarTrendAmount = ({ value, displayMode }: { readonly value: number; readonly displayMode: number }) => {
    const tone = getSignedAmountTone(value);
    const suffix = displayMode === MONEY_VIEW_DISPLAY_MODE_MONTHLY ? "/mo" : "/h";
    const text = `${formatToolbarMoneyViewValue(value)}\u00A0${suffix}`;

    return (
        <div className={`${styles.moneyViewText} ${styles[tone]}`}>
            {text}
        </div>
    );
};

const MoneyViewTooltipContent = ({ baseContent }: { readonly baseContent: ReactNode }) => {
    const { translate } = useLocalization();
    const localize = (key: string, fallback: string) => translate(`CityWatchdog.UI[${key}]`) ?? fallback;
    const moneyViewEnabled = useValue(moneyView$);
    const moneyTooltipMode = useValue(moneyTooltipMode$);
    const hourlyNet = getNumericValue(useValue(toolbarBottom.moneyDelta$));
    const monthlyIncome = getNumericValue(useValue(economyBudget.totalIncome$));
    // Normalize Budget expenses before net monthly income is calculated.
    const monthlyExpenses = -Math.abs(getNumericValue(useValue(economyBudget.totalExpenses$)));
    const monthlyBalance = monthlyIncome + monthlyExpenses;
    const hourlyIncome = monthlyIncome / HOURS_PER_GAME_MONTH;
    const hourlyExpenses = monthlyExpenses / HOURS_PER_GAME_MONTH;

    // Current total city money same as vanilla bottom toolbar.
    const totalMoney = getNumericValue(useValue(toolbarBottom.money$));

    if (!moneyViewEnabled) {
        return <>{baseContent}</>;
    }

    const compact = moneyTooltipMode !== MONEY_TOOLTIP_MODE_DEFAULT;
    const mini = moneyTooltipMode === MONEY_TOOLTIP_MODE_MINI;
    const tooltipClassName = getTooltipRowsClassName(moneyTooltipMode);

    return (
        <div className={tooltipClassName}>
            <div className={styles.tooltipTitle}>WATCHDOG</div>
            {!mini && <MoneyViewTooltipGroup label={localize("MoneyViewTooltipIncome", "Income:")} hourlyValue={hourlyIncome} monthlyValue={monthlyIncome} compact={compact} mode={moneyTooltipMode} />}
            {!mini && <MoneyViewTooltipGroup label={localize("MoneyViewTooltipExpenses", "Expenses:")} hourlyValue={hourlyExpenses} monthlyValue={monthlyExpenses} compact={compact} mode={moneyTooltipMode} />}
            <MoneyViewTooltipGroup label={localize("MoneyViewTooltipNet", "Net:")} hourlyValue={hourlyNet} monthlyValue={monthlyBalance} compact={compact} mode={moneyTooltipMode} />
            {moneyTooltipMode === MONEY_TOOLTIP_MODE_DEFAULT && <MoneyViewTooltipSingleValue label={localize("MoneyViewTooltipTotal", "Total:")} value={totalMoney} mode={moneyTooltipMode} />}
        </div>
    );
};

const getTooltipRowsClassName = (mode: number): string => {
    const classes = [styles.tooltipRows];

    if (mode === MONEY_TOOLTIP_MODE_MINI) {
        classes.push(styles.tooltipRowsMini);
    } else if (mode === MONEY_TOOLTIP_MODE_COMPACT) {
        classes.push(styles.tooltipRowsCompact);
    } else {
        classes.push(styles.tooltipRowsFull);
    }

    return classes.join(" ");
};

const isMoneyTooltip = (props: any): boolean => {
    return Boolean(props?.content) && containsIcon(props?.children, MONEY_ICON);
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

const MoneyViewTooltipGroup = ({ label, hourlyValue, monthlyValue, compact, mode }: { readonly label: string; readonly hourlyValue: number; readonly monthlyValue: number; readonly compact: boolean; readonly mode: number }) => {
    return (
        <div className={styles.tooltipGroup}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={styles.tooltipValueColumn}>
                <MoneyViewTooltipValue value={hourlyValue} suffix="/h" compact={compact} mode={mode} />
                <MoneyViewTooltipValue value={monthlyValue} suffix="/mo" compact={compact} mode={mode} />
            </div>
        </div>
    );
};


const MoneyViewTooltipSingleValue = ({ label, value, mode }: { readonly label: string; readonly value: number; readonly mode: number }) => {
    const tone = getSignedAmountTone(value);
    const text = formatTooltipMoneyValue(value);

    return (
        <div className={styles.tooltipGroup}>
            <div className={styles.tooltipLabel}>{label}</div>
            <div className={styles.tooltipValueColumn}>
                <div className={`${styles.tooltipValueLine} ${getTooltipValueClassName(mode)} ${styles[tone]}`}>{text}</div>
            </div>
        </div>
    );
};


const MoneyViewTooltipValue = ({ value, suffix, compact, mode }: { readonly value: number; readonly suffix: string; readonly compact: boolean; readonly mode: number }) => {
    const tone = getSignedAmountTone(value);
    const text = `${formatTooltipMoneyViewValue(value, compact)}\u00A0${suffix}`;

    return <div className={`${styles.tooltipValueLine} ${getTooltipValueClassName(mode)} ${styles[tone]}`}>{text}</div>;
};

const getTooltipValueClassName = (mode: number): string => {
    if (mode === MONEY_TOOLTIP_MODE_MINI) {
        return styles.tooltipValueLineMini;
    }

    if (mode === MONEY_TOOLTIP_MODE_COMPACT) {
        return styles.tooltipValueLineCompact;
    }

    return styles.tooltipValueLineFull;
};

const getSignedAmountTone = (value: number): SignedAmountTone => {
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

const formatSignedWholeNumber = (
    value: number,
    includePositiveSign: boolean,
    useThinSpace: boolean
): string => {
    const magnitude = wholeNumberFormatter.format(Math.round(Math.abs(value)));
    const spacer = useThinSpace ? "\u200A" : "";

    if (value > 0 && includePositiveSign) {
        return `+${spacer}${magnitude}`;
    }

    if (value < 0) {
        return `-${spacer}${magnitude}`;
    }

    return magnitude;
};

const formatTooltipMoneyViewValue = (value: number, compact: boolean): string => {
    return compact ? formatCompactTooltipValue(value) : formatSignedWholeNumber(value, true, true);
};

// don't add plus sign for Total money.
const formatTooltipMoneyValue = (value: number): string => {
    return formatSignedWholeNumber(value, false, true);
};

const formatToolbarMoneyViewValue = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+" : value < 0 ? "-" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatCompactNumber(roundedValue / 1_000_000_000)}B`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatCompactNumber(roundedValue / 1_000_000)}M`;
    }

    return formatSignedWholeNumber(value, true, false);
};

const formatCompactTooltipValue = (value: number): string => {
    const roundedValue = Math.round(Math.abs(value));
    const sign = value > 0 ? "+\u200A" : value < 0 ? "-\u200A" : "";

    if (roundedValue >= 1_000_000_000) {
        return `${sign}${formatFixedCompactNumber(roundedValue / 1_000_000_000)}B`;
    }

    if (roundedValue >= 1_000_000) {
        return `${sign}${formatFixedCompactNumber(roundedValue / 1_000_000)}M`;
    }

    return formatSignedWholeNumber(value, true, true);
};

const formatCompactNumber = (value: number): string => {
    if (value >= 100) {
        return Math.round(value).toString();
    }

    return value.toFixed(2);
};

const formatFixedCompactNumber = (value: number): string => {
    if (value >= 100) {
        return Math.round(value).toString();
    }

    return value.toFixed(2);
};

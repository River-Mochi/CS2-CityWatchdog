// File: src/UI/src/mods/MoneyView/MoneyView.tsx
// Purpose: Hooks vanilla toolbar/tooltip exports to inject City Watchdog Money View UI.

import { useValue } from "cs2/api";
import type { ModuleRegistryExtend } from "cs2/modding";
import { cloneElement, isValidElement, type ReactElement, type ReactNode } from "react";
import { disableMoneyTooltips$ } from "../Bindings/Bindings";
import { MoneyViewTooltipContent, isMoneyTooltip } from "./MoneyViewTooltip";
import { PopulationViewTooltipContent, isPopulationTooltip } from "./PopulationViewTooltip";
import { ToolbarMoneyDelta, ToolbarPopulationDelta } from "./ToolbarTrendAmount";
import { MONEY_ICON, POPULATION_ICON } from "./moneyViewShared";

export const StatFieldMoneyViewExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        const result = Component(props);
        const moneyViewText = getMoneyViewText(props);

        if (!moneyViewText || !isValidElement(result)) {
            return result;
        }

        // Keep the vanilla stat field intact, then append the CWD trend value beside it.
        return appendMoneyViewText(result, moneyViewText);
    };
};

// MoneyField is already captured by the vanilla toolbar before this mod can reliably wrap it.
// Hook the shared DescriptionTooltip instead, then filter to the money/population toolbar children.
export const DescriptionTooltipMoneyViewExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        if (isMoneyTooltip(props)) {
            return <MoneyTooltipGate Component={Component} originalProps={props} kind="money" />;
        }

        if (isPopulationTooltip(props)) {
            return <MoneyTooltipGate Component={Component} originalProps={props} kind="population" />;
        }

        return Component(props);
    };
};

// Inner React component so useValue stays reactive: toggling DisableMoneyTooltips from the
// panel's $ button immediately re-renders this gate and either renders the tooltip or null.
const MoneyTooltipGate = ({
    Component,
    originalProps,
    kind,
}: {
    Component: any;
    originalProps: any;
    kind: "money" | "population";
}) => {
    const disabled = useValue(disableMoneyTooltips$);
    if (disabled) {
        return null;
    }

    if (kind === "money") {
        return Component({
            ...originalProps,
            title: null,
            description: null,
            content: <MoneyViewTooltipContent baseContent={originalProps.content} />,
        });
    }

    return Component({
        ...originalProps,
        title: null,
        description: null,
        content: <PopulationViewTooltipContent baseContent={originalProps.content} />,
    });
};

const getMoneyViewText = (props: any): ReactNode | null => {
    if (props?.unlimited === true) {
        return null;
    }

    // Vanilla icon props identify which stat field is being extended.
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

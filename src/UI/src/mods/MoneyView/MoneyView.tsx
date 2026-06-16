// File: src/UI/src/mods/MoneyView/MoneyView.tsx
// Purpose: Hooks vanilla toolbar/tooltip exports to inject City Watchdog Money View UI.

import { useValue } from "cs2/api";
import type { ModuleRegistryExtend } from "cs2/modding";
import { cloneElement, isValidElement, type ReactElement, type ReactNode } from "react";
import { disableAllTooltips$ } from "../Bindings/Bindings";
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
// Hook the shared DescriptionTooltip instead. Filter for our money/population case first; for
// every other DescriptionTooltip in the game (top-bar City Name, button hovers, etc.), defer to
// the Info-button gate so the popup is suppressed when global toggle is on.
//
// Money/population popups are controlled exclusively by Setting.MoneyView in the Options UI,
// NOT by the in-game Info button or the title-bar CWD-icon panel-tooltip toggle.
export const DescriptionTooltipMoneyViewExtension: ModuleRegistryExtend = (Component: any) => {
    return (props: any) => {
        if (isMoneyTooltip(props)) {
            return Component({
                ...props,
                title: null,
                description: null,
                content: <MoneyViewTooltipContent baseContent={props.content} />,
            });
        }

        if (isPopulationTooltip(props)) {
            return Component({
                ...props,
                title: null,
                description: null,
                content: <PopulationViewTooltipContent baseContent={props.content} />,
            });
        }

        return <DescriptionTooltipGate Component={Component} originalProps={props} />;
    };
};

// Inner React component so useValue stays reactive: toggling the Info button immediately
// re-renders this gate. When global toggle is on we render only the children (the host button /
// label stays visible) — no balloon popup. Returning null would strip the host too.
const DescriptionTooltipGate = ({
    Component,
    originalProps,
}: {
    Component: any;
    originalProps: any;
}) => {
    const allTooltipsDisabled = useValue(disableAllTooltips$);
    if (allTooltipsDisabled) {
        return <>{originalProps.children}</>;
    }
    return Component(originalProps);
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

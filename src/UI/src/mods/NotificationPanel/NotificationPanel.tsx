// File: src/UI/src/mods/NotificationPanel/NotificationPanel.tsx
// Purpose: In-city CWD notification icon panel and buttons.

import { useValue } from "cs2/api";
import { game } from "cs2/bindings";
import { useLocalization } from "cs2/l10n";
import { getModule } from "cs2/modding";
import { Button, Panel, Tooltip } from "cs2/ui";
import { useState, type ReactElement, type ReactNode } from "react";
import {
    controlPanelEnabled$,
    disableAllTooltips$,
    disableCwdTooltips$,
    OnControlPanelBindingToggle,
    OnDisableAllTooltipsToggle,
    OnDisableCwdTooltipsToggle,
} from "../Bindings/Bindings";
import { Divider } from "../Divider/Divider";
import { InfoPanel } from "../InfoPanel/InfoPanel";
import { KEEP_MARKER_CLASS } from "../Tooltip/tooltipBlocker";
import { VanillaComponentResolver } from "../VanillaComponentResolver/VanillaComponentResolver";
import { NotificationRow } from "./NotificationRow";
import styles from "./NotificationPanel.module.scss";
import {
    allIconSources,
    createExpandedSections,
    sections,
    setAllNotifications,
    type Localize,
    type NotificationSection,
} from "./notificationData";
import { useAllNotificationValues, useSectionValues } from "./notificationHooks";

// Title icon is a custom mod image emitted by webpack to coui://ui-mods/images/.
import TitleBarIconPath from "../../../images/NotificationIcon_TitleBar.svg";

// Sort icons are custom mod images emitted by webpack to coui://ui-mods/images/.
import SortArrowUpPath from "../../../images/sort-arrow-up.svg";
import SortArrowDownPath from "../../../images/sort-arrow-down.svg";

// Money toggle icon is a custom mod image emitted by webpack to coui://ui-mods/images/.
import MoneyToggleIconPath from "../../../images/People-money.svg";

const modIconSrc = TitleBarIconPath;
const sortArrowUpSrc = SortArrowUpPath;
const sortArrowDownSrc = SortArrowDownPath;
const moneyIconSrc = MoneyToggleIconPath;

// Info icon uses the built-in game media path.
const infoIconSrc = "Media/Game/Icons/AdvisorInfoViewWhite.svg";

// Toolbar icons use built-in game media paths.
// All.svg is the vanilla snap-options "all" icon.
const toggleAllIconSrc = "Media/Tools/Snap Options/All.svg";

// ParallelPlus / ParallelMinus are used as compact expand/collapse icons.
const expandAllIconSrc = "Media/Tools/Net Tool/ParallelPlus.svg";
const collapseAllIconSrc = "Media/Tools/Net Tool/ParallelMinus.svg";

const roundButtonHighlightStyle = getModule("game-ui/common/input/button/themes/round-highlight-button.module.scss", "classes");

export const NotificationPanel = () => {
    const showPanel = useValue(controlPanelEnabled$);
    const isPhotoMode = useValue(game.activeGamePanel$)?.__Type == game.GamePanelType.PhotoMode;

    if (isPhotoMode || !showPanel) {
        return null;
    }

    return <NotificationPanelContent />;
};

const NotificationPanelContent = () => {
    const { translate } = useLocalization();
    const [sortAscending, setSortAscending] = useState(true);
    // disableAllTooltips$ — Info button: vanilla game tooltips. CWD tooltips are exempt via the keep marker.
    const allTooltipsDisabled = useValue(disableAllTooltips$);
    // disableCwdTooltips$ — People-money button: every CWD tooltip (panel + money/population).
    const cwdTooltipsDisabled = useValue(disableCwdTooltips$);
    // Panel-internal helpers gate on the CWD binding so the user can still kill the panel's chatty tooltips.
    const tooltipsEnabled = !cwdTooltipsDisabled;
    const [expandedSections, setExpandedSections] = useState(createExpandedSections);
    const allValues = useAllNotificationValues();

    const allSelected = allValues.every(Boolean);
    const anySelected = allValues.some(Boolean);
    const selectedTotalCount = allValues.filter(Boolean).length;
    const totalNotificationCount = allValues.length;
    const toggleAllStateClass = allSelected
        ? styles.toggleAllOn
        : anySelected
            ? styles.toggleAllPartial
            : styles.toggleAllOff;

    const allSectionsExpanded = sections.every((section) => expandedSections[section.localeId] === true);

    // sortAscending is the current list state.
    // The button shows the next action: descending icon while the list is currently ascending.
    const sortIconSrc = sortAscending ? sortArrowDownSrc : sortArrowUpSrc;

    const localize: Localize = (localeId, fallback, raw = false) => {
        if (raw) {
            return translate(localeId) ?? fallback ?? localeId;
        }

        return translate(`CityWatchdog.UI[${localeId}]`) ?? fallback ?? localeId;
    };

    const sortTooltip = sortAscending
        ? localize("SortDescending", "↓Sort Descending")
        : localize("SortAscending", "↑Sort Ascending");

    // Wraps tooltip text in a marker-bearing div so the tooltipBlocker CSS keeps the popup
    // visible even while the global toggle is on. The marker class lands on (a) the rendered
    // tooltip content's root div, and (b) — for the buttons that pass className to Tooltip —
    // the balloon itself. Either match is enough.
    const tooltipContent = (localeId: string, fallback: string) => {
        const tooltip = localize(localeId, fallback);
        const lines = tooltip.split("\n");

        if (lines.length <= 1) {
            return <div className={KEEP_MARKER_CLASS}>{tooltip}</div>;
        }

        return (
            <div className={`${styles.tooltipText} ${KEEP_MARKER_CLASS}`}>
                {lines.map((line, index) => (
                    <div key={`${localeId}-${index}`}>{line}</div>
                ))}
            </div>
        );
    };

    const titleBarTooltip = tooltipContent(
        "NotificationIconShowOrHide",
        "Expand rows; [✓] check to show, uncheck to hide alerts.\nDoes not fix city problems, it hides messy icons.",
    );

    // Same text regardless of toggle state — the button itself is always discoverable.
    const infoTooltip = tooltipContent(
        "TooltipToggle",
        "Show or Hide ALL game tooltips.\nClick to silence every tooltip until you click again.",
    );

    const moneyToggleTooltip = tooltipContent(
        "MoneyTooltipToggle",
        "Show or Hide Watchdog money and population tooltips.\nLeaves the rest of the panel alone.",
    );

    // CWD-internal tooltips (sort, expand, count, title-bar help) — skip render entirely when
    // the user turns CWD tooltips off via the People-money button. Cheaper than rendering and
    // hoping the blocker hits them.
    const optionalTooltip = (tooltip: ReactNode, children: ReactElement) => {
        if (cwdTooltipsDisabled) {
            return <>{children}</>;
        }

        return <Tooltip tooltip={tooltip} className={KEEP_MARKER_CLASS}>{children}</Tooltip>;
    };

    const orderedSections = [...sections].sort((a, b) => {
        const result = localize(a.localeId).localeCompare(localize(b.localeId));
        return sortAscending ? result : -result;
    });

    const onToggleAll = () => {
        setAllNotifications(!allSelected);
    };

    const onToggleAllSections = () => {
        setExpandedSections(createExpandedSections(!allSectionsExpanded));
    };

    const onSectionExpandedChange = (section: NotificationSection, expanded: boolean) => {
        setExpandedSections((current) => ({
            ...current,
            [section.localeId]: expanded,
        }));
    };

    return (
        <Panel
            className={styles.panel}
            header={
                <div className={styles.header}>
                    <div className={styles.headerTitleArea}>
                        {optionalTooltip(titleBarTooltip,
                            <img src={modIconSrc} className={styles.headerModIcon} />,
                        )}
                        <div className={styles.headerModName}>CITY WATCHDOG</div>
                    </div>
                    <Button
                        className={roundButtonHighlightStyle.button + " " + styles.headerCloseButton}
                        variant="icon"
                        onClick={() => { OnControlPanelBindingToggle(false); }}
                        focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                    >
                        <img src="coui://uil/Standard/XClose.svg"></img>
                    </Button>
                </div>
            }
        >
            {/* Left side: help + sort. Right side: mass actions. */}
            <div className={styles.toolbar}>
                <div className={styles.toolbarLeft}>
                    {/* Info button: toggles all vanilla game tooltips. Its own tooltip stays visible always. */}
                    <Tooltip tooltip={infoTooltip} className={KEEP_MARKER_CLASS}>
                        <div
                            className={`${styles.infoButton} ${allTooltipsDisabled ? styles.infoButtonTipsOff : ""}`}
                            role="button"
                            aria-pressed={allTooltipsDisabled}
                            onClick={() => { OnDisableAllTooltipsToggle(!allTooltipsDisabled); }}
                        >
                            <img src={infoIconSrc} className={styles.infoIcon} />
                        </div>
                    </Tooltip>

                    {/* People-money button: toggles every CWD tooltip (panel + money/pop). Its own tooltip stays visible. */}
                    <Tooltip tooltip={moneyToggleTooltip} className={KEEP_MARKER_CLASS}>
                        <div
                            className={`${styles.infoButton} ${cwdTooltipsDisabled ? styles.infoButtonTipsOff : ""}`}
                            role="button"
                            aria-pressed={cwdTooltipsDisabled}
                            onClick={() => { OnDisableCwdTooltipsToggle(!cwdTooltipsDisabled); }}
                        >
                            <img src={moneyIconSrc} className={styles.infoIcon} />
                        </div>
                    </Tooltip>

                    {optionalTooltip(sortTooltip,
                        <Button
                            className={`${styles.toolbarButton} ${styles.sortButton}`}
                            onClick={() => { setSortAscending(!sortAscending); }}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <img
                                src={sortIconSrc}
                                className={`${styles.toolbarIcon} ${styles.sortIcon}`}
                                alt=""
                            />
                        </Button>,
                    )}
                </div>

                <div className={styles.toolbarButtons}>
                    {optionalTooltip(allSectionsExpanded ? localize("CollapseAll", "Collapse All Rows") : localize("ExpandAll", "Expand All Rows"),
                        <Button
                            className={styles.toolbarButton + " " + styles.expandButton}
                            onClick={onToggleAllSections}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <img
                                src={allSectionsExpanded ? collapseAllIconSrc : expandAllIconSrc}
                                className={`${styles.toolbarIcon} ${styles.expandCollapseIcon}`}
                                alt=""
                            />
                        </Button>,
                    )}

                    {optionalTooltip(allSectionsExpanded ? localize("CollapseAll", "Collapse All Rows") : localize("ExpandAll", "Expand All Rows"),
                        <Button
                            className={`${styles.toolbarButton} ${styles.countButton} ${toggleAllStateClass}`}
                            onClick={onToggleAllSections}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <span className={styles.countButtonText}>
                                {selectedTotalCount}/{totalNotificationCount}
                            </span>
                        </Button>,
                    )}

                    {optionalTooltip(tooltipContent("ToggleAllTooltip", "Show/hide all icons.\nColor: green = all on; blue = mixed; red = all off."),
                        <Button
                            className={`${styles.toolbarButton} ${styles.toggleButton} ${toggleAllStateClass}`}
                            onClick={onToggleAll}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <span className={styles.toggleButtonText}>
                                {localize("ToggleAll", "Toggle All")}
                            </span>
                        </Button>,
                    )}

                </div>
            </div>

            <IconPreloader />

            {orderedSections.map((section, index) => (
                <NotificationSectionView
                    key={section.localeId}
                    section={section}
                    expanded={expandedSections[section.localeId] === true}
                    localize={localize}
                    showDivider={index > 0}
                    onExpandedChange={(expanded) => onSectionExpandedChange(section, expanded)}
                />
            ))}
        </Panel>
    );
};

const IconPreloader = () => {
    return (
        <div className={styles.iconPreloader} aria-hidden="true">
            {allIconSources.map((source) => (
                <img key={source} src={source} alt="" />
            ))}
        </div>
    );
};

const NotificationSectionView = ({
    section,
    expanded,
    localize,
    showDivider,
    onExpandedChange,
}: {
    section: NotificationSection;
    expanded: boolean;
    localize: Localize;
    showDivider: boolean;
    onExpandedChange: (expanded: boolean) => void;
}) => {
    const values = useSectionValues(section);
    const selectedCount = values.filter(Boolean).length;

    const summaryState =
        selectedCount === section.items.length
            ? "on"
            : selectedCount > 0
                ? "partial"
                : "off";

    return (
        <>
            {showDivider && <Divider></Divider>}
            <InfoPanel
                title={localize(section.localeId)}
                collapsible={true}
                expanded={expanded}
                onExpandedChange={onExpandedChange}
                summary={`${selectedCount}/${section.items.length}`}
                summaryState={summaryState}
                renderChildren={() => section.items.map((item, itemIndex) => (
                    <NotificationRow
                        key={item.localeId}
                        item={item}
                        isChecked={values[itemIndex] ?? false}
                        localize={localize}
                    />
                ))}
            />
        </>
    );
};

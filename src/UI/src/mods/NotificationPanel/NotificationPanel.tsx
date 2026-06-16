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
    hideRoadNames$,
    showRoadArrows$,
    OnControlPanelBindingToggle,
    OnDisableAllTooltipsToggle,
    OnDisableCwdTooltipsToggle,
    OnHideRoadNamesToggle,
    OnShowRoadArrowsToggle,
} from "../Bindings/Bindings";
import { Divider } from "../Divider/Divider";
import { InfoPanel } from "../InfoPanel/InfoPanel";
import { VanillaComponentResolver } from "../../utils/vanilla";
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

// Road-name toggle icons.
import RoadNameOnPath from "../../../images/icon-RoadNameOn-ABC.svg";
import RoadNameOffPath from "../../../images/icon-RoadNameOff.svg";

const modIconSrc = TitleBarIconPath;
const sortArrowUpSrc = SortArrowUpPath;
const sortArrowDownSrc = SortArrowDownPath;
const roadNameOnSrc = RoadNameOnPath;
const roadNameOffSrc = RoadNameOffPath;

// Info icon uses the built-in game media path.
const infoIconSrc = "Media/Game/Icons/AdvisorInfoViewWhite.svg";

// Road-arrow icon — vanilla one-way highway icon. Lives at
//   <CS2 install>/Cities2_Data/Content/Game/UI/Media/Game/Icons/HighwayOneway2lanes.svg
// We reference it by the same Media/ relative path the game uses internally, so no copy needed.
const roadArrowIconSrc = "Media/Game/Icons/HighwayOneway2lanes.svg";

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
    // disableAllTooltips$ — Info button: vanilla game hover tooltips.
    const allTooltipsDisabled = useValue(disableAllTooltips$);
    // disableCwdTooltips$ — controlled by clicking the CWD icon in the title bar.
    const cwdTooltipsDisabled = useValue(disableCwdTooltips$);
    // hideRoadNames$ — Road-Name toggle (or \ hotkey): vanilla aggregate road name labels.
    const roadNamesHidden = useValue(hideRoadNames$);
    // showRoadArrows$ — Road-Arrow toggle: force vanilla 1-way arrows on while browsing.
    const roadArrowsShown = useValue(showRoadArrows$);
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

    const tooltipContent = (localeId: string, fallback: string) => {
        const tooltip = localize(localeId, fallback);
        const lines = tooltip.split("\n");

        if (lines.length <= 1) {
            return tooltip;
        }

        return (
            <div className={styles.tooltipText}>
                {lines.map((line, index) => (
                    <div key={`${localeId}-${index}`}>{line}</div>
                ))}
            </div>
        );
    };

    // Title bar CWD icon is now BOTH a hover-help and a click toggle for panel tooltips.
    // Tooltip text switches based on the panel-tooltip state.
    const titleBarTooltip = cwdTooltipsDisabled
        ? tooltipContent(
            "TitleBarTooltipPanelOff",
            "Click to show City Watchdog panel tooltips.",
        )
        : tooltipContent(
            "TitleBarTooltipPanelOn",
            "Expand rows; [✓] check to show, uncheck to hide alerts.\nClick this icon to hide City Watchdog panel tooltips.",
        );

    // Same text regardless of toggle state — Info button is always discoverable.
    const infoTooltip = tooltipContent(
        "TooltipToggle",
        "Show/hide ALL game hover tooltips.\nCursor tooltips over buildings, cims, tools, and the small popups on game UI buttons.",
    );

    // Road-name toggle: state-aware text.
    const roadNameTooltip = roadNamesHidden
        ? tooltipContent(
            "RoadNameToggleOff",
            "Click to show road names.\nHotkey: \\",
        )
        : tooltipContent(
            "RoadNameToggleOn",
            "Click to hide road names.\nHotkey: \\",
        );

    // Road-arrow toggle: state-aware text. Default OFF (vanilla behavior — arrows only show
    // when a road/upgrade/bulldoze tool is active).
    const roadArrowTooltip = roadArrowsShown
        ? tooltipContent(
            "RoadArrowToggleOn",
            "Click to hide 1-way arrows.\nReturn to vanilla behavior (arrows only when using a road tool).",
        )
        : tooltipContent(
            "RoadArrowToggleOff",
            "Click to show 1-way road arrows on every road.\nNormally only visible while a road tool is active.",
        );

    // CWD-internal tooltips (sort, expand, count) — skip render entirely when
    // the user turns CWD tooltips off via the title-bar CWD icon.
    const optionalTooltip = (tooltip: ReactNode, children: ReactElement) => {
        if (cwdTooltipsDisabled) {
            return <>{children}</>;
        }

        return <Tooltip tooltip={tooltip}>{children}</Tooltip>;
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
                        {/* Title-bar CWD icon — now clickable. Toggles panel tooltips (was the People-money button). */}
                        <Tooltip tooltip={titleBarTooltip}>
                            <div
                                className={`${styles.headerModIconButton} ${cwdTooltipsDisabled ? styles.headerModIconOff : ""}`}
                                role="button"
                                aria-pressed={cwdTooltipsDisabled}
                                onClick={() => { OnDisableCwdTooltipsToggle(!cwdTooltipsDisabled); }}
                            >
                                <img src={modIconSrc} className={styles.headerModIcon} />
                            </div>
                        </Tooltip>
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
            {/* Left side: Info + Road-Name toggles. Right side: sort + mass actions. */}
            <div className={styles.toolbar}>
                <div className={styles.toolbarLeft}>
                    {/* Info button: toggles vanilla game tooltips (cursor-follow + DescriptionTooltip popups).
                        When off, the button turns red — a clear reminder the player has globally muted hover tooltips. */}
                    <Tooltip tooltip={infoTooltip}>
                        <div
                            className={`${styles.infoButton} ${allTooltipsDisabled ? styles.infoButtonAllOff : ""}`}
                            role="button"
                            aria-pressed={allTooltipsDisabled}
                            onClick={() => { OnDisableAllTooltipsToggle(!allTooltipsDisabled); }}
                        >
                            <img src={infoIconSrc} className={styles.infoIcon} />
                        </div>
                    </Tooltip>

                    {/* Road Name on/off toggle. Default state shows the "names on" icon; click flips it to "names off".
                        Backslash (\) hotkey is wired on the C# side. */}
                    <Tooltip tooltip={roadNameTooltip}>
                        <div
                            className={`${styles.infoButton} ${roadNamesHidden ? styles.infoButtonTipsOff : ""}`}
                            role="button"
                            aria-pressed={roadNamesHidden}
                            onClick={() => { OnHideRoadNamesToggle(!roadNamesHidden); }}
                        >
                            <img
                                src={roadNamesHidden ? roadNameOffSrc : roadNameOnSrc}
                                className={styles.infoIcon}
                            />
                        </div>
                    </Tooltip>

                    {/* Road Arrow toggle: forces vanilla 1-way arrows on while browsing.
                        Default OFF (vanilla behavior: arrows only visible with a road tool active). */}
                    <Tooltip tooltip={roadArrowTooltip}>
                        <div
                            className={`${styles.infoButton} ${roadArrowsShown ? styles.infoButtonTipsOff : ""}`}
                            role="button"
                            aria-pressed={roadArrowsShown}
                            onClick={() => { OnShowRoadArrowsToggle(!roadArrowsShown); }}
                        >
                            <img src={roadArrowIconSrc} className={styles.infoIcon} />
                        </div>
                    </Tooltip>
                </div>

                <div className={styles.toolbarButtons}>
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

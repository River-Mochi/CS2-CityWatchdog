// File: src/UI/src/mods/NotificationPanel/NotificationPanel.tsx
// Purpose: In-city CWD notification icon panel and buttons.

import { useValue } from "cs2/api";
import { game } from "cs2/bindings";
import { useLocalization } from "cs2/l10n";
import { getModule } from "cs2/modding";
import { useText } from "../shared/localization";
import { Button, Panel, Tooltip } from "cs2/ui";
import { useState, type ReactElement, type ReactNode } from "react";
import {
    controlPanelEnabled$,
    disableAllTooltips$,
    disableCwdTooltips$,
    hideDistrictNames$,
    hideRoadNames$,
    miniHudFavorites$,
    notificationCounts$,
    panelButtonsOnlyStart$,
    showRoadArrows$,
    OnControlPanelBindingToggle,
    OnDisableAllTooltipsToggle,
    OnDisableCwdTooltipsToggle,
    OnHideDistrictNamesToggle,
    OnHideRoadNamesToggle,
    OnShowRoadArrowsToggle,
    OnToggleMiniHudFavorite,
} from "../Bindings/Bindings";
import { Divider } from "../Divider/Divider";
import { InfoPanel } from "../InfoPanel/InfoPanel";
import { VanillaComponentResolver } from "../../utils/vanilla";
import { NotificationRow } from "./NotificationRow";
import styles from "./NotificationPanel.module.scss";
import {
    allIconSources,
    createExpandedSections,
    notificationCountIndexes,
    sections,
    setAllNotifications,
    type Localize,
    type NotificationSection,
} from "./notificationData";
import { useAllNotificationValues, useSectionValues } from "./notificationHooks";
import { usePanelDrag } from "./usePanelDrag";

// Title icon is a custom mod image emitted by webpack to coui://ui-mods/images/.
import TitleBarIconPath from "../../../images/NotificationIcon_TitleBar.svg";

// Sort icons are custom mod images emitted by webpack to coui://ui-mods/images/.
import SortArrowUpPath from "../../../images/sort-arrow-up.svg";
import SortArrowDownPath from "../../../images/sort-arrow-down.svg";

// Road-name toggle icon — user-provided max variant, CSS handles the blue "active" state.
import RoadNameOnPath from "../../../images/icon-RoadName-max.svg";

// District-name toggle icon — user-provided max variant tuned for small toolbar rendering.
import DistrictIconPath from "../../../images/Districts-max.svg";

// Road-arrow toggle icon — user-provided max variant tuned for small toolbar rendering.
import RoadArrowIconPath from "../../../images/icon-RoadArrows-max.svg";

const modIconSrc = TitleBarIconPath;
const sortArrowUpSrc = SortArrowUpPath;
const sortArrowDownSrc = SortArrowDownPath;
const roadNameOnSrc = RoadNameOnPath;
const districtIconSrc = DistrictIconPath;
const roadArrowIconSrc = RoadArrowIconPath;

// Info icon uses the built-in game media path.
const infoIconSrc = "Media/Game/Icons/AdvisorInfoViewWhite.svg";

const roundButtonHighlightStyle = getModule("game-ui/common/input/button/themes/round-highlight-button.module.scss", "classes");

// Panel-internal Tooltip wrapper. Two jobs:
//   1. Passes a `cwdBypass` flag the global TooltipGate extension reads, so panel tooltips stay
//      visible when the Info button mutes vanilla game tooltips (disableAllTooltips$).
//   2. Reads disableCwdTooltips$ itself — the CWD title-bar icon mutes panel tooltips by
//      returning just the children. `alwaysVisible` is for the Info button and the CWD icon
//      themselves so users can always discover how to turn each toggle back on.
const CwdTooltip = ({
    tooltip,
    alwaysVisible,
    children,
}: {
    tooltip: ReactNode;
    alwaysVisible?: boolean;
    children: ReactElement;
}) => {
    const cwdTooltipsDisabled = useValue(disableCwdTooltips$);
    if (cwdTooltipsDisabled && !alwaysVisible) {
        return <>{children}</>;
    }
    return <Tooltip {...{ cwdBypass: true }} tooltip={tooltip}>{children}</Tooltip>;
};

export const NotificationPanel = () => {
    const showPanel = useValue(controlPanelEnabled$);
    const isPhotoMode = useValue(game.activeGamePanel$)?.__Type == game.GamePanelType.PhotoMode;

    if (isPhotoMode || !showPanel) {
        return null;
    }

    return <NotificationPanelContent />;
};

const NotificationPanelContent = () => {
    const localization = useLocalization();
    const uiText = useText();
    const { translate } = localization;
    const [sortAscending, setSortAscending] = useState(true);
    const panelButtonsOnlyStart = useValue(panelButtonsOnlyStart$);
    const [panelCollapsed, setPanelCollapsed] = useState(() => panelButtonsOnlyStart);
    // disableAllTooltips$ — Info button: vanilla game hover tooltips.
    const allTooltipsDisabled = useValue(disableAllTooltips$);
    // disableCwdTooltips$ — controlled by clicking the CWD icon in the title bar.
    // Read here only to drive the title-bar icon's own state class + tooltip text; the actual
    // gating of panel tooltips lives inside CwdTooltip.
    const cwdTooltipsDisabled = useValue(disableCwdTooltips$);
    // hideRoadNames$ — Road-Name toggle (or \ hotkey): vanilla aggregate road name labels.
    const roadNamesHidden = useValue(hideRoadNames$);
    // hideDistrictNames$ — District toggle: vanilla district labels only.
    const districtNamesHidden = useValue(hideDistrictNames$);
    // showRoadArrows$ — Road-Arrow toggle: force vanilla 1-way arrows on while browsing.
    const roadArrowsShown = useValue(showRoadArrows$);
    const [expandedSections, setExpandedSections] = useState(createExpandedSections);
    const allValues = useAllNotificationValues();
    const notificationCounts = useValue(notificationCounts$);
    const miniHudFavorites = useValue(miniHudFavorites$);
    const favoriteIndexes = new Set(miniHudFavorites);
    const {
        panelOffset,
        panelDragging,
        panelElementRef,
        handlePanelDragStart,
    } = usePanelDrag();

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

        return uiText(localeId, fallback);
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

    const roadArrowTooltip = tooltipContent(
        "RoadArrowToggleOff",
        "Click to show/hide 1-way road arrows on every road.\nThis also hides road names as side effect.\nNormally only visible while a road tool is active.",
    );

    const districtNameTooltip = districtNamesHidden
        ? tooltipContent(
            "DistrictNameToggleOff",
            "Click to show district names.",
        )
        : tooltipContent(
            "DistrictNameToggleOn",
            "Click to hide district names.",
        );

    const orderedSections = [...sections].sort((a, b) => {
        const result = localize(a.localeId).localeCompare(localize(b.localeId));
        return sortAscending ? result : -result;
    });

    const onToggleAll = () => {
        setAllNotifications(!allSelected);
    };

    const onToggleAllSections = () => {
        if (panelCollapsed) {
            setPanelCollapsed(false);
            setExpandedSections(createExpandedSections(true));
            return;
        }

        setExpandedSections(createExpandedSections(!allSectionsExpanded));
    };

    const onSectionExpandedChange = (section: NotificationSection, expanded: boolean) => {
        setExpandedSections((current) => ({
            ...current,
            [section.localeId]: expanded,
        }));
    };

    return (
        <div
            ref={panelElementRef}
            className={styles.panelAnchor}
            style={{ transform: `translate(${panelOffset.x}px, ${panelOffset.y}px)` }}
        >
        <Panel
            className={styles.panel}
            header={
                <div className={styles.header}>
                    <div className={styles.headerTitleArea}>
                        {/* Title-bar CWD icon — clickable. Toggles panel tooltips. alwaysVisible so the
                            user can always discover how to turn panel tooltips back on. */}
                        <CwdTooltip tooltip={titleBarTooltip} alwaysVisible>
                            <div
                                className={`${styles.headerModIconButton} ${cwdTooltipsDisabled ? styles.headerModIconOff : ""}`}
                                role="button"
                                aria-pressed={cwdTooltipsDisabled}
                                onClick={() => { OnDisableCwdTooltipsToggle(!cwdTooltipsDisabled); }}
                            >
                                <img src={modIconSrc} className={styles.headerModIcon} />
                            </div>
                        </CwdTooltip>
                        <div
                            className={`${styles.headerModName} ${panelDragging ? styles.headerModNameDragging : ""}`}
                            onMouseDown={handlePanelDragStart}
                        >
                            CITY WATCHDOG
                        </div>
                    </div>
                    <Button
                        className={roundButtonHighlightStyle.button + " " + styles.headerCollapseButton}
                        variant="icon"
                        onClick={() => { setPanelCollapsed(!panelCollapsed); }}
                        focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                    >
                        <img
                            src={panelCollapsed ? "Media/Glyphs/ThickStrokeArrowRight.svg" : "Media/Glyphs/ThickStrokeArrowDown.svg"}
                            className={styles.headerCollapseIcon}
                        />
                    </Button>
                    <Button
                        className={roundButtonHighlightStyle.button + " " + styles.headerCloseButton}
                        variant="icon"
                        onClick={() => { OnControlPanelBindingToggle(false); }}
                        focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                    >
                        <img src="Media/Glyphs/Close.svg" className={styles.headerCloseIcon} />
                    </Button>
                </div>
            }
        >
            {/* Left side: Info + Road Name + Road Arrows + District. Right side: sort + mass actions. */}
            <div className={styles.toolbar}>
                <div className={styles.toolbarLeft}>
                    {/* Info button: toggles vanilla game tooltips (cursor-follow + DescriptionTooltip popups).
                        When off, the button turns red — a clear reminder the player has globally muted hover tooltips.
                        alwaysVisible so the user can always discover how to turn vanilla tooltips back on. */}
                    <CwdTooltip tooltip={infoTooltip} alwaysVisible>
                        <div
                            className={`${styles.infoButton} ${allTooltipsDisabled ? styles.infoButtonAllOff : ""}`}
                            role="button"
                            aria-pressed={allTooltipsDisabled}
                            onClick={() => { OnDisableAllTooltipsToggle(!allTooltipsDisabled); }}
                        >
                            <img src={infoIconSrc} className={styles.infoIcon} />
                        </div>
                    </CwdTooltip>

                    {/* Road Name on/off toggle. Default state shows the "names on" icon; click flips it to "names off".
                        Backslash (\) hotkey is wired on the C# side. */}
                    <CwdTooltip tooltip={roadNameTooltip}>
                        <div
                            className={`${styles.infoButton} ${roadNamesHidden ? styles.infoButtonTipsOff : ""}`}
                            role="button"
                            aria-pressed={roadNamesHidden}
                            onClick={() => { OnHideRoadNamesToggle(!roadNamesHidden); }}
                        >
                            <img
                                src={roadNameOnSrc}
                                className={`${styles.infoIcon} ${styles.mapToggleIcon}`}
                            />
                        </div>
                    </CwdTooltip>

                    {/* Road Arrow toggle: forces vanilla 1-way arrows on while browsing.
                        Default OFF (vanilla behavior: arrows only visible with a road tool active). */}
                    <CwdTooltip tooltip={roadArrowTooltip}>
                        <div
                            className={`${styles.infoButton} ${roadArrowsShown ? styles.infoButtonTipsOff : ""}`}
                            role="button"
                            aria-pressed={roadArrowsShown}
                            onClick={() => { OnShowRoadArrowsToggle(!roadArrowsShown); }}
                        >
                            <img src={roadArrowIconSrc} className={`${styles.infoIcon} ${styles.mapToggleIcon}`} />
                        </div>
                    </CwdTooltip>

                    {/* District Name toggle: hides labels without affecting boundaries or area overlays. */}
                    <CwdTooltip tooltip={districtNameTooltip}>
                        <div
                            className={`${styles.infoButton} ${districtNamesHidden ? styles.infoButtonTipsOff : ""}`}
                            role="button"
                            aria-pressed={districtNamesHidden}
                            onClick={() => { OnHideDistrictNamesToggle(!districtNamesHidden); }}
                        >
                            <img src={districtIconSrc} className={`${styles.infoIcon} ${styles.mapToggleIcon}`} />
                        </div>
                    </CwdTooltip>
                </div>

                <div className={styles.toolbarButtons}>
                    <CwdTooltip tooltip={sortTooltip}>
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
                        </Button>
                    </CwdTooltip>

                    <CwdTooltip tooltip={allSectionsExpanded ? localize("CollapseAll", "Collapse All Rows") : localize("ExpandAll", "Expand All Rows")}>
                        <Button
                            className={`${styles.toolbarButton} ${styles.countButton} ${toggleAllStateClass}`}
                            onClick={onToggleAllSections}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <span className={styles.countButtonText}>
                                {selectedTotalCount}/{totalNotificationCount}
                            </span>
                        </Button>
                    </CwdTooltip>

                    <CwdTooltip tooltip={tooltipContent("ToggleAllTooltip", "Show/hide all icons.\nColor: green = all on; blue = mixed; red = all off.")}>
                        <Button
                            className={`${styles.toolbarButton} ${styles.toggleButton} ${toggleAllStateClass}`}
                            onClick={onToggleAll}
                            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
                        >
                            <span className={styles.toggleButtonText}>
                                {localize("ToggleAll", "Toggle All")}
                            </span>
                        </Button>
                    </CwdTooltip>

                </div>
            </div>

            <IconPreloader />

            {!panelCollapsed && orderedSections.map((section, index) => (
                    <NotificationSectionView
                        key={section.localeId}
                        section={section}
                        expanded={expandedSections[section.localeId] === true}
                        localize={localize}
                        notificationCounts={notificationCounts}
                        favoriteIndexes={favoriteIndexes}
                        showDivider={index > 0}
                        onExpandedChange={(expanded) => onSectionExpandedChange(section, expanded)}
                    />
                ))}
        </Panel>
        </div>
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
    notificationCounts,
    favoriteIndexes,
    showDivider,
    onExpandedChange,
}: {
    section: NotificationSection;
    expanded: boolean;
    localize: Localize;
    notificationCounts: number[];
    favoriteIndexes: Set<number>;
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
                renderChildren={() => section.items.map((item, itemIndex) => {
                    const countIndex = notificationCountIndexes.get(item.localeId) ?? -1;
                    return (
                        <NotificationRow
                            key={item.localeId}
                            item={item}
                            isChecked={values[itemIndex] ?? false}
                            count={notificationCounts[countIndex] ?? 0}
                            favorite={favoriteIndexes.has(countIndex)}
                            onFavoriteToggle={() => OnToggleMiniHudFavorite(countIndex)}
                            localize={localize}
                        />
                    );
                })}
            />
        </>
    );
};

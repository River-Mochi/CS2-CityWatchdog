// File: src/UI/src/components/panel/notification-panel/notificationPanel.tsx
// Purpose: In-city CWD notification icon panel and buttons.

import { useValue } from "cs2/api";
import { game } from "cs2/bindings";
import { useLocalization } from "cs2/l10n";
import { getModule } from "cs2/modding";
import { useText } from "../../shared/localization";
import { Button, Panel, Tooltip } from "cs2/ui";
import { useCallback, useEffect, useState, type ReactElement, type ReactNode } from "react";
import {
    controlPanelEnabled$,
    disableAllTooltips$,
    disableCwdTooltips$,
    hideDistrictNames$,
    hideRoadNames$,
    miniHudFavorites$,
    notificationCounts$,
    panelButtonsOnlyStart$,
    panelPositionX$,
    panelPositionY$,
    panelCollapsedSectionsMask$,
    panelSortMode$,
    showRoadArrows$,
    OnControlPanelBindingToggle,
    OnDisableAllTooltipsToggle,
    OnDisableCwdTooltipsToggle,
    OnHideDistrictNamesToggle,
    OnHideRoadNamesToggle,
    OnShowRoadArrowsToggle,
    OnToggleMiniHudFavorite,
    OnPanelCollapsedSectionsChanged,
    OnPanelSortModeChanged,
} from "../../../bindings/bindings";
import { Divider } from "../../divider/divider";
import { InfoPanel } from "../info-panel/infoPanel";
import { VanillaComponentResolver } from "../../../utils/vanilla";
import { NotificationRow } from "../notification-row/notificationRow";
import { PanelButton, PanelButtonText, type PanelButtonTone } from "./buttons/panelButton";
import styles from "./notificationPanel.module.scss";
import {
    allIconSources,
    allItems,
    createExpandedSections,
    expandedSectionsFromMask,
    collapsedSectionsMask,
    notificationCountIndexes,
    sections,
    setAllNotifications,
    type Localize,
    type NotificationSection,
} from "./notificationData";
import { useAllNotificationValues, useSectionValues } from "./notificationHooks";
import { usePanelDrag } from "./usePanelDrag";

// Title icon is a custom mod image emitted by webpack to coui://ui-mods/images/.
import TitleBarIconPath from "../../../../images/NotificationIcon_TitleBar.svg";

// Sort icons are custom mod images emitted by webpack to coui://ui-mods/images/.
import SortArrowUpPath from "../../../../images/sort-arrow-up.svg";
import SortArrowDownPath from "../../../../images/sort-arrow-down.svg";
import SortActivePath from "../../../../images/sort-active.svg";

// Road-name toggle icon. CSS handles the blue active state.
import RoadNameOnPath from "../../../../images/icon-RoadName-max.svg";

// District-name toggle icon tuned for small toolbar rendering.
import DistrictIconPath from "../../../../images/Districts-max.svg";

// Road-arrow toggle icon tuned for small toolbar rendering.
import RoadArrowIconPath from "../../../../images/icon-RoadArrows-max.svg";

const modIconSrc = TitleBarIconPath;
const sortArrowUpSrc = SortArrowUpPath;
const sortArrowDownSrc = SortArrowDownPath;
const sortActiveSrc = SortActivePath;
const roadNameOnSrc = RoadNameOnPath;
const districtIconSrc = DistrictIconPath;
const roadArrowIconSrc = RoadArrowIconPath;

// Info icon uses the built-in game media path.
const infoIconSrc = "Media/Game/Icons/AdvisorInfoViewWhite.svg";

const roundButtonHighlightStyle = getModule("game-ui/common/input/button/themes/round-highlight-button.module.scss", "classes");

// Sort button cycles through three modes. Kept at module scope so the chosen mode survives the
// panel closing and reopening within a game session (active-first order re-snapshots on open).
const SORT_ASCENDING = 0;
const SORT_DESCENDING = 1;
const SORT_ACTIVE = 2;
let sessionSortMode = SORT_ASCENDING;

// Panel-internal Tooltip wrapper. Two jobs:
//   1. Passes a `cwdBypass` flag the global TooltipGate extension reads, so panel tooltips stay
//      visible when the Info button mutes vanilla game tooltips (disableAllTooltips$).
//   2. Reads disableCwdTooltips$ itself — the CWD title-bar icon mutes panel tooltips by
//      returning just the children. `alwaysVisible` keeps recovery toggles discoverable.
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
    const [sortMode, setSortMode] = useState(sessionSortMode);
    const [activeSnapshot, setActiveSnapshot] = useState<number[] | null>(null);
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
    // showRoadArrows$ — Road-Arrow toggle: force vanilla 1-way arrows on when no road tool is active.
    const roadArrowsShown = useValue(showRoadArrows$);
    const [expandedSections, setExpandedSections] = useState(createExpandedSections);
    const allValues = useAllNotificationValues();
    const notificationCounts = useValue(notificationCounts$);
    const miniHudFavorites = useValue(miniHudFavorites$);
    const favoriteIndexes = new Set(miniHudFavorites);
    const savedPanelPositionX = useValue(panelPositionX$);
    const savedPanelPositionY = useValue(panelPositionY$);
    const savedCollapsedMask = useValue(panelCollapsedSectionsMask$);
    const savedSortMode = useValue(panelSortMode$);
    const {
        panelOffset,
        panelDragging,
        panelElementRef,
        handlePanelDragStart,
    } = usePanelDrag({ x: savedPanelPositionX, y: savedPanelPositionY });

    // Active-first sort snapshots the counts so rows don't reshuffle while you read. The snapshot is
    // taken on click (see cycleSortMode) and re-taken here on panel (re)open or if it wasn't ready yet.
    useEffect(() => {
        if (sortMode !== SORT_ACTIVE) {
            return;
        }
        if (activeSnapshot === null && notificationCounts.length > 0) {
            setActiveSnapshot(notificationCounts.slice());
        }
    }, [sortMode, activeSnapshot, notificationCounts]);

    // Restore the player's saved expand/collapse state once the setting binding resolves (and re-apply
    // harmlessly after our own saves round-trip). This does NOT save, so it can't clobber the setting.
    useEffect(() => {
        setExpandedSections(expandedSectionsFromMask(savedCollapsedMask));
    }, [savedCollapsedMask]);

    // Restore the saved sort mode once its binding resolves (A->Z, Z->A, or Active-first).
    useEffect(() => {
        setSortMode(savedSortMode);
        sessionSortMode = savedSortMode;
    }, [savedSortMode]);

    // Set the sort mode, snapshot the active list when needed, and persist the choice for next launch.
    const setAndSaveSortMode = (mode: number) => {
        setSortMode(mode);
        sessionSortMode = mode;
        OnPanelSortModeChanged(mode);
        setActiveSnapshot(mode === SORT_ACTIVE && notificationCounts.length > 0 ? notificationCounts.slice() : null);
    };

    const cycleSortMode = () => setAndSaveSortMode((sortMode + 1) % 3);

    // In Active view the count/expand button has no sections to act on, so it becomes a "back to the
    // grouped list" control (returns to A→Z), which is what players reach for to leave Active view.
    const exitToGroupedView = () => setAndSaveSortMode(SORT_ASCENDING);

    // Active-first is a flat list: every count > 0 row (by the frozen snapshot), sorted by count desc.
    // arrayIndex is this item's position in `allItems` (for allValues, which is self-built from that
    // same array and order). item.countIndex is the STABLE index into the C#-side counts/favorites/
    // jump-to-alert — the two can differ (e.g. Leveling Building lives in a different section from
    // its countIndex position), so both must be tracked and used for the right lookup below.
    // Dedupe by miniHudIdentity so a shared alert — e.g. "Facility full", which Garbage and Healthcare
    // display from one game prefab/count — appears only once here (same approach as the Mini HUD).
    const seenActiveIdentities = new Set<string>();
    const activeRows = sortMode === SORT_ACTIVE
        ? allItems
            .map((item, arrayIndex) => ({ item, arrayIndex, count: activeSnapshot?.[item.countIndex] ?? 0 }))
            .filter((entry) => entry.count > 0)
            .sort((a, b) => b.count - a.count || a.item.countIndex - b.item.countIndex)
            .filter((entry) => {
                const identity = entry.item.miniHudIdentity ?? entry.item.localeId;
                if (seenActiveIdentities.has(identity)) {
                    return false;
                }
                seenActiveIdentities.add(identity);
                return true;
            })
        : [];

    // Toggle All's tone/count reflect only the bulk-toggleable rows — excludeFromToggleAll rows
    // (currently just Leveling Building) are opt-in extras that bulk actions deliberately skip, so
    // they're left out here too. Otherwise the button could never show "all on" without also
    // requiring that optional row, and its on/off direction would misread which way to toggle.
    // allValues is self-built from `allItems` in this same array order, so plain array position
    // (not countIndex) is the correct lookup here.
    const toggleAllValues = allItems
        .map((item, arrayIndex) => ({ item, value: allValues[arrayIndex] ?? false }))
        .filter((entry) => !entry.item.excludeFromToggleAll)
        .map((entry) => entry.value);
    const allSelected = toggleAllValues.every(Boolean);
    const anySelected = toggleAllValues.some(Boolean);
    const selectedTotalCount = toggleAllValues.filter(Boolean).length;
    const totalNotificationCount = toggleAllValues.length;
    const toggleAllTone: PanelButtonTone = allSelected
        ? "on"
        : anySelected
            ? "partial"
            : "off";

    const allSectionsExpanded = sections.every((section) => expandedSections[section.localeId] === true);

    // The icon reflects the CURRENT sort mode: up = A→Z, down = Z→A, bars = active-first.
    const sortIconSrc =
        sortMode === SORT_ASCENDING ? sortArrowUpSrc
            : sortMode === SORT_DESCENDING ? sortArrowDownSrc
                : sortActiveSrc;

    const localize: Localize = useCallback((localeId, fallback, raw = false) => {
        if (raw) {
            return translate(localeId) ?? fallback ?? localeId;
        }

        return uiText(localeId, fallback);
    }, [translate, uiText]);

    const sortTooltip =
        sortMode === SORT_ASCENDING ? localize("SortModeAscending", "Sorting: A → Z · click to cycle")
            : sortMode === SORT_DESCENDING ? localize("SortModeDescending", "Sorting: Z → A · click to cycle")
                : localize("SortModeActiveFirst", "Sorting: active alerts first · click to cycle");

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
    const panelCollapseTooltip = localize("PanelCollapseToggle", "Expand/collapse whole panel.");
    const dragTitleTooltip = localize("DragTitleBar", "Drag title bar.");

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
        return sortMode === SORT_DESCENDING ? -result : result;
    });

    const onToggleAll = () => {
        setAllNotifications(!allSelected);
    };

    // Update the rows AND persist the resulting mask so the layout survives a game restart.
    const applyExpandedSections = (next: Record<string, boolean>) => {
        setExpandedSections(next);
        OnPanelCollapsedSectionsChanged(collapsedSectionsMask(next));
    };

    const onToggleAllSections = () => {
        if (panelCollapsed) {
            setPanelCollapsed(false);
            applyExpandedSections(createExpandedSections(true));
            return;
        }

        applyExpandedSections(createExpandedSections(!allSectionsExpanded));
    };

    const onSectionExpandedChange = (section: NotificationSection, expanded: boolean) => {
        applyExpandedSections({ ...expandedSections, [section.localeId]: expanded });
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
                            players knows how to turn panel tooltips back on and it's not also invisible. */}
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
                        <CwdTooltip tooltip={dragTitleTooltip}>
                            <div
                                className={`${styles.headerModName} ${panelDragging ? styles.headerModNameDragging : ""}`}
                                onMouseDown={handlePanelDragStart}
                            >
                                CITY WATCHDOG
                            </div>
                        </CwdTooltip>
                    </div>
                    <CwdTooltip tooltip={panelCollapseTooltip}>
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
                    </CwdTooltip>
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
                        When off, the button turns red — strong reminder the player has globally muted hover tooltips.
                        alwaysVisible keeps the vanilla-tooltip recovery control discoverable. */}
                    <CwdTooltip tooltip={infoTooltip} alwaysVisible>
                        <PanelButton
                            tone={allTooltipsDisabled ? "danger" : "default"}
                            ariaPressed={allTooltipsDisabled}
                            iconSrc={infoIconSrc}
                            onClick={() => { OnDisableAllTooltipsToggle(!allTooltipsDisabled); }}
                        />
                    </CwdTooltip>

                    {/* Road Name on/off toggle. Default state shows the "names on" icon; click flips it to "names off".
                        Backslash (\) hotkey is wired on the C# side. */}
                    <CwdTooltip tooltip={roadNameTooltip}>
                        <PanelButton
                            tone={roadNamesHidden ? "active" : "default"}
                            ariaPressed={roadNamesHidden}
                            iconSrc={roadNameOnSrc}
                            iconKind="map"
                            onClick={() => { OnHideRoadNamesToggle(!roadNamesHidden); }}
                        />
                    </CwdTooltip>

                    {/* Road Arrow toggle: forces vanilla 1-way arrows on when no road tool is active.
                        Default OFF (vanilla behavior: arrows only visible with a road tool active). */}
                    <CwdTooltip tooltip={roadArrowTooltip}>
                        <PanelButton
                            tone={roadArrowsShown ? "active" : "default"}
                            ariaPressed={roadArrowsShown}
                            iconSrc={roadArrowIconSrc}
                            iconKind="map"
                            onClick={() => { OnShowRoadArrowsToggle(!roadArrowsShown); }}
                        />
                    </CwdTooltip>

                    {/* District Name toggle: hides labels without affecting boundaries or area overlays. */}
                    <CwdTooltip tooltip={districtNameTooltip}>
                        <PanelButton
                            tone={districtNamesHidden ? "active" : "default"}
                            ariaPressed={districtNamesHidden}
                            iconSrc={districtIconSrc}
                            iconKind="map"
                            onClick={() => { OnHideDistrictNamesToggle(!districtNamesHidden); }}
                        />
                    </CwdTooltip>
                </div>

                <div className={styles.toolbarButtons}>
                    <CwdTooltip tooltip={sortTooltip}>
                        <PanelButton
                            kind="sort"
                            iconSrc={sortIconSrc}
                            iconKind="sort"
                            onClick={cycleSortMode}
                        />
                    </CwdTooltip>

                    <CwdTooltip tooltip={sortMode === SORT_ACTIVE
                        ? localize("BackToGrouped", "Back to grouped list")
                        : (allSectionsExpanded ? localize("CollapseAll", "Collapse All Rows") : localize("ExpandAll", "Expand All Rows"))}>
                        <PanelButton
                            kind="count"
                            tone={toggleAllTone}
                            onClick={sortMode === SORT_ACTIVE ? exitToGroupedView : onToggleAllSections}
                        >
                            <PanelButtonText kind="count">
                                {selectedTotalCount}/{totalNotificationCount}
                            </PanelButtonText>
                        </PanelButton>
                    </CwdTooltip>

                    <CwdTooltip tooltip={tooltipContent("ToggleAllTooltip", "Show/hide all icons.\nColor: green = all on; blue = mixed; red = all off.")}>
                        <PanelButton
                            kind="toggle"
                            tone={toggleAllTone}
                            onClick={onToggleAll}
                        >
                            <PanelButtonText kind="toggle">
                                {localize("ToggleAll", "Toggle All")}
                            </PanelButtonText>
                        </PanelButton>
                    </CwdTooltip>

                </div>
            </div>

            <IconPreloader />

            {/* Active-first: flat list of only the count > 0 rows (frozen snapshot), sorted by count. */}
            {!panelCollapsed && sortMode === SORT_ACTIVE && (
                activeRows.length === 0
                    ? (
                        <div style={{ paddingTop: "12rem", paddingBottom: "12rem", textAlign: "center", opacity: 0.6 }}>
                            {localize("NoActiveAlerts", "No active notifications.")}
                        </div>
                    )
                    : activeRows.map(({ item, arrayIndex }) => (
                        <NotificationRow
                            key={item.localeId}
                            item={item}
                            isChecked={allValues[arrayIndex] ?? false}
                            count={notificationCounts[item.countIndex] ?? 0}
                            favorite={favoriteIndexes.has(item.countIndex)}
                            onFavoriteToggle={() => OnToggleMiniHudFavorite(item.countIndex)}
                            localize={localize}
                        />
                    ))
            )}

            {!panelCollapsed && sortMode !== SORT_ACTIVE && orderedSections.map((section, index) => (
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

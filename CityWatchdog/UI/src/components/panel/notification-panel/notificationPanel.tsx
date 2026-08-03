// File: src/UI/src/components/panel/notification-panel/notificationPanel.tsx
// Purpose: In-city CWD notification icon panel and buttons.

import { useValue } from "cs2/api";
import { game } from "cs2/bindings";
import { useLocalization } from "cs2/l10n";
import { getModule } from "cs2/modding";
import { useText } from "../../shared/localization";
import { Button, FormattedParagraphs, Panel, Tooltip } from "cs2/ui";
import { memo, useCallback, useEffect, useMemo, useState, type ReactElement, type ReactNode } from "react";
import {
  controlPanelEnabled$,
  disableAllTooltips$,
  disableCwdTooltips$,
  hideDistrictNames$,
  hideRoadNames$,
  miniHudFavorites$,
  mainPanelOpacity$,
  notificationCounts$,
  panelButtonsOnlyStart$,
  panelPositionX$,
  panelPositionY$,
  panelCollapsedSectionsMask$,
  panelSortMode$,
  preset1Saved$,
  preset2Saved$,
  activePreset$,
  interfaceScaleEnabled$,
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
  OnLoadPreset,
  OnSavePreset,
  OnToggleInterfaceScale,
} from "../../../bindings/bindings";
import { Divider } from "../../divider/divider";
import { InfoPanel } from "../info-panel/infoPanel";
import { VanillaComponentResolver } from "../../../utils/vanilla";
import { playSelectSound } from "../../../utils/uiSound";
import { NotificationRow } from "../notification-row/notificationRow";
import { PanelButton, PanelButtonText, type PanelButtonTone } from "./buttons/panelButton";
import { PresetSlot } from "./buttons/presetButtons";
import presetStyles from "./buttons/presetButtons.module.scss";
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

// UI-scale (title-bar) button icon.
import ScalePanelsPath from "../../../../images/ScalePanels.svg";

const modIconSrc = TitleBarIconPath;
const scalePanelsSrc = ScalePanelsPath;
const sortArrowUpSrc = SortArrowUpPath;
const sortArrowDownSrc = SortArrowDownPath;
const sortActiveSrc = SortActivePath;
const preloadedIconSources = [
  ...allIconSources,
  sortArrowUpSrc,
  sortArrowDownSrc,
  sortActiveSrc,
];
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

const getMainPanelOpacityClass = (value: number) => {
  const normalized = Math.round(Math.min(100, Math.max(30, Number.isFinite(value) ? value : 80)) / 5) * 5;
  return styles[`opacity${normalized}`] ?? styles.opacity80;
};

// Coherent collapses "\n" inside one text node.
// FormattedParagraphs preserves tooltip line breaks with vanilla styling.
const renderTooltipLines = (tooltip: ReactNode): ReactNode =>
  typeof tooltip === "string" && tooltip.includes("\n")
    ? <FormattedParagraphs className={styles.tooltipParagraphs}>{tooltip}</FormattedParagraphs>
    : tooltip;

// Keeps CWD tooltips independent from the global game-tooltip toggle.
// alwaysVisible is used for controls that restore hidden CWD tooltips.
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
  return <Tooltip {...{ cwdBypass: true }} tooltip={renderTooltipLines(tooltip)}>{children}</Tooltip>;
};

// Keeps 60fps drag state outside the 63-row body.
// Stable children prevent the notification list from re-rendering while dragging.
const DraggablePanelFrame = ({
  savedOffset,
  cwdTooltipsDisabled,
  titleBarTooltip,
  dragTitleTooltip,
  panelCollapseTooltip,
  scaleEnabled,
  scaleTooltip,
  panelTitle,
  panelCollapsed,
  allSectionsExpanded,
  onPanelCollapsedToggle,
  onCloseClick,
  children,
}: {
  savedOffset: { x: number; y: number };
  cwdTooltipsDisabled: boolean;
  titleBarTooltip: ReactNode;
  dragTitleTooltip: ReactNode;
  panelCollapseTooltip: ReactNode;
  scaleEnabled: boolean;
  scaleTooltip: ReactNode;
  // Swaps to the Active-view title so the header says what the body is actually showing.
  panelTitle: string;
  panelCollapsed: boolean;
  // Only true when every section is showing its rows — the one state that gets the shorter
  // max-height. The "categories only" collapsed view and any partial-expand state are unaffected.
  allSectionsExpanded: boolean;
  onPanelCollapsedToggle: () => void;
  onCloseClick: () => void;
  children: ReactNode;
}) => {
  const mainPanelOpacity = useValue(mainPanelOpacity$);
  const mainPanelOpacityClass = getMainPanelOpacityClass(mainPanelOpacity);
  const {
    panelOffset,
    panelDragging,
    panelElementRef,
    handlePanelDragStart,
  } = usePanelDrag(savedOffset);

  return (
    <div
      ref={panelElementRef}
      className={styles.panelAnchor}
      style={{ transform: `translate(${panelOffset.x}px, ${panelOffset.y}px)` }}
    >
      <Panel
        className={`${styles.panel} ${mainPanelOpacityClass} ${allSectionsExpanded ? styles.panelAllExpanded : ""}`}
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
                  onClick={() => { playSelectSound(); OnDisableCwdTooltipsToggle(!cwdTooltipsDisabled); }}
                >
                  <img src={modIconSrc} className={styles.headerModIcon} />
                </div>
              </CwdTooltip>
              {/* UI-scale toggle — enables the vanilla (dev) interface scaling without the launch flag.
                  Placed at the far left next to the CWD paw icon, deliberately away from the expand
                  arrow so players don't flip their UI scale when reaching to expand/collapse. Highlights
                  when scaling is on. */}
              <CwdTooltip tooltip={scaleTooltip} alwaysVisible>
                <div
                  className={`${styles.headerScaleButton} ${scaleEnabled ? styles.headerScaleButtonActive : ""}`}
                  role="button"
                  aria-pressed={scaleEnabled}
                  onClick={() => { playSelectSound(); OnToggleInterfaceScale(!scaleEnabled); }}
                >
                  <img src={scalePanelsSrc} className={styles.headerScaleIcon} />
                </div>
              </CwdTooltip>
              {/* While actively dragging, skip the Tooltip wrapper entirely rather than just
                                hiding it — the title's DOM position lags one rAF tick behind the raw
                                mousemove during a fast drag, so a hover-tracking tooltip mounted here
                                would flicker on/off as the cursor drifts in and out of the stale hit-box. */}
              {panelDragging ? (
                <div
                  className={`${styles.headerModName} ${styles.headerModNameDragging}`}
                  onMouseDown={handlePanelDragStart}
                >
                  {panelTitle}
                </div>
              ) : (
                <CwdTooltip tooltip={dragTitleTooltip}>
                  <div
                    className={styles.headerModName}
                    onMouseDown={handlePanelDragStart}
                  >
                    {panelTitle}
                  </div>
                </CwdTooltip>
              )}
            </div>
            <CwdTooltip tooltip={panelCollapseTooltip}>
              <Button
                className={roundButtonHighlightStyle.button + " " + styles.headerCollapseButton}
                variant="icon"
                onSelect={onPanelCollapsedToggle}
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
              onSelect={onCloseClick}
              focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
            >
              <img src="Media/Glyphs/Close.svg" className={styles.headerCloseIcon} />
            </Button>
          </div>
        }
      >
        {children}
      </Panel>
    </div>
  );
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
  // preset1Saved$/preset2Saved$ — whether each "1 | 2" preset slot holds a saved checkbox layout.
  const preset1Saved = useValue(preset1Saved$);
  const preset2Saved = useValue(preset2Saved$);
  // activePreset$ — which slot (1/2) is currently applied; 0 = none. Drives the "selected" ring + dot.
  const activePreset = useValue(activePreset$);
  // interfaceScaleEnabled$ — vanilla UI scaling on/off (drives the title-bar scale button).
  const interfaceScaleEnabled = useValue(interfaceScaleEnabled$);
  const [expandedSections, setExpandedSections] = useState(createExpandedSections);
  const allValues = useAllNotificationValues();
  const notificationCounts = useValue(notificationCounts$);
  const miniHudFavorites = useValue(miniHudFavorites$);
  // Memoized: without this, a fresh Set was allocated every render (including the 60fps drag
  // re-renders this file used to get before DraggablePanelFrame isolated that), which also
  // defeated any future memo() on components that receive favoriteIndexes as a prop.
  const favoriteIndexes = useMemo(() => new Set(miniHudFavorites), [miniHudFavorites]);
  const savedPanelPositionX = useValue(panelPositionX$);
  const savedPanelPositionY = useValue(panelPositionY$);
  const savedCollapsedMask = useValue(panelCollapsedSectionsMask$);
  const savedSortMode = useValue(panelSortMode$);

  // Active-first sort snapshots the counts so rows don't reshuffle while player reads. The snapshot is
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
      // Optional rows (e.g. Leveling Building) never appear here — there's nothing to "fix" about
      // a positive-status extra, so it doesn't belong in a problems-triage list at any position.
      .filter((entry) => entry.count > 0 && !entry.item.optional)
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

  // SHOW ICONS's tone/count reflect only the bulk-toggleable rows — optional rows (currently just
  // Leveling Building) are opt-in extras that bulk actions deliberately skip, so they're left out
  // here too. Otherwise the button could never show "all on" without also requiring that optional
  // row, and its on/off direction would misread which way to toggle.
  // allValues is self-built from `allItems` in this same array order, so plain array position
  // (not countIndex) is the correct lookup here.
  const toggleAllValues = allItems
    .map((item, arrayIndex) => ({ item, value: allValues[arrayIndex] ?? false }))
    .filter((entry) => !entry.item.optional)
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

  // Title bar CWD icon is now BOTH a hover-help and a click toggle for panel tooltips.
  // Tooltip text switches based on the panel-tooltip state.
  const titleBarTooltip = cwdTooltipsDisabled
    ? localize(
      "TitleBarTooltipPanelOff",
      "Click to show City Watchdog panel tooltips.",
    )
    : localize(
      "TitleBarTooltipPanelOn",
      "Expand rows; [✓] check to show, uncheck to hide alerts.\nClick this icon to hide City Watchdog panel tooltips.",
    );
  // Keep the brand title for both grouped sort directions. Only the flat Active view changes the
  // title because it displays a fundamentally different list instead of the grouped sections.
  const panelTitle = sortMode === SORT_ACTIVE
    ? localize("PanelTitleActiveAlerts", "ACTIVE ALERTS")
    : "CITY WATCHDOG";
  const panelCollapseTooltip = localize("PanelCollapseToggle", "Expand/collapse whole panel.");
  const dragTitleTooltip = localize("DragTitleBar", "Drag title bar.");
  const scaleTooltip = interfaceScaleEnabled
    ? localize("InterfaceScaleOn", "Bigger UI is ON.\nClick to return the game interface to normal size.")
    : localize("InterfaceScaleOff", "Make the whole game interface bigger — panels and text.\nAffects the entire game and stays on until you turn it off.");

  // Same text regardless of toggle state — Info button is always discoverable.
  const infoTooltip = localize(
    "TooltipToggle",
    "Show/hide ALL game hover tooltips.\nCursor tooltips over buildings, cims, tools, and the small popups on game UI buttons.",
  );

  // Road-name toggle: state-aware text.
  const roadNameTooltip = roadNamesHidden
    ? localize(
      "RoadNameToggleOff",
      "Click to show road names.\nHotkey: \\",
    )
    : localize(
      "RoadNameToggleOn",
      "Click to hide road names.\nHotkey: \\",
    );

  const roadArrowTooltip = localize(
    "RoadArrowToggleOff",
    "Click to show/hide 1-way road arrows on every road.\nThis also hides road names as side effect.\nNormally only visible while a road tool is active.",
  );

  const districtNameTooltip = districtNamesHidden
    ? localize(
      "DistrictNameToggleOff",
      "Click to show district names.",
    )
    : localize(
      "DistrictNameToggleOn",
      "Click to hide district names.",
    );

  // Preset slots: tooltip depends on whether the slot already holds a saved layout.
  const savedPresetTooltip = localize(
    "PresetLoadHint",
    "Click to load this saved icon setup.\nHold 1 second to overwrite it with your current checkboxes.",
  );
  const emptyPresetTooltip = localize(
    "PresetSaveHint",
    "This preset is empty.\nHold 1 second to save your current checkboxes into it.",
  );
  const preset1Tooltip = preset1Saved ? savedPresetTooltip : emptyPresetTooltip;
  const preset2Tooltip = preset2Saved ? savedPresetTooltip : emptyPresetTooltip;

  // Memoized: this sort calls localize() twice per comparison plus localeCompare (both string-heavy),
  // and section titles only change when the sort mode or the game language does — NOT when a count
  // ticks or a checkbox toggles. Without this it re-ran on every panel render for identical output.
  const orderedSections = useMemo(
    () => [...sections].sort((a, b) => {
      const result = localize(a.localeId).localeCompare(localize(b.localeId));
      return sortMode === SORT_DESCENDING ? -result : result;
    }),
    [sortMode, localize],
  );

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

  // When the panel is collapsed to just the button row, Sort — like the count button — opens the
  // full panel instead of silently cycling the sort icon with nothing to show for it. It reveals the
  // CURRENT sort's view without advancing it, so what the player sees matches the icon they clicked:
  // grouped sorts open with all rows expanded; Active opens its flat list (re-snapshotted so it's
  // fresh). Once the panel is open, Sort cycles A→Z / Z→A / Active as before.
  const onSortButtonClick = () => {
    if (!panelCollapsed) {
      cycleSortMode();
      return;
    }
    setPanelCollapsed(false);
    if (sortMode === SORT_ACTIVE) {
      if (notificationCounts.length > 0) {
        setActiveSnapshot(notificationCounts.slice());
      }
    } else {
      applyExpandedSections(createExpandedSections(true));
    }
  };

  const onSectionExpandedChange = (section: NotificationSection, expanded: boolean) => {
    applyExpandedSections({ ...expandedSections, [section.localeId]: expanded });
  };

  return (
    <DraggablePanelFrame
      savedOffset={{ x: savedPanelPositionX, y: savedPanelPositionY }}
      cwdTooltipsDisabled={cwdTooltipsDisabled}
      titleBarTooltip={titleBarTooltip}
      dragTitleTooltip={dragTitleTooltip}
      panelCollapseTooltip={panelCollapseTooltip}
      scaleEnabled={interfaceScaleEnabled}
      scaleTooltip={scaleTooltip}
      panelTitle={panelTitle}
      panelCollapsed={panelCollapsed}
      allSectionsExpanded={allSectionsExpanded}
      onPanelCollapsedToggle={() => {
        const collapsing = !panelCollapsed;
        setPanelCollapsed(collapsing);
        // Re-expanding is the player asking to see the list again, so re-snapshot: the Active
        // view is deliberately frozen (see activeRows) and would otherwise still show whatever
        // was true when it was first opened. Costs nothing — notificationCounts is already live
        // in the binding, so this copies 63 ints and triggers no scan.
        if (!collapsing && sortMode === SORT_ACTIVE && notificationCounts.length > 0) {
          setActiveSnapshot(notificationCounts.slice());
        }
      }}
      onCloseClick={() => { OnControlPanelBindingToggle(false); }}
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
              onClick={onSortButtonClick}
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

          {/* Preset boxes "1" "2" sit next to Show Icons because all three control which map icons
              show. Click a box to load its saved checkbox layout, hold to save the current one in. */}
          <div className={presetStyles.presetGroup}>
            <CwdTooltip tooltip={preset1Tooltip}>
              <PresetSlot
                label="1"
                saved={preset1Saved}
                active={activePreset === 1}
                onLoad={() => { OnLoadPreset(1); }}
                onSave={() => { OnSavePreset(1); }}
              />
            </CwdTooltip>
            <CwdTooltip tooltip={preset2Tooltip}>
              <PresetSlot
                label="2"
                saved={preset2Saved}
                active={activePreset === 2}
                onLoad={() => { OnLoadPreset(2); }}
                onSave={() => { OnSavePreset(2); }}
              />
            </CwdTooltip>
          </div>

          <CwdTooltip tooltip={localize("ToggleAllTooltip", "Show or hide ALL map notification icons at once.\nColor: green = all shown; blue = mixed; red = all hidden.")}>
            <PanelButton
              kind="toggle"
              tone={toggleAllTone}
              onClick={onToggleAll}
            >
              <PanelButtonText kind="toggle">
                {allSelected
                  ? localize("HideIcons", "Hide Icons")
                  : localize("ShowIcons", "Show Icons")}
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
    </DraggablePanelFrame>
  );
};

const IconPreloader = () => {
  return (
    <div className={styles.iconPreloader} aria-hidden="true">
      {preloadedIconSources.map((source) => (
        <img key={source} src={source} alt="" />
      ))}
    </div>
  );
};

// Memoized so an action affecting ONE section (checkbox toggle, that section's own expand/collapse)
// doesn't force every OTHER section to re-run useSectionValues + rebuild its row list for nothing.
// notificationCounts only gets a new array reference when the counts ACTUALLY changed — the C# side
// diffs them (AreSameNotificationCounts in CityWatchdogUISystem) and skips the binding update when
// they match, so the poll tick alone does NOT churn this prop. onExpandedChange is intentionally
// excluded: it's recreated per section every render but always closes over the same section + calls
// the same handler, so a new reference never reflects an actual behavior change worth re-rendering
// for (same convention as NotificationRow's comparator).
const NotificationSectionView = memo(({
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

  // Rows inside a category always remain case-insensitive A→Z, even when the category list is
  // Z→A. Retain each original index so sorting cannot attach state to the wrong notification.
  const orderedItems = useMemo(
    () => section.items
      .map((item, itemIndex) => ({ item, itemIndex }))
      .sort((a, b) => {
        const firstLabel = localize(a.item.localeId).toLocaleLowerCase();
        const secondLabel = localize(b.item.localeId).toLocaleLowerCase();
        const result = firstLabel.localeCompare(secondLabel);
        return result || a.itemIndex - b.itemIndex;
      }),
    [section, localize],
  );

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
        renderChildren={() => orderedItems.map(({ item, itemIndex }) => {
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
}, (prev, next) =>
  prev.section === next.section &&
  prev.expanded === next.expanded &&
  prev.localize === next.localize &&
  prev.notificationCounts === next.notificationCounts &&
  prev.favoriteIndexes === next.favoriteIndexes &&
  prev.showDivider === next.showDivider);

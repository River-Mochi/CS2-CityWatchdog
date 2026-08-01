// File: src/UI/src/components/panel/notification-row/notificationRow.tsx
// Purpose: Renders one notification alert row with icon, label, count, favorite marker, and checkbox.

import { memo, type KeyboardEvent } from "react";
import { OnMiniHudNotificationClicked } from "../../../bindings/bindings";
import { Checkbox } from "../../checkbox/checkbox";
import { FavoriteButton } from "../../favorites/favoriteButton";
import { formatPanelNotificationCount } from "../../shared/formatNotificationCount";
import { gameTitleKeys, notificationCountIndexes, type Localize, type NotificationItem } from "../notification-panel/notificationData";
import styles from "./notificationRow.module.scss";

interface NotificationRowProps {
  item: NotificationItem;
  isChecked: boolean;
  count: number;
  favorite: boolean;
  onFavoriteToggle: () => void;
  localize: Localize;
}

export const NotificationRow = memo(({
  item,
  isChecked,
  count,
  favorite,
  onFavoriteToggle,
  localize,
}: NotificationRowProps) => {
  const gameTitleKey = item.gameTitleKey ?? gameTitleKeys[item.localeId];
  const gameLabel = gameTitleKey
    ? localize(gameTitleKey, undefined, true)
    : undefined;

  const baseLabel =
    gameLabel &&
      gameLabel !== gameTitleKey &&
      !gameLabel.includes("NOTIFICATIONS.TITLE") &&
      !gameLabel.includes("Notifications.TITLE")
      ? gameLabel
      : localize(item.localeId);

  // Optional rows (e.g. Leveling Building) get "(optional)" appended after whichever name showed —
  // vanilla's translated title or the CWD fallback — so the tag is always in the player's language.
  const label = item.optional
    ? `${baseLabel}${localize("OptionalTag", " (optional)")}`
    : baseLabel;

  const countIndex = notificationCountIndexes.get(item.localeId) ?? -1;
  const canJumpToAlert = countIndex >= 0 && count > 0;

  const rowClassName = isChecked
    ? styles.subPanel
    : `${styles.subPanel} ${styles.subPanelOff}`;

  const iconLabelClassName = isChecked
    ? styles.iconLabelSection
    : `${styles.iconLabelSection} ${styles.iconLabelSectionOff}`;

  const countClassName = canJumpToAlert
    ? `${styles.count} ${styles.countJump}`
    : `${styles.count} ${styles.countDisabled}`;

  // The jump target is the whole left-to-count strip (icon + label + count). The star and checkbox
  // sit OUTSIDE this element, so clicking either never triggers a jump — no stopPropagation needed.
  const jumpAreaClassName = canJumpToAlert
    ? `${styles.rowJumpArea} ${styles.rowJumpAreaClickable}`
    : styles.rowJumpArea;

  const onJumpClick = () => {
    if (canJumpToAlert) {
      OnMiniHudNotificationClicked(countIndex);
    }
  };

  const onJumpKeyDown = (event: KeyboardEvent<HTMLDivElement>) => {
    if (!canJumpToAlert) {
      return;
    }

    if (event.key === "Enter" || event.key === " ") {
      event.preventDefault();
      OnMiniHudNotificationClicked(countIndex);
    }
  };

  return (
    <div className={rowClassName}>
      {/* Jump area: icon + label + count. Clicking anywhere here jumps to the alert on the map. */}
      <div
        className={jumpAreaClassName}
        role={canJumpToAlert ? "button" : undefined}
        tabIndex={canJumpToAlert ? 0 : undefined}
        aria-disabled={canJumpToAlert ? undefined : true}
        onClick={canJumpToAlert ? onJumpClick : undefined}
        onKeyDown={canJumpToAlert ? onJumpKeyDown : undefined}
      >
        <div className={iconLabelClassName}>
          <img src={item.icon} className={styles.icon} alt="" />
          <span className={styles.label}>{label}</span>
        </div>
        {/* MAIN panel count badge. The Mini HUD has its own count in miniHud.tsx. */}
        <span className={countClassName}>
          {formatPanelNotificationCount(count)}
        </span>
      </div>

      {/* Controls: Mini HUD favorite marker + notification toggle checkbox. Never jump. */}
      <div className={styles.rowControls}>
        <FavoriteButton
          favorite={favorite}
          onToggle={onFavoriteToggle}
        />
        <Checkbox isChecked={isChecked} onValueToggle={item.onToggle} />
      </div>
    </div>
  );
}, (prev, next) =>
  prev.item === next.item &&
  prev.isChecked === next.isChecked &&
  prev.count === next.count &&
  prev.favorite === next.favorite &&
  prev.localize === next.localize);

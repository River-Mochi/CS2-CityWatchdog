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

  const onCountClick = () => {
    if (canJumpToAlert) {
      OnMiniHudNotificationClicked(countIndex);
    }
  };

  const onCountKeyDown = (event: KeyboardEvent<HTMLSpanElement>) => {
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
      {/* Left side: small notification icon plus vanilla/localized label. */}
      <div className={iconLabelClassName}>
        <img src={item.icon} className={styles.icon} alt="" />
        <span className={styles.label}>{label}</span>
      </div>

      {/* Right side: count jump target, Mini HUD favorite marker, and notification toggle checkbox. */}
      <div className={styles.labelCheckboxSection}>
        {/* MAIN panel count — click to jump. The Mini HUD has its own count in miniHud.tsx. */}
        <span
          className={countClassName}
          role={canJumpToAlert ? "button" : undefined}
          tabIndex={canJumpToAlert ? 0 : undefined}
          aria-disabled={canJumpToAlert ? undefined : true}
          onClick={canJumpToAlert ? onCountClick : undefined}
          onKeyDown={canJumpToAlert ? onCountKeyDown : undefined}
        >
          {formatPanelNotificationCount(count)}
        </span>
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

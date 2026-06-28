// File: src/UI/src/mods/NotificationPanel/NotificationRow.tsx
// Purpose: Renders one notification icon row and prefers vanilla game title text when available.

import { InfoCheckbox } from "../InfoCheckbox/InfoCheckbox";
import { gameTitleKeys, type Localize, type NotificationItem } from "./notificationData";
import { memo } from "react";

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

    const label =
        gameLabel &&
            gameLabel !== gameTitleKey &&
            !gameLabel.includes("NOTIFICATIONS.TITLE") &&
            !gameLabel.includes("Notifications.TITLE")
            ? gameLabel
            : localize(item.localeId);

    return (
        <InfoCheckbox
            image={item.icon}
            label={label}
            count={count}
            favorite={favorite}
            onFavoriteToggle={onFavoriteToggle}
            isChecked={isChecked}
            onToggle={item.onToggle}
            style={{ marginBottom: "5rem" }}
        ></InfoCheckbox>
    );
}, (prev, next) =>
    prev.item === next.item &&
    prev.isChecked === next.isChecked &&
    prev.count === next.count &&
    prev.favorite === next.favorite &&
    prev.localize === next.localize);

// File: src/UI/src/mods/InfoCheckbox/InfoCheckbox.tsx
// Purpose: Renders one notification row with a left icon, label text, count, favorite marker, and checkbox.

import type { CSSProperties } from "react";
import { Checkbox } from "../Checkbox/Checkbox";
import { FavoriteButton } from "../Favorites/FavoriteButton";
import { formatPanelNotificationCount } from "../shared/formatNotificationCount";
import styles from "./InfoCheckbox.module.scss";

interface InfoCheckboxProps {
    image: string;
    label: string | null;
    count?: number;
    favorite?: boolean;
    onFavoriteToggle?: () => void;
    isChecked: boolean;
    onToggle: (newVal: boolean) => void;
    className?: string;
    style?: CSSProperties;
}

export const InfoCheckbox = ({
    image,
    label,
    count,
    favorite,
    onFavoriteToggle,
    isChecked,
    onToggle,
    className,
    style,
}: InfoCheckboxProps) => {
    const rowClassName = `${styles.subPanel} ${className ?? ""}`;

    return (
        <div
            className={rowClassName}
            style={{ ...style, opacity: isChecked ? 1 : 0.5 }}
            onClick={() => onToggle(!isChecked)}
        >
            {/* Left side: small notification icon plus vanilla/localized label. */}
            <div className={styles.iconLabelSection}>
                <img src={image} className={styles.icon} alt="" />
                <span className={styles.label}>{label}</span>
            </div>

            {/* Right side: count, optional Mini HUD favorite marker, and visual checkbox. */}
            <div className={styles.labelCheckboxSection}>
                {count !== undefined && <span className={styles.count}>{formatPanelNotificationCount(count)}</span>}
                {onFavoriteToggle !== undefined && (
                    <FavoriteButton
                        favorite={favorite ?? false}
                        onToggle={onFavoriteToggle}
                    />
                )}
                <Checkbox isChecked={isChecked} onValueToggle={() => { }} />
            </div>
        </div>
    );
};

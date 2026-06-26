// File: src/UI/src/mods/InfoCheckbox/InfoCheckbox.tsx
// Purpose: Renders one notification row with a left icon, label text, and right checkbox.

import type { CSSProperties } from "react";
import { Checkbox } from "../Checkbox/Checkbox";
import { useText } from "../shared/localization";
import { VanillaComponentResolver } from "../../utils/vanilla";
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
    const text = useText();
    const favoriteTooltip = text("MiniHudFavoriteTooltip", "Select favorite for mini-HUD");
    const DescriptionTooltip = VanillaComponentResolver.instance.DescriptionTooltip;
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

            {/* Right side: visual checkbox. Row click handles the actual toggle. */}
            <div className={styles.labelCheckboxSection}>
                {count !== undefined && <span className={styles.count}>{formatPanelNotificationCount(count)}</span>}
                {onFavoriteToggle !== undefined && (
                    <DescriptionTooltip title={favoriteTooltip} description={null} direction="right">
                        <button
                            type="button"
                            className={`${styles.favoriteButton} ${favorite ? styles.favoriteButtonActive : ""}`}
                            aria-label={favoriteTooltip}
                            onMouseDown={(event) => event.stopPropagation()}
                            onClick={(event) => {
                                event.stopPropagation();
                                onFavoriteToggle();
                            }}
                        >
                            <span className={styles.favoriteIcon}>☆</span>
                        </button>
                    </DescriptionTooltip>
                )}
                <Checkbox isChecked={isChecked} onValueToggle={() => { }} />
            </div>
        </div>
    );
};

// File: src/UI/src/components/favorites/favoriteButton.tsx
// Purpose: Renders the Mini HUD favorite marker used by notification rows.

import { useText } from "../shared/localization";
import { VanillaComponentResolver } from "../../utils/vanilla";
import { FavoriteStarIcon } from "./favoriteStarIcon";
import styles from "./favoriteButton.module.scss";

interface FavoriteButtonProps {
    favorite: boolean;
    onToggle: () => void;
}

export const FavoriteButton = ({ favorite, onToggle }: FavoriteButtonProps) => {
    const text = useText();
    const favoriteTooltip = text("MiniHudFavoriteTooltip", "Blue Star = favorite saved for mini-HUD");
    const DescriptionTooltip = VanillaComponentResolver.instance.DescriptionTooltip;
    const stateClass = favorite ? styles.favoriteButtonActive : styles.favoriteButtonInactive;

    return (
        <DescriptionTooltip title={null} description={favoriteTooltip} direction="right">
            <button
                type="button"
                className={`${styles.favoriteButton} ${stateClass}`}
                aria-label={favoriteTooltip}
                aria-pressed={favorite}
                onMouseDown={(event) => event.stopPropagation()}
                onClick={(event) => {
                    event.stopPropagation();
                    onToggle();
                }}
            >
                <FavoriteStarIcon />
            </button>
        </DescriptionTooltip>
    );
};

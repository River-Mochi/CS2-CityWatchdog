// File: src/UI/src/mods/Favorites/FavoriteButton.tsx
// Purpose: Renders the Mini HUD favorite marker used by notification rows.

import { useText } from "../shared/localization";
import { VanillaComponentResolver } from "../../utils/vanilla";
import FavoriteStarOffPath from "../../../images/favorite-star-off.svg";
import FavoriteStarOnPath from "../../../images/favorite-star-on.svg";
import styles from "./FavoriteButton.module.scss";

interface FavoriteButtonProps {
    favorite: boolean;
    onToggle: () => void;
}

export const FavoriteButton = ({ favorite, onToggle }: FavoriteButtonProps) => {
    const text = useText();
    const favoriteTooltip = text("MiniHudFavoriteTooltip", "Blue Star = favorite saved for mini-HUD");
    const DescriptionTooltip = VanillaComponentResolver.instance.DescriptionTooltip;
    const starIcon = favorite ? FavoriteStarOnPath : FavoriteStarOffPath;

    return (
        <DescriptionTooltip title={null} description={favoriteTooltip} direction="right">
            <button
                type="button"
                className={`${styles.favoriteButton} ${favorite ? styles.favoriteButtonActive : ""}`}
                aria-label={favoriteTooltip}
                aria-pressed={favorite}
                onMouseDown={(event) => event.stopPropagation()}
                onClick={(event) => {
                    event.stopPropagation();
                    onToggle();
                }}
            >
                <img src={starIcon} className={styles.favoriteIcon} alt="" />
            </button>
        </DescriptionTooltip>
    );
};

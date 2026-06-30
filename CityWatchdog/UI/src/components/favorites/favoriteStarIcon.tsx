// File: src/UI/src/components/favorites/favoriteStarIcon.tsx
// Purpose: Star SVG used by the Mini HUD favorite marker button.

import styles from "./favoriteButton.module.scss";

export const FavoriteStarIcon = () => (
    <svg className={styles.favoriteIcon} viewBox="0 0 24 24" aria-hidden="true" focusable="false">
        <path
            className={styles.favoriteStarFill}
            d="M12 2.6l2.88 5.84 6.45.94-4.67 4.55 1.1 6.43L12 17.33l-5.76 3.03 1.1-6.43-4.67-4.55 6.45-.94L12 2.6z"
        />
        <path
            className={styles.favoriteStarOuter}
            d="M12 2.6l2.88 5.84 6.45.94-4.67 4.55 1.1 6.43L12 17.33l-5.76 3.03 1.1-6.43-4.67-4.55 6.45-.94L12 2.6z"
        />
        <g transform="translate(12 12) scale(0.9) translate(-12 -12)">
            <path
                className={styles.favoriteStarInner}
                d="M12 2.6l2.88 5.84 6.45.94-4.67 4.55 1.1 6.43L12 17.33l-5.76 3.03 1.1-6.43-4.67-4.55 6.45-.94L12 2.6z"
            />
        </g>
    </svg>
);

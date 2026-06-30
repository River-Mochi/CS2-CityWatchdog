// File: src/UI/src/components/checkbox/checkbox.tsx
// Purpose: Small checkbox control used by City Watchdog panel rows.

import { Icon } from "cs2/ui";
import styles from "./checkbox.module.scss";

interface CheckboxProps {
    isChecked: boolean;
    onValueToggle: (newVal: boolean) => void;
}

export const Checkbox = ({ isChecked, onValueToggle }: CheckboxProps) => {
    const checkmarkSrc = "Media/Glyphs/Checkmark.svg";

    return (
        <button
            type="button"
            className={styles.checkboxContainer}
            aria-pressed={isChecked}
            onClick={() => onValueToggle(!isChecked)}
        >
            {isChecked && <Icon
                src={checkmarkSrc}
                className={styles.checkmarkIcon}
                tinted={true} />
            }
        </button>
    );
};

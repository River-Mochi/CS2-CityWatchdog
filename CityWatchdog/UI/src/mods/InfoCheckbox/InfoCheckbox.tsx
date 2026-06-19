// File: src/UI/src/mods/InfoCheckbox/InfoCheckbox.tsx
// Purpose: Renders one notification row with a left icon, label text, and right checkbox.

import type { CSSProperties } from "react";
import { Checkbox } from "../Checkbox/Checkbox";
import styles from "./InfoCheckbox.module.scss";

interface InfoCheckboxProps {
    image: string;
    label: string | null;
    isChecked: boolean;
    onToggle: (newVal: boolean) => void;
    className?: string;
    style?: CSSProperties;
}

export const InfoCheckbox = ({
    image,
    label,
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

            {/* Right side: visual checkbox. Row click handles the actual toggle. */}
            <div className={styles.labelCheckboxSection}>
                <Checkbox isChecked={isChecked} onValueToggle={() => { }} />
            </div>
        </div>
    );
};

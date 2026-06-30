// File: src/UI/src/components/divider/divider.tsx
// Purpose: Lightweight divider component for City Watchdog panel layout.

import { CSSProperties } from "react";
import styles from "./divider.module.scss";

interface DividerProps {
    className?: string;
    style?: CSSProperties;
    text?: string;
}

export const Divider = ({ className, style, text }: DividerProps) => {
    return (
        <div className={`${styles.divider} ${className || ""}`} style={style}>
            {text && <span className={styles.dividerText}>{text}</span>}
        </div>
    );
};

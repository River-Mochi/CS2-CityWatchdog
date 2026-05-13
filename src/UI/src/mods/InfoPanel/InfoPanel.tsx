import { CSSProperties, ReactNode, useState } from "react";
import styles from "../InfoPanel/InfoPanel.module.scss";

export interface InfoPanelProps {
    className?: string;
    style?: CSSProperties;
    title?: string;
    children?: ReactNode;
    collapsible?: boolean;
    defaultExpanded?: boolean;
    summary?: string;
    renderChildren?: () => ReactNode;
}

export const InfoPanel = ({
    className = "",
    style = {},
    title,
    children,
    collapsible = false,
    defaultExpanded = true,
    summary,
    renderChildren,
}: InfoPanelProps) => {
    const [isExpanded, setIsExpanded] = useState(defaultExpanded);
    const showBody = !collapsible || isExpanded;

    return (
        <div className={`${styles.infoPanel} ${className}`} style={style}>
            {title && collapsible && (
                <button
                    className={styles.infoPanelHeader}
                    type="button"
                    onClick={() => setIsExpanded(!isExpanded)}
                >
                    <span className={styles.infoPanelTitle}>{title}</span>
                    <span className={styles.infoPanelSummary}>{summary}</span>
                    <span className={styles.infoPanelToggle}>{isExpanded ? "-" : "+"}</span>
                </button>
            )}
            {title && !collapsible && <div className={styles.infoPanelTitle}>{title}</div>}
            {showBody && (renderChildren ? renderChildren() : children)}
        </div>
    );
};

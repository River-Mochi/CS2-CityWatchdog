// File: src/UI/src/components/panel/notification-panel/buttons/panelButton.tsx
// Purpose: Notification-panel toolbar buttons with Cohtml-safe hover behavior.

import { Button } from "cs2/ui";
import type { ReactNode } from "react";
import { VanillaComponentResolver } from "../../../../utils/vanilla";
import styles from "./panelButton.module.scss";

export type PanelButtonKind = "icon" | "sort" | "count" | "toggle";
export type PanelButtonTone = "default" | "active" | "danger" | "on" | "partial" | "off";
export type PanelButtonIconKind = "default" | "map" | "sort";

interface PanelButtonProps {
    kind?: PanelButtonKind;
    tone?: PanelButtonTone;
    iconKind?: PanelButtonIconKind;
    iconSrc?: string;
    iconAlt?: string;
    ariaPressed?: boolean;
    onClick: () => void;
    children?: ReactNode;
}

interface PanelButtonTextProps {
    kind: "count" | "toggle";
    children: ReactNode;
}

const classNames = (...names: Array<string | false | undefined>) => names.filter(Boolean).join(" ");

const toneClass = (tone: PanelButtonTone) => {
    switch (tone) {
        case "active":
            return styles.iconButtonActive;
        case "danger":
            return styles.iconButtonDanger;
        case "on":
            return styles.toggleAllOn;
        case "partial":
            return styles.toggleAllPartial;
        case "off":
            return styles.toggleAllOff;
        default:
            return undefined;
    }
};

const toolbarKindClass = (kind: PanelButtonKind) => {
    switch (kind) {
        case "sort":
            return styles.sortButton;
        case "count":
            return styles.countButton;
        case "toggle":
            return styles.toggleButton;
        default:
            return undefined;
    }
};

const iconKindClass = (kind: PanelButtonIconKind) => {
    switch (kind) {
        case "map":
            return styles.mapIcon;
        case "sort":
            return styles.sortIcon;
        default:
            return undefined;
    }
};

export const PanelButton = ({
    kind = "icon",
    tone = "default",
    iconKind = "default",
    iconSrc,
    iconAlt = "",
    ariaPressed,
    onClick,
    children,
}: PanelButtonProps) => {
    // Coherent Gameface can leave a reused image node blank after its src changes. Keying by source
    // makes React mount a fresh node when a stateful button (currently Sort) switches icons.
    const icon = iconSrc !== undefined
        ? (
            <img
                key={iconSrc}
                src={iconSrc}
                className={classNames(styles.icon, iconKindClass(iconKind))}
                alt={iconAlt}
            />
        )
        : null;

    if (kind === "icon") {
        return (
            <Button
                className={classNames(styles.iconButton, toneClass(tone))}
                variant="icon"
                onClick={onClick}
                focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
            >
                {icon}
                {children}
            </Button>
        );
    }

    return (
        <Button
            className={classNames(styles.toolbarButton, toolbarKindClass(kind), toneClass(tone))}
            onClick={onClick}
            focusKey={VanillaComponentResolver.instance.FOCUS_DISABLED}
        >
            {icon}
            {children}
        </Button>
    );
};

export const PanelButtonText = ({ kind, children }: PanelButtonTextProps) => {
    return (
        <span className={kind === "count" ? styles.countButtonText : styles.toggleButtonText}>
            {children}
        </span>
    );
};

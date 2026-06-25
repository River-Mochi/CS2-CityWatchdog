// File: src/UI/src/mods/MiniHud/MiniHud.tsx
// Purpose: Compact configurable notification totals HUD.

import { useValue } from "cs2/api";
import { game } from "cs2/bindings";
import { useEffect, useRef, useState, type MouseEvent as ReactMouseEvent } from "react";
import {
    controlPanelEnabled$,
    miniHudEnabled$,
    miniHudFavorites$,
    miniHudHideZero$,
    miniHudItemCount$,
    miniHudMode$,
    miniHudOrientation$,
    miniHudPlacement$,
    notificationCounts$,
    OnControlPanelBindingToggle,
} from "../Bindings/Bindings";
import { allItems } from "../NotificationPanel/notificationData";
import { formatMiniNotificationCount } from "../shared/formatNotificationCount";
import styles from "./MiniHud.module.scss";
import EmptyIconPath from "../../../images/NotificationIcon_TitleBar.svg";

const MODE_FAVORITES = 1;
const ORIENTATION_VERTICAL = 1;
const PLACEMENT_TOP_CENTER = 0;
const PLACEMENT_TOP_RIGHT = 1;
const PLACEMENT_DRAGGABLE = 2;

type Position = {
    x: number;
    y: number;
};

type DragState = {
    pointerX: number;
    pointerY: number;
    originX: number;
    originY: number;
    originLeft: number;
    originTop: number;
    originWidth: number;
    originHeight: number;
};

let sessionPosition: Position = { x: 0, y: 0 };

export const MiniHud = () => {
    const enabled = useValue(miniHudEnabled$);
    const fullPanelVisible = useValue(controlPanelEnabled$);
    const counts = useValue(notificationCounts$);
    const favorites = useValue(miniHudFavorites$);
    const mode = useValue(miniHudMode$);
    const itemCount = useValue(miniHudItemCount$);
    const orientation = useValue(miniHudOrientation$);
    const placement = useValue(miniHudPlacement$);
    const hideZero = useValue(miniHudHideZero$);
    const activeGamePanel = useValue(game.activeGamePanel$);
    const isPhotoMode = activeGamePanel?.__Type == game.GamePanelType.PhotoMode;
    const [position, setPosition] = useState<Position>(sessionPosition);
    const [dragging, setDragging] = useState(false);
    const hudRef = useRef<HTMLDivElement | null>(null);
    const dragRef = useRef<DragState | null>(null);
    const pendingPositionRef = useRef(position);
    const animationFrameRef = useRef<number | null>(null);

    useEffect(() => {
        if (!dragging) {
            return;
        }

        const onMouseMove = (event: MouseEvent) => {
            const drag = dragRef.current;
            if (drag === null) {
                return;
            }

            const deltaX = event.clientX - drag.pointerX;
            const deltaY = event.clientY - drag.pointerY;
            let nextX = drag.originX + deltaX;
            let nextY = drag.originY + deltaY;
            const nextLeft = drag.originLeft + deltaX;
            const nextTop = drag.originTop + deltaY;
            const nextRight = nextLeft + drag.originWidth;
            const nextBottom = nextTop + drag.originHeight;

            if (nextLeft < 0) {
                nextX -= nextLeft;
            }
            if (nextTop < 0) {
                nextY -= nextTop;
            }
            if (nextRight > window.innerWidth) {
                nextX -= nextRight - window.innerWidth;
            }
            if (nextBottom > window.innerHeight) {
                nextY -= nextBottom - window.innerHeight;
            }

            pendingPositionRef.current = { x: nextX, y: nextY };
            if (animationFrameRef.current === null) {
                animationFrameRef.current = window.requestAnimationFrame(() => {
                    animationFrameRef.current = null;
                    sessionPosition = pendingPositionRef.current;
                    setPosition(pendingPositionRef.current);
                });
            }
        };

        const onMouseUp = () => {
            if (animationFrameRef.current !== null) {
                window.cancelAnimationFrame(animationFrameRef.current);
                animationFrameRef.current = null;
            }

            dragRef.current = null;
            setDragging(false);
            sessionPosition = pendingPositionRef.current;
            setPosition(pendingPositionRef.current);
        };

        window.addEventListener("mousemove", onMouseMove);
        window.addEventListener("mouseup", onMouseUp);
        return () => {
            window.removeEventListener("mousemove", onMouseMove);
            window.removeEventListener("mouseup", onMouseUp);
        };
    }, [dragging]);

    useEffect(() => () => {
        if (animationFrameRef.current !== null) {
            window.cancelAnimationFrame(animationFrameRef.current);
        }
    }, []);

    if (!enabled || fullPanelVisible || isPhotoMode) {
        return null;
    }

    const favoriteSet = new Set(favorites);
    const candidates = allItems
        .map((item, index) => ({
            item,
            index,
            count: counts[index] ?? 0,
        }))
        .filter((entry) => mode !== MODE_FAVORITES || favoriteSet.has(entry.index))
        .filter((entry) => !hideZero || entry.count > 0)
        .sort((a, b) => b.count - a.count || a.index - b.index)
        .slice(0, itemCount === 10 ? 10 : 5);

    const startDragging = (event: ReactMouseEvent<HTMLDivElement>) => {
        if (placement !== PLACEMENT_DRAGGABLE) {
            return;
        }

        event.preventDefault();
        event.stopPropagation();
        const rect = hudRef.current?.getBoundingClientRect();
        if (rect === undefined) {
            return;
        }

        pendingPositionRef.current = position;
        dragRef.current = {
            pointerX: event.clientX,
            pointerY: event.clientY,
            originX: position.x,
            originY: position.y,
            originLeft: rect.left,
            originTop: rect.top,
            originWidth: rect.width,
            originHeight: rect.height,
        };
        setDragging(true);
    };

    const placementClass =
        placement === PLACEMENT_TOP_CENTER
            ? styles.topCenter
            : placement === PLACEMENT_TOP_RIGHT
                ? styles.topRight
                : styles.draggable;
    const openPanel = (event: ReactMouseEvent<HTMLDivElement>) => {
        event.preventDefault();
        event.stopPropagation();
        OnControlPanelBindingToggle(true);
    };

    return (
        <div
            ref={hudRef}
            className={`${styles.hud} ${orientation === ORIENTATION_VERTICAL ? styles.vertical : styles.horizontal} ${placementClass}`}
            style={placement === PLACEMENT_DRAGGABLE
                ? { transform: `translate(${position.x}px, ${position.y}px)` }
                : undefined}
        >
            {placement === PLACEMENT_DRAGGABLE && (
                <div
                    className={`${styles.dragGrip} ${dragging ? styles.dragGripActive : ""}`}
                    onMouseDown={startDragging}
                >
                    •••
                </div>
            )}

            <div className={styles.items}>
                {candidates.length === 0 ? (
                    <div
                        className={styles.item}
                        role="button"
                        onMouseDown={openPanel}
                    >
                        <span className={styles.count}>0</span>
                        <img src={EmptyIconPath} className={styles.icon} alt="" />
                    </div>
                ) : candidates.map(({ item, index, count }) => (
                    <div
                        key={index}
                        className={styles.item}
                        role="button"
                        onMouseDown={openPanel}
                    >
                        <span className={styles.count}>{formatMiniNotificationCount(count)}</span>
                        <img src={item.icon} className={styles.icon} alt="" />
                    </div>
                ))}
            </div>
        </div>
    );
};

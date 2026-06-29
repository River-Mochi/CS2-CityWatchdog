// File: src/UI/src/mods/MiniHud/MiniHud.tsx
// Purpose: Compact configurable notification totals HUD.

import { useValue } from "cs2/api";
import { game } from "cs2/bindings";
import { Tooltip } from "cs2/ui";
import { useCallback, useEffect, useRef, useState, type MouseEvent as ReactMouseEvent } from "react";
import {
    disableCwdTooltips$,
    miniHudEnabled$,
    miniHudFavorites$,
    miniHudGlassStyle$,
    miniHudHideZero$,
    miniHudItemCount$,
    miniHudMode$,
    miniHudOrientation$,
    miniHudPlacement$,
    notificationCounts$,
    OnMiniHudNotificationClicked,
} from "../Bindings/Bindings";
import { allItems } from "../NotificationPanel/notificationData";
import { useText } from "../shared/localization";
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
    const text = useText();
    const enabled = useValue(miniHudEnabled$);
    const counts = useValue(notificationCounts$);
    const favorites = useValue(miniHudFavorites$);
    const mode = useValue(miniHudMode$);
    const itemCount = useValue(miniHudItemCount$);
    const orientation = useValue(miniHudOrientation$);
    const placement = useValue(miniHudPlacement$);
    const hideZero = useValue(miniHudHideZero$);
    const glassStyle = useValue(miniHudGlassStyle$);
    const cwdTooltipsDisabled = useValue(disableCwdTooltips$);
    const activeGamePanel = useValue(game.activeGamePanel$);
    const isPhotoMode = activeGamePanel?.__Type == game.GamePanelType.PhotoMode;
    const isDraggable = placement === PLACEMENT_DRAGGABLE;
    const [position, setPosition] = useState<Position>(sessionPosition);
    const [dragging, setDragging] = useState(false);
    const hudRef = useRef<HTMLDivElement | null>(null);
    const dragRef = useRef<DragState | null>(null);
    const pendingPositionRef = useRef(position);
    const animationFrameRef = useRef<number | null>(null);
    const resizeAnimationFrameRef = useRef<number | null>(null);

    const resetHudPosition = useCallback(() => {
        const next = { x: 0, y: 0 };
        sessionPosition = next;
        pendingPositionRef.current = next;
        setPosition(next);
    }, []);

    useEffect(() => {
        resetHudPosition();
    }, [orientation, placement, resetHudPosition]);

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

        document.addEventListener("mousemove", onMouseMove);
        document.addEventListener("mouseup", onMouseUp);
        return () => {
            document.removeEventListener("mousemove", onMouseMove);
            document.removeEventListener("mouseup", onMouseUp);
        };
    }, [dragging]);

    useEffect(() => {
        if (!enabled || !isDraggable) {
            return;
        }

        const onResize = () => {
            if (resizeAnimationFrameRef.current !== null) {
                return;
            }

            resizeAnimationFrameRef.current = window.requestAnimationFrame(() => {
                resizeAnimationFrameRef.current = null;
                resetHudPosition();
            });
        };

        window.addEventListener("resize", onResize);
        return () => {
            window.removeEventListener("resize", onResize);
            if (resizeAnimationFrameRef.current !== null) {
                window.cancelAnimationFrame(resizeAnimationFrameRef.current);
                resizeAnimationFrameRef.current = null;
            }
        };
    }, [enabled, isDraggable, resetHudPosition]);

    useEffect(() => () => {
        if (animationFrameRef.current !== null) {
            window.cancelAnimationFrame(animationFrameRef.current);
        }
        if (resizeAnimationFrameRef.current !== null) {
            window.cancelAnimationFrame(resizeAnimationFrameRef.current);
        }
    }, []);

    if (!enabled || isPhotoMode) {
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

    const onOpenHandleMouseDown = (event: ReactMouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
        event.stopPropagation();

        if (!isDraggable) {
            return;
        }

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

    const onOpenHandleClick = (event: ReactMouseEvent<HTMLButtonElement>) => {
        event.preventDefault();
        event.stopPropagation();
    };

    const onItemClick = (event: ReactMouseEvent<HTMLDivElement>, index: number) => {
        event.preventDefault();
        event.stopPropagation();
        OnMiniHudNotificationClicked(index);
    };

    const placementClass =
        placement === PLACEMENT_TOP_CENTER
            ? styles.topCenter
            : placement === PLACEMENT_TOP_RIGHT
                ? styles.topRight
                : orientation === ORIENTATION_VERTICAL
                    ? styles.draggableVertical
                    : styles.draggableHorizontal;
    const dragTransform = orientation === ORIENTATION_VERTICAL
        ? `translate(${position.x}px, ${position.y}px)`
        : `translate(-50%, 0) translate(${position.x}px, ${position.y}px)`;
    const openHandleTooltip = text("MiniHudDragHandle", "Draggable dots.");
    const openHandleButton = (
        <button
            type="button"
            className={styles.openHandle}
            onMouseDown={onOpenHandleMouseDown}
            onClick={onOpenHandleClick}
            aria-label={openHandleTooltip}
        >
            <span className={styles.openHandleMark} aria-hidden="true">
                <span className={styles.openHandleDot}></span>
                <span className={styles.openHandleDot}></span>
                <span className={styles.openHandleDot}></span>
            </span>
        </button>
    );

    return (
        <div
            ref={hudRef}
            className={`${styles.hud} ${glassStyle ? styles.glass : styles.gray} ${orientation === ORIENTATION_VERTICAL ? styles.vertical : styles.horizontal} ${isDraggable ? styles.draggable : ""} ${placementClass}`}
            style={isDraggable
                ? { transform: dragTransform }
                : undefined}
        >
            <div className={styles.content}>
                <div className={styles.items}>
                    {candidates.length === 0 ? (
                        <div
                            className={styles.item}
                            role="button"
                        >
                            <span className={styles.count}>0</span>
                            <img src={EmptyIconPath} className={styles.icon} alt="" />
                        </div>
                    ) : candidates.map(({ item, index, count }) => (
                        <div
                            key={index}
                            className={styles.item}
                            role="button"
                            onClick={(event) => onItemClick(event, index)}
                        >
                            <span className={styles.count}>{formatMiniNotificationCount(count)}</span>
                            <img src={item.icon} className={styles.icon} alt="" />
                        </div>
                    ))}
                </div>
                {isDraggable && (
                    cwdTooltipsDisabled
                        ? openHandleButton
                        : <Tooltip {...{ cwdBypass: true }} tooltip={openHandleTooltip}>{openHandleButton}</Tooltip>
                )}
            </div>
        </div>
    );
};

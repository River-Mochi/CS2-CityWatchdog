// File: src/UI/src/mods/NotificationPanel/usePanelDrag.ts
// Purpose: Keeps the CWD panel draggable and clamped inside the game window.

import { useCallback, useEffect, useRef, useState, type MouseEvent as ReactMouseEvent } from "react";

type PanelOffset = {
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

let sessionPanelOffset: PanelOffset = { x: 0, y: 0 };

export const usePanelDrag = () => {
    const [panelOffset, setPanelOffset] = useState<PanelOffset>(sessionPanelOffset);
    const [panelDragging, setPanelDragging] = useState(false);
    const panelElementRef = useRef<HTMLDivElement | null>(null);
    const dragStateRef = useRef<DragState | null>(null);
    const pendingOffsetRef = useRef(panelOffset);
    const animationFrameRef = useRef<number | null>(null);

    useEffect(() => {
        if (!panelDragging) {
            return;
        }

        const onMouseMove = (event: MouseEvent) => {
            const dragState = dragStateRef.current;
            if (dragState === null) {
                return;
            }

            const deltaX = event.clientX - dragState.pointerX;
            const deltaY = event.clientY - dragState.pointerY;
            let nextX = dragState.originX + deltaX;
            let nextY = dragState.originY + deltaY;
            const nextLeft = dragState.originLeft + deltaX;
            const nextTop = dragState.originTop + deltaY;
            const nextRight = nextLeft + dragState.originWidth;
            const nextBottom = nextTop + dragState.originHeight;

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

            pendingOffsetRef.current = { x: nextX, y: nextY };
            if (animationFrameRef.current === null) {
                animationFrameRef.current = window.requestAnimationFrame(() => {
                    animationFrameRef.current = null;
                    sessionPanelOffset = pendingOffsetRef.current;
                    setPanelOffset(pendingOffsetRef.current);
                });
            }
        };

        const onMouseUp = () => {
            if (animationFrameRef.current !== null) {
                window.cancelAnimationFrame(animationFrameRef.current);
                animationFrameRef.current = null;
            }

            dragStateRef.current = null;
            setPanelDragging(false);
            sessionPanelOffset = pendingOffsetRef.current;
            setPanelOffset(pendingOffsetRef.current);
        };

        window.addEventListener("mousemove", onMouseMove);
        window.addEventListener("mouseup", onMouseUp);

        return () => {
            window.removeEventListener("mousemove", onMouseMove);
            window.removeEventListener("mouseup", onMouseUp);
        };
    }, [panelDragging]);

    useEffect(() => () => {
        if (animationFrameRef.current !== null) {
            window.cancelAnimationFrame(animationFrameRef.current);
        }
    }, []);

    const handlePanelDragStart = useCallback((event: ReactMouseEvent<HTMLDivElement>) => {
        event.preventDefault();
        event.stopPropagation();

        const rect = panelElementRef.current?.getBoundingClientRect();
        if (rect === undefined) {
            return;
        }

        pendingOffsetRef.current = panelOffset;
        dragStateRef.current = {
            pointerX: event.clientX,
            pointerY: event.clientY,
            originX: panelOffset.x,
            originY: panelOffset.y,
            originLeft: rect.left,
            originTop: rect.top,
            originWidth: rect.width,
            originHeight: rect.height,
        };
        setPanelDragging(true);
    }, [panelOffset]);

    return {
        panelOffset,
        panelDragging,
        panelElementRef,
        handlePanelDragStart,
    };
};

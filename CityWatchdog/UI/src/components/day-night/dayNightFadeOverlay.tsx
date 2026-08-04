// File: src/UI/src/components/day-night/dayNightFadeOverlay.tsx
// Purpose: Light screen dim that softens the Day/Night lighting cut. Opacity comes from C#.

import { useValue } from "cs2/api";
import { dayNightFade$ } from "../../bindings/bindings";
import styles from "./dayNightFadeOverlay.module.scss";

export const DayNightFadeOverlay = () => {
  const fade = useValue(dayNightFade$);

  // Nothing between transitions, so there is no cost while idle.
  if (fade <= 0.001) {
    return null;
  }

  return <div className={styles.overlay} style={{ opacity: fade }} />;
};

// File: src/UI/src/components/day-night/dayNightFadeOverlay.tsx
// Purpose: Full-screen dim that masks the HDR auto-exposure flash during a Day/Night switch. Opacity is
//          driven entirely by C# (DayNightControlSystem); this component only renders it. Registered in
//          both the "Game" and "Editor" module slots so it works in a city and in the map editor.

import { useValue } from "cs2/api";
import { dayNightFade$ } from "../../bindings/bindings";
import styles from "./dayNightFadeOverlay.module.scss";

export const DayNightFadeOverlay = () => {
  const fade = useValue(dayNightFade$);

  // Nothing to draw between transitions — keep the DOM empty so there is zero cost while idle.
  if (fade <= 0.001) {
    return null;
  }

  // opacity is the only dynamic bit; the rest lives in the SCSS class. pointer-events: none there
  // guarantees the overlay never intercepts clicks even at full dark.
  return <div className={styles.overlay} style={{ opacity: fade }} />;
};

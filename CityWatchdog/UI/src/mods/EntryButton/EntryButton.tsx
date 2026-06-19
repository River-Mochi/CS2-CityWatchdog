// File: src/UI/src/mods/EntryButton/EntryButton.tsx
// Purpose:
//   Floating GameTopLeft launcher button for the City Watchdog notification panel.
//   Clicking toggles the in-game City Watchdog SIP panel.
// Notes:
//   - Uses the CS2 "floating" button variant so it matches GameTopLeft buttons.
//   - Uses the Button `src` prop for the SVG, matching the EasyZoning GTL button pattern.
//   - Avoids Icon tinted={true}, so the SVG can keep its own colors.
//   - Uses onSelect because that is the CS2 UI button handler.
//   - Uses vanilla DescriptionTooltip through VanillaComponentResolver for title + description tooltip styling.
//   - Tooltip text is localized through lang/en-US.json.

import { useValue } from "cs2/api";
import { Button } from "cs2/ui";
import { text } from "../shared/localization";
import {
    OnControlPanelBindingToggle,
    controlPanelEnabled$,
} from "../Bindings/Bindings";
import { VanillaComponentResolver } from "../../utils/vanilla";

// Icon emitted by webpack to coui://ui-mods/images/.
// Same SVG as the panel title-bar icon so the GTL launcher and the open panel match visually.
import ModIconPath from "../../../images/NotificationIcon_GTL.svg";

export const EntryButton = () => {
    const showPanel = useValue(controlPanelEnabled$);

    const title = text("EntryButtonTitle", "CITY WATCHDOG");
    const description = text("EntryButtonDescription", "Open the notification icon panel.");

    // Vanilla title + description tooltip, matching the style used by EasyZoning.
    const DescriptionTooltip = VanillaComponentResolver.instance.DescriptionTooltip;

    const handleSelect = () => {
        OnControlPanelBindingToggle(!showPanel);
    };

    // Color SVG path:
    //   Use Button src={ModIconPath}; this lets SVG keep its own colors for GTL button.
    //
    // For a white/tintable icons use Monochrome/tinted path:
    //   <Icon tinted={true} src={ModIconPath} /> inside the Button body,
    //   only do this where losing the SVG's own colors is intended.

    // Intentionally omit `selected={showPanel}` so the GTL button never shows the vanilla
    // white "selected" overlay — the icon stays identical whether the panel is open or not.
    // Same approach as CS2-RoadRailSpeeds RoadSpeedToolbarButton.
    return (
        <DescriptionTooltip title={title} description={description} direction="right">
            <Button
                variant="floating"
                src={ModIconPath}
                onSelect={handleSelect}
            />
        </DescriptionTooltip>
    );
};

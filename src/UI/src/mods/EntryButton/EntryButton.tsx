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
//   - Tooltip text is localized through CityWatchdog.UI[...] locale keys.

import { useValue } from "cs2/api";
import { useLocalization } from "cs2/l10n";
import { Button } from "cs2/ui";
import {
    OnControlPanelBindingToggle,
    controlPanelEnabled$,
} from "../Bindings/Bindings";
import { VanillaComponentResolver } from "../VanillaComponentResolver/VanillaComponentResolver";

// Icon emitted by webpack to coui://ui-mods/images/.
import ModIconPath from "../../../images/CWDNotificationIcon_white02.svg";

export const EntryButton = () => {
    const { translate } = useLocalization();
    const showPanel = useValue(controlPanelEnabled$);

    // Tooltip strings live in LocaleEN.cs. Fallbacks keep the button usable if locale loading fails.
    const title = translate("CityWatchdog.UI[EntryButtonTitle]", "CITY WATCHDOG");
    const description = translate(
        "CityWatchdog.UI[EntryButtonDescription]",
        "Open the notification icon control panel."
    );

    // Vanilla title + description tooltip, matching the style used by EasyZoning.
    const DescriptionTooltip = VanillaComponentResolver.instance.DescriptionTooltip;

    const handleSelect = () => {
        OnControlPanelBindingToggle(!showPanel);

        // Devtools trace only. This does not write to the game log.
        try {
            console.log("[CWD][UI] GameTopLeft button toggled notification panel");
        } catch {
        }
    };

    // Color SVG path:
    //   Use Button src={ModIconPath}; this lets SVG keep its own colors for GTL button.
    //
    // For a white/tintable icons use Monochrome/tinted path:
    //   <Icon tinted={true} src={ModIconPath} /> inside the Button body,
    //   only do this where losing the SVG's own colors is intended.

    return (
        <DescriptionTooltip title={title} description={description} direction="right">
            <Button
                variant="floating"
                src={ModIconPath}
                selected={showPanel}
                onSelect={handleSelect}
            />
        </DescriptionTooltip>
    );
};

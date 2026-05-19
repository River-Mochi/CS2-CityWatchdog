import { ModRegistrar, type ModuleRegistry, type ModuleRegistryExtend } from "cs2/modding";
import mod from "../mod.json";
import { NotificationPanel } from "./mods/NotificationPanel/NotificationPanel";
import { EntryButton } from "./mods/EntryButton/EntryButton";
import { DescriptionTooltipTrendTrackerExtension, StatFieldTrendTrackerExtension } from "./mods/ToolbarTrendTracker/ToolbarTrendTracker";
import { VanillaComponentResolver } from "./mods/VanillaComponentResolver/VanillaComponentResolver";
import "../images/NotificationIcon_TitleBar.svg";
import "../images/CWDNotificationIcon_white02.svg";

const STAT_FIELD_MODULE = "game-ui/game/components/toolbar/components/stat-field/stat-field.tsx";
const STAT_FIELD_TREND_EXPORT = "StatFieldTrend";
const DESCRIPTION_TOOLTIP_MODULE = "game-ui/common/tooltip/description-tooltip/description-tooltip.tsx";
const DESCRIPTION_TOOLTIP_EXPORT = "DescriptionTooltip";

const extendSafe = (
    registry: ModuleRegistry,
    modulePath: string,
    exportId: string,
    extension: ModuleRegistryExtend
) => {
    try {
        registry.extend(modulePath, exportId, extension);
    } catch (error) {
        console.error(`${mod.id} - UI extension failed for ${modulePath}#${exportId}`, error);
    }
};

const register: ModRegistrar = (moduleRegistry) => {
    VanillaComponentResolver.setRegistry(moduleRegistry);
    extendSafe(moduleRegistry, STAT_FIELD_MODULE, STAT_FIELD_TREND_EXPORT, StatFieldTrendTrackerExtension);
    extendSafe(moduleRegistry, DESCRIPTION_TOOLTIP_MODULE, DESCRIPTION_TOOLTIP_EXPORT, DescriptionTooltipTrendTrackerExtension);
    moduleRegistry.append("GameTopLeft", EntryButton);
    moduleRegistry.append("Game", NotificationPanel);
    console.log(`${mod.id} - UI registration completed`);
};

export default register;

//using ECommons;
//using ECommons.DalamudServices;
//using FFXIVClientStructs.FFXIV.Client.UI;
//using Landman.Contants;
//using Landman.Helpers;
//using Lumina.Excel.Sheets;

//namespace Landman.Services;

//public static unsafe class GatheringWindowService
//{
//    public static AddonGathering* GatheringWindow { get; set; }

//    public static uint CurrentIntegrity => GatheringWindow->AtkValues[110].UInt;
//    public static uint MaxIntegrity => GatheringWindow->AtkValues[111].UInt;

//    public static string LocationEffect => GatheringWindow->UldManager.NodeList[8]->GetAsAtkTextNode()->NodeText.GetText();
//    public static string LocationEffect2 => GatheringWindow->UldManager.NodeList[7]->GetAsAtkTextNode()->NodeText.GetText();

//    public static bool QuickGatherToggle => GatheringWindow->QuickGatheringComponentCheckBox->IsChecked;

//    public static bool TryGetAddOn()
//    {
//        GatheringWindow = (AddonGathering*)Svc.GameGui.GetAddonByName("Gathering", 1);

//        return GatheringWindow != null;
//    }

//    public static List<uint> GetAvailableItemIds()
//    {

//        var availableItemIds = new List<uint>();

//        for (var i = 7; i <= 11 * 8 + 7; i += 11)
//        {
//            availableItemIds.Add(GatheringWindow->AtkValues[i].UInt);
//        }

//        return availableItemIds;
//    }

//    private static bool NodeHasHiddenItems(List<uint> ids)
//    {
//        foreach (var id in ids.Where(x => x != 0))
//        {
//            if (Svc.Data.GetExcelSheet<GatheringItem>().FindFirst(x => x.Item.RowId == id, out var item) && item.IsHidden)
//                return false; // node is already exposed, don't need to expose it.
//            if (SpecialItems.Maps.Any(x => x.MapId == id))
//                return false;
//            if (SpecialItems.Items.Any(x => x.ItemId == id))
//                return false;

//        }
//        if (SpecialItems.Seeds.Any(x => ids.Any(y => x.ItemId == y)))
//            return true;

//        var targetNodeDataId = Svc.ClientState.LocalPlayer?.TargetObject?.DataId;
//        var gatheringPoint = Svc.Data.GetExcelSheet<GatheringPoint>().Where(x => x.RowId == targetNodeDataId).First().GatheringPointBase.Value;

//        if (SpecialItems.Items.Any(x => x.NodeId == gatheringPoint.RowId))
//            return true;
//        if (SpecialItems.Maps.Any(x => x.NodeIds.Any(y => y == gatheringPoint.RowId)))
//            return true;

//        return false;
//    }

//    public static string GetBoon(int id)
//    {
//        return GatheringWindow->AtkUnitBase.UldManager.NodeList[25 - id]
//            ->GetAsAtkComponentNode()->Component->UldManager.NodeList[21]
//            ->GetAsAtkTextNode()->NodeText.ToString();
//    }

//    public enum GatheringWindowItemPositions
//    {
//        First = 7,
//        Second = 18,
//        Third = 29,
//        Fourth = 40,
//        Fifth = 51,
//        Sixth = 62,
//        Seventh = 73,
//        Eighth = 84,
//        Ninth = 95
//    }
//}

using System.Collections.Generic;
using HarmonyLib;
using Vintagestory.GameContent;

namespace NoMoreFallingFuel
{
    [HarmonyPatch(typeof(BlockEntityCoalPile))]
    public static class CoalPilePatch
    {
        [HarmonyPatch("TryPartialCollapse")]
        [HarmonyPrefix]
        public static bool Prefix(BlockEntityCoalPile __instance, ref bool __result)
        {
            var itemCode = __instance.inventory[0]?.Itemstack?.Collectible?.Code?.Path;
            if (IsItemProtected(itemCode, NoMoreFallingFuelModSystem.ProtectedItemSet))
            {
                __result = false;
                return false;
            }
            return true;
        }

        internal static bool IsItemProtected(string itemCode, HashSet<string> protectedItems)
        {
            return itemCode != null && protectedItems.Contains(itemCode);
        }
    }
}

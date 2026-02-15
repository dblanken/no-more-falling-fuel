using System.Collections.Generic;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace NoMoreFallingFuel
{
    [HarmonyPatch(typeof(BlockBehaviorUnstableFalling))]
    public static class CharcoalPilePatch
    {
        [HarmonyPatch("OnNeighbourBlockChange")]
        [HarmonyPrefix]
        public static bool OnNeighbourBlockChangePrefix(BlockBehaviorUnstableFalling __instance, IWorldAccessor world, BlockPos pos)
        {
            return !ShouldPreventFalling(__instance, world, pos);
        }

        [HarmonyPatch("OnBlockPlaced")]
        [HarmonyPrefix]
        public static bool OnBlockPlacedPrefix(BlockBehaviorUnstableFalling __instance, IWorldAccessor world, BlockPos blockPos)
        {
            return !ShouldPreventFalling(__instance, world, blockPos);
        }

        private static bool ShouldPreventFalling(BlockBehaviorUnstableFalling instance, IWorldAccessor world, BlockPos pos)
        {
            if (instance.block is BlockCharcoalPile)
            {
                return ShouldPreventCharcoalFalling(NoMoreFallingFuelModSystem.Config.PreventCharcoalPileFalling);
            }

            if (instance.block is BlockCoalPile)
            {
                var be = world.BlockAccessor.GetBlockEntity(pos) as BlockEntityCoalPile;
                var itemCode = be?.inventory[0]?.Itemstack?.Collectible?.Code?.Path;
                return ShouldPreventCoalFalling(itemCode, NoMoreFallingFuelModSystem.ProtectedItemSet);
            }

            return false;
        }

        internal static bool ShouldPreventCharcoalFalling(bool configValue)
        {
            return configValue;
        }

        internal static bool ShouldPreventCoalFalling(string itemCode, HashSet<string> protectedItems)
        {
            return itemCode != null && protectedItems.Contains(itemCode);
        }
    }
}

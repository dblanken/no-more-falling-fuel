using Vintagestory.API.Common;
using HarmonyLib;
using System;
using System.Collections.Generic;

namespace NoMoreFallingFuel
{
    public class NoMoreFallingFuelModSystem : ModSystem
    {
        public const string HarmonyId = "com.nomorefallingfuel.patch";

        private Harmony harmony;
        public static ModConfig Config { get; private set; }
        public static HashSet<string> ProtectedItemSet { get; private set; }

        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            Config = api.LoadModConfig<ModConfig>("nomorefallingfuel.json");
            if (Config == null)
            {
                Config = new ModConfig();
                api.StoreModConfig(Config, "nomorefallingfuel.json");
            }

            ProtectedItemSet = new HashSet<string>(Config.ProtectedItems);

            try
            {
                harmony = new Harmony(HarmonyId);
                harmony.PatchAll(typeof(NoMoreFallingFuelModSystem).Assembly);

                foreach (var method in harmony.GetPatchedMethods())
                {
                    api.Logger.Notification($"[NoMoreFallingFuel] Patched: {method.DeclaringType?.Name}.{method.Name}");
                }

                api.Logger.Notification("[NoMoreFallingFuel] Patches applied!");
            }
            catch (Exception ex)
            {
                api.Logger.Error($"[NoMoreFallingFuel] Failed: {ex.Message}");
                api.Logger.Error($"[NoMoreFallingFuel] {ex.StackTrace}");
            }
        }

        public override void Dispose()
        {
            harmony?.UnpatchAll(HarmonyId);
            base.Dispose();
        }
    }
}

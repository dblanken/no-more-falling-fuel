using System.Collections.Generic;

namespace NoMoreFallingFuel
{
    public class ModConfig
    {
        public List<string> ProtectedItems { get; set; } = new List<string>
        {
            "charcoal",
            "coal-anthracite",
            "coal-bituminous",
            "coal-lignite",
            "coal-brown",
            "coke"
        };

        public bool PreventCharcoalPileFalling { get; set; } = true;
    }
}

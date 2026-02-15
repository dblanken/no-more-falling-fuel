using Xunit;

namespace NoMoreFallingFuel.Tests
{
    public class ModConfigTests
    {
        [Fact]
        public void DefaultConfig_ContainsAllExpectedFuelTypes()
        {
            var config = new ModConfig();

            Assert.Contains("charcoal", config.ProtectedItems);
            Assert.Contains("coal-anthracite", config.ProtectedItems);
            Assert.Contains("coal-bituminous", config.ProtectedItems);
            Assert.Contains("coal-lignite", config.ProtectedItems);
            Assert.Contains("coal-brown", config.ProtectedItems);
            Assert.Contains("coke", config.ProtectedItems);
            Assert.Equal(6, config.ProtectedItems.Count);
        }

        [Fact]
        public void DefaultConfig_PreventCharcoalPileFalling_IsTrue()
        {
            var config = new ModConfig();

            Assert.True(config.PreventCharcoalPileFalling);
        }

        [Fact]
        public void ProtectedItems_IsMutable()
        {
            var config = new ModConfig();

            config.ProtectedItems.Add("custom-fuel");
            Assert.Contains("custom-fuel", config.ProtectedItems);

            config.ProtectedItems.Remove("charcoal");
            Assert.DoesNotContain("charcoal", config.ProtectedItems);
        }
    }
}

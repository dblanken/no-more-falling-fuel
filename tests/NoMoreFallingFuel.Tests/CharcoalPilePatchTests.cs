using System.Collections.Generic;
using Xunit;

namespace NoMoreFallingFuel.Tests
{
    public class CharcoalPilePatchTests
    {
        [Fact]
        public void ShouldPreventCharcoalFalling_WhenEnabled_ReturnsTrue()
        {
            Assert.True(CharcoalPilePatch.ShouldPreventCharcoalFalling(true));
        }

        [Fact]
        public void ShouldPreventCharcoalFalling_WhenDisabled_ReturnsFalse()
        {
            Assert.False(CharcoalPilePatch.ShouldPreventCharcoalFalling(false));
        }

        [Fact]
        public void ShouldPreventCoalFalling_WithProtectedItem_ReturnsTrue()
        {
            var protectedItems = new HashSet<string> { "coal-anthracite", "coke" };

            Assert.True(CharcoalPilePatch.ShouldPreventCoalFalling("coal-anthracite", protectedItems));
        }

        [Fact]
        public void ShouldPreventCoalFalling_WithUnprotectedItem_ReturnsFalse()
        {
            var protectedItems = new HashSet<string> { "coal-anthracite", "coke" };

            Assert.False(CharcoalPilePatch.ShouldPreventCoalFalling("dirt", protectedItems));
        }

        [Fact]
        public void ShouldPreventCoalFalling_WithNullItemCode_ReturnsFalse()
        {
            var protectedItems = new HashSet<string> { "coal-anthracite", "coke" };

            Assert.False(CharcoalPilePatch.ShouldPreventCoalFalling(null, protectedItems));
        }
    }
}

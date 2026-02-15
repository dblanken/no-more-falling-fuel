using System.Collections.Generic;
using Xunit;

namespace NoMoreFallingFuel.Tests
{
    public class CoalPilePatchTests
    {
        [Fact]
        public void IsItemProtected_WithProtectedItem_ReturnsTrue()
        {
            var protectedItems = new HashSet<string> { "charcoal", "coke" };

            Assert.True(CoalPilePatch.IsItemProtected("charcoal", protectedItems));
        }

        [Fact]
        public void IsItemProtected_WithUnprotectedItem_ReturnsFalse()
        {
            var protectedItems = new HashSet<string> { "charcoal", "coke" };

            Assert.False(CoalPilePatch.IsItemProtected("dirt", protectedItems));
        }

        [Fact]
        public void IsItemProtected_WithNullItemCode_ReturnsFalse()
        {
            var protectedItems = new HashSet<string> { "charcoal", "coke" };

            Assert.False(CoalPilePatch.IsItemProtected(null, protectedItems));
        }

        [Fact]
        public void IsItemProtected_WithEmptyProtectedSet_ReturnsFalse()
        {
            var protectedItems = new HashSet<string>();

            Assert.False(CoalPilePatch.IsItemProtected("charcoal", protectedItems));
        }
    }
}

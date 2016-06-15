using System.ComponentModel.DataAnnotations;
using Suggestive.Web.Models.Requirements;
using Xunit;

namespace Suggestive.Web.Test
{
    public class EnumDisplayNameExtensionTests
    {
        [Fact]
        public void GetDisplayName_EnumWithDisplayAttribute_ExpectDisplayAttributeValue()
        {
            var expectedDisplayName = "This Enum Value Has a Display Name";
            var result = GetDisplayNameTestEnum.EnumValueWithDisplayName.GetDisplayName();
            Assert.Equal(expectedDisplayName, result);
        }

        [Fact]
        public void GetDisplayName_EnumWithoutDisplayAttribute_ExpectEnumItemName()
        {
            var expectedDisplayName = "EnumValueWithoutDisplayName";
            var result = GetDisplayNameTestEnum.EnumValueWithoutDisplayName.GetDisplayName();
            Assert.Equal(expectedDisplayName, result);
        }
    }

    internal enum GetDisplayNameTestEnum
    {
        [Display(Name="This Enum Value Has a Display Name")]
        EnumValueWithDisplayName = 0,
        EnumValueWithoutDisplayName = 1
    }
}

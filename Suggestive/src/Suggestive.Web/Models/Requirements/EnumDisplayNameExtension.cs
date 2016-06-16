using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Suggestive.Web.Models.Requirements
{
    public static class EnumDisplayNameExtension
    {
        public static string GetDisplayName<T>(this T value) where T : struct, IConvertible
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var displayAttributes = fieldInfo.GetCustomAttributes<DisplayAttribute>();

            return displayAttributes.Any() ? displayAttributes.First().Name : value.ToString();
        }
    }
}

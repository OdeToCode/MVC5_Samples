using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace ModelBinding.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this Type enumType, int? selectedValue)
        {
            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>();

            var items = names.Zip(values, (name, value) => new SelectListItem
            {
                Text = GetName(enumType, name),
                Value = value.ToString(CultureInfo.InvariantCulture),
                Selected = value == selectedValue
            });
            return items;
        }

        public static string GetName(Type enumType, string name)
        {
            var result = name;


            var display = enumType
                .GetField(name)
                .GetCustomAttributes(inherit: false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            if (display != null)
            {
                result = display.GetName();
            }

            return result;
        }
    }
}
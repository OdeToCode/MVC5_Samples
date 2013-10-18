using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Web.Helpers
{
    public static class EnumHelpers
    {
        public static IEnumerable<SelectListItem> EnumToItems(this Type enumType, object selected)
        {
            if (!typeof(Enum).IsAssignableFrom(enumType))
            {
                throw new ArgumentException("Type must be an enum");
            }

            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<object>();

            var items =  names.Zip(values, (name, value) =>
                new SelectListItem
                {
                    Text = GetName(enumType, name),
                    Value = value.ToString(),
                    Selected = value == selected
                }
            );

            return items;
        }

        static string GetName(Type enumType, string name)
        {
            var result = name;

            var attribute = enumType.GetField(name)
                                .GetCustomAttributes(inherit: false)
                                .OfType<DisplayAttribute>()
                                .FirstOrDefault();
            if (attribute != null && !String.IsNullOrEmpty(attribute.Name))
            {
                result = attribute.Name;
            }

            return result;
        }
    }
}
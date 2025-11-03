using System.ComponentModel;
using System.Reflection;

namespace Crosscutting.Util.Extension
{
    public static class CustomEnumExtensions
    {

        public static string convertToString(this Enum value)
        {
            return Enum.GetName(value.GetType(), value);
        }

        public static int ToInt(this Enum value)
        {
            return (int)(object)value;
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        /// <summary>
        /// Will get the string value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        public static T GetFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }

        public static T GetFromStringValue<T>(string stringValue) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(StringValueAttribute)) is StringValueAttribute attribute)
                {
                    if (attribute.StringValue.ToUpper() == stringValue.ToUpper())
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name.ToUpper() == stringValue.ToUpper())
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(stringValue));
            // Or return default(T);
        }

        public static IEnumerable<SelectListItemDto> ToSelectListItemDtoList(this Enum enumObj)
        {
            return from Enum e in Enum.GetValues(enumObj.GetType())
                   select new SelectListItemDto
                   {
                       Selected = e.Equals(enumObj),
                       Text = e.GetEnumDescription(),
                       Value = e.ToInt()
                   };
        }
    }

}

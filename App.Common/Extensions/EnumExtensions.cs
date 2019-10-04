using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace App00.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Description)
        {
            if (Assert.NotNull<Enum>(value))
            {
               // object attribute = value.GetType().GetField(value.ToString()).GetCustomAttributes(false).FirstOrDefault();
                CustomAttributeData customAttributeData = value.GetType().GetField(value.ToString()).CustomAttributes.FirstOrDefault(c => c.AttributeType == typeof(DisplayAttribute));
                if (Assert.NotNull<object>(customAttributeData))
                {
                    //object propVal = attribute.GetType().GetProperty(property.ToString()).GetValue(attribute);
                    return customAttributeData.NamedArguments.FirstOrDefault(a => a.MemberName == property.ToString()).TypedValue.Value.ToString();
                   // return propVal.ToString();
                }
            }
            return value.ToString();
        }
    }

    public enum DisplayProperty
    {
        Description,
        GroupName,
        Name,
        Prompt,
        ShortName,
        Order
    }
}
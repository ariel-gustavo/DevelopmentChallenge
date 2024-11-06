using System;
using System.ComponentModel;
using System.Reflection;

namespace DevelopmentChallenge.Data.Classes
{
    public enum Lenguaje
    {
        [Description("es")]
        Castellano,
        [Description("en")]
        Ingles,
        [Description("it")]
        Italiano
    }

    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}

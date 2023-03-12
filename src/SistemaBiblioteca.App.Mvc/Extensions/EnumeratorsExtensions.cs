using System;
using System.ComponentModel;

namespace SistemaBiblioteca.App.Mvc.Extensions
{
    public static class EnumeratorsExtensions
    {
        public static string GetDescription(this Enum value)
        {
            //Recuperando o tipo do enum
            var enumType = value.GetType();

            //Recuperando o nome do item do enum
            var field = enumType.GetField(value.ToString());

            //Recuperando o texto do enum
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            //Senão tiver declarado o atributo Description é retornado o nome do item do enum
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
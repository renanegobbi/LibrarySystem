using System;

namespace SistemaBiblioteca.Business.Core.Utils.ExtensionMethods
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Remove de uma string alguns caracteres desejados.
        /// </summary>
        /// <param name="input">String de onde os caracteres serão removidos.</param>
        /// <param name="caracteres"></param>
        public static string RemoverCaracter(this string input, params string[] caracteres)
        {
            if (string.IsNullOrEmpty(input)) return input;

            if (caracteres == null || caracteres.Length == 0) return input;

            foreach (string caracter in caracteres)
            {
                input = input.Replace(caracter, string.Empty);
            }

            return input;
        }


        /// <summary>
        /// Remove os caracteres de formatação ".", ",", "-", "/", "(", ")" e " " de uma string.
        /// </summary>
        public static string RemoverFormatacao(this string input) => string.IsNullOrEmpty(input)
                ? input
                : input.RemoverCaracter(".", ",", "-", "/", "(", ")", " ").Trim();


        /// <summary>
        /// Formata uma string representada por CPF.
        /// </summary>
        public static string FormatarCpf(this string cpf) => Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");


        /// <summary>
        /// Susbitui por "..." os caracteres que excederem o limite fornecido.
        /// </summary>
        public static string LimitarCaracteresSeMaiorQue(this string input, int maxCaracter)
        {
            if (string.IsNullOrEmpty(input)) return input;

            if (input == null || input.Length == 0) return input;

            return input.Length > maxCaracter
                    ? input.Substring(0, maxCaracter) + "..."
                    : input;
        }
    }
}
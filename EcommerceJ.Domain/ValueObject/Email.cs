using EcommerceJ.Helpers;
using System.Text.RegularExpressions;

namespace EcommerceJ.Domain.ValueObject
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public string Endereco { get; private set; }

        protected Email()
        {

        }

        public Email(string endereco)
        {
            Guard.ForNullOrEmptyDefaultMessage(endereco, "Email");
            Guard.StringLength("Email", endereco, EnderecoMaxLength);

            if (!IsValid(endereco))
                throw new System.Exception("Endereço de E-mail inválido.");

            Endereco = endereco;
        }

        public static bool IsValid(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}

using EcommerceJ.Helpers;
using System;
using TutorialEcommerce.Helpers;

namespace EcommerceJ.Domain.ValueObject
{
    public class Cep
    {
        public const int CepMaxLength = 8;
        public Int64? CepCod { get; private set; }

        protected Cep()
        {

        }

        public Cep(string cep)
        {
            Guard.ForNullOrEmptyDefaultMessage("CEP", cep);
            cep = TextoHelper.GetNumeros(cep);
            Guard.StringLength("CEP", CepMaxLength, cep);
            try
            {
                CepCod = Convert.ToInt64(cep);
            }
            catch (Exception)
            {
                throw new Exception("CEP inválido: " + cep);
            }
        }

        public bool Vazio()
        {
            return !CepCod.HasValue;
        }

        public string GetCepFormatado()
        {
            if (CepCod.Equals(null))
                return string.Empty;

            var cep = CepCod.ToString();

            while (cep.Length < 8)
                cep = "0" + cep;

            return cep.Substring(0, 5) + "-" + cep.Substring(5);
        }

    }
}

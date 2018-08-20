using EcommerceJ.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceJ.Domain.ValueObject
{
    public class Telefone
    {
        protected Telefone()
        {

        }

        public Telefone(string ddd, string numero)
        {
            SetDDD(ddd);
            SetTelefone(numero);
        }

        public const int NumeroMaxLength = 20;
        public string Numero { get; private set; }

        public const int DDDMaxLength = 3;
        public string DDD { get; private set; }

        private void SetTelefone(string numero)
        {
            if (string.IsNullOrEmpty(numero))
                numero = string.Empty;
            Numero = numero;
        }

        private void SetDDD(string ddd)
        {
            if (string.IsNullOrEmpty(ddd))
                ddd = string.Empty;
            DDD = ddd;
        }

        public string GetTelefoneCompleto()
        {
            return DDD + Numero;
        }
    }
}

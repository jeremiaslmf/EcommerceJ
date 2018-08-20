using EcommerceJ.Helpers;
using System;
using TutorialEcommerce.Domain.Enuns;

namespace EcommerceJ.Domain.ValueObject
{
    public class Endereco
    {
        protected Endereco()
        {

        }

        public Endereco(string logradouro, string complemento, string numero, string bairro, 
            string cidade, Uf? uf, Cep cep)
        {
            SetCep(cep);
            SetLogradouro(logradouro);
            SetComplemento(complemento);
            SetNumero(numero);
            SetBairro(bairro);
            SetCidade(cidade);
            SetUf(uf);
        }

        public const int LogradouroMaxLength = 150;
        public virtual string Logradouro { get; private set; }

        public const int ComplementoMaxLength = 150;
        public virtual string Complemento { get; private set; }

        public const int NumeroMaxLength = 50;
        public virtual string Numero { get; private set; }

        public const int CidadeMaxLength = 150;
        public virtual string Cidade { get; set; }

        public const int BairroMaxLength = 150;
        public virtual string Bairro { get; private set; }

        public virtual Uf? Uf { get; set; }

        public virtual Cep Cep { get; set; }

        private void SetUf(Uf? uf)
        {
            if (!uf.HasValue)
                throw new Exception("Estado é obrigatório.");
            Uf = uf;

        }

        private void SetCidade(string cidade)
        {
            Guard.ForNullOrEmptyDefaultMessage(cidade, "Cidade");
            Cidade = cidade;
        }

        private void SetBairro(string bairro)
        {
            Guard.ForNullOrEmptyDefaultMessage(bairro, "Bairro");
            Bairro = bairro;
        }

        private void SetNumero(string numero)
        {
            Guard.ForNullOrEmptyDefaultMessage(numero, "Número");
            Numero = numero;
        }

        private void SetComplemento(string complemento)
        {
            if (string.IsNullOrWhiteSpace(complemento))
                complemento = string.Empty;
            Complemento = complemento;
        }

        private void SetCep(Cep cep)
        {
            if (cep.Vazio())
                throw new Exception("Cep é obrigatório.");
            Cep = cep;
        }

        private void SetLogradouro(string logradouro)
        {
            Guard.ForNullOrEmptyDefaultMessage(logradouro, "Endereço");
            Logradouro = logradouro;
        }
    }
}

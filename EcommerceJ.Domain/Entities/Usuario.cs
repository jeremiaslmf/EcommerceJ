using EcommerceJ.Domain.ValueObject;
using System;

namespace EcommerceJ.Domain.Entities
{
    public class Usuario : EntityBase
    {

        //Construtor EntityFramework
        protected Usuario()
        {

        }

        public Usuario()
        {

        }

        public Cpf Cpf { get; protected set; }

        public Email Email { get; protected set; }

        public string Login { get; protected set; }

        public Endereco Endereco { get; protected set; }

        public byte[] Senha { get; protected set; }

        public Guid TokenAlteracaoDeSenha { get; protected set; }

    }
}

using EcommerceJ.Domain.ValueObject;
using EcommerceJ.Helpers;
using System;

namespace EcommerceJ.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario(string login, Cpf cpf, Email email, string senha, string senhaConfirmacao)
        {
            SetLogin(login);
            SetCpf(cpf);
            SetEmail(email);
            SetSenha(senha, senhaConfirmacao);
        }

        private void SetSenha(string senha, string senhaConfirmacao)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage(senhaConfirmacao, "Confirmação de Senha");
            Guard.StringLength("Senha", senha, SenhaMinValue, SenhaMaxValue);
            Guard.AreEqual(senha, senhaConfirmacao, "Senhas não conferem!");

            Senha = CriptografiaHelper.CriptografarSenha(senha);
        }

        private void SetEmail(Email email)
        {
            throw new NotImplementedException();
        }

        private void SetCpf(Cpf cpf)
        {
            throw new NotImplementedException();
        }

        private void SetLogin(string login)
        {
            Guard.ForNullOrEmptyDefaultMessage(login, "Login");
            Guard.StringLength("Login", login, LoginMinValue, LoginMaxValue);
            Login = login;
        }

        //Construtor EntityFramework
        protected Usuario()
        {

        }

        public Cpf Cpf { get; protected set; }

        public Email Email { get; protected set; }


        public const int LoginMinValue = 6;
        public const int LoginMaxValue = 30;
        public string Login { get; protected set; }


        public Endereco Endereco { get; protected set; }


        public const int SenhaMinValue = 6;
        public const int SenhaMaxValue = 30;
        public byte[] Senha { get; protected set; }

        public Guid TokenAlteracaoDeSenha { get; protected set; }

    }
}

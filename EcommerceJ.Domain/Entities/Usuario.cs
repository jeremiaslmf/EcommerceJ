using EcommerceJ.Domain.ValueObject;
using EcommerceJ.Helpers;
using System;
using System.Linq;

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

        private void SetSenha(string senha, string senhaConfirmacao)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            Guard.ForNullOrEmptyDefaultMessage(senhaConfirmacao, "Confirmação de Senha");
            Guard.StringLength("Senha", senha, SenhaMinValue, SenhaMaxValue);
            Guard.AreEqual(senha, senhaConfirmacao, "Senhas não conferem!");

            Senha = CriptografiaHelper.CriptografarSenha(senha);
        }

        public void SetEmail(Email email)
        {
            Email = email ?? throw new Exception("E-mail é obrigatório!");
        }

        public void SetCpf(Cpf cpf)
        {
            Cpf = cpf ?? throw new Exception("CPF é obrigatório.");
        }

        public void SetLogin(string login)
        {
            Guard.ForNullOrEmptyDefaultMessage(login, "Login");
            Guard.StringLength("Login", login, LoginMinValue, LoginMaxValue);
            Login = login;
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmacaoSenha)
        {
            ValidarSenha(senhaAtual);
            SetSenha(novaSenha, confirmacaoSenha);
        }

        private void ValidarSenha(string senha)
        {
            Guard.ForNullOrEmptyDefaultMessage(senha, "Senha");
            var senhaCriptografada = CriptografiaHelper.CriptografarSenha(senha);
            if (!Senha.SequenceEqual(senhaCriptografada))
                throw new Exception("Senha inválida!");
        }

        public Guid GerarNovoTokenAlterarSenha()
        {
            TokenAlteracaoDeSenha = Guid.NewGuid();
            return TokenAlteracaoDeSenha;
        }

        public void AlterarSenha(Guid token, string novaSenha, string confirmacaoSenha)
        {
            if (!TokenAlteracaoDeSenha.Equals(token))
                throw new Exception("Token para alteração de senha inválido.");
            SetSenha(novaSenha, confirmacaoSenha);
            GerarNovoTokenAlterarSenha();
        }
    }
}

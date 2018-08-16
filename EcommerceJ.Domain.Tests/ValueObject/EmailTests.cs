using EcommerceJ.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceJ.Domain.Tests.ValueObject
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Em_Branco()
        {
            var email = new Email("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Null()
        {
            var email = new Email("");
        }

        [TestMethod]
        public void Email_New_Email_Valido()
        {
            var endereco = "jeremiaslmf@gmail.com";
            var email = new Email(endereco);
            Assert.AreEqual(endereco, email.Endereco);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Invalido()
        {
            var email = new Email("asdasdasd65465");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Email_New_Email_Erro_MaxLength()
        {
            var endereco = "jeremiaslmf@gmail.com";
            while (endereco.Length < Email.EnderecoMaxLength)
            {
                endereco += endereco;
            }
            var email = new Email(endereco);
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EcommerceJ.Helpers.Tests
{
    [TestClass]
    public class GuardTests
    {
        [TestMethod]
        public void Guard_ForValidId_Ok()
        {
            Guard.ForValidId("Guid", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_Exception()
        {
            Guard.ForValidId(Guid.Empty, "Valor não pode ser vazio.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_Propriedade_Invalido()
        {
            Guard.ForValidId("Guid", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForValidId_Menor_Que_Zero()
        {
            Guard.ForValidId(-5, "Valor deve ser maior que zero.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNegative_True()
        {
            Guard.ForNegative(-1, "Número");
        }

        [TestMethod]
        public void Guard_ForNegative_False()
        {
            Assert.AreEqual(Guard.ForNegative(1), false);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Erro_Quando_Em_Branco()
        {
            Guard.ForNullOrEmpty("", "Valor não pode ser vazio.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_null()
        {
            Guard.ForNullOrEmpty(null, "Valor não pode ser vazio.");
        }

        
    }
}

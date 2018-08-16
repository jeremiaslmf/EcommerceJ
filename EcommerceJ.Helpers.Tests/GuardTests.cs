using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EcommerceJ.Helpers.Tests
{
    [TestClass]
    public class GuardTests
    {
        [TestMethod]
        public void Guard_ForValidId_Valid()
        {
            Guard.ForValidId()
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

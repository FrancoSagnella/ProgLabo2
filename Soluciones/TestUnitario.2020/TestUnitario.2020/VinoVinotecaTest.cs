using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario._2020
{
    [TestClass]
    public class VinoVinotecaTest
    {
        [TestMethod]
        public void VerificarIgualdadVinos_Ok()
        {
            //Arrange
            Vino v1 = new Vino(ETipoVino.Merlot, EBodega.Zuccardi);
            Vino v2 = new Vino(ETipoVino.Merlot, EBodega.Zuccardi);

            //Act
            bool rta = v1 == v2;

            //Assert
            Assert.IsTrue(rta);
        }

        [TestMethod]
        public void VerificarIgualdadVinos_Falla()
        {
            //Arrange
            Vino v1 = new Vino(ETipoVino.Merlot, EBodega.Zuccardi);
            Vino v2 = new Vino(ETipoVino.Merlot, EBodega.Rippon);

            //Act
            bool rta = v1 == v2;

            //Assert
            Assert.IsFalse(rta);
        }

        [TestMethod]
        public void VerificarIgualdadVinosNulos()
        {
            //Arrange
            Vino v1 = null;
            Vino v2 = null;

            //Act
            bool rta = v1 == v2;

            //Assert
            Assert.IsTrue(rta);
        }

        [TestMethod]
        public void Vinoteca()
        {
            //Arrange
            Vinoteca v = new Vinoteca(5);

            //Act
            Vino[] vinos = v.Vinos;

            //Assert
            Assert.IsNotNull(vinos);
        }

        [TestMethod]
        public void VinotecaDefault()
        {
            //Arrange
            Vinoteca v = new Vinoteca();

            //Act
            Vino[] vinos = v.Vinos;

            //Assert
            Assert.IsNotNull(vinos);
        }

        [TestMethod]
        public void AgregarVinos_Ok()
        {
            //Arrange
            Vinoteca v = new Vinoteca(3);
            Vino v1 = new Vino(ETipoVino.Merlot, EBodega.Zuccardi);
            Vino v2 = new Vino(ETipoVino.Merlot, EBodega.Rippon);
            int espacioLibreEsperado = 1;
            int espacioLibre = 0;

            //Act
            v += v1;
            v += v2;

            espacioLibre = v.EspacioLibre;

            //Assert
            Assert.AreEqual(espacioLibre, espacioLibreEsperado);
        }

        [TestMethod]
        public void AgregarVinos_Falla()
        {
            //Arrange
            Vinoteca v = new Vinoteca(1);
            Vino v1 = new Vino(ETipoVino.Merlot, EBodega.Zuccardi);
            Vino v2 = new Vino(ETipoVino.Merlot, EBodega.Rippon);

            //Act
            try
            {
                v += v1;
                v += v2;
            }
            catch (Exception e)
            {
            //Assert
                Assert.IsInstanceOfType(e, typeof(VinotecaLlenaException));
            }
           
        }

        [TestMethod]
        [ExpectedException(typeof(VinotecaLlenaException))]
        public void AgregarVinos_Exception()
        {
            //Arrange
            Vinoteca v = new Vinoteca(1);
            Vino v1 = new Vino(ETipoVino.Merlot, EBodega.Zuccardi);
            Vino v2 = new Vino(ETipoVino.Merlot, EBodega.Rippon);

            //Act
            v += v1;
            v += v2;
        }
    }
}

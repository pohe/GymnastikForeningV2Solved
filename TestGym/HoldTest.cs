using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymnastikForening;
using System;

namespace TestGym
{
    [TestClass]
    public class HoldTest
    {
        [TestMethod]
        public void BeregnTotalPris_3børn_1000kr()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            Deltager d1 = new Deltager("Magrethe Frederiksen", "Gade 123, 4000 Roskilde", 3);
            double forventetPris = 1000.0;

            //Act
            double aktuelPris = hold.BeregnTotalPris(d1.AntalBørn);

            

            //Assert
            Assert.AreEqual(forventetPris, aktuelPris, 0.01);

        }

        [TestMethod]
        public void BeregnTotalPris_1barn_500kr()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            Deltager d1 = new Deltager("Magrethe Frederiksen", "Gade 123, 4000 Roskilde", 1);
            double forventetPris = 500.0;
            //Act
            double aktuelPris = hold.BeregnTotalPris(d1.AntalBørn);

            //Assert
            Assert.AreEqual(forventetPris, aktuelPris, 0.01);

        }

        [TestMethod]
        public void BeregnTotalPris_0børn_0kr()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            int antalBørn = 0;
            double forventetPris = 0.0;
            //Act
            double aktuelPris = hold.BeregnTotalPris(antalBørn);

            //Assert
            Assert.AreEqual(forventetPris, aktuelPris, 0.01);
        }

        [TestMethod]
        public void BeregnTotalPris_Minus1børn_0kr()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            int antalBørn = -1;
            double forventetPris = 0.0;
            //Act
            double aktuelPris = hold.BeregnTotalPris(antalBørn);

            //Assert
            Assert.AreEqual(forventetPris, aktuelPris, 0.01);
        }

        [TestMethod]
        public void BeregnTotalPris_15børn_4000kr()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            int antalBørn = 15;
            double forventetPris = hold.PrisPrDeltager + (antalBørn-1)* hold.PrisPrDeltager * 50/100;
            //Act
            double aktuelPris = hold.BeregnTotalPris(antalBørn);

            //Assert
            Assert.AreEqual(forventetPris, aktuelPris, 0.01);
        }

        [TestMethod]
        public void TilmeldDeltager_2DeltagereIalt4Børn_4Børn()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            Deltager d1 = new Deltager("Magrethe Frederiksen", "Gade 123, 4000 Roskilde", 3);
            Deltager d2 = new Deltager("Peter Jensen", "vej 321, 4000 Roskilde", 1);
            int forventetAntaldeltagere = 4;
            //Act
            hold.TilmeldDeltager(d1);
            hold.TilmeldDeltager(d2);
            int antalDeltager = hold.AntalTilmeldte();

            //Assert
            Assert.AreEqual(forventetAntaldeltagere, antalDeltager);

        }

        [TestMethod]
        public void TilmeldDeltager_1DeltagereIalt0Børn_0Børn()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            Deltager d1 = new Deltager("Magrethe Frederiksen", "Gade 123, 4000 Roskilde", 0);
            int forventetAntaldeltagere = 0;
            //Act
            hold.TilmeldDeltager(d1);
            
            int antalDeltager = hold.AntalTilmeldte();

            //Assert
            Assert.AreEqual(forventetAntaldeltagere, antalDeltager);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TilmeldDeltager_1DeltagereIaltminusBørn_ArgumentException()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            Deltager d1 = new Deltager("Magrethe Frederiksen", "Gade 123, 4000 Roskilde", -1);
            
            //Act
            hold.TilmeldDeltager(d1);

            //Assert            

        }

        [TestMethod]
        public void TilmeldDeltager_1DeltagereIalt5Børn_5Børn()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            Deltager d1 = new Deltager("Magrethe Frederiksen", "Gade 123, 4000 Roskilde", 5);
            int forventetAntaldeltagere = 5;
            //Act
            hold.TilmeldDeltager(d1);
            int antalDeltager = hold.AntalTilmeldte();
            //Assert            
            Assert.AreEqual(forventetAntaldeltagere, antalDeltager);
        }

        [TestMethod]
        [ExpectedException(typeof(FuldtHoldException))]
        public void TilmeldDeltager_1DeltagereIalt6Børn_FuldtHoldException()
        {
            //Arrange
            Hold hold = new Hold("TumlingE22", 2022, "Musik for tumlinger", 500, 5);
            Deltager d1 = new Deltager("Magrethe Frederiksen", "Gade 123, 4000 Roskilde", 6);

            //Act
            hold.TilmeldDeltager(d1);

            //Assert            

        }
    }
}
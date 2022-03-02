using System;
using NUnit.Framework;
using ReversiRestApi.Models;
using ReversiRestApi.Interfaces;

namespace TestReversiRestApi
{
    [TestFixture]
    public class GameTest
    {
        // geen kleur = 0
        // Wit = 1
        // Zwart = 2

        [Test]
        public void ZetMogelijk__BuitenBord_Exception()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //                     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     1 <
            // Act
            Game.AandeBeurt = Kleur.Wit;
            //var actual = Game.ZetMogelijk(8, 8);
            Exception ex = Assert.Throws<Exception>(delegate { Game.ZetMogelijk(8, 8); });
            Assert.That(ex.Message, Is.EqualTo("Zet (8,8) ligt buiten het bord!"));

            // Assert
        }

        [Test]
        public void ZetMogelijk_StartSituatieZet23Zwart_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0  <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(2, 3);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_StartSituatieZet23Wit_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(2, 3);
            // Assert
            Assert.IsFalse(actual);
        }


        [Test]
        public void ZetMogelijk_ZetAanDeRandBoven_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(0, 3);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBoven_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 1 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(0, 3);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[5, 3] = Kleur.Wit;
            Game.Bord[6, 3] = Kleur.Wit;
            Game.Bord[7, 3] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 2 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(0, 3);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[5, 3] = Kleur.Wit;
            Game.Bord[6, 3] = Kleur.Wit;
            Game.Bord[7, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 1 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(0, 3);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechts_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 2 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(4, 7);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechts_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 1 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(4, 7);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[4, 0] = Kleur.Zwart;
            Game.Bord[4, 1] = Kleur.Wit;
            Game.Bord[4, 2] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Wit;
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0 
            // 4   2 1 1 1 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(4, 7);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[4, 0] = Kleur.Zwart;
            Game.Bord[4, 1] = Kleur.Wit;
            Game.Bord[4, 2] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Wit;
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  

            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   2 1 1 1 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(4, 7);
            // Assert
            Assert.IsFalse(actual);
        }


        //     0 1 2 3 4 5 6 7
        //                     
        // 0   0 0 0 0 0 0 0 0  
        // 1   0 0 0 0 0 0 0 0
        // 2   0 0 0 0 0 0 0 0
        // 3   0 0 0 1 2 0 0 0
        // 4   0 0 0 2 1 0 0 0
        // 5   0 0 0 0 0 0 0 0
        // 6   0 0 0 0 0 0 0 0
        // 7   0 0 0 0 0 0 0 0



        [Test]
        public void ZetMogelijk_StartSituatieZet22Wit_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(2, 2);
            // Assert
            Assert.IsFalse(actual);
        }
        
        [Test]
        public void ZetMogelijk_StartSituatieZet22Zwart_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(2, 2);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsBoven_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 5] = Kleur.Zwart;
            Game.Bord[1, 6] = Kleur.Zwart;
            Game.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 1  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(0, 7);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsBoven_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 5] = Kleur.Zwart;
            Game.Bord[1, 6] = Kleur.Zwart;
            Game.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 2  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(0, 7);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsOnder_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 2] = Kleur.Zwart;
            Game.Bord[5, 5] = Kleur.Wit;
            Game.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 2 <
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(7, 7);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsOnder_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 2] = Kleur.Zwart;
            Game.Bord[5, 5] = Kleur.Wit;
            Game.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  <
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 1
            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(7, 7);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksBoven_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 1] = Kleur.Wit;
            Game.Bord[2, 2] = Kleur.Wit;
            Game.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   2 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0 
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(0, 0);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksBoven_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 1] = Kleur.Wit;
            Game.Bord[2, 2] = Kleur.Wit;
            Game.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0          
            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(0, 0);
            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksOnder_ReturnTrue()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 5] = Kleur.Wit;
            Game.Bord[5, 2] = Kleur.Zwart;
            Game.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   1 0 0 0 0 0 0 0 <
            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.ZetMogelijk(7, 0);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksOnder_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 5] = Kleur.Wit;
            Game.Bord[5, 2] = Kleur.Zwart;
            Game.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  <
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   2 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            var actual = Game.ZetMogelijk(7, 0);
            // Assert
            Assert.IsFalse(actual);
        }

        //---------------------------------------------------------------------------
        [Test]
        //[ExpectedException(typeof(Exception))]
        public void DoeZet_BuitenBord_Exception()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //                     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     1 <
            // Act
            Game.AandeBeurt = Kleur.Wit;
            // Game.DoeZet(8, 8);
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(8, 8); });
            Assert.That(ex.Message, Is.EqualTo("Zet (8,8) ligt buiten het bord!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, Game.AandeBeurt);
        }

        [Test]
        public void DoeZet_StartSituatieZet23Zwart_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0  <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Game.DoeZet(2, 3);
            // Assert
            Assert.AreEqual(Kleur.Zwart, Game.Bord[2, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, Game.AandeBeurt);
        }

        [Test]
        public void DoeZet_StartSituatieZet23Wit_Exception()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(2, 3); });
            Assert.That(ex.Message, Is.EqualTo("Zet (2,3) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[2, 3]);

            Assert.AreEqual(Kleur.Wit, Game.AandeBeurt);
        }


        [Test]
        public void DoeZet_ZetAanDeRandBoven_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Game.DoeZet(0, 3);
            // Assert
            Assert.AreEqual(Kleur.Zwart, Game.Bord[0, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[1, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[2, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, Game.AandeBeurt);
        }

        [Test]
        public void DoeZet_ZetAanDeRandBoven_Exception()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 1 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(0, 3); });
            Assert.That(ex.Message, Is.EqualTo("Zet (0,3) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, Game.Bord[1, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[2, 3]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[0, 3]);

        }

        [Test]
        public void DoeZet_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[5, 3] = Kleur.Wit;
            Game.Bord[6, 3] = Kleur.Wit;
            Game.Bord[7, 3] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 2 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Game.DoeZet(0, 3);
            // Assert
            Assert.AreEqual(Kleur.Zwart, Game.Bord[0, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[1, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[2, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[5, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[6, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[7, 3]);

        }

        [Test]
        public void DoeZet_ZetAanDeRandBovenEnTotBenedenReedsGevuld_Exception()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[5, 3] = Kleur.Wit;
            Game.Bord[6, 3] = Kleur.Wit;
            Game.Bord[7, 3] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //           v
            // 0   0 0 0 2 0 0 0 0  <
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 1 1 0 0 0
            // 5   0 0 0 1 0 0 0 0
            // 6   0 0 0 1 0 0 0 0
            // 7   0 0 0 1 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(0, 3); });
            Assert.That(ex.Message, Is.EqualTo("Zet (0,3) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, Game.Bord[1, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[2, 3]);
            Assert.AreEqual(Kleur.Geen, Game.Bord[0, 3]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechts_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Game.DoeZet(4, 7);
            // Assert
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 5]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 6]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechts_Exception()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 1 0 0 0 0  
            // 1   0 0 0 1 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            //Game.DoeZet(4, 7);
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(4, 7); });
            Assert.That(ex.Message, Is.EqualTo("Zet (4,7) is niet mogelijk!"));


            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 5]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 6]);
            Assert.AreEqual(Kleur.Geen, Game.Bord[4, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[4, 0] = Kleur.Zwart;
            Game.Bord[4, 1] = Kleur.Wit;
            Game.Bord[4, 2] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Wit;
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0 
            // 4   2 1 1 1 1 1 1 2 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Game.DoeZet(4, 7);
            // Assert
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 0]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 1]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 2]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 5]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 6]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsEnTotLinksReedsGevuld_Exception()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[4, 0] = Kleur.Zwart;
            Game.Bord[4, 1] = Kleur.Wit;
            Game.Bord[4, 2] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Wit;
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  

            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   2 1 1 1 1 1 1 1 <
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;

            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(4, 7); });
            Assert.That(ex.Message, Is.EqualTo("Zet (4,7) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 0]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 1]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 2]);

            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 5]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 6]);
            Assert.AreEqual(Kleur.Geen, Game.Bord[4, 7]);
        }


        //     0 1 2 3 4 5 6 7
        //                     
        // 0   0 0 0 0 0 0 0 0  
        // 1   0 0 0 0 0 0 0 0
        // 2   0 0 0 0 0 0 0 0
        // 3   0 0 0 1 2 0 0 0
        // 4   0 0 0 2 1 0 0 0
        // 5   0 0 0 0 0 0 0 0
        // 6   0 0 0 0 0 0 0 0
        // 7   0 0 0 0 0 0 0 0



        [Test]
        public void DoeZet_StartSituatieZet22Wit_Exception()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Wit;
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(2, 2); });
            Assert.That(ex.Message, Is.EqualTo("Zet (2,2) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[2, 2]);
        }

        [Test]
        public void DoeZet_StartSituatieZet22Zwart_Exception()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //         v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0 <
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0

            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(2, 2); });
            Assert.That(ex.Message, Is.EqualTo("Zet (2,2) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[2, 2]);
        }


        [Test]
        public void DoeZet_ZetAanDeRandRechtsBoven_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 5] = Kleur.Zwart;
            Game.Bord[1, 6] = Kleur.Zwart;
            Game.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 1  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Wit;
            Game.DoeZet(0, 7);
            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[5, 2]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[2, 5]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[1, 6]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[0, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsBoven_Exception()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 5] = Kleur.Zwart;
            Game.Bord[1, 6] = Kleur.Zwart;
            Game.Bord[5, 2] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 2  <
            // 1   0 0 0 0 0 0 2 0
            // 2   0 0 0 0 0 2 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 1 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(0, 7); });
            Assert.That(ex.Message, Is.EqualTo("Zet (0,7) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Zwart, Game.Bord[1, 6]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[2, 5]);

            Assert.AreEqual(Kleur.Wit, Game.Bord[5, 2]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[0, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsOnder_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 2] = Kleur.Zwart;
            Game.Bord[5, 5] = Kleur.Wit;
            Game.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 2 <
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Game.DoeZet(7, 7);
            // Assert
            Assert.AreEqual(Kleur.Zwart, Game.Bord[2, 2]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[5, 5]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[6, 6]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[7, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsOnder_Exception()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 2] = Kleur.Zwart;
            Game.Bord[5, 5] = Kleur.Wit;
            Game.Bord[6, 6] = Kleur.Wit;
            //     0 1 2 3 4 5 6 7
            //                   v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 2 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 1 0 0
            // 6   0 0 0 0 0 0 1 0
            // 7   0 0 0 0 0 0 0 1 <
            // Act
            Game.AandeBeurt = Kleur.Wit;
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(7, 7); });
            Assert.That(ex.Message, Is.EqualTo("Zet (7,7) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Zwart, Game.Bord[2, 2]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[5, 5]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[6, 6]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[7, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksBoven_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 1] = Kleur.Wit;
            Game.Bord[2, 2] = Kleur.Wit;
            Game.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   2 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0 
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Game.DoeZet(0, 0);
            // Assert
            Assert.AreEqual(Kleur.Zwart, Game.Bord[0, 0]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[1, 1]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[2, 2]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[5, 5]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksBoven_Exception()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[1, 1] = Kleur.Wit;
            Game.Bord[2, 2] = Kleur.Wit;
            Game.Bord[5, 5] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 0 0 0 0 0 0 0  <
            // 1   0 1 0 0 0 0 0 0
            // 2   0 0 1 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 2 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0          
            // Act
            Game.AandeBeurt = Kleur.Wit;
            //Game.DoeZet(0, 0);
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(0, 0); });
            Assert.That(ex.Message, Is.EqualTo("Zet (0,0) is niet mogelijk!"));


            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, Game.Bord[1, 1]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[2, 2]);

            Assert.AreEqual(Kleur.Zwart, Game.Bord[5, 5]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[0, 0]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksOnder_ZetCorrectUitgevoerd()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 5] = Kleur.Wit;
            Game.Bord[5, 2] = Kleur.Zwart;
            Game.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   1 0 0 0 0 0 0 0 <
            // Act
            Game.AandeBeurt = Kleur.Wit;
            Game.DoeZet(7, 0);
            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[7, 0]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[6, 1]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[5, 2]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[2, 5]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandLinksOnder_Exception()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 5] = Kleur.Wit;
            Game.Bord[5, 2] = Kleur.Zwart;
            Game.Bord[6, 1] = Kleur.Zwart;
            //     0 1 2 3 4 5 6 7
            //     v
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 1 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 2 0 0 0 0 0
            // 6   0 2 0 0 0 0 0 0
            // 7   2 0 0 0 0 0 0 0 <
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Exception ex = Assert.Throws<Exception>(delegate { Game.DoeZet(7, 0); });
            Assert.That(ex.Message, Is.EqualTo("Zet (7,0) is niet mogelijk!"));

            // Assert
            Assert.AreEqual(Kleur.Wit, Game.Bord[3, 3]);
            Assert.AreEqual(Kleur.Wit, Game.Bord[4, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[3, 4]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[4, 3]);

            Assert.AreEqual(Kleur.Wit, Game.Bord[2, 5]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[5, 2]);
            Assert.AreEqual(Kleur.Zwart, Game.Bord[6, 1]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[7, 7]);

            Assert.AreEqual(Kleur.Geen, Game.Bord[7, 0]);
        }

        [Test]
        public void Pas_ZwartAanZetGeenZetMogelijk_ReturnTrueEnWisselBeurt()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Game Game = new Game();
            Game.Bord[0, 0] = Kleur.Wit;
            Game.Bord[0, 1] = Kleur.Wit;
            Game.Bord[0, 2] = Kleur.Wit;
            Game.Bord[0, 3] = Kleur.Wit;
            Game.Bord[0, 4] = Kleur.Wit;
            Game.Bord[0, 5] = Kleur.Wit;
            Game.Bord[0, 6] = Kleur.Wit;
            Game.Bord[0, 7] = Kleur.Wit;
            Game.Bord[1, 0] = Kleur.Wit;
            Game.Bord[1, 1] = Kleur.Wit;
            Game.Bord[1, 2] = Kleur.Wit;
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[1, 4] = Kleur.Wit;
            Game.Bord[1, 5] = Kleur.Wit;
            Game.Bord[1, 6] = Kleur.Wit;
            Game.Bord[1, 7] = Kleur.Wit;
            Game.Bord[2, 0] = Kleur.Wit;
            Game.Bord[2, 1] = Kleur.Wit;
            Game.Bord[2, 2] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[2, 4] = Kleur.Wit;
            Game.Bord[2, 5] = Kleur.Wit;
            Game.Bord[2, 6] = Kleur.Wit;
            Game.Bord[2, 7] = Kleur.Wit;
            Game.Bord[3, 0] = Kleur.Wit;
            Game.Bord[3, 1] = Kleur.Wit;
            Game.Bord[3, 2] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[3, 4] = Kleur.Wit;
            Game.Bord[3, 5] = Kleur.Wit;
            Game.Bord[3, 6] = Kleur.Wit;
            Game.Bord[3, 7] = Kleur.Geen;
            Game.Bord[4, 0] = Kleur.Wit;
            Game.Bord[4, 1] = Kleur.Wit;
            Game.Bord[4, 2] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Wit;
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Geen;
            Game.Bord[4, 7] = Kleur.Geen;
            Game.Bord[5, 0] = Kleur.Wit;
            Game.Bord[5, 1] = Kleur.Wit;
            Game.Bord[5, 2] = Kleur.Wit;
            Game.Bord[5, 3] = Kleur.Wit;
            Game.Bord[5, 4] = Kleur.Wit;
            Game.Bord[5, 5] = Kleur.Wit;
            Game.Bord[5, 6] = Kleur.Geen;
            Game.Bord[5, 7] = Kleur.Zwart;
            Game.Bord[6, 0] = Kleur.Wit;
            Game.Bord[6, 1] = Kleur.Wit;
            Game.Bord[6, 2] = Kleur.Wit;
            Game.Bord[6, 3] = Kleur.Wit;
            Game.Bord[6, 4] = Kleur.Wit;
            Game.Bord[6, 5] = Kleur.Wit;
            Game.Bord[6, 6] = Kleur.Wit;
            Game.Bord[6, 7] = Kleur.Geen;
            Game.Bord[7, 0] = Kleur.Wit;
            Game.Bord[7, 1] = Kleur.Wit;
            Game.Bord[7, 2] = Kleur.Wit;
            Game.Bord[7, 3] = Kleur.Wit;
            Game.Bord[7, 4] = Kleur.Wit;
            Game.Bord[7, 5] = Kleur.Wit;
            Game.Bord[7, 6] = Kleur.Wit;
            Game.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            Game.AandeBeurt = Kleur.Zwart;
            Game.Pas();
            // Assert
            Assert.AreEqual(Kleur.Wit, Game.AandeBeurt);
        }

        [Test]
        public void Pas_WitAanZetGeenZetMogelijk_ReturnTrueEnWisselBeurt()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Game Game = new Game();
            Game.Bord[0, 0] = Kleur.Wit;
            Game.Bord[0, 1] = Kleur.Wit;
            Game.Bord[0, 2] = Kleur.Wit;
            Game.Bord[0, 3] = Kleur.Wit;
            Game.Bord[0, 4] = Kleur.Wit;
            Game.Bord[0, 5] = Kleur.Wit;
            Game.Bord[0, 6] = Kleur.Wit;
            Game.Bord[0, 7] = Kleur.Wit;
            Game.Bord[1, 0] = Kleur.Wit;
            Game.Bord[1, 1] = Kleur.Wit;
            Game.Bord[1, 2] = Kleur.Wit;
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[1, 4] = Kleur.Wit;
            Game.Bord[1, 5] = Kleur.Wit;
            Game.Bord[1, 6] = Kleur.Wit;
            Game.Bord[1, 7] = Kleur.Wit;
            Game.Bord[2, 0] = Kleur.Wit;
            Game.Bord[2, 1] = Kleur.Wit;
            Game.Bord[2, 2] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[2, 4] = Kleur.Wit;
            Game.Bord[2, 5] = Kleur.Wit;
            Game.Bord[2, 6] = Kleur.Wit;
            Game.Bord[2, 7] = Kleur.Wit;
            Game.Bord[3, 0] = Kleur.Wit;
            Game.Bord[3, 1] = Kleur.Wit;
            Game.Bord[3, 2] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[3, 4] = Kleur.Wit;
            Game.Bord[3, 5] = Kleur.Wit;
            Game.Bord[3, 6] = Kleur.Wit;
            Game.Bord[3, 7] = Kleur.Geen;
            Game.Bord[4, 0] = Kleur.Wit;
            Game.Bord[4, 1] = Kleur.Wit;
            Game.Bord[4, 2] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Wit;
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Geen;
            Game.Bord[4, 7] = Kleur.Geen;
            Game.Bord[5, 0] = Kleur.Wit;
            Game.Bord[5, 1] = Kleur.Wit;
            Game.Bord[5, 2] = Kleur.Wit;
            Game.Bord[5, 3] = Kleur.Wit;
            Game.Bord[5, 4] = Kleur.Wit;
            Game.Bord[5, 5] = Kleur.Wit;
            Game.Bord[5, 6] = Kleur.Geen;
            Game.Bord[5, 7] = Kleur.Zwart;
            Game.Bord[6, 0] = Kleur.Wit;
            Game.Bord[6, 1] = Kleur.Wit;
            Game.Bord[6, 2] = Kleur.Wit;
            Game.Bord[6, 3] = Kleur.Wit;
            Game.Bord[6, 4] = Kleur.Wit;
            Game.Bord[6, 5] = Kleur.Wit;
            Game.Bord[6, 6] = Kleur.Wit;
            Game.Bord[6, 7] = Kleur.Geen;
            Game.Bord[7, 0] = Kleur.Wit;
            Game.Bord[7, 1] = Kleur.Wit;
            Game.Bord[7, 2] = Kleur.Wit;
            Game.Bord[7, 3] = Kleur.Wit;
            Game.Bord[7, 4] = Kleur.Wit;
            Game.Bord[7, 5] = Kleur.Wit;
            Game.Bord[7, 6] = Kleur.Wit;
            Game.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            Game.AandeBeurt = Kleur.Wit;
            Game.Pas();
            // Assert
            Assert.AreEqual(Kleur.Zwart, Game.AandeBeurt);
        }

        [Test]
        public void Afgelopen_GeenZetMogelijk_ReturnTrue()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Game Game = new Game();
            Game.Bord[0, 0] = Kleur.Wit;
            Game.Bord[0, 1] = Kleur.Wit;
            Game.Bord[0, 2] = Kleur.Wit;
            Game.Bord[0, 3] = Kleur.Wit;
            Game.Bord[0, 4] = Kleur.Wit;
            Game.Bord[0, 5] = Kleur.Wit;
            Game.Bord[0, 6] = Kleur.Wit;
            Game.Bord[0, 7] = Kleur.Wit;
            Game.Bord[1, 0] = Kleur.Wit;
            Game.Bord[1, 1] = Kleur.Wit;
            Game.Bord[1, 2] = Kleur.Wit;
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[1, 4] = Kleur.Wit;
            Game.Bord[1, 5] = Kleur.Wit;
            Game.Bord[1, 6] = Kleur.Wit;
            Game.Bord[1, 7] = Kleur.Wit;
            Game.Bord[2, 0] = Kleur.Wit;
            Game.Bord[2, 1] = Kleur.Wit;
            Game.Bord[2, 2] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[2, 4] = Kleur.Wit;
            Game.Bord[2, 5] = Kleur.Wit;
            Game.Bord[2, 6] = Kleur.Wit;
            Game.Bord[2, 7] = Kleur.Wit;
            Game.Bord[3, 0] = Kleur.Wit;
            Game.Bord[3, 1] = Kleur.Wit;
            Game.Bord[3, 2] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[3, 4] = Kleur.Wit;
            Game.Bord[3, 5] = Kleur.Wit;
            Game.Bord[3, 6] = Kleur.Wit;
            Game.Bord[3, 7] = Kleur.Geen;
            Game.Bord[4, 0] = Kleur.Wit;
            Game.Bord[4, 1] = Kleur.Wit;
            Game.Bord[4, 2] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Wit;
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Geen;
            Game.Bord[4, 7] = Kleur.Geen;
            Game.Bord[5, 0] = Kleur.Wit;
            Game.Bord[5, 1] = Kleur.Wit;
            Game.Bord[5, 2] = Kleur.Wit;
            Game.Bord[5, 3] = Kleur.Wit;
            Game.Bord[5, 4] = Kleur.Wit;
            Game.Bord[5, 5] = Kleur.Wit;
            Game.Bord[5, 6] = Kleur.Geen;
            Game.Bord[5, 7] = Kleur.Zwart;
            Game.Bord[6, 0] = Kleur.Wit;
            Game.Bord[6, 1] = Kleur.Wit;
            Game.Bord[6, 2] = Kleur.Wit;
            Game.Bord[6, 3] = Kleur.Wit;
            Game.Bord[6, 4] = Kleur.Wit;
            Game.Bord[6, 5] = Kleur.Wit;
            Game.Bord[6, 6] = Kleur.Wit;
            Game.Bord[6, 7] = Kleur.Geen;
            Game.Bord[7, 0] = Kleur.Wit;
            Game.Bord[7, 1] = Kleur.Wit;
            Game.Bord[7, 2] = Kleur.Wit;
            Game.Bord[7, 3] = Kleur.Wit;
            Game.Bord[7, 4] = Kleur.Wit;
            Game.Bord[7, 5] = Kleur.Wit;
            Game.Bord[7, 6] = Kleur.Wit;
            Game.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 0
            // 4   1 1 1 1 1 1 0 0
            // 5   1 1 1 1 1 1 0 2
            // 6   1 1 1 1 1 1 1 0
            // 7   1 1 1 1 1 1 1 1
            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.Afgelopen();
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void Afgelopen_GeenZetMogelijkAllesBezet_ReturnTrue()
        {
            // Arrange  (zowel wit als zwart kunnen niet meer)
            Game Game = new Game();
            Game.Bord[0, 0] = Kleur.Wit;
            Game.Bord[0, 1] = Kleur.Wit;
            Game.Bord[0, 2] = Kleur.Wit;
            Game.Bord[0, 3] = Kleur.Wit;
            Game.Bord[0, 4] = Kleur.Wit;
            Game.Bord[0, 5] = Kleur.Wit;
            Game.Bord[0, 6] = Kleur.Wit;
            Game.Bord[0, 7] = Kleur.Wit;
            Game.Bord[1, 0] = Kleur.Wit;
            Game.Bord[1, 1] = Kleur.Wit;
            Game.Bord[1, 2] = Kleur.Wit;
            Game.Bord[1, 3] = Kleur.Wit;
            Game.Bord[1, 4] = Kleur.Wit;
            Game.Bord[1, 5] = Kleur.Wit;
            Game.Bord[1, 6] = Kleur.Wit;
            Game.Bord[1, 7] = Kleur.Wit;
            Game.Bord[2, 0] = Kleur.Wit;
            Game.Bord[2, 1] = Kleur.Wit;
            Game.Bord[2, 2] = Kleur.Wit;
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[2, 4] = Kleur.Wit;
            Game.Bord[2, 5] = Kleur.Wit;
            Game.Bord[2, 6] = Kleur.Wit;
            Game.Bord[2, 7] = Kleur.Wit;
            Game.Bord[3, 0] = Kleur.Wit;
            Game.Bord[3, 1] = Kleur.Wit;
            Game.Bord[3, 2] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[3, 4] = Kleur.Wit;
            Game.Bord[3, 5] = Kleur.Wit;
            Game.Bord[3, 6] = Kleur.Wit;
            Game.Bord[3, 7] = Kleur.Wit;
            Game.Bord[4, 0] = Kleur.Wit;
            Game.Bord[4, 1] = Kleur.Wit;
            Game.Bord[4, 2] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Wit;
            Game.Bord[4, 5] = Kleur.Wit;
            Game.Bord[4, 6] = Kleur.Zwart;
            Game.Bord[4, 7] = Kleur.Zwart;
            Game.Bord[5, 0] = Kleur.Wit;
            Game.Bord[5, 1] = Kleur.Wit;
            Game.Bord[5, 2] = Kleur.Wit;
            Game.Bord[5, 3] = Kleur.Wit;
            Game.Bord[5, 4] = Kleur.Wit;
            Game.Bord[5, 5] = Kleur.Wit;
            Game.Bord[5, 6] = Kleur.Zwart;
            Game.Bord[5, 7] = Kleur.Zwart;
            Game.Bord[6, 0] = Kleur.Wit;
            Game.Bord[6, 1] = Kleur.Wit;
            Game.Bord[6, 2] = Kleur.Wit;
            Game.Bord[6, 3] = Kleur.Wit;
            Game.Bord[6, 4] = Kleur.Wit;
            Game.Bord[6, 5] = Kleur.Wit;
            Game.Bord[6, 6] = Kleur.Wit;
            Game.Bord[6, 7] = Kleur.Zwart;
            Game.Bord[7, 0] = Kleur.Wit;
            Game.Bord[7, 1] = Kleur.Wit;
            Game.Bord[7, 2] = Kleur.Wit;
            Game.Bord[7, 3] = Kleur.Wit;
            Game.Bord[7, 4] = Kleur.Wit;
            Game.Bord[7, 5] = Kleur.Wit;
            Game.Bord[7, 6] = Kleur.Wit;
            Game.Bord[7, 7] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //     v
            // 0   1 1 1 1 1 1 1 1  
            // 1   1 1 1 1 1 1 1 1
            // 2   1 1 1 1 1 1 1 1
            // 3   1 1 1 1 1 1 1 2
            // 4   1 1 1 1 1 1 2 2
            // 5   1 1 1 1 1 1 2 2
            // 6   1 1 1 1 1 1 1 2
            // 7   1 1 1 1 1 1 1 1
            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.Afgelopen();
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void Afgelopen_WelZetMogelijk_ReturnFalse()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            Game.AandeBeurt = Kleur.Wit;
            var actual = Game.Afgelopen();
            // Assert
            Assert.IsFalse(actual);
        }



        [Test]
        public void OverwegendeKleur_Gelijk_ReturnKleurGeen()
        {
            // Arrange
            Game Game = new Game();
            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 0 0 0 0 0
            // 3   0 0 0 1 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = Game.OverwegendeKleur();
            // Assert
            Assert.AreEqual(Kleur.Geen, actual);
        }

        [Test]
        public void OverwegendeKleur_Zwart_ReturnKleurZwart()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 3] = Kleur.Zwart;
            Game.Bord[3, 3] = Kleur.Zwart;
            Game.Bord[4, 3] = Kleur.Zwart;
            Game.Bord[3, 4] = Kleur.Zwart;
            Game.Bord[4, 4] = Kleur.Wit;

            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 2 0 0 0 0
            // 3   0 0 0 2 2 0 0 0
            // 4   0 0 0 2 1 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = Game.OverwegendeKleur();
            // Assert
            Assert.AreEqual(Kleur.Zwart, actual);
        }

        [Test]
        public void OverwegendeKleur_Wit_ReturnKleurWit()
        {
            // Arrange
            Game Game = new Game();
            Game.Bord[2, 3] = Kleur.Wit;
            Game.Bord[3, 3] = Kleur.Wit;
            Game.Bord[4, 3] = Kleur.Wit;
            Game.Bord[3, 4] = Kleur.Wit;
            Game.Bord[4, 4] = Kleur.Zwart;


            //     0 1 2 3 4 5 6 7
            //                     
            // 0   0 0 0 0 0 0 0 0  
            // 1   0 0 0 0 0 0 0 0
            // 2   0 0 0 1 0 0 0 0
            // 3   0 0 0 1 1 0 0 0
            // 4   0 0 0 1 2 0 0 0
            // 5   0 0 0 0 0 0 0 0
            // 6   0 0 0 0 0 0 0 0
            // 7   0 0 0 0 0 0 0 0
            //                     
            // Act
            var actual = Game.OverwegendeKleur();
            // Assert
            Assert.AreEqual(Kleur.Wit, actual);
        }
    }
}

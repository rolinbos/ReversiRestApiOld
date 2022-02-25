using System;
using System.Collections.Generic;
using NUnit.Framework;
using ReversiRestApi.Models;

namespace TestReversiRestApi.Repository
{
    [TestFixture]
    public class SpelRepository
    {
        private List<Spel> Spellen { get; set; }
        private ReversiRestApi.Repositories.SpelRepository _repository;
        
        [SetUp]
        public void SetUp()
        {
            Spel spel1 = new Spel();
            Spel spel2 = new Spel();
            Spel spel3 = new Spel();

            spel1.Speler1Token = "abcdef";
            spel1.Omschrijving = "Potje snel reveri, dus niet lang nadenken";
            spel2.Speler1Token = "ghijkl";
            spel2.Speler2Token = "mnopqr";
            spel2.Omschrijving = "Ik zoek een gevorderde tegenspeler!";
            spel3.Speler1Token = "stuvwx";
            spel3.Omschrijving = "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander";
            

            Spellen = new List<Spel> {spel1, spel2, spel3};
        }

        [Test]
        public void TestAddSpel()
        {
            Spel spel = new Spel()
            {
                Speler1Token = "abc",
                Speler2Token = "cde",
                Omschrijving = "Description from spel",
            };
            
            this._repository.AddSpel(spel);
            
            Assert.AreEqual(this.Spellen.Count, this._repository.GetSpellen().Count);
        }

        [Test]
        public void TestGetSpellen()
        {
            Assert.AreEqual(3, this._repository.GetSpellen().Count);
        }

        [Test]
        public void TestGetSpelDescriptionWithWaitingPlayers()
        {
            List<String> descriptions = new List<String>()
            {
                "Potje snel reveri, dus niet lang nadenken",
                "Na dit spel wil ik er nog een paar spelen tegen zelfde tegenstander"
            };
            
            Assert.AreEqual(descriptions, _repository.GetSpelDescriptionWithWaitingPlayers());
        }
    }
}
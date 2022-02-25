using System;
using System.Collections.Generic;
using System.Linq;
using ReversiRestApi.Interfaces;
using ReversiRestApi.Models;

namespace ReversiRestApi.Repositories
{
    public class SpelRepository: ISpelRepository
    {
        public List<Spel> Spellen { get; set; }
        
        public SpelRepository()
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

        public void AddSpel(Spel spel)
        {
            this.Spellen.Add(spel);
        }

        public List<Spel> GetSpellen()
        {
            return this.Spellen;
        }

        public Spel GetSpel(string spelToken)
        {
            return this.Spellen.First();
        }

        public List<String> GetSpelDescriptionWithWaitingPlayers()
        {
            return this.Spellen.Where(spel => (spel.Speler2Token == null || spel.Speler2Token == ""))
                .Select(spel => spel.Omschrijving).ToList();
        }
    }
}
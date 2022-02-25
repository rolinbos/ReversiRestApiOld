using System;
using System.Collections.Generic;
using ReversiRestApi.Models;

namespace ReversiRestApi.Interfaces
{
    public interface ISpelRepository
    {
        void AddSpel(Spel spel);

        public List<Spel> GetSpellen();

        Spel GetSpel(string spelToken);

        List<String> GetSpelDescriptionWithWaitingPlayers();
    }
}
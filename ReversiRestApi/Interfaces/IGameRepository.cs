using System;
using System.Collections.Generic;
using ReversiRestApi.Models;

namespace ReversiRestApi.Interfaces
{
    public interface IGameRepository
    {
        void CreateGame(Game game);

        List<Game> GetWaitingGames();

        Game GetGameFromToken(string gameToken);

        Game GetGameFromPlayerToken(string playerToken);

        Kleur GetTurn(string gameToken); //TODO: implement

        void TakeTurn(); //TODO: implement

        void GiveUp(); //TODO: implement
    }
}
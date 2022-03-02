using System;
namespace ReversiRestApi.Interfaces
{
    public enum Kleur { Geen, Wit, Zwart };

    public interface IGame
    {
        int ID { get; set; }
        string Description { get; set; }

        //het unieke token van het Game
        string Token { get; set; }
        string Player1Token { get; set; }
        string Player2Token { get; set; }

        Kleur[,] Bord { get; set; }
        Kleur AandeBeurt { get; set; }
        void Pas();
        bool Afgelopen();

        //welke kleur het meest voorkomend op het speelbord
        Kleur OverwegendeKleur();

        //controle of op een bepaalde positie een zet mogelijk is
        bool ZetMogelijk(int rijZet, int kolomZet);
        void DoeZet(int rijZet, int kolomZet);
    }
}

namespace ReversiRestApi.Requests
{
    public class GameRequest
    {
        public string Description { get; set; }
        public string Player1Token { get; set; }
        public string Player2Token { get; set; }
    }
}
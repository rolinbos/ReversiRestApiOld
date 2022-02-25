using NUnit.Framework;
using ReversiRestApi.Requests;

namespace TestReversiRestApi.Requests
{
    [TestFixture]
    public class SpelRequestTest
    {
        private SpelRequest spelRequest = new SpelRequest();
        
        [Test]
        public void SetAndGetOmschrijving()
        {
            string omschrijving = "Omschrijving van spel";
            this.spelRequest.Omschrijving = omschrijving;
            
            Assert.AreEqual(omschrijving, this.spelRequest.Omschrijving);
        }

        [Test]
        public void SetAndGetSpeler1Token()
        {
            string token = "1122A";
            this.spelRequest.Speler1Token = token;
            
            Assert.AreEqual(token, this.spelRequest.Speler1Token);
        }

        [Test]
        public void SetAndGetSpeler2Token()
        {
            string token = "1122A";
            this.spelRequest.Speler2Token = token;
            
            Assert.AreEqual(token, this.spelRequest.Speler2Token);
        }
    }
}
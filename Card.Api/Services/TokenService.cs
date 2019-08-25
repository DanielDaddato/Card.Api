using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Card.Api.Models;

namespace Card.Api.Services
{
    public class TokenService : ITokenService
    {
        public async Task<long> GenerateToken(CardData cardData)
        {
            var baseToken = await Encapsulate(cardData.CardNumber, cardData.RegistrationData);
            var arrayToken = await CompressToken(baseToken);
            var token = await shuffleToken(arrayToken, cardData.CVV);
            return token;
        }

        private async Task<string> Encapsulate(long card, DateTime date)
        {
            return card.ToString() + date.Year.ToString("0000") + date.Month.ToString("00") + date.Day.ToString("00") + date.Hour.ToString("00") + date.Minute.ToString("00");

        }

        private async Task<List<int>> CompressToken(string baseToken)
        {
            int parser = 0;
            var baseArray = baseToken.ToArray();
            var array = Array.ConvertAll(baseArray, x => Convert.ToInt32(x.ToString()));
            var minimunValue = array.Min();
            var span = minimunValue + 5;
            List<int> tokenArray = new List<int>();
            foreach (var item in array)
            {
                if (item <= span)
                {
                    tokenArray.Add(item);
                }
            }
            return tokenArray;
        }

        private async Task<long> shuffleToken(List<int> arrayToken, int cVV)
        {
            for (int i = 0; i < cVV ; i++)
            {
                var item = arrayToken.Last();
                arrayToken.RemoveAt(arrayToken.Count - 1);
                arrayToken.Insert(0, item);
            }
            var token = Convert.ToInt64(string.Join(string.Empty, arrayToken));
            return token;
        }

    }
}

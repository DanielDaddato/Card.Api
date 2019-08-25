using Card.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Data
{
    public class CardRepository : ICardRepository
    {
        private static List<CardData> cardList;
        public CardRepository()
        {
            cardList = new List<CardData>();
        }
        

        public void AddCard(CardData cardData)
        {
            
            cardList.Add(cardData);
        }

        public List<CardData> GetCard(DateTime registrationDate)
        {
            var cardData = cardList.FindAll(x => x.RegistrationData == registrationDate).ToList();
            return cardData;
        }



    }
}

using Card.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Data
{
    public interface ICardRepository
    {
        void AddCard(CardData cardData);


        List<CardData> GetCard(DateTime registrationDate);
    }
}

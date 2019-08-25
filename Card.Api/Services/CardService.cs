using Card.Api.Data;
using Card.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Services
{
    public class CardService: ICardService
    {
        private readonly ITokenService _tokenService;
        private readonly ICardRepository _cardRepository;
        public CardService(ITokenService tokenService, ICardRepository cardRepository)
        {
            _tokenService = tokenService;
            _cardRepository = cardRepository;
        }
        public async Task<TokenInfo> RegisterCard(CardInfo cardInfo)
        {
            CardData cardData = new CardData
            {
                CardNumber = cardInfo.CardNumber,
                CVV = cardInfo.CVV,
                RegistrationData = DateTime.UtcNow

            };

            _cardRepository.AddCard(cardData);

            var token = await _tokenService.GenerateToken(cardData);

            var tokenInfo = new TokenInfo

            {
                Token = token,
                RegistrationDate = cardData.RegistrationData
            };

            return tokenInfo;
        }

        public async Task<bool> CompareCard(ValidationInfo validationInfo)
        {
            var cardList = _cardRepository.GetCard(validationInfo.RegistrationDate);
            
            foreach (var cardData in cardList)
            {
                cardData.RegistrationData = validationInfo.RegistrationDate;
                cardData.CVV = validationInfo.CVV;
                var compareToken = await _tokenService.GenerateToken(cardData);
                if (compareToken == validationInfo.Token)
                {
                    return true;
                }
            }

            return false;
        }

    }
}

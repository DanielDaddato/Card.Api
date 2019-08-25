using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Card.Api.Data;
using Card.Api.Models;
using Card.Api.Services;
using Moq;
using NUnit.Framework;

namespace Card.Api.Test.ServiceTest
{
    public class CardServiceTest
    {
        private CardService cardService;
        private Mock<ITokenService> tokenService;
        private Mock<ICardRepository> cardRepository;
        private CardData _cardData;
        private TokenInfo _tokenInfo;
        public CardServiceTest()
        {
            tokenService = new Mock<ITokenService>();
            cardRepository = new Mock<ICardRepository>();
            cardService = new CardService(tokenService.Object, cardRepository.Object);
        }

        [SetUp]
        public void Setup()
        {
            _cardData = new CardData
            {
                CardNumber= 3456909687651234,
                CVV= 150,
                RegistrationData = Convert.ToDateTime("2019-08-25T01:59:05.4686297Z")
            };

            cardRepository.Setup(r => r.AddCard(_cardData));

            _tokenInfo = new TokenInfo
            {
                Token = 25015345051234201,
                RegistrationDate = Convert.ToDateTime("2019-08-25T01:59:05.4686297Z")
            };

            
            tokenService.Setup(m => m.GenerateToken(_cardData)).Returns(Task.FromResult(25015345051234201));

        }

        [Test]
        public void RegisterCardTest()
        {
            var cardInfo = new CardInfo
            {
                CardNumber = 3456909687651234,
                CVV = 150
            };

            tokenService.Setup(m => m.GenerateToken(It.IsAny<CardData>())).Returns(Task.FromResult(25015345051234201));

            var ret = cardService.RegisterCard(cardInfo).Result;
            Assert.AreEqual(_tokenInfo.Token, ret.Token);
        }

        [Test]
        public void CompareCardTrueTest()
        {
            var validationInfo = new ValidationInfo
            {
                Token = 25015345051234201,
                CVV = 150,
                RegistrationDate = Convert.ToDateTime("2019-08-25T01:59:05.4686297Z")
            };

            var cardList = new List<CardData>();
            cardList.Add(_cardData);

            cardRepository.Setup(r => r.GetCard(Convert.ToDateTime("2019-08-25T01:59:05.4686297Z"))).Returns(cardList);
            tokenService.Setup(m => m.GenerateToken(It.IsAny<CardData>())).Returns(Task.FromResult(25015345051234201));

            var ret = cardService.CompareCard(validationInfo).Result;
            Assert.AreEqual(true, ret);
        }

        [Test]
        public void CompareCardFalseTest()
        {
            var validationInfo = new ValidationInfo
            {
                Token = 25015345051234203,
                CVV = 150,
                RegistrationDate = Convert.ToDateTime("2019-08-25T01:59:05.4686297Z")
            };

            var cardList = new List<CardData>();
            cardList.Add(_cardData);

            cardRepository.Setup(r => r.GetCard(Convert.ToDateTime("2019-08-25T01:59:05.4686297Z"))).Returns(cardList);
            tokenService.Setup(m => m.GenerateToken(It.IsAny<CardData>())).Returns(Task.FromResult(25015345051234201));

            var ret = cardService.CompareCard(validationInfo).Result;
            Assert.AreEqual(false, ret);
        }
    }
}

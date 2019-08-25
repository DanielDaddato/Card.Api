using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Card.Api.Services;
using Moq;
using Card.Api.Models;

namespace Card.Api.Test.ServiceTest
{
    public class TokenServiceTest
    {
        private TokenService tokenService;
        private CardData _cardData;

        public TokenServiceTest()
        {
            tokenService = new TokenService();
        }

        [SetUp]
        public void Setup()
        {

            _cardData = new CardData
            {
                CardNumber = 3456909687651234,
                CVV = 150,
                RegistrationData = Convert.ToDateTime("2019-08-25T01:59:05.4686297Z")
            };
            
            
        }

        [Test]
        public void GenerateToken()
        {
            var ret = tokenService.GenerateToken(_cardData).Result;
            Assert.AreEqual(24225345051234201, ret);
        }

    }
}

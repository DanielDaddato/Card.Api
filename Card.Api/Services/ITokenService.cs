using Card.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Services
{
    public interface ITokenService
    {
        Task<long> GenerateToken(CardData cardData);
    }
}

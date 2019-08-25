using Card.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Api.Services
{
    public interface ICardService
    {
        Task<TokenInfo> RegisterCard(CardInfo cardInfo);

        Task<bool> CompareCard(ValidationInfo validationInfo);
    }
}

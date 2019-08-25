using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Card.Api.Models;
using Card.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("validation")]
        public async Task<ActionResult> Validation([FromBody]ValidationInfo validation)
        {
            try
            {
                var result = await _cardService.CompareCard(validation);
                var validationResult = new ValidationResult()
                {
                    Validation = result
                };
                return Ok(validationResult);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(CardInfo cardInfo)
        {
            try
            {
                var result = await _cardService.RegisterCard(cardInfo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

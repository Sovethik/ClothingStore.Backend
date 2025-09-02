using AutoMapper;
using Clothing.Application.Order.CreateOrder;
using Clothing.Domain.Entity;
using Clothing.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clothing.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IMapper _mapper;
        private IMediator _mediator;

        public OrderController(IMapper mapper, IMediator mediator) 
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrders(CreateOrderDto order)
        {

            var command = _mapper.Map<CreateOrderCommand>(order);

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;//В NameIdentifier кладется id из sub

            if (userId == null)
                return Unauthorized();

            command.UserId = Convert.ToInt32(userId);

            var resultCommand = await _mediator.Send(command);

            return Ok(resultCommand);
            
        }
    }
}

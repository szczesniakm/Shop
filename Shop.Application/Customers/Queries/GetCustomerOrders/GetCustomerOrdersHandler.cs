using AutoMapper;
using MediatR;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Customers.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersHandler : IRequestHandler<GetCustomerOrders, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetCustomerOrdersHandler(IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        async Task<IEnumerable<OrderDto>> IRequestHandler<GetCustomerOrders, IEnumerable<OrderDto>>.Handle(GetCustomerOrders request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllUserOrders(request.Id);

            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
    }
}

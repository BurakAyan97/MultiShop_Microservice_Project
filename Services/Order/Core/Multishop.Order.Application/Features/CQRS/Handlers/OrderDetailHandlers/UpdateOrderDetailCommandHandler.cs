using Multishop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetail)
        {
            var values = await _repository.GetByIdAsync(updateOrderDetail.OrderDetailId);

            values.OrderingId = updateOrderDetail.OrderingId;
            values.ProductId = updateOrderDetail.ProductId;
            values.ProductPrice= updateOrderDetail.ProductPrice;
            values.ProductName = updateOrderDetail.ProductName;
            values.ProductTotalPrice = updateOrderDetail.ProductTotalPrice;
            values.ProductAmount = updateOrderDetail.ProductAmount;
            
            await _repository.UpdateAsync(values);
        }
    }
}

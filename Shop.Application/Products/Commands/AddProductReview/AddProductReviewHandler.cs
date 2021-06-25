using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Models;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands
{
    public class AddProductReviewHandler : IRequestHandler<AddProductReview>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public AddProductReviewHandler(IProductRepository productRepository,
            ICustomerRepository customerRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(AddProductReview request, CancellationToken cancellationToken)
        {
            if(request.UserId == Guid.Empty)
            {
                throw new ServiceException("not_authenticated", "User not authenticated");
            }
            var customer = await _customerRepository.GetAsync(request.UserId);

            var product = await _productRepository.GetBySlugAsync(request.Slug);
            if(product == null)
            {
                throw new ServiceException("product_not_found", "Product not found");
            }
            var review = new Review(request.Rating, request.Description, customer);
            product.AddReview(review);

            await _productRepository.AddReviewAsync(review);
            await _productRepository.Save();

            return Unit.Value;
        }
    }
}

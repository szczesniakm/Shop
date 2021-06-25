using MediatR;
using Shop.Application.Exceptions;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands.RemoveProductReview
{
    public class RemoveProductReviewHandler : IRequestHandler<RemoveProductReview>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IReviewRepository _reviewRepository;

        public RemoveProductReviewHandler(IProductRepository productRepository,
            ICustomerRepository customerRepository,
            IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<Unit> Handle(RemoveProductReview request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(request.UserId);

            var review = await _reviewRepository.GetAsync(request.ReviewId);
            if(review == null)
            {
                throw new ServiceException("review_not_found", $"Review with Id {request.ReviewId} was not found.");
            }
            if(review.Customer.UserId != customer.UserId)
            {
                throw new ServiceException("review_not_found", "You must own review.");
            }

            await _reviewRepository.RemoveAsync(review);

            await _reviewRepository.Save();

            return Unit.Value;
        }
    }
}

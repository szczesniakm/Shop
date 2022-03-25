using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shop.Domain.Models
{
	public class Product
	{
        private readonly List<Review> _reviews = new();

		public Guid Id { get; protected set; }
		public string Code { get; protected set; }
		public string Name { get; protected set; }
		public string Slug { get; protected set; }
		public decimal Price { get; protected set; }
		public string Photo { get; protected set; }
		public int Stock { get; protected set; }

		public IReadOnlyList<Review> Reviews { get { return _reviews; } }

		private Product() { }
		public Product(Guid id, string code, string name, string slug, decimal price, string photo, int stock)
		{
			Id = id;
			Code = code;
			Name = name;
			Slug = slug;
			Price = price;
			Stock = stock;
			Photo = photo;
		}

		public void AddReview(Review review)
        {
			_reviews.Add(review);
        }

		public void EditReview(Guid id, decimal rating, string description)
		{
			var review = _reviews.Find(r => r.Id == id);
			review.SetRating(rating);
			review.SetDescription(description);
		}
	}

}

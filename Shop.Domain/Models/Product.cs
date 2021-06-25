using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shop.Domain.Models
{
	public class Product
	{
		private List<Review> _reviews = new List<Review>();

		public Guid Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }

		public IReadOnlyList<Review> Reviews { get { return _reviews; } }


		public Product(Guid id, string code, string name, string slug, decimal price, int stock)
		{
			Id = id;
			Code = code;
			Name = name;
			Slug = slug;
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

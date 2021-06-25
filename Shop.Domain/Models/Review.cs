using System;

namespace Shop.Domain.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }

        private Review()
        { }

        public Review(decimal rating, string description, Customer customer)
        {
            Id = Guid.NewGuid();
            SetRating(rating);
            SetDescription(description);
            Customer = customer;
        }

        internal void SetDescription(string description)
        {
            Description = description;
        }

        internal void SetRating(decimal rating)
        {
            if (rating < 1 || rating > 5)
                return;

            Rating = rating;
        }
    }
}
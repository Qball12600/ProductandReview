using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_ReviewsWebAPI.Data;
using Products_ReviewsWebAPI.Models;
using System.Drawing.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Products_ReviewsWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   
    public class ReviewsController : ControllerBase
    {
        private readonly List<Review> reviews = new List<Review>
        {
            new Review {Id = 1, ProductId = 1, Text = "Description for Product A"},
            new Review {Id = 2, ProductId = 15, Text = "Description for Product B"}
        };
        private readonly ApplicationDbContext _context;
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ReviewsController>
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            return Ok(reviews);
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public IActionResult GetReviewById(int id)
        {
            var review = reviews.FirstOrDefault(r => r.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public IActionResult CreateReview(Review newReview)
        {
            newReview.Id = reviews.Count + 1;
            reviews.Add(newReview);

            return CreatedAtAction(nameof(GetReviewById), new { id = newReview.Id }, newReview);
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public IActionResult UodateReview(int  Id,Review updatedReview)
        {

            var existingReview= reviews.FirstOrDefault(r => r.Id == Id);
            if (existingReview == null)
            {
                return NotFound();
            }
            existingReview.ProductId = updatedReview.ProductId;
            existingReview.Text = updatedReview.Text;

            return NoContent();
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            var reviewToRemove = reviews.FirstOrDefault(r => r.Id == id);
            if (reviewToRemove == null)
            {
                return NotFound();
            }
            reviews.Remove(reviewToRemove);
            return NoContent();
        }
    }
}

using Microservices.BackEnd.ShoppingCartAPI.Models.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.BackEnd.ShoppingCartAPI.Models
{
    public class CartDetails
    {
        public int Id { get; set; }
        public int CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }

        public int ProductId { get; set; }

        [NotMapped]
        public ProductDto ProductDto  { get; set; }
        public int Count { get; set; }

        public bool IsDeleted { get; set; }

    }
}

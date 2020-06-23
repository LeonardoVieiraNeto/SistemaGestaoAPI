using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoAPI
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int _id, string _name, decimal _purchasePrice, decimal _salePrice, string _unitOfmeasurement, int _stock, string _somenteAtivos, string _category)
        {
            this.Id = _id;
            this.Name = _name;
            this.PurchasePrice = _purchasePrice;
            this.SalePrice = _salePrice;
            this.UnitOfmeasurement = _unitOfmeasurement;
            this.Stock = _stock;
            this.SomenteAtivos = _somenteAtivos;
            this.Category = _category;
        }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        public string UnitOfmeasurement { get; set; }

        [Required]
        public int Stock { get; set; }

        public string SomenteAtivos { get; set; }

        public string Category { get; set; }
    }
}

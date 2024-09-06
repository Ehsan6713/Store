using Store.MVC.Models.Brands;
using Store.MVC.Models.CategoryViewModels;
using System.ComponentModel;

namespace Store.MVC.Models.ProductViewModels
{
    public class ProductVM : BaseVM
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public int BrandId { get; set; }
        [ReadOnly(true)]
        public BrandVM? Brand { get; set; }
        public int CategoryId { get; set; }
        [ReadOnly(true)]
        public CategoryVM? Category { get; set; }
    }
}

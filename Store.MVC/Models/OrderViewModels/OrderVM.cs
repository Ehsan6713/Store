namespace Store.MVC.Models.OrderViewModels
{
    public class OrderVM:BaseVM
    {
        public int UserId { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}

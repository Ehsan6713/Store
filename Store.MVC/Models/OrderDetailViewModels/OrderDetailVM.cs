namespace Store.MVC.Models.OrderDetailViewModels
{
    public class OrderDetailVM:BaseVM
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
    }
}

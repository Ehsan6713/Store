namespace Store.MVC.Models.AttachmentViewModels
{
    public class AttachmentVM: BaseVM
    {
        public string Title { get; set; }
        public byte[] Content { get; set; }
        public string Format { get; set; }
    }
}

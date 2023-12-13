namespace KursaVue.Model.modelUser
{
    public class ProductModelcs
    {
        public int Id { get; set; }

        public int? CategoriesId { get; set; }

        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public int? UserId { get; set; }

        public string? Img { get; set; }

        public string? Description { get; set; }

        public virtual Category? Categories { get; set; }

        public virtual UserModel? User { get; set; }

      
    }
}

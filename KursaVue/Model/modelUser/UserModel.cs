namespace KursaVue.Model.modelUser
{
    public class UserModel
    {
        public int Id { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? TypeUsers { get; set; }

        public int? PersonalDataId { get; set; }

        public virtual List<personalDataModel> PersonalData { get; set; } = new List<personalDataModel>();

        public virtual List<ProductModelcs> Products { get; set; } = new List<ProductModelcs>();
    }
}

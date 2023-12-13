namespace KursaVue.Model.modelUser
{
    public class personalDataModel
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string? Sname { get; set; }

        public string? MidellName { get; set; }

        public DateTime? Date { get; set; }

        public int Id { get; set; }

        public virtual UserModel User { get; set; } = null!;

      
    }
}

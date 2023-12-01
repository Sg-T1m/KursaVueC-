using KursaVue.Model;
using KursaVue.Repository;
using Microsoft.EntityFrameworkCore;

namespace KursaVue.Services
{
    public partial class DbWork
    {
        public  DbContextProductShop db = new DbContextProductShop();
        public  List<User> GetUser(string login)
        {
            3var user = db.Users.Where(p => p.Login == login).ToList();
            return user;
        }
        public List<User> GetUserData(string login)
        {
            var user = db.Users.Where(p => p.Login == login).Include(c=>c.PersonalData).ToList();
            return user;
        }
    }
}

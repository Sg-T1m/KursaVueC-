using AutoMapper;
using KursaVue.Model;
using KursaVue.Repository;
using Microsoft.EntityFrameworkCore;

namespace KursaVue.Services
{
    public partial class DbWork
    {
        private IMapper _mapper;
        public  DbContextProductShop db = new DbContextProductShop();
        public  List<User> GetUser(string login)
        {
            var user = db.Users.Where(p => p.Login == login).ToList();
            return user;
        }
        public List<User> GetUserData(string login)
        {
            var user = db.Users.Where(p => p.Login == login).Include(c=>c.PersonalData).ToList();
            return user;
        }
        public List<Category> GetProductsByCategory(int id)
        {
            var product = db.Categories.Where(p => p.Id == id).Include(c=>c.Products).ToList();
           
            return product;
        }
        public List<Product> GetAllProducts()
        {
            var product = db.Products.ToList();

            return product;
        }
    }
}

using KursaVue.Model;
using KursaVue.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KursaVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataUsersController : ControllerBase
    {

        private DbWork DbWork = new DbWork();
        [HttpGet]
        [Authorize]
        public IEnumerable<PersonalDataUserProfile> Get()
        {
            var req = (User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            var user = DbWork.GetUserData(req.Value).ToList();

            List<PersonalDataUserProfile> personalData = new List<PersonalDataUserProfile>() { new PersonalDataUserProfile() {
                   Id = user[0].Id, Login = user[0].Login.Replace(" ", ""), TypeUsers = user[0].TypeUsers.Replace(" ", ""), Name = user[0].PersonalData[0].Name.Replace(" ", ""), Sname = user[0].PersonalData[0].Sname.Replace(" ", ""), MidellName  = user[0].PersonalData[0].MidellName.Replace(" ", "")
            } };



            return personalData;
        }



    }
}

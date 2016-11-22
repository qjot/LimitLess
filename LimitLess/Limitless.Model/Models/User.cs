using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Limitless.Model
{
    public class User : IdentityUser
    {
        [DisplayName("Name")]
       private string name { get; set; }
        [DisplayName("Phone")]
       public string PhoneNumber { get; set; }
    }
}

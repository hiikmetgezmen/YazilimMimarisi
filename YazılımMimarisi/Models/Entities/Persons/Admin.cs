using Yaz�l�mMimarisi.Models.Common;
using Yaz�l�mMimarisi.Models.Common.Interfaces;

namespace Yaz�l�mMimarisi.Models.Entities.Persons {
    public class Admin : Person, ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
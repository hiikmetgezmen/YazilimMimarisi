using YazýlýmMimarisi.Models.Common;
using YazýlýmMimarisi.Models.Common.Interfaces;

namespace YazýlýmMimarisi.Models.Entities.Persons {
    public class Admin : Person, ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
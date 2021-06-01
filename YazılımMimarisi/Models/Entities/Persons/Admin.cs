using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Common.Interfaces;

namespace YazılımMimarisi.Models.Entities.Persons {
    public class Admin : Person, ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
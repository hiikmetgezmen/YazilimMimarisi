using YazýlýmMimarisi.Models.Common.Interfaces;

namespace YazýlýmMimarisi.Models.Common {
    public abstract class Login : ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
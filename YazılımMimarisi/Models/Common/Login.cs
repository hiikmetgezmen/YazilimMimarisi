using YazılımMimarisi.Models.Common.Interfaces;

namespace YazılımMimarisi.Models.Common {
    public abstract class Login : ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
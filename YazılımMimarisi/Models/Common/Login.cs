using Yaz�l�mMimarisi.Models.Common.Interfaces;

namespace Yaz�l�mMimarisi.Models.Common {
    public abstract class Login : ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
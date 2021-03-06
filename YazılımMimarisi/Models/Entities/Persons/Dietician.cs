using System.Collections.Generic;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Common.Interfaces;

namespace YazılımMimarisi.Models.Entities.Persons {
    public class Dietician : Person, ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> PatientIds { get; set; }
    }
}
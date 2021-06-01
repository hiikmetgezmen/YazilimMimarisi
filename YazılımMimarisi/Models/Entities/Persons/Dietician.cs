using System.Collections.Generic;
using YazýlýmMimarisi.Models.Common;
using YazýlýmMimarisi.Models.Common.Interfaces;

namespace YazýlýmMimarisi.Models.Entities.Persons {
    public class Dietician : Person, ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> PatientIds { get; set; }
    }
}
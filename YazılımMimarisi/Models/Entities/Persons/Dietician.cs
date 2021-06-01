using System.Collections.Generic;
using Yaz�l�mMimarisi.Models.Common;
using Yaz�l�mMimarisi.Models.Common.Interfaces;

namespace Yaz�l�mMimarisi.Models.Entities.Persons {
    public class Dietician : Person, ILogin {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> PatientIds { get; set; }
    }
}
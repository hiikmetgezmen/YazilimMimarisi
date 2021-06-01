using System.Collections.Generic;
using Yaz�l�mMimarisi.Models.Common;
using Yaz�l�mMimarisi.Models.Entities.Diets;

namespace Yaz�l�mMimarisi.Models.Entities.Persons {
    public class Patient : Person {
        public string DietId { get; set; }
        public string DieticianId { get; set; }
        public List<string> DiseaseIds { get; set; }
    }
}
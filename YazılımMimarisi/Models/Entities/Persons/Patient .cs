using System.Collections.Generic;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Entities.Diets;

namespace YazılımMimarisi.Models.Entities.Persons {
    public class Patient : Person {
        public string DietId { get; set; }
        public string DieticianId { get; set; }
        public List<string> DiseaseIds { get; set; }
    }
}
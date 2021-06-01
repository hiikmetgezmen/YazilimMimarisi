using System.Collections.Generic;
using YazýlýmMimarisi.Models.Common;
using YazýlýmMimarisi.Models.Entities.Diets;

namespace YazýlýmMimarisi.Models.Entities.Persons {
    public class Patient : Person {
        public string DietId { get; set; }
        public string DieticianId { get; set; }
        public List<string> DiseaseIds { get; set; }
    }
}
using System.Collections.Generic;
using YazılımMimarisi.Models.Common;

namespace YazılımMimarisi.Models.Entities.Diets {
    public class DietMethod : EntityBase {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> FoodIds { get; set; }
    }
}
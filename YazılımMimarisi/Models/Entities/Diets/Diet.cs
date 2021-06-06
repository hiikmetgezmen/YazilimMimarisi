using System;
using System.Collections.Generic;
using YazılımMimarisi.Models.Common;

namespace YazılımMimarisi.Models.Entities.Diets {
    public class Diet : EntityBase {

        public string DietMethodId { get; set; }

        public List<string> DietFoodList { get; set; }

        //* Başlangıç tarihi şuandan daha önce bir tarihe atanamaz
        public DateTime StartDate {
            get;
            set;
        }
        //* Bitiş tarihi Başlangıç tarihinden daha önce bir tarihe atanamaz
        public DateTime EndDate {
            get;
            set;
        }

    }
}
using YazılımMimarisi.Models.Common.Enums;

namespace YazılımMimarisi.Models.Common {

    /*
     *   her insan varlığının temel olarak alması gereken sınıf
     */
    public class Person : EntityBase {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; } //* string IDNumber: Ulusal kimlik numarası Global olsun diye TC demedim ama mantık aynı 
        public Sex Sex { get; set; } //* Sex Sex: Cinsiyet enumu tipinde cinsiyet bilgisi
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public Contact Contact { get; set; }
    }
}
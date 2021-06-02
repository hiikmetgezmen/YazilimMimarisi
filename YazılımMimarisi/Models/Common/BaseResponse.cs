using System.Collections.Generic;
using YazılımMimarisi.Models.Common.Enums;

namespace YazılımMimarisi.Models.Common {

    //* Tüm Entity base objelerinin ortak bir şekilde dönmeleri için yaptım
    public class BaseResponse<T> where T : EntityBase {
        public string ReponseName { get; set; }
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public List<T> Content { get; set; }
    }
}
namespace YazılımMimarisi.Models.Common.Enums {
    public class ResponseType {
        //* Enum kullanımı gibi string kullanımı bknz:https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp?page=1&tab=votes#tab-top
        private ResponseType (string value) { Value = value; }
        public string Value { get; set; }
        public static ResponseType Success { get { return new ResponseType (nameof (Success)); } }
        public static ResponseType Info { get { return new ResponseType (nameof (Info)); } }
        public static ResponseType Warning { get { return new ResponseType (nameof (Warning)); } }
        public static ResponseType Error { get { return new ResponseType (nameof (Error)); } }
    }
}
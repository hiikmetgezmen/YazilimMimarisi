namespace YazılımMimarisi.Models.Common.Enums {
    public class ResponseStatus {
        //* Enum kullanımı gibi string kullanımı bknz:https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp?page=1&tab=votes#tab-top
        public ResponseStatus(string value) { Value = value; }
        public string Value { get; set; }
        public static ResponseStatus Success { get { return new ResponseStatus(nameof (Success)); } }
        public static ResponseStatus Info { get { return new ResponseStatus(nameof (Info)); } }
        public static ResponseStatus Warning { get { return new ResponseStatus(nameof (Warning)); } }
        public static ResponseStatus Error { get { return new ResponseStatus(nameof (Error)); } }
    }
}
public class Symbol {
    public int ID { get; set; }
    public string Ascii { get; set; }

    public Symbol(int iD, string ascii) {
        ID = iD;
        Ascii = ascii;
    }

        public Symbol(string ascii) {
        Ascii = ascii;
    }
}
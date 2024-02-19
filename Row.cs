public class Row
{

    // column value for each row
    public string Column1 { get; set; }
    public string Column2 { get; set; }
    public string Column3 { get; set; }
    public string Column4 { get; set; }
    public string Column5 { get; set; }

    public Row(string col1, string col2, string col3, string col4, string col5)
    {
        Column1 = col1;
        Column2 = col2;
        Column3 = col3;
        Column4 = col4;
        Column5 = col5;
    }

    public override string ToString ()
    {
        return
            Column1 + Column2 + Column3 + Column4 + Column5;
    }


}
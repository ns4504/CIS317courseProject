using System.Data.SQLite;
using System.Collections.Generic;

public class SymbolDb
{
    // Properties
    public string Ascii { get; set; }

    // Constructors
    public SymbolDb(string ascii)
    {
        Ascii = ascii;
    }

    // Methods
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
        "CREATE TABLE IF NOT EXISTS Symbols (\n"
        + " ID integer PRIMARY KEY\n"
        + " ,Ascii varchar(1))";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static void AddSymbol(SQLiteConnection conn, Symbol s)
    {
        string sql = string.Format(
            "INSERT INTO Symbols(Ascii) "
            + "VALUES('{0}')",
            s.Ascii);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<Symbol> GetAllSymbols(SQLiteConnection conn)
    {
        List<Symbol> symbols = new List<Symbol>();
        string sql = "SELECT * FROM Symbols";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            symbols.Add(new Symbol(
                rdr.GetInt32(0), // Assuming ID is stored in the first column
                rdr.GetString(1) // Assuming Ascii is stored in the second column
            ));
        }

        return symbols;
    }

    public static SymbolDb GetSymbol(SQLiteConnection conn, int id)
    {
        string sql = string.Format("SELECT * FROM Symbols WHERE ID = {0}", id);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
        {
            return new SymbolDb(
                rdr.GetString(1) // Assuming Ascii is stored in the second column
            );
        }
        else
        {
            return new SymbolDb(string.Empty);
        }
    }

    public static string MapNumberToAscii(SQLiteConnection conn, int numericValue)
    {
        // Initialize result variable to a default value or handle null case
        string result = "Default Value";

        // Your existing code to retrieve ASCII symbols from the database
        SymbolDb symbol = GetSymbol(conn, numericValue);
        if (symbol != null)
        {
            result = symbol.Ascii;
        }
        else
        {
            // Handle the case where symbol is null, perhaps by providing a default ASCII symbol
            result = "Default ASCII Symbol";
        }

        // Convert result to string (might not be necessary if result is already a string)
        return result;
    }

    }

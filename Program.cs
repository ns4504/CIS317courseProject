using System;
using System.Data.SQLite;
using System.Collections.Generic;

public class ArtProject
{
    public static void Main(string[] args)
    {
        // Set the console output encoding to UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        const string dbName = "nathanSymbols.db";
        Console.WriteLine("Nathan Scott - Course Project");
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

        if (conn != null)
        {
            SymbolDb.CreateTable(conn);

            // Add every symbol
            SymbolDb.AddSymbol(conn, new Symbol("■"));
            SymbolDb.AddSymbol(conn, new Symbol("□"));
            SymbolDb.AddSymbol(conn, new Symbol("┌"));
            SymbolDb.AddSymbol(conn, new Symbol("┘"));
            SymbolDb.AddSymbol(conn, new Symbol("└"));
            SymbolDb.AddSymbol(conn, new Symbol("┐"));
            SymbolDb.AddSymbol(conn, new Symbol("│"));
            SymbolDb.AddSymbol(conn, new Symbol("─"));
            SymbolDb.AddSymbol(conn, new Symbol("┼"));
            SymbolDb.AddSymbol(conn, new Symbol("┴"));
            SymbolDb.AddSymbol(conn, new Symbol("├"));
            SymbolDb.AddSymbol(conn, new Symbol("╣"));
            SymbolDb.AddSymbol(conn, new Symbol("║"));
            SymbolDb.AddSymbol(conn, new Symbol("╗"));
            SymbolDb.AddSymbol(conn, new Symbol("╝"));
            SymbolDb.AddSymbol(conn, new Symbol("╚"));
            SymbolDb.AddSymbol(conn, new Symbol("╔"));
            SymbolDb.AddSymbol(conn, new Symbol("╩"));
            SymbolDb.AddSymbol(conn, new Symbol("╦"));
            SymbolDb.AddSymbol(conn, new Symbol("╠"));
            SymbolDb.AddSymbol(conn, new Symbol("═"));
            SymbolDb.AddSymbol(conn, new Symbol("╬"));

            // Print symbols only if they have both ID and Symbol labels
            Console.WriteLine("All Symbols in the Database:");
            var symbols = SymbolDb.GetAllSymbols(conn);
            foreach (var symbol in symbols)
            {
                if (!string.IsNullOrEmpty(symbol.Ascii))
                {
                    Console.WriteLine($"ID: {symbol.ID}, Symbol: {symbol.Ascii}");
                }
            }
        }

        // create a grid to hold the rows
        var grid = new Grid();

        // create & add default rows
        Console.WriteLine("\n\n\n");
        var row1 = new Row("■", "■", "■", "■", "■");
        grid.Rows.Add(row1);
        var row2 = new Row("■", "■", "■", "■", "■");
        grid.Rows.Add(row2);
        var row3 = new Row("■", "■", "■", "■", "■");
        grid.Rows.Add(row3);
        var row4 = new Row("■", "■", "■", "■", "■");
        grid.Rows.Add(row4);
        var row5 = new Row("■", "■", "■", "■", "■");
        grid.Rows.Add(row5);

        bool continueEditing = true;

        while (continueEditing)
        {
            // Default Grid Displayed
            DisplayGrid(grid);

            // Ask user for row number to alter
            Console.WriteLine("\nEnter row number (1-5) or enter -1 to stop editing: ");
            string? rowInput = Console.ReadLine();
            if (rowInput == "-1")
            {
                continueEditing = false;
                break;
            }

            if (!int.TryParse(rowInput, out int rowNum) || rowNum < 1 || rowNum > 5)
            {
                Console.WriteLine("Invalid input. Please enter a valid row number between 1 and 5.");
                continue;
            }

            // Ask user for column number to alter
            Console.WriteLine("Enter column number (1-5): ");
            string? colInput = Console.ReadLine();

            if (!int.TryParse(colInput, out int colNum) || colNum < 1 || colNum > 5)
            {
                Console.WriteLine("Invalid input. Please enter a valid column number between 1 and 5.");
                continue;
            }

            // Ask user for what symbol they want
            Console.WriteLine("Enter the number for the symbol (or direct letter/symbol) you want to use: ");
            string? newValue = Console.ReadLine();

        // Check if the input is numeric
        if (int.TryParse(newValue, out int numericValue))
        {
            // Ensure conn is not null before calling MapNumberToAscii
            if (conn != null)
            {
                // Map certain numbers to ASCII symbols
                newValue = SymbolDb.MapNumberToAscii(conn, numericValue);
            }
            else
            {
                // Handle the case where conn is null, perhaps by providing a default ASCII symbol
                newValue = "Default ASCII Symbol";
            }
        }


            if (!string.IsNullOrEmpty(newValue))
            {
                // newValue is not null or empty, proceed with updating the grid
                UpdateGrid(grid, rowNum - 1, colNum - 1, newValue);
            }
            else
            {
                Console.WriteLine($"No ASCII symbol defined for input: {newValue}");
            }
        }

        Console.WriteLine("Editing complete. Final grid:");
        DisplayGrid(grid);
    }

    public static void PrintSymbols(List<SymbolDb> symbols)
    {
        foreach (var symbol in symbols)
        {
            Console.WriteLine(symbol.Ascii);
        }
    }

    // Method to display the grid
    private static void DisplayGrid(Grid grid)
    {
        foreach (var row in grid.Rows)
        {
            Console.WriteLine(row.ToString());
        }
    }

    // Method to update the grid with new value at specified row and column
    private static void UpdateGrid(Grid grid, int rowIndex, int colIndex, string newValue)
    {
        if (rowIndex >= 0 && rowIndex < grid.Rows.Count && colIndex >= 0 && colIndex < 5)
        {
            var rowToUpdate = grid.Rows[rowIndex];
            switch (colIndex)
            {
                case 0:
                    rowToUpdate.Column1 = newValue;
                    break;
                case 1:
                    rowToUpdate.Column2 = newValue;
                    break;
                case 2:
                    rowToUpdate.Column3 = newValue;
                    break;
                case 3:
                    rowToUpdate.Column4 = newValue;
                    break;
                case 4:
                    rowToUpdate.Column5 = newValue;
                    break;
                default:
                    break;
            }
        }
    }
}
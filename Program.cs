/*******************************************************************
* Name: Nathan Scott
* Date: 02.11.2024
* Assignment: CIS317 Project Class Implementation
*
* Main application class.
*/
public class ArtProject
{
    public static void Main(string[] args)
    {
        // Set the console output encoding to UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Label Header
        Console.WriteLine("Nathan Scott - Course Project");
        Console.WriteLine("As of now, there are only 10 options (0-9) to choose from, in the future there will be more once I connect a database.");
        Console.WriteLine("You can also use letters and numbers found on the keyboard by default! \n.");

        // create a grid to hold the rows
        var grid = new Grid();

        // create & add default rows
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
        
        // this shows every option to the user
        Dictionary<int, string> symbols = new Dictionary<int, string>
        {
            { 0, "■" },
            { 1, "□" },
            { 2, "█" },
            { 3, "┌" },
            { 4, "┐" },
            { 5, "└" },
            { 6, "┘" },
            { 7, "│" },
            { 8, "─" },
            { 9, "┼ \n" }
        };
        Console.WriteLine("Possible Symbols:");
        foreach (var sym in symbols)
        {
            Console.WriteLine($"{sym.Key}: {sym.Value}");
        }


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

            int rowNum;
            if (!int.TryParse(rowInput, out rowNum) || rowNum < 1 || rowNum > 5)
            {
                Console.WriteLine("Invalid input. Please enter a valid row number between 1 and 5.");
                continue;
            }

            // Ask user for column number to alter
            Console.WriteLine("Enter column number (1-5): ");
            string? colInput = Console.ReadLine();

            int colNum;
            if (!int.TryParse(colInput, out colNum) || colNum < 1 || colNum > 5)
            {
                Console.WriteLine("Invalid input. Please enter a valid column number between 1 and 5.");
                continue;
            }

            // Ask user for what symbol they want
            Console.WriteLine("Enter the number for the symbol(or direct letter/symbol) you want to use: ");
            string? newValue = Console.ReadLine();

            // Check if the input is numeric
            if (int.TryParse(newValue, out int numericValue))
            {
                // Map certain numbers to ASCII symbols
                switch (numericValue)
                {
                    case 0:
                        newValue = "■";
                        break;
                    case 1:
                        newValue = "□"; 
                        break;
                    case 2:
                        newValue = "█"; 
                        break;
                    case 3:
                        newValue = "┌";
                        break;
                    case 4:
                        newValue = "┐";
                        break;
                    case 5:
                        newValue = "└";
                        break;
                    case 6:
                        newValue = "┘";
                        break;
                    case 7:
                        newValue = "│";
                        break;
                    case 8:
                        newValue = "─";
                        break;
                    case 9:
                        newValue = "┼";
                        break;
                    default:
                        Console.WriteLine($"No ASCII symbol defined for number {numericValue}");
                        break;
                }
            }

            if (!string.IsNullOrEmpty(newValue))
            {
                // newValue is not null or empty, proceed with updating the grid
                UpdateGrid(grid, rowNum - 1, colNum - 1, newValue);
            }
            else
            {
                // Handle the case where newValue is null or empty, perhaps by providing a default value or displaying an error message
            }
        }

        Console.WriteLine("Editing complete. Final grid:");
        DisplayGrid(grid);
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

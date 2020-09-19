
/**
 * Makes a 2d array of tiles for the dungeon level.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Board
{
    // instance variables 
    Tile[][] layout;
    
    /**
     * Constructor for objects of class Map
     */
    public Board(int columns, int rows)
    {
        init(columns, rows);
    }
    
    public void init(int col, int row)
    {
        // initialise instance variables
        layout = new Tile[row][col];
        for(int index = 0; index < row; index++)
        {
            for(int jindex = 0; jindex < col; jindex++)
            {
                layout[index][jindex] = new Tile();
            }
        }
    }
    
    public Tile[][] getLayout()
    {
        return layout;
    }
}

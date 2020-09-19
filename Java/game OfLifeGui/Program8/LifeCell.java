
/**
 * Write a description of class LifeCell here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.awt.geom.*;


public class LifeCell extends JPanel implements MouseListener
{
    private LifeCell[][] board;
    private boolean alive;
    private int row, col;
    private int count;

    
    public LifeCell(LifeCell[][] b, int r, int c)
    {
        board = b;
        row = r;
        col = c;
        alive = false;
        count = 0;
        this.addMouseListener(this);
    }
    
    public void countNeighbors()
    {
        count = 0;
        if(row+1 < 8)
        {
            if(board[row +1 ][col].isAlive() == true)
            {
                count += 1;
            }
            if(col-1 >= 0)
            {
                if(board[row + 1][col - 1].isAlive() == true)
                {
                    count += 1;
                }
            }
            if(col+1 < 8 )
            {
                if(board[row + 1][col + 1].isAlive() == true)
                {
                    count += 1;
                }
            }
        }

        if(col-1 >= 0 && row < 8)
        {
            if(board[row][col - 1].isAlive() == true)
            {
                count += 1;
            }
        }
        if(col + 1 < 8)
        {
            if(board[row][col + 1].isAlive() == true)
            {
                count += 1;
            }
        }

        if(row - 1 >= 0 && col < 8)
        {
            if(col -1 >= 0 && row < 10)
            {
                if(board[row - 1][col - 1].isAlive() == true)
                {
                      count += 1;
                }
            }
             if(col + 1 < 8)
            {
                if(board[row - 1][col + 1].isAlive() == true)
                {
                    count += 1;
                }
            }
             if(board[row -1][col].isAlive() == true)
            {
                  count += 1;
            }
        }
          
        
    }
    
    public void updateState()
    {
        if (isAlive() == true  && (count > 3 || count < 2))
        {
            toggle();
        }
       
        if(isAlive() == false && count == 3)
        {
            toggle();
        }

    }
    
    public void paintComponent (Graphics gr)
    {
        Graphics2D g = (Graphics2D) gr;
        int width = 35; int length = 35;
        super.paintComponent(g);

        if(isAlive() == false)
        {
            setBackground(Color.YELLOW);
        }
        if(isAlive() == true)
        {
            setBackground(Color.BLUE);
        }
    }
    
    
    public boolean isAlive()
    {
        return alive;
    }
    
    public void toggle()
    {
        alive = ! alive;
        this.repaint();
    }
    
    public void mousePressed(MouseEvent event)
    {
        toggle();
    }
    
    public void mouseReleased(MouseEvent event) {}
    public void mouseClicked(MouseEvent event){}
    public void mouseEntered(MouseEvent event) {}
    public void mouseExited(MouseEvent event ) {}
    
}


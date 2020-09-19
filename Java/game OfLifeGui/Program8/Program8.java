
/**
 * Write a description of class Program8 here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.awt.geom.*;

public class Program8 extends JPanel implements ActionListener
{
    private LifeCell[][] board;
    private JButton next;
    private JFrame frame;
    
    public static void main(String[] args)
    {
        new Program8();
    }
    public Program8()
    {
        frame = new JFrame("Game Of Life"); 
        frame.setContentPane(this);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.init();
        frame.pack();
        frame.setVisible(true);        
    }
    
    public void init()
    {
        final int WIDTH = 43;
        final int HEIGHT = 43;
        int row, col;
        board = new LifeCell[8][8];
        this.setPreferredSize(new Dimension (410, 450));
        this.setBackground(Color.PINK);
        this.setLayout(null);
        for(row = 0;row < 8; ++row)
        {
            for (col = 0;col < 8; ++col)
            {
                board[row][col] = new LifeCell(board,row,col);  
                board[row][col].setBounds( (50 * row) + 6, (50  * col) + 5, WIDTH, HEIGHT);
                this.add(board[row][col]);
                board[row][col].setBackground(Color.YELLOW);

               
            }
            
        }
        
        next = new JButton("Next");
        next.addActionListener(this);
        next.setBounds(125,410, 120,25);
        this.add(next);

    }
    
    public void actionPerformed(ActionEvent event)
    {
        int row, col;
        for(row = 0; row < 8; ++row)
        {
            for(col = 0; col < 8; ++col)
            {
                board[row][col].countNeighbors();
            }
        }
        
        for(row = 0; row < 8; ++row)
        {
            for(col = 0; col < 8; ++col)
            {
                board[row][col].updateState();
            }
        }
    }
}

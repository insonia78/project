using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using WpfApplication2;
namespace System.Windows.Forms
{
    public partial class Tyle : System.Windows.Forms.UserControl
    {

        public static readonly Color ActiveSquareBackColorDefault = Color.FromArgb(0, 224, 0);
        public static readonly Color MoveIndicatorColorDefault = Color.Red;
        public static readonly Color NormalBackColorDefault = Color.Green;
        public static readonly Color NormalBackColorDefault1 = Color.Blue;
        public static readonly Color ValidMoveBackColorDefault = Color.FromArgb(0, 176, 0);

        // Colors used in rendering the control.
        public static Color ActiveSquareBackColor = ActiveSquareBackColorDefault;
        public static Color MoveIndicatorColor = MoveIndicatorColorDefault;
        public static Color NormalBackColor = NormalBackColorDefault;
        public static Color NormalBackColor1 = NormalBackColorDefault1;
        public static Color ValidMoveBackColor = ValidMoveBackColorDefault;

        // This represents the contents of the square, see the values defined
        // in the Board class.
        public int Contents;
        public int PreviewContents;

        
        // These are used to set highlighting.
        public bool IsValid = false;
        public bool IsActive = false;
        public bool IsNew = false;

        // Used for animation.
        

        // Default color values.
        
        // These reflect the position of the square on the board.
        public int Row
        {
            get { return this.row; }
            set { row = value; }
        }
        public int Col
        {
            get { return this.col; }
            set { col = value; }
        }

        // These reflect the public row and column properties.
        private int row;
        private int col;

        // Drawing tools.
        private static Pen pen = new Pen(Color.Black);
        private static SolidBrush solidBrush = new SolidBrush(Color.Black);
        private static GraphicsPath path = new GraphicsPath();
        private static PathGradientBrush gradientBrush;
        public Tyle()
        {
            InitializeComponent();
            
            
                this.BackColor = Tyle.NormalBackColor;
            
            

            

            // Redraw the control on a resize.
            this.ResizeRedraw = true;

            // Set double-buffering to prevent flicker when drawing the control.
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
        public static Color AdjustBrightness(Color color, double m)
        {
            int r = (int)Math.Max(0, Math.Min(255, Math.Round((double)color.R * m)));
            int g = (int)Math.Max(0, Math.Min(255, Math.Round((double)color.G * m)));
            int b = (int)Math.Max(0, Math.Min(255, Math.Round((double)color.B * m)));

            return Color.FromArgb(r, g, b);
        }
       
        private void Tyle_Paint(object sender, PaintEventArgs e)
        {
            Color backColor = NormalBackColor;    
            if (this.IsValid)
                backColor = ValidMoveBackColor;
            if (this.IsActive)
                backColor = ActiveSquareBackColor;

            // e.Graphics.Clear(backColor);

            // Set drawing options.
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the border.
            System.Drawing.Point topLeft = new System.Drawing.Point(0, 0);
            System.Drawing.Point topRight = new System.Drawing.Point((int)(Width - 1), 0);
            System.Drawing.Point bottomLeft =  new System.Drawing.Point(0, (int)(Height - 1));
            System.Drawing.Point bottomRight = new System.Drawing.Point((int)(Width - 1), (int)(Height - 1));
            pen.Color = AdjustBrightness(backColor, 1.5);
            pen.Width = 1;
            e.Graphics.DrawLine(pen, bottomLeft, topLeft);
            e.Graphics.DrawLine(pen, topLeft, topRight);
            pen.Color = AdjustBrightness(backColor, 0.6);
            e.Graphics.DrawLine(pen, bottomLeft, bottomRight);
            e.Graphics.DrawLine(pen, bottomRight, topRight);
            //            e.Graphics;

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

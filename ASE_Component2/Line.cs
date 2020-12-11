using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component2
{
    /// <summary>
    /// Class for Line which is a child class of shape
    /// </summary>
    /// <param name="penSize">Defines shapes borders width</param>
    /// <param name="penColor">Defines border color</param
    class Line : Shape
    {
        Point[] points;
        int penSize = 2;
        Color penColor = Color.Black;

        public Line() : base()
        {
        }
        /// <summary>
        /// Constructor of class Line
        /// </summary>
        /// <param name="colour">color of line</param>
        /// <param name="x">coordinates</param>
        /// <param name="y">coordinates</param>
        public Line(Color colour, int x, int y) : base(colour, x, y)
        {
        }
        /// <summary>
        /// Overriding method of parent class that passes all the values for the shape 
        /// </summary>
        /// <param name="colour">Shape color</param>
        /// <param name="list">array fo integers to hold users input values for coordinates, pen size and pen color</param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            points = new Point[2];
            points[0] = new Point(list[0], list[1]);
            points[1] = new Point(list[2], list[3]);

            this.penSize = list[4];
            //penColor 1 = Black, 2 = Blue, 3 = Green, 4 = Red, 5 = Yellow
            if (list[5] == 1) { this.penColor = Color.Black; }
            if (list[5] == 2) { this.penColor = Color.Blue; }
            if (list[5] == 3) { this.penColor = Color.Green; }
            if (list[5] == 4) { this.penColor = Color.Red; }
            if (list[5] == 5) { this.penColor = Color.Yellow; }
        }
        /// <summary>
        /// Overriding graphic method from parent class and drawing a circle
        /// </summary>
        /// <param name="g">Has graphics context of form</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(penColor, penSize);
            SolidBrush b = new SolidBrush(colour);
            g.DrawLine(p, points[0], points[1]);
        }

        public override double calcArea()
        {
            //Line is a single dimension. Hence, it does not have area
            return 0;
        }

        public override double calcPerimeter()
        {
            //Perimeter of Line is its Length
            double x1 = points[0].X;
            double y1 = points[0].Y;
            double x2 = points[1].X;
            double y2 = points[1].Y;

            double side1 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return side1;
        }

        public override string ToString() //all classes inherit from object and ToString() is abstract in object
        {
            return base.ToString() + "  ";
        }
    }
}

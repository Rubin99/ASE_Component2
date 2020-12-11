using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component2
{
    /// <summary>
    /// Class for triangle which is a child class of shape
    /// </summary>
    /// <param name="points">Array for the coordinates of the tringles vertices</param>
    /// <param name="penSize">Defines shapes borders width</param>
    /// <param name="penColor">Defines border color</param>
    /// <param name="fillColor">booloen for filling the shape or not</param>
    class Triangle : Shape
    {
        Point[] points;
        int penSize = 2;
        Color penColor = Color.Black;
        bool fillColor = false;

        public Triangle() : base()
        {
        }
        /// <summary>
        /// Constructor of Triangle class
        /// </summary>
        /// <param name="colour">Color of Triangle(fill)</param>
        /// <param name="x">initial x coordinate</param>
        /// <param name="y">initial y coordinate</param>
        /// <param name="lftX">secondary x coordinate</param>
        /// <param name="lftY">secondary y coodrinate</param>
        /// <param name="rtX">third x coordinate</param>
        /// <param name="rtY">third y coordinate</param>
        public Triangle(Color colour, int x, int y, int lftX, int lftY, int rtX, int rtY) : base(colour, x, y)
        {
        }
        /// <summary>
        /// Overriding method of parent class that passes all the values for the shape 
        /// </summary>
        /// <param name="colour">Shape color</param>
        /// <param name="list">array for integers to hold users input values for coordinates, pen size and pen color</param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            points = new Point[3];
            points[0] = new Point(list[0], list[1]);
            points[1] = new Point(list[2], list[3]);
            points[2] = new Point(list[4], list[5]);

            this.penSize = list[6];
            //penColor 1 = Black, 2 = Blue, 3 = Green, 4 = Red, 5 = Yellow
            if (list[7] == 1) { this.penColor = Color.Black; }
            if (list[7] == 2) { this.penColor = Color.Blue; }
            if (list[7] == 3) { this.penColor = Color.Green; }
            if (list[7] == 4) { this.penColor = Color.Red; }
            if (list[7] == 5) { this.penColor = Color.Yellow; }

            if (list[8] == 1) { this.fillColor = true; }
            if (list[8] == 2) { this.fillColor = false; }
        }
        /// <summary>
        /// Overriding graphic method from parent class and drawing a triangle
        /// </summary>
        /// <param name="g">Has graphics context of form</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(penColor, penSize);
            SolidBrush b = new SolidBrush(colour);

            g.DrawPolygon(p, points);
            if (fillColor) { g.FillPolygon(b, points); }
        }

        public override double calcArea()
        {
            double x1 = points[0].X;
            double y1 = points[0].Y;
            double x2 = points[1].X;
            double y2 = points[1].Y;
            double x3 = points[2].X;
            double y3 = points[2].Y;

            return (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2;
        }

        public override double calcPerimeter()
        {
            double x1 = points[0].X;
            double y1 = points[0].Y;
            double x2 = points[1].X;
            double y2 = points[1].Y;
            double x3 = points[2].X;
            double y3 = points[2].Y;

            double side1 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            double side2 = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
            double side3 = Math.Sqrt((x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3));

            return side1 + side2 + side3;
        }
    }
}

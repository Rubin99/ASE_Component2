using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component2
{
    /// <summary>
    /// Class for making Rectagle. Child class of Shape
    /// </summary>
    /// <param name="width">User input of rectangles width</param>
    /// <param name="height">User input of rectangles height</param>
    /// <param name="penSize">Defines shapes borders width</param>
    /// <param name="penColor">Defines border color</param>
    /// <param name="fillColor">booloen for filling the shape or not</param>
    class Rectangle : Shape
    {
        int width, height;
        int penSize = 2;
        Color penColor = Color.Black;
        bool fillColor = false;

        public Rectangle() : base()
        {
            width = 100;
            height = 100;
        }
        /// <summary>
        /// Constructor of class Rectangle
        /// </summary>
        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {
            this.width = width; //the only thingthat is different from shape
            this.height = height;
        }
        /// <summary>
        /// Overriding method of parent class that passes all the values for the shape
        /// </summary>
        /// <param name="colour">Shape color</param>
        /// <param name="list">array fo integers to hold users input values for coordinates, pen size and pen color</param>
        public override void set(Color colour, params int[] list)
        {            
            base.set(colour, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];

            this.penSize = list[4];

            if (list[5] == 1) { this.penColor = Color.Black; }
            if (list[5] == 2) { this.penColor = Color.Blue; }
            if (list[5] == 3) { this.penColor = Color.Green; }
            if (list[5] == 4) { this.penColor = Color.Red; }
            if (list[5] == 5) { this.penColor = Color.Yellow; }

            if (list[6] == 1) { this.fillColor = true; }
            if (list[6] == 2) { this.fillColor = false; }
        }
        /// <summary>
        /// Overriding graphic method from parent class and drawing a rectangle
        /// </summary>
        /// <param name="g">Has graphics context of form</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(penColor, penSize);
            SolidBrush b = new SolidBrush(colour);
            g.DrawRectangle(p, x, y, width, height);
            if (fillColor) { g.FillRectangle(b, x, y, width, height); }
        }
        /// <summary>
        /// For calculating area
        /// </summary>
        /// <returns>Area of rectangle</returns>
        public override double calcArea()
        {
            return width * height;
        }
        /// <summary>
        /// For calculating Perimeter
        /// </summary>
        /// <returns>Perimeter of </returns>
        public override double calcPerimeter()
        {
            return 2 * width + 2 * height;
        }
    }
}

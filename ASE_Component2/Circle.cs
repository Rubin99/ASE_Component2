using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASE_Component2
{
    /// <summary>
    /// Class for circle which is a child class of shape
    /// </summary>
    /// <param name="penSize">Defines shapes borders width</param>
    /// <param name="penColor">Defines border color</param>
    /// <param name="fillColor">booloen for filling the shape or not</param>
    class Circle : Shape
    {
        int radius;
        int penSize = 2;
        Color penColor = Color.Black;
        bool fillColor = false;

        public Circle() : base()
        {

        }
        /// <summary>
        /// Constructor of class circle
        /// </summary>
        /// <param name="colour">for fill color of circle</param>
        /// <param name="x">coordinate</param>
        /// <param name="y">coordinate</param>
        /// <param name="radius">radius of the circle</param>
        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            this.radius = radius; //the only thingthat is different from shape
        }

        /// <summary>
        /// Overriding method of parent class that passes all the values for the shape 
        /// </summary>
        /// <param name="colour">Shape color</param>
        /// <param name="list">array fo integers to hold users input values for coordinates, pen size and pen color</param>
        public override void set(Color colour, params int[] list)
        {
            
            base.set(colour, list[0], list[1]);
            this.radius = list[2];

            int numList = list.Count();
            if (numList == 6)
            {
                this.penSize = list[3];
                //penColor 1 = Black, 2 = Blue, 3 = Green, 4 = Red, 5 = Yellow
                if (list[4] == 1) { this.penColor = Color.Black; }
                if (list[4] == 2) { this.penColor = Color.Blue; }
                if (list[4] == 3) { this.penColor = Color.Green; }
                if (list[4] == 4) { this.penColor = Color.Red; }
                if (list[4] == 5) { this.penColor = Color.Yellow; }

                if (list[5] == 1) { this.fillColor = true; }
                if (list[5] == 2) { this.fillColor = false; }
            }

        }
        /// <summary>
        /// Overriding graphic method from parent class and drawing a circle
        /// </summary>
        /// <param name="g">Has graphics context of form</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(penColor, penSize);
            SolidBrush b = new SolidBrush(colour);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);
            if (fillColor) { g.FillEllipse(b, x, y, radius * 2, radius * 2); }
        }

        public override double calcArea()
        {
            return Math.PI * (radius ^ 2);
        }

        public override double calcPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString() //all classes inherit from object and ToString() is abstract in object
        {
            return base.ToString() + "  " + this.radius; // not used
        }
    }
}



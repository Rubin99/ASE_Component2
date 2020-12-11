using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component2
{
    /// <summary>
    /// Interface for the program
    /// </summary>
    interface Shapes
    {
        /// <summary>
        /// Setting up methods to be inherited by its child classes
        /// </summary>
        /// <param name="c"> For shape color</param>
        /// <param name="list">array to hold values of variables</param>
        void set(Color c, params int[] list);
        void draw(Graphics g);
        double calcArea();
        double calcPerimeter();
    }
}

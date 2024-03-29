﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component2
{
    /// <summary>
    /// Abstract class shape that inherists from the interface class and is the parent class to all the other shape classes.
    /// </summary>
    abstract class Shape : Shapes
    {
        protected Color colour; //shape's colour
        protected int x, y; //not I could use c# properties for this
        public Shape()
        {
            colour = Color.Red;
            x = y = 100;
        }
        /// <summary>
        /// Connstructor for shape class.
        /// </summary>
        /// <param name="colour">Color of shape</param>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>

        public Shape(Color colour, int x, int y)
        {

            this.colour = colour; //shape's colour
            this.x = x; //its x pos
            this.y = y; //its y pos
            //can't provide anything else as "shape" is too general
        }

        //the three methods below are from the Shapes interface
        //here we are passing on the obligation to implement them to the derived classes by declaring them as abstract
        public abstract void draw(Graphics g); //any derrived class must implement this method
        public abstract double calcArea();
        public abstract double calcPerimeter();

        //set is declared as virtual so it can be overridden by a more specific child version
        //but is here so it can be called by that child version to do the generic stuff
        //note the use of the param keyword to provide a variable parameter list to cope with some shapes having more setup information than others
        public virtual void set(Color colour, params int[] list)
        {
            this.colour = colour;
            this.x = list[0];
            this.y = list[1];
        }


        public override string ToString()
        {
            return base.ToString() + "    " + this.x + "," + this.y + " : ";
        }

    }
}

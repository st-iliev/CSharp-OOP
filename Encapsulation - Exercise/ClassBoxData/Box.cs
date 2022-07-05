using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length,double width,double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double SurfaceArea()
        {
            return 2 * ((length * width) + (width * height) + (length * height));
        }
        public double  Volume()
        {
            return height * width * length;
        }
        public double LateralSurfaceArea()
        {
            return (2 * (length + width)) * height;
        }
        public override string ToString()
        {
            return $"Surface Area - {SurfaceArea():F2}\nLateral Surface Area - {LateralSurfaceArea():F2}\nVolume - {Volume():F2}";
        }
    }
}

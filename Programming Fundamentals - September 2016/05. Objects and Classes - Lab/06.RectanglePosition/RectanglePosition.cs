namespace _06.RectanglePosition
{
    using System;
    using System.Linq;

    class Rectangle
    {
        static void Main()
        {
            RectanglePosition r1 = RectanglePosition.ReadRectangle();
            RectanglePosition r2 = RectanglePosition.ReadRectangle();

            Console.WriteLine(r1.IsInside(r2) ? "Inside" : "Not inside");
        }
    }

    class RectanglePosition
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // public int Bottom => Top + Height;
        public int Bottom
        {
            get
            {
                return Top + Height;
            }
        }

        // public int Right => Left + Width;
        public int Right
        {
            get
            {
                return Left + Width;
            }
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public static RectanglePosition ReadRectangle()
        {
            int[] points = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            RectanglePosition r = new RectanglePosition()
            {
                Left = points[0],
                Top = points[1],
                Width = points[2],
                Height = points[3]
            };

            return r;
        }

        public bool IsInside(RectanglePosition outer)
        {
            return
                outer.Left <= this.Left &&
                outer.Right >= this.Right &&
                outer.Top <= this.Top &&
                outer.Bottom >= this.Bottom;
        }

        public override string ToString()
        {
            return $"Rectangle (left = {Left}, top = {Top}, width = {Width}, height = {Height})";
        }
    }
}

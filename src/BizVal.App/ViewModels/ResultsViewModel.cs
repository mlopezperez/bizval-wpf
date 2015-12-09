using System.Collections.Generic;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ResultsViewModel : Screen
    {
        public IList<Point> Points { get; set; }

        public ResultsViewModel()
        {
            this.Points = new List<Point>();
            var point1 = new Point(2f, 2f, 4f);
            var point2 = new Point(2f, 2f, 1f);
            this.Points.Add(point1);
            this.Points.Add(point2);
        }
    }

    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float Size { get; set; }

        public Point(float x, float y, float size)
        {
            this.X = x;
            this.Y = y;
            this.Size = size;
        }
    }
}

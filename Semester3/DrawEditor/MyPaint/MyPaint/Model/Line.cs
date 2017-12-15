using System;
using System.Collections.Generic;
using System.Drawing;
using MyPaint.View;

namespace MyPaint.Model
{
    public class Line:IEqualityComparer<Line>
    {
        private Point point1;
        private Point point2;
        private bool _isSelected;
        private bool isSelectedPoint1;
        private int WightOfPen = 3;

        public bool IsDrawing() => _isSelected;

        public void EndDrawing()
        {
            _isSelected = false;
        }

        public Line Clone()
        {
            return new Line(point1, point2);
        }
        
        public Line(Point pointStart)
        {
            _isSelected = true;
            point1.X = pointStart.X;
            point1.Y = pointStart.Y;
            point2.X = pointStart.X;
            point2.Y = pointStart.Y;
            CorrectPoints();
        }
        
        public Line(Point pointStart, Point pointLast)
        {
            _isSelected = true;
            point1.X = pointStart.X;
            point1.Y = pointStart.Y;
            point2.X = pointLast.X;
            point2.Y = pointLast.Y;
            CorrectPoints();
        }

        public void Draw(BufferedGraphics bufferedGraphics, Pen pen)
        {
            bufferedGraphics.Graphics.DrawLine(pen, point1, point2);
            if (_isSelected)
            {
                DrawSelected(bufferedGraphics, pen);
            }
        }

        public void Choose()
        {
            _isSelected = true;
        }

        private void DrawSelected(BufferedGraphics bufferedGraphics, Pen pen)
        {
            bufferedGraphics.Graphics.DrawEllipse(pen, point1.X - 2, point1.Y - 2, 4, 4);
            bufferedGraphics.Graphics.DrawEllipse(pen, point2.X - 2, point2.Y - 2, 4, 4);
        }

        public void CorrectLine(Point point)
        {

            if (isSelectedPoint1)
            {
                point1 = point;
            }
            else
            {
                point2 = point;
            }
            CorrectPoints();
        }

        public bool TrySelect(int x, int y)
        {
            var distanse = Math.Abs((point2.Y - point1.Y) * x - (point2.X - point1.X) * y +
                                    point2.X * point1.Y - point2.Y * point1.X) /
                           Math.Sqrt((point2.Y - point1.Y) * (point2.Y - point1.Y) +
                                     (point2.X - point1.X) * (point2.X - point1.X));

            if (distanse < WightOfPen + 2)
            {
                _isSelected = true;
                return true;
            }
            _isSelected = false;
            return false;
        }

        public bool Equals(Line x, Line y)
        {
            if (x?.point1 == y?.point1 && x?.point2 == y?.point2)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Line obj)
        {
            throw new NotImplementedException();
        }

        public bool TryBeginMove(Point point)
        {
            var distanse = Math.Abs(Math.Pow(point1.X - point.X, 2)
                                    + Math.Pow(point1.Y - point.Y, 2));
            if (distanse < (double) WightOfPen / 2 + 4)
            {
                //_isSelected = true;
                isSelectedPoint1 = true;
                return true;
            }
            //TODO:
            distanse = Math.Abs(Math.Pow(point2.X - point.X, 2)
                                + Math.Pow(point2.Y - point.Y, 2));
            if (distanse < (double) WightOfPen / 2 + 4)
            {
                //_isSelected = true;
                isSelectedPoint1 = false;
                return true;
            }
            return false;
        }

        private void CorrectPoints()
        {
            if (point1.X < 0)
            {
                point1.X = 0;
            }
            if (point1.Y < 0)
            {
                point1.Y = 0;
            }
            if (point2.X < 0)
            {
                point2.X = 0;
            }
            if (point2.Y < 0)
            {
                point2.Y = 0;
            }
            
            if (point1.X > EditorForm.WightOfPanel)
            {
                point1.X = EditorForm.WightOfPanel;
            }
            if (point1.Y > EditorForm.HeightOfPanel)
            {
                point1.Y = EditorForm.HeightOfPanel;
            }
            if (point2.X > EditorForm.WightOfPanel)
            {
                point2.X = EditorForm.WightOfPanel;
            }
            if (point2.Y > EditorForm.HeightOfPanel)
            {
                point2.Y = EditorForm.HeightOfPanel;
            }
        }
    }
}    
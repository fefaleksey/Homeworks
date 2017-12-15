using System;
using System.Collections.Generic;
using System.Drawing;
using MyPaint.View;

namespace MyPaint.Model
{
    public class Line:IEqualityComparer<Line>
    {
        private Point _point1;
        private Point _point2;
        private bool _isSelected;
        private bool _isSelectedPoint1;
        private const int WightOfPen = 3;

        public bool IsDrawing() => _isSelected;

        public void EndDrawing()
        {
            _isSelected = false;
        }

        public Line Clone()
        {
            return new Line(_point1, _point2);
        }                
        
        public Line(Point pointStart)
        {
            _isSelected = true;
            _point1.X = pointStart.X;
            _point1.Y = pointStart.Y;
            _point2.X = pointStart.X;
            _point2.Y = pointStart.Y;
            CorrectPoints();
        }
        
        public Line(Point pointStart, Point pointLast)
        {
            _isSelected = true;
            _point1.X = pointStart.X;
            _point1.Y = pointStart.Y;
            _point2.X = pointLast.X;
            _point2.Y = pointLast.Y;
            CorrectPoints();
        }

        public void Draw(BufferedGraphics bufferedGraphics, Pen pen)
        {
            bufferedGraphics.Graphics.DrawLine(pen, _point1, _point2);
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
            bufferedGraphics.Graphics.DrawEllipse(pen, _point1.X - 2, _point1.Y - 2, 4, 4);
            bufferedGraphics.Graphics.DrawEllipse(pen, _point2.X - 2, _point2.Y - 2, 4, 4);
        }

        public void CorrectLine(Point point)
        {

            if (_isSelectedPoint1)
            {
                _point1 = point;
            }
            else
            {
                _point2 = point;
            }
            CorrectPoints();
        }

        public bool TrySelect(int x, int y)
        {
            var distanse = Math.Abs((_point2.Y - _point1.Y) * x - (_point2.X - _point1.X) * y +
                                    _point2.X * _point1.Y - _point2.Y * _point1.X) /
                           Math.Sqrt((_point2.Y - _point1.Y) * (_point2.Y - _point1.Y) +
                                     (_point2.X - _point1.X) * (_point2.X - _point1.X));

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
            if (x?._point1 == y?._point1 && x?._point2 == y?._point2)
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
            var distanse = Math.Abs(Math.Pow(_point1.X - point.X, 2)
                                    + Math.Pow(_point1.Y - point.Y, 2));
            if (distanse < (double) WightOfPen / 2 + 4)
            {
                //_isSelected = true;
                _isSelectedPoint1 = true;
                return true;
            }
            distanse = Math.Abs(Math.Pow(_point2.X - point.X, 2)
                                + Math.Pow(_point2.Y - point.Y, 2));
            if (distanse < (double) WightOfPen / 2 + 4)
            {
                //_isSelected = true;
                _isSelectedPoint1 = false;
                return true;
            }
            return false;
        }

        private void CorrectPoints()
        {
            if (_point1.X < 0)
            {
                _point1.X = 0;
            }
            if (_point1.Y < 0)
            {
                _point1.Y = 0;
            }
            if (_point2.X < 0)
            {
                _point2.X = 0;
            }
            if (_point2.Y < 0)
            {
                _point2.Y = 0;
            }
            
            if (_point1.X > EditorForm.WightOfPanel)
            {
                _point1.X = EditorForm.WightOfPanel;
            }
            if (_point1.Y > EditorForm.HeightOfPanel)
            {
                _point1.Y = EditorForm.HeightOfPanel;
            }
            if (_point2.X > EditorForm.WightOfPanel)
            {
                _point2.X = EditorForm.WightOfPanel;
            }
            if (_point2.Y > EditorForm.HeightOfPanel)
            {
                _point2.Y = EditorForm.HeightOfPanel;
            }
        }
    }
}
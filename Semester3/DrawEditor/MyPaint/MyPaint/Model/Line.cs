using System;
using System.Collections.Generic;
using System.Drawing;
using MyPaint.View;

namespace MyPaint.Model
{
    /// <summary>
    /// Line class
    /// </summary>
    public class Line : IEqualityComparer<Line>
    {
        private Point _point1;
        private Point _point2;
        private bool _isSelected;
        private bool _isSelectedPoint1;
        private const int WidthOfPen = 3;

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="point">Coordinate of first and second vertex</param>
        public Line(Point point)
        {
            _isSelected = true;
            _point1.X = point.X;
            _point1.Y = point.Y;
            _point2.X = point.X;
            _point2.Y = point.Y;
            CorrectPoints();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="point">first point</param>
        /// <param name="pointLast">second point</param>
        public Line(Point point, Point pointLast)
        {
            _isSelected = true;
            _point1.X = point.X;
            _point1.Y = point.Y;
            _point2.X = pointLast.X;
            _point2.Y = pointLast.Y;
            CorrectPoints();
        }
        
        /// <summary>
        /// End drawing
        /// </summary>
        public void EndDrawing()
        {
            _isSelected = false;
        }

        /// <summary>
        /// Draw this line
        /// </summary>
        /// <param name="bufferedGraphics">buffer</param>
        /// <param name="pen">pen</param>
        public void Draw(BufferedGraphics bufferedGraphics, Pen pen)
        {
            bufferedGraphics.Graphics.DrawLine(pen, _point1, _point2);
            if (_isSelected)
            {
                DrawSelected(bufferedGraphics, pen);
            }
        }
        
        /// <summary>
        /// Draw a selection of this line
        /// </summary>
        /// <param name="bufferedGraphics">buffer</param>
        /// <param name="pen">pen</param>
        private void DrawSelected(BufferedGraphics bufferedGraphics, Pen pen)
        {
            bufferedGraphics.Graphics.DrawEllipse(pen, _point1.X - 2, _point1.Y - 2, 4, 4);
            bufferedGraphics.Graphics.DrawEllipse(pen, _point2.X - 2, _point2.Y - 2, 4, 4);
        }

        /// <summary>
        /// Correct line
        /// </summary>
        /// <param name="point">new point</param>
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

        public void SelectLine()
        {
            _isSelected = true;
        }

        /// <summary>
        /// Try select this line
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <returns>Success or not</returns>
        public bool TrySelect(int x, int y)
        {
            var distanse = Math.Abs((_point2.Y - _point1.Y) * x - (_point2.X - _point1.X) * y +
                                    _point2.X * _point1.Y - _point2.Y * _point1.X) /
                           Math.Sqrt((_point2.Y - _point1.Y) * (_point2.Y - _point1.Y) +
                                     (_point2.X - _point1.X) * (_point2.X - _point1.X));
            
            _isSelected = distanse < WidthOfPen + 2;
            return _isSelected;
        }

        /// <summary>
        /// Try begin move this line
        /// </summary>
        /// <param name="point">Point from event</param>
        /// <returns>Success or not</returns>
        public bool TryBeginMove(Point point)
        {
            var distanse = Math.Abs(Math.Pow(_point1.X - point.X, 2)
                                    + Math.Pow(_point1.Y - point.Y, 2));
            if (distanse < (double) WidthOfPen / 2 + 4)
            {
                _isSelectedPoint1 = true;
                return true;
            }
            distanse = Math.Abs(Math.Pow(_point2.X - point.X, 2)
                                + Math.Pow(_point2.Y - point.Y, 2));
            if (distanse < (double) WidthOfPen / 2 + 4)
            {
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
        
        /// <summary>
        /// For interface IEqualityComparer
        /// </summary>
        /// <param name="x">first line</param>
        /// <param name="y">second line</param>
        /// <returns>result of compare</returns>
        public bool Equals(Line x, Line y)
        {
            return x?._point1 == y?._point1 && x?._point2 == y?._point2;
        }

        public int GetHashCode(Line obj)
        {
            throw new NotImplementedException();
        }
    }
}
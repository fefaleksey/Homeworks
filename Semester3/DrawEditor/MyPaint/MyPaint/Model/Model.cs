using System.Collections.Generic;
using System.Drawing;

namespace MyPaint.Model
{
    /// <summary>
    /// Form data
    /// </summary>
    public class Model
    {
        private readonly List<Line> _lines = new List<Line>();
        private Line _selectedLine;
        private readonly Builder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        /// <param name="builder"></param>
        public Model(Builder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Delete last line in model
        /// </summary>
        public void DeleteLastLine()
        {
            _lines.RemoveAt(_lines.Count - 1);
        }

        /// <summary>
        /// Check for empty
        /// </summary>
        /// <returns>Model is Empty or not</returns>
        public bool IsEmpty() => _lines.Count == 0;
        
        /// <summary>
        /// Add line in model
        /// </summary>
        /// <param name="line">Line which will be added</param>
        public void AddLine(Line line)
        {
            _lines.Add(line);
            _builder.Draw(_lines);
        }

        /// <summary>
        /// Delete selected line
        /// </summary>
        /// <returns>Selected line was not null or null</returns>
        public bool DeleteSelectedLine()
        {
            if (_selectedLine != null)
            {
                _lines.Remove(_selectedLine);
                _selectedLine = null;
                _builder.Draw(_lines);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get selected line
        /// </summary>
        /// <returns>Selected line</returns>
        public Line GetSelectedLine()
        {
            return _selectedLine;
        }

        /// <summary>
        /// Select line
        /// </summary>
        /// <param name="line">Line which will be selected</param>
        public void SelectLine(Line line)
        {
            _selectedLine?.EndDrawing();
            _selectedLine = line;
            _selectedLine?.SelectLine();
        }

        /// <summary>
        /// Remove line
        /// </summary>
        /// <param name="line">Line which will be removed</param>
        public void RemoveElement(Line line)
        {
            _lines.Remove(line);
            _builder.Draw(_lines);
        }

        /// <summary>
        /// Try select line
        /// </summary>
        /// <param name="x">Coordinate x</param>
        /// <param name="y">Coordinate y</param>
        /// <returns>Line was selected or not</returns>
        public bool TrySelect(int x, int y)
        {
            foreach (var line in _lines)
            {
                if (line.TrySelect(x, y))
                {
                    _selectedLine?.EndDrawing();
                    _selectedLine = line;
                    _builder.Draw(_lines);
                    return true;
                }
            }
            _selectedLine = null;
            _builder.Draw(_lines);
            return false;
        }

        /// <summary>
        /// Change selected line
        /// </summary>
        /// <param name="point">new point(coordinate)</param>
        public void CorrectSelectedLine(Point point)
        {
            _selectedLine?.CorrectLine(point);
            _builder.Draw(_lines);
        }

        /// <summary>
        /// Unselect line
        /// </summary>
        private void UnSelectLine()
        {
            _selectedLine = null;
        }

        /// <summary>
        /// End drawing line
        /// </summary>
        public void EndDrawing()
        {
            _selectedLine?.EndDrawing();
            UnSelectLine();
            _builder.Draw(_lines);
        }

        /// <summary>
        /// Begin drawing line
        /// </summary>
        /// <param name="line">Line which we will change and draw</param>
        public void BeginDrawingLine(Line line)
        {
            _selectedLine?.EndDrawing();
            _selectedLine = line;
        }

        /// <summary>
        /// Try begin move line
        /// </summary>
        /// <param name="point">Point (coordinate) of mouse in the moment of event</param>
        /// <returns>Success or not</returns>
        public bool TryBeginMoveLine(Point point)
        {
            if (_selectedLine != null && _selectedLine.TryBeginMove(point))
            {
                return true;
            }
            return false;
        }
    }
}
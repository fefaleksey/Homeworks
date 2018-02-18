using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using MyPaint.Controller.Commands;
using MyPaint.Model;

namespace MyPaint.Controller
{
    /// <summary>
    /// Form controller
    /// </summary>
    public class Controller
    {
        private readonly Model.Model _model;

        private readonly List<ICommand> _undoredolList = new List<ICommand>();
        private int _position = -1;
        private Point _startPoint;
        private bool _isDrawing;
        
        public Controller(Model.Model model)
        {
            _model = model;
        }

        /// <summary>
        /// Undo stack is empty
        /// </summary>
        public bool IsUndoEmpty => _undoredolList.Count == 0 || _position == -1;

        /// <summary>
        /// Redo stack is empty
        /// </summary>
        public bool IsRedoEmpty => _position == _undoredolList.Count - 1;
        
        /// <summary>
        /// End drawing
        /// </summary>
        /// <param name="point">Point from event</param>
        public void EndDrawing(Point point)
        {
            if (_isDrawing)
            {
                var commandAdd = new CommandAddLine(_startPoint, point);
                commandAdd.Execute(_model);
                AddCommand(commandAdd);
                _model.EndDrawing();
            }
        }

        /// <summary>
        /// Correct selected line
        /// </summary>
        /// <param name="point">new point</param>
        public void CorrectSelectedLine(Point point)
        {
            _model.CorrectSelectedLine(point);
        }

        /// <summary>
        /// Begin drawing new line
        /// </summary>
        /// <param name="point">Point from event</param>
        public void BeginDrawingLine(Point point)
        {
            _isDrawing = true;
            var line = new Line(point);
            _model.AddLine(line);
            _startPoint.X = point.X;
            _startPoint.Y = point.Y;
            _model.BeginDrawingLine(line);
        }

        /// <summary>
        /// Delete selected line
        /// </summary>
        public void Delete()
        {
            var deleteCommand = new CommandDelete();
            if (deleteCommand.Execute(_model))
            {
                AddCommand(deleteCommand);
            }
        }
        
        /// <summary>
        /// Try begin move line
        /// </summary>
        /// <param name="point">Point from event</param>
        /// <returns>success or not</returns>
        public bool TryBeginMoveLine(Point point)
        {
            if (_model.TryBeginMoveLine(point))
            {
                var line = _model.GetSelectedLine();
                if (line != null)
                {
                    //startLine = line.Clone();
                    _startPoint = point;
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// End moving
        /// </summary>
        public void EndMoving(Point point)
        {
            _model.CorrectSelectedLine(_startPoint);
            var commandMove = new CommandMoveLine(_startPoint, point);
            commandMove.Execute(_model);
            AddCommand(commandMove);
        }

        /// <summary>
        /// Try choose line
        /// </summary>
        /// <param name="x">Coordinate x from event</param>
        /// <param name="y">Coordinate y from event</param>
        public void TryChooseLine(int x, int y)
        {
            _model.TrySelect(x, y);
        }

        /// <summary>
        /// undo last command
        /// </summary>
        public void Undo()
        {
            if (_position > -1)
            {
                _undoredolList[_position].UnExecute(_model);
                --_position;
            }
        }
        
        /// <summary>
        /// Redo last command
        /// </summary>
        public void Redo()
        {
            if (_position + 1 < _undoredolList.Count)
            {
                _position++;
                _undoredolList[_position].Execute(_model);
            }
        }

        private void AddCommand(ICommand command)
        {
            if (_position < _undoredolList.Count - 1)
            {
                _position++;
                _undoredolList.RemoveRange(_position, _undoredolList.Count - _position);
                _undoredolList.Add(command);
            }
            else
            {
                _position++;
                _undoredolList.Add(command);
            }
        }
    }
}

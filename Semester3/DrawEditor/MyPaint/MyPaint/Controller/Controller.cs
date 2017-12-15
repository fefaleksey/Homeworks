using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using MyPaint.Controller.Commands;
using MyPaint.Model;

namespace MyPaint.Controller
{
    class Controller
    {
        private readonly Model.Model _model;

        private readonly List<ICommand> _undoredolList = new List<ICommand>();
        private int position = -1;
        private Point startPoint;
        private bool isDrawing;
        //private Line startLine;
        
        public Controller(Model.Model model)
        {
            _model = model;
        }
        
        /// <summary>
        /// End drawing
        /// </summary>
        /// <param name="point">Point from event</param>
        public void EndDrawing(Point point)
        {
            if (isDrawing)
            {
                var commandAdd = new CommandAddLine(startPoint, point);
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
            isDrawing = true;
            var line = new Line(point);
            _model.AddLine(line);
            startPoint.X = point.X;
            startPoint.Y = point.Y;
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
                    startPoint = point;
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
            _model.CorrectSelectedLine(startPoint);
            var commandMove = new CommandMoveLine(startPoint, point);
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
            if (position > -1)
            {
                _undoredolList[position].UnExecute(_model);
                --position;
            }
        }
        
        /// <summary>
        /// Redo last command
        /// </summary>
        public void Redo()
        {
            if (position + 1 < _undoredolList.Count)
            {
                position++;
                _undoredolList[position].Execute(_model);
            }
        }

        private void AddCommand(ICommand command)
        {
            if (position < _undoredolList.Count - 1)
            {
                position++;
                _undoredolList.RemoveRange(position, _undoredolList.Count - position);
                _undoredolList.Add(command);
            }
            else
            {
                position++;
                _undoredolList.Add(command);
            }
        }
    }
}

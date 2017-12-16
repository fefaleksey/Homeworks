using System.Drawing;
using MyPaint.Model;

namespace MyPaint.Controller.Commands
{
    public class CommandAddLine:ICommand
    {
        private readonly Line _line;

        private bool _undo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAddLine"/> class.
        /// </summary>
        /// <param name="point1">first point</param>
        /// <param name="point2">second point</param>
        public CommandAddLine(Point point1, Point point2)
        {
            _line = new Line(point1, point2);
            _line.EndDrawing();
        }
        
        public bool Execute(Model.Model model)
        {
            if (!_undo)
            {
                model.DeleteLastLine();
            }
            model.AddLine(_line);
            return true;
        }

        public void UnExecute(Model.Model model)
        {
            model.RemoveElement(_line);
            _undo = true;
        }
    }
}
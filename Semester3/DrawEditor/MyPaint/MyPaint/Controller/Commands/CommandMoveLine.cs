using System.Drawing;

namespace MyPaint.Controller.Commands
{
    /// <summary>
    /// Command to move a line
    /// </summary>
    public class CommandMoveLine : ICommand
    {
        private readonly Point _startPoint;
        private readonly Point _finishPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandMoveLine"/> class.
        /// </summary>
        public CommandMoveLine(Point from, Point to)
        {
            _startPoint = from;
            _finishPoint = to;
        }
            
        public bool Execute(Model.Model model)
        {
            model.CorrectSelectedLine(_finishPoint);
            return true;
        }

        public void UnExecute(Model.Model model)
        {
            model.CorrectSelectedLine(_startPoint);
        }
    }
}
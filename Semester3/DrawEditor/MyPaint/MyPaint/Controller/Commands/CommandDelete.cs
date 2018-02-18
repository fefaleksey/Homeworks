using MyPaint.Model;

namespace MyPaint.Controller.Commands
{
    /// <summary>
    /// Command to delete a line
    /// </summary>
    public class CommandDelete : ICommand
    {
        private Line _line;
        private bool _isExecute;

        public bool Execute(Model.Model model)
        {
            if (!_isExecute)
            {
                _line = model.GetSelectedLine();
                _isExecute = true;

                if (model.DeleteSelectedLine())
                {
                    return true;
                }
                return false;
            }
            
            model.RemoveElement(_line);
            return true;
        }

        public void UnExecute(Model.Model model)
        {
            model.AddLine(_line);
            _line.EndDrawing();
        }
    }
}
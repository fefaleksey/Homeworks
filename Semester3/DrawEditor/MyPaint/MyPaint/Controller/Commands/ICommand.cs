namespace MyPaint.Controller.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Make the command
        /// </summary>
        bool Execute(Model.Model model);

        /// <summary>
        /// Undo the command
        /// </summary>
        void UnExecute(Model.Model model);
    }
}
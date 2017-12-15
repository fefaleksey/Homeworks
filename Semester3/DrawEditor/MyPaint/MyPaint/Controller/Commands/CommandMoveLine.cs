using System.Drawing;
using MyPaint.Model;

namespace MyPaint.Controller.Commands
{
    public class CommandMoveLine:ICommand
    {
        private readonly Point _startPoint;
        private readonly Point _finishPoint;
        private bool _isExecute;

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
            //_finishPoint=model.GetSelectedLine();
            //model.DeleteSelectedLine();
            //if (!_isExecute)
            //{
                /*
                model.DeleteSelectedLine();
                //_finishPoint.Choose();
                model.AddLine(_finishPoint);
                //model.SelectLine(_finishPoint);
                */
            
            model.CorrectSelectedLine(_finishPoint);
            //}
            /*
            else
            {
                model.RemoveElement(_startPoint);
                model.AddLine(_finishPoint);
            }*/
            //_isExecute = true;
            return true;
        }

        public void UnExecute(Model.Model model)
        {/*
            model.RemoveElement(_finishPoint);
            model.AddLine(_startPoint);
        */
            model.CorrectSelectedLine(_startPoint);
        }
    }
}
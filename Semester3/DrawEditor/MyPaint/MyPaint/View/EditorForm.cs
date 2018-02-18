using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MyPaint.Model;

namespace MyPaint.View
{
    /// <summary>
    /// Editor of form
    /// </summary>
    public partial class EditorForm : Form
    {
        private readonly Model.Model _model;

        private readonly Controller.Controller _controller;
        private bool _isdrawingButtonOn;
        private bool _isDrawingLine;
        private bool _movingLine;
        private int _x, _y;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorForm"/> class.
        /// </summary>
        public EditorForm()
        {
            InitializeComponent();
            var gr = panel.CreateGraphics();
            gr.SmoothingMode = SmoothingMode.HighQuality | SmoothingMode.AntiAlias;
            buffGraph = gContext.Allocate(gr, new Rectangle(0, 0, panel.Width, panel.Height));
            _model = new Model.Model(new Builder(buffGraph));
            buffGraph.Graphics.Clear(SystemColors.InactiveBorder);
            _controller = new Controller.Controller(_model);
        }

        // panel
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            buffGraph?.Render(e.Graphics);
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (_isdrawingButtonOn)
            {
                _isDrawingLine = true;
                _controller.BeginDrawingLine(new Point(e.X, e.Y));
                panel.Invalidate();
                return;
            }

            if (_controller.TryBeginMoveLine(new Point(_x, _y)))
            {
                _movingLine = true;
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            _x = e.X;
            _y = e.Y;
            if ((!_model.IsEmpty() && _isDrawingLine) || _movingLine)
            {
                _controller.CorrectSelectedLine(new Point(e.X, e.Y));
                panel.Invalidate();
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDrawingLine)
            {
                _isDrawingLine = false;
                _controller.EndDrawing(new Point(_x, _y));
                panel.Invalidate();
            }
            
            if (_movingLine)
            {
                _movingLine = false;
                _controller.EndMoving(new Point(_x, _y));
                panel.Invalidate();
            }
            Redo.Enabled = !_controller.IsRedoEmpty;
            Undo.Enabled = !_controller.IsUndoEmpty;
        }
        
        private void panel_Click(object sender, EventArgs e)
        {
            if (!_isdrawingButtonOn)
            {
                _controller.TryChooseLine(_x, _y);
                
                panel.Invalidate();
            }
         }

        // buttons
        private void Undo_Click(object sender, EventArgs e)
        {
            _controller.Undo();
            if (_controller.IsUndoEmpty)
            {
                Undo.Enabled = false;
            }
            Redo.Enabled = true;
            panel.Invalidate();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            _controller.Redo();
            if (_controller.IsRedoEmpty)
            {
                Redo.Enabled = false;
            }
            Undo.Enabled = true;
            panel.Invalidate();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            _controller.Delete();
            panel.Invalidate();
        }

        private void Cursor_Click(object sender, EventArgs e)
        {
            _isdrawingButtonOn = false;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            _isdrawingButtonOn = true;
        }
    }
}
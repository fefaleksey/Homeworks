using System.Drawing;
using Xunit;
using MyPaint.Controller;
using MyPaint.Model;
using MyPaint.View;

namespace Test
{
    public class Tests
    {
        private readonly EditorForm _editor = new EditorForm();
        private Controller _controller;
        private Model _model;
        private Builder _builder;

        private void Init()
        {
            _builder = new Builder(_editor.buffGraph);
            _model = new Model(_builder);
            _controller = new Controller(_model);
        }

        [Fact]
        public void IsEmptyTest()
        {
            Init();
            Assert.True(_model.IsEmpty());
            _model.AddLine(new Line(new Point(1, 1)));
            Assert.False(_model.IsEmpty());
        }

        [Fact]
        public void CommandAddLineTest()
        {
            Init();
            _controller.BeginDrawingLine(new Point(1, 1));
            _controller.CorrectSelectedLine(new Point(100, 100));
            _controller.EndDrawing(new Point(100, 100));
            Assert.False(_model.IsEmpty());
        }

        [Fact]
        public void CommandRemoveLineTest()
        {
            Init();
            _controller.BeginDrawingLine(new Point(1, 1));
            _controller.CorrectSelectedLine(new Point(100, 100));
            _controller.EndDrawing(new Point(100, 100));
            _controller.TryChooseLine(1, 1);
            _controller.Delete();
            Assert.True(_model.IsEmpty());
        }

        [Fact]
        public void CommandMoveLineTest()
        {
            Init();
            var line = new Line(new Point(1, 1), new Point(100, 100));
            _model.AddLine(line);
            _model.SelectLine(line);
            _controller.TryBeginMoveLine(new Point(1, 1));
            _controller.EndMoving(new Point(20, 20));
            var correctLine = new Line(new Point(20,20), new Point(100,100));
            Assert.True(correctLine.Equals(line, correctLine));
        }
    }
}
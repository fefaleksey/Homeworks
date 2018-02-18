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
        private readonly Controller _controller;
        private readonly Model _model;

        public Tests()
        {
            var builder = new Builder(_editor.buffGraph);
            _model = new Model(builder);
            _controller = new Controller(_model);
        }

        [Fact]
        public void IsEmptyTest()
        {
            Assert.True(_model.IsEmpty());
            _model.AddLine(new Line(new Point(1, 1)));
            Assert.False(_model.IsEmpty());
        }

        [Fact]
        public void CommandAddLineTest()
        {
            _controller.BeginDrawingLine(new Point(1, 1));
            _controller.CorrectSelectedLine(new Point(100, 100));
            _controller.EndDrawing(new Point(100, 100));
            Assert.False(_model.IsEmpty());
        }

        [Fact]
        public void CommandRemoveLineTest()
        {
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
            var line = new Line(new Point(1, 1), new Point(100, 100));
            _model.AddLine(line);
            _model.SelectLine(line);
            _controller.TryBeginMoveLine(new Point(1, 1));
            _controller.EndMoving(new Point(20, 20));
            var correctLine = new Line(new Point(20,20), new Point(100,100));
            Assert.True(correctLine.Equals(line, correctLine));
        }

        [Fact]
        public void UndoRedoTest()
        {
            _controller.BeginDrawingLine(new Point(10, 10));
            _controller.CorrectSelectedLine(new Point(100,100));
            _controller.EndDrawing(new Point(100,100));
            _controller.BeginDrawingLine(new Point(20, 20));
            _controller.CorrectSelectedLine(new Point(50,50));
            _controller.EndDrawing(new Point(50,50));
            Assert.False(_model.IsEmpty());
            _controller.Undo();
            Assert.False(_model.IsEmpty());
            _controller.Undo();
            Assert.True(_model.IsEmpty());
            _controller.Redo();
            Assert.False(_model.IsEmpty());
        }

        [Fact]
        public void Model_DeleteSelectedLineTest()
        {
            var line = new Line(new Point(10, 10), new Point(100, 100));
            _model.AddLine(line);
            _model.SelectLine(line);
            _model.DeleteSelectedLine();
            Assert.True(_model.IsEmpty());
        }

        [Fact]
        public void Model_RemoveElementTest()
        {
            var line = new Line(new Point(10, 10), new Point(100, 100));
            _model.AddLine(line);
            _model.RemoveElement(line);
            Assert.True(_model.IsEmpty());
        }
    }
}
using System.Collections.Generic;
using System.Drawing;

namespace MyPaint.Model
{
    /// <summary>
    /// Class for drawing into a form
    /// </summary>
    public class Builder
    {
        private readonly BufferedGraphics _buffGraph;

        private readonly Color _backColor = SystemColors.InactiveBorder;

        private readonly Pen _pen = new Pen(Color.Black) { Width = 3 };

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        public Builder(BufferedGraphics bufferedGraphics)
        {
            _buffGraph = bufferedGraphics;
        }

        /// <summary>
        /// Draw window
        /// </summary>
        /// <param name="lines">List of lines for drawing</param>
        public void Draw(List<Line> lines)
        {
            _buffGraph.Graphics.Clear(_backColor);
            foreach (var line in lines)
            {
                line.Draw(_buffGraph, _pen);
            }
        }
    }
}

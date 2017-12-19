using System.Drawing;

namespace MyPaint.View
{
    partial class EditorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.Delete = new System.Windows.Forms.Button();
            this.Line = new System.Windows.Forms.Button();
            this.MouseCursor = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.Redo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Location = new System.Drawing.Point(12, 48);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(601, 379);
            this.panel.TabIndex = 0;
            this.panel.Click += new System.EventHandler(this.panel_Click);
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Delete.Location = new System.Drawing.Point(336, 12);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 4;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Line
            // 
            this.Line.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Line.Location = new System.Drawing.Point(93, 12);
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(75, 23);
            this.Line.TabIndex = 3;
            this.Line.Text = "Line";
            this.Line.UseVisualStyleBackColor = false;
            this.Line.Click += new System.EventHandler(this.Line_Click);
            // 
            // MouseCursor
            // 
            this.MouseCursor.BackColor = System.Drawing.Color.CornflowerBlue;
            this.MouseCursor.Cursor = System.Windows.Forms.Cursors.Default;
            this.MouseCursor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MouseCursor.Location = new System.Drawing.Point(12, 12);
            this.MouseCursor.Name = "MouseCursor";
            this.MouseCursor.Size = new System.Drawing.Size(75, 23);
            this.MouseCursor.TabIndex = 2;
            this.MouseCursor.Text = "Cursor";
            this.MouseCursor.UseVisualStyleBackColor = false;
            this.MouseCursor.Click += new System.EventHandler(this.Cursor_Click);
            // 
            // Undo
            // 
            this.Undo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Undo.Location = new System.Drawing.Point(174, 12);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(75, 23);
            this.Undo.TabIndex = 1;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = false;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Redo
            // 
            this.Redo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Redo.Location = new System.Drawing.Point(255, 12);
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(75, 23);
            this.Redo.TabIndex = 0;
            this.Redo.Text = "Redo";
            this.Redo.UseVisualStyleBackColor = false;
            this.Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(625, 439);
            this.Controls.Add(this.Redo);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.MouseCursor);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Name = "EditorForm";
            this.Text = "MyPaint";
            this.ResumeLayout(false);

        }
        
        #endregion

        public const int HeightOfPanel = 378;
        public const int WightOfPanel = 697;
        
        private BufferedGraphics buffGraph;
        private BufferedGraphicsContext gContext = BufferedGraphicsManager.Current;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Line;
        private System.Windows.Forms.Button MouseCursor;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Redo;
    }
}
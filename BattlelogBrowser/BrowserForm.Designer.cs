namespace Alexantr.BattlelogBrowser
{
    partial class BrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.goHomeButton = new System.Windows.Forms.ToolStripButton();
            this.urlTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.goButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1008, 704);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            this.toolStripContainer.Size = new System.Drawing.Size(1008, 729);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goHomeButton,
            this.urlTextBox,
            this.goButton});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(275, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // goHomeButton
            // 
            this.goHomeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.goHomeButton.Image = ((System.Drawing.Image)(resources.GetObject("goHomeButton.Image")));
            this.goHomeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goHomeButton.Name = "goHomeButton";
            this.goHomeButton.Size = new System.Drawing.Size(44, 22);
            this.goHomeButton.Text = "Home";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(200, 25);
            // 
            // goButton
            // 
            this.goButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.goButton.Image = ((System.Drawing.Image)(resources.GetObject("goButton.Image")));
            this.goButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(26, 22);
            this.goButton.Text = "Go";
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Battlelog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserForm_FormClosing);
            this.Resize += new System.EventHandler(this.BrowserForm_Resize);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton goHomeButton;
        private System.Windows.Forms.ToolStripTextBox urlTextBox;
        private System.Windows.Forms.ToolStripButton goButton;
    }
}


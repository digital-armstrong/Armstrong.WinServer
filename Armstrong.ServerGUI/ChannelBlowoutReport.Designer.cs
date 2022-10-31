namespace Armstrong.WinServer
{
    partial class ChannelBlowoutReport
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
            this.blowoutReportGrid = new System.Windows.Forms.DataGridView();
            this.blowoutCategoriesReportGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.blowoutReportGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blowoutCategoriesReportGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // blowoutReportGrid
            // 
            this.blowoutReportGrid.AllowUserToAddRows = false;
            this.blowoutReportGrid.AllowUserToDeleteRows = false;
            this.blowoutReportGrid.AllowUserToResizeRows = false;
            this.blowoutReportGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.blowoutReportGrid.BackgroundColor = System.Drawing.Color.DarkGray;
            this.blowoutReportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blowoutReportGrid.Location = new System.Drawing.Point(12, 12);
            this.blowoutReportGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blowoutReportGrid.MultiSelect = false;
            this.blowoutReportGrid.Name = "blowoutReportGrid";
            this.blowoutReportGrid.ReadOnly = true;
            this.blowoutReportGrid.RowHeadersVisible = false;
            this.blowoutReportGrid.RowHeadersWidth = 51;
            this.blowoutReportGrid.RowTemplate.Height = 24;
            this.blowoutReportGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.blowoutReportGrid.Size = new System.Drawing.Size(470, 474);
            this.blowoutReportGrid.TabIndex = 0;
            // 
            // blowoutCategoriesReportGrid
            // 
            this.blowoutCategoriesReportGrid.AllowUserToAddRows = false;
            this.blowoutCategoriesReportGrid.AllowUserToDeleteRows = false;
            this.blowoutCategoriesReportGrid.AllowUserToResizeRows = false;
            this.blowoutCategoriesReportGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.blowoutCategoriesReportGrid.BackgroundColor = System.Drawing.Color.DarkGray;
            this.blowoutCategoriesReportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blowoutCategoriesReportGrid.Location = new System.Drawing.Point(500, 12);
            this.blowoutCategoriesReportGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blowoutCategoriesReportGrid.MultiSelect = false;
            this.blowoutCategoriesReportGrid.Name = "blowoutCategoriesReportGrid";
            this.blowoutCategoriesReportGrid.ReadOnly = true;
            this.blowoutCategoriesReportGrid.RowHeadersVisible = false;
            this.blowoutCategoriesReportGrid.RowHeadersWidth = 51;
            this.blowoutCategoriesReportGrid.RowTemplate.Height = 24;
            this.blowoutCategoriesReportGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.blowoutCategoriesReportGrid.Size = new System.Drawing.Size(470, 474);
            this.blowoutCategoriesReportGrid.TabIndex = 1;
            // 
            // ChannelBlowoutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 499);
            this.Controls.Add(this.blowoutCategoriesReportGrid);
            this.Controls.Add(this.blowoutReportGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChannelBlowoutReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.blowoutReportGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blowoutCategoriesReportGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView blowoutReportGrid;
        private System.Windows.Forms.DataGridView blowoutCategoriesReportGrid;
    }
}

namespace StudentManagementSystem
{
    partial class SL_List
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewScore = new System.Windows.Forms.DataGridView();
            this.ColumnStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ttSearch = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureCircle = new StudentManagementSystem.PictureCircle();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCircle)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewScore
            // 
            this.dataGridViewScore.AllowUserToAddRows = false;
            this.dataGridViewScore.AllowUserToDeleteRows = false;
            this.dataGridViewScore.AllowUserToResizeColumns = false;
            this.dataGridViewScore.AllowUserToResizeRows = false;
            this.dataGridViewScore.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Chaparral Pro", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStudentID,
            this.ColumnFullName,
            this.ColumnGender,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewScore.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewScore.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewScore.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewScore.MultiSelect = false;
            this.dataGridViewScore.Name = "dataGridViewScore";
            this.dataGridViewScore.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Khmer OS Siemreap", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewScore.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewScore.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Chaparral Pro", 11.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridViewScore.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewScore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScore.Size = new System.Drawing.Size(435, 595);
            this.dataGridViewScore.TabIndex = 7;
            this.dataGridViewScore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewScore_CellClick);
            // 
            // ColumnStudentID
            // 
            this.ColumnStudentID.HeaderText = "ID";
            this.ColumnStudentID.MinimumWidth = 50;
            this.ColumnStudentID.Name = "ColumnStudentID";
            this.ColumnStudentID.ReadOnly = true;
            this.ColumnStudentID.Width = 50;
            // 
            // ColumnFullName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColumnFullName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnFullName.HeaderText = "FullName";
            this.ColumnFullName.Name = "ColumnFullName";
            this.ColumnFullName.ReadOnly = true;
            this.ColumnFullName.Width = 150;
            // 
            // ColumnGender
            // 
            this.ColumnGender.HeaderText = "Gender";
            this.ColumnGender.Name = "ColumnGender";
            this.ColumnGender.ReadOnly = true;
            this.ColumnGender.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cell Phone";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Chaparral Pro", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(282, 12);
            this.txtSearch.MaxLength = 10000;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(165, 23);
            this.txtSearch.TabIndex = 21;
            this.ttSearch.SetToolTip(this.txtSearch, "Type anything to search");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StudentManagementSystem.Properties.Resources._1458373346_Find01;
            this.pictureBox1.Location = new System.Drawing.Point(423, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 23);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureCircle
            // 
            this.pictureCircle.BackColor = System.Drawing.Color.Black;
            this.pictureCircle.Image = global::StudentManagementSystem.Properties.Resources._1446056085_Student_3;
            this.pictureCircle.InitialImage = null;
            this.pictureCircle.Location = new System.Drawing.Point(478, 12);
            this.pictureCircle.Name = "pictureCircle";
            this.pictureCircle.Size = new System.Drawing.Size(175, 175);
            this.pictureCircle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCircle.TabIndex = 8;
            this.pictureCircle.TabStop = false;
            // 
            // SL_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 646);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pictureCircle);
            this.Controls.Add(this.dataGridViewScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SL_List";
            this.Text = "SL_List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SL_List_FormClosed);
            this.Load += new System.EventHandler(this.SL_List_Load);
            this.Leave += new System.EventHandler(this.SL_List_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCircle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private PictureCircle pictureCircle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolTip ttSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
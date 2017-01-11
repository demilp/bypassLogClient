namespace LogClient
{
    partial class FormLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLog));
            this.messages = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clients = new System.Windows.Forms.ListBox();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.textBoxDataPreview = new System.Windows.Forms.TextBox();
            this.messages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messages
            // 
            this.messages.Controls.Add(this.dataGridView1);
            this.messages.Location = new System.Drawing.Point(226, 5);
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(732, 495);
            this.messages.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(732, 495);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clients);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 622);
            this.panel1.TabIndex = 1;
            // 
            // clients
            // 
            this.clients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clients.FormattingEnabled = true;
            this.clients.Location = new System.Drawing.Point(0, 0);
            this.clients.MultiColumn = true;
            this.clients.Name = "clients";
            this.clients.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.clients.Size = new System.Drawing.Size(200, 622);
            this.clients.TabIndex = 0;
            this.clients.SelectedIndexChanged += new System.EventHandler(this.clients_SelectedIndexChanged);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayPause.Location = new System.Drawing.Point(12, 5);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(200, 50);
            this.btnPlayPause.TabIndex = 2;
            this.btnPlayPause.Text = "▶";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // textBoxDataPreview
            // 
            this.textBoxDataPreview.Location = new System.Drawing.Point(226, 506);
            this.textBoxDataPreview.Multiline = true;
            this.textBoxDataPreview.Name = "textBoxDataPreview";
            this.textBoxDataPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDataPreview.Size = new System.Drawing.Size(732, 177);
            this.textBoxDataPreview.TabIndex = 1;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 695);
            this.Controls.Add(this.textBoxDataPreview);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.messages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLog";
            this.Text = "Log Client";
            this.messages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel messages;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox clients;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.TextBox textBoxDataPreview;
    }
}


namespace nRage.Example {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtShowName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFullSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEpisodeList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowInfo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnFullShowInfo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtShowList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtSeason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEpisode = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastUpdates = new System.Windows.Forms.Button();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(3, 45);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 27);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Basic GetSeries";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFullSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtShowName);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(236, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GetSeries";
            // 
            // txtShowName
            // 
            this.txtShowName.Location = new System.Drawing.Point(75, 19);
            this.txtShowName.Name = "txtShowName";
            this.txtShowName.Size = new System.Drawing.Size(155, 20);
            this.txtShowName.TabIndex = 2;
            this.txtShowName.Text = "Breaking Bad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Show name";
            // 
            // btnFullSearch
            // 
            this.btnFullSearch.Location = new System.Drawing.Point(118, 45);
            this.btnFullSearch.Name = "btnFullSearch";
            this.btnFullSearch.Size = new System.Drawing.Size(112, 27);
            this.btnFullSearch.TabIndex = 4;
            this.btnFullSearch.Text = "Detailed GetSeries";
            this.btnFullSearch.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFullShowInfo);
            this.groupBox2.Controls.Add(this.btnEpisodeList);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnShowInfo);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(9, 94);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(236, 80);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Get Show Info";
            // 
            // btnEpisodeList
            // 
            this.btnEpisodeList.Location = new System.Drawing.Point(80, 45);
            this.btnEpisodeList.Name = "btnEpisodeList";
            this.btnEpisodeList.Size = new System.Drawing.Size(73, 27);
            this.btnEpisodeList.TabIndex = 4;
            this.btnEpisodeList.Text = "Episodes";
            this.btnEpisodeList.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Show Id";
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.Location = new System.Drawing.Point(3, 45);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.Size = new System.Drawing.Size(73, 27);
            this.btnShowInfo.TabIndex = 0;
            this.btnShowInfo.Text = "Show Info";
            this.btnShowInfo.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "15352";
            // 
            // btnFullShowInfo
            // 
            this.btnFullShowInfo.Location = new System.Drawing.Point(157, 45);
            this.btnFullShowInfo.Name = "btnFullShowInfo";
            this.btnFullShowInfo.Size = new System.Drawing.Size(73, 27);
            this.btnFullShowInfo.TabIndex = 5;
            this.btnFullShowInfo.Text = "Both";
            this.btnFullShowInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtEpisode);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.txtSeason);
            this.groupBox3.Location = new System.Drawing.Point(9, 179);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(236, 67);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Get Episode Info";
            // 
            // txtShowList
            // 
            this.txtShowList.Location = new System.Drawing.Point(9, 328);
            this.txtShowList.Name = "txtShowList";
            this.txtShowList.Size = new System.Drawing.Size(236, 27);
            this.txtShowList.TabIndex = 5;
            this.txtShowList.Text = "Full Show List";
            this.txtShowList.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Season #";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(135, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 43);
            this.button3.TabIndex = 0;
            this.button3.Text = "Get Episode";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtSeason
            // 
            this.txtSeason.Location = new System.Drawing.Point(75, 19);
            this.txtSeason.Name = "txtSeason";
            this.txtSeason.Size = new System.Drawing.Size(54, 20);
            this.txtSeason.TabIndex = 2;
            this.txtSeason.Text = "15352";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Episode #";
            // 
            // txtEpisode
            // 
            this.txtEpisode.Location = new System.Drawing.Point(75, 42);
            this.txtEpisode.Name = "txtEpisode";
            this.txtEpisode.Size = new System.Drawing.Size(54, 20);
            this.txtEpisode.TabIndex = 4;
            this.txtEpisode.Text = "15352";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtDays);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtLastUpdates);
            this.groupBox4.Controls.Add(this.txtHours);
            this.groupBox4.Location = new System.Drawing.Point(9, 251);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(236, 67);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Last Updates Since...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Days";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(75, 42);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(54, 20);
            this.txtDays.TabIndex = 4;
            this.txtDays.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Hours";
            // 
            // txtLastUpdates
            // 
            this.txtLastUpdates.Location = new System.Drawing.Point(135, 19);
            this.txtLastUpdates.Name = "txtLastUpdates";
            this.txtLastUpdates.Size = new System.Drawing.Size(95, 43);
            this.txtLastUpdates.TabIndex = 0;
            this.txtLastUpdates.Text = "Get Updates";
            this.txtLastUpdates.UseVisualStyleBackColor = true;
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(75, 19);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(54, 20);
            this.txtHours.TabIndex = 2;
            this.txtHours.Text = "8";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(259, 15);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(410, 339);
            this.txtResult.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 367);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtShowList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "nRage Example";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtShowName;
        private System.Windows.Forms.Button btnFullSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFullShowInfo;
        private System.Windows.Forms.Button btnEpisodeList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEpisode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtSeason;
        private System.Windows.Forms.Button txtShowList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button txtLastUpdates;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtResult;
    }
}


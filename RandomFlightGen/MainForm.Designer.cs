namespace RandomFlightGen
{
    partial class MainForm
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
			this.lblCountry = new System.Windows.Forms.Label();
			this.cbCountry = new System.Windows.Forms.ComboBox();
			this.butRandomCountry = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.butRandomAirport = new System.Windows.Forms.Button();
			this.tbDistanceFrom = new System.Windows.Forms.TextBox();
			this.tbDistanceTo = new System.Windows.Forms.TextBox();
			this.butRandomDest = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cbContinent = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.lblAD = new System.Windows.Forms.Label();
			this.tbICAO = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblMatches = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblDestMatches = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tbDestICAO = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.clbAirportTypes = new System.Windows.Forms.CheckedListBox();
			this.wbDep = new System.Windows.Forms.WebBrowser();
			this.wbDest = new System.Windows.Forms.WebBrowser();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblCountry
			// 
			this.lblCountry.AutoSize = true;
			this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCountry.Location = new System.Drawing.Point(269, 29);
			this.lblCountry.Name = "lblCountry";
			this.lblCountry.Size = new System.Drawing.Size(64, 20);
			this.lblCountry.TabIndex = 2;
			this.lblCountry.Text = "Country";
			// 
			// cbCountry
			// 
			this.cbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbCountry.FormattingEnabled = true;
			this.cbCountry.Location = new System.Drawing.Point(339, 26);
			this.cbCountry.Name = "cbCountry";
			this.cbCountry.Size = new System.Drawing.Size(282, 28);
			this.cbCountry.TabIndex = 3;
			this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.CbCountry_SelectedIndexChanged);
			// 
			// butRandomCountry
			// 
			this.butRandomCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butRandomCountry.Location = new System.Drawing.Point(627, 25);
			this.butRandomCountry.Name = "butRandomCountry";
			this.butRandomCountry.Size = new System.Drawing.Size(73, 30);
			this.butRandomCountry.TabIndex = 4;
			this.butRandomCountry.Text = "Random";
			this.toolTip.SetToolTip(this.butRandomCountry, "Pick a random country for me");
			this.butRandomCountry.UseVisualStyleBackColor = true;
			this.butRandomCountry.Click += new System.EventHandler(this.ButRandomCountry_Click);
			// 
			// butRandomAirport
			// 
			this.butRandomAirport.Location = new System.Drawing.Point(145, 32);
			this.butRandomAirport.Name = "butRandomAirport";
			this.butRandomAirport.Size = new System.Drawing.Size(61, 24);
			this.butRandomAirport.TabIndex = 2;
			this.butRandomAirport.Text = "Random";
			this.toolTip.SetToolTip(this.butRandomAirport, "Pick another random airport");
			this.butRandomAirport.UseVisualStyleBackColor = true;
			this.butRandomAirport.Click += new System.EventHandler(this.ButRandomAirport_Click);
			// 
			// tbDistanceFrom
			// 
			this.tbDistanceFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDistanceFrom.Location = new System.Drawing.Point(145, 26);
			this.tbDistanceFrom.Name = "tbDistanceFrom";
			this.tbDistanceFrom.Size = new System.Drawing.Size(48, 22);
			this.tbDistanceFrom.TabIndex = 11;
			this.toolTip.SetToolTip(this.tbDistanceFrom, "Distance from departure is greater or equal to this in NM. Leave empty to ignore");
			// 
			// tbDistanceTo
			// 
			this.tbDistanceTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDistanceTo.Location = new System.Drawing.Point(230, 26);
			this.tbDistanceTo.Name = "tbDistanceTo";
			this.tbDistanceTo.Size = new System.Drawing.Size(48, 22);
			this.tbDistanceTo.TabIndex = 13;
			this.toolTip.SetToolTip(this.tbDistanceTo, "Distance from departure is less than or equal  to this in NM. Leave empty for any" +
        " distance");
			// 
			// butRandomDest
			// 
			this.butRandomDest.Location = new System.Drawing.Point(145, 60);
			this.butRandomDest.Name = "butRandomDest";
			this.butRandomDest.Size = new System.Drawing.Size(61, 24);
			this.butRandomDest.TabIndex = 17;
			this.butRandomDest.Text = "Random";
			this.toolTip.SetToolTip(this.butRandomDest, "Pick a random destination airport matching criteria");
			this.butRandomDest.UseVisualStyleBackColor = true;
			this.butRandomDest.Click += new System.EventHandler(this.ButRandomDest_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(28, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Continent";
			// 
			// cbContinent
			// 
			this.cbContinent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbContinent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbContinent.FormattingEnabled = true;
			this.cbContinent.Location = new System.Drawing.Point(112, 26);
			this.cbContinent.Name = "cbContinent";
			this.cbContinent.Size = new System.Drawing.Size(140, 28);
			this.cbContinent.TabIndex = 1;
			this.cbContinent.SelectedIndexChanged += new System.EventHandler(this.CbContinent_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Airport Types";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.wbDep);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.butRandomAirport);
			this.panel1.Controls.Add(this.lblAD);
			this.panel1.Controls.Add(this.tbICAO);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(10, 197);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(776, 195);
			this.panel1.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(127, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Departure Airport";
			// 
			// lblAD
			// 
			this.lblAD.AutoSize = true;
			this.lblAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAD.Location = new System.Drawing.Point(29, 79);
			this.lblAD.Name = "lblAD";
			this.lblAD.Size = new System.Drawing.Size(107, 16);
			this.lblAD.TabIndex = 2;
			this.lblAD.Text = "Airport Details";
			// 
			// tbICAO
			// 
			this.tbICAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbICAO.Location = new System.Drawing.Point(74, 32);
			this.tbICAO.Name = "tbICAO";
			this.tbICAO.Size = new System.Drawing.Size(66, 22);
			this.tbICAO.TabIndex = 1;
			this.tbICAO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBICAO_KeyUp);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(29, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "ICAO";
			// 
			// lblMatches
			// 
			this.lblMatches.AutoSize = true;
			this.lblMatches.Location = new System.Drawing.Point(317, 175);
			this.lblMatches.Name = "lblMatches";
			this.lblMatches.Size = new System.Drawing.Size(81, 13);
			this.lblMatches.TabIndex = 4;
			this.lblMatches.Text = "Matches Found";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.wbDest);
			this.panel2.Controls.Add(this.lblDestMatches);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.butRandomDest);
			this.panel2.Controls.Add(this.tbDestICAO);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.tbDistanceTo);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.tbDistanceFrom);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Location = new System.Drawing.Point(10, 398);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(776, 217);
			this.panel2.TabIndex = 8;
			// 
			// lblDestMatches
			// 
			this.lblDestMatches.AutoSize = true;
			this.lblDestMatches.Location = new System.Drawing.Point(225, 66);
			this.lblDestMatches.Name = "lblDestMatches";
			this.lblDestMatches.Size = new System.Drawing.Size(81, 13);
			this.lblDestMatches.TabIndex = 20;
			this.lblDestMatches.Text = "Matches Found";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(29, 109);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(107, 16);
			this.label11.TabIndex = 18;
			this.label11.Text = "Airport Details";
			// 
			// tbDestICAO
			// 
			this.tbDestICAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDestICAO.Location = new System.Drawing.Point(74, 60);
			this.tbDestICAO.Name = "tbDestICAO";
			this.tbDestICAO.Size = new System.Drawing.Size(66, 22);
			this.tbDestICAO.TabIndex = 16;
			this.tbDestICAO.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TB_DestICAO_KeyUp);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(29, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 16);
			this.label9.TabIndex = 15;
			this.label9.Text = "ICAO";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(282, 31);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "NM";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(199, 31);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(25, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "and";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(29, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(115, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Distance between";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Destination Airport";
			// 
			// clbAirportTypes
			// 
			this.clbAirportTypes.CheckOnClick = true;
			this.clbAirportTypes.FormattingEnabled = true;
			this.clbAirportTypes.Location = new System.Drawing.Point(112, 79);
			this.clbAirportTypes.Name = "CLB_AirportTypes";
			this.clbAirportTypes.Size = new System.Drawing.Size(172, 109);
			this.clbAirportTypes.TabIndex = 5;
			this.clbAirportTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLB_AirportTypes_ItemCheck);
			// 
			// wbDep
			// 
			this.wbDep.AllowWebBrowserDrop = false;
			this.wbDep.IsWebBrowserContextMenuEnabled = false;
			this.wbDep.Location = new System.Drawing.Point(142, 68);
			this.wbDep.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbDep.Name = "wbDep";
			this.wbDep.Size = new System.Drawing.Size(629, 117);
			this.wbDep.TabIndex = 9;
			// 
			// wbDest
			// 
			this.wbDest.AllowWebBrowserDrop = false;
			this.wbDest.IsWebBrowserContextMenuEnabled = false;
			this.wbDest.Location = new System.Drawing.Point(142, 99);
			this.wbDest.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbDest.Name = "wbDest";
			this.wbDest.Size = new System.Drawing.Size(629, 109);
			this.wbDest.TabIndex = 21;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 619);
			this.Controls.Add(this.clbAirportTypes);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.lblMatches);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbContinent);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.butRandomCountry);
			this.Controls.Add(this.cbCountry);
			this.Controls.Add(this.lblCountry);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Random Flight Generator";
			this.Load += new System.EventHandler(this.Main_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

	#endregion

	private System.Windows.Forms.Label lblCountry;
	private System.Windows.Forms.ComboBox cbCountry;
	private System.Windows.Forms.Button butRandomCountry;
	private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbContinent;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbICAO;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblAD;
		private System.Windows.Forms.Button butRandomAirport;
		private System.Windows.Forms.Label lblMatches;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbDistanceTo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbDistanceFrom;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button butRandomDest;
		private System.Windows.Forms.TextBox tbDestICAO;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lblDestMatches;
		private System.Windows.Forms.CheckedListBox clbAirportTypes;
		private System.Windows.Forms.WebBrowser wbDep;
		private System.Windows.Forms.WebBrowser wbDest;
	}
}


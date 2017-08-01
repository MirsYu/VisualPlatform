namespace VisualPlatform
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.imageBox1 = new Emgu.CV.UI.ImageBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.treeView_Components = new System.Windows.Forms.TreeView();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.treeView_Hierachy = new System.Windows.Forms.TreeView();
			this.tabControl4 = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.btn_Connet = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabControl4.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(2, 59);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(581, 516);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.pictureBox1);
			this.tabPage2.Controls.Add(this.imageBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(573, 489);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Image";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(70, 47);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(397, 277);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// imageBox1
			// 
			this.imageBox1.BackColor = System.Drawing.SystemColors.Highlight;
			this.imageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageBox1.Location = new System.Drawing.Point(3, 3);
			this.imageBox1.Name = "imageBox1";
			this.imageBox1.Size = new System.Drawing.Size(567, 483);
			this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imageBox1.TabIndex = 2;
			this.imageBox1.TabStop = false;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "file.ico");
			this.imageList1.Images.SetKeyName(1, "geGray.ico");
			this.imageList1.Images.SetKeyName(2, "geZbar.ico");
			this.imageList1.Images.SetKeyName(3, "CogAngleLineLineTool.ico");
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Location = new System.Drawing.Point(589, 369);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(223, 206);
			this.tabControl2.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.treeView_Components);
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(215, 179);
			this.tabPage3.TabIndex = 1;
			this.tabPage3.Text = "Components";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// treeView_Components
			// 
			this.treeView_Components.AllowDrop = true;
			this.treeView_Components.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView_Components.ImageIndex = 0;
			this.treeView_Components.ImageList = this.imageList1;
			this.treeView_Components.Location = new System.Drawing.Point(3, 3);
			this.treeView_Components.Name = "treeView_Components";
			this.treeView_Components.SelectedImageIndex = 0;
			this.treeView_Components.Size = new System.Drawing.Size(209, 173);
			this.treeView_Components.TabIndex = 0;
			this.treeView_Components.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_Components_ItemDrag);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(422, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Zbar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabControl3
			// 
			this.tabControl3.Controls.Add(this.tabPage4);
			this.tabControl3.Location = new System.Drawing.Point(589, 59);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(223, 304);
			this.tabControl3.TabIndex = 3;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.treeView_Hierachy);
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(215, 277);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Hierarchy";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// treeView_Hierachy
			// 
			this.treeView_Hierachy.AllowDrop = true;
			this.treeView_Hierachy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView_Hierachy.ImageIndex = 0;
			this.treeView_Hierachy.ImageList = this.imageList1;
			this.treeView_Hierachy.Location = new System.Drawing.Point(3, 3);
			this.treeView_Hierachy.Name = "treeView_Hierachy";
			this.treeView_Hierachy.SelectedImageIndex = 0;
			this.treeView_Hierachy.Size = new System.Drawing.Size(209, 271);
			this.treeView_Hierachy.TabIndex = 0;
			this.treeView_Hierachy.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_Hierachy_ItemDrag);
			this.treeView_Hierachy.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_Hierachy_DragDrop);
			this.treeView_Hierachy.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_Hierachy_DragEnter);
			// 
			// tabControl4
			// 
			this.tabControl4.Controls.Add(this.tabPage5);
			this.tabControl4.Controls.Add(this.tabPage1);
			this.tabControl4.Controls.Add(this.tabPage6);
			this.tabControl4.Location = new System.Drawing.Point(818, 59);
			this.tabControl4.Name = "tabControl4";
			this.tabControl4.SelectedIndex = 0;
			this.tabControl4.Size = new System.Drawing.Size(449, 516);
			this.tabControl4.TabIndex = 4;
			// 
			// tabPage5
			// 
			this.tabPage5.Location = new System.Drawing.Point(4, 23);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(441, 489);
			this.tabPage5.TabIndex = 1;
			this.tabPage5.Text = "Inspector";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.button5);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(441, 489);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "SourceCode";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(6, 9);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(265, 22);
			this.textBox2.TabIndex = 3;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(277, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 2;
			this.button5.Text = "button5";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(358, 8);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 1;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 37);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(429, 446);
			this.textBox1.TabIndex = 0;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.textBox4);
			this.tabPage6.Controls.Add(this.textBox3);
			this.tabPage6.Controls.Add(this.btn_Connet);
			this.tabPage6.Location = new System.Drawing.Point(4, 23);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(441, 489);
			this.tabPage6.TabIndex = 3;
			this.tabPage6.Text = "TCP";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(3, 32);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(435, 454);
			this.textBox3.TabIndex = 5;
			// 
			// btn_Connet
			// 
			this.btn_Connet.Location = new System.Drawing.Point(3, 3);
			this.btn_Connet.Name = "btn_Connet";
			this.btn_Connet.Size = new System.Drawing.Size(75, 23);
			this.btn_Connet.TabIndex = 4;
			this.btn_Connet.Text = "连接";
			this.btn_Connet.UseVisualStyleBackColor = true;
			this.btn_Connet.Click += new System.EventHandler(this.btn_Connet_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(692, 7);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(818, 7);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(531, 11);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 7;
			this.button6.Text = "Zxing";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(58, 12);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(325, 45);
			this.trackBar1.TabIndex = 8;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(130, 4);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(146, 22);
			this.textBox4.TabIndex = 6;
			this.textBox4.Text = "192.168.0.";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1279, 591);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.tabControl4);
			this.Controls.Add(this.tabControl3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tabControl2);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabControl3.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabControl4.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage2;
		private Emgu.CV.UI.ImageBox imageBox1;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabControl tabControl3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabControl tabControl4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TreeView treeView_Components;
		private System.Windows.Forms.TreeView treeView_Hierachy;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Button btn_Connet;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBox4;
	}
}


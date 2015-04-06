/*
 * Created by SharpDevelop.
 * User: XiaoSanya
 * Date: 2015/3/31
 * Time: 20:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace eTracker
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Label labelFilename;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label labelALLNo;
		private System.Windows.Forms.Label labelDQ;
		private System.Windows.Forms.Label labelZT;
		private System.Windows.Forms.Label labelQS;
		private System.Windows.Forms.Label labelCX;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelInfo;
		private System.Windows.Forms.Label labelCC;
		private System.Windows.Forms.Label label7;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.buttonOpen = new System.Windows.Forms.Button();
			this.labelFilename = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.labelCC = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelALLNo = new System.Windows.Forms.Label();
			this.labelDQ = new System.Windows.Forms.Label();
			this.labelZT = new System.Windows.Forms.Label();
			this.labelQS = new System.Windows.Forms.Label();
			this.labelCX = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.labelInfo = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(15, 18);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(75, 23);
			this.buttonOpen.TabIndex = 0;
			this.buttonOpen.Text = "打开";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.ButtonOpenClick);
			// 
			// labelFilename
			// 
			this.labelFilename.Location = new System.Drawing.Point(114, 23);
			this.labelFilename.Name = "labelFilename";
			this.labelFilename.Size = new System.Drawing.Size(284, 18);
			this.labelFilename.TabIndex = 2;
			this.labelFilename.Text = "请先打开快递单Excel文件";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonOpen);
			this.groupBox1.Controls.Add(this.labelFilename);
			this.groupBox1.Location = new System.Drawing.Point(13, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(407, 52);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.labelCC);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.labelALLNo);
			this.groupBox2.Controls.Add(this.labelDQ);
			this.groupBox2.Controls.Add(this.labelZT);
			this.groupBox2.Controls.Add(this.labelQS);
			this.groupBox2.Controls.Add(this.labelCX);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.buttonSave);
			this.groupBox2.Controls.Add(this.buttonStop);
			this.groupBox2.Controls.Add(this.buttonStart);
			this.groupBox2.Location = new System.Drawing.Point(13, 71);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(407, 175);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			// 
			// labelCC
			// 
			this.labelCC.Location = new System.Drawing.Point(96, 154);
			this.labelCC.Name = "labelCC";
			this.labelCC.Size = new System.Drawing.Size(50, 18);
			this.labelCC.TabIndex = 15;
			this.labelCC.Text = "0";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(15, 154);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 18);
			this.label7.TabIndex = 14;
			this.label7.Text = "查询出错：";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(133, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(10, 18);
			this.label5.TabIndex = 13;
			this.label5.Text = "/";
			// 
			// labelALLNo
			// 
			this.labelALLNo.Location = new System.Drawing.Point(154, 62);
			this.labelALLNo.Name = "labelALLNo";
			this.labelALLNo.Size = new System.Drawing.Size(40, 18);
			this.labelALLNo.TabIndex = 12;
			this.labelALLNo.Text = "0";
			// 
			// labelDQ
			// 
			this.labelDQ.Location = new System.Drawing.Point(96, 108);
			this.labelDQ.Name = "labelDQ";
			this.labelDQ.Size = new System.Drawing.Size(50, 18);
			this.labelDQ.TabIndex = 11;
			this.labelDQ.Text = "0";
			// 
			// labelZT
			// 
			this.labelZT.Location = new System.Drawing.Point(96, 131);
			this.labelZT.Name = "labelZT";
			this.labelZT.Size = new System.Drawing.Size(50, 18);
			this.labelZT.TabIndex = 10;
			this.labelZT.Text = "0";
			// 
			// labelQS
			// 
			this.labelQS.Location = new System.Drawing.Point(96, 85);
			this.labelQS.Name = "labelQS";
			this.labelQS.Size = new System.Drawing.Size(50, 18);
			this.labelQS.TabIndex = 9;
			this.labelQS.Text = "0";
			// 
			// labelCX
			// 
			this.labelCX.Location = new System.Drawing.Point(96, 62);
			this.labelCX.Name = "labelCX";
			this.labelCX.Size = new System.Drawing.Size(40, 18);
			this.labelCX.TabIndex = 8;
			this.labelCX.Text = "0";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(15, 108);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 18);
			this.label4.TabIndex = 7;
			this.label4.Text = "到达待取：";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 131);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 18);
			this.label3.TabIndex = 6;
			this.label3.Text = "运输途中：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "成功签收：";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "已查询到：";
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(321, 20);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "保存结果";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new System.Drawing.Point(114, 20);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 2;
			this.buttonStop.Text = "停止查询";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Location = new System.Drawing.Point(15, 20);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "开始查询";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
			// 
			// labelInfo
			// 
			this.labelInfo.Location = new System.Drawing.Point(13, 252);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(407, 18);
			this.labelInfo.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 274);
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "eTracker";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

			this.labelInfo.Location = new System.Drawing.Point(13, 252);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(407, 18);
			this.labelInfo.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 274);
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "eTracker";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}

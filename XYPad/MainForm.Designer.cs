/*
 * Created by SharpDevelop.
 * User: Andreas
 * Date: 02.05.2014
 * Time: 17:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace XYPad
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
			this.panel1 = new XYPad.BufferedPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.midiDevices = new System.Windows.Forms.ComboBox();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 22);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(284, 240);
			this.panel1.TabIndex = 0;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseDown);
			this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseMove);
			this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1MouseUp);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.midiDevices);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(284, 22);
			this.panel2.TabIndex = 1;
			// 
			// midiDevices
			// 
			this.midiDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.midiDevices.FormattingEnabled = true;
			this.midiDevices.Location = new System.Drawing.Point(0, 0);
			this.midiDevices.Name = "midiDevices";
			this.midiDevices.Size = new System.Drawing.Size(284, 21);
			this.midiDevices.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "MainForm";
			this.Text = "XYPad";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Resize += new System.EventHandler(this.MainFormResize);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox midiDevices;
		private System.Windows.Forms.Panel panel2;
		private XYPad.BufferedPanel panel1;
	}
}

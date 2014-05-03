/*
 * Created by SharpDevelop.
 * User: Andreas
 * Date: 02.05.2014
 * Time: 17:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using XYPad;

namespace XYPad
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private Dot dot;
		private bool mousePressing=false;
		private MIDI midi;
		private float lastval1 = 0;
		private float lastval2 = 0;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			dot=new Dot(panel1.Width,panel1.Height);
			midi=new MIDI();
			//comblist mit geräten auffüllen
			midi.refreshList(midiDevices);
		}
		
		void Panel1Paint(object sender, PaintEventArgs e)
		{
			dot.Render(e.Graphics);
		}
		
		void Panel1MouseDown(object sender, MouseEventArgs e)
		{
			this.mousePressing=true;
		}
		
		void Panel1MouseUp(object sender, MouseEventArgs e)
		{
			this.mousePressing=false;
		}
		
				
		void Panel1MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if( this.mousePressing ) {
				this.dot.SetXY(e.X, e.Y);
				this.panel1.Invalidate();
				float val1=0x7f-this.dot.GetMidiY(0x7f);
				float val2=this.dot.GetMidiX(16382);
				if( val1 != lastval1 ) {
					midi.sendMidi(midiDevices.SelectedIndex,0xb,0,1,(byte)val1);
					lastval1 = val1;
				}
				if( val2 != lastval2 ) {
					midi.sendMidi(midiDevices.SelectedIndex,0xe,0,(byte)((ushort)val2&0x7f),(byte)((ushort)val2 >>7 & 0x7f));
					lastval2 = val2;
				}
			}
		}
		
				
		void MainFormResize(object sender, System.EventArgs e)
		{
			this.dot.SetWH(this.panel1.Width,this.panel1.Height);
			this.panel1.Invalidate();
		}
	}
}

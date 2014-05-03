/*
 * Created by SharpDevelop.
 * User: Andreas
 * Date: 02.05.2014
 * Time: 17:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace XYPad
{
	/// <summary>
	/// Description of Dot.
	/// </summary>
	public class Dot
	{
		private float x;
		private float y;
		private int size;
		private float width;
		private float height;
		
		private int bound(float val, float min, float max) {
			val = Math.Min(val,max);
			val = Math.Max(val,min);
			return (int)val;
		}
		
		public Dot(int width, int height)
		{
			this.width = width;
			this.height = height;
			this.x = this.width / 2;
			this.y = this.height / 2;
			this.size = 10;
		}
		
		public void Render(Graphics g) {
			Brush brush = new SolidBrush(Color.White);
			Pen pen = new Pen(Color.Yellow);
			g.DrawLine(pen,
			           this.width/2,
			           0,
			           this.width/2,
			           this.height);
			g.DrawLine(pen,
			           0,
			           this.height/2,
			           this.width,
			           this.height/2);
			g.FillEllipse(brush,
			              this.x-this.size/2,
			              this.y-this.size/2,
			              this.size,
			              this.size
			             );
		}
		
		public void SetXY(int x, int y) {
			this.x=x;
			this.y=y;
		}
		
		public void SetWH(int width, int height) {
			this.width=width;
			this.height=height;
		}
		
		public void debugMidiValues() {
			System.Diagnostics.Debug.WriteLine("Width: " + this.width + " Height: " + this.height);
			System.Diagnostics.Debug.WriteLine("X: " + this.x + " Y: " + this.y);
		}
		
		public float GetMidiX(float max) {
			return bound((int)(max/this.width*this.x),0,max);
		}
		
		public float GetMidiY(float max) {
			return bound((int)(max/this.height*this.y),0,max);
		}
	}
}

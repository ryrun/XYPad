/*
 * Created by SharpDevelop.
 * User: Andreas
 * Date: 02.05.2014
 * Time: 18:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace XYPad
{
	/// <summary>
	/// Description of BufferedPanel.
	/// </summary>
	class BufferedPanel : Panel
	{
		public BufferedPanel()
		{
			this.DoubleBuffered = true;
		}
	}
}

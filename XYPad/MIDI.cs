/*
 * Created by SharpDevelop.
 * User: Andreas
 * Date: 02.05.2014
 * Time: 20:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;

namespace XYPad
{
	/// <summary>
	/// Description of MIDI.
	/// </summary>
	class MIDI { // native MIDI calls from WinMM.dll
		int handle = 0;
		int lastmidioutdevice = -1;
		protected delegate void MidiCallback(int handle, int msg, int instance, int param1, int param2);
    	[DllImport("winmm.dll")] private static extern int midiOutOpen(ref int handle, int deviceID, MidiCallback proc, int instance, int flags);
    	[DllImport("winmm.dll")] private static extern uint midiOutClose(int handle);
    	[DllImport("winmm.dll")] private static extern int midiOutShortMsg(int handle, int message);
    	[DllImport("winmm.dll", SetLastError = true)] private static extern UInt32 midiOutGetNumDevs();
    	[DllImport("winmm.dll")] private static extern UInt32 midiOutGetDevCaps(Int32 uDeviceID, ref MIDIOUTCAPS lpMidiOutCaps, UInt32 cbMidiOutCaps);
    	
    	[StructLayout(LayoutKind.Sequential)]
		struct MIDIOUTCAPS
		{
		    public UInt16 wMid;
		    public UInt16 wPid;
		    public UInt32 vDriverVersion;
		    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		    public string szPname;
		    public UInt16 wTechnology;
		    public UInt16 wVoices;
		    public UInt16 wNotes;
		    public UInt16 wChannelMask;
		    public UInt32 dwSupport;
		}
		
		public void refreshList(ComboBox list) {
			//clear combo list
			list.Items.Clear();
			//get count of midi out devices
			int dev = (int)midiOutGetNumDevs();
			//init struct for data
			MIDIOUTCAPS caps = new MIDIOUTCAPS();
			//step through list
			for(int i=0;i<dev;i++) {
				//get midi out devices infos
				midiOutGetDevCaps(i,ref caps, (UInt32)Marshal.SizeOf(caps));
				//add to combolist
				list.Items.Add(caps.szPname);
			}			
		}
    	
    	public void sendMidi(int midioutdevice, byte status,byte channel,byte data1,byte data2) {
			//list
			if( this.handle != 0 && lastmidioutdevice!=midioutdevice ) {
				midiOutClose(handle);
				handle=0;
			}
    		if( this.handle == 0 && midioutdevice>-1 ) {
				midiOutOpen(ref handle, midioutdevice, null, 0, 0);
			} 
    		int message = status << 4 | channel | data1<<8 | data2<<16;
    		if( this.handle != 0 ) {
    			lastmidioutdevice = midioutdevice;
    			midiOutShortMsg(this.handle, message );
    		}
    	}
  	} 
}

/*
 * SharpOS.ADC.X86/ADC.cs
 * N:SharpOS.ADC
 *
 * (C) 2007 William Lahti. This software is licensed under the terms of the
 * GNU General Public License.
 *
 * Author: William Lahti <xfurious@gmail.com>
 *
 */

using SharpOS;
using SharpOS.AOT;
using SharpOS.AOT.X86;
using SharpOS.AOT.IR;
using ADC = SharpOS.ADC;

namespace SharpOS.ADC.X86 {
	public unsafe class Architecture {
		/**
			<summary>
				Checks for compatibility with the current system, using 
				the most well-supported method possible. 
			</summary>
		*/
		public static bool CheckCompatibility ()
		{
			return true; // if we're running, we're at least 386.
		}

		public static void Setup ()
		{
			GDT.Setup ();
			PIC.Setup ();
			IDT.Setup ();
			PIT.Setup ();
		}
		
		/**
			<summary>
				Gets the ADC platform identifier.
			</summary>
		*/
		public static string GetCPU ()
		{
			return "x86";
		}
		
		public static string GetAuthor ()
		{
			return "The SharpOS Team";
		}
		
		public static string GetLayerName ()
		{
			return "SharpOS.ADC.X86";
		}
		
		public static int GetProcessorCount ()
		{
			return 0;
		}
		
		public static Processor *GetProcessors ()
		{
			return null; // TODO
		}
		
		public static EventRegisterStatus RegisterTimerEvent (uint func)
		{
			return PIT.RegisterTimerEvent (func);
		}

		/// <summary>
		///		Disable interrupts
		/// </summary>
		/// <remarks>
		/// This function should be made "inline" by the AOT
		/// </remarks>
		public static void DisableInterrupts()
		{
			Asm.CLI();
		}

		/// <summary>
		///		Enable interrupts
		/// </summary>
		/// <remarks>
		/// This function should be made "inline" by the AOT
		/// </remarks>
		public static void EnableInterrupts()
		{
			Asm.STI();
		}
	}
}
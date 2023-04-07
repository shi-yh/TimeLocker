using System;
using System.Runtime.InteropServices;

public class CppInterface
{
   [DllImport("DLlTest")]
   public static extern int Add(int a, int b);

   [DllImport("CLIDll")]
   public static extern IntPtr GenerateInvoke();

   [DllImport("CLIDll")]
   public static extern void ReleaseInvoke(IntPtr invoke);

}

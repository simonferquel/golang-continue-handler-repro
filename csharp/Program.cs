using System;
using System.Runtime.InteropServices;

namespace csharp
{
    class Program
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void NativeCallback(Int32 value);

        [DllImport("gosample.dll", CallingConvention =CallingConvention.Cdecl)]
        static extern void CallMeBack(IntPtr callbackPtr, Int32 value);

        static void Main(string[] args)
        {
            var callback = new NativeCallback(v =>
            {
                // setting a breakpoint here make go panic
                Console.WriteLine($"Value comming from go: {v}");
            });
            var funcPtr = Marshal.GetFunctionPointerForDelegate(callback);
            CallMeBack(funcPtr, 42);
        }
    }
}

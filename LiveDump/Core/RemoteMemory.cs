using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LiveDump
{
    public sealed class RemoteMemory
    {
 
        public int ProcessId
        {
            get;
            set;
        }
        public IntPtr ProcessHandle
        {
            get;
            set;
        }

        public bool UseFailSafeRead
        {
            get;
            set;
        }

        public RemoteMemory(int processId)
        {
            SetProcessHandle(processId);
        }

        public RemoteMemory(IntPtr hProcess)
        {
            ProcessId = -1;
            ProcessHandle = hProcess;
        }

        private void SetProcessHandle(int processId)
        {
            if (ProcessId != processId || ProcessHandle == IntPtr.Zero)
            {
                ProcessId = processId;
                if (ProcessHandle != IntPtr.Zero)
                    Close();
                EnsureHandle();
            }
        }

        private void EnsureHandle()
        {
            if (ProcessHandle == IntPtr.Zero && ProcessId != -1)
            {
                ProcessHandle = Native.OpenProcess(
                                    Native.ProcessAccessFlags.VMRead |
                                    Native.ProcessAccessFlags.VMWrite |
                                    Native.ProcessAccessFlags.VMOperation |
                                    Native.ProcessAccessFlags.QueryInformation, false,
                                    ProcessId);
            }
        }

        private static Dictionary<Type, int> CachedSizes = new Dictionary<Type, int>();

        private static int SizeOf(Type t)
        {
            int size;
            if (!CachedSizes.TryGetValue(t, out size))
                CachedSizes.Add(t, size = Marshal.SizeOf(t));
            return size;
        }

        private void ReadInternal(IntPtr address, IntPtr hBuffer, UIntPtr size, out UIntPtr bytesRead)
        {
            if (!Native.ReadProcessMemory(ProcessHandle, address,
                                          hBuffer, size, out bytesRead))
            {
                if (UseFailSafeRead)
                {
                    bytesRead = UIntPtr.Zero;
                    Native.ZeroMemory(hBuffer, size);
                }
                else
                    throw new AccessViolationException("Unable to read memory from the specified pointer.");

            }
            if (size != bytesRead && !UseFailSafeRead)
                throw new AccessViolationException("Unable to read entire buffer from the specified pointer.");
        }

        private void ReadInternal(IntPtr address, IntPtr hBuffer, UIntPtr size)
        {
            UIntPtr bytesRead;
            ReadInternal(address, hBuffer, size, out bytesRead);
        }


        public unsafe T[] ReadArray<T>(IntPtr address, int count)
        {
            EnsureHandle();

            // Direct byte copy, it's faster.
            var t = typeof(T);

            if (t == typeof(byte))
            {
                var arr = new byte[count];
                fixed (byte* hBuffer = arr)
                    ReadInternal(address, (IntPtr)hBuffer, (UIntPtr)count);
                return (T[])(object)arr;
            }
            else
            {
                var sz = SizeOf(t);
                var total = sz * count;
                var hBuffer = Marshal.AllocHGlobal(total);

                // Read the bytes.
                ReadInternal(address, hBuffer, (UIntPtr)total);

                var arr = new T[count];
                for (int i = 0; i < count; i++)
                    arr[i] = (T)Marshal.PtrToStructure(IntPtr.Add(hBuffer, i * sz), t);
                Marshal.FreeHGlobal(hBuffer);
                return arr;
            }
        }

        private IntPtr AllocateInternal(IntPtr preferred, long size,
                                        Native.MemoryProtection protectionFlags)
        {
            return Native.VirtualAllocEx(ProcessHandle, preferred, (UIntPtr)size,
                                         Native.AllocationType.Commit | Native.AllocationType.Reserve, protectionFlags);
        }

        public IntPtr Allocate(IntPtr preferred, long size, Native.MemoryProtection protectionFlags)
        {
            IntPtr allocatedMemory;
            if ((allocatedMemory = AllocateInternal(preferred, size, protectionFlags)) == IntPtr.Zero &&
                    preferred != IntPtr.Zero)
            {
                return Allocate(IntPtr.Zero, size, protectionFlags);
            }
            return allocatedMemory;
        }

        public void Close()
        {
            if (ProcessHandle != IntPtr.Zero)
            {
                Native.CloseHandle(ProcessHandle);
                ProcessHandle = IntPtr.Zero;
            }
        }
    }
}

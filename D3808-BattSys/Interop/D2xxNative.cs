using System;
using System.Runtime.InteropServices;

namespace D3808_BattSys.Interop
{
    public static class D2xxNative
    {
        // FT_STATUS is int, FT_HANDLE is IntPtr, DWORD is uint, UCHAR is byte

        [DllImport("ftd2xx.dll")]
        public static extern int FT_GetBitMode(IntPtr ftHandle, ref byte pucMode);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetBaudRate(IntPtr ftHandle, uint BaudRate);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetDataCharacteristics(IntPtr ftHandle, byte WordLength, byte StopBits, byte Parity);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetFlowControl(IntPtr ftHandle, ushort FlowControl, byte XonChar, byte XoffChar);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetDtr(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_ClrDtr(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetRts(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_ClrRts(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetBreakOn(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetBreakOff(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetEventNotification(IntPtr ftHandle, uint Mask, IntPtr Param);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_GetStatus(IntPtr ftHandle, ref uint RxBytes, ref uint TxBytes, ref uint EventDWord);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetChars(IntPtr ftHandle, byte EventChar, byte EventCharEnabled, byte ErrorChar, byte ErrorCharEnabled);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetTimeouts(IntPtr ftHandle, uint ReadTimeout, uint WriteTimeout);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_GetLatencyTimer(IntPtr ftHandle, ref byte Latency);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetLatencyTimer(IntPtr ftHandle, byte Latency);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_GetQueueStatus(IntPtr ftHandle, ref uint RxBytes);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_Purge(IntPtr ftHandle, uint Mask);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_ResetDevice(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetUSBParameters(IntPtr ftHandle, uint InTransferSize, uint OutTransferSize);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetResetPipeRetryCount(IntPtr ftHandle, uint Count);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_StopInTask(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_RestartInTask(IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_SetDeadmanTimeout(IntPtr ftHandle, uint DeadmanTimeout);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_Open(int deviceNumber, ref IntPtr ftHandle);

        [DllImport("ftd2xx.dll")]
        public static extern int FT_Close(IntPtr ftHandle);

        // Add more as needed from the D2XX Programmer's Guide
    }
}
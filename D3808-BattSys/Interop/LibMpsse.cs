using System;
using System.Runtime.InteropServices;

namespace D3808_BattSys.Interop
{
    public static class LibMpsse
    {
        private const string DllName = "libmpsse.dll";

        // FT_STATUS is typically an int
        public enum FT_STATUS : int
        {
            FT_OK = 0,
            FT_INVALID_HANDLE,
            FT_DEVICE_NOT_FOUND,
            FT_DEVICE_NOT_OPENED,
            FT_IO_ERROR,
            FT_INSUFFICIENT_RESOURCES,
            FT_INVALID_PARAMETER,
            FT_INVALID_BAUD_RATE,
            FT_DEVICE_NOT_OPENED_FOR_ERASE,
            FT_DEVICE_NOT_OPENED_FOR_WRITE,
            FT_FAILED_TO_WRITE_DEVICE,
            FT_EEPROM_READ_FAILED,
            FT_EEPROM_WRITE_FAILED,
            FT_EEPROM_ERASE_FAILED,
            FT_EEPROM_NOT_PRESENT,
            FT_EEPROM_NOT_PROGRAMMED,
            FT_INVALID_ARGS,
            FT_NOT_SUPPORTED,
            FT_OTHER_ERROR
        }

        // ChannelConfig struct
        [StructLayout(LayoutKind.Sequential)]
        public struct ChannelConfig
        {
            public uint ClockRate;
            public byte LatencyTimer;
            public uint Options;
        }

        // FT_DEVICE_LIST_INFO_NODE struct (for I2C_GetChannelInfo)
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct FT_DEVICE_LIST_INFO_NODE
        {
            public uint Flags;
            public uint Type;
            public uint ID;
            public uint LocId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string SerialNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string Description;
            public IntPtr ftHandle;
        }

        // I2C_GetNumChannels
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_STATUS I2C_GetNumChannels(ref uint numChannels);

        // I2C_GetChannelInfo
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_STATUS I2C_GetChannelInfo(
            uint index,
            ref FT_DEVICE_LIST_INFO_NODE chanInfo);

        // I2C_OpenChannel
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_STATUS I2C_OpenChannel(
            uint index,
            ref IntPtr handle);

        // I2C_InitChannel
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_STATUS I2C_InitChannel(
            IntPtr handle,
            ref ChannelConfig config);

        // I2C_DeviceRead
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_STATUS I2C_DeviceRead(
            IntPtr handle,
            uint deviceAddress,
            uint sizeToTransfer,
            [Out] byte[] buffer,
            ref uint sizeTransferred,
            uint options);

        // I2C_DeviceWrite
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_STATUS I2C_DeviceWrite(
            IntPtr handle,
            uint deviceAddress,
            uint sizeToTransfer,
            [In] byte[] buffer,
            ref uint sizeTransferred,
            uint options);

        // I2C_CloseChannel
        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern FT_STATUS I2C_CloseChannel(
            IntPtr handle);

        // Option flags (from AN_411 and header)
        public const uint I2C_TRANSFER_OPTIONS_START_BIT = 0x01;
        public const uint I2C_TRANSFER_OPTIONS_STOP_BIT = 0x02;
        public const uint I2C_TRANSFER_OPTIONS_BREAK_ON_NACK = 0x04;
        public const uint I2C_TRANSFER_OPTIONS_NACK_LAST_BYTE = 0x08;
        public const uint I2C_TRANSFER_OPTIONS_FAST_TRANSFER_BYTES = 0x10;
        public const uint I2C_TRANSFER_OPTIONS_FAST_TRANSFER_BITS = 0x20;
        public const uint I2C_TRANSFER_OPTIONS_FAST_TRANSFER = 0x30;
        public const uint I2C_TRANSFER_OPTIONS_NO_ADDRESS = 0x40;
    }
}
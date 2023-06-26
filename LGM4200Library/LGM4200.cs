using System;
using System.Runtime.InteropServices;

namespace LGM4200Library
{
    public class LGM4200
    {
        #region CONSTANTS

        #region system errors
        /// <summary>
        /// Command OK (Success)
        /// </summary>
        public const byte d_NO_ERROR = 0x00000000;
       
        #endregion
        #endregion

        #region EZPROXAPI.dll library
        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_OpenUSB", ExactSpelling = false, SetLastError = true)]
        //public static extern int CAS_OpenUSB([MarshalAs(UnmanagedType.LPArray)] byte[] Handle);  
        public static extern uint CAS_OpenUSB(ref uint Handle);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_CloseUSB", ExactSpelling = false, SetLastError = true)]
        public static extern uint CAS_CloseUSB(uint Handle);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_MifareHaltA", ExactSpelling = false, SetLastError = true)]
        public static extern int CAS_MifareHaltA(uint Handle2);

        [DllImport("EZPROXAPI.dll", EntryPoint = "GP_PackData", ExactSpelling = false, SetLastError = true)]
        public static extern void GP_PackData(string baSBu, int iLen, [MarshalAs(UnmanagedType.LPArray)] byte[] baTBuf);

        [DllImport("EZPROXAPI.dll", EntryPoint = "GP_UnpackData", ExactSpelling = false, SetLastError = true)]
        public static extern void GP_UnpackData([MarshalAs(UnmanagedType.LPArray)] byte[] baSBu, int iLen, [MarshalAs(UnmanagedType.LPArray)] byte[] baTBuf);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_MifareIncrement", ExactSpelling = false, SetLastError = true)]
        public static extern ulong CAS_MifareIncrement(uint Handle2, byte bNBlock, uint uiValue);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_MifareDecrement", ExactSpelling = false, SetLastError = true)]
        public static extern ulong CAS_MifareDecrement(uint Handle2, [MarshalAs(UnmanagedType.LPArray)] byte[] bNBlock, uint uiValue);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_Display", ExactSpelling = false, SetLastError = true)]
        //public static extern int CAS_Display([MarshalAs(UnmanagedType.LPArray)] byte[] Handle, int bFlag, int bX, int bY, String baMsgBuf, int uiSLen);
        public static extern uint CAS_Display(uint Handle2, int bFlag, int bX, int bY, String baMsgBuf, int uiSLen);

        //Get the API's phototype from the EZProxAPI.h, and modify it to use in the C#. For example :
        //	The original API definition is :
        //		extern ULONG WINAPI CAS_InitComm(IN ULONG PortNumber, IN BYTE bBaudRateIndex, OUT HANDLE *hHandle);
        //	Remove the IN and OUT, change the variable type definition by using the below mapping :
        //		ULONG	-> uint
        //		BYTE	-> byte
        //		long	-> int
        //	Add "public static" in the front, and remove WINAPI
        //	Final, the declaration in C# is 
        //		public static extern uint CAS_InitComm(uint PortNumber, byte bBaudRateIndex, uint *hHandle);

        [DllImport("EZProxAPI.dll")]
        public static extern uint CAS_InitComm(uint PortNumber, byte bBaudRateIndex, ref uint hHandle);
        [DllImport("EZProxAPI.dll")]
        public static extern uint CAS_TimeOut_Set(uint ulMS);
        [DllImport("EZProxAPI.dll")]
        public static extern uint CAS_Poll(uint hHandle);
        [DllImport("EZProxAPI.dll")]
        public static extern uint CAS_Sound(uint hHandle, uint usFreq, uint usDuration);

        [DllImport("EZProxAPI.dll")]
        public static extern uint CAS_TypeA_ActiveIdle(uint Handle2, byte bBaudRate, [MarshalAs(UnmanagedType.LPArray)] byte[] baATQA, [MarshalAs(UnmanagedType.LPArray)] byte[] bSAK, [MarshalAs(UnmanagedType.LPArray)] byte[] bCSNLen, [MarshalAs(UnmanagedType.LPArray)] byte[] baCSN);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_MifareLoadKey", ExactSpelling = false, SetLastError = true)]
        public static extern uint CAS_MifareLoadKey(uint hHandle, [MarshalAs(UnmanagedType.LPArray)] byte[] baRBuf);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_MifareAuth", ExactSpelling = false, SetLastError = true)]
        public static extern uint CAS_MifareAuth(uint hHandle, byte bKeyType, byte bNBlock, [MarshalAs(UnmanagedType.LPArray)] byte[] baCSN);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_MifareReadBlock", ExactSpelling = false, SetLastError = true)]
        public static extern uint CAS_MifareReadBlock(uint hHandle, byte bNBlock, [MarshalAs(UnmanagedType.LPArray)] byte[] baData);

        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_MifareWriteBlock", ExactSpelling = false, SetLastError = true)]
        public static extern uint CAS_MifareWriteBlock(uint hHandle, byte bNBlock, [MarshalAs(UnmanagedType.LPArray)] byte[] baData);


        [DllImport("EZPROXAPI.dll", EntryPoint = "CAS_SetLCDBackLight", ExactSpelling = false, SetLastError = true)]
        public static extern uint CAS_SetLCDBackLight(uint hHandle, int bOnOff);
        #endregion
    }
}

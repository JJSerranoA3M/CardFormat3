using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CardFormat3
{
    public class Evolis
    {
        #region Constants

        private static ushort BUFFER_SIZE = 512;

        public const short MI_OK = 0;
        public const short MI_CHK_OK = 0;
        public const short MI_CRC_ZERO = 0;

        public const short MI_NOTAGERR = -1;
        public const short MI_CHK_FAILED = -1;
        public const short MI_CRCERR = -2;
        public const short MI_CHK_COMPERR = -2;
        public const short MI_EMPTY = -3;
        public const short MI_AUTHERR = -4;
        public const short MI_PARITYERR = -5;
        public const short MI_CODEERR = -6;

        public const short MI_SERNRERR = -8;
        public const short MI_KEYERR = -9;
        public const short MI_NOTAUTHERR = -10;
        public const short MI_BITCOUNTERR = -11;
        public const short MI_BYTECOUNTERR = -12;
        public const short MI_IDLE = -13;
        public const short MI_TRANSERR = -14;
        public const short MI_WRITEERR = -15;
        public const short MI_INCRERR = -16;
        public const short MI_DECRERR = -17;
        public const short MI_READERR = -18;
        public const short MI_OVFLERR = -19;
        public const short MI_POLLING = -20;
        public const short MI_FRAMINGERR = -21;
        public const short MI_ACCESSERR = -22;
        public const short MI_UNKNOWN_COMMAND = -23;
        public const short MI_COLLERR = -24;
        public const short MI_RESETERR = -25;
        public const short MI_INITERR = -25;
        public const short MI_INTERFACEERR = -26;
        public const short MI_ACCESSTIMEOUT = -27;
        public const short MI_NOBITWISEANTICOLL = -28;
        public const short MI_QUIT = -30;
        public const short MI_CODINGERR = -31;
        public const short MI_SENDBYTENR = -51;
        public const short MI_CASCLEVEX = -52;
        public const short MI_SENDBUF_OVERFLOW = -53;
        public const short MI_BAUDRATE_NOT_SUPPORTED = -54;
        public const short MI_SAME_BAUDRATE_REQUIRED = -55;
        public const short MI_WRONG_PARAMETER_VALUE = -60;

        // ICODE1 error codes:
        public const short I1_OK = 0;
        public const short I1_NO_ERR = 0;

        public const short I1_WRONGPARAM = -61;
        public const short I1_NYIMPLEMENTED = -62;
        public const short I1_TSREADY = -63;

        public const short I1_TIMEOUT = -70;
        public const short I1_NOWRITE = -71;
        public const short I1_NOHALT = -72;
        public const short I1_MISS_ANTICOLL = -73;

        public const short I1_COMM_ABORT = -82;

        // MV EV700 error codes:
        public const short MI_BREAK = -99;
        public const short MI_NY_IMPLEMENTED = -100;
        public const short MI_NO_MFRC = -101;
        public const short MI_MFRC_NOTAUTH = -102;
        public const short MI_WRONG_DES_MODE = -103;
        public const short MI_HOST_AUTH_FAILED = -104;

        public const short MI_WRONG_LOAD_MODE = -106;
        public const short MI_WRONG_DESKEY = -107;
        public const short MI_MKLOAD_FAILED = -108;
        public const short MI_FIFOERR = -109;
        public const short MI_WRONG_ADDR = -110;
        public const short MI_DESKEYLOAD_FAILED = -111;
        public const short MI_RECBUF_OVERFLOW = -112;
        public const short MI_WRONG_SEL_CNT = -114;

        public const short MI_WRONG_TEST_MODE = -117;
        public const short MI_TEST_FAILED = -118;
        public const short MI_TOC_ERROR = -119;
        public const short MI_COMM_ABORT = -120;
        public const short MI_INVALID_BASE = -121;
        public const short MI_MFRC_RESET = -122;
        public const short MI_WRONG_VALUE = -123;
        public const short MI_VALERR = -124;
        public const short MI_WRONG_LENGTH = -125;

        // T=CL error codes:
        public const short TCL_OK = 0;
        public const short TCL_NOTAGERR = -131;
        public const short TCL_CRCERR = -132;
        public const short TCL_PRITYERR = -133;
        public const short TCL_OTHERERR = -134;
        public const short TCL_SERNRERR = -135;
        public const short TCL_BITCOUNTERR = -136;
        public const short TCL_POLLING = -137;
        public const short TCL_RF_CHANNEL = -138;
        public const short TCL_MULTACT_DISABLED = -139;
        public const short TCL_MULTACT_ENABLED = -140;
        public const short TCL_CID_NOT_ACTIVE = -141;
        public const short TCL_BITANTICOLL = -142;
        public const short TCL_UIDLEN = -143;
        public const short TCL_CIDINVALID = -144;
        public const short TCL_ATSLEN = -145;
        public const short TCL_NO_ATS_AVAILABLE = -146;
        public const short TCL_ATS_ERROR = -147;
        public const short TCL_FATAL_PROTOCOL = -148;
        public const short TCL_RECBUF_OVERFLOW = -149;
        public const short TCL_SENDBYTENR = -150;
        public const short TCL_TRANSMERR_HALTED = -151;
        public const short TCL_TRANSMERR_NOTAG = -152;
        public const short TCL_BAUDRATE_NOT_SUPPORTED_PICC = -153;
        public const short TCL_CID_NOT_SUPPORTED = -154;
        public const short TCL_NAD_NOT_SUPPORTED = -155;
        public const short TCL_PROTOCOL_NOT_SUPPORTED = -156;
        public const short TCL_PPS_FORMAT = -157;
        public const short TCL_ERROR = -158;
        public const short TCL_NADINVALID = -159;
        public const short TCL_OTHER_ERR = -161;
        public const short TCL_BAUDRATE_NOT_SUPPORTED_PCD = -162;
        public const short TCL_CID_ACTIVE = -163;

        // SpringCard specific:
        public const short MI_FUNCTION_NOT_AVAILABLE = -240;
        public const short MI_SER_LENGTH_ERR = -241;
        public const short MI_SER_CHECKSUM_ERR = -242;
        public const short MI_SER_PROTO_ERR = -243;
        public const short MI_SER_PROTO_NAK = -244;
        public const short MI_SER_ACCESS_ERR = -245;
        public const short MI_SER_TIMEOUT_ERR = -246;
        public const short MI_SER_NORESP_ERR = -247;
        public const short MI_LIB_CALL_ERROR = -248;
        public const short MI_OUT_OF_MEMORY_ERROR = -249;
        public const short MI_FILE_ACCESS_ERROR = -250;




        // SPROX_ReaderGetDeviceSettings/ReaderSetDeviceSettings constantes:
        public const int SPROX_SETTINGS_PROTOCOL_MASK = 0x00000003;
        public const int SPROX_SETTINGS_PROTOCOL_OSI = 0x00000000;
        public const int SPROX_SETTINGS_PROTOCOL_ASCII = 0x00000001;
        public const int SPROX_SETTINGS_PROTOCOL_BIN = 0x00000002;
        public const int SPROX_SETTINGS_PROTOCOL_BUS = 0x00000003;

        public const int SPROX_SETTINGS_HARDWARE_CTRL = 0x00000004;

        public const int SPROX_SETTINGS_BAUDRATE_MASK = 0x00000008;
        public const int SPROX_SETTINGS_BAUDRATE_38400 = 0x00000000;
        public const int SPROX_SETTINGS_BAUDRATE_115200 = 0x00000008;

        public const int SPROX_SETTINGS_CHANNEL_MASK = 0x00000060;
        public const int SPROX_SETTINGS_CHANNEL_RS232 = 0x00000000;
        public const int SPROX_SETTINGS_CHANNEL_RS485 = 0x00000020;
        public const int SPROX_SETTINGS_CHANNEL_USB = 0x00000040;
        public const int SPROX_SETTINGS_CHANNEL_TCP = 0x00000060;

        public const int SPROX_SETTINGS_FORCE_CHANNEL_RS485 = 0x00000020;
        public const int SPROX_SETTINGS_FORCE_BAUDRATE = 0x00000010;
        public const int SPROX_SETTINGS_FORCE_PROTOCOL = 0x00000004;

        //MifStUpdateAccessBlock constantes:
        public const byte ACC_AUTH_NORMAL = 0x03;
        public const byte ACC_AUTH_TRANSPORT = 0x01;
        public const byte ACC_BLOCK_COUNT = 0x06;
        public const byte ACC_BLOCK_VALUE = 0x04;

        //MifLoadKey constantes:
        public const byte KEY_A = 0x41; // 'A'
        public const byte KEY_B = 0x42; // 'B'

        // MifLastAuthKey constantes:
        public const byte MIF_RAM_KEY = 0x80;
        public const byte MIF_E2_KEY = 0x40;
        public const byte MIF_CODED_KEY = 0xC0;
        public const byte MIF_KEY_A = 0x00;
        public const byte MIF_KEY_B = 0x20;

        #endregion Constants

        #region Helpers
        //[DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_GetErrorMessageW")]
        //private static extern unsafe char* GetErrorMessageW(short rc);

        //public static unsafe string GetErrorMessage(short rc)
        //{
        //    char* msg = GetErrorMessageW(rc);
        //    return new string(msg);
        //}

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ArrayToStringW")]
        public static extern short ArrayToString(char[] str, byte[] buffer, ushort size);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_StringToArrayW")]
        public static extern short ArrayToString(byte[] buffer, char[] str, ushort size);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_StrLenW")]
        public static extern ushort StrLen(char[] str);

        #endregion Helpers

        #region Library
        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_GetLibraryW")]
        private static extern short GetLibraryW(char[] library, ushort len);

        public static string GetLibrary()
        {
            short rc;
            char[] buffer = new char[BUFFER_SIZE];
            rc = GetLibraryW(buffer, BUFFER_SIZE);
            if (rc != MI_OK)
                return "";
            else
                return new string(buffer);
        }
        #endregion Library

        #region ReaderAccess
        [DllImport("springprox.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderOpenW")]
        private static extern short ReaderOpenW(char[] device);
        public static short ReaderOpen(string device)
        {
            return ReaderOpenW(string_to_pchar(device));
        }

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderClose")]
        public static extern short ReaderClose();

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderDeactivate")]
        public static extern short ReaderDeactivate();

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderActivate")]
        public static extern short ReaderActivate();

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderGetDeviceW")]
        private static extern short ReaderGetDeviceW(char[] device, ushort len);

        public static string ReaderGetDevice()
        {
            short rc;
            char[] buffer = new char[BUFFER_SIZE];

            rc = ReaderGetDeviceW(buffer, BUFFER_SIZE);
            if (rc != MI_OK)
                return "";
            else
                return new string(buffer);
        }

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderGetFirmwareW")]
        private static extern short ReaderGetFirmwareW(char[] firmware, ushort len);

        public static string ReaderGetFirmware()
        {
            short rc;
            char[] buffer = new char[BUFFER_SIZE];

            rc = ReaderGetFirmwareW(buffer, BUFFER_SIZE);
            if (rc != MI_OK)
                return "";
            else
                return new string(buffer);
        }

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderGetFeatures")]
        public static extern short ReaderGetFeatures(ref uint features);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderGetDeviceSettings")]
        public static extern short ReaderGetDeviceSettings(ref uint settings);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderSetDeviceSettings")]
        public static extern short ReaderSetDeviceSettings(uint settings);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderReset")]
        public static extern short ReaderReset();

        #endregion ReaderAccess

        #region Reader Advanced configuration and Test


        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderGetConsts")]
        public static extern short ReaderGetConsts(ref uint consts);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderSetConsts")]
        public static extern short ReaderSetConsts(uint consts);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderGetConstsEx")]
        public static extern short ReaderGetConstsEx(byte ident, byte[] data, ref ushort datalen);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderSetConstsEx")]
        public static extern short ReaderSetConstsEx(byte ident, byte[] data, ushort datalen);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ReaderGetRc500Id")]
        public static extern short ReaderGetRc500Id(byte[] rc500_type, byte[] rc500_snr);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Echo")]
        public static extern short Echo(ushort len);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ControlEx")]
        public static extern short ControlEx(byte[] send_buffer, ushort send_len, byte[] recv_buffer, ref ushort recv_len);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Function")]
        public static extern short ControlEx(byte cmd_code, byte[] send_buffer, ushort send_len, byte[] recv_buffer, ref ushort recv_len);

        #endregion Reader Advanced configuration and Test

        #region Reader I/Os

        // ControlLed/ControlLedY constantes:
        public const byte LED_OFF = 0x00;
        public const byte LED_ON = 0x01;
        public const byte LED_BLINK_SLOW = 0x02;
        public const byte LED_AUTO = 0x03;
        public const byte LED_BLINK_FAST = 0x04;
        public const byte LED_HEART_BEAT = 0x05;
        public const byte LED_BLINK_SLOW_INV = 0x06;
        public const byte LED_BLINK_FAST_INV = 0x07;
        public const byte LED_HEART_BEAT_INV = 0x08;


        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ControlLed")]
        public static extern short ControlLed(byte led_r, byte led_g);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ControlLedY")]
        public static extern short ControlLed(byte led_r, byte led_g, byte led_y);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ControlBuzzer")]
        public static extern short ControlBuzzer(ushort duration_ms);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_ControlUserIO")]
        private static extern short ControlUserIO(byte is_output, byte out_value, ref byte in_value);

        public static short SetUserIO(bool out_value)
        {
            byte val, dummy = 0;

            if (out_value)
                val = 1;
            else
                val = 0;
            return ControlUserIO(1, val, ref dummy);
        }

        public static short GetUserIO(ref bool in_value)
        {
            byte val = 0;
            short rc;

            rc = ControlUserIO(0, 1, ref val);
            if (val > 0)
                in_value = true;
            else
                in_value = false;
            return rc;
        }


        #endregion Reader I/Os

        #region Polling and RF field control

        [DllImport("springprox.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "SPROX_ControlRF")]
        public static extern short ControlRF(byte mode);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_SetConfig")]
        public static extern short SetConfig(byte mode);

        public const byte CFG_MODE_ISO_14443_A = 0x01;
        public const byte CFG_MODE_ISO_14443_B = 0x02;
        public const byte CFG_MODE_ISO_15693_STD = 0x03;
        public const byte CFG_MODE_ISO_15693_FAST = 0x04;
        public const byte CFG_MODE_ISO_ICODE1_STD = 0x05;
        public const byte CFG_MODE_ISO_ICODE1_FAST = 0x06;
        public const byte CFG_MODE_ISO_14443_Bi = 0x0C;

        [DllImport("springprox.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "SPROX_Find")]
        public static extern short Find(ushort want_protos, ref ushort got_proto, byte[] uid, ref byte uidlen);

        public const ushort PROTO_14443_A = 0x0001;
        public const ushort PROTO_14443_B = 0x0002;
        public const ushort PROTO_14443_Bi = 0x0080;
        public const ushort PROTO_15693 = 0x0004;
        public const ushort PROTO_ICODE1 = 0x0008;
        public const ushort PROTO_MEM_ST = 0x0020;
        public const ushort PROTO_MEM_ASK = 0x0040;

        #endregion Polling

        #region TypeA

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_A_SelectAny")]
        public static extern short A_SelectAny(byte[] atq,
                                               byte[] snr,
                                               ref byte
                                               snrlen,
                                               byte[] sak);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_A_SelectIdle")]
        public static extern short
            A_SelectIdle(byte[] atq, byte[] snr, ref byte snrlen, byte[] sak);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_A_SelectAgain")]
        public static extern short
            A_SelectAgain(byte[] snr, byte snrlen, byte[] sak);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_A_Halt")]
        public static extern short A_Halt();

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_A_Exchange")]
        public static extern short
            A_Exchange(byte[] send_buffer, ushort send_len, byte[] recv_buffer,
            ref ushort recv_len, byte append_crc, ushort timeout);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclA_ActivateAny")]
        public static extern short
            TclA_ActivateAny(byte[] atq, byte[] snr, ref byte snrlen, byte[] sak);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclA_ActivateIdle")]
        public static extern short
            TclA_ActivateIdle(byte[] atq, byte[] snr, ref byte snrlen, byte[] sak);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclA_ActivateAgain")]
        public static extern short
            TclA_ActivateAgain(byte[] snr, byte snrlen, byte[] sak);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclA_Halt")]
        public static extern short TclA_Halt();

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclA_Deselect")]
        public static extern short TclA_Deselect(byte
                                                 cid);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclA_GetAts")]
        public static extern short TclA_GetAts(byte cid,
                                               byte[] ats,
                                               ref byte
                                               atslen);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclA_Pps")]
        public static extern short TclA_Pps(byte cid,
                                            byte dsi,
                                            byte dri);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclA_Exchange")]
        public static extern short TclA_Exchange(byte
                                                 fsci,
                                                 byte
                                                 cid,
                                                 byte
                                                 nad,
                                                 byte
                                                 [] send_buffer,
                                                 ushort
                                                 send_len,
                                                 byte
                                                 [] recv_buffer,
                                                 ref
                                                                       ushort
                                                 recv_len);

        #endregion TypeA

        #region TypeB

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_B_SelectAny")]
        public static extern short B_SelectAny(byte afi,
                                               byte[] atq);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_B_SelectIdle")]
        public static extern short B_SelectIdle(byte afi,
                                                byte
                                                [] atq);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_B_Halt")]
        public static extern short B_Halt(byte[] pupi);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_B_Exchange")]
        public static extern short
            B_Exchange(byte[] send_buffer, ushort send_len, byte[] recv_buffer,
            ref ushort recv_len, byte append_crc, ushort timeout);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclB_ActivateAny")]
        public static extern short
            TclB_ActivateAny(byte afi, byte[] atq);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclB_ActivateIdle")]
        public static extern short
            TclB_ActivateIdle(byte afi, byte[] atq);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclB_Halt")]
        public static extern short TclB_Halt(byte[] pupi);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclB_Deselect")]
        public static extern short TclB_Deselect(byte
                                                 cid);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclB_Attrib")]
        public static extern short TclB_Attrib(byte[] pupi,
                                               byte cid);

        [DllImport
           ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
           "SPROX_TclB_AttribEx")]
        public static extern short TclB_Attrib(byte[] pupi,
            byte cid,
            byte[] ats,
            ref byte
            atslen);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_TclB_Exchange")]
        public static extern short TclB_Exchange(byte
                                                 fsci,
                                                 byte
                                                 cid,
                                                 byte
                                                 nad,
                                                 byte
                                                 [] send_buffer,
                                                 ushort
                                                 send_len,
                                                 byte
                                                 [] recv_buffer,
                                                 ref
                                                                       ushort
                                                 recv_len);

        #endregion TypeB

        #region T=CL

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_Tcl_Exchange")]
        public static extern short Tcl_Exchange(byte cid,
                                                byte
                                                [] send_buffer,
                                                ushort
                                                send_len,
                                                byte
                                                [] recv_buffer,
                                                ref
                                                                     ushort
                                                recv_len);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_Tcl_ExchangeNad")]
        public static extern short Tcl_Exchange(byte
                                                cid,
                                                byte
                                                nad,
                                                byte
                                                [] send_buffer,
                                                ushort
                                                send_len,
                                                byte
                                                [] recv_buffer,
                                                ref
                                                                        ushort
                                                recv_len);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_Tcl_Deselect")]
        public static extern short Tcl_Deselect(byte
                                                cid);

        #endregion T=CL

        #region Mifare
        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStSelectAny")]
        public static extern short
            MifStSelectAny(byte[] snr, byte[] atq, byte[] sak);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStSelectIdle")]
        public static extern short
            MifStSelectIdle(byte[] snr, byte[] atq, byte[] sak);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStSelectAgain")]
        public static extern short
            MifStSelectAgain(byte[] snr);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStHalt")]
        public static extern short MifStHalt();

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifRead")]
        public static extern short MifRead(byte[] snr,
                                           byte addr,
                                           byte[] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifWrite")]
        public static extern short MifWrite(byte[] snr,
                                            byte addr,
                                            byte[] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifWrite4")]
        public static extern short MifWrite4(byte[] snr,
                                             byte addr,
                                             byte[] data);

        [DllImport
         ("springprox.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStReadBlock")]
        public static extern short
            MifStReadBlock(byte[] snr, byte bloc, byte[] data, byte[] key);

        [DllImport
         ("springprox.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStWriteBlock")]
        public static extern short
            MifStWriteBlock(byte[] snr, byte bloc, byte[] data, byte[] key);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStReadSector")]
        public static extern short
            MifStReadSector(byte[] snr, byte sect, byte[] data, byte[] key);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStWriteSector")]
        public static extern short
            MifStWriteSector(byte[] snr, byte sect, byte[] data, byte[] key);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStReadTag768")]
        public static extern short
            MifStReadTag768(byte[] snr, ref short sectors, byte[] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStWriteTag768")]
        public static extern short
            MifStWriteTag768(byte[] snr, ref short sectors, byte[] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStUpdateAccessBlock")]
        public static extern short
            MifStUpdateAccessBlock(byte[] snr, byte sect, byte[] old_key, byte[] new_key_A,
            byte[] new_key_B, byte ac0, byte ac1, byte ac2, byte ac3);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifLoadKey")]
        public static extern short MifLoadKey(int eeprom,
                                              byte
                                              key_type,
                                              byte key_num,
                                              byte
                                              [] key_data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifLastAuthKey")]
        public static extern short MifLastAuthKey(ref
                                                                         byte
                                                  info);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStDecrementCounter")]
        public static extern short
            MifStDecrementCounter(byte[] snr, byte bloc, int value, byte[] key);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStWriteCounter")]
        public static extern short
            MifStWriteCounter(byte[] snr, byte bloc, int value, byte[] key);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MifStReadCounter")]
        public static extern short
            MifStReadCounter(byte[] snr, byte bloc, ref int value, byte[] key);

        #endregion Mifare

        #region RC500

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "ReadRIC")]
        public static extern short ReadRIC(byte reg, ref byte val);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "WriteRIC")]
        public static extern short WriteRIC(byte reg, byte val);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccExchangeBlock_A")]
        public static extern short
            Mf500PiccExchangeBlock_A(byte[] send_data, short send_bytelen, byte[] rec_data,
            ref short rec_bytelen, byte append_crc, short timeout);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccExchangeBlock_B")]
        public static extern short
            Mf500PiccExchangeBlock_B(byte[] send_data, short send_bytelen, byte[] rec_data,
            ref short rec_bytelen, byte append_crc, short timeout);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccAuthKey")]
        public static extern short Mf500PiccAuthKey(byte
                                                    auth_mode,
                                                    byte
                                                    [] snr,
                                                    byte
                                                    [] keys,
                                                    byte
                                                    addr);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccRead")]
        public static extern short Mf500PiccRead(byte addr,
                                                 byte[] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccCommonRead")]
        public static extern short
            Mf500PiccCommonRead(byte cmd, byte addr, byte datalen, byte[] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccWrite")]
        public static extern short Mf500PiccWrite(byte addr,
                                                  byte
                                                  [] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccWrite4")]
        public static extern short Mf500PiccWrite4(byte
                                                   addr,
                                                   byte
                                                   [] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccCommonWrite")]
        public static extern short
            Mf500PiccCommonWrite(byte cmd, byte addr, byte datalen, byte[] data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccValue")]
        public static extern short Mf500PiccValue(byte
                                                  dd_mode,
                                                  byte addr,
                                                  byte
                                                  [] trans_value,
                                                  byte
                                                  trans_data);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccValueDebit")]
        public static extern short
            Mf500PiccValueDebit(byte dd_mode, byte addr, byte[] trans_value);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccHalt")]
        public static extern short Mf500PiccHalt();

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "Mf500PiccActivateIdle")]
        public static extern short
            Mf500PiccActivateIdle(byte br, byte[] atq, byte[] sak, byte[] uid,
            ref byte uid_len);
        #endregion RC500

        #region Crypto

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_ComputeIso14443ACrc")]
        public static extern ushort
            ComputeIso14443ACrc(byte[] crc, byte[] buffer, ushort size);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_ComputeIso14443BCrc")]
        public static extern ushort
            ComputeIso14443BCrc(byte[] crc, byte[] buffer, ushort size);

        #endregion Crypto

        #region Contact smartcard and SAMs

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Card_PowerUp_Ex")]
        public static extern short Card_PowerUp_Ex(byte slot, byte config, byte[] atr, ref ushort atr_len);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Card_PowerUp")]
        public static extern short Card_PowerUp(byte slot, byte unused, byte[] atr, ref ushort atr_len);

        //    [DllImport ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Card_PowerUp_Auto")]
        //    public static extern short Card_PowerUp_Auto(byte slot, byte[]atr, ref ushort atr_len);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Card_PowerDown")]
        public static extern short Card_PowerDown(byte slot);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Card_Exchange")]
        public static extern short Card_Exchange(byte slot, byte[] send_buffer, ushort send_len, byte[] recv_buffer, ref ushort recv_len);

        [DllImport("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Card_Status")]
        public static extern short Card_Status(byte slot, ref byte stat, ref byte type, byte[] config);

        //    [DllImport ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Card_SetConfig")]
        //    public static extern short Card_SetConfig(byte slot, byte mode, byte type);

        //    [DllImport ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint = "SPROX_Card_GetConfig")]
        //    public static extern short Card_SetConfig(byte slot, ref byte mode, ref byte type);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_Card_GetFirmwareW")]
        private static extern short
            Card_GetFirmwareW(char[] firmware, ushort len);
        public static string Card_GetFirmware()
        {
            short rc;
            char[] buffer = new char[BUFFER_SIZE];

            rc = Card_GetFirmwareW(buffer, BUFFER_SIZE);
            if (rc != MI_OK)
                return null;
            else
                return new string(buffer);
        }

        #endregion Cards

        #region MorphoSmart CBM (SpringBIO)

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MSO_Exchange")]
        public static extern short
            MSO_ExchangeEx(byte[] send_buffer, ushort send_len, byte[] recv_buffer,
            ref ushort recv_len, uint timeout, ref byte async);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MSO_OpenW")]
        public static extern short
            MSO_Open(char[] mso_product, char[] mso_firmware, char[] mso_sensor);

        [DllImport
         ("springprox.dll", CharSet = CharSet.Unicode, EntryPoint =
          "SPROX_MSO_Close")]
        public static extern short MSO_Close();

        #endregion MSO CBM

        #region Utility
        private static char[] string_to_pchar(string s)
        {
            char[] t;
            char[] r;
            int l;

            if (s == null)
                return null;
            l = s.Length;
            t = s.ToCharArray();
            if (t == null)
                return null;
            r = new char[l + 1];

            Array.Copy(t, 0, r, 0, l);
            r[l] = '\0';
            return r;
        }
        #endregion Utility


        //Declaration of Dll Function
        [DllImport("iomem.dll", EntryPoint = "_OpenPebble@4")]
        public static extern IntPtr OpenPebble(
            string pPrinterName);

        [DllImport("iomem.dll", EntryPoint = "_ClosePebble@4")]
        public static extern bool ClosePebble(
            IntPtr hPrinter);

        [DllImport("iomem.dll", EntryPoint = "_ReadPebble@16")]
        public static extern bool ReadPebble(
            IntPtr hPrinter,
            IntPtr answer,
            Int32 cbAns,
            ref UInt32 lpNumberOfBytesRead);

        [DllImport("iomem.dll", EntryPoint = "_WritePebble@12")]
        public static extern bool WritePebble(
            IntPtr hPrinter,
            string cde,
            Int32 cdNeeded);

        [DllImport("iomem.dll", EntryPoint = "_GetIomemVersion@4")]
        public static extern bool GetIomemVersion(
            IntPtr version);

        [DllImport("iomem.dll", EntryPoint = "_GetTimeout@0")]
        public static extern Int32 GetTimeout();

        [DllImport("iomem.dll", EntryPoint = "_SetTimeout@4")]
        public static extern bool SetTimeout(
            Int32 Timeout);

        [DllImport("iomem.dll", EntryPoint = "_GetStatusEvo@8")]
        public static extern bool GetStatusEvo(
            IntPtr hPrinter,
            ref UInt32 lpNumberOfBytesRead);

        [DllImport("winspool.Drv", EntryPoint = "GetPrinterA", SetLastError = true,
        CharSet = CharSet.Ansi, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        private static extern bool GetPrinter(IntPtr hPrinter, Int32 dwLevel,
        IntPtr pPrinter, Int32 dwBuf, out Int32 dwNeeded);

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA",
        SetLastError = true, CharSet = CharSet.Ansi,
        ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool
            OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter,
            out IntPtr hPrinter, ref PRINTER_DEFAULTS pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter",
                SetLastError = true, CharSet = CharSet.Ansi,
                ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool
            ClosePrinter(IntPtr hPrinter);

        #region "Data structure"
        [StructLayout(LayoutKind.Sequential)]
        public struct PRINTER_DEFAULTS
        {
            public int pDatatype;
            public int pDevMode;
            public int DesiredAccess;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct PRINTER_INFO_2
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pServerName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrinterName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pShareName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPortName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDriverName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pComment;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pLocation;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pSepFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pPrintProcessor;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDatatype;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pParameters;
            public IntPtr pSecurityDescriptor;
            public Int32 Attributes;
            public Int32 Priority;
            public Int32 DefaultPriority;
            public Int32 StartTime;
            public Int32 UntilTime;
            public Int32 Status;
            public Int32 cJobs;
            public Int32 AveragePPM;
        }
        #endregion
        private const int PRINTER_ACCESS_ADMINISTER = 0x4;
        private const int PRINTER_ACCESS_USE = 0x8;
        private const int STANDARD_RIGHTS_REQUIRED = 0xF0000;
        private const int PRINTER_ALL_ACCESS =
        (STANDARD_RIGHTS_REQUIRED | PRINTER_ACCESS_ADMINISTER
        | PRINTER_ACCESS_USE);

        private string answer;
        public string answerError;
        private string cde;
        // private IntPtr DwdCde;
        private Int32 cdeLen;
        private IntPtr hPrinter;
        private UInt32 nbBytesRead;
        private string _printerName;
        private string cdeTrack;

        private string[] writeDataTrack = new string[4];
        private string[] statusTrack = new string[4];
        private string[] DataToWriteOnTrack = new string[4];

        //Parametros de la codificacion
        private string _track1 = ""; //texto Pista 1
        private string _track2 = ""; //texto Pista 2
        private string _track3 = ""; //texto Pista 3
        private string _coercitividad = "HICO"; //Cooercitividad

        #region Recibimos el texto y la coercitividad
        public string printerName
        {
            get
            {
                return _printerName;
            }
            set
            {
                _printerName = value;
            }
        }
        public string track1
        {
            get
            {
                return _track1;
            }
            set
            {
                _track1 = value;
                SetDownloadData(value, 1);
            }
        }
        public string track2
        {
            get
            {
                return _track2;
            }
            set
            {
                _track2 = value;
                SetDownloadData(value, 2);
            }
        }
        public string track3
        {
            get
            {
                return _track3;
            }
            set
            {
                _track3 = value;
                SetDownloadData(value, 3);
            }
        }
        public string coercitividad
        {
            get
            {
                return _coercitividad;
            }
            set
            {
                _coercitividad = value;
            }
        }
        #endregion
        /// <summary>
        /// Write the three magnetic tracks.
        /// Magnetic tracks data has to be set through CMag class
        /// </summary>
        /// <returns> True: error</returns>
        /// <returns> False: done</returns>
        public bool WriteTracks()
        {
            bool bStatus = true;

            string command;

            if (OpenEvoPrinter() != IntPtr.Zero)
            {
                DoAction("\x1bPem;2\x0d", 2000, ref bStatus);
                DoAction("\x1bSs\x0d", 2000, ref bStatus);

                if (coercitividad == "HICO") //Especificamos Coercitividad
                    DoAction("\x1bPmc;h\x0d", 2000, ref bStatus);
                else
                    DoAction("\x1bPmc;l\x0d", 2000, ref bStatus);

                gsTimeout = 45000;
                for (int i = 1; i < 4; i++)
                {
                    command = GetDownloadCdeTrack(i);
                    if (command != string.Empty)
                    {
                        SetCde = command;
                        if (!WRPrinterOK(ref bStatus))
                        {
                            bStatus = false;
                            SetStatusCdeTrack(getLastAnswer, i);
                        }
                        else
                        {
                            SetStatusCdeTrack("OK", i);
                        }
                    }
                }
                if (bStatus)
                {
                    command = WriteMagTracks();
                    if (command != string.Empty)
                    {
                        SetCde = command;
                        if (!WRPrinterOK(ref bStatus))
                        {
                            bStatus = false;
                        }
                    }
                }

                DoAction("\x1bPem;0\x0d", 2000, ref bStatus); //La impresora gestiona la recuperacion de errores
                CloseEvoPrinter();

            }

            return (bStatus);
        }

        //<summary>
        //To open and grant access to the local port attached to the printer driver
        //</summary>
        //<returns>Handle on the port</returns>
        public IntPtr OpenEvoPrinter()
        {
            hPrinter = OpenPebble(printerName);
            return (hPrinter);
        }

        //<summary>
        //To close and free access to the local port.
        //</summary>
        //<returns>True if correct</returns>
        //<returns>False otherwise</returns>
        public bool CloseEvoPrinter()
        {
            bool bClose = false;
            bClose = ClosePebble(hPrinter);
            return (bClose);
        }

        /// <summary>
        /// To send an escape command and get its answer Port is Opened
        /// </summary>
        /// <param name="escCde"></param>
        /// <param name="Timeout"></param>
        /// <returns>True if execution correct and answer OK</returns>
        public bool DoAction(string escCde, int Timeout, ref bool bPrev)
        {
            bool bStatus = true;
            gsTimeout = Timeout;
            if (escCde.Length > 3)
            {
                SetCde = escCde;
                if (!WRPrinterOK(ref bPrev))
                {
                    bStatus = false;
                }
            }
            return (bStatus);
        }

        ///<summary>
        /// Sequence to synchronize writing and reading and checks taht answer is "OK"
        ///</summary>
        ///<returns>True: if writing and reading are correct and the answer is "OK"</returns>
        ///<returns>False otherwise</returns>
        public bool WRPrinterOK(ref bool bDo)
        {
            bool bWR = false;
            uint iPrtStatus = 0;
            IntPtr lpBuffer = Marshal.AllocHGlobal(1024);

            if (bDo == true)
            {
                if (!lpBuffer.Equals(IntPtr.Zero))
                {
                    GetStatusEvo(hPrinter, ref iPrtStatus);
                    if ((iPrtStatus & 0x000000FF) == 0x00000018)
                    {
                        bWR = WritePebble(hPrinter, cde, cdeLen);
                        if (bWR)
                        {
                            bWR = ReadPebble(hPrinter, lpBuffer, 1024, ref nbBytesRead);
                            if (bWR)
                            {
                                answer = Marshal.PtrToStringAnsi(lpBuffer, Convert.ToInt32(nbBytesRead));
                                if (answer != "OK")
                                {
                                    answerError = Marshal.PtrToStringAnsi(lpBuffer, Convert.ToInt32(nbBytesRead));
                                    switch (answerError)
                                    {
                                        case "FEEDER EMPTY":
                                            bDo = false;
                                            break;

                                        default:
                                            //DEJO ESTE CÓDIGO POR COMPATIBILIDAD CON LO QUE HABIA, PERO ARREGL
                                            //Comento esta linea de la SDK porque se ha escrito correctamente la tarjeta el problema
                                            //es que se ha leido la pista pero no se puede convertir; pero la tarjeta es escrita correctamente
                                            //bDo = false;   //RMM en la SDK viene esta linea.
                                            bDo = true;  //La pongo correcta.
                                            break;
                                    }

                                }
                                else
                                {
                                    bDo = true;
                                    bWR = true;
                                }
                            }
                            else
                            {
                                bDo = false;
                                answerError = "Fails to read";
                            }
                        }
                        else
                        {
                            bDo = false;
                            answerError = "Fails to write";
                        }
                    }
                    else
                    {
                        bDo = false;
                        answerError = "Printer is not ready or detected";
                    }
                    Marshal.FreeHGlobal(lpBuffer);
                }
            }

            return (bWR);
        }

        //		' <summary>
        //		' To get the currect timeout value
        //		' </summary>
        //		' <returns>Timeout value in milliseconds</returns>
        //		' <summary>
        //		' To set the timeout value
        //		' </summary>
        //		' <param name="value">value defined in milliseconds</param>
        public Int32 gsTimeout
        {
            get { return (GetTimeout()); }
            set { SetTimeout(value); }
        }

        //		' <summary>
        //		' To set the escape command to send to the printer
        //		' </summary>
        //		' <param name="newCde">escape command</param>
        public string SetCde
        {
            set
            {
                cde = value;
                cdeLen = value.Length;
            }
        }

        //		' <summary>
        //		'  read the answer error returned by the printer
        //		' </summary>
        //		' <returns>a pointer to the string buffer</returns>
        //for 'cde' and 'cdeLen' properties 
        public string getLastAnswerError
        {
            get { return (answerError); }
        }

        //		' <summary>
        //		' Read last answer from printer
        //		' </summary>
        //		' <returns> a pointer to the string buffer</returns>
        public string getLastAnswer
        {
            get { return (answer); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trackNumber"></param>
        /// <returns></returns>
        public string GetDownloadCdeTrack(int trackNumber)
        {
            if (trackNumber > 0 && trackNumber < 4)
            {
                return (writeDataTrack[trackNumber]);
            }
            else
            {
                return (writeDataTrack[0]);
            }
        }
        /// <summary>
        /// Fill that printer for a specified tracks.
        /// It has to be used after write or read tasks.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="trackNumber"></param>
        public void SetStatusCdeTrack(string status, int trackNumber)
        {
            if (trackNumber > 0 && trackNumber < 4)
            {
                statusTrack[trackNumber] = status;
            }
        }
        public string GetStatusCdeTrack(int trackNumber)
        {
            if (trackNumber > 0 && trackNumber < 4)
            {
                return statusTrack[trackNumber];
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Escape commande to start encoding sequence</returns>
        public string WriteMagTracks()
        {
            if (DataToWriteOnTrack[1] != string.Empty ||
               DataToWriteOnTrack[2] != string.Empty ||
               DataToWriteOnTrack[3] != string.Empty)
            {
                cdeTrack = ("\x1bSmw\x0d");
            }
            else
            {
                cdeTrack = string.Empty;
            }
            return cdeTrack;
        }
        ///// <summary>
        ///// Analyze printer answer and fill m_detailedAnswer with a more detailed explanation
        ///// </summary>
        ///// <returns>detailed string answer</returns>
        //public string AnalyzeAnswer()
        //{
        //    string answer;
        //    string analyzeanswer = string.Empty;
        //    IDictionaryEnumerator ide = printerErrorCol.GetEnumerator();

        //    answer = getLastAnswerError;

        //    foreach (DictionaryEntry key in printerErrorCol)
        //    {
        //        if (key.Value.ToString().CompareTo(answer) == 0)
        //        {
        //            analyzeanswer = key.Key.ToString();
        //            break;
        //        }
        //    }
        //    return analyzeanswer;
        //}
        /// <summary>
        /// Memorize track data
        /// Create downloading escape command.
        /// </summary>
        /// <param name="newTrack">data to download</param>
        /// <param name="trackNumber">track to set</param>
        public void SetDownloadData(string newTrack, int trackNumber)
        {
            if (trackNumber > 0 && trackNumber < 4)
            {
                if (newTrack != string.Empty)
                {
                    DataToWriteOnTrack[trackNumber] = newTrack;
                    writeDataTrack[trackNumber] = "\x1b" + string.Format("Dm;{0};{1}\x0d", trackNumber, DataToWriteOnTrack[trackNumber]);
                }
                else
                {
                    writeDataTrack[trackNumber] = string.Empty;
                }
            }
        }
        public void expulsarTarjeta(String impresora)
        {
            //System.Threading.Thread.Sleep(500);

            string cde1 = "\x1bSs\r";   //Ss: Sequence start
            string cde2 = "\x1bSe\r"; //Se: Sequence end
            IntPtr hPrinter;

            //Abrimos conexion
            hPrinter = OpenPebble(impresora);
            if (hPrinter != IntPtr.Zero)
            {
                SetTimeout(2000);

                bool resp1 = WritePebble(hPrinter, cde1, cde1.Length);
                bool resp2 = WritePebble(hPrinter, cde2, cde2.Length);

                //if (!resp1 || !resp2)
                //{
                //    MessageBox.Show("Evolis: Error on encoding. Sacando Tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                bool bClose = ClosePebble(hPrinter);
                if (!bClose)
                {
                    MessageBox.Show("Evolis: Error closing printer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Evolis: Error openning the printer to encode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// To wait spooler queeue is empty
        /// Useful to manage exclusive access to the port
        /// Direct port access control has to be closed
        /// </summary>
        /// <returns>Number of jobs</returns>
        public long waitQueueJob()
        {
            //IntPtr hPrinter = new System.IntPtr() ;
            PRINTER_DEFAULTS PrinterValues = new PRINTER_DEFAULTS();
            PRINTER_INFO_2 pinfo = new PRINTER_INFO_2();
            IntPtr ptrPrinterInfo;
            int nBytesNeeded;
            long nRet = 999;
            System.Int32 nJunk;

            PrinterValues.pDatatype = 0;
            PrinterValues.pDevMode = 0;
            PrinterValues.DesiredAccess = PRINTER_ALL_ACCESS;
            //-----------------------------------------------
            nRet = Convert.ToInt32(OpenPrinter(printerName, out hPrinter, ref PrinterValues));
            if (nRet == 0)
            {
                return (999);
            }

            GetPrinter(hPrinter, 2, IntPtr.Zero, 0, out nBytesNeeded);
            if (nBytesNeeded > 0)
            {
                // Allocate enough space for PRINTER_INFO_2... 
                ptrPrinterInfo = Marshal.AllocHGlobal(nBytesNeeded);
                // The second GetPrinter fills in all the current settings, so all you 
                // need to do is modify what you're interested in...
                if (ptrPrinterInfo != IntPtr.Zero)
                {
                    nRet = Convert.ToInt32(GetPrinter(hPrinter, 2, ptrPrinterInfo, nBytesNeeded, out nJunk));
                    if (nRet != 0)
                    {
                        pinfo = (PRINTER_INFO_2)Marshal.PtrToStructure(ptrPrinterInfo, typeof(PRINTER_INFO_2));
                        nRet = pinfo.cJobs;
                    }
                    Marshal.FreeHGlobal(ptrPrinterInfo);

                }
                ptrPrinterInfo = IntPtr.Zero;
            }

            CloseEvoPrinter();
            ClosePrinter(hPrinter);
            return (nRet);
        }

        public string gsPrinterName
        {
            get { return (printerName); }
            set { printerName = value; }
        }
    }
}

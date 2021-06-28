using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CardFormat3
{
    public class ClsHiti
    {
        //Export functions definitions, used for LoadLibrary
        //int WINAPI E680_Open_ComPort(int port);
        [DllImport("680api.dll", EntryPoint = "E680_Open_ComPort")]
        public static extern int E680_Open_ComPort(Int32 port);

        //int WINAPI E680_Close_ComPort();
        [DllImport("680api.dll", EntryPoint = "E680_Close_ComPort")]
        public static extern int E680_Close_ComPort();

        //int WINAPI E680_get_version(char* version);
        [DllImport("680api.dll", EntryPoint = "E680_get_version")]
        public static extern int E680_get_version(byte[] version);

        //int WINAPI E680_Request_CardSN(char* serial);
        [DllImport("680api.dll", EntryPoint = "E680_Request_CardSN")]
        public static extern int E680_Request_CardSN(byte[] serial);

        //int WINAPI E680_loadkey(char keyid, char* keyvalue);
        [DllImport("680api.dll", EntryPoint = "E680_loadkey")]
        public static extern int E680_loadkey(byte keyid, byte[] keyvalue);

        //int WINAPI E680_block_read(char block, char keytype, char keyid, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_block_read")]
        public static extern int E680_block_read(byte block, byte keytype, byte keyid, byte[] data);

        //int WINAPI E680_block_write(char block, char keytype, char keyid, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_block_write")]
        public static extern int E680_block_write(byte block, byte keytype, byte keyid, byte[] data);

        //int WINAPI E680_sector_read(char block, char keytype, char keyid, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_sector_read")]
        public static extern int E680_sector_read(byte block, byte keytype, byte keyid, byte[] data);

        //int WINAPI E680_initvalue(char block, char keytype, char keyid, long value);
        [DllImport("680api.dll", EntryPoint = "E680_initvalue")]
        public static extern int E680_initvalue(byte block, byte keytype, byte keyid, Int32 value);

        //int WINAPI E680_readvalue(char block, char keytype, char keyid, long* value);
        [DllImport("680api.dll", EntryPoint = "E680_readvalue")]
        public static extern int E680_readvalue(byte block, byte keytype, byte keyid, IntPtr value);

        //int WINAPI E680_increment(char block, char keytype, char keyid, unsigned long value);
        [DllImport("680api.dll", EntryPoint = "E680_increment")]
        public static extern int E680_increment(byte block, byte keytype, byte keyid, UInt32 value);

        //int WINAPI E680_decrement(char block, char keytype, char keyid, unsigned long value);
        [DllImport("680api.dll", EntryPoint = "E680_decrement")]
        public static extern int E680_decrement(byte block, byte keytype, byte keyid, UInt32 value);

        //int WINAPI E680_ledset(char state);
        [DllImport("680api.dll", EntryPoint = "E680_ledset")]
        public static extern int E680_ledset(byte state);

        //int WINAPI E680_buzzerset(char time);
        [DllImport("680api.dll", EntryPoint = "E680_buzzerset")]
        public static extern int E680_buzzerset(byte time);

        //int WINAPI E680_eeprom_read(int startadd, char length, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_eeprom_read")]
        public static extern int E680_eeprom_read(Int32 startadd, byte length, byte[] data);

        //int WINAPI E680_eeprom_write(int startadd, char length, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_eeprom_write")]
        public static extern int E680_eeprom_write(Int32 startadd, byte length, byte[] data);

        [DllImport("680api.dll", EntryPoint = "E680_loadkey_by_string")]
        public static extern int E680_loadkey_by_string(byte keyid, byte[] keyvalue);

        //int WINAPI E680_block_read_by_string(char block, char keytype, char keyid, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_block_read_by_string")]
        public static extern int E680_block_read_by_string(byte block, byte keytype, byte keyid, byte[] data);

        //int WINAPI E680_block_write_by_string(char block, char keytype, char keyid, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_block_write_by_string")]
        public static extern int E680_block_write_by_string(byte block, byte keytype, byte keyid, byte[] data);

        //int WINAPI E680_sector_read_by_string(char block, char keytype, char keyid, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_sector_read_by_string")]
        public static extern int E680_sector_read_by_string(byte block, byte keytype, byte keyid, byte[] data);

        //int WINAPI E680_eeprom_read_by_string(int startadd, char length, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_eeprom_read_by_string")]
        public static extern int E680_eeprom_read_by_string(Int32 startadd, byte length, byte[] data);

        //int WINAPI E680_eeprom_write_by_string(int startadd, char length, char* data);
        [DllImport("680api.dll", EntryPoint = "E680_eeprom_write_by_string")]
        public static extern int E680_eeprom_write_by_string(Int32 startadd, byte length, byte[] data);

        //int WINAPI E680_Set_Working_Mode(char antenna, char autoq);
        [DllImport("680api.dll", EntryPoint = "E680_Set_Working_Mode")]
        public static extern int E680_Set_Working_Mode(byte antenna, byte autoq);

        //int WINAPI E680_Set_Readcard_Mode(char cardtype);
        [DllImport("680api.dll", EntryPoint = "E680_Set_Readcard_Mode")]
        public static extern int E680_Set_Readcard_Mode(byte cardtype);

        //Messages sent by printer driver
        public const UInt32 WM_PAVO_PRINTER = 0x5555;

        //possible WPARAM values for WM_PAVO_PRINTER
        public const UInt32 MSG_JOB_BEGIN = 1;		    	//Driver begin to process job
        public const UInt32 MSG_PRINT_ONE_PAGE = 3;			//Driver process one page
        public const UInt32 MSG_PRINT_ONE_COPY = 4;			//Driver send one copy of one page data to printer
        public const UInt32 MSG_JOB_END = 6;		    	    //Driver process job end
        public const UInt32 MSG_DEVICE_STATUS = 7;			//Status of printer
        public const UInt32 MSG_JOB_CANCELED = 12;			//Driver cancel the job
        public const UInt32 MSG_JOB_PRINTED = 24;			//Printer print out the job completely

        //HiTi defined Device Status Code used for PAVO_CheckPrinterStatus
        public const UInt32 PAVO_DS_BUSY = 0x00080000;   	        //Printer is busy
        public const UInt32 PAVO_DS_OFFLINE = 0x00000080;	        //Printer is not connected
        public const UInt32 PAVO_DS_PRINTING = 0x00000002;   	    //Printer is printing
        public const UInt32 PAVO_DS_PROCESSING_DATA = 0x00000005;	//Driver is processing print data
        public const UInt32 PAVO_DS_SENDING_DATA = 0x00000006;	    //Driver is sending data to printer
        public const UInt32 PAVO_DS_CARD_MISMATCH = 0x000100FE;	    //Card mismatch
        public const UInt32 PAVO_DS_CMD_SEQ_ERROR = 0x000301FE;	    //Command sequence error
        public const UInt32 PAVO_DS_SRAM_ERROR = 0x00030001;	        //SRAM error
        public const UInt32 PAVO_DS_SDRAM_ERROR = 0x00030101;	    //SDRAM error
        public const UInt32 PAVO_DS_ADC_ERROR = 0x00030201;	        //ADC error
        public const UInt32 PAVO_DS_NVRAM_ERROR = 0x00030301;	    //NVRAM R/W error
        public const UInt32 PAVO_DS_SDRAM_CHECKSUM_ERROR = 0x00030302;//Check sum error - SDRAM
        public const UInt32 PAVO_DS_FW_WRITE_ERROR = 0x00030701;	    //Firmware write error
        public const UInt32 PAVO_DS_COVER_OPEN = 0x00050001;	        //Cover or door open or Ajar
        public const UInt32 PAVO_DS_COVER_OPEN_SLAVE = 0x00050201;	//Cover or door open or Ajar in slave printer
        public const UInt32 PAVO_DS_REJECT_BOX_MISSING = 0x00050301;	//Rejected box missing
        public const UInt32 PAVO_DS_REJECT_BOX_FULL = 0x00050401;	//Rejected box full
        public const UInt32 PAVO_DS_CARD_OUT = 0x00008000;	        //Card out or feeding error
        public const UInt32 PAVO_DS_CARD_LOW = 0x00008001;	        //Card low
        public const UInt32 PAVO_DS_RIBBON_MISSING = 0x00080004;	    //Ribbon missing
        public const UInt32 PAVO_DS_OUT_OF_RIBBON = 0x00080103;	    //Out of ribbon
        public const UInt32 PAVO_DS_RIBBON_IC_RW_ERROR = 0x000804FE;	//Ribbon IC R/W error
        public const UInt32 PAVO_DS_UNSUPPORT_RIBBON = 0x000806FE;	//Unsupported ribbon
        public const UInt32 PAVO_DS_UNKNOWN_RIBBON = 0x000808FE;	    //Unknown ribbon
        public const UInt32 PAVO_DS_RIBBON_MISSING_SLAVE = 0x00080204;//Ribbon missing in slave printer
        public const UInt32 PAVO_DS_OUT_OF_RIBBON_SLAVE = 0x00080303;//Out of ribbon in slave printer
        public const UInt32 PAVO_DS_RIBBON_IC_RW_ERROR_SLAVE = 0x000805FE;//Ribbon IC R/W error in slave printer
        public const UInt32 PAVO_DS_UNSUPPORT_RIBBON_SLAVE = 0x000807FE;//Unsupported ribbon in slave printer
        public const UInt32 PAVO_DS_UNKNOWN_RIBBON_SLAVE = 0x000809FE;//Unknown ribbon in slave printer
        public const UInt32 PAVO_DS_CARD_JAM1 = 0x00030000;	        //Card jam in card path
        public const UInt32 PAVO_DS_CARD_JAM2 = 0x00040000;	        //Card jam in flipper
        public const UInt32 PAVO_DS_CARD_JAM3 = 0x00050000;	        //Card jam in eject box
        public const UInt32 PAVO_DS_CARD_JAM4 = 0x00030100;	        //Card jam in card path of slave printer
        public const UInt32 PAVO_DS_CARD_JAM5 = 0x00040100;           //Card jam in flipper of slave printer
        public const UInt32 PAVO_DS_CARD_JAM6 = 0x00050100;          //Card jam in eject box of slave printer
        public const UInt32 PAVO_DS_CARD_JAM7 = 0x00060100;	        //Card jam between master and slave
        public const UInt32 PAVO_DS_CARD_JAM8 = 0x00070100;	        //Card jam in end of master
        public const UInt32 PAVO_DS_WRITE_FAIL = 0x0000001F;	        //Send command to printer fail
        public const UInt32 PAVO_DS_READ_FAIL = 0x0000002F;	        //Get response from printer fail
        public const UInt32 PAVO_DS_CARD_THICK_WRONG = 0x00008010;	//Card thickness selector is not placed in the right position


        //following errors are used for CS-200e
        public const UInt32 PAVO_DS_0100_COVER_OPEN = 0x00000100;	    //0100 Cover open
        public const UInt32 PAVO_DS_0101_FLIPPER_COVER_OPEN = 0x00000101;//0101 Flipper cover open
        public const UInt32 PAVO_DS_0200_IC_MISSING = 0x00000200;	    //0200 IC chip missing
        public const UInt32 PAVO_DS_0201_RIBBON_MISSING = 0x00000201;	//0201 Ribbon missing
        public const UInt32 PAVO_DS_0202_RIBON_MISMATCH = 0x00000202;	//0202 Ribbon mismatch
        public const UInt32 PAVO_DS_0203_RIBBON_TYPE_ERROR = 0x00000203;	//0203 Ribbon type error
        public const UInt32 PAVO_DS_0300_RIBBON_SEARCH_FAIL = 0x00000300;//0300 Ribbon search fail
        public const UInt32 PAVO_DS_0301_RIBBON_OUT = 0x00000301;    	//0301 Ribbon out
        public const UInt32 PAVO_DS_0302_PRINT_FAIL = 0x00000302;    	//0302 Print fail
        public const UInt32 PAVO_DS_0303_PRINT_FAIL = 0x00000303;    	//0303 Print fail
        public const UInt32 PAVO_DS_0304_RIBBON_OUT = 0x00000304;    	//0304 Ribbon out
        public const UInt32 PAVO_DS_0400_CARD_OUT = 0x00000400;          //0400 Card out
        public const UInt32 PAVO_DS_0500_CARD_JAM = 0x00000500;	        //0500 Card jam
        public const UInt32 PAVO_DS_0501_CARD_JAM = 0x00000501;	        //0501 Card jam
        public const UInt32 PAVO_DS_0502_CARD_JAM = 0x00000502;      	//0502 Card jam
        public const UInt32 PAVO_DS_0503_CARD_JAM = 0x00000503;	        //0503 Card jam
        public const UInt32 PAVO_DS_0504_CARD_JAM = 0x00000504;  	    //0504 Card jam
        public const UInt32 PAVO_DS_0505_CARD_JAM = 0x00000505;	        //0505 Card jam
        public const UInt32 PAVO_DS_0506_CARD_JAM = 0x00000506;	        //0506 Card jam
        public const UInt32 PAVO_DS_0507_CARD_JAM = 0x00000507;  	    //0507 Card jam
        public const UInt32 PAVO_DS_0600_CARD_MISMATCH = 0x00000600;	    //0600 Card mismatch
        public const UInt32 PAVO_DS_0700_CAM_ERROR = 0x00000700;	        //0700 Cam error
        public const UInt32 PAVO_DS_0800_FLIPPER_ERROR = 0x00000800;	    //0800 Flipper error
        public const UInt32 PAVO_DS_0900_NVRAM_ERROR = 0x00000900;	    //0900 NVRAM error
        public const UInt32 PAVO_DS_1000_RIBBON_ERROR = 0x00001000;	    //1000 Ribbon error
        public const UInt32 PAVO_DS_1100_RBN_TAKE_CALIB_FAIL = 0x00001100;	//1100 RBN Take Calibration Failed
        public const UInt32 PAVO_DS_1101_RBN_SUPPLY_CALIB_FAIL = 0x00001101;	//1101 RBN Supply Calibration Failed
        public const UInt32 PAVO_DS_1200_ADC_ERROR = 0x00001200;	        //1200 ADC error
        public const UInt32 PAVO_DS_1300_FW_ERROR = 0x00001300;	        //1300 FW error
        public const UInt32 PAVO_DS_1400_POWER_SUPPLY_ERROR = 0x00001400;//1400 Power supply error

        public const UInt32 SCARD_E_NO_SMARTCARD = 0x8010000C;	        //The operation requires a Smart Card, but no Smart Card is currently in the device.

        //possible return value of PAVO_EncodeMagTrack, PAVO_ReadMagTrackData and PAVO_WriteMagTrackData
        public const UInt32 ERROR_MAGCARD_CONNECT_FAIL = 1850;		    //Cannot connect COM port of magnetic module
        public const UInt32 ERROR_MAGCARD_READ_FAIL = 1851;		        //Read track data fail
        public const UInt32 ERROR_MAGCARD_WRITE_FAIL = 1852;		        //Write track data fail
        public const UInt32 ERROR_MAGCARD_NO_TRACK_SELECTED = 1853;		//No track is specified to be read/write
        public const UInt32 ERROR_MAGCARD_EMPTY_TRACK_DATA = 1855;		//One of the track data is empty

        //HiTi defined ribbon type used for setting PAVO_JOB_PROPERTY.byRibbonType and PAVO_QueryRibbonInfo
        public const UInt32 PAVO_RIBBON_TYPE_YMCKO = 0;
        public const UInt32 PAVO_RIBBON_TYPE_K = 1;
        public const UInt32 PAVO_RIBBON_TYPE_YMCO = 2;
        public const UInt32 PAVO_RIBBON_TYPE_KO = 3;
        public const UInt32 PAVO_RIBBON_TYPE_YMCKOK = 4;
        public const UInt32 PAVO_RIBBON_TYPE_HALF_YMCKO = 5;
        public const UInt32 PAVO_RIBBON_TYPE_GOLD = 6;
        public const UInt32 PAVO_RIBBON_TYPE_SILVER = 7;
        public const UInt32 PAVO_RIBBON_TYPE_WHITE = 8;


        //HiTi defined card type used for setting PAVO_JOB_PROPERTY.dwCardType
        public const UInt32 PAVO_CARD_TYPE_BLANK_CARD = 0;   			//Blank Card
        public const UInt32 PAVO_CARD_TYPE_SMART_CHIP_6PIN = 1;			//Smart Chip Card 6-pin
        public const UInt32 PAVO_CARD_TYPE_SMART_CHIP_8PIN = 2;			//Smart Chip Card 8-pin
        public const UInt32 PAVO_CARD_TYPE_MAG_STRIP = 3;		    	//Magnetic Stripe Card
        public const UInt32 PAVO_CARD_TYPE_CHIP_MAG_STRIP = 4;			//Chip/Magnetic Card
        public const UInt32 PAVO_CARD_TYPE_ADHESIVE_CARD = 5;			//Adhesive Card

        //used for setting PAVO_JOB_PROPERTY.dwFlags
        public const UInt32 PAVO_FLAG_NOT_SHOW_ERROR_MSG_DLG = 0x00000001;	    //Not show error message dialog
        public const UInt32 PAVO_FLAG_WAIT_MSG_DONE = 0x00000002;	            //Make driver to wait until AP process the message ok
        public const UInt32 PAVO_FLAG_NOT_SHOW_CLEAN_MSG = 0x00000100;	        //Not popup clean message
        public const UInt32 PAVO_FLAG_WATCH_JOB_PRINTED = 0x00000400;	        //Indicate driver to notify AP when print card completely
        public const UInt32 PAVO_FLAG_NOT_EJECT_CARD_AFTER_PRINTED = 0x00008000; //Not eject card after printing finished

        //used for setting PAVO_JOB_PROPERTY.dwDataFlag
        public const UInt32 PAVO_DATAFLAG_RESIN_FRONT = 0x00000002;
        public const UInt32 PAVO_DATAFLAG_RESIN_BACK = 0x00000010;

        //used for dwType of PAVO_SetExtraDataToHDC
        public const UInt32 PAVO_DATA_RESIN_FRONT = 2;
        public const UInt32 PAVO_DATA_RESIN_BACK = 5;

        //used for setting PAVO_JOB_PROPERTY.byDuplex
        public const UInt32 PAVO_DUPLEX_PRINT_FRONT_SIDE = 0x01;
        public const UInt32 PAVO_DUPLEX_PRINT_BACK_SIDE = 0x02;

        //Position definition for PAVO_MoveCard
        public const UInt32 MOVE_CARD_TO_IC_ENCODER = 1;			//Move Card to Contact Encoder Station
        public const UInt32 MOVE_CARD_TO_MAGSTRIP_ENCODER = 2;	//Move Card to Magnetic Strip Encoder Station
        public const UInt32 MOVE_CARD_TO_RFIC_ENCODER = 3;		//Move Card to Contactless Encoder Station
        public const UInt32 MOVE_CARD_TO_EJECT_BOX = 4;			//Move Card to Eject Box
        public const UInt32 MOVE_CARD_TO_HOPPER = 5;			    //Move Card to Hopper

        //PAVO_JOB_PROPERTY.dwFieldFlag
        public const UInt32 FF_CARD_TYPE = 0x00000001;
        public const UInt32 FF_FLAGS = 0x00000002;
        public const UInt32 FF_DATA_FLAG = 0x00000004;
        public const UInt32 FF_PARENT_HWND = 0x00000008;
        public const UInt32 FF_ORIENTATION = 0x00000020;
        public const UInt32 FF_COPIES = 0x00000040;
        public const UInt32 FF_CUSTOM_INDEX = 0x00000080;
        public const UInt32 FF_DUPLEX = 0x00000100;
        public const UInt32 FF_RIBBON_TYPE = 0x00000200;
        public const UInt32 FF_PRINT_COLOR = 0x00000400;
        public const UInt32 FF_DITHER_K = 0x00000800;
        public const UInt32 FF_LAMIN = 0x00001000;
        public const UInt32 FF_LAMIN_TYPE = 0x00002000;
        public const UInt32 FF_ROTATE180 = 0x00004000;
        public const UInt32 FF_CARD_THICK = 0x00010000;
        public const UInt32 FF_ALL_FIELDS = 0xFFFFFFFF;
        public Dictionary<long, string> errors = new Dictionary<long, string>();


        public ClsHiti()
        {
            errors.Add(0x00080000, "Printer is busy");
            errors.Add(0x00000080, "Printer is not connected");
            errors.Add(0x00000002, "Printer is printing");
            errors.Add(0x00000005, "Driver is processing print data");
            errors.Add(0x00000006, "Driver is sending data to printer");
            errors.Add(0x000100FE, "Card mismatch");
            errors.Add(0x000301FE, "Command sequence error");
            errors.Add(0x00030001, "SRAM error");
            errors.Add(0x00030101, "SDRAM error");
            errors.Add(0x00030201, "ADC error");
            errors.Add(0x00030301, "NVRAM R/W error");
            errors.Add(0x00030302, "Check sum error - SDRAM");
            errors.Add(0x00030701, "Firmware write error");
            errors.Add(0x00050001, "Cover or door open or Ajar");
            errors.Add(0x00050201, "Cover or door open or Ajar in slave printer");
            errors.Add(0x00050301, "Rejected box missing");
            errors.Add(0x00050401, "Rejected box full");
            errors.Add(0x00008000, "Card out or feeding error");
            errors.Add(0x00008001, "Card low");
            errors.Add(0x00080004, "Ribbon missing");
            errors.Add(0x00080103, "Out of ribbon");
            errors.Add(0x000804FE, "Ribbon IC R/W error");
            errors.Add(0x000806FE, "Unsupported ribbon");
            errors.Add(0x000808FE, "Ribbon missing in slave printer");
            errors.Add(0x00080303, "Out of ribbon in slave printer");
            errors.Add(0x000805FE, "Ribbon IC R/W error in slave printer");
            errors.Add(0x000807FE, "Unsupported ribbon in slave printer");
            errors.Add(0x000809FE, "Unknown ribbon in slave printer");
            errors.Add(0x00030000, "Card jam in card path");
            errors.Add(0x00040000, "Card jam in flipper");
            errors.Add(0x00050000, "Card jam in eject box");
            errors.Add(0x00030100, "Card jam in card path of slave printer");
            errors.Add(0x00040100, "Card jam in flipper of slave printer");
            errors.Add(0x00050100, "Card jam in eject box of slave printer");
            errors.Add(0x00060100, "Card jam between master and slave");
            errors.Add(0x00070100, "Card jam in end of master");
            errors.Add(0x0000001F, "Send command to printer fail");
            errors.Add(0x0000002F, "Get response from printer fail");
            errors.Add(0x00008010, "Card thickness selector is not placed in the right position");
        }

        //used for PAVO_ApplyJobSetting
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct PAVO_JOB_PROPERTY
        {
            public UInt32 dwSize;				//=80
            public UInt32 dwCardType;
            public UInt32 dwFlags;
            public UInt32 dwDataFlag;

            public UInt32 hParentWnd;//HWND		hParentWnd;
            public UInt32 hReserved1;//HWND		hReserved1;

            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
            public string pReserved1;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
            public string pReserved2;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
            public string pReserved3;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
            public string pReserved4;

            public short shOrientation;		//1=Portrait,2=Landscape
            public short shCopies;
            public short shReserved1;
            public short shReserved2;

            public UInt32 dwCustomIndex;
            public UInt32 dwFieldFlag;
            public UInt32 dwReserved3;
            public UInt32 dwReserved4;

            public Int16 wReserved1;
            public Int16 wReserved2;
            public Int16 wReserved3;
            public byte byReserved1;
            public byte byCardThick;		//0=0.3mm;1=0.5mm;2=0.8mm;3=1.0mm

            public byte byDuplex;			//Print side: 0x01=front side, 0x02=back side
            public byte byRibbonType;		//0=YMCKO;1=K;2=YMCO;3=KO;4=YMCKOK;5=1/2YMCKO;6=Gold;7=Silver;8=White
            public byte byPrintColor;		//Print YMCO: 0x01=front side, 0x02=back side
            public byte byDitherK;			//Print K with dither: 0x01=front side, 0x02=back side
            public byte byLamin;			//Print lamination: 0x01=front side, 0x02=back side
            public byte byReserved6;
            public byte byLaminType;		//Lamination ribbon type, 0x00=HiTi Standard Overlay, 0x01=HiTi Standard Patch
            public byte byRotate180;		//Rotate 180: 0x00=Not rotate, 0x01=front side, 0x02=back side, 0x03=both sides
        };

        //used for PAVO_EncodeMagTrack, PAVO_ReadMagTrackData, PAVO_WriteMagTrackData
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct MAG_TRACK_DATA
        {
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 256)]
            public char[] szTrack1;	//78 characters max, allow characters are between {}, { !"#$&'()*+,-./0123456789:;<=>@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_}. Start Sentinel is '%', End Sentinel is '?', both will be auto added by encoder.
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 256)]
            public char[] szTrack2;	//39 characters max, allow characters are between {}, {0123456789:<=>}. Start Sentinel is ';', End Sentinel is '?', both will be auto added by encoder.
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 256)]
            public char[] szTrack3;	//105 characters max, allow characters are between {}, {0123456789:<=>}. Start Sentinel is ';', End Sentinel is '?', both will be auto added by encoder.

            public byte byTrackFlag;	//0x01=track1, 0x02=track2, 0x04=track3
            public byte byEncodeMode;	//not used
            public byte byCoercivity;	//0=Lo-Co, 1=Hi-Co
            public byte byT2BPI;		//75 or 210, if not set it, will use 75

            public byte byRawLenT1;
            public byte byRawLenT2;
            public byte byRawLenT3;

            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 25)]
            public byte[] byReserve;
        };

        //Export functions definitions, used for LoadLibrary
        //typedef	DWORD __stdcall PAVO_FindMatchedComPort(LPTSTR szPrinterName, DWORD* lpdwMagPort, DWORD* lpdwRFPort);
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_CheckPrinterStatus")]
        public static extern UInt32 PAVO_FindMatchedComPort(string szPrinterName, out UInt32 lpdwMagPort, out UInt32 lpdwRFPort);

        //typedef	DWORD (__stdcall * pfnPAVO_ApplyJobSetting) (LPTSTR szPrinterName, HDC hDC, BYTE* lpInDevMode, BYTE* lpInJobProp);
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_CheckPrinterStatus")]
        public static extern UInt32 PAVO_CheckPrinterStatus(string szPrinterName, ref UInt32 lpdwStatus);

        //typedef DWORD (__stdcall * pfnPAVO_DoCommand) (LPTSTR szPrinterName, DWORD dwCommand);
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_DoCommand")]
        public static extern UInt32 PAVO_DoCommand(string szPrinterName, UInt32 dwCommand);

        //typedef DWORD (__stdcall * pfnPAVO_EncodeMagTrack) (LPTSTR szPrinterName, DWORD dwCOM, BYTE* lpTrackData, DWORD dwRetry);//lpTrackData is the pointer of MAG_TRACK_DATA
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_EncodeMagTrack")]
        public static extern UInt32 PAVO_EncodeMagTrack(string szPrinterName, UInt32 dwCOM, IntPtr lpTrackData, UInt32 dwRetry);

        //typedef	DWORD (__stdcall * pfnPAVO_MoveCard)				(LPTSTR szPrinterName, DWORD dwPosition);
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_MoveCard")]
        public static extern UInt32 PAVO_MoveCard(string szPrinterName, UInt32 dwPosition);

        //typedef	DWORD (__stdcall * pfnPAVO_MoveCard2)				(LPTSTR szPrinterName, DWORD dwPosition);
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_MoveCard2")]
        public static extern UInt32 PAVO_MoveCard2(string szPrinterName, UInt32 dwPosition);

        //typedef DWORD (__stdcall * pfnPAVO_ReadMagTrackData)		(LPTSTR szPrinterName, DWORD dwCOM, BYTE* lpTrackData);//lpTrackData is the pointer of MAG_TRACK_DATA
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_ReadMagTrackData")]
        public static extern UInt32 PAVO_ReadMagTrackData(string szPrinterName, UInt32 dwCOM, IntPtr lpTrackData);

        //typedef DWORD (__stdcall * pfnPAVO_WriteMagTrackData)		(LPTSTR szPrinterName, DWORD dwCOM, BYTE* lpTrackData);//lpTrackData is the pointer of MAG_TRACK_DATA
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_WriteMagTrackData")]
        public static extern UInt32 PAVO_WriteMagTrackData(string szPrinterName, UInt32 dwCOM, IntPtr lpTrackData);

        //typedef	DWORD (__stdcall * pfnPAVO_QueryPrintCount)			(LPTSTR szPrinterName, DWORD *lpdwCount);
        [System.Runtime.InteropServices.DllImport("PavoApi.dll", EntryPoint = "PAVO_QueryPrintCount")]
        public static extern UInt32 PAVO_QueryPrintCount(string szPrinterName, ref UInt32 lpdwCount);


        /// <summary>
        /// Method to wait any responde of the printer that indicates that are ready to receive any command
        /// </summary>
        /// <param name="printerName">Printer name</param>
        /// <param name="msegTimeout">Timeout to wait responde in milisecond</param>
        /// <param name="msegTimeStep">Time step of each iteration of printer request</param>
        /// <returns>True if priter response ready, otherwise false</returns>
        static public bool waitPrinterResponse(string printerName, int msegTimeout, int msegTimeStep)
        {
            bool returnVal = false;
            UInt32 status = new UInt32();
            UInt32 result = new UInt32();

            DateTime start = new DateTime();
            DateTime end = new DateTime();

            TimeSpan duration = new TimeSpan(0, 0, 0, 0, msegTimeout);    // msegTimeout seconds

            // start count
            start = DateTime.Now;
            end = DateTime.Now;

            // mientras el tiempo actual - tiempo incicio sea mayor que el tiempo maximo
            do
            {
                result = PAVO_CheckPrinterStatus(printerName, ref status);

                if (result != 0 && result != 0x00000080)
                {
                    //System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(msegTimeStep);
                }
                else if (result == 0x00000080)  // not connected or detected
                    break;
                else if (status == 0 && result == 0)
                    returnVal = true;

                end = DateTime.Now;
            } while (end.Subtract(start) < duration && status != 0 && result != 0);

            return returnVal;
        }
    }
}

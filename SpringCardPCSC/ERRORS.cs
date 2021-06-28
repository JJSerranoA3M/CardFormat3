using System;
using System.Collections.Generic;
using System.Text;

namespace SpringCardPCSC
{
    public class ERRORS
    {
        #region -   errors definitions   -

        // success result indicated by API call
        public static uint NO_ERROR = 0;
        public static uint SCARD_S_SUCCESS = NO_ERROR;

        public static uint SCARD_F_INTERNAL_ERROR = 2148532225; //  An internal consistency check failed
        public static uint SCARD_E_CANCELLED = 2148532226;//  The action was cancelled by an SCardCancel request
        public static uint SCARD_E_INVALID_HANDLE = 2148532227;//  The supplied handle was invalid
        public static uint SCARD_E_INVALID_PARAMETER = 2148532228;//  One or more of the supplied parameters could not be properly interpreted
        public static uint SCARD_E_INVALID_TARGET = 2148532229;//  Registry startup information is missing or invalid
        public static uint SCARD_E_NO_MEMORY = 2148532230;//  Not enough memory available to complete this command 
        public static uint SCARD_F_WAITED_TOO_LONG = 2148532231;//  An internal consistency timer has expired
        public static uint SCARD_E_INSUFFICIENT_BUFFER = 2148532232;//  The data buffer to receive returned data is too small for the returned data
        public static uint SCARD_E_UNKNOWN_READER = 2148532233;//  The specified reader name is not recognized
        public static uint SCARD_E_TIMEOUT = 2148532234;//  The user-specified timeout value has expired
        public static uint SCARD_E_SHARING_VIOLATION = 2148532235;//  The card cannot be accessed because of other connections outstanding
        public static uint SCARD_E_NO_SMARTCARD = 2148532236;//  The operation requires a card, but no card is currently in the device
        public static uint SCARD_E_UNKNOWN_CARD = 2148532237;//  The specified card name is not recognized
        public static uint SCARD_E_CANT_DISPOSE = 2148532238;//  The system could not dispose of the media in the requested manner
        public static uint SCARD_E_PROTO_MISMATCH = 2148532239;//  The requested protocols are incompatible with the protocol currently in use with the card
        public static uint SCARD_E_NOT_READY = 2148532240;//  The reader or card is not ready to accept commands
        public static uint SCARD_E_INVALID_VALUE = 2148532241;//  One or more of the supplied parameters values could not be properly interpreted
        public static uint SCARD_E_SYSTEM_CANCELLED = 2148532242;//  The action was cancelled by the system, presumably to log off or shut down
        public static uint SCARD_F_COMM_ERROR = 2148532243;//  An internal communications error has been detected
        public static uint SCARD_F_UNKNOWN_ERROR = 2148532244;//  An internal error has been detected, but the source is unknown
        public static uint SCARD_E_INVALID_ATR = 2148532245;//  An ATR obtained from the registry is not a valid ATR string
        public static uint SCARD_E_NOT_TRANSACTED = 2148532246;//  An attempt was made to end a non-existent transaction
        public static uint SCARD_E_READER_UNAVAILABLE = 2148532247;//  The specified reader is not currently available for use
        public static uint SCARD_P_SHUTDOWN = 2148532248;//  PRIVATE -- Internal flag to force server termination
        public static uint SCARD_E_PCI_TOO_SMALL = 2148532249;//  The PCI Receive buffer was too small
        public static uint SCARD_E_READER_UNSUPPORTED = 2148532250;//  The reader driver does not meet minimal requirements for support
        public static uint SCARD_E_DUPLICATE_READER = 2148532251;//  The reader driver did not produce a unique reader name
        public static uint SCARD_E_CARD_UNSUPPORTED = 2148532252;//  The card does not meet minimal requirements for support
        public static uint SCARD_E_NO_SERVICE = 2148532253;//  The card resource manager is not running
        public static uint SCARD_E_SERVICE_STOPPED = 2148532254;//  The card resource manager has shut down
        public static uint SCARD_E_UNEXPECTED = 2148532255;//  An unexpected card error has occurred
        public static uint SCARD_E_ICC_INSTALLATION = 2148532256;//  No Primary Provider can be found for the card
        public static uint SCARD_E_ICC_CREATEORDER = 2148532257;//  The requested order of object creation is not supported
        public static uint SCARD_E_UNSUPPORTED_FEATURE = 2148532258;//  This card does not support the reqested feature
        public static uint SCARD_E_DIR_NOT_FOUND = 2148532259;//  The identified directory does not exist in the card
        public static uint SCARD_E_FILE_NOT_FOUND = 2148532260;//  The identified file does not exist in the card
        public static uint SCARD_E_NO_DIR = 2148532261;//  The supplied path does not represent a card directory
        public static uint SCARD_E_NO_FILE = 2148532262;//  The supplied path does not represent a card file
        public static uint SCARD_E_NO_ACCESS = 2148532263;//  Access is denied to this file
        public static uint SCARD_E_WRITE_TOO_MANY = 2148532264;//  An attempt was made to write more data than would fit in the target object
        public static uint SCARD_E_BAD_SEEK = 2148532265;//  There was an error trying to set the card file object pointer
        public static uint SCARD_E_INVALID_CHV = 2148532266;//  The supplied PIN is incorrect
        public static uint SCARD_E_UNKNOWN_RES_MNG = 2148532267;//  An unrecognized error code was returned from a layered component
        public static uint SCARD_E_NO_SUCH_CERTIFICATE = 2148532268;//  The requested certificate does not exist.
        public static uint SCARD_E_CERTIFICATE_UNAVAILABLE = 2148532269;//  The requested certificate could not be obtained.
        public static uint SCARD_E_NO_READERS_AVAILABLE = 2148532270;//  None of the specified readers are currently available for use
        public static uint SCARD_W_UNSUPPORTED_CARD = 2148532325;//  The reader cannot communicate with the card, due to ATR configuration conflicts
        public static uint SCARD_W_UNRESPONSIVE_CARD = 2148532326;//  The card is not responding to a reset
        public static uint SCARD_W_UNPOWERED_CARD = 2148532327;//  Power has been removed from the card, so that further communication is not possible
        public static uint SCARD_W_RESET_CARD = 2148532328;//  The card has been reset, so any shared state information is invalid
        public static uint SCARD_W_REMOVED_CARD = 2148532329;//  The card has been removed, so that further communication is not possible
        public static uint SCARD_W_SECURITY_VIOLATION = 2148532330;//  Access was denied because of a security violation
        public static uint SCARD_W_WRONG_CHV = 2148532331;//  The card cannot be accessed because the wrong PIN was presented
        public static uint SCARD_W_CHV_BLOCKED = 2148532332;//  The card cannot be accessed because the maximum number of PIN entry attempts has been reached
        public static uint SCARD_W_EOF = 2148532333;//  The end of the card file has been reached
        public static uint SCARD_W_CANCELLED_BY_USER = 2148532334;//  The action was cancelled by the user
        public static uint SCARD_M_SUCCESS = NO_ERROR;//Operation success
        public static uint SCARD_M_CARD_ABSENT = 2148532344;//The card is not in the reader
        public static uint SCARD_M_NO_RESPONSE = 2148532345;//The card does not response any thing
        public static uint SCARD_M_POWER_FAIL = 2148532346;//Power the card fail
        public static uint SCARD_M_COMM_ERROR = 2148532347;//Communication error
        public static uint SCARD_M_VERIFY_FAIL = 2148532348;//Verify codes fail
        public static uint SCARD_M_TYPE_ERROR = 2148532349;//Card Type Error
        public static uint SCARD_M_COMMAND_ERROR = 2148532350;//The command to the card Error
        public static uint SCARD_M_COUNTER_EMPTY = 2148532351;//Counter of card is empty
        public static uint SCARD_M_CARD_LOCKED = 2148532352;//The card is locked
        public static uint SCARD_M_WRITE_ERROR = 2148532353;//Write to the card error
        public static uint SCARD_M_CHECK_ERROR = 2148532354;//Check if previously written data is really written
        public static uint SCARD_M_OTHER_FAIL = 2148532355;//Other fail

        public static uint SCARD_MI_CRCERR = 0x801000A0;// PICC response with CRC error
        public static uint SCARD_MI_AUTHERR = 0x801000A1;// Mifare authen error
        public static uint SCARD_MI_PARITYERR = 0x801000A2;// PICC response with parity error
        public static uint SCARD_MI_CODEERR = 0x801000A3;// Received Mifare NAK
        public static uint SCARD_MI_NOTAUTHERR = 0x801000A4;// Mifare have not been authenticated
        public static uint SCARD_MI_BITCOUNTERR = 0x801000A5;// PICC response with error bit length
        public static uint SCARD_MI_BYTECOUNTERR = 0x801000A6;// PICC response with error number of byte
        public static uint SCARD_MI_OVFLERR = 0x801000A7;// Internal FIFO overflow
        public static uint SCARD_MI_FRAMINGERR = 0x801000A8;// PICC response with invalid frame
        public static uint SCARD_MI_COLLERR = 0x801000A9;// Collision have been detected
        public static uint SCARD_MI_ACCESSTIMEOUT = 0x801000AA;// PICC not response
        public static uint SCARD_MI_CODINGERR = 0x801000AB;// PICC response with bit-coding error
        public static uint SCARD_MI_PROTOCOLERR = 0x801000AC;// T=CL protocol error
        public static uint SCARD_MI_RFERR = 0x801000AD;// Antenna hardware error
        public static uint SCARD_MI_TEMPERR = 0x801000AE;// Temperature
        public static uint SCARD_MI_WRERR = 0x801000AF;// EEPROM write error
        public static uint SCARD_MI_VALERR = 0x801000B0;// PICC response with error value
        public static uint SCARD_MI_OTHERERR = 0x801000B1;// Unspecific error
        public static uint SCARD_MI_NOTSUPPORT = 0x801000B2;// Command not support

        #endregion

        #region -   error dictionay   -

        static Dictionary<uint, string> error_dictionary = new Dictionary<uint, string>()
        {
           {SCARD_F_INTERNAL_ERROR, "An internal consistency check failed"},
           {SCARD_E_CANCELLED , "The action was cancelled by an SCardCancel request"},
           {SCARD_E_INVALID_HANDLE , "The supplied handle was invalid"},
           {SCARD_E_INVALID_PARAMETER, "One or more of the supplied parameters could not be properly interpreted"},
           {SCARD_E_INVALID_TARGET, "Registry startup information is missing or invalid"},
           {SCARD_E_NO_MEMORY , "Not enough memory available to complete this command "},
           {SCARD_F_WAITED_TOO_LONG , "An internal consistency timer has expired"},
           {SCARD_E_INSUFFICIENT_BUFFER , "The data buffer to receive returned data is too small for the returned data"},
           {SCARD_E_UNKNOWN_READER , "The specified reader name is not recognized"},
           {SCARD_E_TIMEOUT , "The user-specified timeout value has expired"},
           {SCARD_E_SHARING_VIOLATION , "The card cannot be accessed because of other connections outstanding"},
           {SCARD_E_NO_SMARTCARD , "The operation requires a card, but no card is currently in the device"},
           {SCARD_E_UNKNOWN_CARD , "The specified card name is not recognized"},
           {SCARD_E_CANT_DISPOSE , "The system could not dispose of the media in the requested manner"},
           {SCARD_E_PROTO_MISMATCH , "The requested protocols are incompatible with the protocol currently in use with the card"},
           {SCARD_E_NOT_READY , "The reader or card is not ready to accept commands"},
           {SCARD_E_INVALID_VALUE , "One or more of the supplied parameters values could not be properly interpreted"},
           {SCARD_E_SYSTEM_CANCELLED , "The action was cancelled by the system, presumably to log off or shut down"},
           {SCARD_F_COMM_ERROR , "An internal communications error has been detected"},
           {SCARD_F_UNKNOWN_ERROR , "An internal error has been detected, but the source is unknown"},
           {SCARD_E_INVALID_ATR , "An ATR obtained from the registry is not a valid ATR string"},
           {SCARD_E_NOT_TRANSACTED , "An attempt was made to end a non-existent transaction"},
           {SCARD_E_READER_UNAVAILABLE , "The specified reader is not currently available for use"},
           {SCARD_P_SHUTDOWN , "PRIVATE -- Internal flag to force server termination"},
           {SCARD_E_PCI_TOO_SMALL , "The PCI Receive buffer was too small"},
           {SCARD_E_READER_UNSUPPORTED , "The reader driver does not meet minimal requirements for support"},
           {SCARD_E_DUPLICATE_READER , "The reader driver did not produce a unique reader name"},
           {SCARD_E_CARD_UNSUPPORTED , "The card does not meet minimal requirements for support"},
           {SCARD_E_NO_SERVICE , "The card resource manager is not running"},
           {SCARD_E_SERVICE_STOPPED, "The card resource manager has shut down"},
           {SCARD_E_UNEXPECTED , "An unexpected card error has occurred"},
           {SCARD_E_ICC_INSTALLATION , "No Primary Provider can be found for the card"},
           {SCARD_E_ICC_CREATEORDER  , "The requested order of object creation is not supported"},
           {SCARD_E_UNSUPPORTED_FEATURE  , "This card does not support the reqested feature"},
           {SCARD_E_DIR_NOT_FOUND  , "The identified directory does not exist in the card"},
           {SCARD_E_FILE_NOT_FOUND  , "The identified file does not exist in the card"},
           {SCARD_E_NO_DIR  , "The supplied path does not represent a card directory"},
           {SCARD_E_NO_FILE  , "The supplied path does not represent a card file"},
           {SCARD_E_NO_ACCESS  , "Access is denied to this file"},
           {SCARD_E_WRITE_TOO_MANY  , "An attempt was made to write more data than would fit in the target object"},
           {SCARD_E_BAD_SEEK  , "There was an error trying to set the card file object pointer"},
           {SCARD_E_INVALID_CHV  , "The supplied PIN is incorrect"},
           {SCARD_E_UNKNOWN_RES_MNG  , "An unrecognized error code was returned from a layered component"},
           {SCARD_E_NO_SUCH_CERTIFICATE  , "The requested certificate does not exist."},
           {SCARD_E_CERTIFICATE_UNAVAILABLE  , "The requested certificate could not be obtained."},
           {SCARD_E_NO_READERS_AVAILABLE  , "None of the specified readers are currently available for use"},
           {SCARD_W_UNSUPPORTED_CARD  , "The reader cannot communicate with the card, due to ATR configuration conflicts"},
           {SCARD_W_UNRESPONSIVE_CARD  , "The card is not responding to a reset"},
           {SCARD_W_UNPOWERED_CARD  , "Power has been removed from the card, so that further communication is not possible"},
           {SCARD_W_RESET_CARD  , "The card has been reset, so any shared state information is invalid"},
           {SCARD_W_REMOVED_CARD  , "The card has been removed, so that further communication is not possible"},
           {SCARD_W_SECURITY_VIOLATION  , "Access was denied because of a security violation"},
           {SCARD_W_WRONG_CHV  , "The card cannot be accessed because the wrong PIN was presented"},
           {SCARD_W_CHV_BLOCKED  , "The card cannot be accessed because the maximum number of PIN entry attempts has been reached"},
           {SCARD_W_EOF  , "The end of the card file has been reached"},
           {SCARD_W_CANCELLED_BY_USER  , "The action was cancelled by the user"},
           {SCARD_M_SUCCESS  , "Operation success"},
           {SCARD_M_CARD_ABSENT  , "The card is not in the reader"},
           {SCARD_M_NO_RESPONSE  , "The card does not response any thing"},
           {SCARD_M_POWER_FAIL  , "Power the card fail"},
           {SCARD_M_COMM_ERROR  , "Communication error"},
           {SCARD_M_VERIFY_FAIL  , "Verify codes fail"},
           {SCARD_M_TYPE_ERROR  , "Card Type Error"},
           {SCARD_M_COMMAND_ERROR  , "The command to the card Error"},
           {SCARD_M_COUNTER_EMPTY  , "Counter of card is empty"},
           {SCARD_M_CARD_LOCKED  , "The card is locked"},
           {SCARD_M_WRITE_ERROR  , "Write to the card error"},
           {SCARD_M_CHECK_ERROR  , "Check if previously written data is really written"},
           {SCARD_M_OTHER_FAIL  , "Other fail"},
           {SCARD_MI_CRCERR , "PICC response with CRC error"},
           {SCARD_MI_AUTHERR ,"Mifare authen error"},
           {SCARD_MI_PARITYERR ,"PICC response with parity error"},
           {SCARD_MI_CODEERR ,"Received Mifare NAK"},
           {SCARD_MI_NOTAUTHERR,"Mifare have not been authenticated"},
           {SCARD_MI_BITCOUNTERR,"PICC response with error bit length"},
           {SCARD_MI_BYTECOUNTERR,"PICC response with error number of byte"},
           {SCARD_MI_OVFLERR ,"Internal FIFO overflow"},
           {SCARD_MI_FRAMINGERR,"PICC response with invalid frame"},
           {SCARD_MI_COLLERR ,"Collision have been detected"},
           {SCARD_MI_ACCESSTIMEOUT,"PICC not response"},
           {SCARD_MI_CODINGERR ,"PICC response with bit-coding error"},
           {SCARD_MI_PROTOCOLERR ,"T=CL protocol error"},
           {SCARD_MI_RFERR ,"Antenna hardware error"},
           {SCARD_MI_TEMPERR ,"Temperature"},
           {SCARD_MI_WRERR ,"EEPROM write error"},
           {SCARD_MI_VALERR ,"PICC response with error value"},
           {SCARD_MI_OTHERERR,"Unspecific error"},
           {SCARD_MI_NOTSUPPORT,"Command not support"}
        };

        public static string returnErrorStr(uint result)
        {
            string error_str = "";
            if (error_dictionary.ContainsKey(result))
                error_dictionary.TryGetValue(result, out error_str);
            return error_str;
        }

        #endregion
    }
}

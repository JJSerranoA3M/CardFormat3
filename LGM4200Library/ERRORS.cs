using System.Collections.Generic;

namespace LGM4200Library
{
    public class ERRORS
    {
        #region -   errors definitions   -

        public static uint d_NO_ERROR = 0x00000000;
        public static uint d_INIT_COM_ERROR = 0x80000001;
        public static uint d_INVALID_HANDLE = 0x80000002;
        public static uint d_INVALID_PARA = 0x80000003;
        public static uint d_COMM_FAIL = 0x80000004;
        public static uint d_RSP_LEN_ERROR = 0x80000005;
        public static uint d_RSP_CMD_ERROR = 0x80000006;
        public static uint d_OUT_OF_DATA_LEN = 0x80000007;
        public static uint d_SN_INCORRECT = 0x80000008;
        public static uint d_RSP_DATA_LEN_ERROR = 0x80000009;
        public static uint d_RSP_ID_ERROR = 0x8000000A;
        public static uint d_BASE_INDEX_ERROR = 0x8000000B;
        public static uint d_MSession_NOT_READY = 0x8000000C;
        public static uint d_ASession_NOT_READY = 0x8000000D;
        public static uint d_COM_NOT_OPENED = 0x8000000E;
        public static uint d_USB_NOT_OPENED = 0x8000000F;
        public static uint d_OPEN_USB_ERROR = 0x80000010;
        public static uint d_COM_TX_FAIL = 0x80000011;
        public static uint d_COM_RX_FAIL = 0x80000012;
        public static uint d_USB_TX_FAIL = 0x80000013;
        public static uint d_USB_RX_FAIL = 0x80000014;
        public static uint d_CMD_ID_INCORRECT = 0x80000015;
        public static uint d_HOST_ID_INCORRECT = 0x80000016;
        public static uint d_READER_ID_INCORRECT = 0x80000017;
        public static uint d_CBN_ERROR = 0x80000018;
        public static uint d_UNKNOWN_PROTOCOL_MODE = 0x80000019;
        public static uint d_SOCKET_ERROR = 0x80000020;
        public static uint d_TCP_IO_TX_FAIL = 0x80000021;
        public static uint d_TCP_IO_RX_FAIL = 0x80000022;
        public static uint d_TCP_TX_LEN_ERROR = 0x80000023;



        public static uint RC_SUCCESS = 0xA0000000;// General response code indicating a successful action in the reader
        public static uint RC_DATA = 0xA0000001;//Contactless card data available from contactless reader to initiate the Transaction.
        public static uint RC_POLL_A = 0xA0000002;//Positive acknowledgement from the reader. The reader and base unit have performed mutual authentication.
        public static uint RC_POLL_B = 0xA0000003;//Positive acknowledgement from the reader. The reader and base unit have not performed mutual authentication.
        public static uint RC_SCHEME_SUPPORTED = 0xA0000004;//The payment scheme is supported by the reader.
        public static uint RC_SIGNATURE = 0xA0000005;//Signature is required.
        public static uint RC_ONLINE_PIN = 0xA0000006;//Online PIN is required.
        public static uint RC_OFFLINE_PIN = 0xA0000007;//Offline PIN is required.
        public static uint RC_FAILURE = 0xA00000FF;//General failure. Reasons varies based on the request message.
        public static uint RC_ACCESS_NOT_PERFORMED = 0xA00000FE;//Access Condition to switch to administrative mode has not performed.
        public static uint RC_ACCESS_FAILURE = 0xA00000FD;//Access Condition to switch to administrative mode failed.
        public static uint RC_AUTH_FAILURE = 0xA00000FC;//Mutual Authentication is failed FAIL.
        public static uint RC_AUTH_NOT_PERFORMED = 0xA00000FB;//Mutual Authentication has not performed.
        public static uint RC_DDA_AUTH_FAILURE = 0xA00000FA;//DDA authentication failed.
        public static uint RC_INVALID_COMMAND = 0xA00000F9;//The Instruction Identifier/ command is incorrect. No such command (This is a generic command and the reader can respond any time if it the command is nknown).



        public static uint RC_INVALID_DATA = 0xA00000F8;//Variable data field of the request message is incorrect.
        public static uint RC_INVALID_PARAM = 0xA00000F7;//No such parameters.
        public static uint RC_INVALID_KEYINDEX = 0xA00000F6;//If the base unit request the reader to generate M session key prior to the generaion of MEK or A session key prior to the generation of AEK.
        public static uint RC_INVALID_SCHEME = 0xA00000F5;//Base unit trying to activate a scheme that is not supported by the reader.
        public static uint RC_INVALID_VISA_CA_KEY = 0xA00000F4;//Invalid Visa CA Key Index.
        public static uint RC_MORE_CARDS = 0xA00000F3;//More than 1 card.
        public static uint RC_NO_CARD = 0xA00000F2;//Contactless card is not present.
        public static uint RC_NO_EMV_TAGS = 0xA00000F1;//The reader does not support the tags.
        public static uint RC_NO_PARAMETER = 0xA00000F0;//No such parameters defined.
        public static uint RC_POLL_N = 0xA00000EF;//Negative Acknowledgement from the reader. The reader is not ready.
        public static uint RC_Other_AP_CARDS = 0xA00000EE;//Visa Wave cards are from other AP Countries.
        public static uint RC_US_CARDS = 0xA00000ED;//Contactless oid US cards.
        public static uint RC_NO_PIN = 0xA00000EC;//PIN not entered.
        public static uint RC_NO_SIG = 0xA00000EB;//Signature notsigned on screen.
        public static uint SC_FAIL = 0xB0000001;//Trancaction fail.
        public static uint SC_INEFFECTIVE_DATA = 0xB0000002;//Data incorrect
        public static uint SC_AUTHEN_STATE_NOT_PERFORM = 0xB0000003;//Mutual Authentication not perform.
        public static uint SC_AUTHEN_FAIL = 0xB0000004;//Authentication fail.
        public static uint SC_INEFFECTIVE_PARAMETER = 0xB0000005;//Parameter value incorrect.
        public static uint SC_INEFFECTIVE_MODE = 0xB0000006;//Mode incorrect.
        public static uint SC_INEFFECTIVE_CMD = 0xB0000007;//CMD not support.
        public static uint SC_INEFFECTIVECA_KEY = 0xB0000008;//CA Public Key incorrect.
        public static uint SC_INEFFECTIVE_KEY_ID = 0xB0000009;//Key ID incorrect.





        #endregion

        static Dictionary<uint, string> error_dictionary = new Dictionary<uint, string>()
        {
           {d_NO_ERROR, "Success"},
           {d_INIT_COM_ERROR, "Initiali communication error"},
           {d_INVALID_HANDLE, "Invalid handle"},
           {d_INVALID_PARA, "Invalid parameter"},
            {d_COMM_FAIL        ,       "Communication fail"},
            {d_RSP_LEN_ERROR    ,       "Response length error"},
            {d_RSP_CMD_ERROR    ,       "Response command error"},
            { d_OUT_OF_DATA_LEN,        "Out of data length"},
            { d_SN_INCORRECT    ,       "Secuence number incorrect"},
            { d_RSP_DATA_LEN_ERROR  ,"Response data length error"},
            {d_RSP_ID_ERROR     ,   "Response instruction ID incorrect"},
            { d_BASE_INDEX_ERROR    ,   "Response receiver index error"},
            { d_MSession_NOT_READY  ,"MSession key not ready"},
            { d_ASession_NOT_READY  ,"ASession key not ready"},
            {d_COM_NOT_OPENED   ,   "Com port not initial"},
            {d_USB_NOT_OPENED   ,   "USB not initial"},
            {d_OPEN_USB_ERROR   ,   "Open USB port fail"},
            {d_COM_TX_FAIL      ,   "Com port transmit data fail"},
            {d_COM_RX_FAIL      ,   "Com port received data fail"},
            {d_USB_TX_FAIL      ,   "USB port transmit data fail"},
            {d_USB_RX_FAIL      ,   "USB port received data fail"},
            { d_CMD_ID_INCORRECT    ,   "Command ID incorrect"},
            { d_HOST_ID_INCORRECT   ,   "Host ID incorrect"},
            { d_READER_ID_INCORRECT,    "Reader ID incorrect"},
            { d_CBN_ERROR           ,   "Chaining block number incorrect"},
            { d_UNKNOWN_PROTOCOL_MODE, "Communication protocol type unknown"},
            {d_SOCKET_ERROR     ,   "Invalid socket"},
            {d_TCP_IO_TX_FAIL   ,   "TCP I/O sending data error"},
            {d_TCP_IO_RX_FAIL   ,   "TCP I/O receiving data error"},
            { d_TCP_TX_LEN_ERROR , "TCP sending data length incorrect"},
             {RC_SUCCESS , " General response code indicating a successful action in the reader"},
            {RC_DATA , "Contactless card data available from contactless reader to initiate the Transaction."},
            {RC_POLL_A , "Positive acknowledgement from the reader. The reader and base unit have performed mutual authentication."},
            {RC_POLL_B , "Positive acknowledgement from the reader. The reader and base unit have not performed mutual authentication."},
            {RC_SCHEME_SUPPORTED , "The payment scheme is supported by the reader."},
            {RC_SIGNATURE , "Signature is required."},
            {RC_ONLINE_PIN , "Online PIN is required."},
            {RC_OFFLINE_PIN,"Offline PIN is required."},
            {RC_FAILURE,"General failure. Reasons varies based on the request message."},
            {RC_ACCESS_NOT_PERFORMED,"Access Condition to switch to administrative mode has not performed."},
            {RC_ACCESS_FAILURE,"Access Condition to switch to administrative mode failed."},
            {RC_AUTH_FAILURE,"Mutual Authentication is failed FAIL."},
            {RC_AUTH_NOT_PERFORMED,"Mutual Authentication has not performed."},
            {RC_DDA_AUTH_FAILURE , "DDA authentication failed."},
            {RC_INVALID_COMMAND , "The Instruction Identifier/ command is incorrect. No such command (This is a generic command and the reader can respond any time if it the command is nknown)."},
            {RC_INVALID_DATA,"Variable data field of the request message is incorrect."},
            {RC_INVALID_PARAM,"No such parameters."},
            {RC_INVALID_KEYINDEX,"If the base unit request the reader to generate M session key prior to the generaion of MEK or A session key prior to the generation of AEK."},
            {RC_INVALID_SCHEME,"Base unit trying to activate a scheme that is not supported by the reader."},
            {RC_INVALID_VISA_CA_KEY,"Invalid Visa CA Key Index."},
            {RC_MORE_CARDS , "More than 1 card."},
            {RC_NO_CARD , "Contactless card is not present."},
            {RC_NO_EMV_TAGS ,"The reader does not support the tags."},
            {RC_NO_PARAMETER , "No such parameters defined."},
            {RC_POLL_N , "Negative Acknowledgement from the reader. The reader is not ready."},
            {RC_Other_AP_CARDS ,"Visa Wave cards are from other AP Countries."},
            {RC_US_CARDS,"Contactless oid US cards."},
            {RC_NO_PIN,"PIN not entered."},
            {RC_NO_SIG,"Signature notsigned on screen."},
            {SC_FAIL,"Trancaction fail."},
            {SC_INEFFECTIVE_DATA,"Data incorrect"},
            {SC_AUTHEN_STATE_NOT_PERFORM,"Mutual Authentication not perform."},
            {SC_AUTHEN_FAIL,"Authentication fail."},
            {SC_INEFFECTIVE_PARAMETER,"Parameter value incorrect."},
            {SC_INEFFECTIVE_MODE,"Mode incorrect."},
            {SC_INEFFECTIVE_CMD,"CMD not support."},
            {SC_INEFFECTIVECA_KEY,"CA Public Key incorrect."},
            {SC_INEFFECTIVE_KEY_ID,"Key ID incorrect."}
        };

        public static string returnErrorStr(uint result)
        {
            string error_str = "";
            if (error_dictionary.ContainsKey(result))
                error_dictionary.TryGetValue(result, out error_str);
            return error_str;
        }
    }
}
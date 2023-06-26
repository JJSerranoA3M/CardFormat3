/********************************************************************
  Module Name: EZProxAPI.h
 --------------------------------------------------------------------
 v1.01  2006.06.16	Release
 v1.02	2006.06.30	Modify function parameters
 v1.03  2006.07.04  Modify proprietary function return code
 v1.031 2006.07.06  Modify smart card function return code
 v1.032 2006.07.31  Add GP_DES function
 v1.04  2006.09.05  Add CAS_UserCMD(),GP_PackData(),GP_UnpackData() & Mifare related functions
 v1.041 2006.10.03	Fixed bug in CAS_GetEMVTags() function
 v1.042 2006.11.22  Add USB new functions : CAS_SetCommunicationMode(),CAS_GetCommunicationMode(),CAS_OpenUSB() and
					CAS_CloseUSB()
 v1.050 2006.11.27  Add DLE protocol for all functions and add new functions : CAS_SetProtocolMode(),CAS_GetProtocolMode(),CAS_ICCInitial().
 v1.051 2006.12.11  Add new function : CAS_SetLEDTwinkle().
 v1.06  2007.04.03  Add new function CAS_Complete() for AE 
 v1.07  2007.04.12  Add new functions CAS_NAKPollStart(),CAS_NAKPollStop() and CAS_NAKPollSet()
 v1.08  2007.04.24  Modify VW_USBReadWrite() function
		2007.04.25  Modify CAS_Complete() function for AE with DLE Protocol
 v2.0   2007.05.29	Add new function CAS_SetJCBPublicKey(), CAS_GetJCBPublicKey()
					Add CAS_GetReaderType() to release version
		2007.05.30	Modify coding if Sequance Number is equal to 0xFF which base on VisaWave Spec change
		2007.07.25	Add Baud rate index 0x05(d_BAUDRATE_9600) in VW_SetBaudRate()
 v2.1   2007.10.02  Add new functions CAS_InitTransaction() & CAS_PollTransaction()
 v2.102 2007.10.29  Modify CAS_CAS_GetCAPublicKey()& CAS_GetJCBPublicKey()
 v2.2	2007.11.19  Add CAS_ConnectTCP() and CAS_CloseTCP() functions
 v3.0   2007.12.31  Add some functions for DLE protocol with payPass transaction use 
					Modify coding in VisaWave Protocol related functions
					Remove Baud Rate index 0x05(d_VW_BAUDRATE_9600) from CAS_SetBaudRate()
        2008.02.13  Modify coding for bSN in some proprietary commands
		2008.03.11	Change the definition value of d_UNKNOWN_PROTOCOL_MODE
		2008.04.11	Add new function CAS_StartTransactionHyWave()
 ********************************************************************************/
#ifdef __cplusplus
extern "C" {
#endif

// Definition 
#define d_COMM_COM1		0
#define d_COMM_COM2		1
#define d_COMM_COM3		2
#define d_COMM_COM4		3
#define d_COMM_COM5		4
#define d_COMM_COM6		5
#define d_COMM_COM7		6
#define d_COMM_COM8		7
#define d_COMM_COM9		8
#define d_COMM_USB1		0x80
#define d_COMM_USB2		0x81
#define d_COMM_USB3		0x82
#define d_COMM_USB4		0x83

// Definition for Type of Communication
#define d_UNKNOWN_COMMUNICATION_MODE	0xAA
#define d_TCP_MODE						0xDD
#define d_RS232_MODE					0xEE
#define d_USB_MODE						0xFF

// Definition for Type of Protocol
//#define d_UNKNOWN_PROTOCOL_MODE			0xBB
#define d_VW_MODE						0xCC
#define d_DLE_MODE						0xDD

#define d_CA_KEY_ADD					0x00
#define d_CA_KEY_DELETE					0x01
#define d_CA_KEY_GET_ALL				0xFF
#define d_MODE_DEBUG					0x00
#define d_MODE_NORMAL					0x01
#define d_MODE_ADMIN					0x02
#define d_SCHEME_ACTIVE					0x00
#define d_SCHEME_DEACTIVE				0x01
#define d_SCHEME_GET_ALL				0xFF
#define d_SCHEME_SUPPORT				0x01
#define d_SCHEME_NOT_SUPPORT			0x00
#define d_TAGS_GET_ALL					0xFF
#define d_MESSAGES_GET_ALL				0xFF
#define d_CVM_ACTIVE					0x01
#define d_CVM_DEACTIVE					0x00
#define d_CMV_GET_ALL					0xFF
#define	d_IMEK_MDK						0x00
#define	d_IMEK							0x01
#define d_MEK							0x02
#define d_Msession						0x03
#define	d_IAEK_MDK						0x04
#define	d_IAEK							0x05
#define	d_AEK							0x06
#define d_Asession						0x07
#define	d_BAUDRATE_115200				0x00
#define	d_BAUDRATE_57600				0x01
#define	d_BAUDRATE_38400				0x02
#define	d_BAUDRATE_28800				0x03
#define	d_BAUDRATE_19200				0x04
#define	d_BAUDRATE_9600					0x05
#define	d_CVM_NOT_SUPPORT				0x00
#define	d_CVM_SIGNATURE					0x10
#define	d_CVM_ONLINE_PIN				0x11
#define	d_CVM_OFFLINE_PIN				0x12
#define d_ON							0x01
#define d_OFF							0x00
#define d_SAM1							0x01
#define d_SAM2							0x02
#define d_SAM3							0x03
#define d_SAM4							0x04
#define d_5V							0x01
#define d_3V							0x02
#define d_18V							0x03
#define d_EMV							0x01
#define d_NONEMV						0x00
#define d_PTS							0x01
#define d_NOPTS							0x00
#define d_IFSD							0x01
#define d_NOIFSD						0x00
#define d_DECRYPTION					0   //DES Decryption
#define d_ENCRYPTION					1   //DES Encryption
#define d_TYPEKEYA						0X60	
#define d_TYPEKEYB						0X61
#define d_ACT_ONL_APPR					0x01
#define d_ACT_ONL_DENY					0x02
#define d_ACT_UNAB_ONL					0x03
#define d_ACT_ONL_ISSUER_REFERRAL_APPR	0x04
#define d_ACT_ONL_ISSUER_REFERRAL_DENY	0x05
#define d_CPP_GETALL					0x00

#define	d_NO_ERROR				0x00000000
#define	d_INIT_COM_ERROR		0x80000001
#define d_INVALID_HANDLE		0x80000002
#define	d_INVALID_PARA			0x80000003
#define	d_COMM_FAIL				0x80000004
#define	d_RSP_LEN_ERROR			0x80000005
#define	d_RSP_CMD_ERROR			0x80000006
#define d_OUT_OF_DATA_LEN		0x80000007
#define d_SN_INCORRECT			0x80000008
#define d_RSP_DATA_LEN_ERROR	0x80000009
#define	d_RSP_ID_ERROR			0x8000000A
#define d_BASE_INDEX_ERROR		0x8000000B
#define d_MSession_NOT_READY	0x8000000C
#define d_ASession_NOT_READY	0x8000000D
#define	d_COM_NOT_OPENED		0x8000000E
#define	d_USB_NOT_OPENED		0x8000000F
#define	d_OPEN_USB_ERROR		0x80000010
#define	d_COM_TX_FAIL			0x80000011
#define	d_COM_RX_FAIL			0x80000012
#define	d_USB_TX_FAIL			0x80000013
#define	d_USB_RX_FAIL			0x80000014
#define d_CMD_ID_INCORRECT		0x80000015
#define d_HOST_ID_INCORRECT		0x80000016
#define d_READER_ID_INCORRECT	0x80000017
#define d_CBN_ERROR				0x80000018
#define d_UNKNOWN_PROTOCOL_MODE 0x80000019
#define	d_SOCKET_ERROR			0x80000020
#define	d_TCP_IO_TX_FAIL		0x80000021
#define	d_TCP_IO_RX_FAIL		0x80000022
#define	d_TCP_TX_LEN_ERROR		0x80000023

typedef	char			CHAR;
typedef	unsigned char	UCHAR;
typedef	unsigned char	str;
typedef	unsigned char	BYTE;
typedef	short			SHORT;
typedef	unsigned short	USHORT;
typedef	unsigned short	WORD;
typedef	long			LONG;
typedef	unsigned long	ULONG;
typedef	unsigned long	DWORD;

typedef struct {
	BYTE		bSID;				//Scheme Identifier
	BYTE		baDateTime[15];		//YYYYMMDDHHMMSS format
	BYTE		bTrack1Len;
	BYTE        baTrack1Data[100];	//ANS 
	BYTE		bTrack2Len;
	BYTE        baTrack2Data[100];	//ASCII
	BYTE        bChipDataLen;		//Chip Data
	BYTE        baChipData[256];
	BYTE        bAdditionalDataLen;	//Additional Data
	BYTE        baAdditionalData[256];
}RC_DATA;

typedef struct {
	BYTE		bStatus;		//0x00: Success, 0x01: Error
	BYTE		bNoM;			//Number of Message
	BYTE        baMessage[20][80];
}STATUS_INFO;

typedef struct {
	BYTE		bAction;		//0x00: Key Addition, 0x01: Key Deletion
	BYTE		bIndex;			// Key Index
	UINT		uiModulusLen;	// Length of Modulus
	BYTE		baModulus[248];	// Modulus
	UINT		uiExponentLen;	// Length of Extension
	BYTE		baExponent[3];	// Extension
	BYTE		baHash[20]; 	// Key Hash (SHA-1) Result
}CA_PUBLIC_KEY;

typedef struct {
	UINT		uiNoP;			// Number of Parameters
	UINT		uiIndex[100];	// Parameter Index
	UINT		uiLen[100];		// Length of Parameter Data
	BYTE		baData[100][20];// Parameter Data
}PARAMETER_DATA;

typedef struct {
	BYTE		bNoS;			// Number of Schemes
	BYTE		baID[255];		// Scheme ID
	BYTE		baAction[255];	// Active or deactive
}SCHEME_DATA;

typedef struct {
	BYTE		bKeyType;		// Key Type
	BYTE		bKeyIndex;		// Key Index
	BYTE		baRND_R[8];		// Random Number R
	BYTE		baEnRND[16];	// Encrypted Random Number B & R
}AUTHKEY_DATA;					// baEnRND[0..7]: RND_B// baEnRND[8..15]: RND_R

typedef struct {
	BYTE		bNoMsg;				// Number of Message
	BYTE		baMsgID[30];		// Message ID
	BYTE		baMsgLen[30];		// Message ID length
	BYTE		baMsgData[30][80];	// Message Data
}MESSAGE_DATA;

typedef struct {
	BYTE		bNoCVM;			// Number of CVM
	BYTE		baCVMID[10];	// CVM ID
	BYTE		baAction[10];	// Active or deactive
}CVM_DATA;

typedef struct {
	BYTE		bCardType;			//Card Type
	USHORT		usTxResult;			//Transaction Result
	BYTE		bT1Len;				//Track 1 Length
	BYTE        baT1Data[256];		//Track 1 Data
	BYTE		bT2Len;				//Track 2 Length
	BYTE        baT2Data[256];		//Track 2 Data
	USHORT      usChipDataLen;		//Chip Data Length
	BYTE        baChipData[65536];	//Chip Data
}SALE_DATAOUT;

typedef struct {
	BYTE		baRID[5];			//RID
	BYTE		bCAPKI;				//CP Public Key Index
	BYTE		bModulusLen;		//Modulus Length
	BYTE		baModulus[248];		//Modulus
	BYTE		bExponentLen;		//Extension Length
	BYTE		baExponent[3];		//Extension
	BYTE		baHash[20]; 		//Key Hash (SHA-1) Result
}CAPK_DATA;
/*****************************************************/
extern void WINAPI CAS_SetCommunicationMode(IN BYTE bType);

extern ULONG WINAPI CAS_GetCommunicationMode(void);

extern void WINAPI CAS_SetProtocolMode(IN BYTE bType);

extern ULONG WINAPI CAS_GetProtocolMode(void);

extern ULONG WINAPI CAS_InitComm(
	IN	ULONG		PortNumber,
	IN	BYTE		bBaudRateIndex,
	OUT HANDLE		*hHandle
	);

extern ULONG WINAPI CAS_CloseComm(
	HANDLE	hHandle
	);
extern ULONG WINAPI CAS_OpenUSB(
	OUT HANDLE		*hHandle
	);
extern ULONG WINAPI CAS_CloseUSB(
	HANDLE	hHandle
	);
extern ULONG WINAPI CAS_ConnectTCP(
	IN	char		*caIPAddr,
	IN	USHORT		usPortNo,
	OUT HANDLE		*hHandle
	);
extern ULONG WINAPI CAS_CloseTCP(
	HANDLE	hHandle
	);
extern ULONG WINAPI CAS_TimeOut_Set(ULONG ulMS);
extern ULONG WINAPI CAS_SetSenderIndex(UINT	uiSIndex);
extern ULONG WINAPI CAS_SetReceiverIndex(UINT uiRIndex);
extern ULONG WINAPI CAS_SetSessionKey(
	IN BYTE	bKeyID,
	IN	BYTE	*baKeyData
	);
extern void WINAPI CAS_GetAPIVersion(
	OUT char *cVer
	);
extern void WINAPI GP_DES(
	IN	int		iE_D,
	IN	BYTE	bKeyLen,
	IN	BYTE	*baKey,
	IN	BYTE	*baData,
	OUT	BYTE	*baOut
	);
extern void WINAPI GP_PackData(
	IN	BYTE	*baSBuf,
	IN	UINT	uiLen,
	OUT	BYTE	*baTBuf 
	);
extern void WINAPI GP_UnpackData(
	IN	BYTE	*baSBuf, 
	IN	UINT	uiLen,
	OUT	BYTE	*baTBuf
	);
/*********** VISA WAVE Messages **********/
//--- POLL, Echo and Optimization Messages ---
extern ULONG WINAPI CAS_Poll(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_Echo(
	IN	HANDLE		hHandle,	
	IN	BYTE		*baSBuf,
	IN	UINT		uiSLen,
	OUT	BYTE		*baRBuf,
	OUT	UINT		*uiRLen
	);
extern ULONG WINAPI CAS_SetMode(
	IN	HANDLE		hHandle,
	IN	BYTE		bMode
	);
extern ULONG WINAPI CAS_SetParameter(
	IN	HANDLE			hHandle,
	IN	PARAMETER_DATA	*stPara
	);
//--- Authentication Messages ---
extern ULONG WINAPI CAS_InitializeCommunication(
	IN	HANDLE			hHandle,	
	IN	BYTE			bKeyType,
	IN	BYTE			bKeyIndex,
	IN	BYTE			*baRNDB,
	OUT	AUTHKEY_DATA	*stKeyData
	);
extern ULONG WINAPI CAS_MutualAuthenticate(
	IN	HANDLE			hHandle,	
	IN	AUTHKEY_DATA	*stKeyData
	);
extern ULONG WINAPI CAS_GenerateKeys(
	IN	HANDLE			hHandle,	
	IN	AUTHKEY_DATA	*stKeyData
	);
extern ULONG WINAPI CAS_InvalidReader(
	IN	HANDLE			hHandle
	);
//--- Transaction Messages ---
extern ULONG WINAPI CAS_StartTransaction(
	IN	HANDLE		hHandle,
	IN	ULONG		ulAmount,
	OUT RC_DATA		*stRCData
	);
extern ULONG WINAPI CAS_Reset(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_ShowStatus(
	IN	HANDLE		hHandle,
	IN	BYTE		*baBuf,
	IN	UINT		uiLen
	);
extern ULONG WINAPI CAS_InitTransaction(
	IN	HANDLE		hHandle,
	IN	ULONG		ulAmount
	);
extern ULONG WINAPI CAS_PollTransaction(
	IN	HANDLE		hHandle,
	IN	ULONG		ulMS,
	OUT RC_DATA		*stRCData
	);
extern ULONG WINAPI CAS_Complete(
	IN HANDLE		hHandle,
	IN BYTE			bAction,
	IN BYTE			*baARC,
	IN UINT			uiIADLen,
	IN BYTE			*baIAD,
	IN UINT			uiScriptLen,
	IN BYTE			*baScript,
	OUT RC_DATA		*stRCData
 );
extern ULONG WINAPI CAS_StartTransactionHyWave(
	IN	HANDLE		hHandle,
	IN	ULONG		ulAmount,
	IN	BYTE		bRedeemFlag,
	OUT RC_DATA		*stRCData
	);
//--- Administative Messages ---
extern ULONG WINAPI CAS_SwitchToAdministrativeMode(
	IN	HANDLE		hHandle,
	IN	BYTE		bMode,
	OUT	BYTE		*baBuf
	);
extern ULONG WINAPI CAS_GetCapability(
	IN		HANDLE			hHandle,
	IN OUT	SCHEME_DATA		*stScheme
	);
extern ULONG WINAPI CAS_SetCapability(
	IN	HANDLE			hHandle,
	IN	SCHEME_DATA		*stScheme,
	OUT	SCHEME_DATA		*stRsp
	);
extern ULONG WINAPI CAS_GetDateTime(
	IN	HANDLE		hHandle,
	OUT	BYTE		*baDateTime
	);
extern ULONG WINAPI CAS_SetDateTime(
	IN	HANDLE		hHandle,
	IN	BYTE		*baDateTime
	);
extern ULONG WINAPI CAS_GetParameter(
	IN	HANDLE			hHandle,
	IN	UINT			uiPID,
	OUT	PARAMETER_DATA	*stPara
	);
extern ULONG WINAPI CAS_GetCAPublicKey(
	IN	HANDLE			hHandle,
	IN	BYTE			bKID,
	OUT	CA_PUBLIC_KEY	*stCAPubKey,
	OUT BYTE			*bNoK
	);
extern ULONG WINAPI CAS_SetCAPublicKey(
	IN	HANDLE			hHandle,
	IN	CA_PUBLIC_KEY	*stCAPubKey
	);
extern ULONG WINAPI CAS_GetBaudRate(
	IN	HANDLE			hHandle,
	OUT	BYTE			*bBaudRateIndex
	);
extern ULONG WINAPI CAS_SetBaudRate(
	IN	HANDLE			hHandle,
	IN	BYTE			bBaudRateIndex
	);
extern ULONG WINAPI CAS_ResetAcquirerKey(
	IN	HANDLE			hHandle,
	IN	BYTE			bKeyType,
	IN	BYTE			bKeyIndex
	);
extern ULONG WINAPI CAS_ReaderRecovery(
	IN	HANDLE			hHandle
	);
extern ULONG WINAPI CAS_GetEMVTags(
	IN	HANDLE		hHandle,
	IN	BYTE		bTagNo,
	IN	BYTE		*baTagsData,
	IN	UINT		uiTagLen,
	OUT BYTE		*baRBuf,
	OUT UINT		*uiRLen
	);
extern ULONG WINAPI CAS_SetEMVTags(
	IN	HANDLE		hHandle,
	IN	BYTE		*baTagsData,
	IN	UINT		uiTagLen,
	OUT BYTE		*baRBuf,
	OUT UINT		*uiRLen
	);
extern ULONG WINAPI CAS_GetDisplayMessage(
	IN	HANDLE			hHandle,
	IN	BYTE			bMsgID,
	OUT MESSAGE_DATA	*stMessage
	);
extern ULONG WINAPI CAS_SetDisplayMessage(
	IN	HANDLE			hHandle,
	IN	MESSAGE_DATA	*stMessage,
	OUT MESSAGE_DATA	*stRsp
	);
extern ULONG WINAPI CAS_GetCVMCapability(
	IN	HANDLE			hHandle,
	IN	BYTE			bCVMID,
	OUT CVM_DATA		*stCVMData
	);
extern ULONG WINAPI CAS_SetCVMCapability(
	IN	HANDLE			hHandle,
	IN	CVM_DATA		*stCVMData,
	OUT CVM_DATA		*stRsp
	);
extern ULONG WINAPI CAS_GetJCBPublicKey(
	IN	HANDLE			hHandle,
	IN	BYTE			bKID,
	OUT	CA_PUBLIC_KEY	*stCAPubKey,
	OUT BYTE			*bNoK
	);
extern ULONG WINAPI CAS_SetJCBPublicKey(
	IN	HANDLE			hHandle,
	IN	CA_PUBLIC_KEY	*stCAPubKey
	);
//--- Proprietary Messag ---
extern ULONG WINAPI CAS_TypeA_ActiveIdle(
	IN	HANDLE		hHandle,
	IN	BYTE		bBaudRate,
	OUT	BYTE		*baATQA,
	OUT	BYTE		*bSAK,
	OUT	BYTE		*bCSN_Length,
	OUT	BYTE		*baCSN
	);
extern ULONG WINAPI CAS_TypeA_RATS(
	IN	HANDLE		hHandle,
	IN	BYTE		bAutoPPS,
	OUT	BYTE		*baATS,
	OUT	UINT		*uiRLen
	);
extern ULONG WINAPI CAS_TCL_APDU(
	IN	HANDLE		hHandle,
	IN	BYTE		*baAPDU,
	IN	UINT		uiSLen,
	OUT	BYTE		*baRBuf,
	OUT	UINT		*uiRLen
	);
extern ULONG WINAPI CAS_TCL_DESELECT(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_TypeB_PowerOn(
	IN	HANDLE		hHandle,
	OUT	BYTE		*baPUPI
	);
extern ULONG WINAPI CAS_Display(
	IN	HANDLE		hHandle,
	IN	BYTE		bFlag,
	IN	BYTE		bX,
	IN	BYTE		bY,
	IN	BYTE		*baMsgBuf,
	IN	UINT		uiSLen
	);
extern ULONG WINAPI CAS_Sound(
	IN	HANDLE		hHandle,
	IN	USHORT		usFreq,
	IN	USHORT		usDuration
	);
extern ULONG WINAPI CAS_SetLCDBackLight(
	IN	HANDLE		hHandle,
	IN	BYTE		bOnOff
	);
extern ULONG WINAPI CAS_SetLED(
	IN	HANDLE		hHandle,
	IN	BYTE		bIndex,
	IN	BYTE		bOnOff
	);
extern ULONG WINAPI CAS_SetLEDTwinkle(
	IN	HANDLE		hHandle,
	IN	BYTE		bIndex,
	IN	BYTE		bOnOff,
	IN	BYTE		bBackLight,
	IN	BYTE		bBuzzer,
	IN	USHORT		usFreq,
	IN	USHORT		usDuration,
	IN	BYTE		*baMsgBuf,
	IN	UINT		uiSLen
	);
extern ULONG WINAPI CAS_ICCInitial(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_ICCheckInsert(
	IN	HANDLE		hHandle,
	IN	BYTE		bSocketID
	);
extern ULONG WINAPI CAS_ICCPowerOn(
	IN	HANDLE		hHandle,
	IN	BYTE		bSocketID,
	IN	BYTE		bVoltage,
	IN	BYTE		bEMV,
	IN	BYTE		bPTS,
	IN	BYTE		bIFSD,
	OUT	BYTE		*baATR,
	OUT	UINT		*uiRLen
	);
extern ULONG WINAPI CAS_ICCPowerOff(
	IN	HANDLE		hHandle,
	IN	BYTE		bSocketID
	);
extern ULONG WINAPI CAS_ICCSendAPDU(
	IN	HANDLE		hHandle,
	IN	BYTE		bSocketID,
	IN	BYTE		*baAPDU,
	IN	UINT		uiSLen,
	OUT	BYTE		*baRBuf,
	OUT	UINT		*uiRLen
	);
extern ULONG WINAPI CAS_SetCAPK(
	IN	HANDLE			hHandle,
	IN	BYTE			*baRID,
	IN	CA_PUBLIC_KEY	*stCAPubKey
	);
extern ULONG WINAPI CAS_GetCAPK(
	IN	HANDLE			hHandle,
	IN	BYTE			*baRID,
	IN	BYTE			bKID,
	OUT	CA_PUBLIC_KEY	*stCAPubKey
	);
extern ULONG WINAPI CAS_ListAllCAPKID(
	IN	HANDLE			hHandle,
	OUT BYTE			*baRBuf,
	OUT UINT			*uiRLen
	);
extern ULONG WINAPI CAS_UserCMD(
	IN	HANDLE		hHandle,	
	IN	BYTE		*baUCMD,
	IN	UINT		uiUCMDLen,
	OUT	BYTE		*baURESPON,
	OUT	UINT		*uiURESPONLen
	);
extern ULONG WINAPI CAS_PCDInit(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_PCDPowerOn(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_PCDPowerOff(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_MifareActiveHalt(
	IN	HANDLE		hHandle,
	IN	BYTE		bBaudRate,
	IN	BYTE		*baCSN,
	IN	BYTE		bCSN_Length,	
	OUT	BYTE		*baATQA,
	OUT	BYTE		*bSAK
	);
extern ULONG WINAPI CAS_MifareHaltA(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_MifareReadE2(
	IN	HANDLE		hHandle,
	IN	USHORT		usAddress,
	IN	BYTE		bLen,
	OUT	BYTE		*baData
	);
extern ULONG WINAPI CAS_MifareWriteE2(
	IN	HANDLE		hHandle,
	IN	USHORT		usAddress,
	IN	BYTE		bLen,
	IN	BYTE		*baData
	);
extern ULONG WINAPI CAS_MifareLoadKeyE2(
	IN	HANDLE		hHandle,
	IN	USHORT		usAddress
	);
extern ULONG WINAPI CAS_MifareLoadKey(
	IN	HANDLE		hHandle,
	IN	BYTE		*baKey
	);
extern ULONG WINAPI CAS_MifareAuth(
	IN	HANDLE		hHandle,
	IN	BYTE		bKeyType,
	IN	BYTE		bNBlock,
	IN	BYTE		*baCSN
	);
extern ULONG WINAPI CAS_MifareReadBlock(
	IN	HANDLE		hHandle,
	IN	BYTE		bNBlock,
	OUT	BYTE		*baData
	);
extern ULONG WINAPI CAS_MifareWriteBlock(
	IN	HANDLE		hHandle,
	IN	BYTE		bNBlock,
	IN	BYTE		*baData
	);
extern ULONG WINAPI CAS_MifareIncrement(
	IN	HANDLE		hHandle,
	IN	BYTE		bNBlock,
	IN	UINT		uiValue
	);
extern ULONG WINAPI CAS_MifareDecrement(
	IN	HANDLE		hHandle,
	IN	BYTE		bNBlock,
	IN	UINT		uiValue
	);
extern ULONG WINAPI CAS_MifareRestore(
	IN	HANDLE		hHandle,
	IN	BYTE		bNBlock
	);
extern ULONG WINAPI CAS_MifareTransfer(
	IN	HANDLE		hHandle,
	IN	BYTE		bNBlock
	);
extern ULONG WINAPI CAS_NAKPollStart(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_NAKPollStop(
	IN	HANDLE		hHandle
	);
extern ULONG WINAPI CAS_NAKPollSet(
	IN	HANDLE		hHandle,
	IN	BYTE		bOnOff,
	IN	BYTE		bInterval
	);
extern ULONG WINAPI CPP_GetReaderStatus(
	IN	HANDLE		hHandle,
	OUT	BYTE		*bAuthState,
	OUT	BYTE		*baRSN
	);
extern ULONG WINAPI CPP_InitAuthen(
	IN	HANDLE		hHandle,
	IN	BYTE		*baTRN,
	OUT	BYTE		*bKeyVer,
	OUT	BYTE		*baRRN,
	OUT	BYTE		*baRCrypto
	);
extern ULONG WINAPI CPP_MutualAuthen(
	IN	HANDLE		hHandle,
	IN	BYTE		*baAuthenKey,
	IN	BYTE		*baTCrypto
	);
extern ULONG WINAPI CPP_InjectKey(
	IN	HANDLE		hHandle,
	IN	BYTE		bKeyVer,
	IN	BYTE		*baKeyValue,
	IN	BYTE		*baCheckCode
	);		
extern ULONG WINAPI CPP_Sale(
	IN	HANDLE			hHandle,
	IN	ULONG			ulAmount,
	OUT	SALE_DATAOUT	*stRspData
	);
extern ULONG WINAPI CPP_InitSale(
	IN	HANDLE			hHandle,
	IN	ULONG			ulAmount
	);
extern ULONG WINAPI CPP_PollSale(
	IN	HANDLE			hHandle,
	IN	ULONG			ulMS,
	OUT	SALE_DATAOUT	*stRspData
	);
extern ULONG WINAPI CPP_Cancel(
	IN	HANDLE			hHandle
	);
extern ULONG WINAPI CPP_DisplayMessage(
	IN	HANDLE		hHandle,
	IN	BYTE		*baMsgID,
	IN	BYTE		bMsgIDLen
	);
extern ULONG WINAPI CPP_SetReaderSN(
	IN	HANDLE		hHandle,
	IN	BYTE		*baRSN
	);
extern ULONG WINAPI CPP_SetTags(
	IN	HANDLE		hHandle,
	IN	BYTE		bTagNum,
	IN	BYTE		*baTagData,
	IN	UINT		uiDLen
	);
extern ULONG WINAPI CPP_GetTags(
	IN		HANDLE		hHandle,
	IN OUT	BYTE		*bTagNum,
	IN OUT	BYTE		*baTagData,
	IN OUT	UINT		*uiDLen
	);
extern ULONG WINAPI CPP_SetCAPK(
	IN HANDLE			hHandle,
	IN CAPK_DATA		*stCAPKData
	);
extern ULONG WINAPI CPP_ListCAPKID(
	IN	HANDLE		hHandle,
	OUT	BYTE		*bCAPKNum,
	OUT	BYTE		*baCAPKList,
	OUT	UINT		*uiRLen
	);
extern ULONG WINAPI CPP_SetMessage(
	IN	HANDLE		hHandle,
	IN	BYTE		bMsgNum,
	IN	BYTE		*baMsgData,
	IN	UINT		uiDLen
	);
extern ULONG WINAPI CPP_GetMessage(
	IN		HANDLE		hHandle,
	IN OUT	BYTE		*bMsgNum,
	IN OUT	BYTE		*baMsgData,
	IN OUT	UINT		*uiDLen
	);
extern ULONG WINAPI CPP_SetParameters(
	IN	HANDLE		hHandle,
	IN	BYTE		bParamNum,
	IN	BYTE		*baParamData,
	IN	UINT		uiDLen
	);
extern ULONG WINAPI CPP_GetParameters(
	IN		HANDLE		hHandle,
	IN OUT	BYTE		*bParamNum,
	IN OUT	BYTE		*baParamData,
	IN OUT	UINT		*uiDLen
	);
extern ULONG WINAPI CPP_SetRTC(
	IN	HANDLE		hHandle,
	IN	BYTE		*baDateTime
	);
extern ULONG WINAPI CPP_GetRTC(
	IN	HANDLE		hHandle,
	OUT	BYTE		*baDateTime
	);
extern ULONG WINAPI CPP_SetBaudrateValue(
	IN	HANDLE		hHandle,
	IN	ULONG		ulBaudrate
	);
extern ULONG WINAPI CAS_GetReaderType(
	IN	HANDLE		hHandle,
	IN	BYTE		bVerFlag,
	OUT	BYTE		*baRdrType,
	OUT BYTE		*bRLen
	);
#ifdef __cplusplus
}
#endif
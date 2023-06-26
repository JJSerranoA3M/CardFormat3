using System;
using System.Text;
using CardLibrary.Cards;
using LGM4200Library;

namespace CardLibrary.Readers
{
    public class Lgm4200CardReader
    {
        #region variables

        private uint _handle, _rtn;

        private byte[] _baAtqa = new byte[2];
        private byte[] _baCsn = new byte[20];
        private byte[] _bSak = new byte[1];
        private byte[] _bCsnLen = new byte[1];
        private byte[] _baSBuf = new byte[12];

        private const byte KeyA = 0x60;
        // private byte _keyB = 0x61; //KEYB = 0x61

        private byte[] _baRBuf = new byte[16];

        private string _csn = "";

        #endregion

        public bool Open()
        {
            Initialize();

            //Halt the PICC of Type A
            LGM4200.CAS_MifareHaltA(_handle);


            _rtn = LGM4200.CAS_OpenUSB(ref _handle);
            if (_rtn != ERRORS.d_NO_ERROR)//fail
            {
                throw new Exception("ERROR: " + ERRORS.returnErrorStr(_rtn));
            }

            //Set response timeout
            LGM4200.CAS_TimeOut_Set(3000);

            //Establish a communication link between the PC and the reader and to determine whether
            //the reader is connected to the PC or not.
            _rtn = LGM4200.CAS_Poll(_handle);

            //The return code A000000002 means that the Mutual Authentication has performed.
            //The return code A000000003 means that the Mutual Authentication hasn't performed.
            if (_rtn != ERRORS.RC_POLL_A && _rtn != ERRORS.RC_POLL_B)
            {
                throw new Exception("ERROR: " + ERRORS.returnErrorStr(_rtn));
            }

            //BackLight
            LGM4200.CAS_SetLCDBackLight(_handle, 1);
            //Beep
            //LGM4200.CAS_Sound(handle, 990, 10);

            return true;
        }

        public void Beep()
        {
            //Beep
            LGM4200.CAS_Sound(_handle, 990, 10);
        }

        private void Initialize()
        {
            _handle = 0;
            _rtn = 0;

            _baAtqa = new byte[2];
            _baCsn = new byte[20];
            _bSak = new byte[1];
            _bCsnLen = new byte[1];
            _baSBuf = new byte[12];
            _baRBuf = new byte[16];

            _csn = "";
        }

        public void Close()
        {
            //Halt the PICC of Type A
            LGM4200.CAS_MifareHaltA(_handle);
            LGM4200.CAS_CloseUSB(_handle);
        }

        private byte[] ActiveIdle()
        {
            //Activate a PICC from its idle state. This command executes REQA, anti-collision loop, and 
            // SELECTA sequence for one of PICC in the field. After execution of Active_Idle command, the 
            //PICC goes from IDLE state to ACTIVE state, and is ready to enter ISO-14443-4 area.

            var resultado = LGM4200.CAS_TypeA_ActiveIdle(_handle, Convert.ToByte(0x00), _baAtqa, _bSak, _bCsnLen, _baCsn);

            if (resultado != ERRORS.d_NO_ERROR) throw new Exception("ERROR: " + ERRORS.returnErrorStr(_rtn));
            // get newSnr (2 possi
            var newSnr = new byte[_bCsnLen[0]];
            Array.Copy(_baCsn, newSnr, newSnr.Length);

            _csn = string.Empty;
            var sb = new StringBuilder(_bCsnLen[0]);
            for (var i = 0; i < _bCsnLen[0]; i++)
            {
                sb.AppendFormat("{0:x2}", _baCsn[i]);
            }
            _csn = sb.ToString().ToUpper();

            //foreach(byte b in newSnr)
            //    CSN += Convert.ToString(b, 16).ToUpper();

            //CSN = (Convert.ToString(baCSN[0], 16) + Convert.ToString(baCSN[1], 16) + Convert.ToString(baCSN[2], 16) + Convert.ToString(baCSN[3], 16)).ToUpper();

            SetDiplay(_csn);
            return newSnr;
        }

        private void SetDiplay(string message)
        {
            LGM4200.CAS_Display(_handle, 1, 1, 1, message, message.Length);
        }
        public CardInfo ReadInfo()
        {
            return FindCard();
        }

        private Lgm4200CardInfo FindCard()
        {
            var sci = new Lgm4200CardInfo {ID = ActiveIdle()};

            //número de serie
            sci.IDLen = (byte)sci.ID.Length;
            //sci.IDLen = (byte)(CSN.Length / 2);

            return sci;
        }

        /// <summary>
        /// Lee los datos de al tarjeta
        /// </summary>
        /// <param name="info">Información de la tarjeta que se desea leer</param>
        /// <param name="sector">Sector de la tarjeta que se desea leer</param>
        /// <param name="key">clave de acceso de la tarjeta en formato de array de bytes</param>
        /// <returns>todos los datos legibles de al tarjeta</returns>
        public byte[] ReadSector(Lgm4200CardInfo info, byte sector, byte[] key)
        {
            return ReadMifare(sector, key);
        }

        private byte[] ReadMifare(byte sector, byte[] key)
        {
            /* Read the sector */
            byte[] data; 
            byte authBlock;
            short numBlocks;

            if (sector < 32)
            {
                numBlocks = 3;
                authBlock = (byte)(sector * 4);
                data = new byte[48];
            }
            else
            {
                numBlocks = 15;
                authBlock = (byte)(128 + (sector - 32) * 16);
                data = new byte[240];
            }
            
            //ReadBlock
            //Read the contents of one specific block number from the PICC.
            if (sector != 0)
            {
                ActiveIdle();
                LoadKey(key);
                if (MifareAuthenticate(Convert.ToByte(authBlock)))
                {
                    for (var i = 0; i < numBlocks; i++)
                    {
                        var rtn = LGM4200.CAS_MifareReadBlock(_handle, Convert.ToByte(authBlock + i), _baRBuf);

                        //desactivar el lector
                        if (rtn != ERRORS.d_NO_ERROR)
                        {
                            throw new Exception("ERROR: " + ERRORS.returnErrorStr(rtn));
                        }

                        Array.Copy(_baRBuf, 0, data, i * 16, 16);

                        //switch (i)
                        //{
                        //    case 0:
                        //        Array.Copy(baRBuf, 0, data, 0, 16);
                        //        break;
                        //    case 1:
                        //        Array.Copy(baRBuf, 0, data, 16, 16);
                        //        break;
                        //    case 2:
                        //        Array.Copy(baRBuf, 0, data, 32, 16);
                        //        break;
                        //}
                    }
                }
            }
            else//sector 0
            {
                LoadKey(key);
                var b32 = new byte[32];
                if (MifareAuthenticate(Convert.ToByte(sector * 4)))
                {
                    for (var i = 1; i < 3; i++)
                    {
                        var rtn = LGM4200.CAS_MifareReadBlock(_handle, Convert.ToByte(sector * 4 + i), _baRBuf);
                        //desactivar el lector
                        if (rtn != ERRORS.d_NO_ERROR)
                        {
                            throw new Exception("ERROR: " + ERRORS.returnErrorStr(rtn));
                        }

                        switch (i)
                        {
                            case 1:
                                Array.Copy(_baRBuf, 0, b32, 0, 16);
                                break;
                            case 2:
                                Array.Copy(_baRBuf, 0, b32, 16, 16);
                                break;
                        }
                    }
                }

                //Halt the PICC of Type A
                LGM4200.CAS_MifareHaltA(_handle);

                return b32;
            }

            //Halt the PICC of Type A
            LGM4200.CAS_MifareHaltA(_handle);

            return data;
        }

        private bool MifareAuthenticate(byte bloque)
        {
            //Authentication
            //Perfom the CRYPTO1 (Mifare Classic) card authentication with the key
            //which es inside the internal key buffer. whe authentication is successful then RC531 could operate the
            //blocks in the same sector of the authenticated block.
            var resultado = LGM4200.CAS_MifareAuth(_handle, KeyA, bloque, _baCsn);
            if (resultado != ERRORS.d_NO_ERROR)
            {
                throw new Exception("ERROR: " + ERRORS.returnErrorStr(_rtn));
            }
            return true;
        }

        /// <summary>
        /// meter la clave FFFFF en el lector por si no la tiene
        /// </summary>
        private void LoadKey(byte[] keyOriginal)
        {
            var keyBuenFormato = DarFormatoAKey(keyOriginal);

            LGM4200.CAS_MifareLoadKey(_handle, keyBuenFormato);
            
        }

        private byte[] DarFormatoAKey(byte[] keyOriginal)
        {
            var keyBuenFormato = new byte[12];

            var clave = "";//necesito la clave en forma de string para poder transformarla a la forma en que necesita este lecto

            foreach (var tByte in keyOriginal)
            {
                var nible = Convert.ToString(Convert.ToInt16(tByte.ToString()), 16);
                if (nible.Length == 1)
                    nible = "0" + nible;

                clave += nible;
            }

            LGM4200.GP_PackData(clave.ToUpper(), 12, _baSBuf);

            for (var i = 0; i < 12; i++)
            {
                if (i % 2 == 0)
                    keyBuenFormato[i] = (byte)(((_baSBuf[i / 2] & 0xF0) ^ 0xF0) | (_baSBuf[i / 2] >> 4));
                else
                {
                    keyBuenFormato[i] = (byte)((_baSBuf[i / 2] & 0x0F) | ((_baSBuf[i / 2] << 4) ^ 0xF0));
                }
            }
             
            return keyBuenFormato;
        }

        public void WriteSector(Lgm4200CardInfo info, byte sector, byte[] key, byte[] data)
        {
            WriteMifare(sector, key, data);
        }

        public void WriteBlock(Lgm4200CardInfo info, byte sector, byte block, byte[] key, byte[] data)
        {
            WriteMifare(sector, block, key, data);
        }

        private void WriteMifare(byte sector, byte[] key, byte[] data)
        {
            uint rc;
            if (data == null) return;

            LoadKey(key);

            if (sector != 0)
            {
                /* write the sector */
                if (data.Length != 48 && data.Length != 240)
                {
                    throw new Exception("Longitud de datos menor de 48");
                }

                short numBlocks;
                byte authBlock;
                if (sector < 32)
                {
                    numBlocks = 3;
                    authBlock = (byte)(sector * 4);
                }
                else
                {
                    numBlocks = 15;
                    authBlock = (byte)(128 + (sector - 32) * 16);
                }
                
                for (var i = 0; i < numBlocks; i++)
                {
                    var data16 = new byte[16];
                    MifareAuthenticate((byte)(authBlock + i));

                    Array.Copy(data, i * 16, data16, 0, 16);
                    rc = LGM4200.CAS_MifareWriteBlock(_handle, (byte)(authBlock + i), data16);

                    if (rc != ERRORS.d_NO_ERROR)
                    {
                        throw new Exception("ERROR: " + ERRORS.returnErrorStr(_rtn));
                    }
                }
            }
            else //se parte en dos y se escribe el bloque 1 y 2, ya que el 0 es el numero de serie y el 3 está protegido
            {

                if (data.Length < 32)
                {
                    throw new Exception("Longitud de datos menor de 32");
                }
                var data1 = new byte[16];
                var data2 = new byte[16];

                Array.Copy(data, 0, data1, 0, 16);
                Array.Copy(data, 16, data2, 0, 16);

                MifareAuthenticate(1);
                //y ahora escribo los sectores
                rc = LGM4200.CAS_MifareWriteBlock(_handle, 1, data1);

                if (rc == ERRORS.d_NO_ERROR) //escirbo el segunod
                {
                    MifareAuthenticate(2);
                    rc = LGM4200.CAS_MifareWriteBlock(_handle, 2, data2);
                    if (rc != ERRORS.d_NO_ERROR)
                    {
                        throw new Exception("ERROR: " + ERRORS.returnErrorStr(_rtn));
                    }
                }
                else
                {
                    throw new Exception("ERROR: " + ERRORS.returnErrorStr(_rtn));
                }
            }
        }

        private void WriteMifare(byte sector, byte block, byte[] key, byte[] data)
        {
            //Halt the PICC of Type A
            //LGM4200.CAS_MifareHaltA(handle);
            byte authBlock;

            if (data.Length != 16 && data.Length != 240)
            {
                throw new Exception("Longitud distinta de 16");
            }
            //ActiveIdle();
            LoadKey(key);

            if (sector < 32)
            {
                authBlock = (byte)(sector * 4);
            }
            else
            {
                authBlock = (byte)(128 + (sector - 32) * 16);
            }

            var bloque = (byte)(authBlock + block);
            MifareAuthenticate(bloque);

            var rc = LGM4200.CAS_MifareWriteBlock(_handle, bloque, data);

            //y ahora hago las comprobaciones de escritura
            if (rc != ERRORS.d_NO_ERROR)
            {
                throw new Exception("ERROR: " + ERRORS.returnErrorStr(_rtn));
            }
        }

        public byte[] ReadSectorComplete(Lgm4200CardInfo info, byte sector, byte[] key)
        {
            return ReadMifareComplete(sector, key);
        }

        private byte[] ReadMifareComplete(byte sector, byte[] key)
        {
            /* Read the sector */
            byte[] data; 
            byte authBlock;
            short numBlocks;

            if (sector < 32)
            {
                numBlocks = 4;
                authBlock = (byte)(sector * 4);
                data = new byte[64];
            }
            else
            {
                numBlocks = 16;
                authBlock = (byte)(128 + (sector - 32) * 16);
                data = new byte[256];
            }

            LoadKey(key);
            if (!MifareAuthenticate(Convert.ToByte(authBlock))) return data;
            for (var i = 0; i < numBlocks; i++)
            {
                var rtn = LGM4200.CAS_MifareReadBlock(_handle, Convert.ToByte(authBlock + i), _baRBuf);

                //desactivar el lector
                if (rtn != ERRORS.d_NO_ERROR)
                {
                    throw new Exception("ERROR: " + ERRORS.returnErrorStr(rtn));
                }

                Array.Copy(_baRBuf, 0, data, i * 16, 16);
            }

            return data;
        }
    }
}

using CardFormat3.Controls;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CardLibrary;
using CardLibrary.Cards;
using CardLibrary.Readers;

namespace CardFormat3
{
    public partial class FrmTest : MetroForm
    {

        #region fields
        Evolis codificacionEvolis = null;
        private byte[] m1kSN = new byte[6];
        private byte[] defaultKey = new byte[6];
        private byte[] firstBytes = new byte[6];
        private byte[] centralBytes = new byte[4];
        private byte[] lastBytes = new byte[6];
        private const string FILE_NAME = "errors.txt";
        byte[] uid;

        private readonly Lgm4200CardReader _cardReader = new Lgm4200CardReader();
        private CardInfo _sci;
        private CardMode _cardMode = CardMode.User;
        #endregion

        public byte[] ReadPassword
        {
            get
            {
                //aqui vamos a transformar el password en byte
                var b = new byte[6];
                var s = mhbKeyA.Text.Replace(" ", string.Empty);
                if (s.Length != 12)
                {
                    throw new Exception("Longitud de password errónea");
                }

                //hacemos el recorrido del array de texto de dos en dos caracteres para formar los bytes
                for (var i = 0; i < s.Length; i += 2)
                {
                    b[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
                }
                return b;
            }
        }

        #region constructor
        public FrmTest()
        {
            InitializeComponent();
        }
        #endregion

        #region events

        private enum CardMode { User, Master, AntiPassBack, AntiPassBackFree, Default, Emergency, EmergencyLocal }
        private void FrmTest_Load(object sender, System.EventArgs e)
        {
            loadPrinters();
            sector0.disableBlock(0);
        }

        private void cmbPrinters_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbPrinters.Text.ToLower().Contains("evolis"))
            {
                cmbEncoder.SelectedIndex = 1;
            }
            else if (cmbPrinters.Text.Contains("Hiti"))
            {
                cmbEncoder.SelectedIndex = 0;
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            encodeCards();
        }
        private void encodeCards()
        {
            short rc = 0;
            UInt16 card_proto = 0;
            int want_protos = 0xFFFF;

            if (verificarDatos() == true)
            {
                bool commandSend = false;
                IntPtr printer_p = IntPtr.Zero;

                if (cmbEncoder.Text.ToLower() == "evolis")
                {
                    codificacionEvolis = new Evolis();
                    codificacionEvolis.printerName = cmbPrinters.Text;

                    rc = Evolis.ReaderOpen("");
                    Evolis.ControlRF(1);

                    printer_p = codificacionEvolis.OpenEvoPrinter();
                }

                if (rdbKeyA.Checked)
                    defaultKey = transformTextToBytes(mhbKeyA.Text);
                else if (rdbKeyB.Checked)
                    defaultKey = transformTextToBytes(mhbKeyB.Text);

                for (int j = 0; j < Convert.ToInt32(txtQuantity.Text); j++)
                {
                    bool status = true;
                    try
                    {
                        if (cmbEncoder.Text.ToLower() == "evolis")
                        {
                            if (printer_p != null && printer_p.ToInt32() != 0)
                            {
                                commandSend = codificacionEvolis.DoAction("\x1bSic\x0d", 40000, ref status);
                                System.Threading.Thread.Sleep(1000);
                                //commandSend = codificacionEvolis.DoAction("\x1bSic\x0d", 3000, ref status);
                                //codificacionEvolis.CloseEvoPrinter();
                                uid = new byte[4];
                                byte uidlen;
                                uidlen = 4;

                                rc = Evolis.Find(System.Convert.ToUInt16(want_protos), ref card_proto, uid, ref uidlen);
                                System.Threading.Thread.Sleep(1500);
                                if (rc == Evolis.MI_OK)
                                {
                                    m1kSN = uid;
                                    commandSend = true;
                                }
                                else
                                {
                                    commandSend = false;
                                    do
                                    {
                                        commandSend = codificacionEvolis.DoAction("\x1bSic\x0d", 40000, ref status);
                                        System.Threading.Thread.Sleep(1000);

                                        rc = Evolis.Find(System.Convert.ToUInt16(want_protos), ref card_proto, uid, ref uidlen);
                                        System.Threading.Thread.Sleep(1500);

                                        if (rc == Evolis.MI_OK)
                                        {
                                            m1kSN = uid;
                                            commandSend = true;
                                        }
                                        else
                                        {
                                            commandSend = false;
                                        }
                                    }
                                    while (rc != Evolis.MI_OK && MessageBox.Show("Fallo al buscar la Tarjeta.", "Atención", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry);
                                }
                            }
                        }

                        System.Threading.Thread.Sleep(500);
                        if (commandSend == true)
                        {
                            encodeSectors(rc);
                        }
                        if (cmbEncoder.Text.ToLower() == "evolis")
                        {
                            codificacionEvolis.expulsarTarjeta(cmbPrinters.Text);
                        }
                        System.Threading.Thread.Sleep(1500);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (cmbEncoder.Text.ToLower() == "evolis")
                {
                    codificacionEvolis.expulsarTarjeta(cmbPrinters.Text);
                    codificacionEvolis.CloseEvoPrinter();
                }
                GC.Collect();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region methods
        private void loadPrinters()
        {
            //PrintDocument prtdoc = new PrintDocument();
            //string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbPrinters.Items.Add(strPrinter);
            }
        }

        private byte[] transformTextToBytes(String pass)
        {
            string s = pass.Replace(" ", string.Empty);
            if (s.Length != 12)
            {
                return null;
            }
            else
            {
                byte[] b = new byte[6];
                for (int i = 0; i < s.Length; i += 2)
                {
                    b[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
                }

                return b;

            }
        }

        private byte[] transformTextAccessToBytes(String pass)
        {
            string s = pass.Replace(" ", string.Empty);
            if (s.Length != 8)
            {
                return null;
            }
            else
            {
                byte[] b = new byte[4];
                for (int i = 0; i < s.Length; i += 2)
                {
                    b[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
                }

                return b;
            }
        }

        private bool verificarDatos()
        {
            bool valor = true, result = false;
            String message = "";
            short cant = 0;

            if (String.IsNullOrEmpty(cmbPrinters.Text))
            {
                message += "- Debe seleccionar una impresora" + Environment.NewLine;
                valor = false;
            }

            if (String.IsNullOrEmpty(cmbEncoder.Text))
            {
                message += "- Debe seleccionar un codificador" + Environment.NewLine;
                valor = false;
            }

            result = Int16.TryParse(txtQuantity.Text, out cant);
            if (!result || cant == 0)
            {
                message += "- Debe ingresar una cantidad válida" + Environment.NewLine;
                valor = false;
            }


            if (valor == false)
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return valor;
        }


        private void encodeSectors(short rc)
        {
            try
            {
                int nSector = 0;
                foreach (TabPageAdv page in tabSectors.TabPages)
                {
                    foreach (Controls.Sector sector in page.Controls.OfType<Controls.Sector>())
                    {
                        for (int nBlock = 0; nBlock < 4; nBlock++)
                        {
                            CardFormat3.Controls.Block block = sector.getBlock(nBlock);

                            if (block.isDirty())
                            {
                                firstBytes = transformTextToBytes(block.MhbFirstBytes.Text);
                                centralBytes = transformTextAccessToBytes(block.MhbCentralBytes.Text);
                                lastBytes = transformTextToBytes(block.MhbLastBytes.Text);

                                // byte keyAB = 0x00;
                                byte[] data = new byte[16];
                                //int result;

                                if (cmbEncoder.Text.ToLower() == "evolis")
                                {
                                    rc = Evolis.MifStReadBlock(m1kSN, (byte)((nSector * 4) + nBlock), data, defaultKey);
                                    System.Threading.Thread.Sleep(250);

                                    if (rc == Evolis.MI_OK)
                                    {
                                        Array.Copy(firstBytes, 0, data, 0, 6);
                                        Array.Copy(centralBytes, 0, data, 6, 4);
                                        Array.Copy(lastBytes, 0, data, 10, 6);

                                        rc = Evolis.MifStWriteBlock(m1kSN, (byte)((nSector * 4) + nBlock), data, defaultKey);
                                        System.Threading.Thread.Sleep(200);
                                        if (rc != Evolis.MI_OK)
                                        {
                                            do
                                            {
                                                rc = Evolis.MifStWriteBlock(m1kSN, (byte)((nSector * 4) + nBlock), data, defaultKey);

                                            }
                                            while (rc != Evolis.MI_OK && MessageBox.Show("Fallo al escribir la Tarjeta, ¿Reintentar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes);
                                        }
                                    }
                                    else
                                    {
                                        if (!checkBoxSkipErrors.Checked)
                                            MessageBox.Show("Fallo al leer la Tarjeta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        StreamWriter sw;
                                        if (File.Exists(FILE_NAME))
                                        {
                                            sw = File.AppendText(FILE_NAME);
                                        }
                                        else
                                        {
                                            sw = File.CreateText(FILE_NAME);
                                        }
                                        sw.WriteLine("Error: " + rc.ToString() + " " + System.Text.Encoding.Default.GetString(uid));
                                        sw.Flush();
                                        sw.Close();
                                    }
                                }
                            }

                        }
                        nSector++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                int nSector = 0;
                int nBlock = 0;
                string line;
                if (dlgOpenFile.ShowDialog() == DialogResult.OK)
                {
                    // Read the file and display it line by line.
                    using (StreamReader file = new StreamReader(@dlgOpenFile.FileName))
                    {
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Trim() != String.Empty)
                            {
                                if (nSector > 0 || (nSector == 0 && nBlock > 0))
                                {
                                    Sector sector = this.Controls.Find("sector" + nSector, true).FirstOrDefault() as Sector;

                                    Block block = sector.getBlock(nBlock);
                                    string[] split = line.Split(new Char[] { ';' });
                                    block.MhbFirstBytes.importData(split[0]);
                                    block.MhbCentralBytes.importData(split[1]);
                                    block.MhbLastBytes.importData(split[2]);
                                }

                                nBlock++;
                                if (nBlock > 3)
                                {
                                    if (nSector != 15)
                                    {
                                        nBlock = 0;
                                        nSector++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgSaveFile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter file = new StreamWriter(@dlgSaveFile.FileName))
                    {
                        foreach (TabPageAdv page in tabSectors.TabPages)
                        {
                            foreach (Controls.Sector sector in page.Controls.OfType<Controls.Sector>())
                            {
                                for (int nBlock = 0; nBlock < 4; nBlock++)
                                {
                                    CardFormat3.Controls.Block block = sector.getBlock(nBlock);
                                    file.WriteLine(block.MhbFirstBytes + ";" + block.MhbCentralBytes + ";" + block.MhbLastBytes);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool EncryptCard()
        {
            int nSector = 0;
            foreach (TabPageAdv page in tabSectors.TabPages)
            {
                foreach (Sector sector in page.Controls.OfType<Sector>())
                {
                    for (int nBlock = 0; nBlock < 4; nBlock++)
                    {
                        Block block = sector.getBlock(nBlock);

                        if (block.isDirty())
                        {
                            firstBytes = transformTextToBytes(block.MhbFirstBytes.Text);
                            centralBytes = transformTextAccessToBytes(block.MhbCentralBytes.Text);
                            lastBytes = transformTextToBytes(block.MhbLastBytes.Text);



                            // byte keyAB = 0x00;
                            byte[] data = new byte[16];
                            byte[] keyA = ReadPassword;

                            Array.Copy(firstBytes, 0, data, 0, 6);
                            Array.Copy(centralBytes, 0, data, 6, 4);
                            Array.Copy(lastBytes, 0, data, 10, 6);

                            if (_cardReader.Open())
                            {
                                try
                                {
                                    _sci = _cardReader.ReadInfo();
                                    if(_sci != null)
                                        _cardReader.WriteBlock((Lgm4200CardInfo)_sci, (byte)nSector, (byte)nBlock, keyA, data);
                                    
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(@"Tarjeta no encontrada");
                                    _cardReader.Close();
                                    return false;
                                }
                                _cardReader.Close();
                            }
                        }

                    }
                    nSector++;
                }
            }
            return true;
        }

        private void BtnEncode1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _cardReader.Beep();
            if (EncryptCard())
                MessageBox.Show(@"Tarjeta codificada");
            else
                MessageBox.Show(@"Tarjeta no codificada");

            Cursor = Cursors.Default;  
        }
    }
}

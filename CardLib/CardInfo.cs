using System;

namespace CardLibrary
{
    /// <summary>
    /// Información básica de la tarjeta
    /// </summary>
    public abstract class CardInfo
    {

        #region variables
        /// <summary>
        /// la cadena que contiene el tipo de tarjeta leída
        /// </summary>
        protected string cardType;

        /// <summary>
        /// Nombre del campo identificador de la tarjeta
        /// </summary>
        protected string uiField;

        /// <summary>
        /// Id de la tarjeta
        /// </summary>
        protected byte[] id;

        /// <summary>
        /// Longitud de lcampo id
        /// </summary>
        protected byte idLen;

        #endregion


        #region propiedades
        /// <summary>
        /// Cadena con el tipo de tarjeta que se está usando
        /// </summary>
        public String CardType
        {
            get { return cardType; }
            internal set { cardType = value; }
        }

        /// <summary>
        /// Nombre del campo de identifiación de la tarjeta
        /// </summary>
        public String UIField
        {
            get { return uiField; }
            internal set { uiField = value; }
        }

        /// <summary>
        /// Id de la tarjeta, esta expresado en bytes
        /// </summary>
        public byte[] ID
        {
            get { return id; }
            internal set { id = value; }
        }

        /// <summary>
        /// Longitud de los bytes significativos dle campo id
        /// </summary>
        public byte IDLen
        {
            get { return idLen; }
            internal set { idLen = value; }
        }
        #endregion

        #region métodos que hay que sobrecargar
        /// <summary>
        /// Obtiene el id de la tarjeta en forma de cadena de texto
        /// </summary>
        public abstract string IDString { get; }

        #endregion

        public string getFormattedUSN(string baseFormat, bool reverseMode, int zerosPadding)
        {
            string result = "";
            byte[] usnOrder = new byte[this.IDLen];

            if (this == null)
                return string.Empty;

            // hex /dec format
            switch (baseFormat.ToUpper())
            {
                case "DEC":
                    // get the byte ordered array (decimal format)
                    if (reverseMode == false)
                    {
                        #region Inverting byte order
                        int index = this.IDLen - 1;
                        for (int i = 0; i < this.IDLen; i++)
                        {
                            usnOrder[i] = this.ID[index];
                            index--;
                        }
                        #endregion Inverting byte order
                    }
                    else
                    {
                        for (int i = 0; i < this.IDLen; i++)
                            usnOrder[i] = this.ID[i];
                    }

                    ulong l_result = 0;
                    try
                    {
                        byte[] newBufferDecConversion = new byte[8];
                        Array.Copy(usnOrder, newBufferDecConversion, usnOrder.Length);
                        l_result = BitConverter.ToUInt64(newBufferDecConversion, 0);
                    }
                    catch (Exception) { }
                    result = l_result.ToString();
                    break;
                case "HEX":
                    // get the byte ordered array
                    if (reverseMode == true)
                    {
                        #region Inverting byte order
                        int index = this.IDLen - 1;
                        for (int i = 0; i < this.IDLen; i++)
                        {
                            usnOrder[i] = this.ID[index];
                            index--;
                        }
                        #endregion Inverting byte order
                    }
                    else
                    {
                        for (int i = 0; i < this.IDLen; i++)
                            usnOrder[i] = this.ID[i];
                    }

                    foreach (byte b in usnOrder)
                        result += b.ToString("X2");
                    break;
            }

            // aplying data padding
            string result2 = "";
            if (zerosPadding > result.Length)
                result2 = result.PadLeft(zerosPadding, '0');
            else
                result2 = result;

            return result2;
        }

    }
}

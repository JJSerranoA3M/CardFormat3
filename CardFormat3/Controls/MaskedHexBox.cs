using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CardFormat3
{
    public class MaskedHexBox : MaskedTextBox
    {

        #region Fields
        string originalText = "";
        bool dirty = false;
        #endregion

        #region Events
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //permitir control+c y control+v
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = false;
            }
            //permitir home, inicio, suprimir y tal
            else if (e.KeyCode == Keys.Insert || e.KeyCode == Keys.Home || e.KeyCode == Keys.End || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = false;
            }
            //permitir flechitas de curosr y espacio
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right /*|| e.KeyCode == Keys.Space*/)
            {
                e.SuppressKeyPress = false;
            }
            //ahora, solo permitimso caracteres hexadecimales
            else if (!e.Control && !e.Alt && ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.A && e.KeyCode <= Keys.F)))
            {
                e.SuppressKeyPress = false;
            }
            else
            {
                e.SuppressKeyPress = true;
            }

            base.OnKeyDown(e);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                ////vamos a ver que el texto es válido para corregirlo, esto puede pasar por hacer un copy-paste
                if (value == null)
                {
                    base.Text = null;
                    return;
                }
                string txt = value.ToUpper();
                string newText = string.Empty;

                for (int i = 0; i < txt.Length; i++)
                {
                    if ((txt[i] >= 'A' && txt[i] <= 'F') || txt[i] == ' ' || (txt[i] >= '0' && txt[i] <= '9') || txt[i] == 0x0020)
                    {
                        newText += txt[i];
                    }
                    else
                    {

                        newText += '0';
                    }
                }

                base.Text = newText.ToUpper();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            dirty = true;
            e.KeyChar = char.ToUpperInvariant(e.KeyChar);

            base.OnKeyPress(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.SelectAll();
            this.Focus();
            saveOriginalTtext();
            base.OnGotFocus(e);
        }

        protected override void OnClick(EventArgs e)
        {
            this.SelectAll();
            saveOriginalTtext();
            base.OnClick(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (dirty)
            {
                formatData();
            }
            base.OnLeave(e);
        }
        #endregion

        #region properties
        public bool Dirty
        {
            get { return dirty; }
            set { dirty = value; }
        }
        #endregion

        #region Methods
        private void saveOriginalTtext()
        {
            if (!dirty)
            {
                originalText = base.Text;
            }
        }

        private void formatData()
        {
            string strPad = "00 00 00 00 00 00";
            string strTemp = base.Text.Trim();

            StringBuilder aStringBuilder = new StringBuilder(strPad);
            aStringBuilder.Remove(0, strTemp.Length);
            aStringBuilder.Insert(0, strTemp);
            base.Text = aStringBuilder.ToString();

            if (base.Text != originalText)
            {
                base.ForeColor = Color.Red;
            }
            else
            {
                base.ForeColor = Color.Black;
                dirty = false;
            }
        }

        public void importData(string data)
        {
            saveOriginalTtext();
            base.Text = data.Trim();
            this.Dirty = true;
            formatData();
        }
        #endregion

    }
}

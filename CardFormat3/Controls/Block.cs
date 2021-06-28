using System.Windows.Forms;

namespace CardFormat3.Controls
{
    public partial class Block : UserControl
    {
        #region constructor
        public Block()
        {
            InitializeComponent();
        }
        #endregion

        #region properties
        public MaskedHexBox MhbFirstBytes
        {
            get { return this.mhbFirstBytes; }
            set { this.mhbFirstBytes = value; }
        }

        public MaskedHexBox MhbCentralBytes
        {
            get { return mhbCentralBytes; }
            set { mhbCentralBytes = value; }
        }


        public MaskedHexBox MhbLastBytes
        {
            get { return mhbLastBytes; }
            set { mhbLastBytes = value; }
        }
        #endregion

        #region methods
        public bool isDirty()
        {
            return (mhbFirstBytes.Dirty || mhbCentralBytes.Dirty || mhbLastBytes.Dirty) ? true : false;
        }
        #endregion;
    }
}

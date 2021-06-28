using System.Linq;
using System.Windows.Forms;

namespace CardFormat3.Controls
{
    public partial class Sector : UserControl
    {
        #region constructor
        public Sector()
        {
            InitializeComponent();
        }
        #endregion

        #region methods
        public void disableBlock(int block)
        {
            getBlock(block).Enabled = false;

        }

        public Block getBlock(int block)
        {
            return this.Controls.Find("block" + block, true).FirstOrDefault() as Block;
        }
        #endregion
    }
}

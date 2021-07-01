using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardFormat3.Controls
{
    public partial class sector4k : UserControl
    {
        public sector4k()
        {
            InitializeComponent();
        }

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

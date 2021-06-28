namespace CardFormat3.Controls
{
    partial class Block
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mhbLastBytes = new MaskedHexBox();
            this.mhbCentralBytes = new MaskedHexBox();
            this.mhbFirstBytes = new MaskedHexBox();
            this.SuspendLayout();
            // 
            // mhbLastBytes
            // 
            this.mhbLastBytes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mhbLastBytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mhbLastBytes.Location = new System.Drawing.Point(216, 2);
            this.mhbLastBytes.Mask = "AA AA AA AA AA AA";
            this.mhbLastBytes.Name = "mhbLastBytes";
            this.mhbLastBytes.Size = new System.Drawing.Size(125, 13);
            this.mhbLastBytes.TabIndex = 2;
            this.mhbLastBytes.Text = "000000000000";
            this.mhbLastBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mhbCentralBytes
            // 
            this.mhbCentralBytes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mhbCentralBytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mhbCentralBytes.Location = new System.Drawing.Point(129, 2);
            this.mhbCentralBytes.Mask = "AA AA AA AA";
            this.mhbCentralBytes.Name = "mhbCentralBytes";
            this.mhbCentralBytes.Size = new System.Drawing.Size(85, 13);
            this.mhbCentralBytes.TabIndex = 1;
            this.mhbCentralBytes.Text = "00000000";
            this.mhbCentralBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mhbFirstBytes
            // 
            this.mhbFirstBytes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mhbFirstBytes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mhbFirstBytes.Location = new System.Drawing.Point(2, 2);
            this.mhbFirstBytes.Mask = "AA AA AA AA AA AA";
            this.mhbFirstBytes.Name = "mhbFirstBytes";
            this.mhbFirstBytes.Size = new System.Drawing.Size(125, 13);
            this.mhbFirstBytes.TabIndex = 0;
            this.mhbFirstBytes.Text = "000000000000";
            this.mhbFirstBytes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Block
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.mhbLastBytes);
            this.Controls.Add(this.mhbCentralBytes);
            this.Controls.Add(this.mhbFirstBytes);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Block";
            this.Size = new System.Drawing.Size(343, 17);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedHexBox mhbFirstBytes;
        private MaskedHexBox mhbCentralBytes;
        private MaskedHexBox mhbLastBytes;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelToTab
{
    public partial class PopupOk : Form
    {
        public PopupOk()
        {
            InitializeComponent();
        }

        private void Button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Setting Popup info's text
        /// </summary>
        /// <param name="infoText">Info</param>
        public void SetInfoText(string infoText)
        {
            label_info.Text = infoText;
        }
    }
}

﻿using System.Windows.Forms;

namespace DigaoDeskApp
{
    public partial class FrmFind : Form
    {
        public FrmFind()
        {
            InitializeComponent();
        }

        private void FrmFind_Load(object sender, System.EventArgs e)
        {
            edText_TextChanged(null, null);
        }

        private void FrmFind_Shown(object sender, System.EventArgs e)
        {
            edText.Select();
        }

        private void edText_TextChanged(object sender, System.EventArgs e)
        {
            btnOK.Enabled = (edText.Text != string.Empty);
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (Vars.FindMemoryObj == null) Vars.FindMemoryObj = new();
            Vars.FindMemoryObj.Text = edText.Text;
            Vars.FindMemoryObj.CaseSensitive = ckCaseSensitive.Checked;
            Vars.FindMemoryObj.WholeWord = ckWholeWord.Checked;

            if (Vars.FrmAppsObj.FindInLog(ckFromCurrentPos.Checked))
            {
                DialogResult = DialogResult.OK;
            } 
            else
            {
                Messages.Error("Text not found!");
                edText.Select();
            }
        }
                
    }
}

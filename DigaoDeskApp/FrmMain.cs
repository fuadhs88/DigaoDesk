﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DigaoDeskApp
{
    public partial class FrmMain : Form
    {

        private int? _lastTrayIndex = null;

        public FrmMain()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.Opacity = 0;

            miVersion.Text = "Version " + Vars.APP_VERSION;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Config.Load();
            ApplicationsStore.LoadApplications();
            UpdateTrayIcon();
        }       

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Vars.AppList.Any(x => x.Running))
            {
                e.Cancel = true;
                Messages.Error("There are applications running right now");
            }
        }

        private void miConfig_Click(object sender, EventArgs e)
        {
            if (Vars.FrmConfigObj == null) Vars.FrmConfigObj = new();
            Vars.FrmConfigObj.Show();
            Vars.FrmConfigObj.Restore();
        }

        private void miApplications_Click(object sender, EventArgs e)
        {
            if (Vars.FrmAppsObj == null) Vars.FrmAppsObj = new();
            Vars.FrmAppsObj.Show();
            Vars.FrmAppsObj.Restore();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateTrayIcon()
        {
            var appsRunning = Vars.AppList.Where(x => x.Running);

            int idx = 0;
            if (appsRunning.Any())
            {
                idx = 1;
                if (appsRunning.Any(x => x.Logs.Any() && x.Logs.Last().Error))
                {
                    idx = 2;
                } 
            }

            if (idx != _lastTrayIndex)
            {
                this.Invoke(new MethodInvoker(() => //using invoke because could be called by thread
                {
                    tray.Icon = Icon.FromHandle((images.Images[idx] as Bitmap).GetHicon());
                    _lastTrayIndex = idx;
                }));                
            }
        }

        private void miDigaoDesk_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Vars.GITHUB_LINK);
        }

        private void miVersion_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Vars.GITHUB_LINK + "/releases");
        }
        
    }
}

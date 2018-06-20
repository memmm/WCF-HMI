using service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace model
{
    public partial class ModeSwapper : Form
    {
        public ModeSwapper()
        {
            InitializeComponent();

            rbEngineering.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbProductive.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbScheduled.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbUnscheduled.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbStandby.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        }

        private string mode;
        public string Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (sender == rbEngineering)
            { Mode = "Engineering"; }
            else if (sender == rbProductive)
            { Mode = "Productive"; }
            else if (sender == rbScheduled)
            { Mode = "Scheduled downtime"; }
            else if (sender == rbUnscheduled)
            { Mode = "Unscheduled downtime"; }
            else if (sender == rbStandby)
            { Mode = "Standby"; }

            HMIService.Notify(Mode);
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Repairs_M_S
{
    public partial class Spares : Form
    {
        Functions Con;
        public Spares()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSpares();
        }
        private void ShowSpares()
        {
            string Query = "select * From SpareTb1";
            PartList.DataSource = Con.GetData(Query);
        }
        private void Clear()
        {
            PartNameTb.Text = "";
            PartCostTb.Text = "";
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
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
            if (PartNameTb.Text == "" || PartCostTb.Text == "" )
            {
                MessageBox.Show("Messing Data !!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    
                    string Query = "insert into SpareTb1 values('{0}',{1})";
                    Query = string.Format(Query, PName, Cost);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Added!!!");
                    ShowSpares();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}

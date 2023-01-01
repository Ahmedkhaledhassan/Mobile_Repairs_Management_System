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
        int key = 0;
        private void PartList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartNameTb.Text = PartList.SelectedRows[0].Cells[1].Value.ToString();
            PartCostTb.Text = PartList.SelectedRows[0].Cells[2].Value.ToString();
           
            if (PartNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PartList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Messing Data !!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);

                    string Query = "Update SpareTb1 set SpName = '{0}',SpCost = {1} where SpCode = {2}";
                    Query = string.Format(Query, PName, Cost, key);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Ubdated!!!");
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

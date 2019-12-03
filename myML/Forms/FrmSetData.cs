using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myML.Forms
{
    public partial class FrmSetData : Form
    {
        public FrmSetData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Number of Features;
        /// </summary>
        public int Features { get; set; }

        /// <summary>
        /// Number of Model
        /// </summary>
        public int Models { get; set; }

        /// <summary>
        /// Data Class
        /// </summary>
        private ML.Data Data { get; set; }

        /// <summary>
        /// Show Dialog with ML.Data class
        /// </summary>
        /// <param name="data"> ML.Data class </param>
        /// <returns> Boolean </returns>
        public bool ShowDialog(ref ML.Data data)
        {
            if(data == null)
            {
                this.Data = new ML.Data();
            }
            else
            {
                this.Data = data;
            }

            if(this.ShowDialog() == DialogResult.OK)
            {
                data = this.Data;
                return true;
            }
            else
            {
                data = null;
                return false;
            }
        }

        /// <summary>
        /// Create Sample Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateSample_Click(object sender, EventArgs e)
        {
            int models;
            if (!int.TryParse(txtModels.Text, out models))
            {
                MessageBox.Show("Invalid value in #Models text box.");
                return;
            }

            this.Data = new ML.Data();
            this.Data.MakeSampleData(models, ML.SampleType.HousingPrice);

            DataTable dt = this.Data.GetData();

            this.gridViewData.DataSource = dt;
        }

        /// <summary>
        /// Save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Save data? (yes or no)", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Do Nothing.
        }

        /// <summary>
        /// Create Table button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            int features;
            if (!int.TryParse(txtFeatures.Text, out features))
            {
                MessageBox.Show("Invalid value in #Features text box.");
                return;
            }

            int models;
            if (!int.TryParse(txtModels.Text, out models))
            {
                MessageBox.Show("Invalid value in #Models text box.");
                return;
            }

            this.Features = features;
            this.Models = models;

            // Create Table.
            DataTable dt = new DataTable();
            for (int i = 0; i < this.Features; i++)
            {
                dt.Columns.Add(string.Format("x{0}", i.ToString()), typeof(double));
            }

            for (int i = 0; i < this.Models; i++)
            {
                dt.Rows.Add();
            }

            this.gridViewData.DataSource = dt;
        }
    }
}

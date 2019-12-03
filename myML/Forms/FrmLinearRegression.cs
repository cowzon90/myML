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
    public partial class FrmLinearRegression : Form
    {
        public FrmLinearRegression()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Data Class
        /// </summary>
        public ML.Data Data { get; set; }

        /// <summary>
        /// Set Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetData_Click(object sender, EventArgs e)
        {
            FrmSetData frm = new FrmSetData();

            ML.Data data = this.Data;
            if (frm.ShowDialog(ref data))
            {
                this.Data = data;
            }
        }

        /// <summary>
        /// Gradient Descent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGradientDescent_Click(object sender, EventArgs e)
        {
            double learningRate;
            if (!double.TryParse(txtLearningRate.Text, out learningRate))
            {
                MessageBox.Show("Invalid value in learning rate.");
                return;
            }

            int iteration;
            if(!int.TryParse(txtIteration.Text, out iteration))
            {
                MessageBox.Show("Invalid value in iteration.");
                return;
            }

            // Run.
            ML.LinearRegression LR = new ML.LinearRegression();

            LR.NumberOfFeatures = this.Data.NumberOfFeatures;
            LR.Thetas = LR.InitializeTheta();

            LR.RunGradientDescent(iteration, learningRate, this.Data.X, this.Data.Y);


        }

        /// <summary>
        /// Normal Equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNormalEquation_Click(object sender, EventArgs e)
        {
            ML.LinearRegression LR = new ML.LinearRegression();
            LR.NormalEquation(this.Data.X, this.Data.Y);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {

        }
    }
}

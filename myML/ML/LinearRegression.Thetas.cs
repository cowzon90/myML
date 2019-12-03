using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myML.ML
{
    /// <summary>
    /// class for Linear Regression
    /// </summary>
    partial class LinearRegression
    {

        #region Theta
        // Theta
        // Theta = [Theta0, Theta1, Theta2, Theta3, ... , ThetaN]
        // N is feature;

        /// <summary>
        /// Initialize theta with feature + 1;
        /// </summary>
        /// <param name="features"> number of features </param>
        /// <param name="initialThetas">initial values </param>
        /// <returns> theta list </returns>
        public Vector<double> InitializeTheta(int features, double[] initialThetas)
        {
            if(features + 1 != initialThetas.Length)
            {
                throw new Exception("Length of initial theta as params is not matched with number of feature.");
            }

            Vector<double> theta = Vector<double>.Build.Dense(initialThetas);

            return theta;
        }

        /// <summary>
        /// Initialize theta with random data
        /// </summary>
        /// <returns> theta list </returns>
        public Vector<double> InitializeTheta()
        {
            Vector<double> theta = Vector<double>.Build.Dense(this.NumberOfFeatures + 1); 
            Random random = new Random();

            for (int i = 0; i < theta.Count; i++)
            {
                theta[i] = random.NextDouble();
            }

            return theta;
        }
        #endregion

        #region Function
        /// <summary>
        /// J(theta) = theta0 * 1 + theta1 * x1 + theta2 * x2 + ... + thetan * xn
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double Function(Vector<double> data)
        {
            if(data.At(0) != 1.0)
            {
                throw new Exception("0 index of data must be 1.0");
            }

            try
            {
                double value = this.Thetas.DotProduct(data);

                return value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Cost Function
        /// <summary>
        /// Cost Function
        /// <para>
        /// J(Theta) = 1/2m * sigma (i = 1 to data size) ( h_theta(xi) - yi ) ^ 2
        /// </para>
        /// </summary>
        /// <returns></returns>
        public double CostFunction(Matrix<double> data, Vector<double> y)
        {
            int modelSize = data.RowCount;

            double sum = 0.0;

            for(int i = 0; i < modelSize; i++)
            {
                Vector<double> xi = data.Row(i);

                sum += Math.Pow(this.Function(xi) - y.At(i), 2.0);
            }

            sum /= (2 * modelSize);

            return sum;
        }

        #endregion

        #region Gradient Descent

        /// <summary>
        /// Gradient Descent with theta index
        /// </summary>
        /// <param name="thetaIndex"> theta_index </param>
        /// <returns> value of theta_index </returns>
        public double GradientDescent(double learningRate, int thetaIndex, Matrix<double> data, Vector<double> y)
        {
            int modelSize = data.RowCount;

            double theta = this.Thetas[thetaIndex];

            for(int i = 0; i < modelSize; i++)
            {
                Vector<double> xi = data.Row(i);
                theta += ((this.Function(xi) - y.At(i)) * xi.At(thetaIndex));
            }

            theta -= (learningRate / modelSize);
            
            return theta;
        }

        #endregion

        public void RunGradientDescent(int iteration, double learningRate, Matrix<double> data, Vector<double> y)
        {
            Console.WriteLine("Start");

            for (int i = 0; i < iteration; i++)
            {
                for(int thetaIndex = 0; thetaIndex < this.Thetas.Count; thetaIndex++)
                {
                    double previousTheta = this.Thetas[thetaIndex];
                    double currentTheta = this.GradientDescent(learningRate, thetaIndex, data, y);

                    this.Thetas[thetaIndex] = currentTheta;
                    Console.WriteLine(string.Format("Theta {0} changed : {1} -> {2}", thetaIndex, previousTheta, currentTheta));
                }

                Console.WriteLine(this.Equation());
            }

            Console.WriteLine("Done");
        }

        private string Equation()
        {
            string equation = string.Empty;

            equation += this.Thetas[0].ToString();

            for(int i = 1; i < this.Thetas.Count; i++)
            {
                equation += string.Format(" + {0} * x{1}", this.Thetas[i], i);
            }

            return equation;
        }

        public void NormalEquation(Matrix<double> data, Vector<double> y)
        {
            Matrix<double> transpose_x = data.Transpose();

            Matrix<double> xTx = transpose_x.Multiply(data);

            Matrix<double> inverse_xTx = xTx.PseudoInverse();

            Matrix<double> multiply = inverse_xTx.Multiply(transpose_x);

            Vector<double> theta = multiply.Multiply(y);

            this.Thetas = theta;

            Console.WriteLine(this.Equation());
        }

        #region Scaling
        
        public void FeatureScaling()
        {
            //
        }

        /// <summary>
        /// Get Average of data set about x_index
        /// </summary>
        /// <param name="index"> index of feature x </param>
        /// <returns> average of x_index </returns>
        public double GetAverage(int index)
        {
            double sum = 0.0;

            //for(int i = 0; i < this.DataSet.DataSize; i++)
            //{
            //    sum += this.DataSet.Datas[i].X[index];
            //}

            //double average = sum / this.DataSet.DataSize;

            return double.NaN;
        }
        
        #endregion
    }
}

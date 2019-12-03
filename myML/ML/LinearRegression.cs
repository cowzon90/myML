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
    public partial class LinearRegression
    {
        /// <summary>
        /// number of features
        /// </summary>
        public int NumberOfFeatures { get; set; }

        /// <summary>
        /// Theta List -> theta0, theta1, theta2, theta3 ...
        /// </summary>
        public Vector<double> Thetas { get; set; }

        /// <summary>
        /// Learning Rate alpha
        /// </summary>
        public double LearningRate { get; set; }

        /// <summary>
        /// Iteration for runing
        /// </summary>
        public int Iteration { get; set; }

    }
}

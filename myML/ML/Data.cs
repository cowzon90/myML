using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;

namespace myML.ML
{
    /// <summary>
    /// Sample Type
    /// </summary>
    public enum SampleType
    {
        None,
        HousingPrice
    }

    /// <summary>
    /// Data class for ML
    /// </summary>
    public class Data
    {
        /// <summary>
        /// m * (n+1) Matrix for feature value.
        /// </summary>
        public Matrix<double> X { get; set; }

        /// <summary>
        /// m dimension vector for y values.
        /// </summary>
        public Vector<double> Y { get; set; }

        /// <summary>
        /// number of features
        /// </summary>
        public int NumberOfFeatures { get; set; }

        /// <summary>
        /// number of models
        /// </summary>
        public int NumberOfModels { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Data()
        {

        }

        /// <summary>
        /// Constructor with params.
        /// </summary>
        /// <param name="index"> index of data </param>
        /// <param name="y"> y value </param>
        /// <param name="n"> number of x </param>
        /// <param name="x"> values of x </param>
        public Data(int features, int models)
        {
            this.NumberOfFeatures = features;
            this.NumberOfModels = models;

            this.X = Matrix<double>.Build.Dense(this.NumberOfModels, this.NumberOfFeatures + 1);
            this.Y = Vector<double>.Build.Dense(this.NumberOfModels);
        }

        /// <summary>
        /// Set X and Y matrix with data table
        /// </summary>
        /// <param name="dt"> data table </param>
        public void SetData(DataTable dt)
        {
            this.NumberOfFeatures = dt.Columns.Count - 1;
            this.NumberOfModels = dt.Rows.Count;

            this.X = Matrix<double>.Build.Dense(this.NumberOfModels, this.NumberOfFeatures + 1);
            this.Y = Vector<double>.Build.Dense(this.NumberOfModels);

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double[] x = new double[this.NumberOfFeatures + 1];
                    x[0] = 1.0;

                    // x
                    for (int j = 0; j < this.NumberOfFeatures; j++)
                    {
                        x[j + 1] = Convert.ToDouble(dt.Rows[i][j]);
                    }

                    Vector<double> x_vector = Vector<double>.Build.Dense(x);

                    // Add x_vector to X matrix on selected row
                    this.X.SetRow(i, x_vector);

                    // y
                    double y = Convert.ToDouble(dt.Rows[i][dt.Columns.Count - 1]);
                    this.Y[i] = y;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        /// <summary>
        /// X and Y matrix to data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            for(int i = 0; i < this.NumberOfFeatures; i++)
            {
                dt.Columns.Add(string.Format("x{0}", (i + 1).ToString()), typeof(double));
            }
            dt.Columns.Add("y", typeof(double));

            for(int i = 0; i < this.NumberOfModels; i++)
            {
                // x and y to row
                object[] objs = new object[this.NumberOfFeatures + 1];

                for(int j = 0; j < this.NumberOfFeatures; j++)
                {
                    objs[j] = this.X.At(i, j + 1);
                }
                objs[this.NumberOfFeatures] = this.Y[i];

                dt.Rows.Add(objs);
            }

            return dt;
        }

        /// <summary>
        /// Make Sample
        /// </summary>
        /// <param name="models"></param>
        /// <param name="sampleType"></param>
        public void MakeSampleData(int models, SampleType sampleType)
        {
            switch (sampleType)
            {
                case SampleType.None:
                    return;
                case SampleType.HousingPrice:
                    this.Sample_HousingPrice(models);
                    break;
            }
        }

        /// <summary>
        /// Housing price data sample.
        /// </summary>
        /// <param name="models"></param>
        private void Sample_HousingPrice(int models)
        {
            this.NumberOfFeatures = 3;
            this.NumberOfModels = models;
            this.X = Matrix<double>.Build.Dense(models, 4);

            // x features
            // x0   x1      x2       x3
            //  1  size  #floors  #bedrooms

            Random random = new Random();

            for(int i = 0; i < models; i++)
            {
                double x0 = 1.0;                                    // x0 -> 1
                double x1 = random.Next() % 1000 + 100;             // x1 -> size (100 to 1000)
                double x2 = random.Next() % 4 + 1;                  // x2 -> floors (1 to 5)
                double x3 = random.Next() % 2 + 1;                  // x3 -> bedrooms (1 to 3)

                double[] x = { x0, x1, x2, x3 };
                Vector<double> x_vector = Vector<double>.Build.Dense(x);
                this.X.SetRow(i, x_vector);

                double i0 = this.X.At(i, 0);
                double i1 = this.X.At(i, 1);
            }

            // y feature
            //   price 
            double[] y = new double[models];
            for(int i = 0; i < models; i++)
            {
                y[i] = (random.NextDouble() % 99.0 + 1.0) * 1000.0;
            }
            
            this.Y = Vector<double>.Build.Dense(y);
        }

    }
}

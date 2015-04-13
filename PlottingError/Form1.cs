using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using ArtificialNeuralNetwork;

namespace PlottingError
{
    public partial class Form1 : Form
    {
        ArtificialNeuralNetwork.ArtificialNeuralNetwork ann = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(2, 3, 3, 1);
        ArtificialNeuralNetwork.ArtificialNeuralNetwork ann1 = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(1, 10, 5, 1);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Generate data matrices for training of ANN as XOR gate
            Console.WriteLine("\n Training ANN ...\n");

            Random rand = new Random((int)DateTime.Now.ToBinary());
            const int numberOfInputSequences = 16;
            double[,] inputMatrix = new double[2, numberOfInputSequences], targetMatrix = new double[1, numberOfInputSequences];
            int x1, x2;

            for (int i = 0; i < numberOfInputSequences; i++)
            {
                x1 = rand.Next(0, 2);
                x2 = rand.Next(0, 2);

                inputMatrix[0, i] = x1;
                inputMatrix[1, i] = x2;
                targetMatrix[0, i] = x1 ^ x2;
            }

            double[] errorDev = this.ann.AnnTrainingOnline(inputMatrix, targetMatrix, 4, 10000);

            //  Plot
            this.chart1.Series.Clear();

            Series serie = new Series("Error");
            serie.ChartType = SeriesChartType.Line;
            //serie.Points.Add(errorDev);
            for (int i = 0; i < errorDev.Length; i++)
            {
                serie.Points.Add(new DataPoint(i, errorDev[i]));
            }


            this.chart1.Series.Add(serie);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  Generate data matrices for training of ANN as XOR gate
            Random rand = new Random((int)DateTime.Now.ToBinary());
            const int numberOfInputSequences = 16;
            double[,] inputMatrix = new double[1, numberOfInputSequences], targetMatrix = new double[1, numberOfInputSequences];
            double x1 = -8;

            for (int i = 0; i < numberOfInputSequences; i++, x1++)
            {
                inputMatrix[0, i] = x1;
                targetMatrix[0, i] = Math.Pow(x1, 3);
            }

            double[] errorDev = this.ann1.AnnTrainingOnline(inputMatrix, targetMatrix, 4, 10000);

            //  Plot
            this.chart1.Series.Clear();

            Series serie = new Series("Error");
            serie.ChartType = SeriesChartType.Line;
            //serie.Points.Add(errorDev);
            for (int i = 0; i < errorDev.Length; i++)
            {
                serie.Points.Add(new DataPoint(i, errorDev[i]));
            }

            //  Generate data-points from ANN
            double[] y;
            Series annOutput = new Series("ANN Output"), target = new Series("Target");
            serie.ChartType = SeriesChartType.Line;

            for (double x = -10; x <= 10; x += 0.001)
            {
                y = ann1.FeedForward(new double[] { x });
                annOutput.Points.Add(new DataPoint(x, y));
                target.Points.Add(new DataPoint(x, Math.Pow(x, 3)));
            }

            this.chart1.Series.Add(serie);
            ChartArea cArea = new ChartArea("Function");
            annOutput.ChartArea = "Function";
            annOutput.ChartType = SeriesChartType.Line;
            target.ChartArea = "Function";
            target.ChartType = SeriesChartType.Line;

            this.chart1.ChartAreas.Add(cArea);

            this.chart1.Series.Add(annOutput);
            this.chart1.Series.Add(target);
        }
    }
}

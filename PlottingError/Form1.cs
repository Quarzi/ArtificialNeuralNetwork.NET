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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////  Generate data matrices for training of ANN as XOR gate
            //Console.WriteLine("\n Training ANN ...\n");

            //Random rand = new Random((int)DateTime.Now.ToBinary());
            //const int numberOfInputSequences = 16;
            //double[,] inputMatrix = new double[2, numberOfInputSequences], targetMatrix = new double[1, numberOfInputSequences];
            //int x1, x2;

            //for (int i = 0; i < numberOfInputSequences; i++)
            //{
            //    x1 = rand.Next(0, 2);
            //    x2 = rand.Next(0, 2);

            //    inputMatrix[0, i] = x1;
            //    inputMatrix[1, i] = x2;
            //    targetMatrix[0, i] = x1 ^ x2;
            //}

            //double[] errorDev = this.ann.AnnTrainingOnline(inputMatrix, targetMatrix, 4, 10000);

            ////  Plot
            //this.chart1.Series.Clear();

            //Series serie = new Series("Error");
            //serie.ChartType = SeriesChartType.Line;
            ////serie.Points.Add(errorDev);
            //for (int i = 0; i < errorDev.Length; i++)
            //{
            //    serie.Points.Add(new DataPoint(i, errorDev[i]));
            //}


            //this.chart1.Series.Add(serie);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const double minX = -5, maxX = 5, stepSize = 0.001, trainingStepSize = Math.PI / 5;
            const int numberOfTrainingSteps = (int)((maxX - minX) / trainingStepSize) + 1;
            const int hiddenLayers = 3, neuronsPerHiddenLayer = 5;
            double[,] inputMatrix = new double[1, numberOfTrainingSteps], targetMatrix = new double[1, numberOfTrainingSteps];
            int index = 0;
            double x, y, est;

            ChartArea errorChart = new ChartArea("ErrorChart"), outputChart = new ChartArea("OutputChart");
            Series errorSequence = new Series("Errors"), targetSequence = new Series("Target"), outputSequence = new Series("Output");
            
            errorSequence.ChartArea = errorChart.Name;
            errorSequence.Color = Color.Red;
            errorSequence.ChartType = SeriesChartType.Line;

            targetSequence.ChartArea = outputChart.Name;
            targetSequence.Color = Color.Green;
            targetSequence.ChartType = SeriesChartType.Line;

            outputSequence.ChartArea = outputChart.Name;
            outputSequence.Color = Color.Red;
            outputSequence.ChartType = SeriesChartType.Line;

            //  Generate input and target matrices for training of ANN
            for (x = minX; x < maxX; x += trainingStepSize)
            {
                y = Math.Sin(x); 

                inputMatrix[0, index] = x;
                targetMatrix[0, index] = y;
                index++;
            }

            double scale = targetMatrix.Max() - targetMatrix.Min();
            targetMatrix = targetMatrix.Multiply(1 / scale);

            //  Train ANN
            ArtificialNeuralNetwork.ArtificialNeuralNetwork ann = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(inputMatrix.Rows(), hiddenLayers, neuronsPerHiddenLayer, targetMatrix.Rows());
            double[] errorDev = ann.Trainer.TrainAnn(inputMatrix, targetMatrix);

            //  Add errors to listbox
            this.listBox1.Items.Clear();
            foreach (var item in errorDev)
            {
                this.listBox1.Items.Add(item);
            }

            //  Extract relevant data
            for (int i = 0; i < errorDev.Length; i++)
            {
                errorSequence.Points.Add(new DataPoint(i, errorDev[i]));
            }

            for (x = minX; x <= maxX; x += stepSize)
            {
                //y = 2 * Math.Pow(x, 3) + 2 / scale;
                y = Math.Sin(x);

                double[] yy = ann.FeedForward(new double[] { x }).Multiply(scale);
                outputSequence.Points.Add(new DataPoint(x, yy));
                targetSequence.Points.Add(new DataPoint(x, y));
            }

            //  Plot
            this.chart1.Series.Clear();
            this.chart1.ChartAreas.Clear();

            this.chart1.ChartAreas.Add(errorChart);
            this.chart1.ChartAreas.Add(outputChart);

            this.chart1.Series.Add(errorSequence);
            this.chart1.Series.Add(targetSequence);
            this.chart1.Series.Add(outputSequence);
        }
    }
}

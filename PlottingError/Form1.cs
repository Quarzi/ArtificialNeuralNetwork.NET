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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Generate data matrices for training of ANN as XOR gate
            ChartArea errorChart = new ChartArea("ErrorChart");
            Series errorSequence = new Series("Errors");

            errorChart.AxisX.Title = "Epochs";
            errorChart.AxisY.Title = "Error^2";

            errorSequence.ChartArea = errorChart.Name;
            errorSequence.Color = Color.Blue;
            errorSequence.ChartType = SeriesChartType.Line;

            double[,] inputMatrix = new double[,] { { 0, 0, 1, 1 }, { 0, 1, 0, 1 } }, targetMatrix = new double[,] { { 0, 1, 1, 0 } };
            
            //  Train ANN
            ArtificialNeuralNetwork.ArtificialNeuralNetwork myAnn = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(inputMatrix.Rows(), 1, 2, targetMatrix.Rows());

            myAnn.Trainer.Epochs = 100;
            myAnn.Trainer.LearningRate = 0.01;
            myAnn.Trainer.Epsilon = 0.1;

            double[] errorDev = myAnn.Trainer.TrainAnn(inputMatrix, targetMatrix);

            //  Add errors to listbox
            int i = 0;
            this.listBox1.Items.Clear();
            foreach (var item in errorDev)
            {
                this.listBox1.Items.Add(item);
                errorSequence.Points.Add(new DataPoint(i, item));
                i++;
            }

            double[] yy = myAnn.FeedForward(new double[] { 1,0 });
            
            //  Plot
            this.chart1.ChartAreas.Clear();
            this.chart1.ChartAreas.Add(errorChart);
            
            this.chart1.Series.Clear();
            this.chart1.Series.Add(errorSequence);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const double minX = -2 * Math.PI, maxX = 2 * Math.PI, trainingStepSize = Math.PI / 7000;
            const int numberOfTrainingSteps = (int)((maxX - minX) / trainingStepSize) + 1;
            const int hiddenLayers = 10, neuronsPerHiddenLayer = 10;
            double[,] inputMatrix = new double[1, numberOfTrainingSteps], targetMatrix = new double[1, numberOfTrainingSteps];
            int index = 0;
            double x, y;
            double[] yy;

            ChartArea errorChart = new ChartArea("ErrorChart"), outputChart = new ChartArea("OutputChart");
            Series errorSequence = new Series("Errors"), targetSequence = new Series("Target"), outputSequence = new Series("Output");

            errorChart.AxisX.Title = "Epochs";
            errorChart.AxisY.Title = "Error^2";

            outputChart.AxisX.Title = "x";
            outputChart.AxisY.Title = "sin(x)";

            errorSequence.ChartArea = errorChart.Name;
            errorSequence.Color = Color.Blue;
            errorSequence.ChartType = SeriesChartType.Line;

            targetSequence.ChartArea = outputChart.Name;
            targetSequence.Legend = "Target";
            targetSequence.Color = Color.Green;
            targetSequence.ChartType = SeriesChartType.Line;

            outputSequence.ChartArea = outputChart.Name;
            outputSequence.Legend = "Actual";
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

            //  Train ANN
            ArtificialNeuralNetwork.ArtificialNeuralNetwork myAnn = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(inputMatrix.Rows(), hiddenLayers, neuronsPerHiddenLayer, targetMatrix.Rows());

            myAnn.Trainer.Epochs = 1000;
            myAnn.Trainer.LearningRate = 0.001;
            myAnn.Trainer.Epsilon = 0.0001;

            double[] errorDev = myAnn.Trainer.TrainAnn(inputMatrix, targetMatrix);

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

            for (x = minX; x <= maxX; x += trainingStepSize)
            {
                //y = 2 * Math.Pow(x, 3) + 2 / scale;
                y = Math.Sin(x);

                yy = myAnn.FeedForward(new double[] { x });
                outputSequence.Points.Add(new DataPoint(x, yy));
                targetSequence.Points.Add(new DataPoint(x, y));
            }

            //  Plot
            this.chart1.ChartAreas.Clear();
            this.chart1.ChartAreas.Add(errorChart);
            this.chart1.ChartAreas.Add(outputChart);

            this.chart1.Series.Clear();
            this.chart1.Series.Add(errorSequence);
            this.chart1.Series.Add(targetSequence);
            this.chart1.Series.Add(outputSequence);
        }
    }
}

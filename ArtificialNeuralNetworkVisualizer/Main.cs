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
using ArtificialNeuralNetwork.Extensions;
using ANN = ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkVisualizer
{
    public partial class Main : Form
    {
        private ANN.ArtificialNeuralNetwork ann = null;
        private ANN.TrainingSet trainingSet = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //  Initialize create network section
            this.nrInputs.Text = "2";
            this.nrOutput.Text = "1";
            this.hiddenLayers.Text = "";

            //  Initialize training section
            this.learningMethod.DataSource = Enum.GetValues(typeof(ANN.ArtificialNeuralNetwork.TrainingMethods));
            this.trainingMethod.DataSource = Enum.GetValues(typeof(ANN.Trainer.TrainingSchemes));
            this.costFunction.DataSource = Enum.GetValues(typeof(ANN.Trainer.CostFunctions));

            this.learningRateCombo.Items.Clear();
            this.learningRateCombo.Items.Add(0.01);
            this.learningRateCombo.Items.Add(0.025);
            this.learningRateCombo.Items.Add(0.05);
            this.learningRateCombo.Items.Add(0.1);
            this.learningRateCombo.Items.Add(0.25);
            this.learningRateCombo.Items.Add(0.5);
            this.learningRateCombo.Items.Add(0.7);
            this.learningRateCombo.Items.Add(1.0);

            this.learningRateCombo.SelectedIndex = 2;
            this.epochsValue.Text = "500";
            this.epsilonValue.Text = "0.001";
        }

        private void learningRateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.learningRateValue.Text = this.learningRateCombo.Items[this.learningRateCombo.SelectedIndex].ToString();
        }

        private void trainAnn_Click(object sender, EventArgs e)
        {
            //  Check if training set is loaded
            if (this.trainingSet != null)
            {
                const double minX = -1, maxX = 1, trainingStepSize = Math.PI / 7000;
                const int numberOfTrainingSteps = (int)((maxX - minX) / trainingStepSize) + 1;
                const int hiddenLayers = 15, neuronsPerHiddenLayer = 15;
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

                TrainingSet trainingSet = new TrainingSet();
                trainingSet.InputMatrix = inputMatrix;
                trainingSet.TargetMatrix = targetMatrix;
                //trainingSet.SaveSet("C:/Users/Kent/Desktop/trainingset.bin");

                //  Train ANN
                ArtificialNeuralNetwork.ArtificialNeuralNetwork myAnn = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(inputMatrix.Rows(), hiddenLayers, neuronsPerHiddenLayer, targetMatrix.Rows());

                myAnn.Trainer.Epochs = 50;
                myAnn.Trainer.LearningRate = 0.05;
                myAnn.Trainer.Epsilon = 0.0001;

                double[] errorDev = myAnn.Trainer.TrainAnn(inputMatrix, targetMatrix);

                ////  Add errors to listbox
                //this.listBox1.Items.Clear();
                //foreach (var item in errorDev)
                //{
                //    this.listBox1.Items.Add(item);
                //}

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
            else
            {
                MessageBox.Show("There is no training set loaded. Cannot train network!", "Error");
            }

            
        }

        private void loadDataset_Click(object sender, EventArgs e)
        {
            this.trainingSet = new TrainingSet();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "%home%";
            openFileDialog1.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.trainingSet.LoadSet(openFileDialog1.OpenFile());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}

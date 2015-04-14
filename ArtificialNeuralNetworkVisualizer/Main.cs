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
            this.hiddenLayers.Text = "1";
            this.hiddenNeurons.Text = "2";

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
            if (this.ann != null && this.trainingSet != null && this.trainingSet.InputMatrix.Rows() == this.ann.Layers[0].NumberOfNeurons && this.trainingSet.TargetMatrix.Rows() == this.ann.Layers[this.ann.Layers.Count - 1].NumberOfNeurons)
            {
                this.chart1.Legends.Clear();
                this.chart1.ChartAreas.Clear();
                this.chart1.Series.Clear();

                //  Setup training and start
                this.ann.SetTrainer((ANN.ArtificialNeuralNetwork.TrainingMethods)this.learningMethod.SelectedItem);
                this.ann.Trainer.SetCostFunction((Trainer.CostFunctions)this.costFunction.SelectedItem);
                this.ann.Trainer.SetTrainingScheme((Trainer.TrainingSchemes)this.trainingMethod.SelectedItem);
                this.ann.Trainer.Epochs = Int32.Parse(this.epochsValue.Text);
                this.ann.Trainer.Epsilon = Double.Parse(this.epsilonValue.Text);
                this.ann.Trainer.LearningRate = Double.Parse(this.learningRateValue.Text);
                double[] error = this.ann.Trainer.TrainAnn(this.trainingSet.InputMatrix, this.trainingSet.TargetMatrix);

                //  Setup visualization of data
                Legend legend = new Legend("Legend");
                ChartArea errorChart = new ChartArea("ErrorChart"), outputChart = new ChartArea("OutputChart");
                Series errorSequence = new Series("Errors"), targetSequence = new Series("Target"), outputSequence = new Series("Output");

                errorChart.AxisX.Title = "Epochs";
                errorChart.AxisY.Title = "Cost";

                outputChart.AxisX.Title = "x";
                outputChart.AxisY.Title = "f(x)";

                errorSequence.ChartArea = errorChart.Name;
                errorSequence.Legend = "Legend";
                errorSequence.LegendText = "Cost";
                errorSequence.Color = Color.Blue;
                errorSequence.ChartType = SeriesChartType.Line;

                targetSequence.ChartArea = outputChart.Name;
                targetSequence.Legend = "Legend";
                targetSequence.LegendText = "Target";
                targetSequence.Color = Color.Green;
                targetSequence.ChartType = SeriesChartType.Line;

                outputSequence.ChartArea = outputChart.Name;
                outputSequence.Legend = "Legend";
                outputSequence.LegendText = "Output";
                outputSequence.Color = Color.Red;
                outputSequence.ChartType = SeriesChartType.Line;

                //  Get error over epochs
                for (int i = 0; i < error.Length; i++)
                {
                    errorSequence.Points.Add(new DataPoint(i, error[i]));
                }

                //  Generate actual and target output
                double[] x, y, t;
                for (int i = 0; i < this.trainingSet.InputMatrix.Cols(); i++)
                {
                    x = this.trainingSet.InputMatrix.ExtractColumn(i);
                    t = this.trainingSet.TargetMatrix.ExtractColumn(i);
                    y = this.ann.FeedForward(x);

                    targetSequence.Points.Add(new DataPoint(x[0], t[0]));
                    outputSequence.Points.Add(new DataPoint(x[0], y[0]));
                }

                //  Plot
                this.chart1.Legends.Add(legend);

                this.chart1.ChartAreas.Add(errorChart);
                this.chart1.ChartAreas.Add(outputChart);

                this.chart1.Series.Add(errorSequence);
                this.chart1.Series.Add(targetSequence);
                this.chart1.Series.Add(outputSequence);
            }
            else
            {
                MessageBox.Show("No artificial neural network was created nor the dimensions of it are compatible with the trainingset. Is dataset loaded? Training stopped!", "Error");
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

        private void generateAnn_Click(object sender, EventArgs e)
        {
            int inputs = Int32.Parse(this.nrInputs.Text),
                hiddenLayers = Int32.Parse(this.hiddenLayers.Text),
                neuronsPerHiddenLayer = Int32.Parse(this.hiddenNeurons.Text),
                outputs = Int32.Parse(this.nrOutput.Text);

            this.ann = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(inputs, hiddenLayers, neuronsPerHiddenLayer, outputs);

            this.layersList.DataSource = this.ann.Layers;
        }

        private void layersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Layer selectedLayer = (Layer)this.layersList.SelectedItem;

            this.transferFunction.DataSource = Enum.GetValues(typeof(ANN.Layer.TransferFunctions));
            this.transferFunction.SelectedIndex = (int)selectedLayer.TransferFunction;
        }

        private void transferFunction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Layer selectedLayer = (Layer)this.layersList.SelectedItem;

            selectedLayer.SetTransfer((Layer.TransferFunctions)(this.transferFunction.SelectedItem));
        }
    }
}

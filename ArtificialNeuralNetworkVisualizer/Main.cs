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
using System.Diagnostics;

using ArtificialNeuralNetwork;
using ArtificialNeuralNetwork.Extensions;
using ANN = ArtificialNeuralNetwork;

namespace ArtificialNeuralNetworkVisualizer
{
    public partial class Main : Form
    {
        private Stopwatch stopWatch;

        private ANN.ArtificialNeuralNetwork ann = null;
        private ANN.TrainingSet trainingSet = null;
        private ANN.TrainingSetGenerator generator = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //  Initialize create network section
            this.toolStripTextBox1.Text = "2";
            this.toolStripTextBox2.Text = "1";
            this.toolStripTextBox2.Text = "1";
            this.toolStripTextBox4.Text = "2";

            //  Initialize training section
            this.learningMethod.DataSource = Enum.GetValues(typeof(ANN.ArtificialNeuralNetwork.TrainingMethods));
            this.trainingMethod.DataSource = Enum.GetValues(typeof(ANN.Trainer.TrainingSchemes));
            this.costFunction.DataSource = Enum.GetValues(typeof(ANN.Trainer.CostFunctions));
            this.generatorSignals.ComboBox.DataSource = Enum.GetValues(typeof(ANN.TrainingSetGenerator.Signals));
            /// Bugged
            this.layerTransfer.ComboBox.DataSource = Enum.GetValues(typeof(ANN.Layer.TransferFunctions));
            ///

            this.learningRateCombo.Items.Clear();
            this.learningRateCombo.Items.Add(0.01);
            this.learningRateCombo.Items.Add(0.025);
            this.learningRateCombo.Items.Add(0.05);
            this.learningRateCombo.Items.Add(0.1);
            this.learningRateCombo.Items.Add(0.25);
            this.learningRateCombo.Items.Add(0.5);
            this.learningRateCombo.Items.Add(0.7);
            this.learningRateCombo.Items.Add(1.0);

            this.learningRateCombo.SelectedIndex = 0;
            this.epochsValue.Text = "10000";
            this.epsilonValue.Text = "0.00000000001";
        }

        private void learningRateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.learningRateValue.Text = this.learningRateCombo.Items[this.learningRateCombo.SelectedIndex].ToString();
        }

        private void trainAnn_Click(object sender, EventArgs e)
        {
            //  Start timer
            this.backgroundWorker1.RunWorkerAsync();

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
                targetSequence.MarkerStyle = MarkerStyle.Circle;
                targetSequence.MarkerSize = 10;
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

            //this.backgroundWorker1.CancelAsync();
        }

        private void generateAnn_Click(object sender, EventArgs e)
        {

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

        private void saveDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "%home%";
            saveFileDialog1.Filter = "Training set files (*.set)|*.set|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.trainingSet.SaveSet(saveFileDialog1.OpenFile());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trainingSet = new TrainingSet();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "%home%";
            openFileDialog1.Filter = "Training set files (*.set)|*.set|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
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

        private void createNewAnnCompatibleDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.createNewAnnCompatibleDatasetToolStripMenuItem.Checked)
                this.createNewAnnCompatibleDatasetToolStripMenuItem.Checked = false;
            else
                this.createNewAnnCompatibleDatasetToolStripMenuItem.Checked = true;
        }

        private void generateDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.generator = new TrainingSetGenerator((TrainingSetGenerator.Signals)this.generatorSignals.SelectedItem);
            this.trainingSet = this.generator.GenerateData();

            if (this.createNewAnnCompatibleDatasetToolStripMenuItem.Checked)
            {
                this.toolStripTextBox1.Text = this.trainingSet.InputMatrix.Rows().ToString();
                this.toolStripTextBox2.Text = this.trainingSet.TargetMatrix.Rows().ToString();

                int inputs = Int32.Parse(this.toolStripTextBox1.Text),
                    hiddenLayers = Int32.Parse(this.toolStripTextBox3.Text),
                    neuronsPerHiddenLayer = Int32.Parse(this.toolStripTextBox4.Text),
                    outputs = Int32.Parse(this.toolStripTextBox2.Text);

                this.ann = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(inputs, hiddenLayers, neuronsPerHiddenLayer, outputs, (Layer.TransferFunctions)this.layerTransfer.ComboBox.SelectedItem);

                this.layersList.DataSource = this.ann.Layers;
            }
        }

        private void generateANNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int inputs = Int32.Parse(this.toolStripTextBox1.Text),
                hiddenLayers = Int32.Parse(this.toolStripTextBox3.Text),
                neuronsPerHiddenLayer = Int32.Parse(this.toolStripTextBox4.Text),
                outputs = Int32.Parse(this.toolStripTextBox2.Text);

            this.ann = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(inputs, hiddenLayers, neuronsPerHiddenLayer, outputs, (Layer.TransferFunctions)this.layerTransfer.ComboBox.SelectedItem);

            this.layersList.DataSource = this.ann.Layers;
        }

        private void layerTransfer_Click(object sender, EventArgs e)
        {

        }

        private void computeOutput_Click(object sender, EventArgs e)
        {
            string[] list = this.inputManual.Text.Split(new char[] { ',' });
            double[] input = Array.ConvertAll(list, str => double.Parse(str));

            double[] output = this.ann.FeedForward(input);

            this.outputManual.Text = output.VectorToString();

            return;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long msTimeElapsed = 0, current;
            long interval = 10;

            while (!this.backgroundWorker1.CancellationPending)
            {
                current = stopWatch.ElapsedMilliseconds;
                interval -= current + msTimeElapsed;
                msTimeElapsed = current;

                if (interval <= 0)
                {
                    interval = 10;

                    this.timeElapsed.Text = msTimeElapsed.ToString();
                }
            }

            e.Cancel = true;
            return;
        }
    }
}

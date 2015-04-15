namespace ArtificialNeuralNetworkVisualizer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.learningMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trainingMethod = new System.Windows.Forms.ComboBox();
            this.trainAnn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.learningRateCombo = new System.Windows.Forms.ComboBox();
            this.costFunction = new System.Windows.Forms.ComboBox();
            this.epochsValue = new System.Windows.Forms.TextBox();
            this.epsilonValue = new System.Windows.Forms.TextBox();
            this.learningRateValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loadDataset = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.transferFunction = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.layersList = new System.Windows.Forms.ListBox();
            this.generateAnn = new System.Windows.Forms.Button();
            this.nrOutput = new System.Windows.Forms.TextBox();
            this.hiddenLayers = new System.Windows.Forms.TextBox();
            this.hiddenNeurons = new System.Windows.Forms.TextBox();
            this.nrInputs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(0, -2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1013, 537);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.learningMethod);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.trainingMethod);
            this.groupBox1.Controls.Add(this.trainAnn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.learningRateCombo);
            this.groupBox1.Controls.Add(this.costFunction);
            this.groupBox1.Controls.Add(this.epochsValue);
            this.groupBox1.Controls.Add(this.epsilonValue);
            this.groupBox1.Controls.Add(this.learningRateValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.loadDataset);
            this.groupBox1.Location = new System.Drawing.Point(1019, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 281);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artificial Neural Network Training";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Learning method:";
            // 
            // learningMethod
            // 
            this.learningMethod.FormattingEnabled = true;
            this.learningMethod.Location = new System.Drawing.Point(101, 54);
            this.learningMethod.Name = "learningMethod";
            this.learningMethod.Size = new System.Drawing.Size(201, 21);
            this.learningMethod.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Training method:";
            // 
            // trainingMethod
            // 
            this.trainingMethod.FormattingEnabled = true;
            this.trainingMethod.Location = new System.Drawing.Point(101, 81);
            this.trainingMethod.Name = "trainingMethod";
            this.trainingMethod.Size = new System.Drawing.Size(201, 21);
            this.trainingMethod.TabIndex = 11;
            // 
            // trainAnn
            // 
            this.trainAnn.Location = new System.Drawing.Point(208, 161);
            this.trainAnn.Name = "trainAnn";
            this.trainAnn.Size = new System.Drawing.Size(94, 46);
            this.trainAnn.TabIndex = 10;
            this.trainAnn.Text = "Train ANN";
            this.trainAnn.UseVisualStyleBackColor = true;
            this.trainAnn.Click += new System.EventHandler(this.trainAnn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cost function:";
            // 
            // learningRateCombo
            // 
            this.learningRateCombo.FormattingEnabled = true;
            this.learningRateCombo.Location = new System.Drawing.Point(208, 134);
            this.learningRateCombo.Name = "learningRateCombo";
            this.learningRateCombo.Size = new System.Drawing.Size(94, 21);
            this.learningRateCombo.TabIndex = 8;
            this.learningRateCombo.SelectedIndexChanged += new System.EventHandler(this.learningRateCombo_SelectedIndexChanged);
            // 
            // costFunction
            // 
            this.costFunction.FormattingEnabled = true;
            this.costFunction.Location = new System.Drawing.Point(101, 108);
            this.costFunction.Name = "costFunction";
            this.costFunction.Size = new System.Drawing.Size(201, 21);
            this.costFunction.TabIndex = 7;
            // 
            // epochsValue
            // 
            this.epochsValue.Location = new System.Drawing.Point(101, 187);
            this.epochsValue.Name = "epochsValue";
            this.epochsValue.Size = new System.Drawing.Size(94, 20);
            this.epochsValue.TabIndex = 6;
            // 
            // epsilonValue
            // 
            this.epsilonValue.Location = new System.Drawing.Point(101, 161);
            this.epsilonValue.Name = "epsilonValue";
            this.epsilonValue.Size = new System.Drawing.Size(94, 20);
            this.epsilonValue.TabIndex = 5;
            // 
            // learningRateValue
            // 
            this.learningRateValue.Location = new System.Drawing.Point(101, 135);
            this.learningRateValue.Name = "learningRateValue";
            this.learningRateValue.Size = new System.Drawing.Size(94, 20);
            this.learningRateValue.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Epsilon:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Learning rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Epochs:";
            // 
            // loadDataset
            // 
            this.loadDataset.Location = new System.Drawing.Point(6, 19);
            this.loadDataset.Name = "loadDataset";
            this.loadDataset.Size = new System.Drawing.Size(296, 23);
            this.loadDataset.TabIndex = 0;
            this.loadDataset.Text = "Load Input/Target matrices";
            this.loadDataset.UseVisualStyleBackColor = true;
            this.loadDataset.Click += new System.EventHandler(this.loadDataset_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 701);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1340, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(253, 17);
            this.statusLabel.Text = "Tip of the day: Artificial Neural Network (ANN)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.transferFunction);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.layersList);
            this.groupBox2.Controls.Add(this.generateAnn);
            this.groupBox2.Controls.Add(this.nrOutput);
            this.groupBox2.Controls.Add(this.hiddenLayers);
            this.groupBox2.Controls.Add(this.hiddenNeurons);
            this.groupBox2.Controls.Add(this.nrInputs);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(1019, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 316);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Artificial Neural Network";
            // 
            // transferFunction
            // 
            this.transferFunction.FormattingEnabled = true;
            this.transferFunction.Location = new System.Drawing.Point(105, 287);
            this.transferFunction.Name = "transferFunction";
            this.transferFunction.Size = new System.Drawing.Size(197, 21);
            this.transferFunction.TabIndex = 11;
            this.transferFunction.SelectionChangeCommitted += new System.EventHandler(this.transferFunction_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Transfer function:";
            // 
            // layersList
            // 
            this.layersList.FormattingEnabled = true;
            this.layersList.Location = new System.Drawing.Point(9, 147);
            this.layersList.Name = "layersList";
            this.layersList.Size = new System.Drawing.Size(293, 134);
            this.layersList.TabIndex = 9;
            this.layersList.SelectedIndexChanged += new System.EventHandler(this.layersList_SelectedIndexChanged);
            // 
            // generateAnn
            // 
            this.generateAnn.Location = new System.Drawing.Point(9, 117);
            this.generateAnn.Name = "generateAnn";
            this.generateAnn.Size = new System.Drawing.Size(294, 23);
            this.generateAnn.TabIndex = 8;
            this.generateAnn.Text = "Generate new network with randomized weights";
            this.generateAnn.UseVisualStyleBackColor = true;
            this.generateAnn.Click += new System.EventHandler(this.generateAnn_Click);
            // 
            // nrOutput
            // 
            this.nrOutput.Location = new System.Drawing.Point(190, 39);
            this.nrOutput.Name = "nrOutput";
            this.nrOutput.Size = new System.Drawing.Size(113, 20);
            this.nrOutput.TabIndex = 7;
            // 
            // hiddenLayers
            // 
            this.hiddenLayers.Location = new System.Drawing.Point(190, 65);
            this.hiddenLayers.Name = "hiddenLayers";
            this.hiddenLayers.Size = new System.Drawing.Size(113, 20);
            this.hiddenLayers.TabIndex = 6;
            // 
            // hiddenNeurons
            // 
            this.hiddenNeurons.Location = new System.Drawing.Point(190, 91);
            this.hiddenNeurons.Name = "hiddenNeurons";
            this.hiddenNeurons.Size = new System.Drawing.Size(113, 20);
            this.hiddenNeurons.TabIndex = 5;
            // 
            // nrInputs
            // 
            this.nrInputs.Location = new System.Drawing.Point(190, 13);
            this.nrInputs.Name = "nrInputs";
            this.nrInputs.Size = new System.Drawing.Size(113, 20);
            this.nrInputs.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Number of neurons per hidden layer:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Number of hidden layers:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Number of outputs:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Number of inputs:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 723);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artificial Neural Network Visualizer";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox trainingMethod;
        private System.Windows.Forms.Button trainAnn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox learningRateCombo;
        private System.Windows.Forms.ComboBox costFunction;
        private System.Windows.Forms.TextBox epochsValue;
        private System.Windows.Forms.TextBox epsilonValue;
        private System.Windows.Forms.TextBox learningRateValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadDataset;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox learningMethod;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button generateAnn;
        private System.Windows.Forms.TextBox nrOutput;
        private System.Windows.Forms.TextBox hiddenLayers;
        private System.Windows.Forms.TextBox hiddenNeurons;
        private System.Windows.Forms.TextBox nrInputs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox transferFunction;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox layersList;
    }
}


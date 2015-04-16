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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeElapsed = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.setNeurons = new System.Windows.Forms.Button();
            this.nrNeuronsInLayer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.copyOutput = new System.Windows.Forms.Button();
            this.computeOutput = new System.Windows.Forms.Button();
            this.outputManual = new System.Windows.Forms.TextBox();
            this.inputManual = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.transferFunction = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.layersList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewAnnCompatibleDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateANNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorSignals = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.layerTransfer = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(0, 27);
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
            this.groupBox1.Location = new System.Drawing.Point(1019, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 218);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artificial Neural Network Training";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Learning method:";
            // 
            // learningMethod
            // 
            this.learningMethod.FormattingEnabled = true;
            this.learningMethod.Location = new System.Drawing.Point(101, 21);
            this.learningMethod.Name = "learningMethod";
            this.learningMethod.Size = new System.Drawing.Size(201, 21);
            this.learningMethod.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Training method:";
            // 
            // trainingMethod
            // 
            this.trainingMethod.FormattingEnabled = true;
            this.trainingMethod.Location = new System.Drawing.Point(101, 48);
            this.trainingMethod.Name = "trainingMethod";
            this.trainingMethod.Size = new System.Drawing.Size(201, 21);
            this.trainingMethod.TabIndex = 11;
            // 
            // trainAnn
            // 
            this.trainAnn.Location = new System.Drawing.Point(208, 128);
            this.trainAnn.Name = "trainAnn";
            this.trainAnn.Size = new System.Drawing.Size(94, 46);
            this.trainAnn.TabIndex = 10;
            this.trainAnn.Text = "Train ANN (Step)";
            this.trainAnn.UseVisualStyleBackColor = true;
            this.trainAnn.Click += new System.EventHandler(this.trainAnn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cost function:";
            // 
            // learningRateCombo
            // 
            this.learningRateCombo.FormattingEnabled = true;
            this.learningRateCombo.Location = new System.Drawing.Point(208, 101);
            this.learningRateCombo.Name = "learningRateCombo";
            this.learningRateCombo.Size = new System.Drawing.Size(94, 21);
            this.learningRateCombo.TabIndex = 8;
            this.learningRateCombo.SelectedIndexChanged += new System.EventHandler(this.learningRateCombo_SelectedIndexChanged);
            // 
            // costFunction
            // 
            this.costFunction.FormattingEnabled = true;
            this.costFunction.Location = new System.Drawing.Point(101, 75);
            this.costFunction.Name = "costFunction";
            this.costFunction.Size = new System.Drawing.Size(201, 21);
            this.costFunction.TabIndex = 7;
            // 
            // epochsValue
            // 
            this.epochsValue.Location = new System.Drawing.Point(101, 154);
            this.epochsValue.Name = "epochsValue";
            this.epochsValue.Size = new System.Drawing.Size(94, 20);
            this.epochsValue.TabIndex = 6;
            // 
            // epsilonValue
            // 
            this.epsilonValue.Location = new System.Drawing.Point(101, 128);
            this.epsilonValue.Name = "epsilonValue";
            this.epsilonValue.Size = new System.Drawing.Size(94, 20);
            this.epsilonValue.TabIndex = 5;
            // 
            // learningRateValue
            // 
            this.learningRateValue.Location = new System.Drawing.Point(101, 102);
            this.learningRateValue.Name = "learningRateValue";
            this.learningRateValue.Size = new System.Drawing.Size(94, 20);
            this.learningRateValue.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Epsilon:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Learning rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Epochs/Steps:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.timeElapsed});
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
            // timeElapsed
            // 
            this.timeElapsed.Name = "timeElapsed";
            this.timeElapsed.Size = new System.Drawing.Size(326, 17);
            this.timeElapsed.Text = " - Written by: Kent Stark Olsen (kent.stark.olsen@gmail.com)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.setNeurons);
            this.groupBox2.Controls.Add(this.nrNeuronsInLayer);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.transferFunction);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.layersList);
            this.groupBox2.Location = new System.Drawing.Point(1019, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 330);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Artificial Neural Network";
            // 
            // setNeurons
            // 
            this.setNeurons.Enabled = false;
            this.setNeurons.Location = new System.Drawing.Point(234, 198);
            this.setNeurons.Name = "setNeurons";
            this.setNeurons.Size = new System.Drawing.Size(69, 23);
            this.setNeurons.TabIndex = 16;
            this.setNeurons.Text = "Set";
            this.setNeurons.UseVisualStyleBackColor = true;
            this.setNeurons.Click += new System.EventHandler(this.setNeurons_Click);
            // 
            // nrNeuronsInLayer
            // 
            this.nrNeuronsInLayer.Location = new System.Drawing.Point(128, 200);
            this.nrNeuronsInLayer.Name = "nrNeuronsInLayer";
            this.nrNeuronsInLayer.Size = new System.Drawing.Size(100, 20);
            this.nrNeuronsInLayer.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Number of neurons:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.copyOutput);
            this.groupBox3.Controls.Add(this.computeOutput);
            this.groupBox3.Controls.Add(this.outputManual);
            this.groupBox3.Controls.Add(this.inputManual);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(9, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 97);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual feed-forward";
            // 
            // copyOutput
            // 
            this.copyOutput.Location = new System.Drawing.Point(6, 66);
            this.copyOutput.Name = "copyOutput";
            this.copyOutput.Size = new System.Drawing.Size(76, 23);
            this.copyOutput.TabIndex = 5;
            this.copyOutput.Text = "Copy output";
            this.copyOutput.UseVisualStyleBackColor = true;
            this.copyOutput.Click += new System.EventHandler(this.copyOutput_Click);
            // 
            // computeOutput
            // 
            this.computeOutput.Location = new System.Drawing.Point(88, 66);
            this.computeOutput.Name = "computeOutput";
            this.computeOutput.Size = new System.Drawing.Size(200, 23);
            this.computeOutput.TabIndex = 4;
            this.computeOutput.Text = "Compute Output";
            this.computeOutput.UseVisualStyleBackColor = true;
            this.computeOutput.Click += new System.EventHandler(this.computeOutput_Click);
            // 
            // outputManual
            // 
            this.outputManual.Location = new System.Drawing.Point(88, 40);
            this.outputManual.Name = "outputManual";
            this.outputManual.Size = new System.Drawing.Size(200, 20);
            this.outputManual.TabIndex = 3;
            // 
            // inputManual
            // 
            this.inputManual.Location = new System.Drawing.Point(88, 13);
            this.inputManual.Name = "inputManual";
            this.inputManual.Size = new System.Drawing.Size(200, 20);
            this.inputManual.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Output vector:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Input vector:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Layers:";
            // 
            // transferFunction
            // 
            this.transferFunction.FormattingEnabled = true;
            this.transferFunction.Location = new System.Drawing.Point(127, 172);
            this.transferFunction.Name = "transferFunction";
            this.transferFunction.Size = new System.Drawing.Size(176, 21);
            this.transferFunction.TabIndex = 11;
            this.transferFunction.SelectionChangeCommitted += new System.EventHandler(this.transferFunction_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Layer transfer function:";
            // 
            // layersList
            // 
            this.layersList.FormattingEnabled = true;
            this.layersList.Location = new System.Drawing.Point(9, 32);
            this.layersList.Name = "layersList";
            this.layersList.Size = new System.Drawing.Size(294, 134);
            this.layersList.TabIndex = 9;
            this.layersList.SelectedIndexChanged += new System.EventHandler(this.layersList_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.generatorToolStripMenuItem,
            this.toolStripMenuItem1,
            this.generatorSignals,
            this.toolStripMenuItem3,
            this.layerTransfer,
            this.toolStripMenuItem4,
            this.toolStripTextBox1,
            this.toolStripMenuItem5,
            this.toolStripTextBox2,
            this.toolStripMenuItem2,
            this.toolStripTextBox3,
            this.toolStripMenuItem6,
            this.toolStripTextBox4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1340, 27);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDatasetToolStripMenuItem,
            this.saveDatasetToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadDatasetToolStripMenuItem
            // 
            this.loadDatasetToolStripMenuItem.Name = "loadDatasetToolStripMenuItem";
            this.loadDatasetToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.loadDatasetToolStripMenuItem.Text = "Load dataset";
            this.loadDatasetToolStripMenuItem.Click += new System.EventHandler(this.loadDatasetToolStripMenuItem_Click);
            // 
            // saveDatasetToolStripMenuItem
            // 
            this.saveDatasetToolStripMenuItem.Name = "saveDatasetToolStripMenuItem";
            this.saveDatasetToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.saveDatasetToolStripMenuItem.Text = "Save dataset";
            this.saveDatasetToolStripMenuItem.Click += new System.EventHandler(this.saveDatasetToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // generatorToolStripMenuItem
            // 
            this.generatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewAnnCompatibleDatasetToolStripMenuItem,
            this.generateDatasetToolStripMenuItem,
            this.generateANNToolStripMenuItem});
            this.generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            this.generatorToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.generatorToolStripMenuItem.Text = "Generator";
            // 
            // createNewAnnCompatibleDatasetToolStripMenuItem
            // 
            this.createNewAnnCompatibleDatasetToolStripMenuItem.Checked = true;
            this.createNewAnnCompatibleDatasetToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createNewAnnCompatibleDatasetToolStripMenuItem.Name = "createNewAnnCompatibleDatasetToolStripMenuItem";
            this.createNewAnnCompatibleDatasetToolStripMenuItem.Size = new System.Drawing.Size(364, 22);
            this.createNewAnnCompatibleDatasetToolStripMenuItem.Text = "Create new ANN when training set is generated/loaded";
            this.createNewAnnCompatibleDatasetToolStripMenuItem.Click += new System.EventHandler(this.createNewAnnCompatibleDatasetToolStripMenuItem_Click);
            // 
            // generateDatasetToolStripMenuItem
            // 
            this.generateDatasetToolStripMenuItem.Name = "generateDatasetToolStripMenuItem";
            this.generateDatasetToolStripMenuItem.Size = new System.Drawing.Size(364, 22);
            this.generateDatasetToolStripMenuItem.Text = "Generate training set";
            this.generateDatasetToolStripMenuItem.Click += new System.EventHandler(this.generateDatasetToolStripMenuItem_Click);
            // 
            // generateANNToolStripMenuItem
            // 
            this.generateANNToolStripMenuItem.Name = "generateANNToolStripMenuItem";
            this.generateANNToolStripMenuItem.Size = new System.Drawing.Size(364, 22);
            this.generateANNToolStripMenuItem.Text = "Generate ANN";
            this.generateANNToolStripMenuItem.Click += new System.EventHandler(this.generateANNToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 23);
            this.toolStripMenuItem1.Text = "Training characteristics:";
            // 
            // generatorSignals
            // 
            this.generatorSignals.Name = "generatorSignals";
            this.generatorSignals.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(103, 23);
            this.toolStripMenuItem3.Text = "Default transfer:";
            // 
            // layerTransfer
            // 
            this.layerTransfer.Name = "layerTransfer";
            this.layerTransfer.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(55, 23);
            this.toolStripMenuItem4.Text = "Inputs:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "2";
            this.toolStripTextBox1.ToolTipText = "Number of input neurons to ANN";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(65, 23);
            this.toolStripMenuItem5.Text = "Outputs:";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox2.Text = "1";
            this.toolStripTextBox2.ToolTipText = "Number of outputs from ANN";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(94, 23);
            this.toolStripMenuItem2.Text = "Hidden layers:";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox3.Text = "1";
            this.toolStripTextBox3.ToolTipText = "Number of hidden layers in ANN";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Enabled = false;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(67, 23);
            this.toolStripMenuItem6.Text = "Neurons:";
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox4.Text = "2";
            this.toolStripTextBox4.ToolTipText = "Number of neurons per hidden layer";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 723);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.MainMenuStrip = this.menuStrip1;
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox learningMethod;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox transferFunction;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox layersList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox generatorSignals;
        private System.Windows.Forms.ToolStripMenuItem loadDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewAnnCompatibleDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateANNToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button computeOutput;
        private System.Windows.Forms.TextBox outputManual;
        private System.Windows.Forms.TextBox inputManual;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripComboBox layerTransfer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripStatusLabel timeElapsed;
        private System.Windows.Forms.Button setNeurons;
        private System.Windows.Forms.TextBox nrNeuronsInLayer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button copyOutput;
    }
}


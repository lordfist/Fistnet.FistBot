namespace Fistnet.FistBot.StrategyBuilder
{
    partial class BuildStrategy
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
            this.uiRunBattles = new System.Windows.Forms.Button();
            this.uiCreateRandomSS = new System.Windows.Forms.Button();
            this.uiRandomSS = new System.Windows.Forms.TextBox();
            this.uiGenerationCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiRoundsPerBattle = new System.Windows.Forms.TextBox();
            this.uiRobots = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiPopulationCount = new System.Windows.Forms.TextBox();
            this.uiLoadRobots = new System.Windows.Forms.Button();
            this.uiGenerationProgress = new System.Windows.Forms.ProgressBar();
            this.uiLabelBattle = new System.Windows.Forms.Label();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiBattleWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // uiRunBattles
            // 
            this.uiRunBattles.Location = new System.Drawing.Point(269, 439);
            this.uiRunBattles.Name = "uiRunBattles";
            this.uiRunBattles.Size = new System.Drawing.Size(218, 23);
            this.uiRunBattles.TabIndex = 0;
            this.uiRunBattles.Text = "Run battles";
            this.uiRunBattles.UseVisualStyleBackColor = true;
            this.uiRunBattles.Click += new System.EventHandler(this.uiRunBattles_Click);
            // 
            // uiCreateRandomSS
            // 
            this.uiCreateRandomSS.Location = new System.Drawing.Point(12, 439);
            this.uiCreateRandomSS.Name = "uiCreateRandomSS";
            this.uiCreateRandomSS.Size = new System.Drawing.Size(221, 23);
            this.uiCreateRandomSS.TabIndex = 1;
            this.uiCreateRandomSS.Text = "Create random SS";
            this.uiCreateRandomSS.UseVisualStyleBackColor = true;
            this.uiCreateRandomSS.Click += new System.EventHandler(this.button2_Click);
            // 
            // uiRandomSS
            // 
            this.uiRandomSS.Location = new System.Drawing.Point(12, 12);
            this.uiRandomSS.Multiline = true;
            this.uiRandomSS.Name = "uiRandomSS";
            this.uiRandomSS.Size = new System.Drawing.Size(221, 421);
            this.uiRandomSS.TabIndex = 2;
            // 
            // uiGenerationCount
            // 
            this.uiGenerationCount.Location = new System.Drawing.Point(387, 12);
            this.uiGenerationCount.Name = "uiGenerationCount";
            this.uiGenerationCount.Size = new System.Drawing.Size(100, 20);
            this.uiGenerationCount.TabIndex = 3;
            this.uiGenerationCount.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Generation count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rounds per battle";
            // 
            // uiRoundsPerBattle
            // 
            this.uiRoundsPerBattle.Location = new System.Drawing.Point(387, 63);
            this.uiRoundsPerBattle.Name = "uiRoundsPerBattle";
            this.uiRoundsPerBattle.Size = new System.Drawing.Size(100, 20);
            this.uiRoundsPerBattle.TabIndex = 6;
            this.uiRoundsPerBattle.Text = "10";
            // 
            // uiRobots
            // 
            this.uiRobots.FormattingEnabled = true;
            this.uiRobots.Location = new System.Drawing.Point(269, 100);
            this.uiRobots.Name = "uiRobots";
            this.uiRobots.Size = new System.Drawing.Size(218, 304);
            this.uiRobots.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Population count";
            // 
            // uiPopulationCount
            // 
            this.uiPopulationCount.Location = new System.Drawing.Point(387, 37);
            this.uiPopulationCount.Name = "uiPopulationCount";
            this.uiPopulationCount.Size = new System.Drawing.Size(100, 20);
            this.uiPopulationCount.TabIndex = 8;
            this.uiPopulationCount.Text = "100";
            // 
            // uiLoadRobots
            // 
            this.uiLoadRobots.Location = new System.Drawing.Point(269, 410);
            this.uiLoadRobots.Name = "uiLoadRobots";
            this.uiLoadRobots.Size = new System.Drawing.Size(218, 23);
            this.uiLoadRobots.TabIndex = 10;
            this.uiLoadRobots.Text = "Load robots";
            this.uiLoadRobots.UseVisualStyleBackColor = true;
            this.uiLoadRobots.Click += new System.EventHandler(this.uiLoadRobots_Click);
            // 
            // uiGenerationProgress
            // 
            this.uiGenerationProgress.Location = new System.Drawing.Point(12, 494);
            this.uiGenerationProgress.Name = "uiGenerationProgress";
            this.uiGenerationProgress.Size = new System.Drawing.Size(384, 23);
            this.uiGenerationProgress.TabIndex = 11;
            // 
            // uiLabelBattle
            // 
            this.uiLabelBattle.AutoSize = true;
            this.uiLabelBattle.Location = new System.Drawing.Point(9, 478);
            this.uiLabelBattle.Name = "uiLabelBattle";
            this.uiLabelBattle.Size = new System.Drawing.Size(0, 13);
            this.uiLabelBattle.TabIndex = 12;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.Enabled = false;
            this.uiCancelButton.Location = new System.Drawing.Point(412, 494);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 13;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            this.uiCancelButton.Click += new System.EventHandler(this.uiCancelButton_Click);
            // 
            // uiBattleWorker
            // 
            this.uiBattleWorker.WorkerReportsProgress = true;
            this.uiBattleWorker.WorkerSupportsCancellation = true;
            this.uiBattleWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.uiBattleWorker_DoWork);
            this.uiBattleWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.uiBattleWorker_ProgressChanged);
            this.uiBattleWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.uiBattleWorker_RunWorkerCompleted);
            // 
            // BuildStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 526);
            this.Controls.Add(this.uiCancelButton);
            this.Controls.Add(this.uiLabelBattle);
            this.Controls.Add(this.uiGenerationProgress);
            this.Controls.Add(this.uiLoadRobots);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiPopulationCount);
            this.Controls.Add(this.uiRobots);
            this.Controls.Add(this.uiRoundsPerBattle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiGenerationCount);
            this.Controls.Add(this.uiRandomSS);
            this.Controls.Add(this.uiCreateRandomSS);
            this.Controls.Add(this.uiRunBattles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BuildStrategy";
            this.Text = "Strategy builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uiRunBattles;
        private System.Windows.Forms.Button uiCreateRandomSS;
        private System.Windows.Forms.TextBox uiRandomSS;
        private System.Windows.Forms.TextBox uiGenerationCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uiRoundsPerBattle;
        private System.Windows.Forms.CheckedListBox uiRobots;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiPopulationCount;
        private System.Windows.Forms.Button uiLoadRobots;
        private System.Windows.Forms.ProgressBar uiGenerationProgress;
        private System.Windows.Forms.Label uiLabelBattle;
        private System.Windows.Forms.Button uiCancelButton;
        private System.ComponentModel.BackgroundWorker uiBattleWorker;
    }
}


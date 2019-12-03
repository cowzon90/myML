namespace myML.Forms
{
    partial class FrmLinearRegression
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLearningRate = new System.Windows.Forms.TextBox();
            this.txtIteration = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGradientDescent = new System.Windows.Forms.Button();
            this.btnNormalEquation = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLog);
            this.groupBox1.Controls.Add(this.btnNormalEquation);
            this.groupBox1.Controls.Add(this.btnGradientDescent);
            this.groupBox1.Controls.Add(this.txtIteration);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLearningRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSetData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Linear Regression";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(170, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 450);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // btnSetData
            // 
            this.btnSetData.Location = new System.Drawing.Point(28, 36);
            this.btnSetData.Name = "btnSetData";
            this.btnSetData.Size = new System.Drawing.Size(100, 25);
            this.btnSetData.TabIndex = 0;
            this.btnSetData.Text = "Set Data";
            this.btnSetData.UseVisualStyleBackColor = true;
            this.btnSetData.Click += new System.EventHandler(this.btnSetData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Learning Rate (alpha)";
            // 
            // txtLearningRate
            // 
            this.txtLearningRate.Location = new System.Drawing.Point(28, 88);
            this.txtLearningRate.Name = "txtLearningRate";
            this.txtLearningRate.Size = new System.Drawing.Size(100, 21);
            this.txtLearningRate.TabIndex = 2;
            // 
            // txtIteration
            // 
            this.txtIteration.Location = new System.Drawing.Point(28, 136);
            this.txtIteration.Name = "txtIteration";
            this.txtIteration.Size = new System.Drawing.Size(100, 21);
            this.txtIteration.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Iteration.";
            // 
            // btnGradientDescent
            // 
            this.btnGradientDescent.Location = new System.Drawing.Point(28, 183);
            this.btnGradientDescent.Name = "btnGradientDescent";
            this.btnGradientDescent.Size = new System.Drawing.Size(125, 25);
            this.btnGradientDescent.TabIndex = 5;
            this.btnGradientDescent.Text = "Gradient Descent";
            this.btnGradientDescent.UseVisualStyleBackColor = true;
            this.btnGradientDescent.Click += new System.EventHandler(this.btnGradientDescent_Click);
            // 
            // btnNormalEquation
            // 
            this.btnNormalEquation.Location = new System.Drawing.Point(28, 223);
            this.btnNormalEquation.Name = "btnNormalEquation";
            this.btnNormalEquation.Size = new System.Drawing.Size(125, 25);
            this.btnNormalEquation.TabIndex = 6;
            this.btnNormalEquation.Text = "Normal Equation";
            this.btnNormalEquation.UseVisualStyleBackColor = true;
            this.btnNormalEquation.Click += new System.EventHandler(this.btnNormalEquation_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(28, 266);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(100, 25);
            this.btnLog.TabIndex = 7;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // FrmLinearRegression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLinearRegression";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnNormalEquation;
        private System.Windows.Forms.Button btnGradientDescent;
        private System.Windows.Forms.TextBox txtIteration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLearningRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSetData;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}


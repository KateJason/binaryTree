namespace BinaryTree
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnConvertToArray = new Button();
            lblArrayResult = new Label();
            label_txtNodeValues = new Label();
            label1 = new Label();
            panelTree = new Panel();
            lblErrorMessage = new Label();
            txtNodeValues = new TextBox();
            txtNodeCount = new TextBox();
            panel1.SuspendLayout();
            panelTree.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(btnConvertToArray);
            panel1.Controls.Add(lblArrayResult);
            panel1.Controls.Add(label_txtNodeValues);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panelTree);
            panel1.Controls.Add(txtNodeValues);
            panel1.Controls.Add(txtNodeCount);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1346, 1161);
            panel1.TabIndex = 0;
            // 
            // btnConvertToArray
            // 
            btnConvertToArray.FlatStyle = FlatStyle.Flat;
            btnConvertToArray.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnConvertToArray.ForeColor = SystemColors.ControlLight;
            btnConvertToArray.Location = new Point(31, 471);
            btnConvertToArray.Name = "btnConvertToArray";
            btnConvertToArray.Size = new Size(455, 90);
            btnConvertToArray.TabIndex = 7;
            btnConvertToArray.Text = "轉換成一維陣列";
            btnConvertToArray.UseVisualStyleBackColor = true;
            btnConvertToArray.Click += btnConvertToArray_Click;
            // 
            // lblArrayResult
            // 
            lblArrayResult.AutoSize = true;
            lblArrayResult.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblArrayResult.ForeColor = SystemColors.ControlLight;
            lblArrayResult.Location = new Point(12, 375);
            lblArrayResult.Name = "lblArrayResult";
            lblArrayResult.Size = new Size(126, 32);
            lblArrayResult.TabIndex = 6;
            lblArrayResult.Text = "一維陣列";
            // 
            // label_txtNodeValues
            // 
            label_txtNodeValues.AutoSize = true;
            label_txtNodeValues.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label_txtNodeValues.ForeColor = SystemColors.ControlLight;
            label_txtNodeValues.Location = new Point(12, 123);
            label_txtNodeValues.Name = "label_txtNodeValues";
            label_txtNodeValues.Size = new Size(549, 32);
            label_txtNodeValues.TabIndex = 5;
            label_txtNodeValues.Text = "請再分別輸入這 {nodeCount} 個節點的內容";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(12, 69);
            label1.Name = "label1";
            label1.Size = new Size(218, 32);
            label1.TabIndex = 0;
            label1.Text = "請輸入節點數量:";
            // 
            // panelTree
            // 
            panelTree.BackColor = Color.FromArgb(64, 0, 0);
            panelTree.Controls.Add(lblErrorMessage);
            panelTree.Location = new Point(668, 3);
            panelTree.Name = "panelTree";
            panelTree.Size = new Size(675, 1155);
            panelTree.TabIndex = 4;
            panelTree.Paint += panelTree_Paint;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblErrorMessage.ForeColor = SystemColors.ControlLightLight;
            lblErrorMessage.Location = new Point(3, 14);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(195, 32);
            lblErrorMessage.TabIndex = 6;
            lblErrorMessage.Text = "Error Message";
            // 
            // txtNodeValues
            // 
            txtNodeValues.Location = new Point(12, 170);
            txtNodeValues.Name = "txtNodeValues";
            txtNodeValues.Size = new Size(535, 30);
            txtNodeValues.TabIndex = 1;
            // 
            // txtNodeCount
            // 
            txtNodeCount.Location = new Point(238, 69);
            txtNodeCount.Name = "txtNodeCount";
            txtNodeCount.Size = new Size(150, 30);
            txtNodeCount.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1346, 1161);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelTree.ResumeLayout(false);
            panelTree.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtNodeValues;
        private TextBox txtNodeCount;
        private Panel panelTree;
        private Label label_txtNodeValues;
        private Label label1;
        private Label lblErrorMessage;
        private Label lblArrayResult;
        private Button btnConvertToArray;
    }
}

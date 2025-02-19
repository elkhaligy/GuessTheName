namespace ClientApp
{
    partial class RoomCreationForm
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
            comboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox = new TextBox();
            button = new Button();
            SuspendLayout();
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "Animal", "Country", "Item" });
            comboBox.Location = new Point(142, 145);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(133, 23);
            comboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(142, 6);
            label1.Name = "label1";
            label1.Size = new Size(133, 30);
            label1.TabIndex = 1;
            label1.Text = "Create Room";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 127);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(142, 63);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 3;
            label3.Text = "Name";
            // 
            // textBox
            // 
            textBox.Location = new Point(142, 81);
            textBox.Name = "textBox";
            textBox.Size = new Size(133, 23);
            textBox.TabIndex = 4;
            // 
            // button
            // 
            button.Location = new Point(330, 198);
            button.Name = "button";
            button.Size = new Size(75, 23);
            button.TabIndex = 5;
            button.Text = "Create";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // RoomCreationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 242);
            Controls.Add(button);
            Controls.Add(textBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox);
            Name = "RoomCreationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RoomCreationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox;
        private Button button;
    }
}
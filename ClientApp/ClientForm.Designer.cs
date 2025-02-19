namespace ClientApp
{
    partial class ClientForm
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
        /// 

        private void InitializeComponent()
        {

            connectButton = new Button();
            userNameTextBox = new TextBox();
            label1 = new Label();
            connectedCheckBox = new CheckBox();
            receivedDataTextBox = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // connectButton
            // 
            connectButton.Location = new Point(209, 172);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(188, 86);
            connectButton.TabIndex = 0;
            connectButton.Text = "Login";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButtonClick;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(209, 124);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(188, 31);
            userNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(249, 96);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 4;
            label1.Text = "User Name";
            // 
            // connectedCheckBox
            // 
            connectedCheckBox.AutoSize = true;
            connectedCheckBox.Enabled = false;
            connectedCheckBox.Location = new Point(249, 280);
            connectedCheckBox.Name = "connectedCheckBox";
            connectedCheckBox.Size = new Size(123, 29);
            connectedCheckBox.TabIndex = 5;
            connectedCheckBox.Text = "Connected";
            connectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // receivedDataTextBox
            // 
            receivedDataTextBox.Location = new Point(445, 74);
            receivedDataTextBox.Multiline = true;
            receivedDataTextBox.Name = "receivedDataTextBox";
            receivedDataTextBox.Size = new Size(171, 235);
            receivedDataTextBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(445, 46);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 7;
            label2.Text = "Data Received";
            // 
            // ClientForm
            // 
            ClientSize = new Size(646, 379);
            Controls.Add(label2);
            Controls.Add(receivedDataTextBox);
            Controls.Add(connectedCheckBox);
            Controls.Add(label1);
            Controls.Add(userNameTextBox);
            Controls.Add(connectButton);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();



        }

        #endregion

        private Button connectButton;
        private TextBox userNameTextBox;
        private Label label1;
        private CheckBox connectedCheckBox;
        private TextBox receivedDataTextBox;
        private Label label2;
    }
}

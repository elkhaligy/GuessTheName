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
            SuspendLayout();
            // 
            // connectButton
            // 
            connectButton.Location = new Point(170, 135);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(73, 27);
            connectButton.TabIndex = 0;
            connectButton.Text = "Login";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButtonClick;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(55, 96);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(188, 23);
            userNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 78);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 4;
            label1.Text = "User Name";
            // 
            // ClientForm
            // 
            ClientSize = new Size(289, 227);
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
    }
}

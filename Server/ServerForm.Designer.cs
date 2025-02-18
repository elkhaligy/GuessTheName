namespace ServerApp
{
    partial class ServerForm
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
            startServerButton = new Button();
            messageTextBox = new TextBox();
            sendButton = new Button();
            connectedClientsLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            clientMessagesTextBox = new TextBox();
            stopServerButton = new Button();
            connectedClientsListBox = new TextBox();
            SuspendLayout();
            // 
            // startServerButton
            // 
            startServerButton.Location = new Point(718, 472);
            startServerButton.Name = "startServerButton";
            startServerButton.Size = new Size(164, 76);
            startServerButton.TabIndex = 0;
            startServerButton.Text = "Start";
            startServerButton.UseVisualStyleBackColor = true;
            startServerButton.Click += startServerButton_Click;
            // 
            // messageTextBox
            // 
            messageTextBox.Location = new Point(248, 517);
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(295, 31);
            messageTextBox.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(568, 517);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(112, 34);
            sendButton.TabIndex = 2;
            sendButton.Text = "Broadcast";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // connectedClientsLabel
            // 
            connectedClientsLabel.AutoSize = true;
            connectedClientsLabel.Location = new Point(16, 391);
            connectedClientsLabel.Name = "connectedClientsLabel";
            connectedClientsLabel.Size = new Size(163, 25);
            connectedClientsLabel.TabIndex = 4;
            connectedClientsLabel.Text = "Connected Clients :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 42);
            label1.Name = "label1";
            label1.Size = new Size(67, 32);
            label1.TabIndex = 5;
            label1.Text = "Logs";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(238, 5);
            label2.Name = "label2";
            label2.Size = new Size(314, 44);
            label2.TabIndex = 6;
            label2.Text = "Server Dashboard";
            // 
            // clientMessagesTextBox
            // 
            clientMessagesTextBox.Location = new Point(16, 77);
            clientMessagesTextBox.Multiline = true;
            clientMessagesTextBox.Name = "clientMessagesTextBox";
            clientMessagesTextBox.Size = new Size(866, 286);
            clientMessagesTextBox.TabIndex = 7;
            // 
            // stopServerButton
            // 
            stopServerButton.Enabled = false;
            stopServerButton.Location = new Point(718, 390);
            stopServerButton.Name = "stopServerButton";
            stopServerButton.Size = new Size(164, 76);
            stopServerButton.TabIndex = 8;
            stopServerButton.Text = "Stop";
            stopServerButton.UseVisualStyleBackColor = true;
            stopServerButton.Click += stopServerButton_Click;
            // 
            // connectedClientsListBox
            // 
            connectedClientsListBox.Location = new Point(16, 428);
            connectedClientsListBox.Multiline = true;
            connectedClientsListBox.Name = "connectedClientsListBox";
            connectedClientsListBox.Size = new Size(207, 120);
            connectedClientsListBox.TabIndex = 9;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 573);
            Controls.Add(connectedClientsListBox);
            Controls.Add(stopServerButton);
            Controls.Add(clientMessagesTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(connectedClientsLabel);
            Controls.Add(sendButton);
            Controls.Add(messageTextBox);
            Controls.Add(startServerButton);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startServerButton;
        private TextBox messageTextBox;
        private Button sendButton;
        private Label connectedClientsLabel;
        private Label label1;
        private Label label2;
        private TextBox clientMessagesTextBox;
        private Button stopServerButton;
        private TextBox connectedClientsListBox;
    }
}

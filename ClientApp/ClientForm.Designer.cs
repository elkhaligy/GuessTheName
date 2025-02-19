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
            loginPanel = new Panel();
            roomsListPanel = new Panel();
            testCreateRoomButton = new Button();
            testFlowLayout = new FlowLayoutPanel();
            loginPanel.SuspendLayout();
            roomsListPanel.SuspendLayout();
            SuspendLayout();
            // 
            // connectButton
            // 
            connectButton.Location = new Point(419, 273);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(73, 27);
            connectButton.TabIndex = 0;
            connectButton.Text = "Login";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButtonClick;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(304, 244);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(188, 23);
            userNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(304, 226);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 4;
            label1.Text = "User Name";
            // 
            // loginPanel
            // 
            loginPanel.Controls.Add(userNameTextBox);
            loginPanel.Controls.Add(connectButton);
            loginPanel.Controls.Add(label1);
            loginPanel.Location = new Point(12, 12);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(808, 494);
            loginPanel.TabIndex = 5;
            // 
            // roomsListPanel
            // 
            roomsListPanel.Controls.Add(testCreateRoomButton);
            roomsListPanel.Controls.Add(testFlowLayout);
            roomsListPanel.Location = new Point(12, 12);
            roomsListPanel.Name = "roomsListPanel";
            roomsListPanel.Size = new Size(808, 494);
            roomsListPanel.TabIndex = 5;
            roomsListPanel.Visible = false;
            // 
            // testCreateRoomButton
            // 
            testCreateRoomButton.Location = new Point(681, 454);
            testCreateRoomButton.Name = "testCreateRoomButton";
            testCreateRoomButton.Size = new Size(90, 23);
            testCreateRoomButton.TabIndex = 1;
            testCreateRoomButton.Text = "Create Room";
            testCreateRoomButton.UseVisualStyleBackColor = true;
            testCreateRoomButton.Click += testCreateRoomButton_Click;
            // 
            // testFlowLayout
            // 
            testFlowLayout.Location = new Point(33, 18);
            testFlowLayout.Name = "testFlowLayout";
            testFlowLayout.Size = new Size(738, 398);
            testFlowLayout.TabIndex = 0;
            // 
            // ClientForm
            // 
            ClientSize = new Size(832, 518);
            Controls.Add(roomsListPanel);
            Controls.Add(loginPanel);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            roomsListPanel.ResumeLayout(false);
            ResumeLayout(false);



        }

        #endregion

        private Button connectButton;
        private TextBox userNameTextBox;
        private Label label1;
        private Panel loginPanel;
        private Panel roomsListPanel;
        private Button testCreateRoomButton;
        private FlowLayoutPanel testFlowLayout;
    }
}

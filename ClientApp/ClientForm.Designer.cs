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
            loginButton = new Button();
            userNameTextBox = new TextBox();
            label1 = new Label();
            loginPanel = new Panel();
            roomsListPanel = new Panel();
            roomsListFlowLayout = new FlowLayoutPanel();
            createRoomButton = new Button();
            loginPanel.SuspendLayout();
            roomsListPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(419, 273);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(73, 27);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
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
            loginPanel.Controls.Add(loginButton);
            loginPanel.Controls.Add(label1);
            loginPanel.Location = new Point(12, 12);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(808, 494);
            loginPanel.TabIndex = 5;
            // 
            // roomsListPanel
            // 
            roomsListPanel.Controls.Add(roomsListFlowLayout);
            roomsListPanel.Controls.Add(createRoomButton);
            roomsListPanel.Location = new Point(12, 12);
            roomsListPanel.Name = "roomsListPanel";
            roomsListPanel.Size = new Size(808, 494);
            roomsListPanel.TabIndex = 5;
            roomsListPanel.Visible = false;
            // 
            // roomsListFlowLayout
            // 
            roomsListFlowLayout.Location = new Point(33, 18);
            roomsListFlowLayout.Name = "roomsListFlowLayout";
            roomsListFlowLayout.Size = new Size(738, 398);
            roomsListFlowLayout.TabIndex = 0;
            // 
            // createRoomButton
            // 
            createRoomButton.Location = new Point(681, 454);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(90, 23);
            createRoomButton.TabIndex = 1;
            createRoomButton.Text = "Create Room";
            createRoomButton.UseVisualStyleBackColor = true;
            createRoomButton.Click += testCreateRoomButton_Click;
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

        private Button loginButton;
        private TextBox userNameTextBox;
        private Label label1;
        private Panel loginPanel;
        private Panel roomsListPanel;
        private Button createRoomButton;
        private FlowLayoutPanel roomsListFlowLayout;
    }
}

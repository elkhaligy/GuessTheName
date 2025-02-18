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
            loginPanel = new Panel();
            label8 = new Label();
            roomCreationPanel = new Panel();
            confirmCreationButton = new Button();
            tryCategoriesComboBox = new ComboBox();
            tryRoomNameTextBox = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            roomsListPanel = new Panel();
            label4 = new Label();
            refreshRoomsButton = new Button();
            createRoomButton = new Button();
            roomsListFlowLayout = new FlowLayoutPanel();
            lobbyPanel = new Panel();
            guestNameLabel = new Label();
            ownerNameLabel = new Label();
            label2 = new Label();
            button1 = new Button();
            ReadyButton = new Button();
            StartGameButton = new Button();
            label6 = new Label();
            label3 = new Label();
            label5 = new Label();
            loginPanel.SuspendLayout();
            roomCreationPanel.SuspendLayout();
            roomsListPanel.SuspendLayout();
            lobbyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.LightCyan;
            loginButton.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginButton.ForeColor = SystemColors.ControlText;
            loginButton.Location = new Point(304, 247);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(188, 27);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userNameTextBox.Location = new Point(304, 217);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.PlaceholderText = "Enter the username";
            userNameTextBox.Size = new Size(188, 22);
            userNameTextBox.TabIndex = 1;
            userNameTextBox.KeyDown += userNameTextBox_KeyDown;
            // 
            // loginPanel
            // 
            loginPanel.Controls.Add(label8);
            loginPanel.Controls.Add(userNameTextBox);
            loginPanel.Controls.Add(loginButton);
            loginPanel.Location = new Point(12, 12);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(808, 494);
            loginPanel.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Lucida Fax", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(248, 19);
            label8.Name = "label8";
            label8.Size = new Size(321, 42);
            label8.TabIndex = 5;
            label8.Text = "Guess the Name";
            // 
            // roomCreationPanel
            // 
            roomCreationPanel.Controls.Add(confirmCreationButton);
            roomCreationPanel.Controls.Add(tryCategoriesComboBox);
            roomCreationPanel.Controls.Add(tryRoomNameTextBox);
            roomCreationPanel.Controls.Add(label1);
            roomCreationPanel.Controls.Add(panel1);
            roomCreationPanel.Location = new Point(12, 12);
            roomCreationPanel.Name = "roomCreationPanel";
            roomCreationPanel.Size = new Size(808, 494);
            roomCreationPanel.TabIndex = 6;
            roomCreationPanel.Visible = false;
            // 
            // confirmCreationButton
            // 
            confirmCreationButton.Location = new Point(331, 274);
            confirmCreationButton.Name = "confirmCreationButton";
            confirmCreationButton.Size = new Size(121, 23);
            confirmCreationButton.TabIndex = 3;
            confirmCreationButton.Text = "Confirm";
            confirmCreationButton.UseVisualStyleBackColor = true;
            confirmCreationButton.Click += confirmCreationButton_Click;
            // 
            // tryCategoriesComboBox
            // 
            tryCategoriesComboBox.FormattingEnabled = true;
            tryCategoriesComboBox.Location = new Point(331, 245);
            tryCategoriesComboBox.Name = "tryCategoriesComboBox";
            tryCategoriesComboBox.Size = new Size(121, 23);
            tryCategoriesComboBox.TabIndex = 2;
            // 
            // tryRoomNameTextBox
            // 
            tryRoomNameTextBox.Location = new Point(331, 216);
            tryRoomNameTextBox.Name = "tryRoomNameTextBox";
            tryRoomNameTextBox.PlaceholderText = "Enter Room Name";
            tryRoomNameTextBox.Size = new Size(121, 23);
            tryRoomNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(287, 162);
            label1.Name = "label1";
            label1.Size = new Size(230, 25);
            label1.TabIndex = 0;
            label1.Text = "Please Enter Room Details";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(248, 156);
            panel1.Name = "panel1";
            panel1.Size = new Size(292, 169);
            panel1.TabIndex = 4;
            // 
            // roomsListPanel
            // 
            roomsListPanel.Controls.Add(label4);
            roomsListPanel.Controls.Add(refreshRoomsButton);
            roomsListPanel.Controls.Add(createRoomButton);
            roomsListPanel.Controls.Add(roomsListFlowLayout);
            roomsListPanel.Location = new Point(15, 12);
            roomsListPanel.Name = "roomsListPanel";
            roomsListPanel.Size = new Size(805, 494);
            roomsListPanel.TabIndex = 5;
            roomsListPanel.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Fax", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 5);
            label4.Name = "label4";
            label4.Size = new Size(287, 37);
            label4.TabIndex = 3;
            label4.Text = "Available Rooms";
            // 
            // refreshRoomsButton
            // 
            refreshRoomsButton.BackColor = Color.LightCyan;
            refreshRoomsButton.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshRoomsButton.Location = new Point(693, 19);
            refreshRoomsButton.Name = "refreshRoomsButton";
            refreshRoomsButton.Size = new Size(90, 23);
            refreshRoomsButton.TabIndex = 2;
            refreshRoomsButton.Text = "Refresh";
            refreshRoomsButton.UseVisualStyleBackColor = false;
            refreshRoomsButton.Click += refreshRoomsButton_Click;
            // 
            // createRoomButton
            // 
            createRoomButton.BackColor = Color.LightCyan;
            createRoomButton.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createRoomButton.Location = new Point(693, 454);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(90, 23);
            createRoomButton.TabIndex = 1;
            createRoomButton.Text = "Create Room";
            createRoomButton.UseVisualStyleBackColor = false;
            createRoomButton.Click += CreateRoomButton_Click;
            // 
            // roomsListFlowLayout
            // 
            roomsListFlowLayout.AutoScroll = true;
            roomsListFlowLayout.BackColor = SystemColors.Control;
            roomsListFlowLayout.Location = new Point(17, 48);
            roomsListFlowLayout.Name = "roomsListFlowLayout";
            roomsListFlowLayout.Size = new Size(770, 400);
            roomsListFlowLayout.TabIndex = 0;
            // 
            // lobbyPanel
            // 
            lobbyPanel.Controls.Add(guestNameLabel);
            lobbyPanel.Controls.Add(ownerNameLabel);
            lobbyPanel.Controls.Add(label2);
            lobbyPanel.Controls.Add(ReadyButton);
            lobbyPanel.Controls.Add(StartGameButton);
            lobbyPanel.Controls.Add(label6);
            lobbyPanel.Controls.Add(label3);
            lobbyPanel.Controls.Add(label5);
            lobbyPanel.Location = new Point(12, 12);
            lobbyPanel.Name = "lobbyPanel";
            lobbyPanel.Size = new Size(808, 494);
            lobbyPanel.TabIndex = 6;
            lobbyPanel.Visible = false;
            // 
            // guestNameLabel
            // 
            guestNameLabel.AutoSize = true;
            guestNameLabel.Location = new Point(126, 156);
            guestNameLabel.Name = "guestNameLabel";
            guestNameLabel.Size = new Size(72, 15);
            guestNameLabel.TabIndex = 7;
            guestNameLabel.Text = "Guest Name";
            // 
            // ownerNameLabel
            // 
            ownerNameLabel.AutoSize = true;
            ownerNameLabel.Location = new Point(126, 132);
            ownerNameLabel.Name = "ownerNameLabel";
            ownerNameLabel.Size = new Size(77, 15);
            ownerNameLabel.TabIndex = 6;
            ownerNameLabel.Text = "Owner Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(275, 19);
            label2.Name = "label2";
            label2.Size = new Size(251, 42);
            label2.TabIndex = 5;
            label2.Text = "Lobby Room";
            // 
            // ReadyButton
            // 
            ReadyButton.Location = new Point(599, 412);
            ReadyButton.Name = "ReadyButton";
            ReadyButton.Size = new Size(91, 52);
            ReadyButton.TabIndex = 4;
            ReadyButton.Text = "Ready";
            ReadyButton.UseVisualStyleBackColor = true;
            // 
            // StartGameButton
            // 
            StartGameButton.Location = new Point(696, 412);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(91, 52);
            StartGameButton.TabIndex = 3;
            StartGameButton.Text = "Start Game";
            StartGameButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 156);
            label6.Name = "label6";
            label6.Size = new Size(98, 15);
            label6.TabIndex = 2;
            label6.Text = "Player 2 (Guest) : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 61);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 132);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 0;
            label5.Text = "Player 1 (Owner) :";
            // 
            // button1
            // 
            button1.Location = new Point(29, 188);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "Play";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ClientForm
            // 
            ClientSize = new Size(832, 518);
            Controls.Add(roomsListPanel);
            Controls.Add(roomCreationPanel);
            Controls.Add(loginPanel);
            Controls.Add(lobbyPanel);
            Controls.Add(button1);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Guess";
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            roomCreationPanel.ResumeLayout(false);
            roomCreationPanel.PerformLayout();
            roomsListPanel.ResumeLayout(false);
            roomsListPanel.PerformLayout();
            lobbyPanel.ResumeLayout(false);
            lobbyPanel.PerformLayout();
            ResumeLayout(false);



        }

        #endregion

        private Button loginButton;
        private TextBox userNameTextBox;
        private Panel loginPanel;
        private Panel roomsListPanel;
        private Button createRoomButton;
        private FlowLayoutPanel roomsListFlowLayout;
        private Button refreshRoomsButton;
        private Panel lobbyPanel;
        private Label label6;
        private Label label3;
        private Label label5;
        private Button StartGameButton;
        private Button ReadyButton;
        private Label guestNameLabel;
        private Label ownerNameLabel;
        private Label label2;
        private Label label4;
        private Label label8;
        private Panel roomCreationPanel;
        private Label label1;
        private TextBox tryRoomNameTextBox;
        private ComboBox tryCategoriesComboBox;
        private Button confirmCreationButton;
        private Panel panel1;
        private Button button1;
    }
}

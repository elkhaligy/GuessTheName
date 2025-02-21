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
            userNameTextBox = new TextBox();
            loginPanel = new Panel();
            logTextBox = new ReaLTaiizor.Controls.CrownTextBox();
            cyberTextBox1 = new ReaLTaiizor.Controls.CyberTextBox();
            dungeonButtonRight1 = new ReaLTaiizor.Controls.DungeonButtonRight();
            label8 = new Label();
            roomCreationPanel = new Panel();
            confirmCreationButton = new Button();
            tryCategoriesComboBox = new ComboBox();
            tryRoomNameTextBox = new TextBox();
            label1 = new Label();
            roomsListPanel = new Panel();
            label4 = new Label();
            refreshRoomsButton = new Button();
            createRoomButton = new Button();
            roomsListFlowLayout = new FlowLayoutPanel();
            lobbyPanel = new Panel();
            guestReadyCheckbox = new CheckBox();
            ownerReadyCheckbox = new CheckBox();
            guestNameLabel = new Label();
            ownerNameLabel = new Label();
            label2 = new Label();
            StartGameButton = new Button();
            panel1 = new Panel();
            label6 = new Label();
            label3 = new Label();
            label5 = new Label();
            loginPanel.SuspendLayout();
            roomCreationPanel.SuspendLayout();
            roomsListPanel.SuspendLayout();
            lobbyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // userNameTextBox
            // 
            userNameTextBox.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userNameTextBox.Location = new Point(142, 177);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.PlaceholderText = "Enter the username";
            userNameTextBox.Size = new Size(188, 22);
            userNameTextBox.TabIndex = 1;
            userNameTextBox.Visible = false;
            userNameTextBox.KeyDown += userNameTextBox_KeyDown;
            // 
            // loginPanel
            // 
            loginPanel.Controls.Add(logTextBox);
            loginPanel.Controls.Add(cyberTextBox1);
            loginPanel.Controls.Add(dungeonButtonRight1);
            loginPanel.Controls.Add(label8);
            loginPanel.Controls.Add(userNameTextBox);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(2, 36);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(828, 480);
            loginPanel.TabIndex = 5;
            // 
            // logTextBox
            // 
            logTextBox.BackColor = Color.FromArgb(69, 73, 74);
            //logTextBox.BorderStyle = BorderStyle.FixedSingle;
            logTextBox.ForeColor = Color.FromArgb(220, 220, 220);
            logTextBox.Location = new Point(36, 280);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.Size = new Size(738, 186);
            logTextBox.TabIndex = 11;
            // 
            // cyberTextBox1
            // 
            cyberTextBox1.Alpha = 20;
            cyberTextBox1.BackColor = Color.Transparent;
            cyberTextBox1.Background_WidthPen = 3F;
            cyberTextBox1.BackgroundPen = true;
            cyberTextBox1.ColorBackground = Color.FromArgb(37, 52, 68);
            cyberTextBox1.ColorBackground_Pen = Color.FromArgb(255, 128, 0);
            cyberTextBox1.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberTextBox1.ColorPen_1 = Color.FromArgb(29, 200, 238);
            cyberTextBox1.ColorPen_2 = Color.FromArgb(37, 52, 68);
            cyberTextBox1.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberTextBox1.Font = new Font("Arial", 8F);
            cyberTextBox1.ForeColor = Color.FromArgb(245, 245, 245);
            cyberTextBox1.Lighting = false;
            cyberTextBox1.LinearGradientPen = false;
            cyberTextBox1.Location = new Point(555, 187);
            cyberTextBox1.Name = "cyberTextBox1";
            cyberTextBox1.PenWidth = 15;
            cyberTextBox1.RGB = false;
            cyberTextBox1.Rounding = true;
            cyberTextBox1.RoundingInt = 25;
            cyberTextBox1.Size = new Size(168, 33);
            cyberTextBox1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberTextBox1.TabIndex = 9;
            cyberTextBox1.Tag = "Cyber";
            cyberTextBox1.TextButton = "";
            cyberTextBox1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberTextBox1.Timer_RGB = 300;
            // 
            // dungeonButtonRight1
            // 
            dungeonButtonRight1.BackColor = Color.Transparent;
            dungeonButtonRight1.BorderColor = Color.FromArgb(162, 120, 101);
            dungeonButtonRight1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dungeonButtonRight1.Image = null;
            dungeonButtonRight1.ImageAlign = ContentAlignment.MiddleLeft;
            dungeonButtonRight1.InactiveColorA = Color.FromArgb(253, 175, 143);
            dungeonButtonRight1.InactiveColorB = Color.FromArgb(244, 146, 106);
            dungeonButtonRight1.Location = new Point(555, 226);
            dungeonButtonRight1.Name = "dungeonButtonRight1";
            dungeonButtonRight1.PressedColorA = Color.FromArgb(244, 146, 106);
            dungeonButtonRight1.PressedColorB = Color.FromArgb(244, 146, 106);
            dungeonButtonRight1.PressedContourColorA = Color.FromArgb(162, 120, 101);
            dungeonButtonRight1.PressedContourColorB = Color.FromArgb(162, 120, 101);
            dungeonButtonRight1.Size = new Size(168, 30);
            dungeonButtonRight1.TabIndex = 8;
            dungeonButtonRight1.Text = "Login Now";
            dungeonButtonRight1.TextAlignment = StringAlignment.Center;
            dungeonButtonRight1.Click += loginButton_Click;
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
            label8.Visible = false;
            // 
            // roomCreationPanel
            // 
            roomCreationPanel.Controls.Add(confirmCreationButton);
            roomCreationPanel.Controls.Add(tryCategoriesComboBox);
            roomCreationPanel.Controls.Add(tryRoomNameTextBox);
            roomCreationPanel.Controls.Add(label1);
            roomCreationPanel.Dock = DockStyle.Fill;
            roomCreationPanel.Location = new Point(2, 36);
            roomCreationPanel.Name = "roomCreationPanel";
            roomCreationPanel.Size = new Size(828, 480);
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
            tryCategoriesComboBox.Size = new Size(121, 29);
            tryCategoriesComboBox.TabIndex = 2;
            // 
            // tryRoomNameTextBox
            // 
            tryRoomNameTextBox.Location = new Point(331, 216);
            tryRoomNameTextBox.Name = "tryRoomNameTextBox";
            tryRoomNameTextBox.PlaceholderText = "Enter Room Name";
            tryRoomNameTextBox.Size = new Size(121, 29);
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
            // roomsListPanel
            // 
            roomsListPanel.Controls.Add(label4);
            roomsListPanel.Controls.Add(refreshRoomsButton);
            roomsListPanel.Controls.Add(createRoomButton);
            roomsListPanel.Controls.Add(roomsListFlowLayout);
            roomsListPanel.Dock = DockStyle.Fill;
            roomsListPanel.Location = new Point(2, 36);
            roomsListPanel.Name = "roomsListPanel";
            roomsListPanel.Size = new Size(828, 480);
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
            roomsListFlowLayout.Location = new Point(47, 67);
            roomsListFlowLayout.Name = "roomsListFlowLayout";
            roomsListFlowLayout.Size = new Size(599, 301);
            roomsListFlowLayout.TabIndex = 0;
            // 
            // lobbyPanel
            // 
            lobbyPanel.Controls.Add(guestReadyCheckbox);
            lobbyPanel.Controls.Add(ownerReadyCheckbox);
            lobbyPanel.Controls.Add(guestNameLabel);
            lobbyPanel.Controls.Add(ownerNameLabel);
            lobbyPanel.Controls.Add(label2);
            lobbyPanel.Controls.Add(StartGameButton);
            lobbyPanel.Controls.Add(panel1);
            lobbyPanel.Controls.Add(label6);
            lobbyPanel.Controls.Add(label3);
            lobbyPanel.Controls.Add(label5);
            lobbyPanel.Dock = DockStyle.Fill;
            lobbyPanel.Location = new Point(2, 36);
            lobbyPanel.Name = "lobbyPanel";
            lobbyPanel.Size = new Size(828, 480);
            lobbyPanel.TabIndex = 6;
            lobbyPanel.Visible = false;
            // 
            // guestReadyCheckbox
            // 
            guestReadyCheckbox.AutoSize = true;
            guestReadyCheckbox.Location = new Point(209, 157);
            guestReadyCheckbox.Name = "guestReadyCheckbox";
            guestReadyCheckbox.Size = new Size(72, 25);
            guestReadyCheckbox.TabIndex = 9;
            guestReadyCheckbox.Text = "Ready";
            guestReadyCheckbox.UseVisualStyleBackColor = true;
            guestReadyCheckbox.Click += ReadyButton_Click;
            // 
            // ownerReadyCheckbox
            // 
            ownerReadyCheckbox.AutoSize = true;
            ownerReadyCheckbox.Location = new Point(209, 132);
            ownerReadyCheckbox.Name = "ownerReadyCheckbox";
            ownerReadyCheckbox.Size = new Size(72, 25);
            ownerReadyCheckbox.TabIndex = 8;
            ownerReadyCheckbox.Text = "Ready";
            ownerReadyCheckbox.UseVisualStyleBackColor = true;
            ownerReadyCheckbox.Click += ReadyButton_Click;
            // 
            // guestNameLabel
            // 
            guestNameLabel.AutoSize = true;
            guestNameLabel.Location = new Point(126, 156);
            guestNameLabel.Name = "guestNameLabel";
            guestNameLabel.Size = new Size(103, 21);
            guestNameLabel.TabIndex = 7;
            guestNameLabel.Text = "Not Available";
            // 
            // ownerNameLabel
            // 
            ownerNameLabel.AutoSize = true;
            ownerNameLabel.Location = new Point(126, 132);
            ownerNameLabel.Name = "ownerNameLabel";
            ownerNameLabel.Size = new Size(103, 21);
            ownerNameLabel.TabIndex = 6;
            ownerNameLabel.Text = "Not Available";
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
            // StartGameButton
            // 
            StartGameButton.Location = new Point(696, 412);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(91, 52);
            StartGameButton.TabIndex = 3;
            StartGameButton.Text = "Start Game";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(349, 132);
            panel1.Name = "panel1";
            panel1.Size = new Size(292, 169);
            panel1.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 156);
            label6.Name = "label6";
            label6.Size = new Size(131, 21);
            label6.TabIndex = 2;
            label6.Text = "Player 2 (Guest) : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 61);
            label3.Name = "label3";
            label3.Size = new Size(0, 21);
            label3.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 132);
            label5.Name = "label5";
            label5.Size = new Size(134, 21);
            label5.TabIndex = 0;
            label5.Text = "Player 1 (Owner) :";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            ClientSize = new Size(832, 518);
            Controls.Add(loginPanel);
            Controls.Add(roomsListPanel);
            Controls.Add(roomCreationPanel);
            Controls.Add(lobbyPanel);
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
        private CheckBox guestReadyCheckbox;
        private CheckBox ownerReadyCheckbox;
        private ReaLTaiizor.Controls.DungeonButtonRight dungeonButtonRight1;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox1;
        private ReaLTaiizor.Controls.CrownTextBox logTextBox;
    }
}

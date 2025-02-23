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
            label15 = new Label();
            label8 = new Label();
            roomCreationPanel = new Panel();
            panel1 = new Panel();
            tryCategoriesComboBox = new ComboBox();
            confirmCreationButton = new Button();
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
            label6 = new Label();
            label3 = new Label();
            label5 = new Label();
            gamePanel = new Panel();
            turnLabel = new Label();
            label16 = new Label();
            label13 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            oBtn = new Button();
            pBtn = new Button();
            eBtn = new Button();
            rBtn = new Button();
            tBtn = new Button();
            yBtn = new Button();
            uBtn = new Button();
            iBtn = new Button();
            dBtn = new Button();
            fBtn = new Button();
            gBtn = new Button();
            hBtn = new Button();
            qBtn = new Button();
            kBtn = new Button();
            lBtn = new Button();
            jBtn = new Button();
            wBtn = new Button();
            sBtn = new Button();
            xBtn = new Button();
            zBtn = new Button();
            aBtn = new Button();
            bBtn = new Button();
            vBtn = new Button();
            cBtn = new Button();
            nBtn = new Button();
            mBtn = new Button();
            winOrLosePanel = new Panel();
            conrgatOrSorryLabel = new Label();
            button2 = new Button();
            button1 = new Button();
            playAgainLabel = new Label();
            winOrLoseLabel = new Label();
            loginPanel.SuspendLayout();
            roomCreationPanel.SuspendLayout();
            panel1.SuspendLayout();
            roomsListPanel.SuspendLayout();
            lobbyPanel.SuspendLayout();
            gamePanel.SuspendLayout();
            winOrLosePanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = SystemColors.ActiveCaptionText;
            loginButton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginButton.ForeColor = SystemColors.ButtonFace;
            loginButton.Location = new Point(552, 283);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(147, 54);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // userNameTextBox
            // 
            userNameTextBox.BackColor = SystemColors.InfoText;
            userNameTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userNameTextBox.ForeColor = SystemColors.Menu;
            userNameTextBox.Location = new Point(508, 235);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.PlaceholderText = "Enter the username";
            userNameTextBox.Size = new Size(238, 35);
            userNameTextBox.TabIndex = 1;
            userNameTextBox.KeyDown += userNameTextBox_KeyDown;
            // 
            // loginPanel
            // 
            loginPanel.BackColor = SystemColors.ActiveCaptionText;
            loginPanel.BackgroundImage = Properties.Resources.cool_ninja_j6vpsoa55v0q9l16;
            loginPanel.BackgroundImageLayout = ImageLayout.Stretch;
            loginPanel.Controls.Add(label15);
            loginPanel.Controls.Add(label8);
            loginPanel.Controls.Add(userNameTextBox);
            loginPanel.Controls.Add(loginButton);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(788, 474);
            loginPanel.TabIndex = 5;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ActiveCaptionText;
            label15.Location = new Point(69, 132);
            label15.Name = "label15";
            label15.Size = new Size(287, 64);
            label15.TabIndex = 6;
            label15.Text = "Play Now!";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(-5, 9);
            label8.Name = "label8";
            label8.Size = new Size(527, 108);
            label8.TabIndex = 5;
            label8.Text = "Word Ninja";
            // 
            // roomCreationPanel
            // 
            roomCreationPanel.BackColor = SystemColors.ActiveCaptionText;
            roomCreationPanel.Controls.Add(panel1);
            roomCreationPanel.Dock = DockStyle.Fill;
            roomCreationPanel.Location = new Point(0, 0);
            roomCreationPanel.Name = "roomCreationPanel";
            roomCreationPanel.Size = new Size(788, 474);
            roomCreationPanel.TabIndex = 6;
            roomCreationPanel.Visible = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tryCategoriesComboBox);
            panel1.Controls.Add(confirmCreationButton);
            panel1.Controls.Add(tryRoomNameTextBox);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(151, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(475, 302);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // tryCategoriesComboBox
            // 
            tryCategoriesComboBox.BackColor = SystemColors.ActiveCaptionText;
            tryCategoriesComboBox.Font = new Font("Segoe UI", 11.25F);
            tryCategoriesComboBox.ForeColor = SystemColors.ButtonHighlight;
            tryCategoriesComboBox.FormattingEnabled = true;
            tryCategoriesComboBox.Location = new Point(88, 156);
            tryCategoriesComboBox.Name = "tryCategoriesComboBox";
            tryCategoriesComboBox.Size = new Size(315, 39);
            tryCategoriesComboBox.TabIndex = 2;
            // 
            // confirmCreationButton
            // 
            confirmCreationButton.BackColor = SystemColors.ActiveCaptionText;
            confirmCreationButton.Font = new Font("Segoe UI", 11.25F);
            confirmCreationButton.ForeColor = SystemColors.ButtonHighlight;
            confirmCreationButton.Location = new Point(148, 226);
            confirmCreationButton.Name = "confirmCreationButton";
            confirmCreationButton.Size = new Size(190, 42);
            confirmCreationButton.TabIndex = 3;
            confirmCreationButton.Text = "Confirm";
            confirmCreationButton.UseVisualStyleBackColor = false;
            confirmCreationButton.Click += confirmCreationButton_Click;
            // 
            // tryRoomNameTextBox
            // 
            tryRoomNameTextBox.BackColor = SystemColors.ActiveCaptionText;
            tryRoomNameTextBox.Font = new Font("Segoe UI", 11.25F);
            tryRoomNameTextBox.ForeColor = SystemColors.ButtonHighlight;
            tryRoomNameTextBox.Location = new Point(88, 97);
            tryRoomNameTextBox.Name = "tryRoomNameTextBox";
            tryRoomNameTextBox.PlaceholderText = "Enter Room Name";
            tryRoomNameTextBox.Size = new Size(315, 37);
            tryRoomNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(27, 20);
            label1.Name = "label1";
            label1.Size = new Size(431, 52);
            label1.TabIndex = 0;
            label1.Text = "Enter Room's Details";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // roomsListPanel
            // 
            roomsListPanel.BackColor = SystemColors.ActiveCaptionText;
            roomsListPanel.Controls.Add(label4);
            roomsListPanel.Controls.Add(refreshRoomsButton);
            roomsListPanel.Controls.Add(createRoomButton);
            roomsListPanel.Controls.Add(roomsListFlowLayout);
            roomsListPanel.Dock = DockStyle.Fill;
            roomsListPanel.Location = new Point(0, 0);
            roomsListPanel.Name = "roomsListPanel";
            roomsListPanel.Size = new Size(788, 474);
            roomsListPanel.TabIndex = 5;
            roomsListPanel.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(313, 9);
            label4.Name = "label4";
            label4.Size = new Size(177, 55);
            label4.TabIndex = 3;
            label4.Text = "Rooms";
            // 
            // refreshRoomsButton
            // 
            refreshRoomsButton.BackColor = SystemColors.ActiveCaptionText;
            refreshRoomsButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshRoomsButton.ForeColor = SystemColors.ControlLightLight;
            refreshRoomsButton.Location = new Point(497, 421);
            refreshRoomsButton.Name = "refreshRoomsButton";
            refreshRoomsButton.Size = new Size(102, 41);
            refreshRoomsButton.TabIndex = 2;
            refreshRoomsButton.Text = "Refresh";
            refreshRoomsButton.UseVisualStyleBackColor = false;
            refreshRoomsButton.Click += refreshRoomsButton_Click;
            // 
            // createRoomButton
            // 
            createRoomButton.BackColor = SystemColors.ActiveCaptionText;
            createRoomButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createRoomButton.ForeColor = SystemColors.Control;
            createRoomButton.Location = new Point(624, 421);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(102, 41);
            createRoomButton.TabIndex = 1;
            createRoomButton.Text = "Create";
            createRoomButton.UseVisualStyleBackColor = false;
            createRoomButton.Click += CreateRoomButton_Click;
            // 
            // roomsListFlowLayout
            // 
            roomsListFlowLayout.AutoScroll = true;
            roomsListFlowLayout.BackColor = SystemColors.ActiveCaptionText;
            roomsListFlowLayout.Location = new Point(50, 76);
            roomsListFlowLayout.Name = "roomsListFlowLayout";
            roomsListFlowLayout.Size = new Size(676, 317);
            roomsListFlowLayout.TabIndex = 0;
            // 
            // lobbyPanel
            // 
            lobbyPanel.BackColor = SystemColors.ActiveCaptionText;
            lobbyPanel.Controls.Add(guestReadyCheckbox);
            lobbyPanel.Controls.Add(ownerReadyCheckbox);
            lobbyPanel.Controls.Add(guestNameLabel);
            lobbyPanel.Controls.Add(ownerNameLabel);
            lobbyPanel.Controls.Add(label2);
            lobbyPanel.Controls.Add(StartGameButton);
            lobbyPanel.Controls.Add(label6);
            lobbyPanel.Controls.Add(label3);
            lobbyPanel.Controls.Add(label5);
            lobbyPanel.Dock = DockStyle.Fill;
            lobbyPanel.Location = new Point(0, 0);
            lobbyPanel.Name = "lobbyPanel";
            lobbyPanel.Size = new Size(788, 474);
            lobbyPanel.TabIndex = 6;
            lobbyPanel.Visible = false;
            // 
            // guestReadyCheckbox
            // 
            guestReadyCheckbox.AutoSize = true;
            guestReadyCheckbox.BackColor = Color.Transparent;
            guestReadyCheckbox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guestReadyCheckbox.ForeColor = SystemColors.ButtonFace;
            guestReadyCheckbox.Location = new Point(570, 233);
            guestReadyCheckbox.Name = "guestReadyCheckbox";
            guestReadyCheckbox.Size = new Size(142, 52);
            guestReadyCheckbox.TabIndex = 9;
            guestReadyCheckbox.Text = "Ready";
            guestReadyCheckbox.UseVisualStyleBackColor = false;
            guestReadyCheckbox.Click += ReadyButton_Click;
            // 
            // ownerReadyCheckbox
            // 
            ownerReadyCheckbox.AutoSize = true;
            ownerReadyCheckbox.BackColor = Color.Transparent;
            ownerReadyCheckbox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ownerReadyCheckbox.ForeColor = SystemColors.ButtonFace;
            ownerReadyCheckbox.Location = new Point(570, 159);
            ownerReadyCheckbox.Name = "ownerReadyCheckbox";
            ownerReadyCheckbox.Size = new Size(142, 52);
            ownerReadyCheckbox.TabIndex = 8;
            ownerReadyCheckbox.Text = "Ready";
            ownerReadyCheckbox.UseVisualStyleBackColor = false;
            ownerReadyCheckbox.Click += ReadyButton_Click;
            // 
            // guestNameLabel
            // 
            guestNameLabel.AutoSize = true;
            guestNameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guestNameLabel.ForeColor = Color.Gold;
            guestNameLabel.Location = new Point(313, 233);
            guestNameLabel.Name = "guestNameLabel";
            guestNameLabel.Size = new Size(232, 48);
            guestNameLabel.TabIndex = 7;
            guestNameLabel.Text = "Not Available";
            // 
            // ownerNameLabel
            // 
            ownerNameLabel.AutoSize = true;
            ownerNameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ownerNameLabel.ForeColor = Color.Gold;
            ownerNameLabel.Location = new Point(309, 160);
            ownerNameLabel.Name = "ownerNameLabel";
            ownerNameLabel.Size = new Size(232, 48);
            ownerNameLabel.TabIndex = 6;
            ownerNameLabel.Text = "Not Available";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(219, 29);
            label2.Name = "label2";
            label2.Size = new Size(343, 64);
            label2.TabIndex = 5;
            label2.Text = "Lobby Room";
            // 
            // StartGameButton
            // 
            StartGameButton.BackColor = SystemColors.ActiveCaptionText;
            StartGameButton.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartGameButton.ForeColor = SystemColors.ButtonFace;
            StartGameButton.Location = new Point(313, 317);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(153, 117);
            StartGameButton.TabIndex = 3;
            StartGameButton.Text = "Start Game";
            StartGameButton.UseVisualStyleBackColor = false;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(20, 233);
            label6.Name = "label6";
            label6.Size = new Size(306, 48);
            label6.TabIndex = 2;
            label6.Text = "Player 2 (Guest)  : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 61);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(20, 159);
            label5.Name = "label5";
            label5.Size = new Size(300, 48);
            label5.TabIndex = 0;
            label5.Text = "Player 1 (Owner) :";
            // 
            // gamePanel
            // 
            gamePanel.BackColor = SystemColors.ActiveCaptionText;
            gamePanel.BackgroundImageLayout = ImageLayout.Stretch;
            gamePanel.Controls.Add(turnLabel);
            gamePanel.Controls.Add(label16);
            gamePanel.Controls.Add(label13);
            gamePanel.Controls.Add(label11);
            gamePanel.Controls.Add(label10);
            gamePanel.Controls.Add(label9);
            gamePanel.Controls.Add(label7);
            gamePanel.Controls.Add(oBtn);
            gamePanel.Controls.Add(pBtn);
            gamePanel.Controls.Add(eBtn);
            gamePanel.Controls.Add(rBtn);
            gamePanel.Controls.Add(tBtn);
            gamePanel.Controls.Add(yBtn);
            gamePanel.Controls.Add(uBtn);
            gamePanel.Controls.Add(iBtn);
            gamePanel.Controls.Add(dBtn);
            gamePanel.Controls.Add(fBtn);
            gamePanel.Controls.Add(gBtn);
            gamePanel.Controls.Add(hBtn);
            gamePanel.Controls.Add(qBtn);
            gamePanel.Controls.Add(kBtn);
            gamePanel.Controls.Add(lBtn);
            gamePanel.Controls.Add(jBtn);
            gamePanel.Controls.Add(wBtn);
            gamePanel.Controls.Add(sBtn);
            gamePanel.Controls.Add(xBtn);
            gamePanel.Controls.Add(zBtn);
            gamePanel.Controls.Add(aBtn);
            gamePanel.Controls.Add(bBtn);
            gamePanel.Controls.Add(vBtn);
            gamePanel.Controls.Add(cBtn);
            gamePanel.Controls.Add(nBtn);
            gamePanel.Controls.Add(mBtn);
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.Location = new Point(0, 0);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(788, 474);
            gamePanel.TabIndex = 10;
            gamePanel.Visible = false;
            // 
            // turnLabel
            // 
            turnLabel.AutoSize = true;
            turnLabel.Font = new Font("Segoe UI Black", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            turnLabel.ForeColor = SystemColors.Control;
            turnLabel.Location = new Point(468, 64);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new Size(244, 60);
            turnLabel.TabIndex = 113;
            turnLabel.Text = "Your Turn";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Black;
            label16.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Chocolate;
            label16.Location = new Point(442, 9);
            label16.Name = "label16";
            label16.Size = new Size(110, 40);
            label16.TabIndex = 112;
            label16.Text = "label16";
            label16.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Black;
            label13.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Chocolate;
            label13.Location = new Point(556, 9);
            label13.Name = "label13";
            label13.Size = new Size(110, 40);
            label13.TabIndex = 109;
            label13.Text = "label13";
            label13.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Black;
            label11.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.LimeGreen;
            label11.Location = new Point(118, 33);
            label11.Name = "label11";
            label11.Size = new Size(176, 60);
            label11.TabIndex = 107;
            label11.Text = "label11";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Black;
            label10.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(118, 97);
            label10.Name = "label10";
            label10.Size = new Size(176, 60);
            label10.TabIndex = 106;
            label10.Text = "label10";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Black;
            label9.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(50, 93);
            label9.Name = "label9";
            label9.Size = new Size(92, 60);
            label9.TabIndex = 105;
            label9.Text = "Vs: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Black;
            label7.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(32, 33);
            label7.Name = "label7";
            label7.Size = new Size(110, 60);
            label7.TabIndex = 104;
            label7.Text = "Me: ";
            // 
            // oBtn
            // 
            oBtn.BackColor = SystemColors.ActiveCaptionText;
            oBtn.ForeColor = SystemColors.ControlLightLight;
            oBtn.Location = new Point(601, 294);
            oBtn.Margin = new Padding(3, 2, 3, 2);
            oBtn.Name = "oBtn";
            oBtn.Size = new Size(54, 34);
            oBtn.TabIndex = 103;
            oBtn.Text = "O";
            oBtn.UseVisualStyleBackColor = false;
            oBtn.Click += keyClicked;
            // 
            // pBtn
            // 
            pBtn.BackColor = SystemColors.ActiveCaptionText;
            pBtn.ForeColor = SystemColors.ControlLightLight;
            pBtn.Location = new Point(668, 294);
            pBtn.Margin = new Padding(3, 2, 3, 2);
            pBtn.Name = "pBtn";
            pBtn.Size = new Size(54, 34);
            pBtn.TabIndex = 102;
            pBtn.Text = "P";
            pBtn.UseVisualStyleBackColor = false;
            pBtn.Click += keyClicked;
            // 
            // eBtn
            // 
            eBtn.BackColor = SystemColors.ActiveCaptionText;
            eBtn.ForeColor = SystemColors.ControlLightLight;
            eBtn.Location = new Point(202, 294);
            eBtn.Margin = new Padding(3, 2, 3, 2);
            eBtn.Name = "eBtn";
            eBtn.Size = new Size(54, 34);
            eBtn.TabIndex = 101;
            eBtn.Text = "E";
            eBtn.UseVisualStyleBackColor = false;
            eBtn.Click += keyClicked;
            // 
            // rBtn
            // 
            rBtn.BackColor = SystemColors.ActiveCaptionText;
            rBtn.ForeColor = SystemColors.ControlLightLight;
            rBtn.Location = new Point(268, 294);
            rBtn.Margin = new Padding(3, 2, 3, 2);
            rBtn.Name = "rBtn";
            rBtn.Size = new Size(54, 34);
            rBtn.TabIndex = 100;
            rBtn.Text = "R";
            rBtn.UseVisualStyleBackColor = false;
            rBtn.Click += keyClicked;
            // 
            // tBtn
            // 
            tBtn.BackColor = SystemColors.ActiveCaptionText;
            tBtn.ForeColor = SystemColors.ControlLightLight;
            tBtn.Location = new Point(335, 294);
            tBtn.Margin = new Padding(3, 2, 3, 2);
            tBtn.Name = "tBtn";
            tBtn.Size = new Size(54, 34);
            tBtn.TabIndex = 99;
            tBtn.Text = "T";
            tBtn.UseVisualStyleBackColor = false;
            tBtn.Click += keyClicked;
            // 
            // yBtn
            // 
            yBtn.BackColor = SystemColors.ActiveCaptionText;
            yBtn.ForeColor = SystemColors.ControlLightLight;
            yBtn.Location = new Point(402, 294);
            yBtn.Margin = new Padding(3, 2, 3, 2);
            yBtn.Name = "yBtn";
            yBtn.Size = new Size(54, 34);
            yBtn.TabIndex = 98;
            yBtn.Text = "Y";
            yBtn.UseVisualStyleBackColor = false;
            yBtn.Click += keyClicked;
            // 
            // uBtn
            // 
            uBtn.BackColor = SystemColors.ActiveCaptionText;
            uBtn.ForeColor = SystemColors.ControlLightLight;
            uBtn.Location = new Point(468, 294);
            uBtn.Margin = new Padding(3, 2, 3, 2);
            uBtn.Name = "uBtn";
            uBtn.Size = new Size(54, 34);
            uBtn.TabIndex = 97;
            uBtn.Text = "U";
            uBtn.UseVisualStyleBackColor = false;
            uBtn.Click += keyClicked;
            // 
            // iBtn
            // 
            iBtn.BackColor = SystemColors.ActiveCaptionText;
            iBtn.ForeColor = SystemColors.ControlLightLight;
            iBtn.Location = new Point(534, 294);
            iBtn.Margin = new Padding(3, 2, 3, 2);
            iBtn.Name = "iBtn";
            iBtn.Size = new Size(54, 34);
            iBtn.TabIndex = 96;
            iBtn.Text = "I";
            iBtn.UseVisualStyleBackColor = false;
            iBtn.Click += keyClicked;
            // 
            // dBtn
            // 
            dBtn.BackColor = SystemColors.ActiveCaptionText;
            dBtn.ForeColor = SystemColors.ControlLightLight;
            dBtn.Location = new Point(235, 346);
            dBtn.Margin = new Padding(3, 2, 3, 2);
            dBtn.Name = "dBtn";
            dBtn.Size = new Size(54, 34);
            dBtn.TabIndex = 95;
            dBtn.Text = "D";
            dBtn.UseVisualStyleBackColor = false;
            dBtn.Click += keyClicked;
            // 
            // fBtn
            // 
            fBtn.BackColor = SystemColors.ActiveCaptionText;
            fBtn.ForeColor = SystemColors.ControlLightLight;
            fBtn.Location = new Point(304, 346);
            fBtn.Margin = new Padding(3, 2, 3, 2);
            fBtn.Name = "fBtn";
            fBtn.Size = new Size(54, 34);
            fBtn.TabIndex = 94;
            fBtn.Text = "F";
            fBtn.UseVisualStyleBackColor = false;
            fBtn.Click += keyClicked;
            // 
            // gBtn
            // 
            gBtn.BackColor = SystemColors.ActiveCaptionText;
            gBtn.ForeColor = SystemColors.ControlLightLight;
            gBtn.Location = new Point(372, 346);
            gBtn.Margin = new Padding(3, 2, 3, 2);
            gBtn.Name = "gBtn";
            gBtn.Size = new Size(54, 34);
            gBtn.TabIndex = 93;
            gBtn.Text = "G";
            gBtn.UseVisualStyleBackColor = false;
            gBtn.Click += keyClicked;
            // 
            // hBtn
            // 
            hBtn.BackColor = SystemColors.ActiveCaptionText;
            hBtn.ForeColor = SystemColors.ControlLightLight;
            hBtn.Location = new Point(440, 346);
            hBtn.Margin = new Padding(3, 2, 3, 2);
            hBtn.Name = "hBtn";
            hBtn.Size = new Size(54, 34);
            hBtn.TabIndex = 92;
            hBtn.Text = "H";
            hBtn.UseVisualStyleBackColor = false;
            hBtn.Click += keyClicked;
            // 
            // qBtn
            // 
            qBtn.BackColor = SystemColors.ActiveCaptionText;
            qBtn.ForeColor = SystemColors.ControlLightLight;
            qBtn.Location = new Point(69, 294);
            qBtn.Margin = new Padding(3, 2, 3, 2);
            qBtn.Name = "qBtn";
            qBtn.Size = new Size(54, 34);
            qBtn.TabIndex = 91;
            qBtn.Text = "Q";
            qBtn.UseVisualStyleBackColor = false;
            qBtn.Click += keyClicked;
            // 
            // kBtn
            // 
            kBtn.BackColor = SystemColors.ActiveCaptionText;
            kBtn.ForeColor = SystemColors.ControlLightLight;
            kBtn.Location = new Point(576, 346);
            kBtn.Margin = new Padding(3, 2, 3, 2);
            kBtn.Name = "kBtn";
            kBtn.Size = new Size(54, 34);
            kBtn.TabIndex = 90;
            kBtn.Text = "K";
            kBtn.UseVisualStyleBackColor = false;
            kBtn.Click += keyClicked;
            // 
            // lBtn
            // 
            lBtn.BackColor = SystemColors.ActiveCaptionText;
            lBtn.ForeColor = SystemColors.ControlLightLight;
            lBtn.Location = new Point(645, 346);
            lBtn.Margin = new Padding(3, 2, 3, 2);
            lBtn.Name = "lBtn";
            lBtn.Size = new Size(54, 34);
            lBtn.TabIndex = 89;
            lBtn.Text = "L";
            lBtn.UseVisualStyleBackColor = false;
            lBtn.Click += keyClicked;
            // 
            // jBtn
            // 
            jBtn.BackColor = SystemColors.ActiveCaptionText;
            jBtn.ForeColor = SystemColors.ControlLightLight;
            jBtn.Location = new Point(508, 346);
            jBtn.Margin = new Padding(3, 2, 3, 2);
            jBtn.Name = "jBtn";
            jBtn.Size = new Size(54, 34);
            jBtn.TabIndex = 88;
            jBtn.Text = "J";
            jBtn.UseVisualStyleBackColor = false;
            jBtn.Click += keyClicked;
            // 
            // wBtn
            // 
            wBtn.BackColor = SystemColors.ActiveCaptionText;
            wBtn.ForeColor = SystemColors.ControlLightLight;
            wBtn.Location = new Point(136, 294);
            wBtn.Margin = new Padding(3, 2, 3, 2);
            wBtn.Name = "wBtn";
            wBtn.Size = new Size(54, 34);
            wBtn.TabIndex = 87;
            wBtn.Text = "W";
            wBtn.UseVisualStyleBackColor = false;
            wBtn.Click += keyClicked;
            // 
            // sBtn
            // 
            sBtn.BackColor = SystemColors.ActiveCaptionText;
            sBtn.ForeColor = SystemColors.ControlLightLight;
            sBtn.Location = new Point(167, 346);
            sBtn.Margin = new Padding(3, 2, 3, 2);
            sBtn.Name = "sBtn";
            sBtn.Size = new Size(54, 34);
            sBtn.TabIndex = 86;
            sBtn.Text = "S";
            sBtn.UseVisualStyleBackColor = false;
            sBtn.Click += keyClicked;
            // 
            // xBtn
            // 
            xBtn.BackColor = SystemColors.ActiveCaptionText;
            xBtn.ForeColor = SystemColors.ControlLightLight;
            xBtn.Location = new Point(219, 400);
            xBtn.Margin = new Padding(3, 2, 3, 2);
            xBtn.Name = "xBtn";
            xBtn.Size = new Size(54, 34);
            xBtn.TabIndex = 85;
            xBtn.Text = "X";
            xBtn.UseVisualStyleBackColor = false;
            xBtn.Click += keyClicked;
            // 
            // zBtn
            // 
            zBtn.BackColor = SystemColors.ActiveCaptionText;
            zBtn.ForeColor = SystemColors.ControlLightLight;
            zBtn.Location = new Point(143, 400);
            zBtn.Margin = new Padding(3, 2, 3, 2);
            zBtn.Name = "zBtn";
            zBtn.Size = new Size(54, 34);
            zBtn.TabIndex = 84;
            zBtn.Text = "Z";
            zBtn.UseVisualStyleBackColor = false;
            zBtn.Click += keyClicked;
            // 
            // aBtn
            // 
            aBtn.BackColor = SystemColors.ActiveCaptionText;
            aBtn.ForeColor = SystemColors.ControlLightLight;
            aBtn.Location = new Point(99, 346);
            aBtn.Margin = new Padding(3, 2, 3, 2);
            aBtn.Name = "aBtn";
            aBtn.Size = new Size(54, 34);
            aBtn.TabIndex = 83;
            aBtn.Text = "A";
            aBtn.UseVisualStyleBackColor = false;
            aBtn.Click += keyClicked;
            // 
            // bBtn
            // 
            bBtn.BackColor = SystemColors.ActiveCaptionText;
            bBtn.ForeColor = SystemColors.ControlLightLight;
            bBtn.Location = new Point(451, 400);
            bBtn.Margin = new Padding(3, 2, 3, 2);
            bBtn.Name = "bBtn";
            bBtn.Size = new Size(54, 34);
            bBtn.TabIndex = 82;
            bBtn.Text = "B";
            bBtn.UseVisualStyleBackColor = false;
            bBtn.Click += keyClicked;
            // 
            // vBtn
            // 
            vBtn.BackColor = SystemColors.ActiveCaptionText;
            vBtn.ForeColor = SystemColors.ControlLightLight;
            vBtn.Location = new Point(373, 400);
            vBtn.Margin = new Padding(3, 2, 3, 2);
            vBtn.Name = "vBtn";
            vBtn.Size = new Size(54, 34);
            vBtn.TabIndex = 81;
            vBtn.Text = "V";
            vBtn.UseVisualStyleBackColor = false;
            vBtn.Click += keyClicked;
            // 
            // cBtn
            // 
            cBtn.BackColor = SystemColors.ActiveCaptionText;
            cBtn.ForeColor = SystemColors.ControlLightLight;
            cBtn.Location = new Point(297, 400);
            cBtn.Margin = new Padding(3, 2, 3, 2);
            cBtn.Name = "cBtn";
            cBtn.Size = new Size(54, 34);
            cBtn.TabIndex = 80;
            cBtn.Text = "C";
            cBtn.UseVisualStyleBackColor = false;
            cBtn.Click += keyClicked;
            // 
            // nBtn
            // 
            nBtn.BackColor = SystemColors.ActiveCaptionText;
            nBtn.ForeColor = SystemColors.ControlLightLight;
            nBtn.Location = new Point(527, 400);
            nBtn.Margin = new Padding(3, 2, 3, 2);
            nBtn.Name = "nBtn";
            nBtn.Size = new Size(54, 34);
            nBtn.TabIndex = 79;
            nBtn.Text = "N";
            nBtn.UseVisualStyleBackColor = false;
            nBtn.Click += keyClicked;
            // 
            // mBtn
            // 
            mBtn.BackColor = SystemColors.ActiveCaptionText;
            mBtn.ForeColor = SystemColors.ControlLightLight;
            mBtn.Location = new Point(605, 400);
            mBtn.Margin = new Padding(3, 2, 3, 2);
            mBtn.Name = "mBtn";
            mBtn.Size = new Size(54, 34);
            mBtn.TabIndex = 78;
            mBtn.Text = "M";
            mBtn.UseVisualStyleBackColor = false;
            mBtn.Click += keyClicked;
            // 
            // winOrLosePanel
            // 
            winOrLosePanel.BackColor = SystemColors.ActiveCaptionText;
            winOrLosePanel.Controls.Add(conrgatOrSorryLabel);
            winOrLosePanel.Controls.Add(button2);
            winOrLosePanel.Controls.Add(button1);
            winOrLosePanel.Controls.Add(playAgainLabel);
            winOrLosePanel.Controls.Add(winOrLoseLabel);
            winOrLosePanel.Dock = DockStyle.Fill;
            winOrLosePanel.Location = new Point(0, 0);
            winOrLosePanel.Name = "winOrLosePanel";
            winOrLosePanel.Size = new Size(788, 474);
            winOrLosePanel.TabIndex = 113;
            winOrLosePanel.Visible = false;
            // 
            // conrgatOrSorryLabel
            // 
            conrgatOrSorryLabel.AutoSize = true;
            conrgatOrSorryLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            conrgatOrSorryLabel.ForeColor = SystemColors.Control;
            conrgatOrSorryLabel.Location = new Point(212, 94);
            conrgatOrSorryLabel.Name = "conrgatOrSorryLabel";
            conrgatOrSorryLabel.Size = new Size(370, 38);
            conrgatOrSorryLabel.TabIndex = 4;
            conrgatOrSorryLabel.Text = "Congratulations PlayerName";
            // 
            // button2
            // 
            button2.Location = new Point(404, 381);
            button2.Name = "button2";
            button2.Size = new Size(54, 34);
            button2.TabIndex = 3;
            button2.Text = "No";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(333, 381);
            button1.Name = "button1";
            button1.Size = new Size(52, 34);
            button1.TabIndex = 2;
            button1.Text = "Yes";
            button1.UseVisualStyleBackColor = true;
            // 
            // playAgainLabel
            // 
            playAgainLabel.AutoSize = true;
            playAgainLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playAgainLabel.ForeColor = SystemColors.ButtonHighlight;
            playAgainLabel.Location = new Point(228, 326);
            playAgainLabel.Name = "playAgainLabel";
            playAgainLabel.Size = new Size(354, 38);
            playAgainLabel.TabIndex = 1;
            playAgainLabel.Text = "Do you want to play again?";
            // 
            // winOrLoseLabel
            // 
            winOrLoseLabel.AutoSize = true;
            winOrLoseLabel.Font = new Font("Lucida Sans Unicode", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            winOrLoseLabel.ForeColor = Color.Green;
            winOrLoseLabel.Location = new Point(167, 138);
            winOrLoseLabel.Name = "winOrLoseLabel";
            winOrLoseLabel.Size = new Size(466, 116);
            winOrLoseLabel.TabIndex = 0;
            winOrLoseLabel.Text = "You Won";
            // 
            // ClientForm
            // 
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(788, 474);
            Controls.Add(gamePanel);
            Controls.Add(loginPanel);
            Controls.Add(lobbyPanel);
            Controls.Add(roomsListPanel);
            Controls.Add(winOrLosePanel);
            Controls.Add(roomCreationPanel);
            Name = "ClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Guess";
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            roomCreationPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            roomsListPanel.ResumeLayout(false);
            roomsListPanel.PerformLayout();
            lobbyPanel.ResumeLayout(false);
            lobbyPanel.PerformLayout();
            gamePanel.ResumeLayout(false);
            gamePanel.PerformLayout();
            winOrLosePanel.ResumeLayout(false);
            winOrLosePanel.PerformLayout();
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
        private Panel gamePanel;
        private Button oBtn;
        private Button pBtn;
        private Button eBtn;
        private Button rBtn;
        private Button tBtn;
        private Button yBtn;
        private Button uBtn;
        private Button iBtn;
        private Button dBtn;
        private Button fBtn;
        private Button gBtn;
        private Button hBtn;
        private Button qBtn;
        private Button kBtn;
        private Button lBtn;
        private Button jBtn;
        private Button wBtn;
        private Button sBtn;
        private Button xBtn;
        private Button zBtn;
        private Button aBtn;
        private Button bBtn;
        private Button vBtn;
        private Button cBtn;
        private Button nBtn;
        private Button mBtn;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label7;
        private Label label13;
        private Label label16;
        private Label label15;
        private Panel winOrLosePanel;
        private Label winOrLoseLabel;
        private Button button2;
        private Button button1;
        private Label playAgainLabel;
        private Label conrgatOrSorryLabel;
        private Label turnLabel;
    }
}

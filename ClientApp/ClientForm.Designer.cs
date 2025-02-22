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
            label13 = new Label();
            label12 = new Label();
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
            loginPanel.SuspendLayout();
            roomCreationPanel.SuspendLayout();
            roomsListPanel.SuspendLayout();
            lobbyPanel.SuspendLayout();
            gamePanel.SuspendLayout();
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
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(832, 518);
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
            roomCreationPanel.Dock = DockStyle.Fill;
            roomCreationPanel.Location = new Point(0, 0);
            roomCreationPanel.Name = "roomCreationPanel";
            roomCreationPanel.Size = new Size(832, 518);
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
            roomsListPanel.Dock = DockStyle.Fill;
            roomsListPanel.Location = new Point(0, 0);
            roomsListPanel.Name = "roomsListPanel";
            roomsListPanel.Size = new Size(832, 518);
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
            lobbyPanel.Size = new Size(832, 518);
            lobbyPanel.TabIndex = 6;
            lobbyPanel.Visible = false;
            // 
            // guestReadyCheckbox
            // 
            guestReadyCheckbox.AutoSize = true;
            guestReadyCheckbox.Location = new Point(209, 157);
            guestReadyCheckbox.Name = "guestReadyCheckbox";
            guestReadyCheckbox.Size = new Size(58, 19);
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
            ownerReadyCheckbox.Size = new Size(58, 19);
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
            guestNameLabel.Size = new Size(78, 15);
            guestNameLabel.TabIndex = 7;
            guestNameLabel.Text = "Not Available";
            // 
            // ownerNameLabel
            // 
            ownerNameLabel.AutoSize = true;
            ownerNameLabel.Location = new Point(126, 132);
            ownerNameLabel.Name = "ownerNameLabel";
            ownerNameLabel.Size = new Size(78, 15);
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
            // gamePanel
            // 
            gamePanel.Controls.Add(label13);
            gamePanel.Controls.Add(label12);
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
            gamePanel.Size = new Size(832, 518);
            gamePanel.TabIndex = 10;
            gamePanel.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(417, 30);
            label13.Name = "label13";
            label13.Size = new Size(44, 15);
            label13.TabIndex = 109;
            label13.Text = "label13";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(319, 30);
            label12.Name = "label12";
            label12.Size = new Size(90, 15);
            label12.TabIndex = 108;
            label12.Text = "Room Category";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(58, 48);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 107;
            label11.Text = "label11";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(58, 30);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 106;
            label10.Text = "label10";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(22, 48);
            label9.Name = "label9";
            label9.Size = new Size(25, 15);
            label9.TabIndex = 105;
            label9.Text = "Vs: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 27);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 104;
            label7.Text = "Me: ";
            // 
            // oBtn
            // 
            oBtn.Location = new Point(616, 324);
            oBtn.Margin = new Padding(3, 2, 3, 2);
            oBtn.Name = "oBtn";
            oBtn.Size = new Size(54, 34);
            oBtn.TabIndex = 103;
            oBtn.Text = "O";
            oBtn.UseVisualStyleBackColor = true;
            oBtn.Click += keyClicked;
            // 
            // pBtn
            // 
            pBtn.Location = new Point(683, 324);
            pBtn.Margin = new Padding(3, 2, 3, 2);
            pBtn.Name = "pBtn";
            pBtn.Size = new Size(54, 34);
            pBtn.TabIndex = 102;
            pBtn.Text = "P";
            pBtn.UseVisualStyleBackColor = true;
            pBtn.Click += keyClicked;
            // 
            // eBtn
            // 
            eBtn.Location = new Point(217, 324);
            eBtn.Margin = new Padding(3, 2, 3, 2);
            eBtn.Name = "eBtn";
            eBtn.Size = new Size(54, 34);
            eBtn.TabIndex = 101;
            eBtn.Text = "E";
            eBtn.UseVisualStyleBackColor = true;
            eBtn.Click += keyClicked;
            // 
            // rBtn
            // 
            rBtn.Location = new Point(283, 324);
            rBtn.Margin = new Padding(3, 2, 3, 2);
            rBtn.Name = "rBtn";
            rBtn.Size = new Size(54, 34);
            rBtn.TabIndex = 100;
            rBtn.Text = "R";
            rBtn.UseVisualStyleBackColor = true;
            rBtn.Click += keyClicked;
            // 
            // tBtn
            // 
            tBtn.Location = new Point(350, 324);
            tBtn.Margin = new Padding(3, 2, 3, 2);
            tBtn.Name = "tBtn";
            tBtn.Size = new Size(54, 34);
            tBtn.TabIndex = 99;
            tBtn.Text = "T";
            tBtn.UseVisualStyleBackColor = true;
            tBtn.Click += keyClicked;
            // 
            // yBtn
            // 
            yBtn.Location = new Point(417, 324);
            yBtn.Margin = new Padding(3, 2, 3, 2);
            yBtn.Name = "yBtn";
            yBtn.Size = new Size(54, 34);
            yBtn.TabIndex = 98;
            yBtn.Text = "Y";
            yBtn.UseVisualStyleBackColor = true;
            yBtn.Click += keyClicked;
            // 
            // uBtn
            // 
            uBtn.Location = new Point(483, 324);
            uBtn.Margin = new Padding(3, 2, 3, 2);
            uBtn.Name = "uBtn";
            uBtn.Size = new Size(54, 34);
            uBtn.TabIndex = 97;
            uBtn.Text = "U";
            uBtn.UseVisualStyleBackColor = true;
            uBtn.Click += keyClicked;
            // 
            // iBtn
            // 
            iBtn.Location = new Point(549, 324);
            iBtn.Margin = new Padding(3, 2, 3, 2);
            iBtn.Name = "iBtn";
            iBtn.Size = new Size(54, 34);
            iBtn.TabIndex = 96;
            iBtn.Text = "I";
            iBtn.UseVisualStyleBackColor = true;
            iBtn.Click += keyClicked;
            // 
            // dBtn
            // 
            dBtn.Location = new Point(250, 360);
            dBtn.Margin = new Padding(3, 2, 3, 2);
            dBtn.Name = "dBtn";
            dBtn.Size = new Size(54, 34);
            dBtn.TabIndex = 95;
            dBtn.Text = "D";
            dBtn.UseVisualStyleBackColor = true;
            dBtn.Click += keyClicked;
            // 
            // fBtn
            // 
            fBtn.Location = new Point(319, 360);
            fBtn.Margin = new Padding(3, 2, 3, 2);
            fBtn.Name = "fBtn";
            fBtn.Size = new Size(54, 34);
            fBtn.TabIndex = 94;
            fBtn.Text = "F";
            fBtn.UseVisualStyleBackColor = true;
            fBtn.Click += keyClicked;
            // 
            // gBtn
            // 
            gBtn.Location = new Point(387, 360);
            gBtn.Margin = new Padding(3, 2, 3, 2);
            gBtn.Name = "gBtn";
            gBtn.Size = new Size(54, 34);
            gBtn.TabIndex = 93;
            gBtn.Text = "G";
            gBtn.UseVisualStyleBackColor = true;
            gBtn.Click += keyClicked;
            // 
            // hBtn
            // 
            hBtn.Location = new Point(455, 360);
            hBtn.Margin = new Padding(3, 2, 3, 2);
            hBtn.Name = "hBtn";
            hBtn.Size = new Size(54, 34);
            hBtn.TabIndex = 92;
            hBtn.Text = "H";
            hBtn.UseVisualStyleBackColor = true;
            hBtn.Click += keyClicked;
            // 
            // qBtn
            // 
            qBtn.Location = new Point(84, 324);
            qBtn.Margin = new Padding(3, 2, 3, 2);
            qBtn.Name = "qBtn";
            qBtn.Size = new Size(54, 34);
            qBtn.TabIndex = 91;
            qBtn.Text = "Q";
            qBtn.UseVisualStyleBackColor = true;
            qBtn.Click += keyClicked;
            // 
            // kBtn
            // 
            kBtn.Location = new Point(591, 360);
            kBtn.Margin = new Padding(3, 2, 3, 2);
            kBtn.Name = "kBtn";
            kBtn.Size = new Size(54, 34);
            kBtn.TabIndex = 90;
            kBtn.Text = "K";
            kBtn.UseVisualStyleBackColor = true;
            kBtn.Click += keyClicked;
            // 
            // lBtn
            // 
            lBtn.Location = new Point(660, 360);
            lBtn.Margin = new Padding(3, 2, 3, 2);
            lBtn.Name = "lBtn";
            lBtn.Size = new Size(54, 34);
            lBtn.TabIndex = 89;
            lBtn.Text = "L";
            lBtn.UseVisualStyleBackColor = true;
            lBtn.Click += keyClicked;
            // 
            // jBtn
            // 
            jBtn.Location = new Point(523, 360);
            jBtn.Margin = new Padding(3, 2, 3, 2);
            jBtn.Name = "jBtn";
            jBtn.Size = new Size(54, 34);
            jBtn.TabIndex = 88;
            jBtn.Text = "J";
            jBtn.UseVisualStyleBackColor = true;
            jBtn.Click += keyClicked;
            // 
            // wBtn
            // 
            wBtn.Location = new Point(151, 324);
            wBtn.Margin = new Padding(3, 2, 3, 2);
            wBtn.Name = "wBtn";
            wBtn.Size = new Size(54, 34);
            wBtn.TabIndex = 87;
            wBtn.Text = "W";
            wBtn.UseVisualStyleBackColor = true;
            wBtn.Click += keyClicked;
            // 
            // sBtn
            // 
            sBtn.Location = new Point(182, 360);
            sBtn.Margin = new Padding(3, 2, 3, 2);
            sBtn.Name = "sBtn";
            sBtn.Size = new Size(54, 34);
            sBtn.TabIndex = 86;
            sBtn.Text = "S";
            sBtn.UseVisualStyleBackColor = true;
            sBtn.Click += keyClicked;
            // 
            // xBtn
            // 
            xBtn.Location = new Point(241, 400);
            xBtn.Margin = new Padding(3, 2, 3, 2);
            xBtn.Name = "xBtn";
            xBtn.Size = new Size(54, 34);
            xBtn.TabIndex = 85;
            xBtn.Text = "X";
            xBtn.UseVisualStyleBackColor = true;
            xBtn.Click += keyClicked;
            // 
            // zBtn
            // 
            zBtn.Location = new Point(165, 400);
            zBtn.Margin = new Padding(3, 2, 3, 2);
            zBtn.Name = "zBtn";
            zBtn.Size = new Size(54, 34);
            zBtn.TabIndex = 84;
            zBtn.Text = "Z";
            zBtn.UseVisualStyleBackColor = true;
            zBtn.Click += keyClicked;
            // 
            // aBtn
            // 
            aBtn.Location = new Point(114, 360);
            aBtn.Margin = new Padding(3, 2, 3, 2);
            aBtn.Name = "aBtn";
            aBtn.Size = new Size(54, 34);
            aBtn.TabIndex = 83;
            aBtn.Text = "A";
            aBtn.UseVisualStyleBackColor = true;
            aBtn.Click += keyClicked;
            // 
            // bBtn
            // 
            bBtn.Location = new Point(473, 400);
            bBtn.Margin = new Padding(3, 2, 3, 2);
            bBtn.Name = "bBtn";
            bBtn.Size = new Size(54, 34);
            bBtn.TabIndex = 82;
            bBtn.Text = "B";
            bBtn.UseVisualStyleBackColor = true;
            bBtn.Click += keyClicked;
            // 
            // vBtn
            // 
            vBtn.Location = new Point(395, 400);
            vBtn.Margin = new Padding(3, 2, 3, 2);
            vBtn.Name = "vBtn";
            vBtn.Size = new Size(54, 34);
            vBtn.TabIndex = 81;
            vBtn.Text = "V";
            vBtn.UseVisualStyleBackColor = true;
            vBtn.Click += keyClicked;
            // 
            // cBtn
            // 
            cBtn.Location = new Point(319, 400);
            cBtn.Margin = new Padding(3, 2, 3, 2);
            cBtn.Name = "cBtn";
            cBtn.Size = new Size(54, 34);
            cBtn.TabIndex = 80;
            cBtn.Text = "C";
            cBtn.UseVisualStyleBackColor = true;
            cBtn.Click += keyClicked;
            // 
            // nBtn
            // 
            nBtn.Location = new Point(549, 400);
            nBtn.Margin = new Padding(3, 2, 3, 2);
            nBtn.Name = "nBtn";
            nBtn.Size = new Size(54, 34);
            nBtn.TabIndex = 79;
            nBtn.Text = "N";
            nBtn.UseVisualStyleBackColor = true;
            nBtn.Click += keyClicked;
            // 
            // mBtn
            // 
            mBtn.Location = new Point(627, 400);
            mBtn.Margin = new Padding(3, 2, 3, 2);
            mBtn.Name = "mBtn";
            mBtn.Size = new Size(54, 34);
            mBtn.TabIndex = 78;
            mBtn.Text = "M";
            mBtn.UseVisualStyleBackColor = true;
            mBtn.Click += keyClicked;
            // 
            // ClientForm
            // 
            ClientSize = new Size(832, 518);
            Controls.Add(gamePanel);
            Controls.Add(lobbyPanel);
            Controls.Add(roomsListPanel);
            Controls.Add(roomCreationPanel);
            Controls.Add(loginPanel);
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
            gamePanel.ResumeLayout(false);
            gamePanel.PerformLayout();
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
        private Label label12;
    }
}

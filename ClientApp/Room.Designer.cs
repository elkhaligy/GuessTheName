namespace ClientApp
{
    partial class Room
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roomNameLabel = new Label();
            joinRoomButton = new Button();
            spectateRoomButton = new Button();
            roomCategoryLabel = new Label();
            playersInRoomListBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            roomOwnerLabel = new Label();
            SuspendLayout();
            // 
            // roomNameLabel
            // 
            roomNameLabel.AutoSize = true;
            roomNameLabel.BackColor = SystemColors.ActiveCaption;
            roomNameLabel.Cursor = Cursors.IBeam;
            roomNameLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roomNameLabel.ForeColor = SystemColors.ButtonHighlight;
            roomNameLabel.Location = new Point(69, 28);
            roomNameLabel.Name = "roomNameLabel";
            roomNameLabel.Size = new Size(115, 25);
            roomNameLabel.TabIndex = 0;
            roomNameLabel.Text = "Room Name";
            // 
            // joinRoomButton
            // 
            joinRoomButton.Location = new Point(554, 28);
            joinRoomButton.Name = "joinRoomButton";
            joinRoomButton.Size = new Size(80, 73);
            joinRoomButton.TabIndex = 1;
            joinRoomButton.Text = "Join";
            joinRoomButton.UseVisualStyleBackColor = true;
            joinRoomButton.Click += joinRoomButton_Click;
            // 
            // spectateRoomButton
            // 
            spectateRoomButton.Location = new Point(640, 28);
            spectateRoomButton.Name = "spectateRoomButton";
            spectateRoomButton.Size = new Size(80, 73);
            spectateRoomButton.TabIndex = 2;
            spectateRoomButton.Text = "Spectate";
            spectateRoomButton.UseVisualStyleBackColor = true;
            // 
            // roomCategoryLabel
            // 
            roomCategoryLabel.AutoSize = true;
            roomCategoryLabel.BackColor = SystemColors.ActiveCaption;
            roomCategoryLabel.Cursor = Cursors.IBeam;
            roomCategoryLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roomCategoryLabel.ForeColor = SystemColors.ButtonHighlight;
            roomCategoryLabel.Location = new Point(102, 78);
            roomCategoryLabel.Name = "roomCategoryLabel";
            roomCategoryLabel.Size = new Size(141, 25);
            roomCategoryLabel.TabIndex = 3;
            roomCategoryLabel.Text = "Room Category";
            // 
            // playersInRoomListBox
            // 
            playersInRoomListBox.BackColor = SystemColors.Control;
            playersInRoomListBox.FormattingEnabled = true;
            playersInRoomListBox.ItemHeight = 15;
            playersInRoomListBox.Location = new Point(386, 28);
            playersInRoomListBox.Name = "playersInRoomListBox";
            playersInRoomListBox.Size = new Size(117, 79);
            playersInRoomListBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Cursor = Cursors.IBeam;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(386, 4);
            label1.Name = "label1";
            label1.Size = new Size(117, 21);
            label1.TabIndex = 5;
            label1.Text = "Current Players";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(3, 53);
            label2.Name = "label2";
            label2.Size = new Size(77, 25);
            label2.TabIndex = 6;
            label2.Text = "Owner:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(3, 78);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 7;
            label3.Text = "Category: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(3, 28);
            label5.Name = "label5";
            label5.Size = new Size(69, 25);
            label5.TabIndex = 9;
            label5.Text = "Name:";
            // 
            // roomOwnerLabel
            // 
            roomOwnerLabel.AutoSize = true;
            roomOwnerLabel.BackColor = SystemColors.ActiveCaption;
            roomOwnerLabel.Cursor = Cursors.IBeam;
            roomOwnerLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roomOwnerLabel.ForeColor = SystemColors.ButtonHighlight;
            roomOwnerLabel.Location = new Point(86, 53);
            roomOwnerLabel.Name = "roomOwnerLabel";
            roomOwnerLabel.Size = new Size(121, 25);
            roomOwnerLabel.TabIndex = 10;
            roomOwnerLabel.Text = "Room Owner";
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(roomOwnerLabel);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(playersInRoomListBox);
            Controls.Add(roomCategoryLabel);
            Controls.Add(spectateRoomButton);
            Controls.Add(joinRoomButton);
            Controls.Add(roomNameLabel);
            Name = "Room";
            Size = new Size(770, 130);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label roomNameLabel;
        private Button joinRoomButton;
        private Button spectateRoomButton;
        private Label roomCategoryLabel;
        private ListBox playersInRoomListBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label roomOwnerLabel;
    }
}

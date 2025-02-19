namespace ClientApp
{
    partial class RoomsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roomsContainer = new FlowLayoutPanel();
            createRoomButton = new Button();
            SuspendLayout();
            // 
            // roomsContainer
            // 
            roomsContainer.AutoScroll = true;
            roomsContainer.Location = new Point(4, 7);
            roomsContainer.Margin = new Padding(6, 3, 3, 3);
            roomsContainer.Name = "roomsContainer";
            roomsContainer.Size = new Size(793, 359);
            roomsContainer.TabIndex = 0;
            // 
            // createRoomButton
            // 
            createRoomButton.BackColor = SystemColors.ActiveCaption;
            createRoomButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createRoomButton.ForeColor = SystemColors.Control;
            createRoomButton.Location = new Point(672, 372);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(116, 66);
            createRoomButton.TabIndex = 1;
            createRoomButton.Text = "Create Room";
            createRoomButton.UseVisualStyleBackColor = false;
            createRoomButton.Click += createRoomButton_Click;
            // 
            // RoomsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(createRoomButton);
            Controls.Add(roomsContainer);
            Name = "RoomsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RoomsForm";
            FormClosed += RoomsForm_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel roomsContainer;
        private Button createRoomButton;
    }
}
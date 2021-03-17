namespace AdBuying
{
    partial class Form1
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
            this.lblAdvertise = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.lblNormal = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblPlanLow = new System.Windows.Forms.Label();
            this.lblPlanNormal = new System.Windows.Forms.Label();
            this.lblPlanHigh = new System.Windows.Forms.Label();
            this.btnLow = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnHigh = new System.Windows.Forms.Button();
            this.panelBuy = new System.Windows.Forms.Panel();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnChooseAd = new System.Windows.Forms.Button();
            this.imageAd = new System.Windows.Forms.PictureBox();
            this.txtAdvertiser = new System.Windows.Forms.TextBox();
            this.lblAdvertiserName = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblBuyingHeader = new System.Windows.Forms.Label();
            this.btnBackPlans = new System.Windows.Forms.Button();
            this.panelBuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAdvertise
            // 
            this.lblAdvertise.AutoSize = true;
            this.lblAdvertise.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAdvertise.Location = new System.Drawing.Point(145, 26);
            this.lblAdvertise.Name = "lblAdvertise";
            this.lblAdvertise.Size = new System.Drawing.Size(180, 31);
            this.lblAdvertise.TabIndex = 0;
            this.lblAdvertise.Text = "Advertise Ad";
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblLow.Location = new System.Drawing.Point(12, 98);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(133, 31);
            this.lblLow.TabIndex = 1;
            this.lblLow.Text = "Low Plan";
            // 
            // lblNormal
            // 
            this.lblNormal.AutoSize = true;
            this.lblNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblNormal.Location = new System.Drawing.Point(152, 98);
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Size = new System.Drawing.Size(173, 31);
            this.lblNormal.TabIndex = 2;
            this.lblNormal.Text = "Normal Plan";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblHigh.Location = new System.Drawing.Point(344, 98);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(140, 31);
            this.lblHigh.TabIndex = 3;
            this.lblHigh.Text = "High Plan";
            // 
            // lblPlanLow
            // 
            this.lblPlanLow.AutoSize = true;
            this.lblPlanLow.Location = new System.Drawing.Point(27, 151);
            this.lblPlanLow.Name = "lblPlanLow";
            this.lblPlanLow.Size = new System.Drawing.Size(120, 13);
            this.lblPlanLow.TabIndex = 4;
            this.lblPlanLow.Text = "lowest shows per month\r\n";
            // 
            // lblPlanNormal
            // 
            this.lblPlanNormal.AutoSize = true;
            this.lblPlanNormal.Location = new System.Drawing.Point(183, 151);
            this.lblPlanNormal.Name = "lblPlanNormal";
            this.lblPlanNormal.Size = new System.Drawing.Size(120, 13);
            this.lblPlanNormal.TabIndex = 5;
            this.lblPlanNormal.Text = "middle shows per month";
            // 
            // lblPlanHigh
            // 
            this.lblPlanHigh.AutoSize = true;
            this.lblPlanHigh.Location = new System.Drawing.Point(360, 151);
            this.lblPlanHigh.Name = "lblPlanHigh";
            this.lblPlanHigh.Size = new System.Drawing.Size(124, 13);
            this.lblPlanHigh.TabIndex = 6;
            this.lblPlanHigh.Text = "highest shows per month";
            // 
            // btnLow
            // 
            this.btnLow.Location = new System.Drawing.Point(30, 198);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(99, 23);
            this.btnLow.TabIndex = 7;
            this.btnLow.Text = "Choose Low";
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(186, 198);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(99, 23);
            this.btnNormal.TabIndex = 8;
            this.btnNormal.Text = "Choose Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnHigh
            // 
            this.btnHigh.Location = new System.Drawing.Point(363, 198);
            this.btnHigh.Name = "btnHigh";
            this.btnHigh.Size = new System.Drawing.Size(99, 23);
            this.btnHigh.TabIndex = 9;
            this.btnHigh.Text = "Choose High";
            this.btnHigh.UseVisualStyleBackColor = true;
            this.btnHigh.Click += new System.EventHandler(this.btnHigh_Click);
            // 
            // panelBuy
            // 
            this.panelBuy.Controls.Add(this.btnBuy);
            this.panelBuy.Controls.Add(this.btnChooseAd);
            this.panelBuy.Controls.Add(this.imageAd);
            this.panelBuy.Controls.Add(this.txtAdvertiser);
            this.panelBuy.Controls.Add(this.lblAdvertiserName);
            this.panelBuy.Controls.Add(this.txtURL);
            this.panelBuy.Controls.Add(this.lblUrl);
            this.panelBuy.Controls.Add(this.lblBuyingHeader);
            this.panelBuy.Controls.Add(this.btnBackPlans);
            this.panelBuy.Location = new System.Drawing.Point(18, 92);
            this.panelBuy.Name = "panelBuy";
            this.panelBuy.Size = new System.Drawing.Size(466, 276);
            this.panelBuy.TabIndex = 10;
            this.panelBuy.Visible = false;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(207, 237);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 8;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnChooseAd
            // 
            this.btnChooseAd.Location = new System.Drawing.Point(257, 122);
            this.btnChooseAd.Name = "btnChooseAd";
            this.btnChooseAd.Size = new System.Drawing.Size(129, 65);
            this.btnChooseAd.TabIndex = 7;
            this.btnChooseAd.Text = "Choose advertise image";
            this.btnChooseAd.UseVisualStyleBackColor = true;
            this.btnChooseAd.Click += new System.EventHandler(this.btnChooseAd_Click);
            // 
            // imageAd
            // 
            this.imageAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageAd.Location = new System.Drawing.Point(23, 100);
            this.imageAd.Name = "imageAd";
            this.imageAd.Size = new System.Drawing.Size(216, 131);
            this.imageAd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageAd.TabIndex = 6;
            this.imageAd.TabStop = false;
            // 
            // txtAdvertiser
            // 
            this.txtAdvertiser.Location = new System.Drawing.Point(273, 73);
            this.txtAdvertiser.Name = "txtAdvertiser";
            this.txtAdvertiser.Size = new System.Drawing.Size(147, 20);
            this.txtAdvertiser.TabIndex = 5;
            // 
            // lblAdvertiserName
            // 
            this.lblAdvertiserName.AutoSize = true;
            this.lblAdvertiserName.Location = new System.Drawing.Point(301, 57);
            this.lblAdvertiserName.Name = "lblAdvertiserName";
            this.lblAdvertiserName.Size = new System.Drawing.Size(85, 13);
            this.lblAdvertiserName.TabIndex = 4;
            this.lblAdvertiserName.Text = "Advertiser Name";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(23, 74);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(161, 20);
            this.txtURL.TabIndex = 3;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(61, 58);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(71, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "Website URL";
            // 
            // lblBuyingHeader
            // 
            this.lblBuyingHeader.AutoSize = true;
            this.lblBuyingHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblBuyingHeader.Location = new System.Drawing.Point(163, 12);
            this.lblBuyingHeader.Name = "lblBuyingHeader";
            this.lblBuyingHeader.Size = new System.Drawing.Size(119, 26);
            this.lblBuyingHeader.TabIndex = 1;
            this.lblBuyingHeader.Text = "Insert Info";
            // 
            // btnBackPlans
            // 
            this.btnBackPlans.Location = new System.Drawing.Point(425, 0);
            this.btnBackPlans.Name = "btnBackPlans";
            this.btnBackPlans.Size = new System.Drawing.Size(41, 23);
            this.btnBackPlans.TabIndex = 0;
            this.btnBackPlans.Text = "<---";
            this.btnBackPlans.UseVisualStyleBackColor = true;
            this.btnBackPlans.Click += new System.EventHandler(this.btnBackPlans_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 393);
            this.Controls.Add(this.panelBuy);
            this.Controls.Add(this.btnHigh);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnLow);
            this.Controls.Add(this.lblPlanHigh);
            this.Controls.Add(this.lblPlanNormal);
            this.Controls.Add(this.lblPlanLow);
            this.Controls.Add(this.lblHigh);
            this.Controls.Add(this.lblNormal);
            this.Controls.Add(this.lblLow);
            this.Controls.Add(this.lblAdvertise);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelBuy.ResumeLayout(false);
            this.panelBuy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdvertise;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.Label lblNormal;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblPlanLow;
        private System.Windows.Forms.Label lblPlanNormal;
        private System.Windows.Forms.Label lblPlanHigh;
        private System.Windows.Forms.Button btnLow;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnHigh;
        private System.Windows.Forms.Panel panelBuy;
        private System.Windows.Forms.Button btnBackPlans;
        private System.Windows.Forms.PictureBox imageAd;
        private System.Windows.Forms.TextBox txtAdvertiser;
        private System.Windows.Forms.Label lblAdvertiserName;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblBuyingHeader;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnChooseAd;
    }
}


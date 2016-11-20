namespace RoundRectSample {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.roundRectContainer4 = new Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer();
            this.roundRectContainer2 = new Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer();
            this.roundRectContainer3 = new Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer();
            this.roundRectContainer1 = new Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.roundRectContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // roundRectContainer4
            // 
            this.roundRectContainer4.BackColor = System.Drawing.Color.Transparent;
            this.roundRectContainer4.BorderColor = System.Drawing.SystemColors.Highlight;
            this.roundRectContainer4.BorderFillColor = System.Drawing.Color.Transparent;
            this.roundRectContainer4.BorderWidth = 10;
            this.roundRectContainer4.CornerRadius = 4;
            this.roundRectContainer4.DropShadowColor = System.Drawing.Color.LightBlue;
            this.roundRectContainer4.DropShadowOffset = 16;
            this.roundRectContainer4.Location = new System.Drawing.Point(85, 372);
            this.roundRectContainer4.Name = "roundRectContainer4";
            this.roundRectContainer4.Size = new System.Drawing.Size(92, 81);
            this.roundRectContainer4.TabIndex = 5;
            // 
            // roundRectContainer2
            // 
            this.roundRectContainer2.BackColor = System.Drawing.Color.Transparent;
            this.roundRectContainer2.BorderColor = System.Drawing.Color.GreenYellow;
            this.roundRectContainer2.BorderFillColor = System.Drawing.Color.LightCyan;
            this.roundRectContainer2.BorderWidth = 5;
            this.roundRectContainer2.CornerRadius = 16;
            this.roundRectContainer2.DropShadowColor = System.Drawing.Color.LightBlue;
            this.roundRectContainer2.DropShadowOffset = 8;
            this.roundRectContainer2.Location = new System.Drawing.Point(32, 202);
            this.roundRectContainer2.Name = "roundRectContainer2";
            this.roundRectContainer2.Size = new System.Drawing.Size(188, 164);
            this.roundRectContainer2.TabIndex = 3;
            // 
            // roundRectContainer3
            // 
            this.roundRectContainer3.BackColor = System.Drawing.Color.Transparent;
            this.roundRectContainer3.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.roundRectContainer3.BorderFillColor = System.Drawing.Color.Transparent;
            this.roundRectContainer3.BorderWidth = 3;
            this.roundRectContainer3.CornerRadius = 40;
            this.roundRectContainer3.CornerRoundBottomRight = false;
            this.roundRectContainer3.CornerRoundTopRight = false;
            this.roundRectContainer3.DropShadowColor = System.Drawing.Color.LightBlue;
            this.roundRectContainer3.DropShadowDirection = Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer.DropShadowDirections.None;
            this.roundRectContainer3.Location = new System.Drawing.Point(348, 228);
            this.roundRectContainer3.Name = "roundRectContainer3";
            this.roundRectContainer3.Size = new System.Drawing.Size(150, 138);
            this.roundRectContainer3.TabIndex = 4;
            // 
            // roundRectContainer1
            // 
            this.roundRectContainer1.BackColor = System.Drawing.Color.Transparent;
            this.roundRectContainer1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.roundRectContainer1.BorderFillColor = System.Drawing.Color.Transparent;
            this.roundRectContainer1.BorderWidth = 1;
            this.roundRectContainer1.Controls.Add(this.checkBox1);
            this.roundRectContainer1.CornerRadius = 4;
            this.roundRectContainer1.DropShadowColor = System.Drawing.SystemColors.ActiveBorder;
            this.roundRectContainer1.Location = new System.Drawing.Point(72, 40);
            this.roundRectContainer1.Name = "roundRectContainer1";
            this.roundRectContainer1.Size = new System.Drawing.Size(232, 146);
            this.roundRectContainer1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(48, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 22);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 566);
            this.Controls.Add(this.roundRectContainer4);
            this.Controls.Add(this.roundRectContainer2);
            this.Controls.Add(this.roundRectContainer3);
            this.Controls.Add(this.roundRectContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.roundRectContainer1.ResumeLayout(false);
            this.roundRectContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer roundRectContainer1;
        private Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer roundRectContainer2;
        private Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer roundRectContainer3;
        private Case_of_t.net.WinForms.Controls.RoundRectContainerControl.RoundRectContainer roundRectContainer4;
    }
}


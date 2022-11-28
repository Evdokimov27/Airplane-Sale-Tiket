namespace AirplaneTiket
{
    partial class Authz
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.textBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.button1.HoverState.Image = global::AirplaneTiket.Properties.Resources.login;
            this.button1.HoverState.ImageSize = new System.Drawing.Size(74, 74);
            this.button1.Image = global::AirplaneTiket.Properties.Resources.login;
            this.button1.ImageOffset = new System.Drawing.Point(0, 0);
            this.button1.ImageRotate = 0F;
            this.button1.Location = new System.Drawing.Point(121, 240);
            this.button1.Name = "button1";
            this.button1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.button1.Size = new System.Drawing.Size(77, 73);
            this.button1.TabIndex = 24;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(82, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 57);
            this.label1.TabIndex = 18;
            this.label1.Text = "Войти";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(103, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Забыли пароль?";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // imageButton1
            // 
            this.imageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.imageButton1.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.imageButton1.Image = global::AirplaneTiket.Properties.Resources.hide_pass;
            this.imageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.imageButton1.ImageRotate = 0F;
            this.imageButton1.ImageSize = new System.Drawing.Size(40, 40);
            this.imageButton1.Location = new System.Drawing.Point(266, 153);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.imageButton1.Size = new System.Drawing.Size(53, 44);
            this.imageButton1.TabIndex = 23;
            this.imageButton1.Click += new System.EventHandler(this.imageButton1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Animated = true;
            this.textBox1.BorderColor = System.Drawing.Color.Black;
            this.textBox1.BorderRadius = 20;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultText = "";
            this.textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(235)))), ((int)(((byte)(218)))));
            this.textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox1.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, System.Drawing.FontStyle.Italic);
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox1.IconRightSize = new System.Drawing.Size(40, 40);
            this.textBox1.Location = new System.Drawing.Point(48, 104);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textBox1.PlaceholderText = "Номер телефона";
            this.textBox1.SelectedText = "";
            this.textBox1.Size = new System.Drawing.Size(218, 44);
            this.textBox1.TabIndex = 22;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Animated = true;
            this.textBox2.BorderColor = System.Drawing.Color.Black;
            this.textBox2.BorderRadius = 20;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.DefaultText = "";
            this.textBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(235)))), ((int)(((byte)(218)))));
            this.textBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox2.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, System.Drawing.FontStyle.Italic);
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox2.IconRightSize = new System.Drawing.Size(40, 40);
            this.textBox2.Location = new System.Drawing.Point(48, 153);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '•';
            this.textBox2.PlaceholderForeColor = System.Drawing.Color.Black;
            this.textBox2.PlaceholderText = "Пароль";
            this.textBox2.SelectedText = "";
            this.textBox2.Size = new System.Drawing.Size(218, 44);
            this.textBox2.TabIndex = 21;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Authz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Name = "Authz";
            this.Size = new System.Drawing.Size(340, 317);
            this.Load += new System.EventHandler(this.Authz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ImageButton imageButton1;
        public Guna.UI2.WinForms.Guna2TextBox textBox1;
        public Guna.UI2.WinForms.Guna2TextBox textBox2;
    }
}

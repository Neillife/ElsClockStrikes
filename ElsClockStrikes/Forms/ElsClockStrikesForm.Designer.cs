namespace ElsClockStrikes
{
    partial class ElsClockStrikesForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElsClockStrikesForm));
            this.控場Timer = new System.Windows.Forms.Timer(this.components);
            this.控場Label = new System.Windows.Forms.Label();
            this.TopMostCheckBox = new Guna.UI.WinForms.GunaCheckBox();
            this.WindowsSetting = new Guna.UI.WinForms.GunaButton();
            this.控場TextBox = new Guna.UI.WinForms.GunaLineTextBox();
            this.小荊棘TextBox = new Guna.UI.WinForms.GunaLineTextBox();
            this.小荊棘Label = new System.Windows.Forms.Label();
            this.雷射TextBox = new Guna.UI.WinForms.GunaLineTextBox();
            this.雷射Label = new System.Windows.Forms.Label();
            this.荊棘延遲TextBox = new Guna.UI.WinForms.GunaLineTextBox();
            this.荊棘延遲Label = new System.Windows.Forms.Label();
            this.重置計時器Label = new System.Windows.Forms.Label();
            this.重置計時器ComboBox = new Guna.UI.WinForms.GunaComboBox();
            this.控場ComboBox = new Guna.UI.WinForms.GunaComboBox();
            this.荊棘延遲ComboBox = new Guna.UI.WinForms.GunaComboBox();
            this.雷射ComboBox = new Guna.UI.WinForms.GunaComboBox();
            this.小荊棘ComboBox = new Guna.UI.WinForms.GunaComboBox();
            this.CloseControlBox = new Guna.UI.WinForms.GunaControlBox();
            this.ZoomOutControlBox = new Guna.UI.WinForms.GunaControlBox();
            this.荊棘延遲Timer = new System.Windows.Forms.Timer(this.components);
            this.雷射Timer = new System.Windows.Forms.Timer(this.components);
            this.小荊棘Timer = new System.Windows.Forms.Timer(this.components);
            this.小荊棘CDLabel = new System.Windows.Forms.Label();
            this.雷射CDLabel = new System.Windows.Forms.Label();
            this.荊棘延遲CDLabel = new System.Windows.Forms.Label();
            this.控場CDLabel = new System.Windows.Forms.Label();
            this.小荊棘按鍵Label = new System.Windows.Forms.Label();
            this.雷射按鍵Label = new System.Windows.Forms.Label();
            this.荊棘延遲按鍵Label = new System.Windows.Forms.Label();
            this.控場按鍵Label = new System.Windows.Forms.Label();
            this.重置計時器按鍵Label = new System.Windows.Forms.Label();
            this.小荊棘設定音效Button = new Guna.UI.WinForms.GunaButton();
            this.雷射設定音效Button = new Guna.UI.WinForms.GunaButton();
            this.荊棘延遲設定音效Button = new Guna.UI.WinForms.GunaButton();
            this.控場設定音效Button = new Guna.UI.WinForms.GunaButton();
            this.音效設定GroupBox = new System.Windows.Forms.GroupBox();
            this.關閉音效RadioButton = new Guna.UI.WinForms.GunaRadioButton();
            this.預設音效RadioButton = new Guna.UI.WinForms.GunaRadioButton();
            this.自訂音效RadioButton = new Guna.UI.WinForms.GunaRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.音效設定GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // 控場Timer
            // 
            this.控場Timer.Interval = 1000;
            this.控場Timer.Tag = "控場Timer";
            this.控場Timer.Tick += new System.EventHandler(this.控場_Tick);
            // 
            // 控場Label
            // 
            this.控場Label.AutoSize = true;
            this.控場Label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.控場Label.Location = new System.Drawing.Point(250, 279);
            this.控場Label.Name = "控場Label";
            this.控場Label.Size = new System.Drawing.Size(47, 20);
            this.控場Label.TabIndex = 0;
            this.控場Label.Text = "控場:";
            // 
            // TopMostCheckBox
            // 
            this.TopMostCheckBox.BaseColor = System.Drawing.Color.White;
            this.TopMostCheckBox.CheckedOffColor = System.Drawing.Color.Gray;
            this.TopMostCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.TopMostCheckBox.FillColor = System.Drawing.Color.White;
            this.TopMostCheckBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopMostCheckBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TopMostCheckBox.Location = new System.Drawing.Point(94, 420);
            this.TopMostCheckBox.Name = "TopMostCheckBox";
            this.TopMostCheckBox.Size = new System.Drawing.Size(100, 25);
            this.TopMostCheckBox.TabIndex = 1;
            this.TopMostCheckBox.Text = "置頂視窗";
            this.TopMostCheckBox.CheckedChanged += new System.EventHandler(this.TopMostCheckBox_CheckedChanged);
            // 
            // WindowsSetting
            // 
            this.WindowsSetting.Animated = true;
            this.WindowsSetting.AnimationHoverSpeed = 0.07F;
            this.WindowsSetting.AnimationSpeed = 0.03F;
            this.WindowsSetting.BackColor = System.Drawing.Color.Transparent;
            this.WindowsSetting.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.WindowsSetting.BorderColor = System.Drawing.Color.Transparent;
            this.WindowsSetting.DialogResult = System.Windows.Forms.DialogResult.None;
            this.WindowsSetting.FocusedColor = System.Drawing.Color.Empty;
            this.WindowsSetting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.WindowsSetting.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.WindowsSetting.Image = null;
            this.WindowsSetting.ImageSize = new System.Drawing.Size(24, 24);
            this.WindowsSetting.Location = new System.Drawing.Point(256, 403);
            this.WindowsSetting.Name = "WindowsSetting";
            this.WindowsSetting.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.WindowsSetting.OnHoverBorderColor = System.Drawing.Color.Black;
            this.WindowsSetting.OnHoverForeColor = System.Drawing.Color.White;
            this.WindowsSetting.OnHoverImage = null;
            this.WindowsSetting.OnPressedColor = System.Drawing.Color.Black;
            this.WindowsSetting.Size = new System.Drawing.Size(150, 42);
            this.WindowsSetting.TabIndex = 91;
            this.WindowsSetting.Text = "設定完成";
            this.WindowsSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WindowsSetting.Click += new System.EventHandler(this.WindowsSetting_Click);
            // 
            // 控場TextBox
            // 
            this.控場TextBox.Animated = true;
            this.控場TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            this.控場TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.控場TextBox.FocusedLineColor = System.Drawing.Color.Red;
            this.控場TextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.控場TextBox.LineColor = System.Drawing.Color.Gainsboro;
            this.控場TextBox.LineSize = 1;
            this.控場TextBox.Location = new System.Drawing.Point(316, 266);
            this.控場TextBox.MaxLength = 3;
            this.控場TextBox.Name = "控場TextBox";
            this.控場TextBox.PasswordChar = '\0';
            this.控場TextBox.Size = new System.Drawing.Size(90, 42);
            this.控場TextBox.TabIndex = 93;
            this.控場TextBox.Text = "90";
            this.控場TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.控場TextBox.TextOffsetX = 3;
            this.控場TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.控場TextBox_KeyPress);
            // 
            // 小荊棘TextBox
            // 
            this.小荊棘TextBox.Animated = true;
            this.小荊棘TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            this.小荊棘TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.小荊棘TextBox.FocusedLineColor = System.Drawing.Color.Red;
            this.小荊棘TextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.小荊棘TextBox.LineColor = System.Drawing.Color.Gainsboro;
            this.小荊棘TextBox.LineSize = 1;
            this.小荊棘TextBox.Location = new System.Drawing.Point(316, 50);
            this.小荊棘TextBox.MaxLength = 3;
            this.小荊棘TextBox.Name = "小荊棘TextBox";
            this.小荊棘TextBox.PasswordChar = '\0';
            this.小荊棘TextBox.Size = new System.Drawing.Size(90, 42);
            this.小荊棘TextBox.TabIndex = 95;
            this.小荊棘TextBox.Text = "150";
            this.小荊棘TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.小荊棘TextBox.TextOffsetX = 3;
            this.小荊棘TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.小荊棘TextBox_KeyPress);
            // 
            // 小荊棘Label
            // 
            this.小荊棘Label.AutoSize = true;
            this.小荊棘Label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.小荊棘Label.Location = new System.Drawing.Point(233, 63);
            this.小荊棘Label.Name = "小荊棘Label";
            this.小荊棘Label.Size = new System.Drawing.Size(64, 20);
            this.小荊棘Label.TabIndex = 94;
            this.小荊棘Label.Text = "小荊棘:";
            // 
            // 雷射TextBox
            // 
            this.雷射TextBox.Animated = true;
            this.雷射TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            this.雷射TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.雷射TextBox.FocusedLineColor = System.Drawing.Color.Red;
            this.雷射TextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.雷射TextBox.LineColor = System.Drawing.Color.Gainsboro;
            this.雷射TextBox.LineSize = 1;
            this.雷射TextBox.Location = new System.Drawing.Point(316, 122);
            this.雷射TextBox.MaxLength = 3;
            this.雷射TextBox.Name = "雷射TextBox";
            this.雷射TextBox.PasswordChar = '\0';
            this.雷射TextBox.Size = new System.Drawing.Size(90, 42);
            this.雷射TextBox.TabIndex = 97;
            this.雷射TextBox.Text = "70";
            this.雷射TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.雷射TextBox.TextOffsetX = 3;
            this.雷射TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.雷射TextBox_KeyPress);
            // 
            // 雷射Label
            // 
            this.雷射Label.AutoSize = true;
            this.雷射Label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.雷射Label.Location = new System.Drawing.Point(250, 135);
            this.雷射Label.Name = "雷射Label";
            this.雷射Label.Size = new System.Drawing.Size(47, 20);
            this.雷射Label.TabIndex = 96;
            this.雷射Label.Text = "雷射:";
            // 
            // 荊棘延遲TextBox
            // 
            this.荊棘延遲TextBox.Animated = true;
            this.荊棘延遲TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(82)))), ((int)(((byte)(80)))));
            this.荊棘延遲TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.荊棘延遲TextBox.FocusedLineColor = System.Drawing.Color.Red;
            this.荊棘延遲TextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.荊棘延遲TextBox.LineColor = System.Drawing.Color.Gainsboro;
            this.荊棘延遲TextBox.LineSize = 1;
            this.荊棘延遲TextBox.Location = new System.Drawing.Point(316, 194);
            this.荊棘延遲TextBox.MaxLength = 3;
            this.荊棘延遲TextBox.Name = "荊棘延遲TextBox";
            this.荊棘延遲TextBox.PasswordChar = '\0';
            this.荊棘延遲TextBox.Size = new System.Drawing.Size(90, 42);
            this.荊棘延遲TextBox.TabIndex = 99;
            this.荊棘延遲TextBox.Text = "30";
            this.荊棘延遲TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.荊棘延遲TextBox.TextOffsetX = 3;
            this.荊棘延遲TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.荊棘延遲TextBox_KeyPress);
            // 
            // 荊棘延遲Label
            // 
            this.荊棘延遲Label.AutoSize = true;
            this.荊棘延遲Label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.荊棘延遲Label.Location = new System.Drawing.Point(216, 207);
            this.荊棘延遲Label.Name = "荊棘延遲Label";
            this.荊棘延遲Label.Size = new System.Drawing.Size(81, 20);
            this.荊棘延遲Label.TabIndex = 98;
            this.荊棘延遲Label.Text = "荊棘延遲:";
            // 
            // 重置計時器Label
            // 
            this.重置計時器Label.AutoSize = true;
            this.重置計時器Label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.重置計時器Label.Location = new System.Drawing.Point(199, 351);
            this.重置計時器Label.Name = "重置計時器Label";
            this.重置計時器Label.Size = new System.Drawing.Size(94, 20);
            this.重置計時器Label.TabIndex = 100;
            this.重置計時器Label.Text = "重置計時器";
            // 
            // 重置計時器ComboBox
            // 
            this.重置計時器ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.重置計時器ComboBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.重置計時器ComboBox.BorderColor = System.Drawing.Color.Silver;
            this.重置計時器ComboBox.BorderSize = 1;
            this.重置計時器ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.重置計時器ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.重置計時器ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.重置計時器ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.重置計時器ComboBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.重置計時器ComboBox.FormattingEnabled = true;
            this.重置計時器ComboBox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "主鍵盤0",
            "主鍵盤1",
            "主鍵盤2",
            "主鍵盤3",
            "主鍵盤4",
            "主鍵盤5",
            "主鍵盤6",
            "主鍵盤7",
            "主鍵盤8",
            "主鍵盤9",
            "小鍵盤0",
            "小鍵盤1",
            "小鍵盤2",
            "小鍵盤3",
            "小鍵盤4",
            "小鍵盤5",
            "小鍵盤6",
            "小鍵盤7",
            "小鍵盤8",
            "小鍵盤9"});
            this.重置計時器ComboBox.Location = new System.Drawing.Point(94, 348);
            this.重置計時器ComboBox.Name = "重置計時器ComboBox";
            this.重置計時器ComboBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.重置計時器ComboBox.OnHoverItemForeColor = System.Drawing.SystemColors.ControlDark;
            this.重置計時器ComboBox.Size = new System.Drawing.Size(84, 26);
            this.重置計時器ComboBox.StartIndex = 4;
            this.重置計時器ComboBox.TabIndex = 103;
            // 
            // 控場ComboBox
            // 
            this.控場ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.控場ComboBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.控場ComboBox.BorderColor = System.Drawing.Color.Silver;
            this.控場ComboBox.BorderSize = 1;
            this.控場ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.控場ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.控場ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.控場ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.控場ComboBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.控場ComboBox.FormattingEnabled = true;
            this.控場ComboBox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "主鍵盤0",
            "主鍵盤1",
            "主鍵盤2",
            "主鍵盤3",
            "主鍵盤4",
            "主鍵盤5",
            "主鍵盤6",
            "主鍵盤7",
            "主鍵盤8",
            "主鍵盤9",
            "小鍵盤0",
            "小鍵盤1",
            "小鍵盤2",
            "小鍵盤3",
            "小鍵盤4",
            "小鍵盤5",
            "小鍵盤6",
            "小鍵盤7",
            "小鍵盤8",
            "小鍵盤9"});
            this.控場ComboBox.Location = new System.Drawing.Point(94, 276);
            this.控場ComboBox.Name = "控場ComboBox";
            this.控場ComboBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.控場ComboBox.OnHoverItemForeColor = System.Drawing.SystemColors.ControlDark;
            this.控場ComboBox.Size = new System.Drawing.Size(84, 26);
            this.控場ComboBox.StartIndex = 3;
            this.控場ComboBox.TabIndex = 104;
            // 
            // 荊棘延遲ComboBox
            // 
            this.荊棘延遲ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.荊棘延遲ComboBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.荊棘延遲ComboBox.BorderColor = System.Drawing.Color.Silver;
            this.荊棘延遲ComboBox.BorderSize = 1;
            this.荊棘延遲ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.荊棘延遲ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.荊棘延遲ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.荊棘延遲ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.荊棘延遲ComboBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.荊棘延遲ComboBox.FormattingEnabled = true;
            this.荊棘延遲ComboBox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "主鍵盤0",
            "主鍵盤1",
            "主鍵盤2",
            "主鍵盤3",
            "主鍵盤4",
            "主鍵盤5",
            "主鍵盤6",
            "主鍵盤7",
            "主鍵盤8",
            "主鍵盤9",
            "小鍵盤0",
            "小鍵盤1",
            "小鍵盤2",
            "小鍵盤3",
            "小鍵盤4",
            "小鍵盤5",
            "小鍵盤6",
            "小鍵盤7",
            "小鍵盤8",
            "小鍵盤9"});
            this.荊棘延遲ComboBox.Location = new System.Drawing.Point(94, 204);
            this.荊棘延遲ComboBox.Name = "荊棘延遲ComboBox";
            this.荊棘延遲ComboBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.荊棘延遲ComboBox.OnHoverItemForeColor = System.Drawing.SystemColors.ControlDark;
            this.荊棘延遲ComboBox.Size = new System.Drawing.Size(84, 26);
            this.荊棘延遲ComboBox.StartIndex = 2;
            this.荊棘延遲ComboBox.TabIndex = 105;
            // 
            // 雷射ComboBox
            // 
            this.雷射ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.雷射ComboBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.雷射ComboBox.BorderColor = System.Drawing.Color.Silver;
            this.雷射ComboBox.BorderSize = 1;
            this.雷射ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.雷射ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.雷射ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.雷射ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.雷射ComboBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.雷射ComboBox.FormattingEnabled = true;
            this.雷射ComboBox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "主鍵盤0",
            "主鍵盤1",
            "主鍵盤2",
            "主鍵盤3",
            "主鍵盤4",
            "主鍵盤5",
            "主鍵盤6",
            "主鍵盤7",
            "主鍵盤8",
            "主鍵盤9",
            "小鍵盤0",
            "小鍵盤1",
            "小鍵盤2",
            "小鍵盤3",
            "小鍵盤4",
            "小鍵盤5",
            "小鍵盤6",
            "小鍵盤7",
            "小鍵盤8",
            "小鍵盤9"});
            this.雷射ComboBox.Location = new System.Drawing.Point(94, 132);
            this.雷射ComboBox.Name = "雷射ComboBox";
            this.雷射ComboBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.雷射ComboBox.OnHoverItemForeColor = System.Drawing.SystemColors.ControlDark;
            this.雷射ComboBox.Size = new System.Drawing.Size(84, 26);
            this.雷射ComboBox.StartIndex = 1;
            this.雷射ComboBox.TabIndex = 106;
            // 
            // 小荊棘ComboBox
            // 
            this.小荊棘ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.小荊棘ComboBox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.小荊棘ComboBox.BorderColor = System.Drawing.Color.Silver;
            this.小荊棘ComboBox.BorderSize = 1;
            this.小荊棘ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.小荊棘ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.小荊棘ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.小荊棘ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.小荊棘ComboBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.小荊棘ComboBox.FormattingEnabled = true;
            this.小荊棘ComboBox.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "主鍵盤0",
            "主鍵盤1",
            "主鍵盤2",
            "主鍵盤3",
            "主鍵盤4",
            "主鍵盤5",
            "主鍵盤6",
            "主鍵盤7",
            "主鍵盤8",
            "主鍵盤9",
            "小鍵盤0",
            "小鍵盤1",
            "小鍵盤2",
            "小鍵盤3",
            "小鍵盤4",
            "小鍵盤5",
            "小鍵盤6",
            "小鍵盤7",
            "小鍵盤8",
            "小鍵盤9"});
            this.小荊棘ComboBox.Location = new System.Drawing.Point(94, 60);
            this.小荊棘ComboBox.Name = "小荊棘ComboBox";
            this.小荊棘ComboBox.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.小荊棘ComboBox.OnHoverItemForeColor = System.Drawing.SystemColors.ControlDark;
            this.小荊棘ComboBox.Size = new System.Drawing.Size(84, 26);
            this.小荊棘ComboBox.StartIndex = 0;
            this.小荊棘ComboBox.TabIndex = 107;
            // 
            // CloseControlBox
            // 
            this.CloseControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseControlBox.Animated = true;
            this.CloseControlBox.AnimationHoverSpeed = 0.07F;
            this.CloseControlBox.AnimationSpeed = 0.03F;
            this.CloseControlBox.IconColor = System.Drawing.Color.White;
            this.CloseControlBox.IconSize = 15F;
            this.CloseControlBox.Location = new System.Drawing.Point(440, 14);
            this.CloseControlBox.Name = "CloseControlBox";
            this.CloseControlBox.OnHoverBackColor = System.Drawing.Color.RoyalBlue;
            this.CloseControlBox.OnHoverIconColor = System.Drawing.Color.White;
            this.CloseControlBox.OnPressedColor = System.Drawing.Color.Black;
            this.CloseControlBox.Size = new System.Drawing.Size(45, 29);
            this.CloseControlBox.TabIndex = 109;
            // 
            // ZoomOutControlBox
            // 
            this.ZoomOutControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomOutControlBox.Animated = true;
            this.ZoomOutControlBox.AnimationHoverSpeed = 0.07F;
            this.ZoomOutControlBox.AnimationSpeed = 0.03F;
            this.ZoomOutControlBox.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.ZoomOutControlBox.IconColor = System.Drawing.Color.White;
            this.ZoomOutControlBox.IconSize = 15F;
            this.ZoomOutControlBox.Location = new System.Drawing.Point(389, 14);
            this.ZoomOutControlBox.Name = "ZoomOutControlBox";
            this.ZoomOutControlBox.OnHoverBackColor = System.Drawing.Color.RoyalBlue;
            this.ZoomOutControlBox.OnHoverIconColor = System.Drawing.Color.White;
            this.ZoomOutControlBox.OnPressedColor = System.Drawing.Color.Black;
            this.ZoomOutControlBox.Size = new System.Drawing.Size(45, 29);
            this.ZoomOutControlBox.TabIndex = 108;
            // 
            // 荊棘延遲Timer
            // 
            this.荊棘延遲Timer.Interval = 1000;
            this.荊棘延遲Timer.Tag = "荊棘延遲Timer";
            this.荊棘延遲Timer.Tick += new System.EventHandler(this.荊棘延遲Timer_Tick);
            // 
            // 雷射Timer
            // 
            this.雷射Timer.Interval = 1000;
            this.雷射Timer.Tag = "雷射Timer";
            this.雷射Timer.Tick += new System.EventHandler(this.雷射Timer_Tick);
            // 
            // 小荊棘Timer
            // 
            this.小荊棘Timer.Interval = 1000;
            this.小荊棘Timer.Tag = "小荊棘Timer";
            this.小荊棘Timer.Tick += new System.EventHandler(this.小荊棘Timer_Tick);
            // 
            // 小荊棘CDLabel
            // 
            this.小荊棘CDLabel.AutoSize = true;
            this.小荊棘CDLabel.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.小荊棘CDLabel.Location = new System.Drawing.Point(32, 63);
            this.小荊棘CDLabel.Name = "小荊棘CDLabel";
            this.小荊棘CDLabel.Size = new System.Drawing.Size(49, 30);
            this.小荊棘CDLabel.TabIndex = 110;
            this.小荊棘CDLabel.Text = "150";
            this.小荊棘CDLabel.Visible = false;
            // 
            // 雷射CDLabel
            // 
            this.雷射CDLabel.AutoSize = true;
            this.雷射CDLabel.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.雷射CDLabel.Location = new System.Drawing.Point(41, 135);
            this.雷射CDLabel.Name = "雷射CDLabel";
            this.雷射CDLabel.Size = new System.Drawing.Size(37, 30);
            this.雷射CDLabel.TabIndex = 111;
            this.雷射CDLabel.Text = "70";
            this.雷射CDLabel.Visible = false;
            // 
            // 荊棘延遲CDLabel
            // 
            this.荊棘延遲CDLabel.AutoSize = true;
            this.荊棘延遲CDLabel.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.荊棘延遲CDLabel.Location = new System.Drawing.Point(41, 207);
            this.荊棘延遲CDLabel.Name = "荊棘延遲CDLabel";
            this.荊棘延遲CDLabel.Size = new System.Drawing.Size(37, 30);
            this.荊棘延遲CDLabel.TabIndex = 112;
            this.荊棘延遲CDLabel.Text = "30";
            this.荊棘延遲CDLabel.Visible = false;
            // 
            // 控場CDLabel
            // 
            this.控場CDLabel.AutoSize = true;
            this.控場CDLabel.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.控場CDLabel.Location = new System.Drawing.Point(41, 279);
            this.控場CDLabel.Name = "控場CDLabel";
            this.控場CDLabel.Size = new System.Drawing.Size(37, 30);
            this.控場CDLabel.TabIndex = 113;
            this.控場CDLabel.Text = "90";
            this.控場CDLabel.Visible = false;
            // 
            // 小荊棘按鍵Label
            // 
            this.小荊棘按鍵Label.AutoSize = true;
            this.小荊棘按鍵Label.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.小荊棘按鍵Label.Location = new System.Drawing.Point(89, 27);
            this.小荊棘按鍵Label.Name = "小荊棘按鍵Label";
            this.小荊棘按鍵Label.Size = new System.Drawing.Size(36, 30);
            this.小荊棘按鍵Label.TabIndex = 114;
            this.小荊棘按鍵Label.Text = "F1";
            this.小荊棘按鍵Label.Visible = false;
            // 
            // 雷射按鍵Label
            // 
            this.雷射按鍵Label.AutoSize = true;
            this.雷射按鍵Label.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.雷射按鍵Label.Location = new System.Drawing.Point(89, 99);
            this.雷射按鍵Label.Name = "雷射按鍵Label";
            this.雷射按鍵Label.Size = new System.Drawing.Size(36, 30);
            this.雷射按鍵Label.TabIndex = 115;
            this.雷射按鍵Label.Text = "F2";
            this.雷射按鍵Label.Visible = false;
            // 
            // 荊棘延遲按鍵Label
            // 
            this.荊棘延遲按鍵Label.AutoSize = true;
            this.荊棘延遲按鍵Label.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.荊棘延遲按鍵Label.Location = new System.Drawing.Point(89, 171);
            this.荊棘延遲按鍵Label.Name = "荊棘延遲按鍵Label";
            this.荊棘延遲按鍵Label.Size = new System.Drawing.Size(36, 30);
            this.荊棘延遲按鍵Label.TabIndex = 116;
            this.荊棘延遲按鍵Label.Text = "F3";
            this.荊棘延遲按鍵Label.Visible = false;
            // 
            // 控場按鍵Label
            // 
            this.控場按鍵Label.AutoSize = true;
            this.控場按鍵Label.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.控場按鍵Label.Location = new System.Drawing.Point(89, 243);
            this.控場按鍵Label.Name = "控場按鍵Label";
            this.控場按鍵Label.Size = new System.Drawing.Size(36, 30);
            this.控場按鍵Label.TabIndex = 117;
            this.控場按鍵Label.Text = "F4";
            this.控場按鍵Label.Visible = false;
            // 
            // 重置計時器按鍵Label
            // 
            this.重置計時器按鍵Label.AutoSize = true;
            this.重置計時器按鍵Label.Font = new System.Drawing.Font("Segoe UI", 15.25F, System.Drawing.FontStyle.Bold);
            this.重置計時器按鍵Label.Location = new System.Drawing.Point(89, 315);
            this.重置計時器按鍵Label.Name = "重置計時器按鍵Label";
            this.重置計時器按鍵Label.Size = new System.Drawing.Size(36, 30);
            this.重置計時器按鍵Label.TabIndex = 118;
            this.重置計時器按鍵Label.Text = "F5";
            this.重置計時器按鍵Label.Visible = false;
            // 
            // 小荊棘設定音效Button
            // 
            this.小荊棘設定音效Button.Animated = true;
            this.小荊棘設定音效Button.AnimationHoverSpeed = 0.07F;
            this.小荊棘設定音效Button.AnimationSpeed = 0.03F;
            this.小荊棘設定音效Button.BackColor = System.Drawing.Color.Transparent;
            this.小荊棘設定音效Button.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.小荊棘設定音效Button.BorderColor = System.Drawing.Color.Transparent;
            this.小荊棘設定音效Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.小荊棘設定音效Button.FocusedColor = System.Drawing.Color.Empty;
            this.小荊棘設定音效Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.小荊棘設定音效Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.小荊棘設定音效Button.Image = null;
            this.小荊棘設定音效Button.ImageSize = new System.Drawing.Size(24, 24);
            this.小荊棘設定音效Button.Location = new System.Drawing.Point(412, 51);
            this.小荊棘設定音效Button.Name = "小荊棘設定音效Button";
            this.小荊棘設定音效Button.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.小荊棘設定音效Button.OnHoverBorderColor = System.Drawing.Color.Black;
            this.小荊棘設定音效Button.OnHoverForeColor = System.Drawing.Color.White;
            this.小荊棘設定音效Button.OnHoverImage = null;
            this.小荊棘設定音效Button.OnPressedColor = System.Drawing.Color.Black;
            this.小荊棘設定音效Button.Size = new System.Drawing.Size(84, 42);
            this.小荊棘設定音效Button.TabIndex = 119;
            this.小荊棘設定音效Button.Text = "設定音效";
            this.小荊棘設定音效Button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.小荊棘設定音效Button.Visible = false;
            this.小荊棘設定音效Button.Click += new System.EventHandler(this.小荊棘設定音效Button_Click);
            // 
            // 雷射設定音效Button
            // 
            this.雷射設定音效Button.Animated = true;
            this.雷射設定音效Button.AnimationHoverSpeed = 0.07F;
            this.雷射設定音效Button.AnimationSpeed = 0.03F;
            this.雷射設定音效Button.BackColor = System.Drawing.Color.Transparent;
            this.雷射設定音效Button.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.雷射設定音效Button.BorderColor = System.Drawing.Color.Transparent;
            this.雷射設定音效Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.雷射設定音效Button.FocusedColor = System.Drawing.Color.Empty;
            this.雷射設定音效Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.雷射設定音效Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.雷射設定音效Button.Image = null;
            this.雷射設定音效Button.ImageSize = new System.Drawing.Size(24, 24);
            this.雷射設定音效Button.Location = new System.Drawing.Point(412, 122);
            this.雷射設定音效Button.Name = "雷射設定音效Button";
            this.雷射設定音效Button.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.雷射設定音效Button.OnHoverBorderColor = System.Drawing.Color.Black;
            this.雷射設定音效Button.OnHoverForeColor = System.Drawing.Color.White;
            this.雷射設定音效Button.OnHoverImage = null;
            this.雷射設定音效Button.OnPressedColor = System.Drawing.Color.Black;
            this.雷射設定音效Button.Size = new System.Drawing.Size(84, 42);
            this.雷射設定音效Button.TabIndex = 120;
            this.雷射設定音效Button.Text = "設定音效";
            this.雷射設定音效Button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.雷射設定音效Button.Visible = false;
            this.雷射設定音效Button.Click += new System.EventHandler(this.雷射設定音效Button_Click);
            // 
            // 荊棘延遲設定音效Button
            // 
            this.荊棘延遲設定音效Button.Animated = true;
            this.荊棘延遲設定音效Button.AnimationHoverSpeed = 0.07F;
            this.荊棘延遲設定音效Button.AnimationSpeed = 0.03F;
            this.荊棘延遲設定音效Button.BackColor = System.Drawing.Color.Transparent;
            this.荊棘延遲設定音效Button.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.荊棘延遲設定音效Button.BorderColor = System.Drawing.Color.Transparent;
            this.荊棘延遲設定音效Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.荊棘延遲設定音效Button.FocusedColor = System.Drawing.Color.Empty;
            this.荊棘延遲設定音效Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.荊棘延遲設定音效Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.荊棘延遲設定音效Button.Image = null;
            this.荊棘延遲設定音效Button.ImageSize = new System.Drawing.Size(24, 24);
            this.荊棘延遲設定音效Button.Location = new System.Drawing.Point(412, 194);
            this.荊棘延遲設定音效Button.Name = "荊棘延遲設定音效Button";
            this.荊棘延遲設定音效Button.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.荊棘延遲設定音效Button.OnHoverBorderColor = System.Drawing.Color.Black;
            this.荊棘延遲設定音效Button.OnHoverForeColor = System.Drawing.Color.White;
            this.荊棘延遲設定音效Button.OnHoverImage = null;
            this.荊棘延遲設定音效Button.OnPressedColor = System.Drawing.Color.Black;
            this.荊棘延遲設定音效Button.Size = new System.Drawing.Size(84, 42);
            this.荊棘延遲設定音效Button.TabIndex = 121;
            this.荊棘延遲設定音效Button.Text = "設定音效";
            this.荊棘延遲設定音效Button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.荊棘延遲設定音效Button.Visible = false;
            this.荊棘延遲設定音效Button.Click += new System.EventHandler(this.荊棘延遲設定音效Button_Click);
            // 
            // 控場設定音效Button
            // 
            this.控場設定音效Button.Animated = true;
            this.控場設定音效Button.AnimationHoverSpeed = 0.07F;
            this.控場設定音效Button.AnimationSpeed = 0.03F;
            this.控場設定音效Button.BackColor = System.Drawing.Color.Transparent;
            this.控場設定音效Button.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.控場設定音效Button.BorderColor = System.Drawing.Color.Transparent;
            this.控場設定音效Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.控場設定音效Button.FocusedColor = System.Drawing.Color.Empty;
            this.控場設定音效Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.控場設定音效Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.控場設定音效Button.Image = null;
            this.控場設定音效Button.ImageSize = new System.Drawing.Size(24, 24);
            this.控場設定音效Button.Location = new System.Drawing.Point(412, 266);
            this.控場設定音效Button.Name = "控場設定音效Button";
            this.控場設定音效Button.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.控場設定音效Button.OnHoverBorderColor = System.Drawing.Color.Black;
            this.控場設定音效Button.OnHoverForeColor = System.Drawing.Color.White;
            this.控場設定音效Button.OnHoverImage = null;
            this.控場設定音效Button.OnPressedColor = System.Drawing.Color.Black;
            this.控場設定音效Button.Size = new System.Drawing.Size(84, 42);
            this.控場設定音效Button.TabIndex = 122;
            this.控場設定音效Button.Text = "設定音效";
            this.控場設定音效Button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.控場設定音效Button.Visible = false;
            this.控場設定音效Button.Click += new System.EventHandler(this.控場設定音效Button_Click);
            // 
            // 音效設定GroupBox
            // 
            this.音效設定GroupBox.Controls.Add(this.關閉音效RadioButton);
            this.音效設定GroupBox.Controls.Add(this.預設音效RadioButton);
            this.音效設定GroupBox.Controls.Add(this.自訂音效RadioButton);
            this.音效設定GroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.音效設定GroupBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.音效設定GroupBox.Location = new System.Drawing.Point(98, 462);
            this.音效設定GroupBox.Name = "音效設定GroupBox";
            this.音效設定GroupBox.Size = new System.Drawing.Size(304, 50);
            this.音效設定GroupBox.TabIndex = 123;
            this.音效設定GroupBox.TabStop = false;
            this.音效設定GroupBox.Text = "計時器音效設定";
            // 
            // 關閉音效RadioButton
            // 
            this.關閉音效RadioButton.BaseColor = System.Drawing.SystemColors.Control;
            this.關閉音效RadioButton.CheckedOffColor = System.Drawing.Color.Gray;
            this.關閉音效RadioButton.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.關閉音效RadioButton.FillColor = System.Drawing.Color.White;
            this.關閉音效RadioButton.Location = new System.Drawing.Point(228, 20);
            this.關閉音效RadioButton.Name = "關閉音效RadioButton";
            this.關閉音效RadioButton.Size = new System.Drawing.Size(55, 20);
            this.關閉音效RadioButton.TabIndex = 79;
            this.關閉音效RadioButton.Text = "關閉";
            this.關閉音效RadioButton.CheckedChanged += new System.EventHandler(this.關閉音效RadioButton_CheckedChanged);
            // 
            // 預設音效RadioButton
            // 
            this.預設音效RadioButton.BaseColor = System.Drawing.SystemColors.Control;
            this.預設音效RadioButton.Checked = true;
            this.預設音效RadioButton.CheckedOffColor = System.Drawing.Color.Gray;
            this.預設音效RadioButton.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.預設音效RadioButton.FillColor = System.Drawing.Color.White;
            this.預設音效RadioButton.Location = new System.Drawing.Point(20, 20);
            this.預設音效RadioButton.Name = "預設音效RadioButton";
            this.預設音效RadioButton.Size = new System.Drawing.Size(55, 20);
            this.預設音效RadioButton.TabIndex = 77;
            this.預設音效RadioButton.Text = "預設";
            this.預設音效RadioButton.CheckedChanged += new System.EventHandler(this.預設音效RadioButton_CheckedChanged);
            // 
            // 自訂音效RadioButton
            // 
            this.自訂音效RadioButton.BaseColor = System.Drawing.SystemColors.Control;
            this.自訂音效RadioButton.CheckedOffColor = System.Drawing.Color.Gray;
            this.自訂音效RadioButton.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.自訂音效RadioButton.FillColor = System.Drawing.Color.White;
            this.自訂音效RadioButton.Location = new System.Drawing.Point(124, 20);
            this.自訂音效RadioButton.Name = "自訂音效RadioButton";
            this.自訂音效RadioButton.Size = new System.Drawing.Size(55, 20);
            this.自訂音效RadioButton.TabIndex = 78;
            this.自訂音效RadioButton.Text = "自訂";
            this.自訂音效RadioButton.CheckedChanged += new System.EventHandler(this.自訂音效RadioButton_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 15);
            this.label2.TabIndex = 124;
            this.label2.Text = "Copyright © 2024, Levi. All rights reserved.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ElsClockStrikesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(500, 550);
            this.Controls.Add(this.音效設定GroupBox);
            this.Controls.Add(this.控場設定音效Button);
            this.Controls.Add(this.荊棘延遲設定音效Button);
            this.Controls.Add(this.雷射設定音效Button);
            this.Controls.Add(this.小荊棘設定音效Button);
            this.Controls.Add(this.重置計時器按鍵Label);
            this.Controls.Add(this.控場按鍵Label);
            this.Controls.Add(this.荊棘延遲按鍵Label);
            this.Controls.Add(this.雷射按鍵Label);
            this.Controls.Add(this.小荊棘按鍵Label);
            this.Controls.Add(this.控場CDLabel);
            this.Controls.Add(this.荊棘延遲CDLabel);
            this.Controls.Add(this.雷射CDLabel);
            this.Controls.Add(this.小荊棘CDLabel);
            this.Controls.Add(this.小荊棘ComboBox);
            this.Controls.Add(this.雷射ComboBox);
            this.Controls.Add(this.荊棘延遲ComboBox);
            this.Controls.Add(this.控場ComboBox);
            this.Controls.Add(this.重置計時器ComboBox);
            this.Controls.Add(this.重置計時器Label);
            this.Controls.Add(this.荊棘延遲TextBox);
            this.Controls.Add(this.荊棘延遲Label);
            this.Controls.Add(this.雷射TextBox);
            this.Controls.Add(this.雷射Label);
            this.Controls.Add(this.小荊棘TextBox);
            this.Controls.Add(this.小荊棘Label);
            this.Controls.Add(this.控場TextBox);
            this.Controls.Add(this.WindowsSetting);
            this.Controls.Add(this.TopMostCheckBox);
            this.Controls.Add(this.控場Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CloseControlBox);
            this.Controls.Add(this.ZoomOutControlBox);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ElsClockStrikesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.State = MetroSuite.MetroForm.FormState.Custom;
            this.Style = MetroSuite.Design.Style.Custom;
            this.Text = "ElsClockStrikes | Author by DC:  .le._.vi.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElsClockStrikesForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.ElsClockStrikesForm_Resize);
            this.音效設定GroupBox.ResumeLayout(false);
            this.音效設定GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer 控場Timer;
        private System.Windows.Forms.Label 控場Label;
        private Guna.UI.WinForms.GunaCheckBox TopMostCheckBox;
        private Guna.UI.WinForms.GunaButton WindowsSetting;
        private Guna.UI.WinForms.GunaLineTextBox 控場TextBox;
        private Guna.UI.WinForms.GunaLineTextBox 小荊棘TextBox;
        private System.Windows.Forms.Label 小荊棘Label;
        private Guna.UI.WinForms.GunaLineTextBox 雷射TextBox;
        private System.Windows.Forms.Label 雷射Label;
        private Guna.UI.WinForms.GunaLineTextBox 荊棘延遲TextBox;
        private System.Windows.Forms.Label 荊棘延遲Label;
        private System.Windows.Forms.Label 重置計時器Label;
        private Guna.UI.WinForms.GunaComboBox 重置計時器ComboBox;
        private Guna.UI.WinForms.GunaComboBox 控場ComboBox;
        private Guna.UI.WinForms.GunaComboBox 荊棘延遲ComboBox;
        private Guna.UI.WinForms.GunaComboBox 雷射ComboBox;
        private Guna.UI.WinForms.GunaComboBox 小荊棘ComboBox;
        private Guna.UI.WinForms.GunaControlBox CloseControlBox;
        private Guna.UI.WinForms.GunaControlBox ZoomOutControlBox;
        private System.Windows.Forms.Timer 荊棘延遲Timer;
        private System.Windows.Forms.Timer 雷射Timer;
        private System.Windows.Forms.Timer 小荊棘Timer;
        private System.Windows.Forms.Label 小荊棘CDLabel;
        private System.Windows.Forms.Label 雷射CDLabel;
        private System.Windows.Forms.Label 荊棘延遲CDLabel;
        private System.Windows.Forms.Label 控場CDLabel;
        private System.Windows.Forms.Label 小荊棘按鍵Label;
        private System.Windows.Forms.Label 雷射按鍵Label;
        private System.Windows.Forms.Label 荊棘延遲按鍵Label;
        private System.Windows.Forms.Label 控場按鍵Label;
        private System.Windows.Forms.Label 重置計時器按鍵Label;
        private Guna.UI.WinForms.GunaButton 小荊棘設定音效Button;
        private Guna.UI.WinForms.GunaButton 雷射設定音效Button;
        private Guna.UI.WinForms.GunaButton 荊棘延遲設定音效Button;
        private Guna.UI.WinForms.GunaButton 控場設定音效Button;
        private System.Windows.Forms.GroupBox 音效設定GroupBox;
        private Guna.UI.WinForms.GunaRadioButton 預設音效RadioButton;
        private Guna.UI.WinForms.GunaRadioButton 自訂音效RadioButton;
        private Guna.UI.WinForms.GunaRadioButton 關閉音效RadioButton;
        private System.Windows.Forms.Label label2;
    }
}


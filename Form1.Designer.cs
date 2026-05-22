namespace TowerOfHanoi
{
    partial class TowerForm
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
            this.components = new System.ComponentModel.Container();
            this.diskAmount = new System.Windows.Forms.NumericUpDown();
            this.diskAmountLabel = new System.Windows.Forms.Label();
            this.solveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.movesLabel = new System.Windows.Forms.Label();
            this.movesAmount = new System.Windows.Forms.Label();
            this.towerBar = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.auxLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            this.fromRod_Location = new System.Windows.Forms.Panel();
            this.rod1 = new System.Windows.Forms.Label();
            this.fromRod = new System.Windows.Forms.TableLayoutPanel();
            this.d11 = new System.Windows.Forms.Label();
            this.d10 = new System.Windows.Forms.Label();
            this.d9 = new System.Windows.Forms.Label();
            this.d1 = new System.Windows.Forms.Label();
            this.d2 = new System.Windows.Forms.Label();
            this.d8 = new System.Windows.Forms.Label();
            this.d7 = new System.Windows.Forms.Label();
            this.d6 = new System.Windows.Forms.Label();
            this.d5 = new System.Windows.Forms.Label();
            this.d3 = new System.Windows.Forms.Label();
            this.d4 = new System.Windows.Forms.Label();
            this.optimalAmount = new System.Windows.Forms.Label();
            this.optimalLabel = new System.Windows.Forms.Label();
            this.autoSolveLabel = new System.Windows.Forms.Label();
            this.delayAmount = new System.Windows.Forms.TextBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.elapsedLabel = new System.Windows.Forms.Label();
            this.elapsedTimer = new System.Windows.Forms.Timer(this.components);
            this.auxRod_Panel = new System.Windows.Forms.Panel();
            this.rod2 = new System.Windows.Forms.Label();
            this.auxRod = new System.Windows.Forms.TableLayoutPanel();
            this.toRod_Panel = new System.Windows.Forms.Panel();
            this.rod3 = new System.Windows.Forms.Label();
            this.toRod = new System.Windows.Forms.TableLayoutPanel();
            this.limitedMode = new System.Windows.Forms.CheckBox();
            this.methodGuide = new System.Windows.Forms.ToolTip(this.components);
            this.hybridPlayCheck = new System.Windows.Forms.CheckBox();
            this.otherOptionsPanel = new System.Windows.Forms.Panel();
            this.showDraggedDiskBox = new System.Windows.Forms.CheckBox();
            this.showDiskClickBox = new System.Windows.Forms.CheckBox();
            this.showDiskDragBox = new System.Windows.Forms.CheckBox();
            this.showOtherOptions = new System.Windows.Forms.CheckBox();
            this.labelTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.diskAmount)).BeginInit();
            this.fromRod_Location.SuspendLayout();
            this.fromRod.SuspendLayout();
            this.auxRod_Panel.SuspendLayout();
            this.toRod_Panel.SuspendLayout();
            this.otherOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // diskAmount
            // 
            this.diskAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diskAmount.Location = new System.Drawing.Point(303, 463);
            this.diskAmount.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.diskAmount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.diskAmount.Name = "diskAmount";
            this.diskAmount.Size = new System.Drawing.Size(40, 26);
            this.diskAmount.TabIndex = 0;
            this.diskAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.diskAmount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.diskAmount.ValueChanged += new System.EventHandler(this.DiskAmount_ValueChanged);
            this.diskAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DiskAmount_KeyDown);
            // 
            // diskAmountLabel
            // 
            this.diskAmountLabel.AutoSize = true;
            this.diskAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diskAmountLabel.Location = new System.Drawing.Point(171, 465);
            this.diskAmountLabel.Name = "diskAmountLabel";
            this.diskAmountLabel.Size = new System.Drawing.Size(127, 20);
            this.diskAmountLabel.TabIndex = 1;
            this.diskAmountLabel.Text = "Number of disks:";
            // 
            // solveButton
            // 
            this.solveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solveButton.Location = new System.Drawing.Point(523, 459);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(120, 34);
            this.solveButton.TabIndex = 2;
            this.solveButton.Text = "Show solution";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(658, 459);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(61, 34);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // movesLabel
            // 
            this.movesLabel.AutoSize = true;
            this.movesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movesLabel.Location = new System.Drawing.Point(171, 423);
            this.movesLabel.Name = "movesLabel";
            this.movesLabel.Size = new System.Drawing.Size(141, 20);
            this.movesLabel.TabIndex = 4;
            this.movesLabel.Text = "Number of moves: ";
            // 
            // movesAmount
            // 
            this.movesAmount.AutoSize = true;
            this.movesAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movesAmount.Location = new System.Drawing.Point(306, 423);
            this.movesAmount.Name = "movesAmount";
            this.movesAmount.Size = new System.Drawing.Size(18, 20);
            this.movesAmount.TabIndex = 5;
            this.movesAmount.Text = "0";
            this.movesAmount.TextChanged += new System.EventHandler(this.MovesAmount_TextChanged);
            // 
            // towerBar
            // 
            this.towerBar.AutoSize = true;
            this.towerBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.towerBar.Location = new System.Drawing.Point(3, 305);
            this.towerBar.Name = "towerBar";
            this.towerBar.Size = new System.Drawing.Size(1117, 73);
            this.towerBar.TabIndex = 11;
            this.towerBar.Text = "_______________________________";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.Location = new System.Drawing.Point(175, 380);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(44, 20);
            this.startLabel.TabIndex = 12;
            this.startLabel.Text = "Start";
            // 
            // auxLabel
            // 
            this.auxLabel.AutoSize = true;
            this.auxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auxLabel.Location = new System.Drawing.Point(524, 380);
            this.auxLabel.Name = "auxLabel";
            this.auxLabel.Size = new System.Drawing.Size(66, 20);
            this.auxLabel.TabIndex = 13;
            this.auxLabel.Text = "Auxiliary";
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destLabel.Location = new System.Drawing.Point(874, 380);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(90, 20);
            this.destLabel.TabIndex = 14;
            this.destLabel.Text = "Destination";
            // 
            // fromRod_Location
            // 
            this.fromRod_Location.AllowDrop = true;
            this.fromRod_Location.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fromRod_Location.Controls.Add(this.rod1);
            this.fromRod_Location.Controls.Add(this.fromRod);
            this.fromRod_Location.Location = new System.Drawing.Point(22, 65);
            this.fromRod_Location.Margin = new System.Windows.Forms.Padding(0);
            this.fromRod_Location.Name = "fromRod_Location";
            this.fromRod_Location.Size = new System.Drawing.Size(355, 306);
            this.fromRod_Location.TabIndex = 22;
            this.fromRod_Location.DragDrop += new System.Windows.Forms.DragEventHandler(this.ToRod_Panel_DragDrop);
            this.fromRod_Location.DragEnter += new System.Windows.Forms.DragEventHandler(this.AuxRod_Panel_DragEnter);
            this.fromRod_Location.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AuxRod_Panel_MouseClick);
            this.fromRod_Location.MouseEnter += new System.EventHandler(this.AuxRod_Panel_MouseEnter);
            // 
            // rod1
            // 
            this.rod1.AllowDrop = true;
            this.rod1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rod1.BackColor = System.Drawing.Color.Black;
            this.rod1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rod1.Location = new System.Drawing.Point(174, 18);
            this.rod1.Margin = new System.Windows.Forms.Padding(0);
            this.rod1.Name = "rod1";
            this.rod1.Size = new System.Drawing.Size(6, 288);
            this.rod1.TabIndex = 11;
            this.rod1.Text = " ";
            this.rod1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rod1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Rod1_DragDrop);
            this.rod1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Rod3_DragEnter);
            this.rod1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Rod1_MouseClick);
            this.rod1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Rod1_MouseDown);
            this.rod1.MouseEnter += new System.EventHandler(this.Rod3_MouseEnter);
            // 
            // fromRod
            // 
            this.fromRod.AllowDrop = true;
            this.fromRod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fromRod.ColumnCount = 1;
            this.fromRod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fromRod.Controls.Add(this.d11, 0, 10);
            this.fromRod.Controls.Add(this.d10, 0, 9);
            this.fromRod.Controls.Add(this.d9, 0, 8);
            this.fromRod.Controls.Add(this.d1, 0, 0);
            this.fromRod.Controls.Add(this.d2, 0, 1);
            this.fromRod.Controls.Add(this.d8, 0, 7);
            this.fromRod.Controls.Add(this.d7, 0, 6);
            this.fromRod.Controls.Add(this.d6, 0, 5);
            this.fromRod.Controls.Add(this.d5, 0, 4);
            this.fromRod.Controls.Add(this.d3, 0, 2);
            this.fromRod.Controls.Add(this.d4, 0, 3);
            this.fromRod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fromRod.Location = new System.Drawing.Point(0, 42);
            this.fromRod.Margin = new System.Windows.Forms.Padding(0);
            this.fromRod.Name = "fromRod";
            this.fromRod.RowCount = 11;
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.fromRod.Size = new System.Drawing.Size(355, 265);
            this.fromRod.TabIndex = 14;
            this.fromRod.DragDrop += new System.Windows.Forms.DragEventHandler(this.FromRod_DragDrop);
            this.fromRod.DragEnter += new System.Windows.Forms.DragEventHandler(this.FromRod_DragEnter);
            this.fromRod.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FromRod_MouseClick);
            this.fromRod.MouseEnter += new System.EventHandler(this.AuxRod_MouseEnter);
            this.fromRod.MouseLeave += new System.EventHandler(this.AuxRod_MouseLeave);
            // 
            // d11
            // 
            this.d11.AllowDrop = true;
            this.d11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d11.BackColor = System.Drawing.Color.Teal;
            this.d11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d11.ForeColor = System.Drawing.Color.Teal;
            this.d11.Location = new System.Drawing.Point(7, 240);
            this.d11.Margin = new System.Windows.Forms.Padding(0);
            this.d11.Name = "d11";
            this.d11.Size = new System.Drawing.Size(340, 24);
            this.d11.TabIndex = 36;
            this.d11.Text = "11";
            this.d11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d11.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d11.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d10
            // 
            this.d10.AllowDrop = true;
            this.d10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d10.BackColor = System.Drawing.Color.RosyBrown;
            this.d10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d10.ForeColor = System.Drawing.Color.RosyBrown;
            this.d10.Location = new System.Drawing.Point(22, 216);
            this.d10.Margin = new System.Windows.Forms.Padding(0);
            this.d10.Name = "d10";
            this.d10.Size = new System.Drawing.Size(310, 24);
            this.d10.TabIndex = 35;
            this.d10.Text = "10";
            this.d10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d10.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d10.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d9
            // 
            this.d9.AllowDrop = true;
            this.d9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d9.BackColor = System.Drawing.Color.Indigo;
            this.d9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d9.ForeColor = System.Drawing.Color.Indigo;
            this.d9.Location = new System.Drawing.Point(37, 192);
            this.d9.Margin = new System.Windows.Forms.Padding(0);
            this.d9.Name = "d9";
            this.d9.Size = new System.Drawing.Size(280, 24);
            this.d9.TabIndex = 9;
            this.d9.Text = "9";
            this.d9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d9.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d9.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d1
            // 
            this.d1.AllowDrop = true;
            this.d1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d1.BackColor = System.Drawing.Color.ForestGreen;
            this.d1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d1.ForeColor = System.Drawing.Color.ForestGreen;
            this.d1.Location = new System.Drawing.Point(157, 0);
            this.d1.Margin = new System.Windows.Forms.Padding(0);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(40, 24);
            this.d1.TabIndex = 1;
            this.d1.Text = "1";
            this.d1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d1.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d1.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d2
            // 
            this.d2.AllowDrop = true;
            this.d2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d2.BackColor = System.Drawing.Color.Blue;
            this.d2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d2.ForeColor = System.Drawing.Color.Blue;
            this.d2.Location = new System.Drawing.Point(142, 24);
            this.d2.Margin = new System.Windows.Forms.Padding(0);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(70, 24);
            this.d2.TabIndex = 2;
            this.d2.Text = "2";
            this.d2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d2.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d2.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d8
            // 
            this.d8.AllowDrop = true;
            this.d8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d8.BackColor = System.Drawing.Color.Sienna;
            this.d8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d8.ForeColor = System.Drawing.Color.Sienna;
            this.d8.Location = new System.Drawing.Point(52, 168);
            this.d8.Margin = new System.Windows.Forms.Padding(0);
            this.d8.Name = "d8";
            this.d8.Size = new System.Drawing.Size(250, 24);
            this.d8.TabIndex = 8;
            this.d8.Text = "8";
            this.d8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d8.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d8.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d7
            // 
            this.d7.AllowDrop = true;
            this.d7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d7.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.d7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d7.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.d7.Location = new System.Drawing.Point(67, 144);
            this.d7.Margin = new System.Windows.Forms.Padding(0);
            this.d7.Name = "d7";
            this.d7.Size = new System.Drawing.Size(220, 24);
            this.d7.TabIndex = 7;
            this.d7.Text = "7";
            this.d7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d7.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d7.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d6
            // 
            this.d6.AllowDrop = true;
            this.d6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d6.BackColor = System.Drawing.Color.DimGray;
            this.d6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d6.ForeColor = System.Drawing.Color.DimGray;
            this.d6.Location = new System.Drawing.Point(82, 120);
            this.d6.Margin = new System.Windows.Forms.Padding(0);
            this.d6.Name = "d6";
            this.d6.Size = new System.Drawing.Size(190, 24);
            this.d6.TabIndex = 6;
            this.d6.Text = "6";
            this.d6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d6.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d6.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d5
            // 
            this.d5.AllowDrop = true;
            this.d5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.d5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.d5.Location = new System.Drawing.Point(97, 96);
            this.d5.Margin = new System.Windows.Forms.Padding(0);
            this.d5.Name = "d5";
            this.d5.Size = new System.Drawing.Size(160, 24);
            this.d5.TabIndex = 5;
            this.d5.Text = "5";
            this.d5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d5.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d5.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d3
            // 
            this.d3.AllowDrop = true;
            this.d3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.d3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.d3.Location = new System.Drawing.Point(127, 48);
            this.d3.Margin = new System.Windows.Forms.Padding(0);
            this.d3.Name = "d3";
            this.d3.Size = new System.Drawing.Size(100, 24);
            this.d3.TabIndex = 3;
            this.d3.Text = "3";
            this.d3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d3.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d3.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // d4
            // 
            this.d4.AllowDrop = true;
            this.d4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.d4.BackColor = System.Drawing.Color.Olive;
            this.d4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d4.ForeColor = System.Drawing.Color.Olive;
            this.d4.Location = new System.Drawing.Point(112, 72);
            this.d4.Margin = new System.Windows.Forms.Padding(0);
            this.d4.Name = "d4";
            this.d4.Size = new System.Drawing.Size(130, 24);
            this.d4.TabIndex = 4;
            this.d4.Text = "4";
            this.d4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.d4.DragDrop += new System.Windows.Forms.DragEventHandler(this.D2_DragDrop);
            this.d4.DragEnter += new System.Windows.Forms.DragEventHandler(this.D11_DragEnter);
            // 
            // optimalAmount
            // 
            this.optimalAmount.AutoSize = true;
            this.optimalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optimalAmount.Location = new System.Drawing.Point(528, 423);
            this.optimalAmount.Name = "optimalAmount";
            this.optimalAmount.Size = new System.Drawing.Size(18, 20);
            this.optimalAmount.TabIndex = 24;
            this.optimalAmount.Text = "0";
            // 
            // optimalLabel
            // 
            this.optimalLabel.AutoSize = true;
            this.optimalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optimalLabel.Location = new System.Drawing.Point(363, 423);
            this.optimalLabel.Name = "optimalLabel";
            this.optimalLabel.Size = new System.Drawing.Size(165, 20);
            this.optimalLabel.TabIndex = 23;
            this.optimalLabel.Text = "Least possible moves:";
            // 
            // autoSolveLabel
            // 
            this.autoSolveLabel.AutoSize = true;
            this.autoSolveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoSolveLabel.Location = new System.Drawing.Point(433, 22);
            this.autoSolveLabel.Name = "autoSolveLabel";
            this.autoSolveLabel.Size = new System.Drawing.Size(0, 20);
            this.autoSolveLabel.TabIndex = 25;
            // 
            // delayAmount
            // 
            this.delayAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.delayAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delayAmount.Location = new System.Drawing.Point(480, 463);
            this.delayAmount.Name = "delayAmount";
            this.delayAmount.Size = new System.Drawing.Size(24, 26);
            this.delayAmount.TabIndex = 26;
            this.delayAmount.Text = "1";
            this.delayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.delayAmount.TextChanged += new System.EventHandler(this.DelayAmount_TextChanged);
            this.delayAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelayAmount_KeyDown);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delayLabel.Location = new System.Drawing.Point(359, 466);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(119, 20);
            this.delayLabel.TabIndex = 27;
            this.delayLabel.Text = "Solution speed:";
            // 
            // helpButton
            // 
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.Location = new System.Drawing.Point(735, 457);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(61, 39);
            this.helpButton.TabIndex = 28;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedTimeLabel.Location = new System.Drawing.Point(690, 423);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(71, 20);
            this.elapsedTimeLabel.TabIndex = 32;
            this.elapsedTimeLabel.Text = "00:00:00";
            // 
            // elapsedLabel
            // 
            this.elapsedLabel.AutoSize = true;
            this.elapsedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elapsedLabel.Location = new System.Drawing.Point(586, 423);
            this.elapsedLabel.Name = "elapsedLabel";
            this.elapsedLabel.Size = new System.Drawing.Size(105, 20);
            this.elapsedLabel.TabIndex = 31;
            this.elapsedLabel.Text = "Elapsed time:";
            // 
            // elapsedTimer
            // 
            this.elapsedTimer.Enabled = true;
            // 
            // auxRod_Panel
            // 
            this.auxRod_Panel.AllowDrop = true;
            this.auxRod_Panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.auxRod_Panel.Controls.Add(this.rod2);
            this.auxRod_Panel.Controls.Add(this.auxRod);
            this.auxRod_Panel.Location = new System.Drawing.Point(381, 65);
            this.auxRod_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.auxRod_Panel.Name = "auxRod_Panel";
            this.auxRod_Panel.Size = new System.Drawing.Size(355, 306);
            this.auxRod_Panel.TabIndex = 33;
            this.auxRod_Panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.ToRod_Panel_DragDrop);
            this.auxRod_Panel.DragEnter += new System.Windows.Forms.DragEventHandler(this.AuxRod_Panel_DragEnter);
            this.auxRod_Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AuxRod_Panel_MouseClick);
            this.auxRod_Panel.MouseEnter += new System.EventHandler(this.AuxRod_Panel_MouseEnter);
            // 
            // rod2
            // 
            this.rod2.AllowDrop = true;
            this.rod2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rod2.BackColor = System.Drawing.SystemColors.Desktop;
            this.rod2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rod2.Location = new System.Drawing.Point(174, 18);
            this.rod2.Margin = new System.Windows.Forms.Padding(0);
            this.rod2.Name = "rod2";
            this.rod2.Size = new System.Drawing.Size(6, 288);
            this.rod2.TabIndex = 12;
            this.rod2.Text = " ";
            this.rod2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rod2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Rod1_DragDrop);
            this.rod2.DragEnter += new System.Windows.Forms.DragEventHandler(this.Rod3_DragEnter);
            this.rod2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Rod1_MouseClick);
            this.rod2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Rod1_MouseDown);
            this.rod2.MouseEnter += new System.EventHandler(this.Rod3_MouseEnter);
            // 
            // auxRod
            // 
            this.auxRod.AllowDrop = true;
            this.auxRod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.auxRod.ColumnCount = 1;
            this.auxRod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.auxRod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.auxRod.Location = new System.Drawing.Point(0, 42);
            this.auxRod.Margin = new System.Windows.Forms.Padding(0);
            this.auxRod.Name = "auxRod";
            this.auxRod.RowCount = 11;
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.auxRod.Size = new System.Drawing.Size(355, 265);
            this.auxRod.TabIndex = 15;
            this.auxRod.DragDrop += new System.Windows.Forms.DragEventHandler(this.AuxRod_DragDrop1);
            this.auxRod.DragEnter += new System.Windows.Forms.DragEventHandler(this.AuxRod_DragEnter);
            this.auxRod.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AuxRod_MouseClick);
            this.auxRod.MouseEnter += new System.EventHandler(this.AuxRod_MouseEnter);
            this.auxRod.MouseLeave += new System.EventHandler(this.AuxRod_MouseLeave);
            // 
            // toRod_Panel
            // 
            this.toRod_Panel.AllowDrop = true;
            this.toRod_Panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toRod_Panel.Controls.Add(this.rod3);
            this.toRod_Panel.Controls.Add(this.toRod);
            this.toRod_Panel.Location = new System.Drawing.Point(741, 65);
            this.toRod_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.toRod_Panel.Name = "toRod_Panel";
            this.toRod_Panel.Size = new System.Drawing.Size(355, 306);
            this.toRod_Panel.TabIndex = 34;
            this.toRod_Panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.ToRod_Panel_DragDrop);
            this.toRod_Panel.DragEnter += new System.Windows.Forms.DragEventHandler(this.AuxRod_Panel_DragEnter);
            this.toRod_Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AuxRod_Panel_MouseClick);
            this.toRod_Panel.MouseEnter += new System.EventHandler(this.AuxRod_Panel_MouseEnter);
            // 
            // rod3
            // 
            this.rod3.AllowDrop = true;
            this.rod3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rod3.BackColor = System.Drawing.SystemColors.Desktop;
            this.rod3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rod3.Location = new System.Drawing.Point(174, 18);
            this.rod3.Margin = new System.Windows.Forms.Padding(0);
            this.rod3.Name = "rod3";
            this.rod3.Size = new System.Drawing.Size(6, 288);
            this.rod3.TabIndex = 11;
            this.rod3.Text = " ";
            this.rod3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rod3.DragDrop += new System.Windows.Forms.DragEventHandler(this.Rod1_DragDrop);
            this.rod3.DragEnter += new System.Windows.Forms.DragEventHandler(this.Rod3_DragEnter);
            this.rod3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Rod1_MouseClick);
            this.rod3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Rod1_MouseDown);
            this.rod3.MouseEnter += new System.EventHandler(this.Rod3_MouseEnter);
            // 
            // toRod
            // 
            this.toRod.AllowDrop = true;
            this.toRod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toRod.ColumnCount = 1;
            this.toRod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toRod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toRod.Location = new System.Drawing.Point(0, 42);
            this.toRod.Margin = new System.Windows.Forms.Padding(0);
            this.toRod.Name = "toRod";
            this.toRod.RowCount = 11;
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.toRod.Size = new System.Drawing.Size(355, 265);
            this.toRod.TabIndex = 14;
            this.toRod.DragDrop += new System.Windows.Forms.DragEventHandler(this.ToRod_DragDrop);
            this.toRod.DragEnter += new System.Windows.Forms.DragEventHandler(this.ToRod_DragEnter);
            this.toRod.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ToRod_MouseClick);
            this.toRod.MouseEnter += new System.EventHandler(this.AuxRod_MouseEnter);
            this.toRod.MouseLeave += new System.EventHandler(this.AuxRod_MouseLeave);
            // 
            // limitedMode
            // 
            this.limitedMode.AutoSize = true;
            this.limitedMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitedMode.Location = new System.Drawing.Point(815, 463);
            this.limitedMode.Name = "limitedMode";
            this.limitedMode.Size = new System.Drawing.Size(129, 24);
            this.limitedMode.TabIndex = 35;
            this.limitedMode.Text = "Limited moves";
            this.limitedMode.UseVisualStyleBackColor = true;
            this.limitedMode.CheckedChanged += new System.EventHandler(this.LimitedMode_CheckedChanged);
            // 
            // methodGuide
            // 
            this.methodGuide.AutomaticDelay = 100;
            this.methodGuide.AutoPopDelay = 8000;
            this.methodGuide.InitialDelay = 100;
            this.methodGuide.ReshowDelay = 20;
            // 
            // hybridPlayCheck
            // 
            this.hybridPlayCheck.AutoSize = true;
            this.hybridPlayCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hybridPlayCheck.Location = new System.Drawing.Point(12, 10);
            this.hybridPlayCheck.Name = "hybridPlayCheck";
            this.hybridPlayCheck.Size = new System.Drawing.Size(202, 24);
            this.hybridPlayCheck.TabIndex = 36;
            this.hybridPlayCheck.Text = "Always show clicked disc";
            this.hybridPlayCheck.UseVisualStyleBackColor = true;
            // 
            // otherOptionsPanel
            // 
            this.otherOptionsPanel.Controls.Add(this.showDraggedDiskBox);
            this.otherOptionsPanel.Controls.Add(this.showDiskClickBox);
            this.otherOptionsPanel.Controls.Add(this.hybridPlayCheck);
            this.otherOptionsPanel.Controls.Add(this.showDiskDragBox);
            this.otherOptionsPanel.Location = new System.Drawing.Point(72, 451);
            this.otherOptionsPanel.Name = "otherOptionsPanel";
            this.otherOptionsPanel.Size = new System.Drawing.Size(979, 44);
            this.otherOptionsPanel.TabIndex = 37;
            // 
            // showDraggedDiskBox
            // 
            this.showDraggedDiskBox.AutoSize = true;
            this.showDraggedDiskBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDraggedDiskBox.Location = new System.Drawing.Point(226, 10);
            this.showDraggedDiskBox.Name = "showDraggedDiskBox";
            this.showDraggedDiskBox.Size = new System.Drawing.Size(213, 24);
            this.showDraggedDiskBox.TabIndex = 39;
            this.showDraggedDiskBox.Text = "Always show dragged disc";
            this.showDraggedDiskBox.UseVisualStyleBackColor = true;
            // 
            // showDiskClickBox
            // 
            this.showDiskClickBox.AutoSize = true;
            this.showDiskClickBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDiskClickBox.Location = new System.Drawing.Point(453, 10);
            this.showDiskClickBox.Name = "showDiskClickBox";
            this.showDiskClickBox.Size = new System.Drawing.Size(248, 24);
            this.showDiskClickBox.TabIndex = 37;
            this.showDiskClickBox.Text = "Disable visual cue for click-drop";
            this.showDiskClickBox.UseVisualStyleBackColor = true;
            // 
            // showDiskDragBox
            // 
            this.showDiskDragBox.AutoSize = true;
            this.showDiskDragBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDiskDragBox.Location = new System.Drawing.Point(717, 10);
            this.showDiskDragBox.Name = "showDiskDragBox";
            this.showDiskDragBox.Size = new System.Drawing.Size(250, 24);
            this.showDiskDragBox.TabIndex = 38;
            this.showDiskDragBox.Text = "Disable visual cue for drag-drop";
            this.showDiskDragBox.UseVisualStyleBackColor = true;
            // 
            // showOtherOptions
            // 
            this.showOtherOptions.AutoSize = true;
            this.showOtherOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showOtherOptions.Location = new System.Drawing.Point(779, 421);
            this.showOtherOptions.Name = "showOtherOptions";
            this.showOtherOptions.Size = new System.Drawing.Size(165, 24);
            this.showOtherOptions.TabIndex = 38;
            this.showOtherOptions.Text = "Show other options";
            this.showOtherOptions.UseVisualStyleBackColor = true;
            this.showOtherOptions.CheckedChanged += new System.EventHandler(this.ShowOtherOptions_CheckedChanged);
            // 
            // labelTimer
            // 
            this.labelTimer.Enabled = true;
            this.labelTimer.Interval = 1000;
            this.labelTimer.Tick += new System.EventHandler(this.LabelTimer_Tick);
            // 
            // TowerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1118, 511);
            this.Controls.Add(this.otherOptionsPanel);
            this.Controls.Add(this.showOtherOptions);
            this.Controls.Add(this.limitedMode);
            this.Controls.Add(this.auxRod_Panel);
            this.Controls.Add(this.toRod_Panel);
            this.Controls.Add(this.elapsedTimeLabel);
            this.Controls.Add(this.elapsedLabel);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.delayAmount);
            this.Controls.Add(this.autoSolveLabel);
            this.Controls.Add(this.optimalAmount);
            this.Controls.Add(this.optimalLabel);
            this.Controls.Add(this.fromRod_Location);
            this.Controls.Add(this.destLabel);
            this.Controls.Add(this.auxLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.movesAmount);
            this.Controls.Add(this.movesLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.diskAmountLabel);
            this.Controls.Add(this.diskAmount);
            this.Controls.Add(this.towerBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "TowerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tower of Hanoi";
            this.Load += new System.EventHandler(this.TowerForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TowerForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TowerForm_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.TowerForm_DragOver);
            this.DragLeave += new System.EventHandler(this.TowerForm_DragLeave);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TowerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.diskAmount)).EndInit();
            this.fromRod_Location.ResumeLayout(false);
            this.fromRod.ResumeLayout(false);
            this.auxRod_Panel.ResumeLayout(false);
            this.toRod_Panel.ResumeLayout(false);
            this.otherOptionsPanel.ResumeLayout(false);
            this.otherOptionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown diskAmount;
        private System.Windows.Forms.Label diskAmountLabel;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label movesLabel;
        private System.Windows.Forms.Label movesAmount;
        private System.Windows.Forms.Label towerBar;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label auxLabel;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.Panel fromRod_Location;
        private System.Windows.Forms.Label rod1;
        private System.Windows.Forms.TableLayoutPanel fromRod;       
        private System.Windows.Forms.Label d1;
        private System.Windows.Forms.Label d2;
        private System.Windows.Forms.Label d3;
        private System.Windows.Forms.Label d4;
        private System.Windows.Forms.Label d5;
        private System.Windows.Forms.Label d6;
        private System.Windows.Forms.Label d7;
        private System.Windows.Forms.Label d8;
        private System.Windows.Forms.Label d9;
        private System.Windows.Forms.Label d10;
        private System.Windows.Forms.Label d11;  
        private System.Windows.Forms.Label optimalAmount;
        private System.Windows.Forms.Label optimalLabel;
        private System.Windows.Forms.Label autoSolveLabel;
        private System.Windows.Forms.TextBox delayAmount;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Label elapsedLabel;
        private System.Windows.Forms.Timer elapsedTimer;
        private System.Windows.Forms.Panel auxRod_Panel;        
        private System.Windows.Forms.TableLayoutPanel auxRod;
        private System.Windows.Forms.Panel toRod_Panel;
        private System.Windows.Forms.TableLayoutPanel toRod;
        private System.Windows.Forms.Label rod3;
        private System.Windows.Forms.Label rod2;
        private System.Windows.Forms.CheckBox limitedMode;
        private System.Windows.Forms.ToolTip methodGuide;
        private System.Windows.Forms.CheckBox hybridPlayCheck;
        private System.Windows.Forms.Panel otherOptionsPanel;
        private System.Windows.Forms.CheckBox showDiskClickBox;
        private System.Windows.Forms.CheckBox showDiskDragBox;
        private System.Windows.Forms.CheckBox showDraggedDiskBox;
        private System.Windows.Forms.CheckBox showOtherOptions;
        private System.Windows.Forms.Timer labelTimer;
    }
}


using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerOfHanoi
{
    public partial class TowerForm : Form
    {
        static bool freshGame = true;
        static int moves = 0;
        private DateTime startTime;
        static bool timeStarted = false;
        static bool autoSolveOn = false;
        static bool solveCancelled = false;
        static string formattedInterval;
        static int transferDelay = 1;
        private Label selectedDisk = null;
        private Label copiedDisk = new Label();
        private Label draggedDisk = null;
        private CancellationTokenSource cancellationTokenSource;
        static bool panelRecentlyClosed = false;
        static bool diskCopied = false;
        static bool firstIteration = true;
        private readonly int radius = 10;  // Modify value to alter curvature

        public TowerForm()
        {
            InitializeComponent();
            copiedDisk.MouseClick += CopiedDisk_MouseClick;
            copiedDisk.AllowDrop = true;
            copiedDisk.DragEnter += CopiedDisk_DragEnter;
            copiedDisk.DragDrop += CopiedDisk_DragDrop;
            methodGuide.SetToolTip(limitedMode, "When enabled, the puzzle needs to be solved\nwithin the least amount of possible moves only.");
            methodGuide.SetToolTip(solveButton, "When clicked, the puzzle will be solved\nautomatically by the program.");
            methodGuide.SetToolTip(hybridPlayCheck, "If the user wishes to click a disk, and then use the keyboard to drop the disk\nThis checkbox must be checked to prevent the disc from disappearing on the rod");
            methodGuide.SetToolTip(showDraggedDiskBox, "When checked, the disc being dragged will always appear on the original rod location");
            methodGuide.SetToolTip(showDiskClickBox, "When checked, the selected disc with Right/Middle mouse click will not appear on top of the rods.");
            methodGuide.SetToolTip(showDiskDragBox, "When checked, the disc being dragged will not appear on top of the rods.");
            methodGuide.SetToolTip(resetButton, "When clicked, the puzzle will be reverted back to a fresh state.\nIf a solution is being demonstrated, this will stop the demonstration.");
            methodGuide.SetToolTip(delayAmount, "Enter 0 - 5 to indicate the demonstration speed for showing the solution.\n0 means no delay, 1 being the fastest, 5 being the slowest.");
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            MakeDiskRound();
        }

        private void MakeDiskRound()
        {
            foreach (Label disk in fromRod.Controls) { RecreateRegion(disk); }
        }

        private void TowerForm_Load(object sender, EventArgs e)
        {
            DiskAmount_ValueChanged(sender, e);
            otherOptionsPanel.Visible = false;
        }

        private void DiskAmount_ValueChanged(object sender, EventArgs e)
        {
            if (freshGame == false)
            {
                DialogResult notice = MessageBox.Show("Please reset the game first before changing the amount of disks", "Game already started", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (notice == DialogResult.OK) { }
                return;
            }
            if (autoSolveOn == true)
            {
                DialogResult notice = MessageBox.Show("Please click the Reset button to cancel auto-solve", "Auto-solve enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (notice == DialogResult.OK) { }
                return;
            }
            int disk = Convert.ToInt32(diskAmount.Value);
            double optimal = Math.Pow(2, disk) - 1;
            optimalAmount.Text = optimal.ToString();
            switch (diskAmount.Value)
            {
                case 2:
                    fromRod.Controls.Remove(d3);
                    fromRod.Controls.Remove(d4);
                    fromRod.Controls.Remove(d5);
                    fromRod.Controls.Remove(d6);
                    fromRod.Controls.Remove(d7);
                    fromRod.Controls.Remove(d8);
                    fromRod.Controls.Remove(d9);
                    fromRod.Controls.Remove(d10);
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 9);
                    fromRod.Controls.Add(d2, 0, 10);
                    break;
                case 3:
                    fromRod.Controls.Remove(d4);
                    fromRod.Controls.Remove(d5);
                    fromRod.Controls.Remove(d6);
                    fromRod.Controls.Remove(d7);
                    fromRod.Controls.Remove(d8);
                    fromRod.Controls.Remove(d9);
                    fromRod.Controls.Remove(d10);
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 8);
                    fromRod.Controls.Add(d2, 0, 9);
                    fromRod.Controls.Add(d3, 0, 10);
                    break;
                case 4:
                    fromRod.Controls.Remove(d5);
                    fromRod.Controls.Remove(d6);
                    fromRod.Controls.Remove(d7);
                    fromRod.Controls.Remove(d8);
                    fromRod.Controls.Remove(d9);
                    fromRod.Controls.Remove(d10);
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 7);
                    fromRod.Controls.Add(d2, 0, 8);
                    fromRod.Controls.Add(d3, 0, 9);
                    fromRod.Controls.Add(d4, 0, 10);
                    break;
                case 5:
                    fromRod.Controls.Remove(d6);
                    fromRod.Controls.Remove(d7);
                    fromRod.Controls.Remove(d8);
                    fromRod.Controls.Remove(d9);
                    fromRod.Controls.Remove(d10);
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 6);
                    fromRod.Controls.Add(d2, 0, 7);
                    fromRod.Controls.Add(d3, 0, 8);
                    fromRod.Controls.Add(d4, 0, 9);
                    fromRod.Controls.Add(d5, 0, 10);
                    break;
                case 6:
                    fromRod.Controls.Remove(d7);
                    fromRod.Controls.Remove(d8);
                    fromRod.Controls.Remove(d9);
                    fromRod.Controls.Remove(d10);
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 5);
                    fromRod.Controls.Add(d2, 0, 6);
                    fromRod.Controls.Add(d3, 0, 7);
                    fromRod.Controls.Add(d4, 0, 8);
                    fromRod.Controls.Add(d5, 0, 9);
                    fromRod.Controls.Add(d6, 0, 10);
                    break;
                case 7:
                    fromRod.Controls.Remove(d8);
                    fromRod.Controls.Remove(d9);
                    fromRod.Controls.Remove(d10);
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 4);
                    fromRod.Controls.Add(d2, 0, 5);
                    fromRod.Controls.Add(d3, 0, 6);
                    fromRod.Controls.Add(d4, 0, 7);
                    fromRod.Controls.Add(d5, 0, 8);
                    fromRod.Controls.Add(d6, 0, 9);
                    fromRod.Controls.Add(d7, 0, 10);
                    break;
                case 8:
                    fromRod.Controls.Remove(d9);
                    fromRod.Controls.Remove(d10);
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 3);
                    fromRod.Controls.Add(d2, 0, 4);
                    fromRod.Controls.Add(d3, 0, 5);
                    fromRod.Controls.Add(d4, 0, 6);
                    fromRod.Controls.Add(d5, 0, 7);
                    fromRod.Controls.Add(d6, 0, 8);
                    fromRod.Controls.Add(d7, 0, 9);
                    fromRod.Controls.Add(d8, 0, 10);
                    break;
                case 9:
                    fromRod.Controls.Remove(d10);
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 2);
                    fromRod.Controls.Add(d2, 0, 3);
                    fromRod.Controls.Add(d3, 0, 4);
                    fromRod.Controls.Add(d4, 0, 5);
                    fromRod.Controls.Add(d5, 0, 6);
                    fromRod.Controls.Add(d6, 0, 7);
                    fromRod.Controls.Add(d7, 0, 8);
                    fromRod.Controls.Add(d8, 0, 9);
                    fromRod.Controls.Add(d9, 0, 10);
                    break;
                case 10:
                    fromRod.Controls.Remove(d11);
                    fromRod.Controls.Add(d1, 0, 1);
                    fromRod.Controls.Add(d2, 0, 2);
                    fromRod.Controls.Add(d3, 0, 3);
                    fromRod.Controls.Add(d4, 0, 4);
                    fromRod.Controls.Add(d5, 0, 5);
                    fromRod.Controls.Add(d6, 0, 6);
                    fromRod.Controls.Add(d7, 0, 7);
                    fromRod.Controls.Add(d8, 0, 8);
                    fromRod.Controls.Add(d9, 0, 9);
                    fromRod.Controls.Add(d10, 0, 10);
                    break;
                case 11:
                    fromRod.Controls.Add(d1, 0, 0);
                    fromRod.Controls.Add(d2, 0, 1);
                    fromRod.Controls.Add(d3, 0, 2);
                    fromRod.Controls.Add(d4, 0, 3);
                    fromRod.Controls.Add(d5, 0, 4);
                    fromRod.Controls.Add(d6, 0, 5);
                    fromRod.Controls.Add(d7, 0, 6);
                    fromRod.Controls.Add(d8, 0, 7);
                    fromRod.Controls.Add(d9, 0, 8);
                    fromRod.Controls.Add(d10, 0, 9);
                    fromRod.Controls.Add(d11, 0, 10);
                    break;
            }
        }

        private async void ResetPuzzle()
        {
            await Task.Delay(100);
            copiedDisk.Visible = false; autoSolveLabel.Text = "";
            solveCancelled = true; selectedDisk = null;
            copiedDisk = new Label(); draggedDisk = null;
            moves = 0; movesAmount.Text = moves.ToString(); elapsedTimer.Stop();
            elapsedTimeLabel.Text = "00:00:00"; timeStarted = false;
            freshGame = true; autoSolveOn = false;

            TableLayoutPanel diskLoc = FindRodContainingDisk(d1, fromRod, auxRod, toRod);
            d1.MouseDown -= D1_MouseDown;
            d1.Visible = true;
            diskLoc.Controls.Remove(d1);
            int placement = fromRod.RowCount - int.Parse(diskAmount.Text);
            fromRod.Controls.Add(d1, 0, placement);

            diskLoc = FindRodContainingDisk(d2, fromRod, auxRod, toRod);
            d2.MouseDown -= D1_MouseDown;
            d2.Visible = true;
            diskLoc.Controls.Remove(d2);
            placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 1;
            fromRod.Controls.Add(d2, 0, placement);

            if (d3.Parent != null)
            {
                diskLoc = FindRodContainingDisk(d3, fromRod, auxRod, toRod);
                d3.MouseDown -= D1_MouseDown;
                d3.Visible = true;
                diskLoc.Controls.Remove(d3);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 2;
                fromRod.Controls.Add(d3, 0, placement);
            }
            if (d4.Parent != null)
            {
                diskLoc = FindRodContainingDisk(d4, fromRod, auxRod, toRod);
                d4.MouseDown -= D1_MouseDown;
                d4.Visible = true;
                diskLoc.Controls.Remove(d4);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 3;
                fromRod.Controls.Add(d4, 0, placement);
            }
            if (d5.Parent != null)
            {
                diskLoc = FindRodContainingDisk(d5, fromRod, auxRod, toRod);
                d5.MouseDown -= D1_MouseDown;
                d5.Visible = true;
                diskLoc.Controls.Remove(d5);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 4;
                fromRod.Controls.Add(d5, 0, placement);
            }
            if (d6.Parent != null && d6.Visible == true)
            {
                diskLoc = FindRodContainingDisk(d6, fromRod, auxRod, toRod);
                d6.MouseDown -= D1_MouseDown;
                d6.Visible = true;
                diskLoc.Controls.Remove(d6);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 5;
                fromRod.Controls.Add(d6, 0, placement);
            }
            if (d7.Parent != null)
            {
                diskLoc = FindRodContainingDisk(d7, fromRod, auxRod, toRod);
                d7.MouseDown -= D1_MouseDown;
                d7.Visible = true;
                diskLoc.Controls.Remove(d7);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 6;
                fromRod.Controls.Add(d7, 0, placement);
            }
            if (d8.Parent != null)
            {
                diskLoc = FindRodContainingDisk(d8, fromRod, auxRod, toRod);
                d8.MouseDown -= D1_MouseDown;
                d8.Visible = true;
                diskLoc.Controls.Remove(d8);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 7;
                fromRod.Controls.Add(d8, 0, placement);
            }
            if (d9.Parent != null)
            {
                diskLoc = FindRodContainingDisk(d9, fromRod, auxRod, toRod);
                d9.MouseDown -= D1_MouseDown;
                d9.Visible = true;
                diskLoc.Controls.Remove(d9);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 8;
                fromRod.Controls.Add(d9, 0, placement);
            }
            if (d10.Parent != null)
            {
                diskLoc = FindRodContainingDisk(d10, fromRod, auxRod, toRod);
                d10.MouseDown -= D1_MouseDown;
                d10.Visible = true;
                diskLoc.Controls.Remove(d10);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 9;
                fromRod.Controls.Add(d10, 0, placement);
            }
            if (d11.Parent != null)
            {
                diskLoc = FindRodContainingDisk(d11, fromRod, auxRod, toRod);
                d11.MouseDown -= D1_MouseDown;
                d11.Visible = true;
                diskLoc.Controls.Remove(d11);
                placement = fromRod.RowCount - int.Parse(diskAmount.Text) + 10;
                fromRod.Controls.Add(d11, 0, placement);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (autoSolveOn == true) { CancelAutoSolve(); }
            ResetPuzzle();
        }

        private void ElapsedTimer_Tick(object sender, EventArgs e)
        {
            // Calculate the elapsed time since the start time
            TimeSpan elapsedTime = DateTime.Now - startTime;

            formattedInterval = $"{(int)elapsedTime.TotalHours}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";

            // Update the elapsed time display
            elapsedTimeLabel.Text = $"{elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}";
        }      

        public void EnableMouseInteractionForTopmostDisk(TableLayoutPanel rod)
        {
            if (rod.Controls.Count == 0) { return; }
            int topMostDisk = rod.RowCount - rod.Controls.Count;
            Label topDisk = (Label)rod.GetControlFromPosition(0, topMostDisk);
            if (topDisk != null)
            {
                topDisk.MouseDown -= D1_MouseDown;
                topDisk.MouseDown += D1_MouseDown;
            }
        }

        private void DummyMouseDown(object sender, EventArgs e) { return; }

        private void DisableMouseInteractionForNonTopmostDisks(TableLayoutPanel rod)
        {
            if (rod.InvokeRequired)
            {
                // Invoke the method on the UI thread
                rod.Invoke(new Action(() => DisableMouseInteractionForNonTopmostDisks(rod)));
                return;
            }
            int topmostDiskIndex = rod.RowCount - rod.Controls.Count;
            if (rod.Controls.Count == 0) { return; }
            foreach (Label control in rod.Controls)
            {
                // Check if the disk is not the topmost one in the rod
                if (rod.GetRow(control) != topmostDiskIndex)
                {
                    // If the disk is not the topmost one, disable mouse interaction
                    control.MouseDown -= D1_MouseDown;
                    control.MouseDown += DummyMouseDown;

                    // Optionally, you can change the cursor to indicate that the disk is not selectable
                    control.Cursor = Cursors.No;
                }
                else if (rod.GetRow(control) == topmostDiskIndex)
                {
                    control.MouseDown -= DummyMouseDown;
                    control.MouseDown += D1_MouseDown;
                    control.Cursor = Cursors.Default;
                }
            }
        }

        private void AuxRod_MouseEnter(object sender, EventArgs e)
        {
            TableLayoutPanel rod = (TableLayoutPanel)sender;           
            if (selectedDisk != null)
            {
                if (hybridPlayCheck.Checked == false) { selectedDisk.Visible = false; }
                if (hybridPlayCheck.Checked == true) { selectedDisk.Visible = true; }
                if (showDiskClickBox.Checked == false)
                {
                    Point location = new Point();
                    // if (rod == selectedDisk.Parent) { return; }
                    if (rod == fromRod)
                    {
                        if (selectedDisk == d1) { location = new Point(178, 58); }
                        else if (selectedDisk == d2) { location = new Point(163, 58); }
                        else if (selectedDisk == d3) { location = new Point(146, 58); }
                        else if (selectedDisk == d4) { location = new Point(132, 58); }
                        else if (selectedDisk == d5) { location = new Point(119, 58); }
                        else if (selectedDisk == d6) { location = new Point(105, 58); }
                        else if (selectedDisk == d7) { location = new Point(93, 58); }
                        else if (selectedDisk == d8) { location = new Point(78, 58); }
                        else if (selectedDisk == d9) { location = new Point(62, 58); }
                        else if (selectedDisk == d10) { location = new Point(45, 58); }
                        else if (selectedDisk == d11) { location = new Point(27, 58); }
                    }
                    else if (rod == auxRod)
                    {
                        if (selectedDisk == d1) { location = new Point(538, 58); }
                        else if (selectedDisk == d2) { location = new Point(521, 58); }
                        else if (selectedDisk == d3) { location = new Point(505, 58); }
                        else if (selectedDisk == d4) { location = new Point(491, 58); }
                        else if (selectedDisk == d5) { location = new Point(477, 58); }
                        else if (selectedDisk == d6) { location = new Point(464, 58); }
                        else if (selectedDisk == d7) { location = new Point(451, 58); }
                        else if (selectedDisk == d8) { location = new Point(435, 58); }
                        else if (selectedDisk == d9) { location = new Point(419, 58); }
                        else if (selectedDisk == d10) { location = new Point(402, 58); }
                        else if (selectedDisk == d11) { location = new Point(387, 58); }
                    }
                    else if (rod == toRod)
                    {
                        if (selectedDisk == d1) { location = new Point(898, 58); }
                        else if (selectedDisk == d2) { location = new Point(881, 58); }
                        else if (selectedDisk == d3) { location = new Point(864, 58); }
                        else if (selectedDisk == d4) { location = new Point(850, 58); }
                        else if (selectedDisk == d5) { location = new Point(836, 58); }
                        else if (selectedDisk == d6) { location = new Point(823, 58); }
                        else if (selectedDisk == d7) { location = new Point(809, 58); }
                        else if (selectedDisk == d8) { location = new Point(793, 58); }
                        else if (selectedDisk == d9) { location = new Point(777, 58); }
                        else if (selectedDisk == d10) { location = new Point(760, 58); }
                        else if (selectedDisk == d11) { location = new Point(745, 58); }
                    }
                    copiedDisk.Size = selectedDisk.Size;
                    copiedDisk.Visible = true;
                    copiedDisk.Enabled = true;
                    copiedDisk.BackColor = selectedDisk.BackColor;
                    copiedDisk.Location = location;
                    copiedDisk.ForeColor = selectedDisk.ForeColor;
                    copiedDisk.Text = selectedDisk.Text;
                    RecreateRegion(copiedDisk);
                    if (diskCopied == false)
                    {
                        this.Controls.Add(copiedDisk);
                        diskCopied = true;
                    }
                    copiedDisk.BringToFront(); copiedDisk.BringToFront();
                }
            }
            EnableMouseInteractionForTopmostDisk(rod);
        }

        private void AuxRod_MouseLeave(object sender, EventArgs e)
        {
            if (copiedDisk != null) { copiedDisk.Visible = true; }
        }

        private void TowerForm_DragDrop(object sender, DragEventArgs e)
        {
            if (draggedDisk != null)
            {
                if (copiedDisk != null)
                {
                    copiedDisk.Visible = false;
                    this.Controls.Remove(copiedDisk);
                    diskCopied = false;
                }
                if (draggedDisk == d1) { d1.Visible = true; }
                else if (draggedDisk == d2) { d2.Visible = true; }
                else if (draggedDisk == d3) { d3.Visible = true; }
                else if (draggedDisk == d4) { d4.Visible = true; }
                else if (draggedDisk == d5) { d5.Visible = true; }
                else if (draggedDisk == d6) { d6.Visible = true; }
                else if (draggedDisk == d7) { d7.Visible = true; }
                else if (draggedDisk == d8) { d8.Visible = true; }
                else if (draggedDisk == d9) { d9.Visible = true; }
                else if (draggedDisk == d10) { d10.Visible = true; }
                else if (draggedDisk == d11) { d11.Visible = true; }
            }
        }

        private void TowerForm_DragLeave(object sender, EventArgs e)
        {
            // Check if a drag-and-drop operation is in progress
            if (draggedDisk != null)
            {
                if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
                if (draggedDisk == d1) { d1.Visible = true; }
                else if (draggedDisk == d2) { d2.Visible = true; }
                else if (draggedDisk == d3) { d3.Visible = true; }
                else if (draggedDisk == d4) { d4.Visible = true; }
                else if (draggedDisk == d5) { d5.Visible = true; }
                else if (draggedDisk == d6) { d6.Visible = true; }
                else if (draggedDisk == d7) { d7.Visible = true; }
                else if (draggedDisk == d8) { d8.Visible = true; }
                else if (draggedDisk == d9) { d9.Visible = true; }
                else if (draggedDisk == d10) { d10.Visible = true; }
                else if (draggedDisk == d11) { d11.Visible = true; }
            }
        }

        private void TowerForm_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the data being dragged is of the expected type
            if (e.Data.GetDataPresent(typeof(Label)))
            {
                e.Effect = DragDropEffects.Move; // Set the drag-and-drop effect              
                if (draggedDisk != null && draggedDisk.Visible == true)
                {
                    if (showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
                }
            }
        }

        private void TowerForm_DragOver(object sender, DragEventArgs e)
        {
            Point clientPoint = this.PointToClient(new Point(e.X, e.Y));
            // Check if the mouse position is within the bounds of the MainForm's client area
            if (this.ClientRectangle.Contains(clientPoint))
            {
                // Mouse is within the bounds, allow the drag-and-drop operation
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                // Mouse is outside the bounds, prevent the drag-and-drop operation
                e.Effect = DragDropEffects.None;
            }
            Rectangle clientRect = this.ClientRectangle;
            // Constrain the cursor position to stay within the client area
            Point clientCursorPos = this.PointToClient(new Point(e.X, e.Y));
            int constrainedX = Math.Max(clientRect.Left, Math.Min(clientCursorPos.X, clientRect.Right));
            int constrainedY = Math.Max(clientRect.Top, Math.Min(clientCursorPos.Y, clientRect.Bottom));
            // Set the cursor position
            Cursor.Position = this.PointToScreen(new Point(constrainedX, constrainedY));
            if (copiedDisk != null && showDiskDragBox.Checked == false) { copiedDisk.Visible = true; }
            else if (copiedDisk != null && showDiskDragBox.Checked == true) { copiedDisk.Visible = false; }
            if (draggedDisk != null && showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
            else if (draggedDisk != null && showDraggedDiskBox.Checked == true) { draggedDisk.Visible = true; }
        }

        private void D1_MouseDown(object sender, MouseEventArgs e)
        {
            if (autoSolveOn == true)
            {
                DialogResult notice = MessageBox.Show("Please click the Reset button to cancel auto-solve", "Auto-solve enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (notice == DialogResult.OK) { }
                return;
            }
            Label control = sender as Label;
            if (control != null && e.Button == MouseButtons.Left)
            {
                if (selectedDisk != null) { selectedDisk.Visible = true; }
                freshGame = false;
                draggedDisk = control;
                selectedDisk = null;
                if (showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
                control.DoDragDrop(control, DragDropEffects.Move);
                InitiateElapsedTime(); return;
            }
            if (control != null && e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                if (selectedDisk != null) { selectedDisk.Visible = true; }
                selectedDisk = control;
                draggedDisk = null;
                if (hybridPlayCheck.Checked == false) { selectedDisk.Visible = false; }
                else if (hybridPlayCheck.Checked == true) { selectedDisk.Visible = true; }
                freshGame = false;
                InitiateElapsedTime(); return;
            }
        }

        private async void PrintCurrentRod(TableLayoutPanel rod)
        {
            string rodName = "";
            if (rod == fromRod) { rodName = "Starting"; }
            else if (rod == auxRod) { rodName = "Auxiliary"; }
            else if (rod == toRod) { rodName = "Destination"; }
            autoSolveLabel.Text = $"Selected topmost disk of {rodName} Rod";
            Stopwatch stopwatch = Stopwatch.StartNew();
            await Task.WhenAny(Task.Delay(5000));
            // Check if 5 seconds have passed
            if (stopwatch.Elapsed >= TimeSpan.FromSeconds(5))
            {
                autoSolveLabel.Text = ""; // Clear the label
            }
        }

        private async void PrintEmpty(TableLayoutPanel rod)
        {
            string rodName = "";
            if (rod == fromRod) { rodName = "Starting"; }
            else if (rod == auxRod) { rodName = "Auxiliary"; }
            else if (rod == toRod) { rodName = "Destination"; }
            autoSolveLabel.Text = $"{rodName} Rod does not contain a disk";
            Stopwatch stopwatch = Stopwatch.StartNew(); // Start a new stopwatch for each call
            await Task.WhenAny(Task.Delay(5000));
            if (stopwatch.Elapsed >= TimeSpan.FromSeconds(5))
            {
                autoSolveLabel.Text = ""; // Clear the label
            }
        }

        private void InitiateElapsedTime()
        {
            if (timeStarted == false)
            {
                elapsedTimer.Tick += ElapsedTimer_Tick;
                startTime = DateTime.Now;
                timeStarted = true;
                elapsedTimer.Start();
            }
        }

        private void TowerForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (panelRecentlyClosed == true)
            {
                if (e.KeyCode == Keys.Q || e.KeyCode == Keys.Z)
                { if (fromRod.Focused == false) { fromRod.Focus(); } }
                else if (e.KeyCode == Keys.W || e.KeyCode == Keys.X)
                { if (auxRod.Focused == false) { auxRod.Focus(); } }
                else if (e.KeyCode == Keys.E || e.KeyCode == Keys.C)
                { if (toRod.Focused == false) { toRod.Focus(); } }
                panelRecentlyClosed = false;
            }
            if (hybridPlayCheck.Checked == true && selectedDisk != null) { selectedDisk.Visible = true; }
            if (freshGame == true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (diskAmount.Value + diskAmount.Increment <= diskAmount.Maximum)
                    {
                        // Increment value when Up arrow key is pressed
                        diskAmount.Value += diskAmount.Increment;
                    }
                    e.Handled = true; return; // Prevent default handling of the key
                }
                else if (e.KeyCode == Keys.Down)
                {
                    // Decrement value when Down arrow key is pressed
                    if (diskAmount.Value - diskAmount.Increment >= diskAmount.Minimum)
                    {
                        // Increment value when Up arrow key is pressed
                        diskAmount.Value -= diskAmount.Increment;
                    }
                    e.Handled = true; return; // Prevent default handling of the key
                }
            }
            if (autoSolveOn == true)
            {
                DialogResult notice = MessageBox.Show("Please click the Reset button to cancel auto-solve", "Auto-solve enabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (notice == DialogResult.OK) { }
                return;
            }
            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.Z)
            {
                if (fromRod.Controls.Count == 1)
                {
                    freshGame = false;
                    if (selectedDisk != null && selectedDisk.Visible == false) 
                    { 
                        selectedDisk.Visible = true;
                        this.Controls.Remove(copiedDisk); diskCopied = false;
                    }
                    selectedDisk = (Label)fromRod.GetControlFromPosition(0, fromRod.RowCount - 1);
                }
                else if (fromRod.Controls.Count > 1)
                {
                    freshGame = false;
                    if (selectedDisk != null && selectedDisk.Visible == false) 
                    { 
                        selectedDisk.Visible = true;
                        this.Controls.Remove(copiedDisk); diskCopied = false;
                    }
                    int topIndex = fromRod.RowCount - fromRod.Controls.Count;
                    selectedDisk = (Label)fromRod.GetControlFromPosition(0, topIndex);
                }
                else { PrintEmpty(fromRod); return; }
                PrintCurrentRod(fromRod);
                InitiateElapsedTime();
            }
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.X)
            {
                if (auxRod.Controls.Count == 1)
                {
                    freshGame = false;
                    if (selectedDisk != null && selectedDisk.Visible == false) 
                    {
                        selectedDisk.Visible = true;
                        this.Controls.Remove(copiedDisk); diskCopied = false;
                    }
                    selectedDisk = (Label)auxRod.GetControlFromPosition(0, auxRod.RowCount - 1);
                }
                else if (auxRod.Controls.Count > 1)
                {
                    freshGame = false;
                    if (selectedDisk != null && selectedDisk.Visible == false) 
                    { 
                        selectedDisk.Visible = true;
                        this.Controls.Remove(copiedDisk); diskCopied = false;
                    }
                    int topIndex = auxRod.RowCount - auxRod.Controls.Count;
                    selectedDisk = (Label)auxRod.GetControlFromPosition(0, topIndex);
                }
                else { PrintEmpty(auxRod); return; }
                PrintCurrentRod(auxRod);
                InitiateElapsedTime();
            }
            if (e.KeyCode == Keys.E || e.KeyCode == Keys.C)
            {
                if (toRod.Controls.Count == 1)
                {
                    freshGame = false;
                    if (selectedDisk != null && selectedDisk.Visible == false) 
                    { 
                        selectedDisk.Visible = true;
                        this.Controls.Remove(copiedDisk); diskCopied = false;
                    }
                    selectedDisk = (Label)toRod.GetControlFromPosition(0, toRod.RowCount - 1);
                }
                else if (toRod.Controls.Count > 1)
                {
                    freshGame = false;
                    if (selectedDisk != null && selectedDisk.Visible == false) 
                    { 
                        selectedDisk.Visible = true;
                        this.Controls.Remove(copiedDisk); diskCopied = false;
                    }
                    int topIndex = toRod.RowCount - toRod.Controls.Count;
                    selectedDisk = (Label)toRod.GetControlFromPosition(0, topIndex);
                }
                else { PrintEmpty(toRod); return; }
                PrintCurrentRod(toRod);
                InitiateElapsedTime();
            }
            if (selectedDisk != null)
            {
                InitiateElapsedTime(); freshGame = false;
                TableLayoutPanel target = FindRodContainingDisk(selectedDisk, fromRod, auxRod, toRod);
                if (e.KeyCode == Keys.Right)
                {
                    if (target == fromRod)
                    {
                        if (auxRod.Controls.Count == 0)
                        { MoveDiskToRod(selectedDisk, auxRod); selectedDisk = null; ++moves; }
                        else if (auxRod.Controls.Count > 0 && IsMoveValid(selectedDisk, auxRod) == true)
                        { MoveDiskToRod(selectedDisk, auxRod); selectedDisk = null; ++moves; }
                        else if (toRod.Controls.Count == 0)
                        { MoveDiskToRod(selectedDisk, toRod); selectedDisk = null; ++moves; }
                        else if (toRod.Controls.Count > 0 && IsMoveValid(selectedDisk, toRod) == true)
                        {
                            MoveDiskToRod(selectedDisk, toRod); ++moves;
                            if (toRod.Controls.Count == diskAmount.Value) { CheckCompletion(sender, e); }
                            selectedDisk = null;
                        }
                        else { InvalidPrint(); }
                        movesAmount.Text = moves.ToString();
                    }
                    if (target == auxRod)
                    {
                        if (toRod.Controls.Count == 0)
                        { MoveDiskToRod(selectedDisk, toRod); selectedDisk = null; ++moves; }
                        else if (toRod.Controls.Count > 0 && IsMoveValid(selectedDisk, toRod) == true)
                        {
                            MoveDiskToRod(selectedDisk, toRod); ++moves;
                            if (toRod.Controls.Count == diskAmount.Value) { CheckCompletion(sender, e); }
                            selectedDisk = null;
                        }
                        else { InvalidPrint(); }
                        movesAmount.Text = moves.ToString();
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    if (target == toRod)
                    {
                        if (auxRod.Controls.Count == 0)
                        { MoveDiskToRod(selectedDisk, auxRod); selectedDisk = null; ++moves; }
                        else if (auxRod.Controls.Count > 0 && IsMoveValid(selectedDisk, auxRod) == true)
                        { MoveDiskToRod(selectedDisk, auxRod); selectedDisk = null; ++moves; }
                        else if (fromRod.Controls.Count == 0)
                        { MoveDiskToRod(selectedDisk, fromRod); selectedDisk = null; ++moves; }
                        else if (fromRod.Controls.Count > 0 && IsMoveValid(selectedDisk, fromRod) == true)
                        { MoveDiskToRod(selectedDisk, fromRod); selectedDisk = null; ++moves; }
                        else { InvalidPrint(); }
                        movesAmount.Text = moves.ToString();
                    }
                    if (target == auxRod)
                    {
                        if (fromRod.Controls.Count == 0)
                        { MoveDiskToRod(selectedDisk, fromRod); selectedDisk = null; ++moves; }
                        else if (fromRod.Controls.Count > 0 && IsMoveValid(selectedDisk, fromRod) == true)
                        { MoveDiskToRod(selectedDisk, fromRod); selectedDisk = null; ++moves; }
                        else { InvalidPrint(); }
                        movesAmount.Text = moves.ToString();
                    }
                }
                else if (e.KeyCode == Keys.A)
                {
                    if (target == toRod)
                    {
                        if (fromRod.Controls.Count == 0)
                        { MoveDiskToRod(selectedDisk, fromRod); selectedDisk = null; ++moves; }
                        else if (fromRod.Controls.Count > 0 && IsMoveValid(selectedDisk, fromRod) == true)
                        { MoveDiskToRod(selectedDisk, fromRod); selectedDisk = null; ++moves; }
                        else { InvalidPrint(); }
                        movesAmount.Text = moves.ToString();
                    }
                }
                else if (e.KeyCode == Keys.D)
                {
                    if (target == fromRod)
                    {
                        if (toRod.Controls.Count == 0)
                        { MoveDiskToRod(selectedDisk, toRod); selectedDisk = null; ++moves; }
                        else if (toRod.Controls.Count > 0 && IsMoveValid(selectedDisk, toRod) == true)
                        {
                            MoveDiskToRod(selectedDisk, toRod); ++moves;
                            if (toRod.Controls.Count == diskAmount.Value) { CheckCompletion(sender, e); }
                            selectedDisk = null;
                        }
                        else { InvalidPrint(); }
                        movesAmount.Text = moves.ToString();
                    }
                }
            }
        }

        private async void CheckCompletion(object sender, EventArgs e)
        {
            await Task.Delay(100);
            bool disksInOrder = true;
            foreach (Label disk in toRod.Controls)
            {
                int currentRow = toRod.GetRow(disk);
                if (currentRow != (toRod.RowCount - 1))
                {
                    Label precedingDisk = toRod.GetControlFromPosition(0, currentRow + 1) as Label;
                    int currentSize = int.Parse(disk.Text), precedeSize = int.Parse(precedingDisk.Text);
                    if (precedeSize - currentSize != 1) { disksInOrder = false; break; }
                }
            }
            if (disksInOrder)
            {
                // All disks are placed in order with a difference of 1 between adjacent sizes
                if (movesAmount.Text.ToString() == optimalAmount.Text.ToString())
                {
                    elapsedTimer.Stop();
                    DialogResult notice = MessageBox.Show("Congratulations, you have solved the puzzle effortlessly!\nYour number of moves is optimal (" + movesAmount.Text + ")\nYour elapsed time is: " + formattedInterval, "Perfect puzzle completion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (notice == DialogResult.OK) { }
                    ResetPuzzle();
                }
                else
                {
                    elapsedTimer.Stop();
                    DialogResult notice = MessageBox.Show("Congratulations, you have solved the puzzle!\nYour number of moves is " + movesAmount.Text + "\nYour elapsed time is: " + formattedInterval, "Puzzle solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (notice == DialogResult.OK) { }
                    ResetPuzzle();
                }
            }
            else
            {
                // Disks are not placed in order or the difference between sizes is not 1
                MessageBox.Show("Disks are not placed in order", "Puzzle failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FromRod_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                if (selectedDisk != null && selectedDisk.Parent == fromRod)
                {
                    if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
                    selectedDisk.Visible = true;
                    selectedDisk = null; return;
                }
                if (selectedDisk != null)
                {
                    if (IsMoveValid(selectedDisk, fromRod) == true)
                    {
                        selectedDisk.Visible = true;
                        MoveDiskToRod(selectedDisk, fromRod);
                        ++moves; movesAmount.Text = moves.ToString();
                        selectedDisk = null;
                        if (copiedDisk != null) 
                        { 
                            copiedDisk.Visible = false;
                            copiedDisk.Text = "";
                            copiedDisk.BackColor = Color.Transparent;
                            copiedDisk.ForeColor = Color.Transparent;
                        }
                    }
                    else { InvalidPrint(); }
                }
            }
        }

        private void ToRod_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                if (selectedDisk != null)
                {
                    if (selectedDisk.Parent == toRod)
                    {
                        if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
                        selectedDisk.Visible = true;
                        selectedDisk = null; return;
                    }
                    if (IsMoveValid(selectedDisk, toRod) == true)
                    {
                        selectedDisk.Visible = true;
                        MoveDiskToRod(selectedDisk, toRod);
                        ++moves; movesAmount.Text = moves.ToString();
                        selectedDisk = null;
                        if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
                        if (toRod.Controls.Count == diskAmount.Value) { CheckCompletion(sender, e); }
                    }
                    else { InvalidPrint(); }
                }
            }
        }

        private void AuxRod_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                if (selectedDisk != null && selectedDisk.Parent == auxRod)
                {
                    if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
                    selectedDisk.Visible = true;
                    selectedDisk = null; return;
                }
                if (selectedDisk != null)
                {
                    if (IsMoveValid(selectedDisk, auxRod) == true)
                    {
                        selectedDisk.Visible = true;
                        MoveDiskToRod(selectedDisk, auxRod);
                        ++moves; movesAmount.Text = moves.ToString();
                        selectedDisk = null;
                        if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
                    }
                    else { InvalidPrint(); }
                }
            }
        }

        private TableLayoutPanel FindRodContainingDisk(Label cur_disk, params TableLayoutPanel[] rods)
        {
            /*
            foreach (TableLayoutPanel rod in rods)
            {
                foreach (Label disk in rod.Controls)
                {
                    if (disk.Name == cur_disk.Name)
                    {
                        return rod;
                    }
                }
            }
            */
            if (cur_disk.Parent == fromRod) { return fromRod; }
            else if (cur_disk.Parent == auxRod) { return auxRod; }
            else if (cur_disk.Parent == toRod) { return toRod; }
            return null;
        }

        private bool IsMoveValid(System.Windows.Forms.Label diskToMove, TableLayoutPanel destinationRod)
        {
            // Get the size of the disk being moved
            int sizeOfDiskToMove = int.Parse(diskToMove.Text);
            if (destinationRod.Controls.Count == 0) { return true; }

            // Find the topmost disk in the destination rod
            int topMostIndex = destinationRod.RowCount - destinationRod.Controls.Count;
            Label topDisk = (Label)destinationRod.GetControlFromPosition(0, topMostIndex);

            // If there's no topmost disk or if the size of the topmost disk is larger than the disk being moved, the move is valid
            if (int.Parse(topDisk.Text) >= sizeOfDiskToMove) { return true; }
            else { return false; } // A smaller disk is found on top, move is invalid   
        }

        private void AuxRod_DragDrop1(object sender, DragEventArgs e)
        {
            if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
            if (selectedDisk != null) { selectedDisk = null; }
            TableLayoutPanel target = sender as TableLayoutPanel;
            if (e.Data.GetDataPresent(typeof(System.Windows.Forms.Label)))
            {
                System.Windows.Forms.Label control = (System.Windows.Forms.Label)e.Data.GetData(typeof(System.Windows.Forms.Label));
                if (control.Parent == target)
                {
                    control.Visible = true; copiedDisk.Visible = false; return;  // The disk is being dropped back onto its original rod, so do nothing
                }
                if (auxRod.Controls.Count >= 1)
                {
                    if (IsMoveValid(control, auxRod) == false)
                    { control.Visible = true; copiedDisk.Visible = false; InvalidPrint(); return; }
                }
                // control.Parent.Controls.Remove(control);
                control.Visible = true;
                draggedDisk = null;
                MoveDiskToRod(control, auxRod);
                ++moves; movesAmount.Text = moves.ToString();
                /* Do not remove!
                // Determine the location relative to the destination TableLayoutPanel
                Point clientPoint = target.PointToClient(new Point(e.X, e.Y));

                // Calculate the row and column index based on the client coordinates
                int row = -1;
                int column = -1;
                for (int i = 0; i < target.RowCount; i++)
                {
                    if (clientPoint.Y >= target.GetRowHeights()[i] * i &&
                        clientPoint.Y <= target.GetRowHeights()[i] * (i + 1))
                    {
                        row = i;
                        break;
                    }
                }

                for (int j = 0; j < target.ColumnCount; j++)
                {
                    if (clientPoint.X >= target.GetColumnWidths()[j] * j && clientPoint.X <= target.GetColumnWidths()[j] * (j + 1))
                    {
                        column = j;
                        break;
                    }
                }

                // Set the row and column for the dropped label
                if (row >= 0 && column >= 0)
                {
                    target.Controls.Add(control, column, row);
                }

                // Add the control to the destination TableLayoutPanel
                control.Location = clientPoint;
                target.Controls.Add(control);
                */
            }
            return;
        }

        private void AuxRod_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            if (showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
            if (showDiskDragBox.Checked == false)
            {
                if (draggedDisk != null)
                {
                    Point location = new Point();
                    // if (draggedDisk.Parent == rod) { return; }
                    if (draggedDisk == d1) { location = new Point(538, 58); }
                    else if (draggedDisk == d2) { location = new Point(521, 58); }
                    else if (draggedDisk == d3) { location = new Point(505, 58); }
                    else if (draggedDisk == d4) { location = new Point(491, 58); }
                    else if (draggedDisk == d5) { location = new Point(477, 58); }
                    else if (draggedDisk == d6) { location = new Point(464, 58); }
                    else if (draggedDisk == d7) { location = new Point(451, 58); }
                    else if (draggedDisk == d8) { location = new Point(435, 58); }
                    else if (draggedDisk == d9) { location = new Point(419, 58); }
                    else if (draggedDisk == d10) { location = new Point(402, 58); }
                    else if (draggedDisk == d11) { location = new Point(387, 58); }
                    copiedDisk.Size = draggedDisk.Size;
                    copiedDisk.Visible = true;
                    copiedDisk.Enabled = true;
                    copiedDisk.BackColor = draggedDisk.BackColor;
                    copiedDisk.Location = location;
                    copiedDisk.ForeColor = draggedDisk.ForeColor;
                    copiedDisk.Text = draggedDisk.Text;
                    RecreateRegion(copiedDisk);
                    if (diskCopied == false)
                    {
                        this.Controls.Add(copiedDisk);
                        diskCopied = true;
                    }
                    copiedDisk.BringToFront(); copiedDisk.BringToFront();
                }
            }
        }

        private void FromRod_DragDrop(object sender, DragEventArgs e)
        {
            if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
            if (selectedDisk != null) { selectedDisk = null; }
            TableLayoutPanel target = sender as TableLayoutPanel;
            if (e.Data.GetDataPresent(typeof(System.Windows.Forms.Label)))
            {
                System.Windows.Forms.Label control = (System.Windows.Forms.Label)e.Data.GetData(typeof(System.Windows.Forms.Label));
                if (control.Parent == target)
                {
                    control.Visible = true;
                    copiedDisk.Visible = false; return;  // The disk is being dropped back onto its original rod, so do nothing
                }
                if (fromRod.Controls.Count >= 1)
                {
                    if (IsMoveValid(control, fromRod) == false)
                    { control.Visible = true; copiedDisk.Visible = false; InvalidPrint(); return; }
                }
                // control.Parent.Controls.Remove(control);
                control.Visible = true;
                draggedDisk = null;
                MoveDiskToRod(control, fromRod);
                ++moves; movesAmount.Text = moves.ToString();
            }
            return;
        }

        private void FromRod_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            if (showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
            if (showDiskDragBox.Checked == false)
            {
                if (draggedDisk != null)
                {
                    Point location = new Point();
                    // if (draggedDisk.Parent == rod) { return; }
                    if (draggedDisk == d1) { location = new Point(178, 58); }
                    else if (draggedDisk == d2) { location = new Point(163, 58); }
                    else if (draggedDisk == d3) { location = new Point(146, 58); }
                    else if (draggedDisk == d4) { location = new Point(132, 58); }
                    else if (draggedDisk == d5) { location = new Point(119, 58); }
                    else if (draggedDisk == d6) { location = new Point(105, 58); }
                    else if (draggedDisk == d7) { location = new Point(93, 58); }
                    else if (draggedDisk == d8) { location = new Point(78, 58); }
                    else if (draggedDisk == d9) { location = new Point(62, 58); }
                    else if (draggedDisk == d10) { location = new Point(45, 58); }
                    else if (draggedDisk == d11) { location = new Point(27, 58); }
                    copiedDisk.Size = draggedDisk.Size;
                    copiedDisk.Visible = true;
                    copiedDisk.Enabled = true;
                    copiedDisk.BackColor = draggedDisk.BackColor;
                    copiedDisk.Location = location;
                    copiedDisk.ForeColor = draggedDisk.ForeColor;
                    copiedDisk.Text = draggedDisk.Text;
                    RecreateRegion(copiedDisk);
                    if (diskCopied == false)
                    {
                        this.Controls.Add(copiedDisk);
                        diskCopied = true;
                    }
                    copiedDisk.BringToFront(); copiedDisk.BringToFront();
                }
            }
        }

        private void ToRod_DragDrop(object sender, DragEventArgs e)
        {
            if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
            if (selectedDisk != null) { selectedDisk = null; }
            TableLayoutPanel target = sender as TableLayoutPanel;
            if (e.Data.GetDataPresent(typeof(System.Windows.Forms.Label)))
            {
                System.Windows.Forms.Label control = (System.Windows.Forms.Label)e.Data.GetData(typeof(System.Windows.Forms.Label));
                if (control.Parent == target)
                {
                    control.Visible = true; copiedDisk.Visible = false; return;  // The disk is being dropped back onto its original rod, so do nothing
                }
                if (toRod.Controls.Count >= 1)
                {
                    if (IsMoveValid(control, toRod) == false)
                    { control.Visible = true; copiedDisk.Visible = false; InvalidPrint(); return; }
                }
                // control.Parent.Controls.Remove(control);
                control.Visible = true;
                draggedDisk = null;
                MoveDiskToRod(control, toRod);
                ++moves; movesAmount.Text = moves.ToString();
                if (toRod.Controls.Count == diskAmount.Value) { CheckCompletion(sender, e); }
            }
            return;
        }

        private void ToRod_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            if (showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
            if (showDiskDragBox.Checked == false)
            {
                if (draggedDisk != null)
                {
                    Point location = new Point();
                    // if (draggedDisk.Parent == rod) { return; }
                    if (draggedDisk == d1) { location = new Point(898, 58); }
                    else if (draggedDisk == d2) { location = new Point(881, 58); }
                    else if (draggedDisk == d3) { location = new Point(864, 58); }
                    else if (draggedDisk == d4) { location = new Point(850, 58); }
                    else if (draggedDisk == d5) { location = new Point(836, 58); }
                    else if (draggedDisk == d6) { location = new Point(823, 58); }
                    else if (draggedDisk == d7) { location = new Point(809, 58); }
                    else if (draggedDisk == d8) { location = new Point(793, 58); }
                    else if (draggedDisk == d9) { location = new Point(777, 58); }
                    else if (draggedDisk == d10) { location = new Point(760, 58); }
                    else if (draggedDisk == d11) { location = new Point(745, 58); }
                    copiedDisk.Size = draggedDisk.Size;
                    copiedDisk.Visible = true;
                    copiedDisk.Enabled = true;
                    copiedDisk.BackColor = draggedDisk.BackColor;
                    copiedDisk.Location = location;
                    copiedDisk.ForeColor = draggedDisk.ForeColor;
                    copiedDisk.Text = draggedDisk.Text;
                    RecreateRegion(copiedDisk);
                    if (diskCopied == false)
                    {
                        this.Controls.Add(copiedDisk);
                        diskCopied = true;
                    }
                    copiedDisk.BringToFront(); copiedDisk.BringToFront();
                }
            }
        }

        private void MoveDiskToRod(Label diskToMove, TableLayoutPanel destinationRod)
        {
            if (diskToMove.Parent == destinationRod) { return; }
            if (destinationRod.InvokeRequired)
            {
                // If this method is called from a non-UI thread, invoke it on the UI thread
                destinationRod.Invoke(new Action(() => MoveDiskToRod(diskToMove, destinationRod)));
                return;
            }
            // diskToMove.MouseDown -= D1_MouseDown;
            if (destinationRod.Controls.Count == 0)
            {
                // If the rod is empty, place the disk in the last row of the TableLayoutPanel
                int lastRowIndex = destinationRod.RowCount - 1;
                destinationRod.Controls.Add(diskToMove, 0, lastRowIndex);
            }
            else
            {
                // Remove the mouse event of the disk beneath
                int currentTop = destinationRod.RowCount - destinationRod.Controls.Count;
                Label topDisk = (Label)destinationRod.GetControlFromPosition(0, currentTop);
                topDisk.MouseDown -= D1_MouseDown;
                // If the rod is not empty, place the disk on top of the existing disk
                int existingDisksCount = destinationRod.Controls.Count;
                int newRow = destinationRod.RowCount - existingDisksCount - 1;
                destinationRod.Controls.Add(diskToMove, 0, newRow);
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpForm formHelp = new HelpForm();
            formHelp.Show();
        }

        private void DelayAmount_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(delayAmount.Text, out transferDelay) == true)
            {
                if (transferDelay < 0) { transferDelay = 1; delayAmount.Text = "1"; return; }
                else if (transferDelay > 5) { transferDelay = 5; delayAmount.Text = "5"; return; }
            }
            else { transferDelay = 1; delayAmount.Text = ""; return; }
        }

        private async Task SolveTowerOfHanoi(int n, char from_rod, char to_rod, char aux_rod, CancellationToken cancellationToken)
        {
            if (solveCancelled == true || n == 0 || cancellationToken.IsCancellationRequested) { return; }
            // Move the top n-1 disks from the source rod to the auxiliary rod
            await Task.WhenAny(SolveTowerOfHanoi(n - 1, from_rod, aux_rod, to_rod, cancellationToken));
            if (cancellationToken.IsCancellationRequested) { return; }
            if (firstIteration == false && transferDelay != 0)
            {
                await Task.WhenAny(Task.Delay(transferDelay * 1000, cancellationToken));
                if (cancellationToken.IsCancellationRequested) { return; }
            }
            else if (firstIteration == true && transferDelay != 0)
            { 
                await Task.WhenAny(Task.Delay(500, cancellationToken));
                if (cancellationToken.IsCancellationRequested) { return; }
            }
            firstIteration = false;
            // Move the nth disk from the source rod to the destination rod           
            if (!solveCancelled && !cancellationToken.IsCancellationRequested)
            {
                if (GetTopDiskFromRod(from_rod) == null || GetRodByName(to_rod) == null) { return; }
                MoveDiskToRod(GetTopDiskFromRod(from_rod), GetRodByName(to_rod));
                autoSolveLabel.Text = $"Moving disk {n} from Rod {from_rod} to Rod {to_rod}";
                ++moves; movesAmount.Text = moves.ToString();
            }
            else { return; }
            
            if (cancellationToken.IsCancellationRequested) { return; }
            if (movesAmount.Text == optimalAmount.Text)
            {
                int delaySec = int.Parse(delayAmount.Text);
                if (delaySec == 0)
                {
                    DialogResult message = MessageBox.Show("The puzzle has been solved successfully", "Puzzle solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (message == DialogResult.OK) { }                 
                }
                else
                {
                    elapsedTimer.Stop();
                    DialogResult message = MessageBox.Show("The puzzle has been solved successfully\nElapsed time: " + formattedInterval, "Puzzle solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (message == DialogResult.OK) { }
                }
                autoSolveLabel.Text = ""; CancelAutoSolve(); ResetPuzzle();
            }

            // Move the top n-1 disks from the auxiliary rod to the destination rod
            if (cancellationToken.IsCancellationRequested) { return; }
            await Task.WhenAny(SolveTowerOfHanoi(n - 1, aux_rod, to_rod, from_rod, cancellationToken));
        }

        private void CancelAutoSolve()
        {
            // Cancel the auto-solve process if it's running
            firstIteration = true; solveCancelled = true;
            cancellationTokenSource?.Cancel();
            startLabel.Text = "Start";
            auxLabel.Text = "Auxiliary";
            destLabel.Text = "Destination";
            solveButton.Text = "Show solution";
            startLabel.Location = new Point(startLabel.Location.X + 2, startLabel.Location.Y);
            auxLabel.Location = new Point(auxLabel.Location.X + 2, auxLabel.Location.Y);
            destLabel.Location = new Point(destLabel.Location.X - 4, destLabel.Location.Y);
        }

        private async void SolveButton_Click(object sender, EventArgs e)
        {
            if (freshGame == false)
            {
                DialogResult notice = MessageBox.Show("Please click the Reset button first before using this feature", "Game initiated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (notice == DialogResult.OK) { }
                return;
            }
            if (autoSolveOn == true)
            {
                DialogResult notice = MessageBox.Show("Do you want to stop the program from showing the solution?", "Demonstration ongoing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (notice == DialogResult.Yes)
                {
                    CancelAutoSolve(); autoSolveOn = false; freshGame = false; solveCancelled = true;
                    MessageBox.Show("To show the solution again, please reset the puzzle", "Demonstration cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    autoSolveLabel.Text = ""; return;
                }
                return;
            }
            else if (autoSolveOn == false) { autoSolveOn = true; }
            int discVal = int.Parse(diskAmount.Text), delaySec = int.Parse(delayAmount.Text); ;
            elapsedTimer.Tick += ElapsedTimer_Tick;
            startTime = DateTime.Now;
            timeStarted = true; solveCancelled = false;
            if (delaySec > 0) { elapsedTimer.Start(); }
            if (transferDelay < 0 || transferDelay > 5) { transferDelay = 1; delayAmount.Text = "1"; }
            cancellationTokenSource = new CancellationTokenSource();
            startLabel.Text = "Rod A";
            startLabel.Location = new Point(startLabel.Location.X - 2, startLabel.Location.Y);
            auxLabel.Text = "  Rod B  ";
            auxLabel.Location = new Point(auxLabel.Location.X - 2, auxLabel.Location.Y);
            destLabel.Text = "   Rod C   ";
            destLabel.Location = new Point(destLabel.Location.X + 4, destLabel.Location.Y);
            solveButton.Text = "Stop solution";
            await SolveTowerOfHanoi(discVal, 'A', 'C', 'B', cancellationTokenSource.Token);
        }

        private Label GetTopDiskFromRod(char rodName)
        {
            if (rodName == 'A')
            {
                int topMostDisk = fromRod.RowCount - fromRod.Controls.Count;
                Label disk1 = (Label)fromRod.GetControlFromPosition(0, topMostDisk);
                return disk1;
            }
            else if (rodName == 'B')
            {
                int topMostDisk = auxRod.RowCount - auxRod.Controls.Count;
                Label disk2 = (Label)auxRod.GetControlFromPosition(0, topMostDisk);
                return disk2;
            }
            else if (rodName == 'C')
            {
                int topMostDisk = toRod.RowCount - toRod.Controls.Count;
                Label disk3 = (Label)toRod.GetControlFromPosition(0, topMostDisk);
                return disk3;
            }
            return null;
        }

        private TableLayoutPanel GetRodByName(char rodName)
        {
            TableLayoutPanel rod = null;
            if (rodName == 'A') { rod = fromRod; }
            if (rodName == 'B') { rod = auxRod; }
            if (rodName == 'C') { rod = toRod; }
            return rod;
        }
        
        private async void InvalidPrint()
        {
            autoSolveLabel.Text = "Invalid move, please check the disk";
            await Task.Delay(4000);
            autoSolveLabel.Text = "";
        }

        private void DelayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) { e.Handled = true; }
        }

        private void DiskAmount_KeyDown(object sender, KeyEventArgs e) { e.Handled = true; }

        private void MovesAmount_TextChanged(object sender, EventArgs e)
        {
            if (limitedMode.Checked == true)
            {
                int moves = int.Parse(movesAmount.Text), optimal = int.Parse(optimalAmount.Text);
                if (moves >= optimal && toRod.Controls.Count != (int)diskAmount.Value)
                {
                    DialogResult gameOver = MessageBox.Show("You have failed to solve the puzzle, better luck next time!\nElapsed time: " + formattedInterval, "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (gameOver == DialogResult.OK) { ResetPuzzle(); }
                    return;
                }
            }
        }

        private void LimitedMode_CheckedChanged(object sender, EventArgs e)
        {
            if (freshGame == false)
            {
                if (limitedMode.Checked == true)
                {
                    limitedMode.CheckedChanged -= LimitedMode_CheckedChanged;
                    limitedMode.Checked = false;
                    limitedMode.CheckedChanged += LimitedMode_CheckedChanged;
                    DialogResult notice = MessageBox.Show("Please reset the game first before enabling this game mode", "Game initiated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (notice == DialogResult.OK) { return; }
                }
                else
                {
                    limitedMode.CheckedChanged -= LimitedMode_CheckedChanged;
                    limitedMode.Checked = true;
                    limitedMode.CheckedChanged += LimitedMode_CheckedChanged;
                    DialogResult notice = MessageBox.Show("Please reset the game first before disabling this game mode", "Game initiated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (notice == DialogResult.OK) { return; }
                }
            }
        }

        private void ShowOtherOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (showOtherOptions.Checked == true) { otherOptionsPanel.Visible = true; panelRecentlyClosed = true; }
            else { otherOptionsPanel.Visible = false; panelRecentlyClosed = true; }
        }

        private void D11_DragEnter(object sender, DragEventArgs e) { e.Effect = DragDropEffects.Move; }

        private void D2_DragDrop(object sender, DragEventArgs e)
        {
            if (copiedDisk != null) { this.Controls.Remove(copiedDisk); diskCopied = false; }
            if (draggedDisk != null) { draggedDisk.Visible = true; }
        }

        private void Rod3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            Label rod = sender as Label;
            if (draggedDisk != null)
            {
                if (showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
                if (showDraggedDiskBox.Checked == true) { draggedDisk.Visible = true; }
                if (showDiskDragBox.Checked == false)
                {
                    Point location = new Point();
                    // if (rod == draggedDisk.Parent) { return; }
                    if (rod == rod1)
                    {
                        if (draggedDisk == d1) { location = new Point(178, 58); }
                        else if (draggedDisk == d2) { location = new Point(163, 58); }
                        else if (draggedDisk == d3) { location = new Point(146, 58); }
                        else if (draggedDisk == d4) { location = new Point(132, 58); }
                        else if (draggedDisk == d5) { location = new Point(119, 58); }
                        else if (draggedDisk == d6) { location = new Point(105, 58); }
                        else if (draggedDisk == d7) { location = new Point(93, 58); }
                        else if (draggedDisk == d8) { location = new Point(78, 58); }
                        else if (draggedDisk == d9) { location = new Point(62, 58); }
                        else if (draggedDisk == d10) { location = new Point(45, 58); }
                        else if (draggedDisk == d11) { location = new Point(27, 58); }
                    }
                    else if (rod == rod2)
                    {
                        if (draggedDisk == d1) { location = new Point(538, 58); }
                        else if (draggedDisk == d2) { location = new Point(521, 58); }
                        else if (draggedDisk == d3) { location = new Point(505, 58); }
                        else if (draggedDisk == d4) { location = new Point(491, 58); }
                        else if (draggedDisk == d5) { location = new Point(477, 58); }
                        else if (draggedDisk == d6) { location = new Point(464, 58); }
                        else if (draggedDisk == d7) { location = new Point(451, 58); }
                        else if (draggedDisk == d8) { location = new Point(435, 58); }
                        else if (draggedDisk == d9) { location = new Point(419, 58); }
                        else if (draggedDisk == d10) { location = new Point(402, 58); }
                        else if (draggedDisk == d11) { location = new Point(387, 58); }
                    }
                    else if (rod == rod3)
                    {
                        if (draggedDisk == d1) { location = new Point(898, 58); }
                        else if (draggedDisk == d2) { location = new Point(881, 58); }
                        else if (draggedDisk == d3) { location = new Point(864, 58); }
                        else if (draggedDisk == d4) { location = new Point(850, 58); }
                        else if (draggedDisk == d5) { location = new Point(836, 58); }
                        else if (draggedDisk == d6) { location = new Point(823, 58); }
                        else if (draggedDisk == d7) { location = new Point(809, 58); }
                        else if (draggedDisk == d8) { location = new Point(793, 58); }
                        else if (draggedDisk == d9) { location = new Point(777, 58); }
                        else if (draggedDisk == d10) { location = new Point(760, 58); }
                        else if (draggedDisk == d11) { location = new Point(745, 58); }
                    }
                    copiedDisk.Size = draggedDisk.Size;
                    copiedDisk.Visible = true;
                    copiedDisk.Enabled = true;
                    copiedDisk.BackColor = draggedDisk.BackColor;
                    copiedDisk.Location = location;
                    copiedDisk.ForeColor = draggedDisk.ForeColor;
                    copiedDisk.Text = draggedDisk.Text;
                    RecreateRegion(copiedDisk);
                    if (diskCopied == false)
                    {
                        this.Controls.Add(copiedDisk);
                        diskCopied = true;
                    }
                    copiedDisk.BringToFront(); copiedDisk.BringToFront();
                }
            }
        }

        private void Rod1_DragDrop(object sender, DragEventArgs e)
        {
            Label peg = sender as Label;
            if (peg != null && draggedDisk != null)
            {
                if (peg == rod1)
                {
                    FromRod_Transfer();
                }
                else if (peg == rod2)
                {
                    AuxRod_Transfer();
                }
                else if (peg == rod3)
                {
                    ToRod_Transfer(sender, e);
                }
            }
        }

        private void Rod3_MouseEnter(object sender, EventArgs e)
        {
            Label rod = sender as Label;
            if (selectedDisk != null)
            {
                if (hybridPlayCheck.Checked == false) { selectedDisk.Visible = false; }
                if (hybridPlayCheck.Checked == true) { selectedDisk.Visible = true; }
                if (showDiskClickBox.Checked == false)
                {
                    Point location = new Point();
                    // if (rod == selectedDisk.Parent) { return; }
                    if (rod == rod1)
                    {
                        if (selectedDisk == d1) { location = new Point(178, 58); }
                        else if (selectedDisk == d2) { location = new Point(163, 58); }
                        else if (selectedDisk == d3) { location = new Point(146, 58); }
                        else if (selectedDisk == d4) { location = new Point(132, 58); }
                        else if (selectedDisk == d5) { location = new Point(119, 58); }
                        else if (selectedDisk == d6) { location = new Point(105, 58); }
                        else if (selectedDisk == d7) { location = new Point(93, 58); }
                        else if (selectedDisk == d8) { location = new Point(78, 58); }
                        else if (selectedDisk == d9) { location = new Point(62, 58); }
                        else if (selectedDisk == d10) { location = new Point(45, 58); }
                        else if (selectedDisk == d11) { location = new Point(27, 58); }
                    }
                    else if (rod == rod2)
                    {
                        if (selectedDisk == d1) { location = new Point(538, 58); }
                        else if (selectedDisk == d2) { location = new Point(521, 58); }
                        else if (selectedDisk == d3) { location = new Point(505, 58); }
                        else if (selectedDisk == d4) { location = new Point(491, 58); }
                        else if (selectedDisk == d5) { location = new Point(477, 58); }
                        else if (selectedDisk == d6) { location = new Point(464, 58); }
                        else if (selectedDisk == d7) { location = new Point(451, 58); }
                        else if (selectedDisk == d8) { location = new Point(435, 58); }
                        else if (selectedDisk == d9) { location = new Point(419, 58); }
                        else if (selectedDisk == d10) { location = new Point(402, 58); }
                        else if (selectedDisk == d11) { location = new Point(387, 58); }
                    }
                    else if (rod == rod3)
                    {
                        if (selectedDisk == d1) { location = new Point(898, 58); }
                        else if (selectedDisk == d2) { location = new Point(881, 58); }
                        else if (selectedDisk == d3) { location = new Point(864, 58); }
                        else if (selectedDisk == d4) { location = new Point(850, 58); }
                        else if (selectedDisk == d5) { location = new Point(836, 58); }
                        else if (selectedDisk == d6) { location = new Point(823, 58); }
                        else if (selectedDisk == d7) { location = new Point(809, 58); }
                        else if (selectedDisk == d8) { location = new Point(793, 58); }
                        else if (selectedDisk == d9) { location = new Point(777, 58); }
                        else if (selectedDisk == d10) { location = new Point(760, 58); }
                        else if (selectedDisk == d11) { location = new Point(745, 58); }
                    }
                    copiedDisk.Size = selectedDisk.Size;
                    copiedDisk.Visible = true;
                    copiedDisk.Enabled = true;
                    copiedDisk.BackColor = selectedDisk.BackColor;
                    copiedDisk.Location = location;
                    copiedDisk.ForeColor = selectedDisk.ForeColor;
                    copiedDisk.Text = selectedDisk.Text;
                    if (diskCopied == false)
                    {
                        RecreateRegion(copiedDisk);
                        this.Controls.Add(copiedDisk);
                        diskCopied = true;
                    }
                    copiedDisk.BringToFront(); copiedDisk.BringToFront();
                }
            }
            if (rod == rod1) { EnableMouseInteractionForTopmostDisk(fromRod); }
            else if (rod == rod2) { EnableMouseInteractionForTopmostDisk(auxRod); }
            else if (rod == rod3) { EnableMouseInteractionForTopmostDisk(toRod); }
        }

        private void Rod1_MouseClick(object sender, MouseEventArgs e)
        {
            Label peg = sender as Label;
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                if (peg != null && selectedDisk != null)
                {
                    if (peg == rod1) { FromRod_MouseClick(sender, e); }
                    else if (peg == rod2) { AuxRod_MouseClick(sender, e); }
                    else if (peg == rod3) { ToRod_MouseClick(sender, e); }
                    return;
                }
                if (peg != null && selectedDisk == null)
                {
                    if (peg == rod1)
                    {
                        int topMostIndex;
                        if (fromRod.Controls.Count == 1) { topMostIndex = fromRod.RowCount - 1; }
                        else if (fromRod.Controls.Count > 1) { topMostIndex = fromRod.RowCount - fromRod.Controls.Count; }
                        else { PrintEmpty(fromRod); return; }
                        if (selectedDisk != null) { selectedDisk.Visible = true; }
                        selectedDisk = (Label)fromRod.GetControlFromPosition(0, topMostIndex);
                    }
                    else if (peg == rod2)
                    {
                        int topMostIndex;
                        if (auxRod.Controls.Count == 1) { topMostIndex = auxRod.RowCount - 1; }
                        else if (auxRod.Controls.Count > 1) { topMostIndex = auxRod.RowCount - auxRod.Controls.Count; }
                        else { PrintEmpty(auxRod); return; }
                        if (selectedDisk != null) { selectedDisk.Visible = true; }
                        selectedDisk = (Label)auxRod.GetControlFromPosition(0, topMostIndex);
                    }
                    else if (peg == rod3)
                    {
                        int topMostIndex;
                        if (toRod.Controls.Count == 1) { topMostIndex = toRod.RowCount - 1; }
                        else if (toRod.Controls.Count > 1) { topMostIndex = toRod.RowCount - toRod.Controls.Count; }
                        else { PrintEmpty(toRod); return; }
                        if (selectedDisk != null) { selectedDisk.Visible = true; }
                        selectedDisk = (Label)toRod.GetControlFromPosition(0, topMostIndex);
                    }
                    if (hybridPlayCheck.Checked == false) { selectedDisk.Visible = false; }
                    else if (hybridPlayCheck.Checked == true) { selectedDisk.Visible = true; }
                    freshGame = false; InitiateElapsedTime(); Rod3_MouseEnter(sender, e); return;
                }
            }
        }

        private void Rod1_MouseDown(object sender, MouseEventArgs e)
        {
            Label rod = sender as Label;
            if (e.Button == MouseButtons.Left && rod != null)
            {
                if (selectedDisk != null)
                {
                    selectedDisk.Visible = true;
                    selectedDisk = null;
                }
                if (rod == rod1)
                {
                    int topMostIndex;
                    if (fromRod.Controls.Count == 1) { topMostIndex = fromRod.RowCount - 1; }
                    else if (fromRod.Controls.Count > 1) { topMostIndex = fromRod.RowCount - fromRod.Controls.Count; }
                    else { PrintEmpty(fromRod); return; }
                    draggedDisk = (Label)fromRod.GetControlFromPosition(0, topMostIndex);
                }
                else if (rod == rod2)
                {
                    int topMostIndex;
                    if (auxRod.Controls.Count == 1) { topMostIndex = auxRod.RowCount - 1; }
                    else if (auxRod.Controls.Count > 1) { topMostIndex = auxRod.RowCount - auxRod.Controls.Count; }
                    else { PrintEmpty(auxRod); return; }
                    draggedDisk = (Label)auxRod.GetControlFromPosition(0, topMostIndex);
                }
                else if (rod == rod3)
                {
                    int topMostIndex;
                    if (toRod.Controls.Count == 1) { topMostIndex = toRod.RowCount - 1; }
                    else if (toRod.Controls.Count > 1) { topMostIndex = toRod.RowCount - toRod.Controls.Count; }
                    else { PrintEmpty(toRod); return; }
                    draggedDisk = (Label)toRod.GetControlFromPosition(0, topMostIndex);
                }
                if (showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
                else if (showDraggedDiskBox.Checked == true) { draggedDisk.Visible = true; }
                freshGame = false; InitiateElapsedTime();
                draggedDisk.DoDragDrop(draggedDisk, DragDropEffects.Move); return;
            }
        }

        private void AuxRod_Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel peg = sender as Panel;
            if (peg != null && selectedDisk != null)
            {
                if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
                {
                    if (peg == fromRod_Location) { FromRod_MouseClick(sender, e); }
                    else if (peg == auxRod_Panel) { AuxRod_MouseClick(sender, e); }
                    else if (peg == toRod_Panel) { ToRod_MouseClick(sender, e); }
                }
            }
        }

        private void ToRod_Panel_DragDrop(object sender, DragEventArgs e)
        {
            Panel location = sender as Panel;
            if (location != null)
            {
                if (location == fromRod_Location)
                {
                    FromRod_Transfer();
                }
                else if (location == auxRod_Panel)
                {
                    AuxRod_Transfer();
                }
                else if (location == toRod_Panel)
                {
                    ToRod_Transfer(sender, e);
                }
            }
        }

        private void AuxRod_Panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            Panel peg = sender as Panel;
            if (peg != null && draggedDisk != null)
            {
                if (showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
                else { draggedDisk.Visible = true; }
                if (showDiskDragBox.Checked == false)
                {
                    if (peg == fromRod_Location)
                    {
                        Point location = new Point();
                        // if (draggedDisk.Parent == rod) { return; }
                        if (draggedDisk == d1) { location = new Point(178, 58); }
                        else if (draggedDisk == d2) { location = new Point(163, 58); }
                        else if (draggedDisk == d3) { location = new Point(146, 58); }
                        else if (draggedDisk == d4) { location = new Point(132, 58); }
                        else if (draggedDisk == d5) { location = new Point(119, 58); }
                        else if (draggedDisk == d6) { location = new Point(105, 58); }
                        else if (draggedDisk == d7) { location = new Point(93, 58); }
                        else if (draggedDisk == d8) { location = new Point(78, 58); }
                        else if (draggedDisk == d9) { location = new Point(62, 58); }
                        else if (draggedDisk == d10) { location = new Point(45, 58); }
                        else if (draggedDisk == d11) { location = new Point(27, 58); }
                        copiedDisk.Size = draggedDisk.Size;
                        copiedDisk.Visible = true;
                        copiedDisk.Enabled = true;
                        copiedDisk.BackColor = draggedDisk.BackColor;
                        copiedDisk.Location = location;
                        copiedDisk.ForeColor = draggedDisk.ForeColor;
                        copiedDisk.Text = draggedDisk.Text;
                        if (diskCopied == false)
                        {
                            RecreateRegion(copiedDisk);
                            this.Controls.Add(copiedDisk);
                            diskCopied = true;
                        }
                        copiedDisk.BringToFront(); copiedDisk.BringToFront();
                    }
                    else if (peg == auxRod_Panel)
                    {
                        Point location = new Point();
                        // if (draggedDisk.Parent == rod) { return; }
                        if (draggedDisk == d1) { location = new Point(538, 58); }
                        else if (draggedDisk == d2) { location = new Point(521, 58); }
                        else if (draggedDisk == d3) { location = new Point(505, 58); }
                        else if (draggedDisk == d4) { location = new Point(491, 58); }
                        else if (draggedDisk == d5) { location = new Point(477, 58); }
                        else if (draggedDisk == d6) { location = new Point(464, 58); }
                        else if (draggedDisk == d7) { location = new Point(451, 58); }
                        else if (draggedDisk == d8) { location = new Point(435, 58); }
                        else if (draggedDisk == d9) { location = new Point(419, 58); }
                        else if (draggedDisk == d10) { location = new Point(402, 58); }
                        else if (draggedDisk == d11) { location = new Point(387, 58); }
                        copiedDisk.Size = draggedDisk.Size;
                        copiedDisk.Visible = true;
                        copiedDisk.Enabled = true;
                        copiedDisk.BackColor = draggedDisk.BackColor;
                        copiedDisk.Location = location;
                        copiedDisk.ForeColor = draggedDisk.ForeColor;
                        copiedDisk.Text = draggedDisk.Text;
                        if (diskCopied == false)
                        {
                            RecreateRegion(copiedDisk);
                            this.Controls.Add(copiedDisk);
                            diskCopied = true;
                        }
                        copiedDisk.BringToFront(); copiedDisk.BringToFront();
                    }
                    else if (peg == toRod_Panel)
                    {
                        Point location = new Point();
                        // if (draggedDisk.Parent == rod) { return; }
                        if (draggedDisk == d1) { location = new Point(898, 58); }
                        else if (draggedDisk == d2) { location = new Point(881, 58); }
                        else if (draggedDisk == d3) { location = new Point(864, 58); }
                        else if (draggedDisk == d4) { location = new Point(850, 58); }
                        else if (draggedDisk == d5) { location = new Point(836, 58); }
                        else if (draggedDisk == d6) { location = new Point(823, 58); }
                        else if (draggedDisk == d7) { location = new Point(809, 58); }
                        else if (draggedDisk == d8) { location = new Point(793, 58); }
                        else if (draggedDisk == d9) { location = new Point(777, 58); }
                        else if (draggedDisk == d10) { location = new Point(760, 58); }
                        else if (draggedDisk == d11) { location = new Point(745, 58); }
                        copiedDisk.Size = draggedDisk.Size;
                        copiedDisk.Visible = true;
                        copiedDisk.Enabled = true;
                        copiedDisk.BackColor = draggedDisk.BackColor;
                        copiedDisk.Location = location;
                        copiedDisk.ForeColor = draggedDisk.ForeColor;
                        copiedDisk.Text = draggedDisk.Text;
                        if (diskCopied == false)
                        {
                            RecreateRegion(copiedDisk);
                            this.Controls.Add(copiedDisk);
                            diskCopied = true;
                        }
                        copiedDisk.BringToFront(); copiedDisk.BringToFront();
                    }
                }
            }
        }

        private void AuxRod_Panel_MouseEnter(object sender, EventArgs e)
        {
            Panel rod = sender as Panel;
            if (selectedDisk != null)
            {
                if (hybridPlayCheck.Checked == false) { selectedDisk.Visible = false; }
                if (hybridPlayCheck.Checked == true) { selectedDisk.Visible = true; }
                if (showDiskClickBox.Checked == false)
                {
                    Point location = new Point();
                    // if (rod == selectedDisk.Parent) { return; }
                    if (rod == fromRod_Location)
                    {
                        if (selectedDisk == d1) { location = new Point(178, 58); }
                        else if (selectedDisk == d2) { location = new Point(163, 58); }
                        else if (selectedDisk == d3) { location = new Point(146, 58); }
                        else if (selectedDisk == d4) { location = new Point(132, 58); }
                        else if (selectedDisk == d5) { location = new Point(119, 58); }
                        else if (selectedDisk == d6) { location = new Point(105, 58); }
                        else if (selectedDisk == d7) { location = new Point(93, 58); }
                        else if (selectedDisk == d8) { location = new Point(78, 58); }
                        else if (selectedDisk == d9) { location = new Point(62, 58); }
                        else if (selectedDisk == d10) { location = new Point(45, 58); }
                        else if (selectedDisk == d11) { location = new Point(27, 58); }
                    }
                    else if (rod == auxRod_Panel)
                    {
                        if (selectedDisk == d1) { location = new Point(538, 58); }
                        else if (selectedDisk == d2) { location = new Point(521, 58); }
                        else if (selectedDisk == d3) { location = new Point(505, 58); }
                        else if (selectedDisk == d4) { location = new Point(491, 58); }
                        else if (selectedDisk == d5) { location = new Point(477, 58); }
                        else if (selectedDisk == d6) { location = new Point(464, 58); }
                        else if (selectedDisk == d7) { location = new Point(451, 58); }
                        else if (selectedDisk == d8) { location = new Point(435, 58); }
                        else if (selectedDisk == d9) { location = new Point(419, 58); }
                        else if (selectedDisk == d10) { location = new Point(402, 58); }
                        else if (selectedDisk == d11) { location = new Point(387, 58); }
                    }
                    else if (rod == toRod_Panel)
                    {
                        if (selectedDisk == d1) { location = new Point(898, 58); }
                        else if (selectedDisk == d2) { location = new Point(881, 58); }
                        else if (selectedDisk == d3) { location = new Point(864, 58); }
                        else if (selectedDisk == d4) { location = new Point(850, 58); }
                        else if (selectedDisk == d5) { location = new Point(836, 58); }
                        else if (selectedDisk == d6) { location = new Point(823, 58); }
                        else if (selectedDisk == d7) { location = new Point(809, 58); }
                        else if (selectedDisk == d8) { location = new Point(793, 58); }
                        else if (selectedDisk == d9) { location = new Point(777, 58); }
                        else if (selectedDisk == d10) { location = new Point(760, 58); }
                        else if (selectedDisk == d11) { location = new Point(745, 58); }
                    }
                    copiedDisk.Size = selectedDisk.Size;
                    copiedDisk.Visible = true;
                    copiedDisk.Enabled = true;
                    copiedDisk.BackColor = selectedDisk.BackColor;
                    copiedDisk.Location = location;
                    copiedDisk.ForeColor = selectedDisk.ForeColor;
                    copiedDisk.Text = selectedDisk.Text;
                    if (diskCopied == false)
                    {
                        RecreateRegion(copiedDisk);
                        this.Controls.Add(copiedDisk);
                        diskCopied = true;
                    }
                    copiedDisk.BringToFront(); copiedDisk.BringToFront();
                }
            }
        }

        private void CopiedDisk_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                if (selectedDisk != null)
                {
                    if (copiedDisk.Location.X >= 27 && copiedDisk.Location.X <= 178)
                    { FromRod_MouseClick(sender, e); return; }
                    else if (copiedDisk.Location.X >= 387 && copiedDisk.Location.X <= 538)
                    { AuxRod_MouseClick(sender, e); return; }
                    else if (copiedDisk.Location.X >= 745 && copiedDisk.Location.X <= 898)
                    { ToRod_MouseClick(sender, e); return; }
                }
            }
        }

        private void CopiedDisk_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            if (copiedDisk != null && showDiskDragBox.Checked == false) { copiedDisk.Visible = true; }
            else if (copiedDisk != null && showDiskDragBox.Checked == true) { copiedDisk.Visible = false; }
            if (draggedDisk != null && showDraggedDiskBox.Checked == false) { draggedDisk.Visible = false; }
            else if (draggedDisk != null && showDraggedDiskBox.Checked == true) { draggedDisk.Visible = true; }
        }

        private void CopiedDisk_DragDrop(object sender, DragEventArgs e)
        {
            if (copiedDisk.Location.X >= 27 && copiedDisk.Location.X <= 178)
            {
                FromRod_Transfer();
            }
            else if (copiedDisk.Location.X >= 387 && copiedDisk.Location.X <= 538)
            {
                AuxRod_Transfer();
            }
            else if (copiedDisk.Location.X >= 745 && copiedDisk.Location.X <= 898)
            {
                ToRod_Transfer(sender, e);
            }
        }

        private void FromRod_Transfer()
        {
            if (draggedDisk != null)
            {
                this.Controls.Remove(copiedDisk); diskCopied = false;
                if (draggedDisk.Parent == fromRod)
                {
                    draggedDisk.Visible = true;
                    copiedDisk.Visible = false; return;  // The disk is being dropped back onto its original rod, so do nothing
                }
                if (fromRod.Controls.Count >= 1)
                {
                    if (IsMoveValid(draggedDisk, fromRod) == false)
                    { draggedDisk.Visible = true; copiedDisk.Visible = false; InvalidPrint(); return; }
                }
                draggedDisk.Visible = true;
                MoveDiskToRod(draggedDisk, fromRod);
                ++moves; movesAmount.Text = moves.ToString();
                draggedDisk = null;
            }
        }

        private void AuxRod_Transfer()
        {
            if (draggedDisk != null)
            {
                this.Controls.Remove(copiedDisk); diskCopied = false;
                if (draggedDisk.Parent == auxRod)
                {
                    draggedDisk.Visible = true;
                    copiedDisk.Visible = false; return;  // The disk is being dropped back onto its original rod, so do nothing
                }
                if (auxRod.Controls.Count >= 1)
                {
                    if (IsMoveValid(draggedDisk, auxRod) == false)
                    { draggedDisk.Visible = true; copiedDisk.Visible = false; InvalidPrint(); return; }
                }
                draggedDisk.Visible = true;
                MoveDiskToRod(draggedDisk, auxRod);
                ++moves; movesAmount.Text = moves.ToString();
                draggedDisk = null;
            }
        }

        private void ToRod_Transfer(object sender, EventArgs e)
        {
            if (draggedDisk != null)
            {
                this.Controls.Remove(copiedDisk); diskCopied = false;
                if (draggedDisk.Parent == toRod)
                {
                    draggedDisk.Visible = true;
                    copiedDisk.Visible = false; return;  // The disk is being dropped back onto its original rod, so do nothing
                }
                if (toRod.Controls.Count >= 1)
                {
                    if (IsMoveValid(draggedDisk, toRod) == false)
                    { draggedDisk.Visible = true; copiedDisk.Visible = false; InvalidPrint(); return; }
                }
                draggedDisk.Visible = true;
                MoveDiskToRod(draggedDisk, toRod);
                ++moves; movesAmount.Text = moves.ToString();
                draggedDisk = null;
                if (toRod.Controls.Count == diskAmount.Value) { CheckCompletion(sender, e); }
            }
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
        int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void RecreateRegion(Label disk)
        {
            Rectangle bounds = disk.ClientRectangle;
            disk.Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top, bounds.Right, bounds.Bottom + 1, radius, radius));
            disk.Invalidate();
        }
    }
}

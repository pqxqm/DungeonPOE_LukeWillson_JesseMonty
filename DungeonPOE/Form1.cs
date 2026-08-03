using System.Drawing;
using System.Windows.Forms;

namespace DungeonPOE
{
    public partial class Form1 : Form
    {
        // Stores the game engine used by the form.
        private GameEngine GameEngine;

        public Form1()
        {
            InitializeComponent();

            // Apply the visual appearance of the game.
            ApplyGameStyle();

            // Allow the form to receive keyboard input.
            KeyPreview = true;
            KeyDown += Form1_KeyDown;

            // Create the game and display the first level.
            GameEngine = new GameEngine(10);
            UpdateDisplay();
        }

        // Refreshes the dungeon displayed on the form.
        private void UpdateDisplay()
        {
            lblDisplay.Text = GameEngine.ToString();

            // Keep the controls label underneath the dungeon.
            lblControls.Location = new Point(
                lblDisplay.Left,
                lblDisplay.Bottom + 15
            );
        }

        // Runs whenever the player presses a key.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Begin with no movement selected.
            Direction direction = Direction.None;

            // Convert keyboard input into a movement direction.
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    direction = Direction.Up;
                    break;

                case Keys.Right:
                case Keys.D:
                    direction = Direction.Right;
                    break;

                case Keys.Down:
                case Keys.S:
                    direction = Direction.Down;
                    break;

                case Keys.Left:
                case Keys.A:
                    direction = Direction.Left;
                    break;
            }

            // Only move when a recognised movement key is pressed.
            if (direction != Direction.None)
            {
                GameEngine.TriggerMovement(direction);
                UpdateDisplay();

                // Prevent Windows from processing the key again.
                e.SuppressKeyPress = true;
            }
        }

        // Applies the visual styling used by the game.
        private void ApplyGameStyle()
        {
            // Style the main window.
            Text = "Dungeon Explorer";
            BackColor = Color.FromArgb(20, 20, 25);
            ForeColor = Color.White;

            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Padding = new Padding(20);

            // Style the dungeon display.
            lblDisplay.BackColor = Color.FromArgb(10, 10, 15);
            lblDisplay.ForeColor = Color.LightGray;
            lblDisplay.Font = new Font(
                "Consolas",
                18,
                FontStyle.Bold
            );

            lblDisplay.Padding = new Padding(12);
            lblDisplay.AutoSize = true;
            lblDisplay.Location = new Point(20, 55);

            // Style the title.
            lblTitle.Text = "DUNGEON EXPLORER";
            lblTitle.ForeColor = Color.Gold;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font(
                "Segoe UI",
                18,
                FontStyle.Bold
            );

            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 12);

            // Style the control instructions.
            lblControls.Text = "Controls: W/A/S/D or Arrow Keys to Move";
            lblControls.ForeColor = Color.DarkGray;
            lblControls.BackColor = Color.Transparent;
            lblControls.Font = new Font(
                "Segoe UI",
                10,
                FontStyle.Regular
            );

            lblControls.AutoSize = true;
            lblControls.Location = new Point(
                20,
                lblDisplay.Bottom + 15
            );
        }
    }
}
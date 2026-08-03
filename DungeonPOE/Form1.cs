using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
namespace DungeonPOE
{
    public partial class Form1 : Form
    {
        private GameEngine GameEngine;

        public Form1()
        {
            InitializeComponent();

            ApplyGameSyle();
            //Allows the form to receive key presses
            KeyPreview = true;

            KeyDown += Form1_KeyDown;

            GameEngine = new GameEngine(10);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblDisplay.Text = GameEngine.ToString();
        }

        //Runs when a key is pressed while the form has focus
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Direction direction = Direction.None;
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

            //Only trigger movement if a valid direction was pressed
            if (direction != Direction.None)
            {
                GameEngine.TriggerMovement(direction);
                UpdateDisplay();

                //Prevent Windows from processing the same key again
                e.SuppressKeyPress = true;
            }
        }


    }
}

/*private void ApplyGameStyle()

{
    TextBox = "Dungeon Explorer"
    BackColor = Color.FromArgb(20, 20, 25);
    ForeColor = Color.White;

    FormBorderSyle = FormBorderSyle.FixedSingle;
    MaximizeBox = false;

    StartPosition = FormStartPosition.CenterScreen;

    Padding = new Padding(20);

    lblDisplay.BackColor = Color.FromArgb(10, 10, 15);
    lblDisplay.ForeColor = Color.LightGray;

    lblDiplay.Font = new Font("Consolas",18,FontStyle.Bold);

    lblDisplay.Padding = new Padding(12);

    lblDisplay.AutoSize = true;

    lblDisplay.Location = new Point(20, 50);
}
*/
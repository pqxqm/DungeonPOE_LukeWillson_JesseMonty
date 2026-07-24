using System.Drawing.Text;

namespace DungeonPOE
{
    public partial class Form1 : Form
    {
        private GameEngine GameEngine;

        public Form1()
        {
            InitializeComponent();
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

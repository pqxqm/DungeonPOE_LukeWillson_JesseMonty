using System.Drawing.Text;

namespace DungeonPOE
{
    public partial class Form1 : Form
    {
        private GameEngine GameEngine;

        public Form1()
        {
            InitializeComponent();
            GameEngine = new GameEngine(10);
            updateDisplay();
        }

        private void updateDisplay()
        {
            lblDisplay.Text = GameEngine.ToString();
        }


    }
}

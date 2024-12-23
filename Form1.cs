using System.Runtime.CompilerServices;

namespace Bouncer
{
    public partial class Form1 : Form
    {

        private Slime slime = new Slime(0, 0);
        private Ball ball;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            ball = new Ball(100, 100, slime);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ball.Draw(e.Graphics, this.ClientSize.Width, this.ClientSize.Height);
            slime.Draw(e.Graphics, this.ClientSize.Width, this.ClientSize.Height);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int moveStep = 15;
            int moveStepY = 30;

            if (e.KeyCode == Keys.A)
            {
                slime.Move(-moveStep, 0);
            }

            if (e.KeyCode == Keys.D)
            {
                slime.Move(moveStep, 0);
            }

            if (e.KeyCode == Keys.W)
            {
                slime.Move(0, -moveStepY);
            }

            Invalidate();
        }
    }
}

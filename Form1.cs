using System.Windows.Forms;

namespace Bouncer
{
  public partial class Form1 : Form
  {
    private Ball ball;
    private Slime slime;

    public Form1()
    {
      InitializeComponent();
      this.DoubleBuffered = true;

      slime = new Slime(0, ClientSize.Height);
      ball = new Ball(100, 100, slime);

   
      KeyDown += new KeyEventHandler(Form1_KeyDown);
      KeyUp += new KeyEventHandler(Form1_KeyUp);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Invalidate(); 
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      ball.Draw(e.Graphics, ClientSize.Width, ClientSize.Height);
      slime.Draw(e.Graphics, ClientSize.Width, ClientSize.Height);
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {

      //long milliseconds = DateTime.Now.Ticks;
      //Debug.WriteLine($"HERE {milliseconds}");

      int moveStep = 15;     
      int jumpStep = -30;   

      if (e.KeyCode == Keys.A)
      {
        slime.MoveAsync(-moveStep, 0, ClientSize.Width, ClientSize.Height);
      }
      else if (e.KeyCode == Keys.D)
      {
        slime.MoveAsync(moveStep, 0, ClientSize.Width, ClientSize.Height);
      }
      else if (e.KeyCode == Keys.W)
      {
        slime.Jump(ClientSize.Height);
      }

      Invalidate(); 
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
      slime.Stop();
    }
  }
}

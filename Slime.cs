using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;

namespace Bouncer;

internal class Slime
{
  private readonly Brush brush;
  private readonly int Height = 60;
  private bool isMoving;
  internal int PositionOfX;
  internal int PositionOfY;
  internal int Width = 100;
  private bool isJumping = false;
  private bool isFalling = false;
  public int verticalSpeed { get; set; } = 0;

  public Slime(int initialX, int formHeight)
  {
    PositionOfX = initialX;
    PositionOfY = formHeight - Height;
    brush = new SolidBrush(Color.MediumSpringGreen);
  }

  public void Draw(Graphics graphics, int formWidth, int formHeight)
  {
    graphics.SmoothingMode = SmoothingMode.AntiAlias;

    //PositionOfY = formHeight - Height - 5;

    var slimeShape = new GraphicsPath();

    slimeShape.AddArc(PositionOfX, PositionOfY, Width, Height * 2, 180, 180);
    slimeShape.AddLine(PositionOfX, PositionOfY + Height, PositionOfX + Width, PositionOfY + Height);

    graphics.FillPath(brush, slimeShape);
  }


  public async Task MoveAsync(int dx, int dy, int formWidth, int formHeight)
  {
    if(isMoving)
    {
      return;
    }

    isMoving = true;

    while (isMoving)
    {
        PositionOfX += dx;
        //PositionOfY += dy;

      if (PositionOfX < 0)
      {
        PositionOfX = 0;
      }
      if (PositionOfX + Width >= formWidth)
      {
        PositionOfX = formWidth - Width;
      }
      //if (PositionOfY < 0)
      //{
      //  PositionOfY = 0;
      //}
      //if (PositionOfY + Height >= formHeight)
      //{
      //  PositionOfY = formHeight - Height;
      //}

      await Task.Delay(30);
    }
  }

  public void Stop()
  {
    isMoving = false;
  }

  public async Task Jump(int formHeight)
  {
    if (isJumping || isFalling) return;
 

    isJumping = true;
    //int MaxJumpHeight = 400;
    int JumpSpeed = -15;
    int JumpGravity = 2;


    while (JumpSpeed < 0)
    {
      PositionOfY += JumpSpeed;
      verticalSpeed = JumpSpeed;
      JumpSpeed += JumpGravity;
      await Task.Delay(30);
    }


    isJumping = false;
    isFalling = true;



    while (PositionOfY + Height < formHeight)
    {
      PositionOfY += JumpSpeed;
      verticalSpeed = JumpSpeed;
      JumpSpeed += JumpGravity;
      await Task.Delay(30);
      //if (PositionOfY == formHeight - Height)
      //{
      //  isFalling = false;
      //}
    }

    PositionOfY = formHeight - Height;
    verticalSpeed = 0;
    isFalling = false;
  }


}
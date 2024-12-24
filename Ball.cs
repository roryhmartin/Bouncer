using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncer;

internal class Ball
{
    private int PositionOfX = 100;
    private int PositionOfY = 100;
    private int directionOfX = 5;
    private int directionOfY = -15;
    private int gravity = 1;
    private Pen pen;
    private Slime slime;

    public Ball(int initialX, int initialY, Slime slimeInstance)
    {
        PositionOfX = initialX;
        PositionOfY = initialY;
        pen = new Pen(Color.Black, 4);
        slime = slimeInstance;
    }

    public void Draw(Graphics graphics, int formWidth, int formHeight)
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        int diameter = (int)pen.Width * 5;

        directionOfY += gravity;

        PositionOfX += directionOfX;
        PositionOfY += directionOfY;


        // Wall stuff
        if (PositionOfX < 0 || PositionOfX + diameter >= formWidth)
        {
            directionOfX = -directionOfX;
        }
        if(PositionOfY + diameter >= formHeight)
        {
            PositionOfY = formHeight - diameter;
            directionOfY = (int)(-directionOfY * 0.8);
            //directionOfY = -directionOfY;
        }

        // floor stuff
        if (PositionOfY < 0)
        {
            PositionOfY = 0;
            directionOfY = -directionOfY;
        }

        // slime stuff 
        if (PositionOfY + diameter >= slime.PositionOfY && 
            PositionOfX + diameter >= slime.PositionOfX && 
            PositionOfX <= slime.PositionOfX + slime.Width)
        { 
            directionOfY = -directionOfY + slime.verticalSpeed / 4;
            int slimeCenter = slime.PositionOfX + slime.Width / 2;
            int ballCenter = PositionOfX + diameter / 2;
            int impactOffset = ballCenter - slimeCenter;

            directionOfX = impactOffset / 10;


            //PositionOfY = slime.PositionOfY - diameter;
            //directionOfY = -directionOfX;
    }


        graphics.DrawEllipse(pen, PositionOfX, PositionOfY, diameter, diameter);
    }
}

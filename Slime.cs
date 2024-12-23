using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouncer
{
    internal class Slime
    {
        internal int PositionOfX;
        internal int PositionOfY;
        internal int Width = 100;
        private int Height = 60;
        private Brush brush;

        public Slime(int initialX, int initialY)
        {
            PositionOfX = initialX;
            PositionOfY = initialY;
            brush = new SolidBrush(Color.MediumSpringGreen);
        }

        public void Draw(Graphics graphics, int formWidth, int formHeight)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            PositionOfY = formHeight - Height - 5;

            GraphicsPath slimeShape = new GraphicsPath();
            
            slimeShape.AddArc(PositionOfX, PositionOfY, Width, Height * 2, 180, 180);
            slimeShape.AddLine(PositionOfX, PositionOfY + Height, PositionOfX + Width, PositionOfY + Height);

            graphics.FillPath(brush, slimeShape);
        }

        public void Move(int dx, int dy)
        {
            PositionOfX += dx;
            PositionOfY += dy;
        }
    }
}

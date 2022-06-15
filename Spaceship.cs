using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Lists
{
    class Spaceship
    {
        public int x, y, width, height;//variables for the rectangle
        public Image spaceship;//variable for the spaceship's image

        public Rectangle spaceRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public Spaceship()
        {
            x = 10;
            y = 350;
            width = 73;
            height = 39;
            spaceship = Properties.Resources.alien1;
            spaceRec = new Rectangle(x, y, width, height);
        }

        public void drawSpaceship(Graphics g)
        {
            g.DrawImage(spaceship, spaceRec);
        }

        public void moveSpaceship(int mouseX)
        {
            spaceRec.X = mouseX - (spaceRec.Width / 2);
        }

    }
}

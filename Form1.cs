using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lists
{
    public partial class Form1 : Form
    {
        Graphics g; //declare a graphics object called g
        Spaceship spaceship = new Spaceship();//create object called spaceship 

        //declare a list  missiles from the missile class
        List<Missile> missiles = new List<Missile>();
        List<Planet> planets = new List<Planet>();

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                int displacement = 10 + (i * 70);
                planets.Add(new Planet(displacement));
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            spaceship.drawSpaceship(g);
            foreach (Missile m in missiles)
            {
                m.draw(g);
            }
            foreach (Planet p in planets)
            {
                p.draw(g);//Draw the planet
                p.movePlanet(g);//move the planet
                //if the planet reaches the bottom of the form relocate it back to the top
                if (p.y >= ClientSize.Height)
                {
                    p.y = -20;
                }

            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            spaceship.moveSpaceship(e.X);
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                missiles.Add(new Missile(spaceship.spaceRec));
            }

        }

        private void TmrShoot_Tick(object sender, EventArgs e)
        {
            foreach (Planet p in planets)
            {

                foreach (Missile m in missiles)
                {
                    if (p.planetRec.IntersectsWith(m.missileRec))
                    {
                        p.y = -20;// relocate planet to the top of the form
                        missiles.Remove(m);
                        break;
                    }
                }

            }

            this.Invalidate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Muhammad Cheema
//Jeffin Domi
//14/06/2019
//To create a space invaders spin off

namespace KingOfTheHill
{
    
    //declaring enums for archer, arrow and soldier state
    enum ArcherState
    {
        Left, 
        Right,
        None
    }

    enum ArrowState
    {
        Up,
        None
    }

    enum SoldierState
    {
        Left,
        Right,
        Down,
        None
 
    }

    public partial class frmKingOfTheHill : Form
    {
        
        //setting initial states for archer, arrow and soldier states
        ArcherState Archer = ArcherState.None;
        ArrowState Arrow = ArrowState.None;
        SoldierState Soldiers = SoldierState.Right;
        int ArrowCount = 20;
        int Indicator = 0;

        public frmKingOfTheHill()
        {
            InitializeComponent();
        }
        
        private void frmKingOfTheHill_KeyDown(object sender, KeyEventArgs e)
        {
            //for archer to move left
            if (e.KeyCode == Keys.Left)
            {
                Archer = ArcherState.Left;
            }

            //for archer to move right
            else if (e.KeyCode == Keys.Right)
            {
                Archer = ArcherState.Right;
            }

            //to move arrow up
            else if (e.KeyCode == Keys.Space)
            {
                Arrow = ArrowState.Up;  
            }
        }

        private void frmKingOfTheHill_KeyUp(object sender, KeyEventArgs e)
        {
            //to stop movement if key is released
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                Archer = ArcherState.None;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //displaying remaining number of arrows
            lblNumberOfArrows.Text = ArrowCount.ToString();
            
            //declaring array for enemy soldiers
            PictureBox[] Soldier = new PictureBox[14];

            //setting values to pictureboxes for soldiers
            Soldier[0] = picSoldier1;
            Soldier[1] = picSoldier2;
            Soldier[2] = picSoldier3;
            Soldier[3] = picSoldier4;
            Soldier[4] = picSoldier5;
            Soldier[5] = picSoldier6;
            Soldier[6] = picSoldier7;
            Soldier[7] = picSoldier8;
            Soldier[8] = picSoldier9;
            Soldier[9] = picSoldier10;
            Soldier[10] = picSoldier11;
            Soldier[11] = picSoldier12;
            Soldier[12] = picSoldier13;
            Soldier[13] = picSoldier14;
                
            //if the space bar is pressed
            if (Arrow == ArrowState.Up)
            {
                
                //move the arrow
                picArrow.Visible = true;
                picArrow.Top -= 45;

                for (int i = 0; i < Soldier.Length; i++)
                {
                    //if soldier is hit, make them invisible and take away one arrow
                    if (Soldier[i].Visible == true && Soldier[i].Bounds.IntersectsWith(picArrow.Bounds))
                    {
                        Soldier[i].Visible = false;
                        Arrow = ArrowState.None;
                        ArrowCount--;
                        break;

                    }
                }

                //if arrow hits the top of the screen, reset it
                if (picArrow.Bottom <= 0)
                {
                    Arrow = ArrowState.None;
                    ArrowCount--;
                }
            }

            else if (Arrow == ArrowState.None)
            {
                //return arrow
                picArrow.Visible = false;
                picArrow.Top = 454;
                picArrow.Left = picArcher.Left + 24;
            }

            //moving archer left
            if (Archer == ArcherState.Left)
            {
                picArcher.Left -= 25;
              
                //keeping archer on screen
                if (picArcher.Left <= 15)
                {
                    picArcher.Left = 15;
                }
            }

            //moving archer right
            else if (Archer == ArcherState.Right)
            {
                picArcher.Left += 20;

                //keeping archer on screen
                if (picArcher.Left >= 637)
                {
                    picArcher.Left = 637;
                }
            }

            //moving soldiers right
            if (Soldiers == SoldierState.Right)
            {
                Soldier[0].Left += 1;
                Soldier[1].Left += 1;
                Soldier[2].Left += 1;
                Soldier[3].Left += 1;
                Soldier[4].Left += 1;
                Soldier[5].Left += 1;
                Soldier[6].Left += 1;
                Soldier[7].Left += 1;
                Soldier[8].Left += 1;
                Soldier[9].Left += 1;
                Soldier[10].Left += 1;
                Soldier[11].Left += 1;
                Soldier[12].Left += 1;
                Soldier[13].Left += 1;
                picKing.Left += 2;

                //stopping them before moving down
                if (Soldier[4].Right == 695)
                {
                    Soldier[0].Left = 51;
                    Soldier[1].Left = 204;
                    Soldier[2].Left = 365;
                    Soldier[3].Left = 522;
                    Soldier[4].Left = 666;
                    Soldier[5].Left = 51;
                    Soldier[6].Left = 204;
                    Soldier[7].Left = 522;
                    Soldier[8].Left = 666;
                    Soldier[9].Left = 51;
                    Soldier[10].Left = 204;
                    Soldier[11].Left = 365;
                    Soldier[12].Left = 522;
                    Soldier[13].Left = 666;
                    picKing.Left = 365;

                    Soldiers = SoldierState.Down;
                }

                //stopping them before moving down the second time
                else if (Soldier[4].Right >= 699)
                    {
                        Soldier[0].Left = 39;
                        Soldier[1].Left = 192;
                        Soldier[2].Left = 353;
                        Soldier[3].Left = 510;
                        Soldier[4].Left = 666;
                        Soldier[5].Left = 39;
                        Soldier[6].Left = 192;
                        Soldier[7].Left = 510;
                        Soldier[8].Left = 666;
                        Soldier[9].Left = 39;
                        Soldier[10].Left = 192;
                        Soldier[11].Left = 353;
                        Soldier[12].Left = 510;
                        Soldier[13].Left = 666;
                        picKing.Left = 353;

                        //indicator for whether the soldiers are moving the first or second time
                        Indicator++;
                        Soldiers = SoldierState.Down;
                    }
            }

            //moving soldiers down
            else if (Soldiers == SoldierState.Down)
            {
                Soldier[0].Top += 1;
                Soldier[1].Top += 1;
                Soldier[2].Top += 1;
                Soldier[3].Top += 1;
                Soldier[4].Top += 1;
                Soldier[5].Top += 1;
                Soldier[6].Top += 1;
                Soldier[7].Top += 1;
                Soldier[8].Top += 1;
                Soldier[9].Top += 1;
                Soldier[10].Top += 1;
                Soldier[11].Top += 1;
                Soldier[12].Top += 1;
                Soldier[13].Top += 1;
                picKing.Top += 1;

                //stopping them from moving down 
                if (Indicator == 0)
                {
                    Soldier[0].Top = 63;
                    Soldier[1].Top = 63;
                    Soldier[2].Top = 63;
                    Soldier[3].Top = 63;
                    Soldier[4].Top = 63;
                    Soldier[5].Top = 156;
                    Soldier[6].Top = 156;
                    Soldier[7].Top = 156;
                    Soldier[8].Top = 156;
                    Soldier[9].Top = 255;
                    Soldier[10].Top = 255;
                    Soldier[11].Top = 255;
                    Soldier[12].Top = 255;
                    Soldier[13].Top = 255;
                    picKing.Top = 156;

                    Soldiers = SoldierState.Left;
                }

                //stopping them from moving down the second time
                else if (Indicator == 1)
                {
                    Soldier[0].Top = 73;
                    Soldier[1].Top = 73;
                    Soldier[2].Top = 73;
                    Soldier[3].Top = 73;
                    Soldier[4].Top = 73;
                    Soldier[5].Top = 166;
                    Soldier[6].Top = 166;
                    Soldier[7].Top = 166;
                    Soldier[8].Top = 166;
                    Soldier[9].Top = 265;
                    Soldier[10].Top = 265;
                    Soldier[11].Top = 265;
                    Soldier[12].Top = 265;
                    Soldier[13].Top = 265;
                    picKing.Top = 166;

                    Soldiers = SoldierState.Right;
                }

                //keeping soldiers moving if first line is destroyed and letting them reach the tower
                for (int j = 0; j < 14; j++)
                {
                     if (Soldier[j].Bottom >= 352 && Soldier[j].Visible == true)
                    {
                        Soldier[0].Visible = false;
                        Soldier[1].Visible = false;
                        Soldier[2].Visible = false;
                        Soldier[3].Visible = false;
                        Soldier[4].Visible = false;
                        Soldier[5].Visible = false;
                        Soldier[6].Visible = false;
                        Soldier[7].Visible = false;
                        Soldier[8].Visible = false;
                        Soldier[9].Visible = true;
                        Soldier[10].Visible = true;
                        Soldier[11].Visible = true;
                        Soldier[12].Visible = true;
                        Soldier[13].Visible = true; 
                        Soldier[9].Top = 323;
                        Soldier[10].Top = 323;
                        Soldier[11].Top = 323;
                        Soldier[12].Top = 323;
                        Soldier[13].Top = 323;
                        picKing.Visible = false;

                        //stopping the game and displaying the win message
                        tmrGame.Stop();
                        lblWinLose.Visible = true;
                        lblWinLose.Text = "THE GREY RUNNERS HAVE REACHED THE TOWER!";
                    }
                }
            }

            //moving soldiers left
            else if (Soldiers == SoldierState.Left)
            {
                Soldier[0].Left -= 1;
                Soldier[1].Left -= 1;
                Soldier[2].Left -= 1;
                Soldier[3].Left -= 1;
                Soldier[4].Left -= 1;
                Soldier[5].Left -= 1;
                Soldier[6].Left -= 1;
                Soldier[7].Left -= 1;
                Soldier[8].Left -= 1;
                Soldier[9].Left -= 1;
                Soldier[10].Left -= 1;
                Soldier[11].Left -= 1;
                Soldier[12].Left -= 1;
                Soldier[13].Left -= 1;
                picKing.Left -= 2;

                //stopping them before moving down
                if (Soldier[0].Left <= 0)
                {
                    Soldier[0].Left = 0;
                    Soldier[1].Left = 153;
                    Soldier[2].Left = 314;
                    Soldier[3].Left = 471;
                    Soldier[4].Left = 627;
                    Soldier[5].Left = 0;
                    Soldier[6].Left = 153;
                    Soldier[7].Left = 471;
                    Soldier[8].Left = 627;
                    Soldier[9].Left = 0;
                    Soldier[10].Left = 153;
                    Soldier[11].Left = 314;
                    Soldier[12].Left = 471;
                    Soldier[13].Left = 627;
                    picKing.Left = 314;

                    Indicator++;
                    Soldiers = SoldierState.Down;
                }
            }

            //if the number of arrows reaches one
            if (ArrowCount == 0)
            {
                lblLastHope.Visible = true;
                lblLastHope.Text = "YOU FOUND A HIDDEN ARROW! FINISH THIS!";
            }

            //if the archer runs out of arrow
            else if (ArrowCount == -1)
            {
                //letting the soldiers reach the tower
                Soldier[0].Visible = false;
                Soldier[1].Visible = false;
                Soldier[2].Visible = false;
                Soldier[3].Visible = false;
                Soldier[4].Visible = false;
                Soldier[5].Visible = false;
                Soldier[6].Visible = false;
                Soldier[7].Visible = false;
                Soldier[8].Visible = false;
                Soldier[9].Visible = true;
                Soldier[10].Visible = true;
                Soldier[11].Visible = true;
                Soldier[12].Visible = true;
                Soldier[13].Visible = true;
                Soldier[9].Top = 323;
                Soldier[10].Top = 323;
                Soldier[11].Top = 323;
                Soldier[12].Top = 323;
                Soldier[13].Top = 323;
                picKing.Visible = false;
                
                //stop game
                tmrGame.Stop();
                lblWinLose.Visible = true;
                lblWinLose.Text = "YOU RAN OUT OF ARROWS! THE GREY RUNNERS HAVE REACHED THE TOWER!";
            }

            //if all soldiers are defeated
            if (Soldier[0].Visible == false && Soldier[1].Visible == false && Soldier[2].Visible == false &&
                Soldier[3].Visible == false && Soldier[4].Visible == false && Soldier[5].Visible == false &&
                Soldier[5].Visible == false && Soldier[6].Visible == false && Soldier[7].Visible == false && 
                Soldier[8].Visible == false && Soldier[9].Visible == false && Soldier[10].Visible == false && 
                Soldier[11].Visible == false && Soldier[12].Visible == false && Soldier[13].Visible == false)
            {
                //stop game
                tmrGame.Stop();
                lblWinLose.Visible = true;
                lblWinLose.Text = "YOU DEFEATED THE GREY RUNNERS! YOU WIN!";
            }

            //if king is executed
            if (picKing.Bounds.IntersectsWith(picArrow.Bounds))
            {
                tmrGame.Stop();
                picKing.Visible = false;
                picArrow.Visible = false;
                picArcher.Visible = false;
                lblWinLose.Visible = true;
                lblWinLose.Text = "YOU KILLED THE KING! YOU ARE EXECUTED!";
            }
        }
    }
}

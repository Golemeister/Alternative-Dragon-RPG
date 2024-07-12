using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Player_Character Main_Character;
        Player_Character Secondary_Character;
        Golem_Character Golem;
        Dragon_Character Dragon 
         /*= new Dragon_Character() - This is when there's no constructor (same goes for the two player_characters!)*/;
        Dragon_Character TrenutniNeprijatelj;


        bool Dremur = false;
        int Turn_Count = 0;
        int Lost_Count = 0;

        int Current_Enemy;

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("You've entered the lair of Dro'ughul the Dreaded. The bleak, dark interior of his caverns is filled with the stench of rotting flesh, accompanied by the damp, underground air. \r\n\r\nWithout any warning, the dragon appears from above!");

            Random lootable = new Random();
            int loot = lootable.Next(80, 181);
            Random bolder = new Random();
            int boldam = bolder.Next(20, 31);
            Random rock = new Random();
            int rocdam = rock.Next(15, 21);


            Main_Character = new Player_Character("Prince George", 100, 10, 15, 25, 0);
            /*Main_Character.HP = 100;
            Main_Character.ATK = 15;
            Main_Character.DEF = 10;
            Main_Character.Name = "Prince George";
            Main_Character.Fled = false;
            Main_Character.HL = 25;
            Main_Character.SC = 0;
            Main_Character.Dead = false; - used without a constructor.*/

            Secondary_Character = new Player_Character("Loyal Knight", 150, 1, 20, 25, 15);
            /*Secondary_Character.HP = 150;
            Secondary_Character.ATK = 20;
            Secondary_Character.DEF = 1;
            Secondary_Character.Name = "Loyal Knight";
            Secondary_Character.Fled = false;
            Secondary_Character.HL = 25;
            Secondary_Character.SC = 15;
            Secondary_Character.Dead = false;*/

            Dragon = new Dragon_Character("Dro'ughul the Dreaded", 1000, 10, 25, loot);
            /*Dragon.HP = 1000;
            Dragon.ATK = 25;
            Dragon.DEF = 10;
            Dragon.Name = "Dro'ughul the Dreaded";
            Dragon.LT = loot;*/

            Golem = new Golem_Character("Gen", 280, 18, 18, loot, 10, boldam, rocdam);
            TrenutniNeprijatelj = Dragon;

            Turn();

        }

        private void Turn()
        {
            if (Dragon.Dead == false)
            {
                Random random = new Random();
                int number = random.Next(0, 2);
                if (number == 0)
                {
                    if (Main_Character.HP > 0 && Main_Character.Fled == false)
                    {
                        MessageBox.Show(Dragon.Attack(Main_Character));
                    }

                    else
                    {
                        number = 1;
                    }

                }


                if (number == 1)
                {
                    if (Secondary_Character.HP > 0 && Secondary_Character.Fled == false)
                    {
                        MessageBox.Show(Dragon.Attack(Secondary_Character));
                    }
                    else
                    {
                        if (Main_Character.HP > 0 && Main_Character.Fled == false)
                        {
                            MessageBox.Show(Dragon.Attack(Main_Character));

                        }
                        /* This is now an ending. It's known as the "Loss Condition" and is a part of the Lost Ending.
                    else
                    {
                        MessageBox.Show("Error 008: Everyone has died!");
                        MessageBox.Show("You are currently experiencing an Alpha Bug that will be eradicated soon, thank you for your patience. Please restart the game.");
                    }
                         */
                    }
                }

                Turn_Count++;

                label1.Text = Main_Character.Status();
                label2.Text = Secondary_Character.Status();
                label3.Text = Dragon.Status();
                label7.Text = Convert.ToString(Turn_Count);
                DeathCheck();
            }

            else
            {
                if (Golem.Dead == false)
                {
                    Random bolder = new Random();
                    int boldam = bolder.Next(20, 31);
                    Random rock = new Random();
                    int rocdam = rock.Next(15, 21);

                    Random random = new Random();
                    int number = random.Next(0, 2);
                    if (number == 0)
                    {
                        if (Main_Character.HP > 0 && Main_Character.Fled == false)
                        {
                            MessageBox.Show(Golem.Attack(Main_Character));
                        }

                        else
                        {
                            number = 1;
                        }

                    }


                    if (number == 1)
                    {
                        if (Secondary_Character.HP > 0 && Secondary_Character.Fled == false)
                        {
                            MessageBox.Show(Golem.Attack(Secondary_Character));
                        }
                        else
                        {
                            if (Main_Character.HP > 0 && Main_Character.Fled == false)
                            {
                                MessageBox.Show(Golem.Attack(Main_Character));

                            }
                            /* This is now an ending. It's known as the "Loss Condition" and is a part of the Lost Ending.
                        else
                        {
                            MessageBox.Show("Error 008: Everyone has died!");
                            MessageBox.Show("You are currently experiencing an Alpha Bug that will be eradicated soon, thank you for your patience. Please restart the game.");
                        }
                             */
                        }
                    }

                    Turn_Count++;

                    label1.Text = Main_Character.Status();
                    label2.Text = Secondary_Character.Status();
                    label3.Text = Golem.Status();
                    label7.Text = Convert.ToString(Turn_Count);
                    DeathCheck();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Dragon.Dead == false)
            {
                MessageBox.Show(Main_Character.Attack(Dragon));
            }
            else if (Golem.Dead == false)
            {
                MessageBox.Show(Main_Character.Attack(Dragon));
            }
            else MessageBox.Show("Error 011: All enemies dead. Alpha bug 3#");
            Turn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Main_Character.Heal());
            Turn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main_Character.Flee();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            Main_Character.Fled = true;
            Turn();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Dragon.Dead == false)
            {
                MessageBox.Show(Secondary_Character.Attack(Dragon));
            }
            else if (Golem.Dead == false)
            {
                MessageBox.Show(Secondary_Character.Attack(Dragon));
            }
            else MessageBox.Show("Error 011: All enemies dead. Alpha bug 3#");
            Turn();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Secondary_Character.Heal());
            Turn();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Secondary_Character.Flee();
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            Secondary_Character.Fled = true;
            Turn();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Main_Character.Status());
            MessageBox.Show(Secondary_Character.Status());
            MessageBox.Show(Dragon.Status());
        }

        public void DeathCheck()
        {
            int shown = 0;

            if (Main_Character.HP <= 0)
            {
                Main_Character.HP = 0;
                Main_Character.Dead = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                shown++;

                if (Secondary_Character.HP > 0 && Dremur == false)
                {
                    
                    Secondary_Character.Name = "Dremur the Dragonslayer";
                    Secondary_Character.ATK = 28;
                    Secondary_Character.DEF = 15;
                    Secondary_Character.HL = 0;
                    Secondary_Character.HP = (Secondary_Character.HP*15)/10;
                    pictureBox3.Image = Properties.Resources.cc5876a41b7bd8d17119d0493f54f376;

                    Dremur = true;
                }

                if (shown <= 0)
                {
                    MessageBox.Show(Main_Character.Death(Dragon));
                }
            }

            if (Secondary_Character.HP <= 0)
            {
                Secondary_Character.HP = 0;
                Secondary_Character.Dead = true;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                shown++;

                if (shown <= 0)
                {
                    MessageBox.Show(Secondary_Character.Death(Dragon));
                }
            }

            if (TrenutniNeprijatelj.HP <= 0)
            {
                TrenutniNeprijatelj.HP = 0;
                TrenutniNeprijatelj.Dead = true;
                groupBox1.Enabled = false;
                button13.Enabled = true;
            }

            if (Main_Character.Dead == true && Secondary_Character.Dead == true && Dragon.Dead == false)
            {
                MessageBox.Show("Dro'ughul the Dreaded smiled at his victims and begun dragging them deeper into the caverns, allowing their bodies to fester in the damp cave air.");
                Lost_Count++;

                if(Lost_Count==6)
                {
                    MessageBox.Show("His neck snapped as it violently turned towards the screen. Tilting his head, the beast slithered: "+"'You are of a determined ssssort...You keep returning for my head, but you ssssshall not sssssucceed.', and as he approached, his mouth opened, and from it spewed fire. In a column of smoke, you stutter out of the caverns...");
                    Application.Exit();
                }
            }

            label1.Text = Main_Character.Status();
            label2.Text = Secondary_Character.Status();
            label3.Text = Dragon.Status();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Secondary_Character.HL += 1;
            Random message = new Random();
            int number = message.Next(0, 6);

            if (number == 1)
            {
                MessageBox.Show("A ray of light illuminates the knight, filling cracks in his armor. His armor is visibly reinforced.");
                Secondary_Character.DEF += 1;
                Turn();
            }
            if (number == 2)
            {
                MessageBox.Show("The Knight begins to kneel before George, taking in his divine energy.");
                Secondary_Character.HL += 1;
                Turn();
            }
            if (number == 3)
            {
                MessageBox.Show("The Knight's armor begins to shine on it's own. On his back, a spear made of light forms.");
                Secondary_Character.SC += 1;
                Turn();
            }
            if (number == 4)
            {
                MessageBox.Show("The Knight's hands begin to spark with energy, his healing is increased.");
                Secondary_Character.HL += 2;
                Turn();
            }
            if (number == 5)
            {
                MessageBox.Show("The Knight's sword begins to burn with a Divine wrath. Attack damage is increased.");
                Secondary_Character.ATK += 1;
                Turn();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Main_Character.Bless_Self();
            Turn();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Secondary_Character.Throw_Spear(Dragon);
            Turn();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Main_Character.Raised == false)
            {
                Main_Character.Raised = true;
                Main_Character.Raise_Shield();
                button12.Text = "Lower Shield";
            }

            else
            {
                Main_Character.Raised = false;
                Main_Character.Lower_Shield();
                button12.Text = "Raise Shield";
            }

            Turn();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Secondary_Character.Raised == false)
            {
                Secondary_Character.Raised = true;
                Secondary_Character.Raise_Shield();
                button9.Text = "Lower Shield";
            }

            else
            {
                Secondary_Character.Raised = false;
                Secondary_Character.Lower_Shield();
                button9.Text = "Raise Shield";
            }

            Turn();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form2 Inventory = new Form2();
            Inventory.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Victory

            if (Main_Character.Dead == false && Main_Character.Fled == false && Secondary_Character.Dead == false && Secondary_Character.Fled == false)
            {
                //Journey Ending - Novice
                MessageBox.Show("");
                Main_Character.HP += 5;
                Secondary_Character.HP += 5;
                Main_Character.ATK += 1;
                Secondary_Character.ATK += 1;

                pictureBox1.Height = 109;
                pictureBox1.Width = 99;
                pictureBox1.Image = WindowsFormsApplication3.Resource1.pixel_golem_by_moxomo_d7mecb7;

                label3.Text = Golem.Status();

                groupBox1.Enabled = true;
                button13.Enabled = false;
            }

            if (Main_Character.Dead == false && Main_Character.Fled == true && Secondary_Character.Dead == false && Secondary_Character.Fled == false)
            {
                //Underdog Ending - Normal

            }

            if (Main_Character.Dead == false && Main_Character.Fled == false && Secondary_Character.Dead == true && Secondary_Character.Fled == false)
            {
                //Lone Quest Ending - Hard

            }


            if (Main_Character.Dead == true && Main_Character.Fled == false && Secondary_Character.Dead == false && Secondary_Character.Fled == false)
            {
                //Memory Ending - Hard

                MessageBox.Show("");
                Main_Character.HP += 5;
                Secondary_Character.HP += 5;
                Main_Character.ATK += 1;
                Secondary_Character.ATK += 1;

                pictureBox1.Height = 108;
                pictureBox1.Width = 99;
                pictureBox1.Image = WindowsFormsApplication3.Resource1.pixel_golem_by_moxomo_d7mecb7;

                label3.Text = Golem.Status();
                groupBox1.Text = "Gen the Golem";

                groupBox1.Enabled = true;
                button13.Enabled = false;

                Turn_Count = 1;

                TrenutniNeprijatelj = Golem;
                TrenutniNeprijatelj.Dead = false;
            }


            if (Main_Character.Dead == false && Main_Character.Fled == false && Secondary_Character.Dead == false && Secondary_Character.Fled == true)
            {
                //Fire Heart Ending - Insane

            }

            if (Main_Character.Dead == true && Main_Character.Fled == false && Secondary_Character.Dead == true && Secondary_Character.Fled == false)
            {
                //Lost Ending - GAME OVER

            }

            if (Main_Character.Dead == false && Main_Character.Fled == true && Secondary_Character.Dead == false && Secondary_Character.Fled == true)
            {
                //Coward Ending - GAME OVER

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class Golem_Character:Dragon_Character
    {
        public int HL;
        public int BD;
        public int RD;
        public bool Revived;

        public Golem_Character(string Name, int HP, int DEF, int ATK, int LT, int HL, int BD, int RD) : base(Name, HP, DEF, ATK, LT)
        {
            this.HL = HL;
            this.BD = BD;
            this.RD = RD;
            
            this.Revived = false;
        }

        public string Attack(Player_Character player)
        {
            Random attack = new Random();
            int choice = attack.Next(0, 3);

            if (choice == 0 || choice == 1 || choice == 2)
            {
                if (choice == 0)
                {
                    if (this.Dead == false)
                    {
                        if (player.Name != "Prince George")
                        {
                            int damage_dealt = this.ATK - player.DEF;
                            string message0 = this.Name + " has clobbered " + player.Name + " viciously, causing " + damage_dealt + " damage.";
                            player.TakeDamage(this.ATK);
                            return message0;
                        }

                        else
                        {
                            int damage_dealt = this.ATK - player.DEF;
                            string altmessage0 = this.Name + " lurches at " + player.Name + ", attacking them in a maniacal manner, dealing " + damage_dealt * 2 + " damage.";
                            player.TakeDamage(this.ATK);
                            return altmessage0;
                        }
                    }
                    else return this.Name + " seems to be a pile of rocks...";
                }

                else if (choice == 1)
                {
                    if (this.Dead == false)
                    {
                        if (player.Name != "Prince George")
                        {
                            int damage_dealt = this.BD - player.DEF;
                            string message1 = this.Name + " has clobbered " + player.Name + " viciously, causing " + damage_dealt + " damage.";
                            player.TakeDamage(this.BD);
                            return message1;
                        }

                        else
                        {
                            int damage_dealt = this.BD - player.DEF;
                            string altmessage1 = this.Name + " lurches at " + player.Name + ", attacking them in a maniacal manner, dealing " + damage_dealt * 2 + " damage.";
                            player.TakeDamage(this.BD);
                            return altmessage1;
                        }
                    }
                    else return this.Name + " can't be found...";
                }

                else if (choice == 2)
                {
                    if (this.Dead == false)
                    {
                        if (player.Name != "Prince George")
                        {
                            int damage_dealt = this.RD - player.DEF;
                            string message2 = this.Name + " has clobbered " + player.Name + " viciously, causing " + damage_dealt + " damage.";
                            player.TakeDamage(this.RD);
                            return message2;
                        }

                        else
                        {
                            int damage_dealt = this.RD - player.DEF;
                            string altmessage2 = this.Name + " lurches at " + player.Name + ", attacking them in a maniacal manner, dealing " + damage_dealt * 2 + " damage.";
                            player.TakeDamage(this.RD);
                            return altmessage2;
                        }
                    }
                    else return this.Name + " is now a pebble...";
                }
            }

            else return null;
        }

        public override void SpecialAttack()
        {

        }

        public override string TakeDamage(int attack)
        {
            int damage_taken = attack - this.DEF;
            this.HP -= damage_taken;
            string message = this.Name + " has been slashed with " + attack + " attack points, which inflicted " + damage_taken + " damage.";
            return message;
        }

        public override string Status()
        {
            return
                    "Name: " + this.Name +
                    "\r\nHealth: " + this.HP +
                    "\r\nAttack: " + this.ATK +
                    "\r\nDefence: " + this.DEF;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class Dragon_Character
    {
            public string Name;
            public int HP;
            public int DEF;
            public int ATK;
            public int LT;
            public bool Dead;
        
            public Dragon_Character(string Name, int HP, int DEF, int ATK, int LT)
            {
                this.Name = Name;
                this.HP = HP;
                this.DEF = DEF;
                this.ATK = ATK;
                this.LT = LT;

                this.Dead = false;
            }

            public string Attack(Player_Character player)
            {
                if (this.Dead == false)
                {
                    if (player.Name != "Prince George")
                    {
                        int damage_dealt = this.ATK - player.DEF;
                        string message = this.Name + " has attacked " + player.Name + " viciously, causing " + damage_dealt + " damage.";
                        player.TakeDamage(this.ATK);
                        return message;
                    }

                    else
                    {
                        int damage_dealt = this.ATK - player.DEF;
                        string altmessage = this.Name + " lurches at " + player.Name + ", attacking them in a maniacal manner, dealing " + damage_dealt * 2 + " damage.";
                        player.TakeDamage(this.ATK);
                        return altmessage;
                    }
                }
                else return this.Name+" lies motionless. He seems to have succumb to his wounds.";
            }

            public virtual string TakeDamage(int attack)
            {
                int damage_taken = attack - this.DEF;
                this.HP -= damage_taken;
                string message = this.Name + " has been slashed with " + attack + " attack points, which inflicted " + damage_taken + " damage.";
                return message;
            }

            public void Heal()
            {

            }

            public void Flee()
            {

            }

            public virtual void SpecialAttack()
            {

            }

            public virtual string Status()
            {
                return
                    "Name: " + this.Name +
                    "\r\nHealth: " + this.HP +
                    "\r\nAttack: " + this.ATK +
                    "\r\nDefence: " + this.DEF;
            }

            public string Loot()
            {
                return this.LT + " gold";
            }

            public string Death()
            {
                    return this.Name + "";
            }
    }
}

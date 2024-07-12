using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class Player_Character
    {
        public string Name;
        public int HP;
        public int DEF;
        public int ATK;
        public bool Fled;
        public int HL;
        public int SC;
        public bool Dead;
        public bool Raised;

        public Player_Character(string Name, int HP, int DEF, int ATK, int HL, int SC) 
        {
            this.Name = Name;
            this.HP = HP;
            this.ATK = ATK;
            this.DEF = DEF;
            this.HL = HL;
            this.SC = SC;

            this.Dead = false;
            this.Fled = false;
            this.Raised = false;
        }

        public string Attack(Dragon_Character dragon)
        {
                int attack = this.ATK;
                dragon.TakeDamage(attack);
                return this.Name + " attacks " + dragon.Name + " with their sword, dealing " + (this.ATK - dragon.DEF) + " damage.";
        }

        public string TakeDamage(int attack)
        {
            if (this.Name != "Prince George")
            {
                int damage_taken = attack - this.DEF;
                this.HP -= damage_taken;
                if (this.HP > 0)
                {
                    return this.Name + " has been attacked for " + damage_taken + " damage! He has " + this.HP + " remaining health!";
                }

                else
                {
                    Dead = true;
                    return this.Name + " stumbles backwards as a slash cuts through their armor. They are dead!";
                }
            }

            else
            {
                int damage_taken = attack - this.DEF;
                this.HP -= damage_taken*2;
                if (this.HP > 0)
                {
                    return this.Name + " has been attacked for " + damage_taken*2 + " damage! He has " + this.HP + " remaining health!";
                }

                else
                {
                    Dead = true;
                    return this.Name + " stumbles backwards as a slash cuts through their armor. They are dead!";
                }
            }

        }

        public string Heal()
        {
            int heal = this.HL;
            this.HP += heal;
            return this.Name + " replenishes " + heal + " health through praise before rearming himself.";
        }

        public void Flee()
        {
            Fled = true;
        }

        public string Status()
        {
            return 
                "Name: "+this.Name+
                "\r\nHealth: "+this.HP+
                "\r\nAttack: "+this.ATK+
                "\r\nDefence: "+this.DEF+
                "\r\nSpears: " + this.SC;
        }

        public void Bless_Self()
        {
            if (this.HL <= 25)
            {
                MessageBox.Show(this.Name+" prays, and as his armor begins to shine brighter, he can feel the Gods within himself...");
                this.HL += 5;
            }
            else MessageBox.Show(this.Name+" prays, but nothing changes. The Gods have given him their all.");
        }

        public void Raise_Shield()
        {
            this.Raised = true;
            this.DEF += 7;
            this.ATK -= 4;
            MessageBox.Show(this.Name+" raises their shield, bolstering their defence, but hindering their mobility.");
        }

        public void Lower_Shield()
        {
            this.Raised = false;
            this.DEF -= 7;
            this.ATK += 4;
            MessageBox.Show(this.Name+"lowers their shield, bolstering their attack, but decreasing. their defense!");
        }

        public void Berzerk()
        {
            
        }

        public void Throw_Spear(Dragon_Character dragon)
        {
            int spear_damage = (this.ATK * 14)/10;

            if (this.SC > 0)
            {
                MessageBox.Show(this.Name + " takes a spear off their backs and throws it at the beast, dealing " + spear_damage + " damage!");
                dragon.HP -= spear_damage;
                this.SC--;
            }

            else
            {
                MessageBox.Show(this.Name + " reaches behind their backs, only to find they've run out of spears!");
                this.SC = 0;
            }
        }

        public string Death(Dragon_Character dragon)
        {
            if (this.Dead == true)
            {
                string message = dragon.Name + " picks up " + this.Name + " and hurls him across the room. His body hits the cavern walls, and a loud crack can be heard. Lifeless, his body plumps to the ground.";
                if (this.Name == "Prince George")
                {
                    {
                        string alternative = dragon.Name + " picks up " + this.Name + " and hurls him across the room. His body hits the cavern walls, and a loud crack can be heard. Lifeless, his body plumps to the ground. The Loyal Knight rushes to his side. Lifting his visor, Dremur, the Dragonslayer, picks up the prince's sword in righteous fury. His armor begins to shine with the prince's aura, protecting him.";
                        return alternative;
                    }
                }
                else return message;
            }
            else return null;
        }

        //
    }
}


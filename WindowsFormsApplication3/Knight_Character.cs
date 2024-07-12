using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class Knight_Character:Player_Character
    {
        public Knight_Character(string Name, int HP, int DEF, int ATK, int HL, int SC) : base(Name, HP, DEF, ATK, HL, SC)
        {
            /* This is working...*/
        }
    }
}

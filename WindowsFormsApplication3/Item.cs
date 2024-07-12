using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    abstract class Item
    {
        public string Name;
        public Label Slot;
        public PictureBox Sprite;
        public bool Used;

        public Item(string Name, Label Slot, PictureBox Sprite, bool Used):base()
        {
            this.Name = Name;
            this.Slot = Slot;
            this.Sprite = Sprite;
            this.Used = Used;
        }
    }
}

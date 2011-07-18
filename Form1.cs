using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutosizeNightmare
{
    public partial class Form1 : Form
    {
        List<GroupBox> gbs = new List<GroupBox>();

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 4; i++)
            {
                GroupBox b = createCustomGB(""+i);
                gbs.Add(b);
                flowLayoutPanel1.Controls.Add(b);
            }

            /*
            groupBox1.MinimumSize = new Size(
                flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Right - 10,
                0                                           
                );
             */
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (GroupBox g in gbs)
            {
                g.MinimumSize = new Size(
                    flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Right - 10,
                    0
                );
            }
        }

        private GroupBox createCustomGB(String name)
        {
            GroupBox gb = new GroupBox();
            gb.AutoSize = true;
            gb.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            
            FlowLayoutPanel p = new FlowLayoutPanel();
            p.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            p.AutoSize = true;
            p.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            p.WrapContents = true;
            p.Location = new System.Drawing.Point(6, 19);

            gb.Controls.Add(p);
            gb.Text = String.Format("Group {0}", name);

            for (int i = 0; i < 4; i++)
            {
                Button b = new Button();
                b.Text = String.Format("Button {0}", i);
                p.Controls.Add(b);
            }
                        
            gb.MinimumSize = new Size(
                flowLayoutPanel1.Size.Width - flowLayoutPanel1.Margin.Right - 10,
                0
            );

            return gb;
        }
    }
}

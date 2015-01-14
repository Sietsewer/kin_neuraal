using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private CheckBox[,] currentGrid;
        private List<gridValueCombination> grids;
        private int index = 1;
        //private int size = 0;
        public Form1()
        {
            grids = new List<gridValueCombination>();
            grids.Add(new gridValueCombination());
            currentGrid = new CheckBox[5, 5];
            InitializeComponent();
            hodorCodor();
            
        }

        private void saveGrid(int i)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    grids.ElementAt(index).grid[x, y] = this.currentGrid[x, y].Checked;
                    grids.ElementAt(index).value = this.value.Text;
                }
            }
        }

        private void loadGrid(int i)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    this.currentGrid[x, y].Checked = grids.ElementAt(index).grid[x,y];
                    this.value.Text = grids.ElementAt(index).value + "";
                }
            }
        }

        private void linkGrid()
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void hodorCodor()
        {
    //             HORRID CODE AHEAD               //
    // READ AT YOUR OWN RISK, YOU HAVE BEEN WARNED //

            currentGrid[0, 0] = checkBox1;
            currentGrid[1, 0] = checkBox2;
            currentGrid[2, 0] = checkBox3;
            currentGrid[3, 0] = checkBox4;
            currentGrid[4, 0] = checkBox5;

            currentGrid[0, 1] = checkBox6;
            currentGrid[1, 1] = checkBox7;
            currentGrid[2, 1] = checkBox8;
            currentGrid[3, 1] = checkBox9;
            currentGrid[4, 1] = checkBox10;

            currentGrid[0, 2] = checkBox11;
            currentGrid[1, 2] = checkBox12;
            currentGrid[2, 2] = checkBox13;
            currentGrid[3, 2] = checkBox14;
            currentGrid[4, 2] = checkBox15;

            currentGrid[0, 3] = checkBox16;
            currentGrid[1, 3] = checkBox17;
            currentGrid[2, 3] = checkBox18;
            currentGrid[3, 3] = checkBox19;
            currentGrid[4, 3] = checkBox20;

            currentGrid[0, 4] = checkBox21;
            currentGrid[1, 4] = checkBox22;
            currentGrid[2, 4] = checkBox23;
            currentGrid[3, 4] = checkBox24;
            currentGrid[4, 4] = checkBox25;

    // I need to bathe in acid to feel clean again. //
        }

        private void nextGrid_Click(object sender, EventArgs e)
        {
            if (grids.Count != index+1 && grids.Count > index)
            {
                saveGrid(index);
                index++;
                loadGrid(index);
            }
            this.Text = "Grid converter [" + (index + 1) + "/" + grids.Count + "]";
        }

        private void previousGrid_Click(object sender, EventArgs e)
        {
            if (index != 0)
            {
                saveGrid(index);
                index--;
                loadGrid(index);
            }
            this.Text = "Grid converter [" + (index + 1) + "/" + grids.Count + "]";
        }

        private void addGrid_Click(object sender, EventArgs e)
        {
            grids.Add(new gridValueCombination());
            this.Text = "Grid converter [" + (index + 1) + "/" + grids.Count + "]";
            if (index == 0)
            {
                index = 1;
            }
        }

        private void deleteGrid_Click(object sender, EventArgs e)
        {
            if (grids.Count > 0 && grids.Count != 1)
            {
                grids.RemoveAt(index > grids.Count-1 ? grids.Count-1 : index);
            }
            if (index > grids.Count || index == grids.Count)
            {
                index = grids.Count - 1;
            }
            this.Text = "Grid converter [" + (index + 1) + "/" + grids.Count + "]";
            if (index == 0)
            {
                index = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveGrid(index);
            String outText = "[";
            for(int i = 0; i < grids.Count; i++){

                outText += i == grids.Count-1 ? grids[i].ToString() : grids[i].ToString() + ", ";
            }
            outText += "]";
            this.text.Text = outText;
        }

        private void textToGrids_Click(object sender, EventArgs e)
        {
            index = 0;
            grids = new List<gridValueCombination>();
            //string[] level_1 = text.Text.Trim('[', ' ', ']').Split(',');
            Regex getTagsFull = new Regex(@"\[(., *)*(.)\]/\[(., *)*(.)\]", RegexOptions.None);
            MatchCollection hits = getTagsFull.Matches(text.Text);
            foreach (Match m in hits)
            {
                grids.Add(new gridValueCombination(m.Value));
            }
        }
    }
}

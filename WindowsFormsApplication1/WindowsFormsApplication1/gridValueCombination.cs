using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class gridValueCombination
    {
        public string value;
        public bool[,] grid;

        public override string ToString()
        {
            string returnME = "[";
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    returnME += grid[x, y] ? "1" : "0";
                    if ((x != 4 || y != 4))
                    {
                        returnME += ", ";
                    }
                }
            }
            returnME += "]/[";
            bool[] b = new bool[8];
            if (value.Length > 0)
            {
                b = ((Int32)value[0]).ToBooleanArray();
            }
            for (int i = 0; i < 8; i++)
            {
                returnME += b[i] ? "1" : "0";
                if (i != 7)
                {
                    returnME += ", ";
                }
            }
            //returnME += ((Int32)value[0]) + "";
            returnME += "]";
            return returnME;
        }

        public gridValueCombination()
        {
            grid = new bool[5, 5];
        }

        public gridValueCombination(string _value, bool[,] _grid)
        {
            this.value = _value;
            this.grid = _grid;
        }

        public gridValueCombination(string data)
        {
            grid = new bool[5, 5];
            string[] level1 = data.Split('/');
            string[] level1_1 = level1[0].Trim('[', ']', ' ').Split(',');
            int iterator = 0;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    grid[x, y] = level1_1[iterator].Trim() == "1";
                    iterator++;
                }
            }
            string[] level1_2 = level1[1].Trim('[', ']', ' ').Split(',');
            bool[] b = new bool[8];
            string boolean="";
            for (int i = 0; i < 8; i++)
            {
                boolean += level1_2[i].Trim();
            }
            value = ((char)Convert.ToInt32(boolean, 2)).ToString();
            int l = 0;
        }
    }
}

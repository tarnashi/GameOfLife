using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLife.GameClasses
{
    public class BorderedField : Field
    {
        public BorderedField(int x, int y) : base(x, y)
        {
        }

        public override byte NumberOfNeighbors(int x, int y)
        {
            //создаем и зануляем количество соседей
            byte n = 0;
            //считаем соседей
            //три слева
            if (x != 0)
            {
                if (y != 0)
                {
                    if (ArrayCurrent[x - 1, y - 1])
                    {
                        n++;
                    }
                }
                if (ArrayCurrent[x - 1, y])
                {
                    n++;
                }
                if (y != height - 1)
                {
                    if (ArrayCurrent[x - 1, y + 1])
                    {
                        n++;
                    }
                }
            }
            //два по центру
            if (y != 0)
            {
                if (ArrayCurrent[x, y - 1])
                {
                    n++;
                }
            }
            if (y != height - 1)
            {
                if (ArrayCurrent[x, y + 1])
                {
                    n++;
                }
            }
            //три справа
            if (x != width - 1)
            {
                if (y != 0)
                {
                    if (ArrayCurrent[x + 1, y - 1])
                    {
                        n++;
                    }
                }
                if (ArrayCurrent[x + 1, y])
                {
                    n++;
                }
                if (y != height - 1)
                {
                    if (ArrayCurrent[x + 1, y + 1])
                    {
                        n++;
                    }
                }
            }
            return n;
        }
    }
}
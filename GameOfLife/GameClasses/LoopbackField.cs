using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLife.GameClasses
{
    public class LoopbackField : Field
    {
        public LoopbackField(int x, int y) : base(x, y)
        {
        }

        public override byte NumberOfNeighbors(int x, int y)
        {
            //создаем и зануляем количество соседей
            byte n = 0;
            //считаем соседей
            //три слева
            int x1 = (x == 0) ? width - 1 : x - 1;
            int y1 = (y == 0) ? height - 1 : y - 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = y;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = (y == height-1) ? 0 : y + 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            //два по центру
            x1 = x;
            y1 = (y == 0) ? height - 1 : y - 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = (y == height - 1) ? 0 : y + 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            //три справа
            x1 = (x == width - 1) ? 0 : x + 1;
            y1 = (y == 0) ? height - 1 : y - 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = y;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = (y == height - 1) ? 0 : y + 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            return n;
        }
    }
}
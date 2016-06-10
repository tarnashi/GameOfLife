using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLife.GameClasses
{
    public abstract class Field
    {
        //ПОЛЯ
        //Размеры поля
        public int width, height;
        //Два массива: основной и буферный
        public bool[,] ArrayCurrent;
        //Режим поля: добавление, удаление, заблокировано
        public byte mode;

        public Field(int x, int y)
        {
            width = x;
            height = y;
            ArrayCurrent = new bool[x, y];
            Clear();
        }

        public bool this[int x, int y]
        {
            get { return ArrayCurrent[x, y]; }
        }

        public void Clear()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    ArrayCurrent[x, y] = false;
                }
        }

        public void MakeMove()
        {
            bool[,] ArrayTMP = new bool[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    byte localNubmerOfNeighbors = NumberOfNeighbors(x, y);
                    if (ArrayCurrent[x, y])
                    {
                        if (localNubmerOfNeighbors < 2 || localNubmerOfNeighbors > 3)
                        {
                            //Если клетка жива и имеет меньше двух или больше трех живых соседей, она становится мертвой
                            ArrayTMP[x, y] = false;
                        }
                        else
                        {
                            //Оставляем как есть
                            ArrayTMP[x, y] = ArrayCurrent[x, y];
                        }
                    }
                    else
                    {
                        if (localNubmerOfNeighbors == 3)
                        {
                            //Если клетка мертва и имеет трех живых соседей, она становится живой
                            ArrayTMP[x, y] = true;
                        }
                        else
                        {
                            //Оставляем как есть
                            ArrayTMP[x, y] = ArrayCurrent[x, y];
                        }
                    }
                }

            //Просто меняем ссылку на массив. Не пахнет ли такой вариант?
            ArrayCurrent = ArrayTMP;

        }

        public abstract byte NumberOfNeighbors(int x, int y);

    }
}
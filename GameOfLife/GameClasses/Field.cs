using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Helpers;

namespace GameOfLife.GameClasses
{
    public abstract class Field
    {
        //ПОЛЯ
        //Размеры поля
        public int width { get; protected set; }
        public int height { get; protected set; }
        //массив с полем
        public bool[,] CurrentField { get; protected set; }
        //trnv note 
        //закомментил, пока не используется
        //Режим поля: добавление, удаление, заблокировано
        //public byte mode;

        public Field(int x, int y)
        {
            width = x;
            height = y;
            CurrentField = new bool[x, y];
            Clear();
        }

        public bool this[int x, int y]
        {
            get { return CurrentField[x, y]; }
        }

        public void Clear()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    CurrentField[x, y] = false;
                }
        }

        public void MakeMove()
        {
            bool[,] FieldTMP = new bool[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    byte localNubmerOfNeighbors = NumberOfNeighbors(x, y);
                    if (CurrentField[x, y])
                    {
                        if (localNubmerOfNeighbors < 2 || localNubmerOfNeighbors > 3)
                        {
                            //Если клетка жива и имеет меньше двух или больше трех живых соседей, она становится мертвой
                            FieldTMP[x, y] = false;
                        }
                        else
                        {
                            //Оставляем как есть
                            FieldTMP[x, y] = CurrentField[x, y];
                        }
                    }
                    else
                    {
                        if (localNubmerOfNeighbors == 3)
                        {
                            //Если клетка мертва и имеет трех живых соседей, она становится живой
                            FieldTMP[x, y] = true;
                        }
                        else
                        {
                            //Оставляем как есть
                            FieldTMP[x, y] = CurrentField[x, y];
                        }
                    }
                }

            //Просто меняем ссылку на массив. Не пахнет ли такой вариант?
            CurrentField = FieldTMP;

        }

        public void ChangeCell(int x, int y)
        {
            CurrentField[x, y] = !CurrentField[x, y];
        }

        public void SetPlaner()
        {
            Clear();
            CurrentField[1, 0] = true;
            CurrentField[2, 1] = true;
            CurrentField[0, 2] = true;
            CurrentField[1, 2] = true;
            CurrentField[2, 2] = true;
        }

        public abstract byte NumberOfNeighbors(int x, int y);

    }
}
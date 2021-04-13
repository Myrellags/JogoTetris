using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTetris
{
    class BlockMM
    {


        int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

        private Guid _id;
        private Boolean _moving;
        private Boolean _filled;
        public Guid Id
        {
            get { return _id; }
        }

        public Boolean Moving
        {
            get { return _moving; }
            set { _moving = value; }
        }
        public Boolean Filled
        {
            get { return _filled; }
            set { _filled = value; }
        }
        public BlockMM()
        {
            _id = new Guid();

        }
        public BlockMM(int[,] arr)
        {
            _id = new Guid();
            _moving = true;
        }

        static void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    System.Console.WriteLine("Element({0},{1})={2}", i, j, arr[i, j]);
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTetris
{
    class Block
    {
        private Guid _id;
        private int _col;
        private int _row;
        private Boolean _moving;
        private Boolean _filled;
        public Guid Id
        {
            get { return _id; }
        }

        public int Col
        {
            get { return _col; }
            set { _col = value; }
        }
        public int Row
        {
            get { return _row; }
            set { _row = value; }
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
        public Block()
        {
            _id = new Guid();

        }
        public Block(int row, int col)
        {
            _row = row;
            _col = col;
            _id = new Guid();
            _moving = true;
        }
    }
}


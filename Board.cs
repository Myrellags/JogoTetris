using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JogoTetris
{
    public enum MoveType
    {
        Left,
        Right
    }
    public class Board
    {
        List<Block> _blocks = new List<Block>();
        List<Block> _blockstoclear = new List<Block>();

        public List<Block> Blocks
        {
            get { return _blocks; }
        }

        public event EventHandler Refresh;

        private void OnRefresh(object sender, EventArgs e)
        {
            //Null check makes sure the main page is attached to the event
            if (this.Refresh != null)
            {
                this.Refresh(sender, e);
            }
        }

        //public event EventHandler Refresh;
        //public void OnRefresh()
        //{
        //    EventHandler handler = Refresh;
        //    if (null != handler) handler(this, EventArgs.Empty);
        //    if (this.Refresh != null)
        //    {
        //        this.Refresh(sender, e);
        //    }

        //}

        //public event EventHandler ClearBlocks;
        //public void OnClearBlocks()
        //{
        //    EventHandler handler = ClearBlocks;
        //    if (null != handler) handler(this, EventArgs.Empty);
        //}

        public Board()
        {
            Block block = new Block(1, 5);
            _blocks.Add(block);
        }

        public List<Block> OrangeRicky()//  __|
        {
            Block block = new Block(2, 5);
            _blocks.Add(block);
            block = new Block(2, 6);
            _blocks.Add(block);
            block = new Block(2, 7);
            _blocks.Add(block);
            block = new Block(1, 7);
            _blocks.Add(block);
            return _blocks;
        }

        public void BlueRicky()//  |__
        {
            Block block = new Block(1, 5);
            _blocks.Add(block);
            block = new Block(2, 5);
            _blocks.Add(block);
            block = new Block(2, 6);
            _blocks.Add(block);
            block = new Block(2, 7);
            _blocks.Add(block);
        }

        public void ClevelandZ()//  -|_
        {

        }

        public void RhodeIslandZ()//  _|-
        {

        }

        public void Hero()//  ______
        {

        }

        public void Teewee()//  _|_
        {

        }

        public void Smashboy()//  □□
        {                     //  □□
            Block block = new Block(1, 5);
            _blocks.Add(block);
            block = new Block(1, 6);
            _blocks.Add(block);
            block = new Block(2, 5);
            _blocks.Add(block);
            block = new Block(2, 6);
            _blocks.Add(block);
        }
        public void LeftRight(MoveType move)
        {
            var index = _blocks.FindIndex(b => b.Moving.Equals(true));

            if (index < 0)
            {
                Block block = new Block(1, 5);
                _blocks.Add(block);
                index = _blocks.FindIndex(b => b.Moving.Equals(true));
            }

            //future move is
            int x = _blocks[index].Col;
            int y = _blocks[index].Row;

            switch (move)
            {
                case MoveType.Left:
                    x -= 1;
                    break;
                case MoveType.Right:
                    x += 1;
                    break;
            }
            if (x < 0)
            {
                x = 0;
            }
            if (x > 9)
            {
                x = 9;
            }
            //lets check if future move goes to used block
            var alreadyinuse = _blocks.Where(b => !b.Id.Equals(_blocks[index].Id)).Where(b => b.Row.Equals(y)).Where(b => b.Col.Equals(x)).ToList();
            if (alreadyinuse.Count > 0)
            {
                _blocks[index].Moving = false;
            }
            else
            {
                _blocks[index].Col = x;
            }

            // Raise the event.
            Refresh(this, null);
        }
        public void Down()
        {
            var index = _blocks.FindIndex(b => b.Moving.Equals(true));

            if (index < 0)
            {
                Block block = new Block(1, 5);
                _blocks.Add(block);
                index = _blocks.FindIndex(b => b.Moving.Equals(true));
            }

            //future move is
            int x = _blocks[index].Col;
            int y = _blocks[index].Row + 1;

            //lets check if future move goes to used block
            var alreadyinuse = _blocks.Where(b => b.Row.Equals(y)).Where(b => b.Col.Equals(x)).ToList();
            if (alreadyinuse.Count > 0)
            {
                _blocks[index].Moving = false;
            }
            else if (y == 15)
            {
                _blocks[index].Moving = false;
                _blocks[index].Row = y;
            }
            else
            {
                _blocks[index].Row = y;
            }



            // agora verificar se existem linhas totalmente preenchidas
            for (int i = 1; i <= 15; i++)
            {
                var check = _blocks.Where(b => b.Row.Equals(i)).ToList();
                if (check.Count == 10)
                {
                    foreach (Block b in check)
                    {
                        check[check.IndexOf(b)].Filled = true;
                    }
                }
            }

            // Raise the event.
            Refresh(this, null);

            if (HasBlocksToClear())
            {
                Thread.Sleep(100);
                ClearComplete();
                Refresh(this, null);
            }

        }

        public Boolean HasBlocksToClear()
        {
            _blockstoclear = _blocks.Where(b => b.Filled.Equals(true)).ToList();
            return _blockstoclear.Count > 0;
        }
        public void ClearComplete()
        {
            foreach (Block b in _blockstoclear)
            {
                _blocks.Remove(b);
            }
            foreach (Block b in _blocks)
            {
                _blocks[_blocks.IndexOf(b)].Row += 1;
            }
        }
    }
}

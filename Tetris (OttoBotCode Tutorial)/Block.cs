using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris__OttoBotCode_Tutorial_
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }
        private int rotatationState;
        private Position offset;
        public Block() 
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Position> TilePositions() 
        {
            foreach(Position p in Tiles[rotatationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);

            }
        }

        public void RotateCW()
        {
            rotatationState = (rotatationState + 1) % Tiles.Length;
        }

        public void RotateCCW()
        {
            if(rotatationState == 0)
            {
                rotatationState = Tiles.Length - 1;
            }
            else
            {
                rotatationState--;
            }    
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotatationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}

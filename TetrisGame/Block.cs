using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; } // Decide where is the tile spawns in the grid
        public abstract int Id { get; } // Used to distinguish the blocks
        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column); ;
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach(Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        // Rotate the block 90 degrees clockwise
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Rotate counter clockwise
        public void RotateCCW()
        {
            if (rotationState == 0) rotationState = Tiles.Length - 1;
            else rotationState--;
        }

        // Move the block by a given of rows and cols
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        // Reset the rotation and position
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Blocks;

namespace TetrisGame
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[] {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };
        private readonly Random random= new Random();
        public Block NextBlock { get; private set; }

        // Assign NextBlock = RandomBlock
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        // Return random block
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        // Return the next block & update the property
        public Block GetAndUpdate()
        {
            Block block = NextBlock; 

            // Keep the next block doesn't return twice in a row
            do
            {
                NextBlock = RandomBlock();
            } while (block.Id == NextBlock.Id);

            return block;
        }
    }
}

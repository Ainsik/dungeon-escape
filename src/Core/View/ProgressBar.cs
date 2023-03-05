namespace Dungeon_Crawl.src.Core.View
{
    public class ProgressBar
    {
        public string block = "■";

        public int CountBlock(int currentValue, int maxValue)
        {
            int maxBlockQuantity = 28;
            int currentBlockQuantity = maxBlockQuantity * currentValue / maxValue;
            if (currentBlockQuantity < 0)
                currentBlockQuantity = 0;
            return currentBlockQuantity;
        }

        public string DrawBar(int currentValue, int maxValue)
        {
            int numberOfBlocks = CountBlock(currentValue, maxValue);
            string bar = new String('■', numberOfBlocks);
            return bar;
        }
    }
}

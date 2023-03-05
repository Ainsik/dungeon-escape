using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Core.View
{
    internal class Sidebar
    {
        private const int _sidebarWidth = 30;
        private List<string> _frame = new();
        public List<string> CreateFrame(int height)
        {
            var topLine = new StringBuilder().Append('/').Append('-', _sidebarWidth - 2).Append("\\").ToString();
            var bottomLine = new StringBuilder().Append('\\').Append('-', _sidebarWidth - 2).Append("/").ToString();

            _frame.Insert(0, topLine);

            var alreadyAdded = _frame.Count + 1;

            for (int i = 0; i < height - alreadyAdded; i++)
            {
                AddEmptyLine();
            }
            _frame.Add(bottomLine);

            var finishedFrame = _frame;
            _frame = new();
            return finishedFrame;
        }

        public void AddHorizontalRule()
        {
            _frame.Add(new StringBuilder().Append("|").Append('-', _sidebarWidth - 2).Append("|").ToString());
        }
        public void AddCenteredText(string text)
        {
            text = text[0..Math.Min(text.Length, _sidebarWidth - 2)];
            _frame.Add(new StringBuilder().Append("|").Append(' ', _sidebarWidth / 2 - 1 - (int)Math.Ceiling(text.Length / 2f)).Append(text).Append(' ', _sidebarWidth / 2 - 1 - (int)Math.Floor(text.Length / 2f)).Append("|").ToString());
        }
        public void AddLeftAlignedText(string text)
        {
            text = text[0..Math.Min(text.Length, _sidebarWidth - 2)];
            _frame.Add(new StringBuilder().Append("|").Append(text.PadRight(_sidebarWidth - 2)).Append("|").ToString());
        }
        public void AddEmptyLine()
        {
            _frame.Add(new StringBuilder().Append("|").Append(' ', _sidebarWidth - 2).Append("|").ToString());
        }
    }
}

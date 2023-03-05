using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Core.View
{
    internal class InfoDialog : AskDialog
    {
        public InfoDialog(string text, string choice, SelectedChoiceHandler? handler) : base(text, new Tuple<string, string>(choice, choice), handler)
        {
        }

        public override string Choices => $"<{choices.Item1}>";
        public override void SelectLeft() => _selectedChoice = 0;
        public override void SelectRight() => _selectedChoice = 0;
    }
}

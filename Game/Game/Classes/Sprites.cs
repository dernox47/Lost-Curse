using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    public static class Sprites
    {
		public static readonly string[] RunRight = new[]
		{
				// 0
				@"   O   " + '\n' +
				@"   |_  " + '\n' +
				@"   |>  " + '\n' +
				@"  /|   ",
				// 1
				@"   O   " + '\n' +
				@"  <|L  " + '\n' +
				@"   |_  " + '\n' +
				@"   |/  ",
				// 2
				@"   O   " + '\n' +
				@"  L|L  " + '\n' +
				@"   |_  " + '\n' +
				@"  /  | ",
				// 3
				@"  _O   " + '\n' +
				@" | |L  " + '\n' +
				@"   /─  " + '\n' +
				@"  /  \ ",
				// 4
				@"  __O  " + '\n' +
				@" / /\_ " + '\n' +
				@"__/\   " + '\n' +
				@"    \  ",
				// 5
				@"   _O  " + '\n' +
				@"  |/|_ " + '\n' +
				@"  /\   " + '\n' +
				@" /  |  ",
				// 6
				@"    O  " + '\n' +
				@"  </L  " + '\n' +
				@"   \   " + '\n' +
				@"   /|  ",
		};

		public static readonly string[] RunLeft = new[]
		{
				// 0
				@"   O   " + '\n' +
				@"  _|   " + '\n' +
				@"  <|   " + '\n' +
				@"   |\  ",
				// 1
				@"   O   " + '\n' +
				@"  >|>  " + '\n' +
				@"  _|   " + '\n' +
				@"  \|   ",
				// 2
				@"   O   " + '\n' +
				@"  >|>  " + '\n' +
				@"  _|   " + '\n' +
				@" |  \  ",
				// 3
				@"   O_  " + '\n' +
				@"  >| | " + '\n' +
				@"  ─\   " + '\n' +
				@" /  \  ",
				// 4
				@"  O__  " + '\n' +
				@" _/\ \ " + '\n' +
				@"   /\__" + '\n' +
				@"  /    ",
				// 5
				@"  O_   " + '\n' +
				@" _|\|  " + '\n' +
				@"   /\  " + '\n' +
				@"  |  \ ",
				// 6
				@"  O    " + '\n' +
				@"  >\>  " + '\n' +
				@"   /   " + '\n' +
				@"  |\   ",
		};
	}
}

using System;
namespace B23_Ex02_TalKoren_312498520_SnirBabi_204264071
{
	public class Pair <T, K>
	{
        public T First { get; set; }
        public K Second { get; set; }

		public Pair() { }

        public Pair(T i_first, K i_second)
		{
			First = i_first;
			Second = i_second;

        }
	}
}


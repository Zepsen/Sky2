using System;
namespace Sky
{
	public class Map
	{
		private const int _size = 4;
		private int _max = _size - 1;

		private readonly int[][] _res =
		{
			new int[] { 0, 0, 0, 0 },
			new int[] { 0, 0, 0, 0 },
			new int[] { 0, 0, 0, 0 },
			new int[] { 0, 0, 0, 0 }
		};

		public bool Check()
		{
			for (int i = 0; i < _size; i++)
			{
				for (int j = 0; j < _size; j++)
				{
					if (_res[i][j] == 0)
					{
						return false;
					}
				}
			}

			return true;
		}
		public void Show()
		{
			for (int i = 0; i < _size; i++)
			{
				for (int j = 0; j < _size; j++)
				{
					Console.Write(" " + _res[i][j]);
				}

				Console.WriteLine();
			}
		}
		public void Set(int x, int y, int val)
		{
			_res[x][y] = val;
		}

		public void SetForAll(int n)
		{
			var side = n / _size;
			var v = n % _size;
			var val = 1;

			switch(side)
			{
				case 0: 
					for (int i = 0; i < _size; i++)
					{
						_res[i][v] = val++;
					}
					break;

				case 1: 
					for (int i = _max; i >= 0; i--)
					{
						_res[v][i] = val++;
					}
					break;

				case 2: 
					for (int i = _max; i >= 0; i--)
					{
						_res[i][_max-v] = val++;
					}
					break;

				case 3: 
					for (int i = 0; i < _size; i++)
					{
						_res[_max-v][i] = val++;
					}
					break;

				default:
					throw new ArgumentException();					
			}
		}

		public void SetFor1(int n)
		{
			var side = n / _size;
			var v = n % _size;
			switch(side)
			{
				case 0: 
					_res[0][v] = _size;
					break;

				case 1: 
					_res[v][_max] = _size;
					break;

				case 2: 
					_res[_max][_max-v] = _size;
					break;

				case 3: 
					_res[_max-v][0] = _size;
					break;

				default:
					throw new ArgumentException();					
			}
		}

		public void RunDefault(int[] arr) 
		{
			for (int i = 0; i < arr.Length; i++)
			{
				switch(arr[i])
				{
					case 1:  SetFor1(i);
						break;
					case _size: SetForAll(i);
						break;
				}
			}
		}
	}
}
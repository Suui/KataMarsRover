namespace KataMarsRover
{
	public class Location
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Location(int x, int y)
		{
			X = x;
			Y = y;
		}

		public void Sum(Location other)
		{
			X += other.X;
			Y += other.Y;
		}

		public void Delimit(int limit)
		{
			X %= limit + 1;
			X -= limit;
			X %= limit + 1;
			X += limit;

			Y %= limit + 1;
			Y -= limit;
			Y %= limit + 1;
			Y += limit;
		}

		protected bool Equals(Location other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			return Equals((Location) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}
	}
}
namespace KataMarsRover
{
	public class Location
	{
		public int X { get; }
		public int Y { get; }

		public Location(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static Location operator +(Location first, Location second)
		{
			return new Location(first.X + second.X, first.Y + second.Y);
		}

		protected bool Equals(Location other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
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
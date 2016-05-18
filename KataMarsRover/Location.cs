﻿namespace KataMarsRover
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
			if (Y < 0) Y = limit;
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
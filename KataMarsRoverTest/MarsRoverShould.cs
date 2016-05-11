using FluentAssertions;
using NUnit.Framework;

/* TODO
	- Start in the middle of Mars facing north
	- Face North, East, South or West
	- Be able to rotate to the left or to the right in single steps
	- Be able to move forward in single steps
*/

namespace KataMarsRoverTest
{
	[TestFixture]
	class MarsRoverShould
	{
		[Test]
		public void start_facing_north_in_the_center_of_mars()
		{
			var mars = new TestWorld(new MarsRover());

			mars.MarsRoverRotation.GetType().Should().Be(typeof (NorthRotation));
			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(0, 0));
		}
	}

	public class NorthRotation : Rotation
	{
	}

	public class MarsRover
	{
		public Rotation Rotation { get; set; }
		public Location Location { get; set; }
	}

	public class World
	{
		protected MarsRover MarsRover { get; set; }

		public World(MarsRover marsRover)
		{
			MarsRover = marsRover;
			MarsRover.Rotation = new NorthRotation();
			MarsRover.Location = new Location(0, 0);
		}
	}

	class TestWorld : World
	{
		public Rotation MarsRoverRotation => MarsRover.Rotation;
		public Location MarsRoverLocation => MarsRover.Location;

		public TestWorld(MarsRover marsRover) : base(marsRover) {}
	}

	public class Location
	{
		public int X { get; }
		public int Y { get; }

		public Location(int x, int y)
		{
			X = x;
			Y = y;
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

	public class Rotation
	{
	}
}

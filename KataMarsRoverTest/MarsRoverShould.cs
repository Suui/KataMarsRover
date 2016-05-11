using FluentAssertions;
using KataMarsRover;
using NUnit.Framework;

/* TODO
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
			var mars = new TestWorld();

			mars.MarsRoverRotation.ShouldBeEquivalentTo(Rotation.North());
			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(0, 0));
		}

		[Test]
		public void move_forward_when_facing_north()
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacingNorth();

			mars.MoveMarsRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(0, 1));
		}

		[Test]
		public void move_forward_when_facing_east()
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacingEast();

			mars.MoveMarsRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(1, 0));
		}

		[Test]
		public void move_forward_when_facing_south()
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacingSouth();

			mars.MoveMarsRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(0, -1));
		}

		private TestWorld AWorldWithAMarsRoverInTheMiddleFacingSouth()
		{
			return new TestWorld(new MarsRover
			{
				Location = new Location(0, 0),
				Rotation = Rotation.South()
			});
		}

		private static TestWorld AWorldWithAMarsRoverInTheMiddleFacingEast()
		{
			return new TestWorld(new MarsRover
			{
				Location = new Location(0, 0),
				Rotation = Rotation.East()
			});
		}

		private static TestWorld AWorldWithAMarsRoverInTheMiddleFacingNorth()
		{
			return new TestWorld(new MarsRover
			{
				Location = new Location(0, 0),
				Rotation = Rotation.North()
			});
		}
	}

	internal class TestWorld : World
	{
		public Rotation MarsRoverRotation => MarsRover.Rotation;
		public Location MarsRoverLocation => MarsRover.Location;

		public TestWorld() {}

		public TestWorld(MarsRover marsRover)
		{
			MarsRover = marsRover;
		}
	}
}

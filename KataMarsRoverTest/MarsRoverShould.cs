using FluentAssertions;
using KataMarsRover;
using KataMarsRover.Rotations;
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
			var mars = new TestWorld(new MarsRover());

			mars.MarsRoverRotation.GetType().Should().Be(typeof (NorthRotation));
			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(0, 0));
		}

		[Test]
		public void move_forward_when_facing_north()
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacingNorth();

			mars.MoveRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(0, 1));
		}

		private static TestWorld AWorldWithAMarsRoverInTheMiddleFacingNorth()
		{
			return new TestWorld(new MarsRover());
		}
	}

	internal class TestWorld : World
	{
		public Rotation MarsRoverRotation => MarsRover.Rotation;
		public Location MarsRoverLocation => MarsRover.Location;

		public TestWorld(MarsRover marsRover) : base(marsRover) { }
	}
}

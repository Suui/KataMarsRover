using FluentAssertions;
using KataMarsRover;
using NUnit.Framework;

/* TODO
	- Be able to rotate to the left or to the right in single steps
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
			var mars = AWorldWithAMarsRoverInTheMiddleFacing(Rotation.North());

			mars.MoveMarsRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(0, 1));
		}

		[Test]
		public void move_forward_when_facing_east()
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacing(Rotation.East());

			mars.MoveMarsRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(1, 0));
		}

		[Test]
		public void move_forward_when_facing_south()
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacing(Rotation.South());

			mars.MoveMarsRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(0, -1));
		}

		[Test]
		public void move_forward_when_facing_west()
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacing(Rotation.West());

			mars.MoveMarsRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(new Location(-1, 0));
		}


		[Test]
		public void rotate_to_the_left_when_facing_north()
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacing(Rotation.North());

			mars.RotateMarsRoverToTheLeft();

			mars.MarsRoverRotation.ShouldBeEquivalentTo(Rotation.West());
		}

		private static TestWorld AWorldWithAMarsRoverInTheMiddleFacing(Rotation rotation)
		{
			return new TestWorld(new MarsRover
			{
				Location = new Location(0, 0),
				Rotation = rotation
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

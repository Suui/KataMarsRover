using FluentAssertions;
using KataMarsRover;
using NUnit.Framework;

/* TODO
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

		[MoveTestCase("North",	0,  1)]
		[MoveTestCase("East",	1,  0)]
		[MoveTestCase("South",	0, -1)]
		[MoveTestCase("West",  -1,  0)]
		public void move_forward(Rotation currentRotation, Location expectedLocation)
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacing(currentRotation);

			mars.MoveMarsRoverForward();

			mars.MarsRoverLocation.ShouldBeEquivalentTo(expectedLocation);
		}

		[RotationTestCase("North",	"West")]
		[RotationTestCase("East",	"North")]
		[RotationTestCase("South",	"East")]
		[RotationTestCase("West",	"South")]
		public void rotate_to_the_left(Rotation currentRotation, Rotation expectedRotation)
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacing(currentRotation);

			mars.RotateMarsRoverToTheLeft();

			mars.MarsRoverRotation.ShouldBeEquivalentTo(expectedRotation);
		}

		[RotationTestCase("North",	"East")]
		[RotationTestCase("East",	"South")]
		[RotationTestCase("South",	"West")]
		[RotationTestCase("West",	"North")]
		public void rotate_to_the_right(Rotation currentRotation, Rotation expectedRotation)
		{
			var mars = AWorldWithAMarsRoverInTheMiddleFacing(currentRotation);

			mars.RotateMarsRoverToTheRight();

			mars.MarsRoverRotation.ShouldBeEquivalentTo(expectedRotation);
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

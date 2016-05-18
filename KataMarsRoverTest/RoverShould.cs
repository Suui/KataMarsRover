using FluentAssertions;
using KataMarsRover;
using NUnit.Framework;

/* TODO
	- The rover moves in a 10 by 10 grid
	- The rover wraps around if it reaches the end of the grid
	- The rover receives a char array of commands and returns the finishing point as X, Y, R
	- The grid may have obstacles. If the rover encounters an obstacle it moves to the last possible
	  point and reports the obstacle as O, X, Y, R
*/

namespace KataMarsRoverTest
{
	[TestFixture]
	class RoverShould
	{
		[Test]
		public void start_facing_north_in_the_center_of_mars()
		{
			var mars = new TestWorld();

			mars.RoverRotation.ShouldBeEquivalentTo(Rotation.North());
			mars.RoverLocation.ShouldBeEquivalentTo(new Location(0, 0));
		}

		[MoveTestCase("North",	0,  1)]
		[MoveTestCase("East",	1,  0)]
		[MoveTestCase("South",	0, -1)]
		[MoveTestCase("West",  -1,  0)]
		public void move_forward(Rotation currentRotation, Location expectedLocation)
		{
			var mars = AWorldWithARoverInTheMiddleFacing(currentRotation);

			mars.MoveRoverForward();

			mars.RoverLocation.ShouldBeEquivalentTo(expectedLocation);
		}

		[RotationTestCase("North",	"West")]
		[RotationTestCase("East",	"North")]
		[RotationTestCase("South",	"East")]
		[RotationTestCase("West",	"South")]
		public void rotate_to_the_left(Rotation currentRotation, Rotation expectedRotation)
		{
			var mars = AWorldWithARoverInTheMiddleFacing(currentRotation);

			mars.RotateRoverToTheLeft();

			mars.RoverRotation.ShouldBeEquivalentTo(expectedRotation);
		}

		[RotationTestCase("North",	"East")]
		[RotationTestCase("East",	"South")]
		[RotationTestCase("South",	"West")]
		[RotationTestCase("West",	"North")]
		public void rotate_to_the_right(Rotation currentRotation, Rotation expectedRotation)
		{
			var mars = AWorldWithARoverInTheMiddleFacing(currentRotation);

			mars.RotateRoverToTheRight();

			mars.RoverRotation.ShouldBeEquivalentTo(expectedRotation);
		}

		private static TestWorld AWorldWithARoverInTheMiddleFacing(Rotation rotation)
		{
			return new TestWorld(new Rover
			{
				Location = new Location(0, 0),
				Rotation = rotation
			});
		}
	}

	internal class TestWorld : World
	{
		public Rotation RoverRotation => Rover.Rotation;
		public Location RoverLocation => Rover.Location;

		public TestWorld() {}

		public TestWorld(Rover rover)
		{
			Rover = rover;
		}
	}
}

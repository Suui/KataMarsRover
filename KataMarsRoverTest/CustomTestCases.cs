using System.Collections.Generic;
using KataMarsRover;
using NUnit.Framework;


namespace KataMarsRoverTest
{
	internal class RotationTestCase: TestCaseAttribute
	{
		public RotationTestCase(string given, string expected): base(given.ToRotation(), expected.ToRotation()) {}
	}

	internal class MoveTestCase : TestCaseAttribute
	{
		public MoveTestCase(string stringRotation, int x, int y): base(stringRotation.ToRotation(), new Location(x, y)) {}
	}

	internal class WrapWorldTestCaseAttribute : TestCaseAttribute
	{
		public WrapWorldTestCaseAttribute(int currentX, int currentY, string stringRotation, int expectedX, int expectedY)
			: base(new Location(currentX, currentY), stringRotation.ToRotation(), new Location(expectedX, expectedY))
		{
		}
	}


	internal static class StringExtensions
	{
		public static Rotation ToRotation(this string stringRotation)
		{
			var rotationObjectFor = new Dictionary<string, Rotation>
			{
				{ "North",	Rotation.North() },
				{ "East",	Rotation.East() },
				{ "South",	Rotation.South() },
				{ "West",	Rotation.West() }
			};

			return rotationObjectFor[stringRotation];
		}
	}
}
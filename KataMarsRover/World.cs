namespace KataMarsRover
{
	public class World
	{
		protected MarsRover MarsRover { get; set; }

		public World()
		{
			MarsRover = new MarsRover
			{
				Location = new Location(0, 0),
				Rotation = new NorthRotation()
			};
		}

		public void MoveMarsRoverForward() => MarsRover.MoveForward();

		public void RotateMarsRoverToTheLeft() => MarsRover.RotateToTheLeft();

		public void RotateMarsRoverToTheRight() => MarsRover.RotateToTheRight();
	}
}
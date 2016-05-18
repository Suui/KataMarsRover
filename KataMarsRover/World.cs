namespace KataMarsRover
{
	public class World
	{
		protected Rover Rover { get; set; }
		public int Limit { get; } = 10;

		public World()
		{
			Rover = new Rover
			{
				Location = new Location(0, 0),
				Rotation = new NorthRotation()
			};
		}

		public void MoveRoverForward() => Rover.MoveForwardIn(this);

		public void RotateRoverToTheLeft() => Rover.RotateToTheLeft();

		public void RotateRoverToTheRight() => Rover.RotateToTheRight();
	}
}
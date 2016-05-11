using KataMarsRover.Rotations;


namespace KataMarsRover
{
	public class World
	{
		protected MarsRover MarsRover { get; set; }

		public World(MarsRover marsRover)
		{
			MarsRover = marsRover;
			MarsRover.Rotation = new NorthRotation();
			MarsRover.Location = new Location(0, 0);
		}

		public void MoveRoverForward()
		{
			MarsRover.MoveForward();
		}
	}
}
namespace KataMarsRover
{
	public class Rover
	{
		public Rotation Rotation { get; set; }
		public Location Location { get; set; }

		public void RotateToTheLeft() => Rotation = Rotation.ToTheLeft();

		public void RotateToTheRight() => Rotation = Rotation.ToTheRight();

		public void MoveForwardIn(World world)
		{
			Location.Sum(Rotation.Forward);
			Location.Delimit(world.Limit);
		}
	}
}
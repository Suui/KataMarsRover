namespace KataMarsRover
{
	public class MarsRover
	{
		public Rotation Rotation { get; set; }
		public Location Location { get; set; }

		public void MoveForward() => Location += Rotation.Forward;

		public void RotateToTheLeft() => Rotation = Rotation.ToTheLeft();
	}
}
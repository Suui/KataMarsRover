namespace KataMarsRover
{
	public abstract class Rotation
	{
		public abstract Location Forward { get; }

		public static Rotation North() => new NorthRotation();

		public static Rotation East() => new EastRotation();

		public static Rotation South() => new SouthRotation();

		public static Rotation West() => new WestRotation();
	}

	internal class NorthRotation : Rotation
	{
		public override Location Forward => new Location(0, 1);
	}

	internal class EastRotation : Rotation
	{
		public override Location Forward => new Location(1, 0);
	}

	internal class SouthRotation : Rotation
	{
		public override Location Forward => new Location(0,-1);
	}

	public class WestRotation : Rotation
	{
		public override Location Forward => new Location(-1, 0);
	}
}
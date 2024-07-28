using System.Numerics;

namespace Input.Touches
{
	public struct Touch
	{
		public Vector2 StartPosition { get; private set; }
		public Vector2 EndPostion { get; private set; }
        public Vector2 Delta { get; private set; }

    }
}
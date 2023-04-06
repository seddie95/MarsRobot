

namespace MarsRobot
{
    public class Grid
    {
        public Grid(long length, long height)
        {
            Length = length;
            Height = height;
        }

        public long Length { get; private set; }
        public long Height { get; private set; }

        public override string ToString()
        {
            return $"Grid Dimensions - Length: {Length}, Height: {Height}";
        }
    }
}

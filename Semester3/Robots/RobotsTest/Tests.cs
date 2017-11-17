using Xunit;
using Robots;

namespace RobotsTest
{
    public class RobotsTest
    {
        private GraphWithRobots _robots;
        private int[] _position;

        [Fact]
        public void TrueTest()
        {
            _position = new[] {0, 2};
            _robots = new GraphWithRobots(4, _position);
            _robots.ConnectVerteces(1, 0);
            _robots.ConnectVerteces(1, 2);
            _robots.ConnectVerteces(1, 3);
            Assert.True(_robots.CheckExistOrNot());
        }

        [Fact]
        public void FalseTest()
        {
            _position = new[] {1, 2};
            _robots = new GraphWithRobots(4, _position);
            _robots.ConnectVerteces(0, 1);
            _robots.ConnectVerteces(1, 2);
            _robots.ConnectVerteces(2, 3);
            _robots.ConnectVerteces(3, 0);
            Assert.False(_robots.CheckExistOrNot());
        }

        [Fact]
        public void BiggerGraphTest()
        {
            _position = new[] {2, 4, 7};
            _robots = new GraphWithRobots(8, _position);
            _robots.ConnectVerteces(0, 1);
            _robots.ConnectVerteces(1, 2);
            _robots.ConnectVerteces(1, 4);
            _robots.ConnectVerteces(1, 6);
            _robots.ConnectVerteces(2, 3);
            _robots.ConnectVerteces(3, 4);
            _robots.ConnectVerteces(4, 5);
            _robots.ConnectVerteces(5, 6);
            _robots.ConnectVerteces(6, 7);
            Assert.False(_robots.CheckExistOrNot());
        }
    }
}
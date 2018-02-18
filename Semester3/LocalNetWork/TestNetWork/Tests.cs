using LocalNetWork;
using Xunit;

namespace TestNetWork
{
	public class TestNetwork
	{
		private Network _network;
		private int[,] _matrixOfComps;
		private static readonly double[] RandomArray = {0.3, 0.2};
		private IGenerator _numberGenerator;

		public void Init()
		{
			_numberGenerator = new DefinedGenerator(RandomArray);
		}

		[Fact]
		public void OneComputerTest()
		{
			Init();
			bool[] infected = {true};
			string[] os = {"linux"};
			_matrixOfComps = new[,] {{1}};
			_network = new Network(infected, os, _matrixOfComps, _numberGenerator);
			Assert.Equal("Infected: 1 ", _network.NetworkState());
		}

		[Fact]
		public void TwoComputerTest()
		{
			Init();
			bool[] infected = {false, true};
			string[] os = {"linux", "windows"};
			_matrixOfComps = new[,] {{0, 1}, {1, 0}};
			_network = new Network(infected, os, _matrixOfComps, _numberGenerator);
			Assert.Equal("Infected: 2 ", _network.NetworkState());
		}

		[Fact]
		public void MakeStepTest()
		{
			Init();
			bool[] infected = {false, true};
			string[] os = {"windows", "linux"};
			_matrixOfComps = new[,] {{0, 1}, {1, 0}};
			_network = new Network(infected, os, _matrixOfComps, _numberGenerator);
			_network.MakeStep();
			Assert.Equal("Infected: 1 2 ", _network.NetworkState());
		}

		[Fact]
		public void ThreeComputerTest()
		{
			Init();
			bool[] infected = {false, true, false};
			string[] os = {"linux", "windows", "mac"};
			_matrixOfComps = new[,] {{0, 1, 0}, {1, 0, 1}, {0, 1, 0}};
			_network = new Network(infected, os, _matrixOfComps, _numberGenerator);
			Assert.Equal("Infected: 2 ", _network.NetworkState());
			_network.MakeStep();
			Assert.Equal("Infected: 2 3 ", _network.NetworkState());
			_network.MakeStep();
			Assert.Equal("Infected: 1 2 3 ", _network.NetworkState());
		}

		[Fact]
		public void FiveComputerTest()
		{
			Init();
			bool[] infected = {false, false, true, false, false};
			string[] os = {"linux", "windows", "mac", "windows", "linux"};
			_matrixOfComps = new[,] {{0, 1, 0, 0, 0}, {1, 0, 1, 0, 0}, {0, 1, 0, 1, 0}, {0, 0, 1, 0, 1}, {1, 0, 0, 1, 0}};
			_network = new Network(infected, os, _matrixOfComps, _numberGenerator);
			Assert.Equal("Infected: 3 ", _network.NetworkState());
			_network.MakeStep();
			Assert.Equal("Infected: 2 3 4 ", _network.NetworkState());
			_network.MakeStep();
			Assert.Equal("Infected: 1 2 3 4 5 ", _network.NetworkState());
		}
	}
}
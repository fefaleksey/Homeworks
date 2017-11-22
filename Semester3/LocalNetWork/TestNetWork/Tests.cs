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
			Assert.Equal(_network.NetworkState(), "Infected: 1 ");
		}

		[Fact]
		public void TwoComputerTest()
		{
			Init();
			bool[] infected = {false, true};
			string[] os = {"linux", "windows"};
			_matrixOfComps = new[,] {{0, 1}, {1, 0}};
			_network = new Network(infected, os, _matrixOfComps, _numberGenerator);
			Assert.Equal(_network.NetworkState(), "Infected: 2 ");
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
			Assert.Equal(_network.NetworkState(), "Infected: 1 2 ");
		}

		[Fact]
		public void ThreeComputerTest()
		{
			Init();
			bool[] infected = {false, true, false};
			string[] os = {"linux", "windows", "mac"};
			_matrixOfComps = new[,] {{0, 1, 0}, {1, 0, 1}, {0, 1, 0}};
			_network = new Network(infected, os, _matrixOfComps, _numberGenerator);
			Assert.Equal(_network.NetworkState(), "Infected: 2 ");
			_network.MakeStep();
			Assert.Equal(_network.NetworkState(), "Infected: 2 3 ");
			_network.MakeStep();
			Assert.Equal(_network.NetworkState(), "Infected: 1 2 3 ");
		}

		[Fact]
		public void FiveComputerTest()
		{
			Init();
			bool[] infected = {false, false, true, false, false};
			string[] os = {"linux", "windows", "mac", "windows", "linux"};
			_matrixOfComps = new[,] {{0, 1, 0, 0, 0}, {1, 0, 1, 0, 0}, {0, 1, 0, 1, 0}, {0, 0, 1, 0, 1}, {1, 0, 0, 1, 0}};
			_network = new Network(infected, os, _matrixOfComps, _numberGenerator);
			Assert.Equal(_network.NetworkState(), "Infected: 3 ");
			_network.MakeStep();
			Assert.Equal(_network.NetworkState(), "Infected: 2 3 4 ");
			_network.MakeStep();
			Assert.Equal(_network.NetworkState(), "Infected: 1 2 3 4 5 ");
		}
	}
}
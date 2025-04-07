using System;

namespace BoltzzmanMachine.Utils
{
	public static class MathUtils
	{
		public static double Sigmoid(double x)
		{
			return 1.0 / (1.0 + Math.Exp(-x));
		}
	}
}

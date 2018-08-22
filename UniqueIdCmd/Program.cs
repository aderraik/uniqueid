using System;
using static System.AppDomain;

namespace UniqueIdCmd
{
	public class Program
	{
		private static void Usage(string prog)
		{
			Console.WriteLine($"Usage: {prog} <string>");
		}

		public static int Main(string[] args)
		{
			if (args.Length != 1)
			{
				Usage(CurrentDomain.FriendlyName);
				return 1;
			}

			// Generate the id
			try
			{
				var id = new UniqueId.UniqueId(args[0]);
				Console.WriteLine($"Id 32bits: {id.GetId()} 64bits: {id.GetId64()}");
			}
			catch (ArgumentException exception)
			{
				Console.WriteLine(exception.Message);
				return 2;
			}
			return 0;
		}
	}
}

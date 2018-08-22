using System;
using System.Security.Cryptography;
using System.Text;

namespace UniqueId
{
	[System.Runtime.InteropServices.Guid("0233FDD1-CF79-4BC0-A282-B4C672E98689")]
	public class UniqueId
	{
		/// <summary>
		/// The origin string
		/// </summary>
		private readonly string _origin;
		public string GetOrigin() { return _origin; }

		/// <summary>
		/// Return the 64bits created Id
		/// </summary>
		/// <returns></returns>
		private readonly ulong _id64;
		public ulong GetId64() { return _id64; }

		/// <summary>
		/// Return the 32bits created Id
		/// </summary>
		/// <returns></returns>
		private readonly uint _id;
		public uint GetId() { return _id; }

		/// <summary>
		/// Return the MD5 hash created
		/// </summary>
		/// <returns></returns>
		private readonly string _hash;
		public string GetHash() { return _hash; }

		/// <summary>
		/// Create the UniqueId object from a string
		/// </summary>
		/// <param name="str">String reference to create ids.</param>
		public UniqueId(string str)
		{
			// Check input
			if (string.IsNullOrWhiteSpace(str))
				throw new ArgumentException("Invalid input string. Couldn't be empty or white space.");
			// Create the hash
			_origin = str;
			_hash = CreateMd5(str);

			// Create the 32bits id using the first 8 characters
			_id = uint.Parse(_hash.Substring(0, 8), System.Globalization.NumberStyles.HexNumber);
			// Create the 64bits id using the first 16 characters
			_id64 = ulong.Parse(_hash.Substring(0, 16), System.Globalization.NumberStyles.HexNumber);
		}

		/// <summary>
		/// Create the MD5 hash string
		/// </summary>
		/// <param name="input">The input string to convert</param>
		/// <returns>A string with the hash value</returns>
		private static string CreateMd5(string input)
		{
			// Use input string to calculate MD5 hash
			using (var md5 = MD5.Create())
			{
				var inputBytes = Encoding.ASCII.GetBytes(input);
				var hashBytes = md5.ComputeHash(inputBytes);

				// Convert the byte array to hexadecimal string
				var sb = new StringBuilder();
				foreach (var b in hashBytes)
				{
					sb.Append(b.ToString("X2"));
				}
				return sb.ToString();
			}
		}
	}
}

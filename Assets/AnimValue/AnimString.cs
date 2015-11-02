using System;
using UnityEngine;

namespace RadicalShape
{
	public class AnimString : AnimValue<String>
	{
		protected override String Lerp(String from, String to, float time)
		{
			var fromLength = from.Length;
			var toLength = to.Length;

			from = from.PadRight(to.Length);
			to = to.PadRight(from.Length);

			var s = string.Empty;

			for (int i = 0; i < Mathf.Lerp(fromLength, toLength, time); i++)
			{
				s += (char) Mathf.Lerp(from[i], to[i], time * from.Length - i);
			}

			return s;
		}

		public AnimString(String from, String to, float duration) : base(from, to, duration)
		{

		}
	}
}
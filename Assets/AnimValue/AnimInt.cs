using UnityEngine;

namespace RadicalShape
{
	public class AnimInt : AnimValue<int>
	{
		protected override int Lerp(int from, int to, float time)
		{
			return from + Mathf.RoundToInt((to - from) * time);
		}

		public AnimInt(int from, int to, float duration)
			: base(from, to, duration)
		{

		}
	}
}
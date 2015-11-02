using UnityEngine;

namespace RadicalShape
{
	public class AnimColor : AnimValue<Color>
	{
		protected override Color Lerp(Color from, Color to, float time)
		{
			return Color.Lerp(from, to, time);
		}

		public AnimColor(Color from, Color to, float duration)
			: base(from, to, duration)
		{

		}
	}
}
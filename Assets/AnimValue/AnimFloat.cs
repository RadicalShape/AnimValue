namespace RadicalShape
{
	public class AnimFloat : AnimValue<float>
	{
		protected override float Lerp(float from, float to, float time)
		{
			return from + (to - from) * time;
		}

		public AnimFloat(float from, float to, float duration)
			: base(from, to, duration)
		{

		}
	}
}
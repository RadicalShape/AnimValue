using UnityEngine;

namespace RadicalShape
{
	public class AnimQuaternion : AnimValue<Quaternion>
	{
		protected override Quaternion Lerp(Quaternion from, Quaternion to, float time)
		{
			return Quaternion.Lerp(from, to, time);
		}

		public AnimQuaternion(Quaternion from, Quaternion to, float duration)
			: base(from, to, duration)
		{

		}
	}
}
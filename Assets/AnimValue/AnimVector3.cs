using UnityEngine;

namespace RadicalShape
{
	public class AnimVector3 : AnimValue<Vector3>
	{
		protected override Vector3 Lerp(Vector3 from, Vector3 to, float time)
		{
			return new Vector3(from.x + (to.x - from.x) * time, from.y + (to.y - from.y) * time, from.z + (to.z - from.z) * time);
		}

		public AnimVector3(Vector3 from, Vector3 to, float duration) : base(from, to, duration)
		{

		}
	}
}
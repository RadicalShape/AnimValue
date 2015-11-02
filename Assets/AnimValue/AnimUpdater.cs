using System;
using UnityEngine;

namespace RadicalShape
{
	public class AnimUpdater : MonoBehaviour
	{
		private static AnimUpdater mInstance;

		public static AnimUpdater Instance
		{
			get
			{
				if (mInstance == null)
				{
					var go = new GameObject("RadicalShape_AnimUpdater");
					go.hideFlags = HideFlags.HideAndDontSave;
					mInstance = go.AddComponent<AnimUpdater>();
				}
				return mInstance;
			}
		}

		public Action OnUpdate { get; set; }

		private void Update()
		{
			if (OnUpdate != null)
				OnUpdate();
		}
	}
}

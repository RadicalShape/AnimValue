using System;
using UnityEngine;

namespace RadicalShape
{
	public abstract class AnimValue<T>
	{
		private T mTargetValue;
		private float mElapsedTime;
		private bool mSubscribed;

		public T TargetValue
		{
			set
			{
				mTargetValue = value;
				SourceValue = CurrentValue;
				mElapsedTime = 0f;
				Subscribe();
			}
			get { return mTargetValue; }
		}
		public T CurrentValue { get; set; }
		public T SourceValue { get; private set; }

		public float Duration { get; set; }
		public AnimEasing.EaseType EaseType { get; set; }
		public bool UseUnscaledDeltaTime { get; set; }

		public Action<T> OnStart { get; set; }
		public Action<T> OnFinish { get; set; }
		public Action<T> OnUpdate { get; set; }

		protected AnimValue(T from, T to, float duration)
		{
			SourceValue = from;
			mTargetValue = to;
			Duration = duration;
			mElapsedTime = 0f;
			Subscribe();
		}

		protected abstract T Lerp(T from, T to, float time);
	
		public void Subscribe()
		{
			if (mSubscribed)
				return;
			AnimUpdater.Instance.OnUpdate += Update;
			mSubscribed = true;
		}

		public void Unsubscribe()
		{
			if (!mSubscribed)
				return;
			AnimUpdater.Instance.OnUpdate -= Update;
			mSubscribed = false;
		}

		private void Update()
		{
			var deltaTime = UseUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;

			if (deltaTime == 0f)
				return;

			var requireUpdate = false;

			if (mElapsedTime == 0f && OnStart != null)
			{
				OnStart(CurrentValue);
			}

			if (mElapsedTime != Duration)
			{
				mElapsedTime += deltaTime;
				mElapsedTime = Mathf.Min(mElapsedTime, Duration);
				requireUpdate = true;
			}

			if (!requireUpdate)
				return;

			var time = mElapsedTime / Duration;

			var easeTime = AnimEasing.Do(0f, 1f, time, EaseType);

			CurrentValue = Lerp(SourceValue, mTargetValue, easeTime);

			if (OnUpdate != null)
				OnUpdate(CurrentValue);

			if (mElapsedTime == Duration && OnFinish != null)
			{
				Unsubscribe();
				OnFinish(CurrentValue);
			}
		}

	}
}

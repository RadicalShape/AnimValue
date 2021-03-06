﻿using UnityEngine;

namespace RadicalShape
{
	public static class AnimEasing
	{
		public enum EaseType
		{
			Linear,
			EaseInQuad,
			EaseOutQuad,
			EaseInOutQuad,
			EaseInCubic,
			EaseOutCubic,
			EaseInOutCubic,
			EaseInQuart,
			EaseOutQuart,
			EaseInOutQuart,
			EaseInQuint,
			EaseOutQuint,
			EaseInOutQuint,
			EaseInSine,
			EaseOutSine,
			EaseInOutSine,
			EaseInExpo,
			EaseOutExpo,
			EaseInOutExpo,
			EaseInCirc,
			EaseOutCirc,
			EaseInOutCirc,
			Spring,
			/* GFX47 MOD START */
			//bounce,
			EaseInBounce,
			EaseOutBounce,
			EaseInOutBounce,
			/* GFX47 MOD END */
			EaseInBack,
			EaseOutBack,
			EaseInOutBack,
			/* GFX47 MOD START */
			//elastic,
			EaseInElastic,
			EaseOutElastic,
			EaseInOutElastic,
			/* GFX47 MOD END */
			Punch,
		}

		public static float Do(float from, float to, float time, EaseType easeType)
		{
			switch (easeType)
			{
				case EaseType.EaseInQuad:
					return EaseInQuad(from, to, time);
				case EaseType.EaseOutQuad:
					return EaseOutQuad(from, to, time);
				case EaseType.EaseInOutQuad:
					return EaseInOutQuad(from, to, time);
				case EaseType.EaseInCubic:
					return EaseInCubic(from, to, time);
				case EaseType.EaseOutCubic:
					return EaseOutCubic(from, to, time);
				case EaseType.EaseInOutCubic:
					return EaseInOutCubic(from, to, time);
				case EaseType.EaseInQuart:
					return EaseInQuart(from, to, time);
				case EaseType.EaseOutQuart:
					return EaseOutQuart(from, to, time);
				case EaseType.EaseInOutQuart:
					return EaseInOutQuart(from, to, time);
				case EaseType.EaseInQuint:
					return EaseInQuint(from, to, time);
				case EaseType.EaseOutQuint:
					return EaseOutQuint(from, to, time);
				case EaseType.EaseInOutQuint:
					return EaseInOutQuint(from, to, time);
				case EaseType.EaseInSine:
					return EaseInSine(from, to, time);
				case EaseType.EaseOutSine:
					return EaseOutSine(from, to, time);
				case EaseType.EaseInOutSine:
					return EaseInOutSine(from, to, time);
				case EaseType.EaseInExpo:
					return EaseInExpo(from, to, time);
				case EaseType.EaseOutExpo:
					return EaseOutExpo(from, to, time);
				case EaseType.EaseInOutExpo:
					return EaseInOutExpo(from, to, time);
				case EaseType.EaseInCirc:
					return EaseInCirc(from, to, time);
				case EaseType.EaseOutCirc:
					return EaseOutCirc(from, to, time);
				case EaseType.EaseInOutCirc:
					return EaseInOutCirc(from, to, time);
				case EaseType.Linear:
					return Linear(from, to, time);
				case EaseType.Spring:
					return Linear(from, to, time);
					/* GFX47 MOD START */
					/*case EaseType.bounce:
			return EasingFunction(bounce);*/
				case EaseType.EaseInBounce:
					return EaseInBounce(from, to, time);
					;
				case EaseType.EaseOutBounce:
					return EaseOutBounce(from, to, time);
				case EaseType.EaseInOutBounce:
					return EaseInOutBounce(from, to, time);
					/* GFX47 MOD END */
				case EaseType.EaseInBack:
					return EaseInBack(from, to, time);
				case EaseType.EaseOutBack:
					return EaseOutBack(from, to, time);
				case EaseType.EaseInOutBack:
					return EaseInOutBack(from, to, time);
					/* GFX47 MOD START */
					/*case EaseType.elastic:
			return EasingFunction(elastic);*/
				case EaseType.EaseInElastic:
					return EaseInElastic(from, to, time);
				case EaseType.EaseOutElastic:
					return EaseOutElastic(from, to, time);
				case EaseType.EaseInOutElastic:
					return EaseInOutElastic(from, to, time);
					/* GFX47 MOD END */
				default:
					return Linear(from, to, time);
			}
		}

		public static float EaseInQuad(float start, float end, float value)
		{
			end -= start;
			return end * value * value + start;
		}

		public static float EaseOutQuad(float start, float end, float value)
		{
			end -= start;
			return -end * value * (value - 2) + start;
		}

		public static float EaseInOutQuad(float start, float end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1) return end * 0.5f * value * value + start;
			value--;
			return -end * 0.5f * (value * (value - 2) - 1) + start;
		}

		public static float EaseInCubic(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value + start;
		}

		public static float EaseOutCubic(float start, float end, float value)
		{
			value--;
			end -= start;
			return end * (value * value * value + 1) + start;
		}

		public static float EaseInOutCubic(float start, float end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1) return end * 0.5f * value * value * value + start;
			value -= 2;
			return end * 0.5f * (value * value * value + 2) + start;
		}

		public static float EaseInQuart(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value * value + start;
		}

		public static float EaseOutQuart(float start, float end, float value)
		{
			value--;
			end -= start;
			return -end * (value * value * value * value - 1) + start;
		}

		public static float EaseInOutQuart(float start, float end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1) return end * 0.5f * value * value * value * value + start;
			value -= 2;
			return -end * 0.5f * (value * value * value * value - 2) + start;
		}

		public static float EaseInQuint(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value * value * value + start;
		}

		public static float EaseOutQuint(float start, float end, float value)
		{
			value--;
			end -= start;
			return end * (value * value * value * value * value + 1) + start;
		}

		public static float EaseInOutQuint(float start, float end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1) return end * 0.5f * value * value * value * value * value + start;
			value -= 2;
			return end * 0.5f * (value * value * value * value * value + 2) + start;
		}

		public static float EaseInSine(float start, float end, float value)
		{
			end -= start;
			return -end * Mathf.Cos(value * (Mathf.PI * 0.5f)) + end + start;
		}

		public static float EaseOutSine(float start, float end, float value)
		{
			end -= start;
			return end * Mathf.Sin(value * (Mathf.PI * 0.5f)) + start;
		}

		public static float EaseInOutSine(float start, float end, float value)
		{
			end -= start;
			return -end * 0.5f * (Mathf.Cos(Mathf.PI * value) - 1) + start;
		}

		public static float EaseInExpo(float start, float end, float value)
		{
			end -= start;
			return end * Mathf.Pow(2, 10 * (value - 1)) + start;
		}

		public static float EaseOutExpo(float start, float end, float value)
		{
			end -= start;
			return end * (-Mathf.Pow(2, -10 * value) + 1) + start;
		}

		public static float EaseInOutExpo(float start, float end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1) return end * 0.5f * Mathf.Pow(2, 10 * (value - 1)) + start;
			value--;
			return end * 0.5f * (-Mathf.Pow(2, -10 * value) + 2) + start;
		}

		public static float EaseInCirc(float start, float end, float value)
		{
			end -= start;
			return -end * (Mathf.Sqrt(1 - value * value) - 1) + start;
		}

		public static float EaseOutCirc(float start, float end, float value)
		{
			value--;
			end -= start;
			return end * Mathf.Sqrt(1 - value * value) + start;
		}

		public static float EaseInOutCirc(float start, float end, float value)
		{
			value /= .5f;
			end -= start;
			if (value < 1) return -end * 0.5f * (Mathf.Sqrt(1 - value * value) - 1) + start;
			value -= 2;
			return end * 0.5f * (Mathf.Sqrt(1 - value * value) + 1) + start;
		}

		/* GFX47 MOD START */

		public static float EaseInBounce(float start, float end, float value)
		{
			end -= start;
			float d = 1f;
			return end - EaseOutBounce(0, end, d - value) + start;
		}

		/* GFX47 MOD END */

		/* GFX47 MOD START */
		//public static float bounce(float start, float end, float value){
		public static float EaseOutBounce(float start, float end, float value)
		{
			value /= 1f;
			end -= start;
			if (value < (1 / 2.75f))
			{
				return end * (7.5625f * value * value) + start;
			}
			else if (value < (2 / 2.75f))
			{
				value -= (1.5f / 2.75f);
				return end * (7.5625f * (value) * value + .75f) + start;
			}
			else if (value < (2.5 / 2.75))
			{
				value -= (2.25f / 2.75f);
				return end * (7.5625f * (value) * value + .9375f) + start;
			}
			else
			{
				value -= (2.625f / 2.75f);
				return end * (7.5625f * (value) * value + .984375f) + start;
			}
		}

		/* GFX47 MOD END */

		/* GFX47 MOD START */

		public static float EaseInOutBounce(float start, float end, float value)
		{
			end -= start;
			float d = 1f;
			if (value < d * 0.5f) return EaseInBounce(0, end, value * 2) * 0.5f + start;
			else return EaseOutBounce(0, end, value * 2 - d) * 0.5f + end * 0.5f + start;
		}

		/* GFX47 MOD END */

		public static float EaseInBack(float start, float end, float value)
		{
			end -= start;
			value /= 1;
			float s = 1.70158f;
			return end * (value) * value * ((s + 1) * value - s) + start;
		}

		public static float EaseOutBack(float start, float end, float value)
		{
			float s = 1.70158f;
			end -= start;
			value = (value) - 1;
			return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
		}

		public static float EaseInOutBack(float start, float end, float value)
		{
			float s = 1.70158f;
			end -= start;
			value /= .5f;
			if ((value) < 1)
			{
				s *= (1.525f);
				return end * 0.5f * (value * value * (((s) + 1) * value - s)) + start;
			}
			value -= 2;
			s *= (1.525f);
			return end * 0.5f * ((value) * value * (((s) + 1) * value + s) + 2) + start;
		}

		public static float Punch(float amplitude, float value)
		{
			float s = 9;
			if (value == 0)
			{
				return 0;
			}
			else if (value == 1)
			{
				return 0;
			}
			float period = 1 * 0.3f;
			s = period / (2 * Mathf.PI) * Mathf.Asin(0);
			return (amplitude * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * 1 - s) * (2 * Mathf.PI) / period));
		}

		/* GFX47 MOD START */

		public static float EaseInElastic(float start, float end, float value)
		{
			end -= start;

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0) return start;

			if ((value /= d) == 1) return start + end;

			if (a == 0f || a < Mathf.Abs(end))
			{
				a = end;
				s = p / 4;
			}
			else
			{
				s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
			}

			return -(a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
		}

		/* GFX47 MOD END */

		/* GFX47 MOD START */
		//public static float elastic(float start, float end, float value){
		public static float EaseOutElastic(float start, float end, float value)
		{
			/* GFX47 MOD END */
			//Thank you to rafael.marteleto for fixing this as a port over from Pedro's UnityTween
			end -= start;

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0) return start;

			if ((value /= d) == 1) return start + end;

			if (a == 0f || a < Mathf.Abs(end))
			{
				a = end;
				s = p * 0.25f;
			}
			else
			{
				s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
			}

			return (a * Mathf.Pow(2, -10 * value) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) + end + start);
		}

		/* GFX47 MOD START */

		public static float EaseInOutElastic(float start, float end, float value)
		{
			end -= start;

			float d = 1f;
			float p = d * .3f;
			float s = 0;
			float a = 0;

			if (value == 0) return start;

			if ((value /= d * 0.5f) == 2) return start + end;

			if (a == 0f || a < Mathf.Abs(end))
			{
				a = end;
				s = p / 4;
			}
			else
			{
				s = p / (2 * Mathf.PI) * Mathf.Asin(end / a);
			}

			if (value < 1)
				return -0.5f * (a * Mathf.Pow(2, 10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p)) + start;
			return a * Mathf.Pow(2, -10 * (value -= 1)) * Mathf.Sin((value * d - s) * (2 * Mathf.PI) / p) * 0.5f + end + start;
		}

		/* GFX47 MOD END */

		public static float Linear(float start, float end, float value)
		{
			return Mathf.Lerp(start, end, value);
		}
	}
}
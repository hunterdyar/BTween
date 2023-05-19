using System;
using UnityEngine;

namespace BTween
{
	public class FloatTween : PropertyTween<float>
	{
		public FloatTween(Func<float, float> property, float start, float end, Ease ease) : base(property, start, end, ease)
		{
		}

		protected override float Operate(float x)
		{
			return Mathf.Lerp(start, end, Easing.Interpolate(ease, x));
		}
	}
}
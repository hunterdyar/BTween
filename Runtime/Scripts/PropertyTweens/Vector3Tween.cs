using System;
using UnityEngine;

namespace BTween
{
	public class Vector3Tween : PropertyTween<Vector3>
	{
		public Vector3Tween(Func<Vector3, Vector3> property, Vector3 start, Vector3 end, Ease ease) : base(property, start, end, ease)
		{
		}

		protected override Vector3 Operate(float t)
		{
			return Vector3.Lerp(start, end, Easing.Interpolate(ease, t));
		}
	}
}
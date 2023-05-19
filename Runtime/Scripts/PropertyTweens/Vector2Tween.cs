using System;
using UnityEngine;

namespace BTween
{
	public class Vector2Tween : PropertyTween<Vector2>
	{
		public Vector2Tween(Func<Vector2, Vector2> property, Vector2 start, Vector2 end, Ease ease) : base(property, start, end, ease)
		{
		}

		protected override Vector2 Operate(float t)
		{
			return Vector2.Lerp(start, end, t);
		}
	}
}
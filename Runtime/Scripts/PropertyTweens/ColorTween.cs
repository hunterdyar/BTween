using System;
using UnityEngine;

namespace BTween
{
	public class ColorTween : PropertyTween<Color>
	{
		public ColorTween(Func<Color, Color> property, Color start, Color end, Ease ease) : base(property, start, end, ease)
		{
		}

		protected override Color Operate(float t)
		{
			return Color.LerpUnclamped(start, end, t);
		}
	}
}
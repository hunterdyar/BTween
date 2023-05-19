using System;
using UnityEngine;

namespace BTween
{
	public class QuaternionTween : PropertyTween<Quaternion>
	{
		public QuaternionTween(Func<Quaternion, Quaternion> property, Quaternion start, Quaternion end, Ease ease) : base(property, start, end, ease)
		{
		}

		protected override Quaternion Operate(float t)
		{
			return Quaternion.Lerp(start,end,t);
		}
	}
}
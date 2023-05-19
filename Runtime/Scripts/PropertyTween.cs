using System;

namespace BTween
{
	public abstract class PropertyTween
	{
		protected Ease ease;
		protected PropertyTween(Ease ease)
		{
			this.ease = ease;
		}

		protected PropertyTween()
		{
			this.ease = Ease.Linear;
		}

		public abstract void SetToStart();
		public abstract void SetToEnd();

		public abstract void Execute(float f);

		public void SetEase(Ease ease)
		{
			this.ease = ease;
		}
	}
	public abstract class PropertyTween<T> : PropertyTween
	{
		protected readonly T start;
		protected readonly T end;
		protected float t;
		protected Func<T, T> property;
		protected abstract T Operate(float t);
		public override void Execute(float f)
		{
			property.Invoke(Operate(f));
		}

		protected PropertyTween(Func<T, T> property, T start, T end, Ease ease) : base(ease)
		{
			this.start = start;
			this.end = end;
			this.property = property;
		}

		public override void SetToStart()
		{
			Operate(0);
		}

		public override void SetToEnd()
		{
			Operate(1);
		}
	}
}
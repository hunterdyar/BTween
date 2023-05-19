using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BTween
{
	public class Tween
	{
		public delegate void Callback();

		private Callback OnCompleteCallback;
		private Callback OnStartCallback;
		public bool Running => _running;
		public PropertyTween PrimaryPropertyTween => _tweens[0];

		private bool _running;
		private Ease _ease;
		private float _totalTime;
		private List<PropertyTween> _tweens;
		private Tween _followupTween;
		
		public Tween(float totalTime)
		{
			_totalTime = totalTime;
			_tweens = new List<PropertyTween>();
			_running = false;
		}


		public Tween Add(PropertyTween t)
		{
			_tweens.Add(t);
			return this;
		}

		public Tween Then(Tween nextTween)
		{
			_followupTween = nextTween;
			return this;
		}

		/// <summary>
		/// Sets ease of all tweens already added.
		/// </summary>
		/// <param name="ease"></param>
		public Tween SetEase(Ease ease)
		{
			foreach (var tween in _tweens)
			{
				tween.SetEase(ease);
			}

			return this;
		}

		public async void DoTween()
		{
			_running = true;
			float t = 0;
			foreach (var tween in _tweens)
			{
				tween.SetToStart();
			}
			while (t < 1)
			{
				foreach (var tween in _tweens)
				{
					tween.Execute(t);
					t += Time.deltaTime/_totalTime;
				}

				await Task.Yield();
			}

			foreach (var tween in _tweens)
			{
				tween.SetToEnd();
			}

			if (_followupTween != null)
			{
				_followupTween.Start();
				while (_followupTween.Running)
				{
					await Task.Yield();
				}
			}

			_running = false;
			OnCompleteCallback?.Invoke();
		}

		public void Start()
		{
			DoTween();
			OnStartCallback?.Invoke();
		}
		public Tween OnComplete(Callback onComplete)
		{
			OnCompleteCallback = onComplete;
			return this;
		}

		public Tween OnStart(Callback onComplete)
		{
			OnStartCallback = onComplete;
			return this;
		}
		
	}
}
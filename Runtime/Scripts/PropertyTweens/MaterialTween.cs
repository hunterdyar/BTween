using System;
using UnityEngine;

namespace BTween
{
	public class MaterialTween : PropertyTween
	{
		private readonly MeshRenderer _meshRenderer;
		private readonly Material _start;
		private readonly Material _end;
		private Ease _ease;
		
		public MaterialTween(MeshRenderer meshRenderer, Material end, Ease ease)
		{
			_meshRenderer = meshRenderer;
			_start = _meshRenderer.material;
			_ease = ease;
			this._end = end;
		}

		public MaterialTween(MeshRenderer meshRenderer,Material start, Material end, Ease ease)
		{
			_meshRenderer = meshRenderer;
			_start = start;
			_ease = ease;
			this._end = end;
		}

		public override void SetToStart()
		{
			if (_meshRenderer != null)
			{
				_meshRenderer.material = _start;
			}
			else
			{
				Debug.LogWarning("null MR in Tween (set to start)");
			}
		}

		public override void SetToEnd()
		{
			if (_meshRenderer != null)
			{
				_meshRenderer.material = _end;
			}
			else
			{
				Debug.LogWarning("null MR in Tween (set to end)");
			}
		}

		public override void Execute(float f)
		{
			if (_meshRenderer != null)//todo more performant escape please.
			{
				_meshRenderer.material.Lerp(_start, _end, Easing.Interpolate(_ease, f));
			}
			else
			{
				Debug.LogWarning("null MR in Tween (execute)");
			}
		}
	}
}
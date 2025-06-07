using UnityEngine;

namespace BTween
{
	public class SpriteRendererColorTween : PropertyTween
	{
		private SpriteRenderer _spriteRenderer;
		private Color _startColor;
		private Color _endColor;
		private Ease _ease;
		public SpriteRendererColorTween(SpriteRenderer spriteRenderer, Color startColor, Color endColor, Ease ease)
		{
			_spriteRenderer = spriteRenderer;
			_startColor = startColor;
			_endColor = endColor;
			_ease = ease;
		}

		public override void SetToStart()
		{
			if (_spriteRenderer != null)
			{
				_spriteRenderer.color = _startColor;
			}
			else
			{
				Debug.LogWarning("null SpriteRenderer in Tween (set to end)");
			}
		}

		public override void SetToEnd()
		{
			if (_spriteRenderer != null)
			{
				_spriteRenderer.color = _endColor;
			}
			else
			{
				Debug.LogWarning("null SpriteRenderer in Tween (set to end)");
			}
		}

		public override void Execute(float t)
		{
			if (_spriteRenderer != null)
			{
				_spriteRenderer.color = Color.Lerp(_startColor, _endColor, Easing.Interpolate(_ease, t));
			}
			else
			{
				Debug.LogWarning("null SpriteRenderer in Tween (set to end)");
			}
		}
	}
}
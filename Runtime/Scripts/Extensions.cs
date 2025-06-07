using System.Runtime.CompilerServices;
using UnityEngine;

namespace BTween
{
	public static class Extensions
	{

		#region TransformExtensions
		
		public static Tween BMoveTo(this Transform transform, Vector3 endWorldPos, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new Vector3Tween(x=>transform.position = x,transform.position,endWorldPos,ease));

			if (startNow)
			{
				t.Start();
			}

			return t;
		}

		public static Tween BMoveFromTo(this Transform transform, Vector3 startWorldPos, Vector3 endWorldPos, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new Vector3Tween(x => transform.position = x, startWorldPos, endWorldPos, ease));
		
			if (startNow)
			{
				t.Start();
			}
		
			return t;
		}

		public static Tween BRotateTo(this Transform transform, Quaternion endRot, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new QuaternionTween(x => transform.rotation = x, transform.rotation, endRot, ease));

			if (startNow)
			{
				t.Start();
			}
			return t;
		}

		public static Tween BLookTo(this Transform transform, Vector3 lookDirection, Vector3 upDirection, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Quaternion look = Quaternion.LookRotation(lookDirection, upDirection);
			return transform.BRotateTo(look, time, ease, startNow);
		}

		public static Tween BRotateFromTo(this Transform transform, Quaternion from, Quaternion endRot, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new QuaternionTween(x => transform.rotation = x, from, endRot, ease));
			
			if (startNow)
			{
				t.Start();
			}

			return t;
		}

		public static Tween BRotateLocalTo(this Transform transform, Quaternion endRot, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new QuaternionTween(x => transform.localRotation = x, transform.rotation, endRot, ease));

			if (startNow)
			{
				t.Start();
			}

			return t;
		}
		
		public static Tween BScaleTo(this Transform transform, Vector3 endLocalScale, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new Vector3Tween(x => transform.localScale = x, transform.localScale, endLocalScale, ease));

			if (startNow)
			{
				t.Start();
			}

			return t;
		}

		public static Tween BScaleFromTo(this Transform transform, Vector3 startLocal, Vector3 endLocalScale, float time,
			Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new Vector3Tween(x => transform.localScale = x, startLocal, endLocalScale, ease));

			if (startNow)
			{
				t.Start();
			}
			
			return t;
		}


		#endregion

		#region MeshRendererExtension

		public static Tween BTweenMaterial(this MeshRenderer meshRenderer, Material endMat, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new MaterialTween(meshRenderer, endMat, ease));

			if (startNow)
			{
				t.Start();
			}

			return t;
		}
		
		#endregion
		
		#region SpriteRendererExtension
		
		public static Tween BTweenColorTo(this SpriteRenderer spriteRenderer, Color color, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new SpriteRendererColorTween(spriteRenderer, spriteRenderer.color, color, ease));
			if (startNow)
			{
				t.Start();
			}

			return t;
		}

		public static Tween BTweenColorFromTo(this SpriteRenderer spriteRenderer, Color startColor, Color endColor, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			t.Add(new SpriteRendererColorTween(spriteRenderer, startColor, endColor, ease));
			if (startNow)
			{
				t.Start();
			}

			return t;
		}

		public static Tween BTweenOpacityTo(this SpriteRenderer spriteRenderer, float alpha, float time, Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			var startColor = spriteRenderer.color;
			var endColor = new Color(startColor.r, startColor.g, startColor.b, alpha);
			t.Add(new SpriteRendererColorTween(spriteRenderer, startColor, endColor, ease));
			if (startNow)
			{
				t.Start();
			}

			return t;
		}

		public static Tween BTweenOpacityFromTo(this SpriteRenderer spriteRenderer, float startAlpha, float endAlpha, float time,
			Ease ease = Ease.Linear, bool startNow = true)
		{
			Tween t = new Tween(time);
			var startColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, startAlpha);
			var endColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, endAlpha);
			t.Add(new SpriteRendererColorTween(spriteRenderer, startColor, endColor, ease));
			if (startNow)
			{
				t.Start();
			}

			return t;
		}
		#endregion
	}
}
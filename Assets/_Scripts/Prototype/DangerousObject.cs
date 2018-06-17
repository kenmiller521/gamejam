using UnityEngine;

namespace Prototype
{
	public class DangerousObject : MonoBehaviour
	{
		public void OnCollisionEnter2D(Collision2D collision)
		{
			var obj = collision.gameObject;

			if (obj == GlobalData.s.MainPlayer) {
				
			}
		}
	}
}
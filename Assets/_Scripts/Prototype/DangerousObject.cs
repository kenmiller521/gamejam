using UnityEngine;

namespace Prototype
{
	/// <summary>
    /// Makes an object deal damage upon collision.
    /// </summary>
	public class DangerousObject : MonoBehaviour
	{
		[Tooltip("How much damage will this object deal?")]
		public int DamageDealt = 1;

		public void OnCollisionEnter2D(Collision2D collision)
		{
			var obj = collision.gameObject;

			if (obj == GlobalData.s.CurrentPlayer) {
				HealthManager.s.DamagePlayer(DamageDealt);
			}
		}
	}
}
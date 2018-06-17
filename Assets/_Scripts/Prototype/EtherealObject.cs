using UnityEngine;

namespace Prototype
{
	/// <summary>
    /// Makes an object's collider appear in the other world.
    /// </summary>
	[RequireComponent(typeof(Collider2D))]
	public class EtherealObject : MonoBehaviour
	{
		Collider2D _collider;

		#region MonoBehaviour Callbacks

		// Set collider
		void Awake()
		{
			_collider = GetComponent<Collider2D>();
		}

		void Update()
		{
			AdjustOffset();
		}

		#endregion

		// Mirror the collider on the y axis.
		public void AdjustOffset() {
            var yPos = transform.position.y;
            var offset = new Vector2(0, yPos * -0.2f);
            _collider.offset = offset;
		}
	}
}
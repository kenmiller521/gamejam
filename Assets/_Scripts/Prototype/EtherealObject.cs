using UnityEngine;

namespace Prototype
{
	/// <summary>
    /// Makes an object's collider appear in the other world.
    /// </summary>
	[RequireComponent(typeof(BoxCollider2D))]
	public class EtherealObject : MonoBehaviour
	{
		BoxCollider2D _collider;

		void Start()
		{
			_collider = GetComponent<BoxCollider2D>();
		}

		void Update()
		{
			AdjustOffset();
		}

		public void AdjustOffset() {
            var yPos = transform.position.y;
            var size = _collider.size.y;
            var offset = new Vector2(0, yPos * -0.2f);
            _collider.offset = offset;
		}
	}
}
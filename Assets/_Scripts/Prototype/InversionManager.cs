using UnityEngine;

namespace Prototype
{
	/// <summary>
    /// Handles inversion logic
    /// </summary>
	public class InversionManager : MonoBehaviour
	{
		// Singleton
		public static InversionManager s;

		#region MonoBehaviour Callbacks

		// Set singleton
		void Awake()
		{
			s = this;
		}
        
        /// <summary>
        /// Subscribe to events
        /// </summary>
		void OnEnable()
		{
			InputManager.OnInvert += OnInvert;
		}

        /// <summary>
        /// Unsubscribe events
        /// </summary>
        void OnDisable()
        {
            InputManager.OnInvert -= OnInvert;
        }

        #endregion

        public void OnInvert() {
			Camera.main.projectionMatrix *= Matrix4x4.Scale(new Vector3(1, -1, 1));
			GlobalData.s.IsInverted = !GlobalData.s.IsInverted;
			var velocity = PlayerManager.s.OtherRB2D.velocity;
			velocity.y *= -1;
			PlayerManager.s.CurrentRB2D.velocity = velocity;
		}
	}
}
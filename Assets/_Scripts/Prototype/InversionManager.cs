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

        // Subscribe to input events
		void Start()
		{
			InputManager.OnInvert += OnInvert;
		}


        private void OnDisable()
        {
            InputManager.OnInvert -= OnInvert;
        }
        #endregion

        public void OnInvert() {
            Debug.Log("OnInvert");
			Camera.main.projectionMatrix *= Matrix4x4.Scale(new Vector3(1, -1, 1));
			GlobalData.s.IsInverted = !GlobalData.s.IsInverted;
		}
	}
}
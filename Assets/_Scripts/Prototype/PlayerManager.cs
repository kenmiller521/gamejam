using System;
using UnityEngine;

namespace Prototype
{
	/// <summary>
	/// Handles player movement mechanics
	/// </summary>
	public class PlayerManager : MonoBehaviour
	{
		// Singleton
		public static PlayerManager s;

		// Inspector values
		public float HorizontalSpeed;
		public float JumpForce;

		// Rigidbody References
        Rigidbody2D CurrentRB2D
        {
            get
            {
                return GlobalData.s.IsInverted ? InvertedRB2D : MainRB2D;
            }
		}
        Rigidbody2D OtherRB2D
        {
            get
            {
                return GlobalData.s.IsInverted ? MainRB2D : InvertedRB2D;
            }
        }

		Rigidbody2D MainRB2D;
		Rigidbody2D InvertedRB2D;

		#region MonoBehaviour Callbacks

        /// <summary>
        /// Set singleton
        /// </summary>
		void Awake()
		{
			s = this;
		}

        /// <summary>
        /// Subscribe to each event
        /// </summary>
		void Start()
		{
			InputManager.OnMove += OnMove;
			InputManager.OnJump += OnJump;
            HealthManager.OnDeath += OnDeath;
			MainRB2D = GlobalData.s.MainPlayer.GetComponent<Rigidbody2D>();
			InvertedRB2D = GlobalData.s.InvertedPlayer.GetComponent<Rigidbody2D>();
		}

		void Update()
		{
			var pos = GlobalData.s.CurrentPlayer.transform.position;
			pos.y *= -1;
			GlobalData.s.OtherPlayer.transform.position = pos;
		}

        private void OnDisable()
        {
            InputManager.OnMove -= OnMove;
            InputManager.OnJump -= OnJump;
            HealthManager.OnDeath -= OnDeath;
        }

        

        #endregion

        #region Event Callbacks

        public void OnMove(float x)
		{
			var yVelocity = CurrentRB2D.velocity.y;
			var velocity = new Vector2(x * HorizontalSpeed, yVelocity);
			Debug.Log(GlobalData.s.CurrentPlayer);
			CurrentRB2D.velocity = velocity;
		}

		public void OnJump()
		{
			var jumpVelocity = new Vector2(0, JumpForce * GlobalData.s.InvertMultiplier);
			CurrentRB2D.velocity += jumpVelocity;
		}

        private void OnDeath()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
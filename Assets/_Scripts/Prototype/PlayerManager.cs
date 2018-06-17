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
		public float JumpSpeed;

		[Tooltip("How long is the player stunned for after taking damage.")]
		public float StunDuration;
        [Tooltip("How long is the player invulnerable after taking damage.")]
		public float InvulnerabilityDuration;
        [Tooltip("How much is the player knocked away after taking damage.")]
		public Vector2 KnockbackVector;

		// Rigidbody References
        public Rigidbody2D CurrentRB2D
        {
            get
            {
                return GlobalData.s.IsInverted ? _invertedRB2D : _mainRB2D;
            }
		}

        public Rigidbody2D OtherRB2D
        {
            get
            {
                return GlobalData.s.IsInverted ? _mainRB2D : _invertedRB2D;
            }
        }

		Rigidbody2D _mainRB2D;
		Rigidbody2D _invertedRB2D;

		public bool IsStunned;
		public bool IsInvulnerable;
		float _lastTimeDamaged;

		#region MonoBehaviour Callbacks

        /// <summary>
        /// Set singleton
        /// </summary>
		void Awake()
		{
			s = this;
		}

        /// <summary>
        /// Set references to rigidbodies
        /// </summary>
		void Start()
		{
			_mainRB2D = GlobalData.s.MainPlayer.GetComponent<Rigidbody2D>();
			_invertedRB2D = GlobalData.s.InvertedPlayer.GetComponent<Rigidbody2D>();
		}

        /// <summary>
        /// Subscribe to each event
        /// </summary>
		void OnEnable()
		{         
            InputManager.OnMove += OnMove;
			InputManager.OnJump += OnJump;
            HealthManager.OnDamage += OnDamage;
            HealthManager.OnDeath += OnDeath;
		}

        /// <summary>
        /// Unsubscribe events
        /// </summary>
        void OnDisable()
        {
            InputManager.OnMove -= OnMove;
			InputManager.OnJump -= OnJump;
			HealthManager.OnDamage -= OnDamage;
            HealthManager.OnDeath -= OnDeath;
        }

        /// <summary>
        /// Set the other player's position to mirror the current player.
        /// </summary>
		void Update()
		{
			var pos = GlobalData.s.CurrentPlayer.transform.position;
			pos.y *= -1;
			GlobalData.s.OtherPlayer.transform.position = pos;
			OtherRB2D.velocity = CurrentRB2D.velocity;
			if (IsStunned || IsInvulnerable) {
				var timeDiff = Time.time - _lastTimeDamaged;

				if (timeDiff >= InvulnerabilityDuration) {
					IsInvulnerable = false;
				}

				if (timeDiff >= StunDuration) {
					IsStunned = false;
				}
			}
		}

        #endregion

        #region Event Callbacks

        public void OnMove(float x)
		{
			if (IsStunned) return;

			var yVelocity = CurrentRB2D.velocity.y;
			var velocity = new Vector2(x * HorizontalSpeed, yVelocity);
			CurrentRB2D.velocity = velocity;
		}

		public void OnJump()
		{
			if (IsStunned) return;
			var velocity = CurrentRB2D.velocity;
			var jumpVelocity = new Vector2(velocity.x, JumpSpeed * GlobalData.s.InvertMultiplier);
			CurrentRB2D.velocity = jumpVelocity;
		}

		void OnDamage(GameObject damager) {
			var playerPos = GlobalData.s.CurrentPlayer.transform.position;
			var enemyX = damager.transform.position.x;
			Debug.Log(damager);
			var xDirection = playerPos.x >= enemyX ? 1 : -1;

			var velocity = new Vector2(xDirection * KnockbackVector.x, KnockbackVector.y);
			Debug.Log(velocity);
			playerPos.x += xDirection * 0.1f;
			GlobalData.s.CurrentPlayer.transform.position = playerPos;
			CurrentRB2D.velocity = velocity;

			IsStunned = true;
			IsInvulnerable = true;
			_lastTimeDamaged = Time.time;
		}

        void OnDeath()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
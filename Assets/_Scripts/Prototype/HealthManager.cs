using UnityEngine;

namespace Prototype
{
	/// <summary>
    /// Manages the player's health
    /// </summary>
	public class HealthManager : MonoBehaviour
	{
		// Singleton
		public static HealthManager s;

        public int MaxHealth;
		public int CurrentHealth { get; private set; }

        public delegate void DamageEvent();
		public static event DamageEvent OnDamage;

        public delegate void DeathEvent();
        public static event DeathEvent OnDeath;

        // Set singleton
		void Awake()
		{
			s = this;
		}

        /// <summary>
        /// Lower player's health by amount
        /// </summary>
        /// <param name="amount">Amount.</param>
		public void DamagePlayer(int amount) {
			CurrentHealth -= amount;
         
			if (CurrentHealth <= 0) {
                CurrentHealth = 0;
				OnDamage();
			}
			else {
				OnDeath();
			}
		}

        /// <summary>
        /// Sets health to max
        /// </summary>
		public void ResetHealth() {
			CurrentHealth = MaxHealth;
		}
	}
}
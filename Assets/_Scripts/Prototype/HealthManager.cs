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

        public delegate void DamageEvent(GameObject damager);
		public static event DamageEvent OnDamage;

        public delegate void DeathEvent();
        public static event DeathEvent OnDeath;

        // Set singleton
		void Awake()
		{
			s = this;
			CurrentHealth = MaxHealth;
		}

        /// <summary>
        /// Lower player's health by amount
        /// </summary>
        /// <param name="amount">Amount.</param>
		public void DamagePlayer(GameObject damager,int amount) {
			CurrentHealth -= amount;
			Debug.Log(CurrentHealth);
			if (CurrentHealth > 0) {
				if (OnDamage != null)
				{
					OnDamage(damager);
				}
			}
			else {
                CurrentHealth = 0;
				if (OnDeath != null)
				{
					OnDeath();
				}
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
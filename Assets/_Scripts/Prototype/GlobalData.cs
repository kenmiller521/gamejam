using UnityEngine;

namespace Prototype
{
	/// <summary>
    /// Data container
    /// </summary>
	public class GlobalData : MonoBehaviour
	{
		// Singleton
		public static GlobalData s;

		#region MonoBehaviour Callbacks

		// Set singleton
		void Awake()
		{
			s = this;
		}

		#endregion

		// Player References
		public GameObject CurrentPlayer {
			get {
				return IsInverted ? InvertedPlayer : MainPlayer;
			}
		}
		public GameObject OtherPlayer {
			get {
				return IsInverted ? MainPlayer : InvertedPlayer;
			}
		}
		public GameObject MainPlayer;
		public GameObject InvertedPlayer;

		// Inverted Flag
		public bool IsInverted;
		public int InvertMultiplier {
			get {
				return IsInverted ? -1 : 1;
			}
		}
	}
}
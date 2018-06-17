using System;
using UnityEngine;

namespace Prototype
{
	/// <summary>
    /// Event manager for player inputs.
    /// </summary>
	public class InputManager : MonoBehaviour
	{
		// Singleton
		public static InputManager s;

		public delegate void MoveEvent(float x);
		public delegate void JumpEvent();
		public delegate void InvertEvent();
		public delegate void EscapeEvent();

		public static event MoveEvent OnMove;
		public static event JumpEvent OnJump;
		public static event InvertEvent OnInvert;
		public static event EscapeEvent OnEscape;

		#region Monobehaviour Callbacks

        // Set singleton
		void Awake()
		{
			s = this;
		}

		// Check each type of input.
		void Update()
		{
			MoveCheck();
			JumpCheck();
			InvertCheck();
			EscapeCheck();
		}

        #endregion

		#region InputLogic

		void MoveCheck()
		{
			float xAxis = Input.GetAxis("Horizontal");

			if (xAxis != 0)
			{
				if (OnMove != null)
				{
					OnMove(xAxis);
				}
			}
		}

		void JumpCheck()
		{
			if (Input.GetButtonDown("Jump"))
			{
				if (OnJump != null)
				{
					OnJump();
				}
			}
		}

		void InvertCheck()
		{
			if (Input.GetButtonDown("Fire1"))
			{
				if (OnInvert != null)
				{
					OnInvert();
				}
			}
		}

		void EscapeCheck()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (OnEscape != null)
				{
					OnEscape();
				}
			}
		}

        #endregion
	}
}
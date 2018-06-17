using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class OptionsMenu : MonoBehaviour
    {
        public GameObject optionsPanel;
        private bool isPaused;
        // Use this for initialization
        private void OnEnable()
        {
            InputManager.OnEscape += OnPause;
        }
        private void OnDisable()
        {
            InputManager.OnEscape -= OnPause;
        }

        private void OnPause()
        {
            isPaused = !isPaused;
            optionsPanel.SetActive(isPaused);
        }

        void Start()
        {
            isPaused = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


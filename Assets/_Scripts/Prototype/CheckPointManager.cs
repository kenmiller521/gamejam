using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class CheckPointManager : MonoBehaviour
    {
        #region Public Variables
        public static CheckPointManager s;
        public Vector3 respawnPosition;
        #endregion



        #region Private Variables
        #endregion



        #region Monobehavior Callbacks
        private void Awake()
        {
            if (s == null)
                s = this;
        }
        private void OnEnable()
        {
            HealthManager.OnDeath += OnDeath;
        }                

        private void OnDisable()
        {
            HealthManager.OnDeath -= OnDeath;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Public Functions
        public void SetCheckPointPosition(Vector3 pos)
        {
            respawnPosition = pos;
        }
        #endregion

        #region Event Functions
        private void OnDeath()
        {
            GlobalData.s.CurrentPlayer.transform.position = new Vector3(respawnPosition.x, GlobalData.s.CurrentPlayer.transform.position.y, 0);
            GlobalData.s.OtherPlayer.transform.position = new Vector3(respawnPosition.x, GlobalData.s.OtherPlayer.transform.position.y, 0);
        }
        #endregion
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class CheckPoint : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                CheckPointManager.s.SetCheckPointPosition(transform.position);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class CameraFollow : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(GlobalData.s.CurrentPlayer.transform.position.x, 0, -10);
    
        }
    }
}


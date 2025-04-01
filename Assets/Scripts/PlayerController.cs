using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NZ
{


    public class PlayerController : MonoBehaviour
    {

        public Spawner spawner;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("X key down");
                spawner.Spawn();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Z key down");
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key down");
            }


        }
    }
}

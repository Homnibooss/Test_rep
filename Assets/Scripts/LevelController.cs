using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{

    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        public float delay = 0.5f;
        public bool isGameOver = false;

        private void Start()
        {
           StartCoroutine(StartStoneProc()); 
        }

        private IEnumerator StartStoneProc()
        {
            do
            {
                yield return new WaitForSeconds(delay);
                spawner.Spawn();
            }
            while (!isGameOver);
        }
    }
}

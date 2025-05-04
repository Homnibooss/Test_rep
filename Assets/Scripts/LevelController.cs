using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{

    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        public float deLayMax = 2f;
        public float deLayMin = 0.5f;
        public float deLayStep = 0.1f;
        private float m_delay = 0.5f;
       

        private float m_LastSpawnedTime = 0;

        private void Start()
        {
           m_LastSpawnedTime = Time.time;
            RefreshDelay();
            
        }

        private void OnEnable()
        {
            Stone.onCollisionStone += GameOver;
        }

        private void OnDisable()
        {
            Stone.onCollisionStone -= GameOver;
        }

        private void GameOver()
        {
           Debug.Log("Game Over!");
           enabled = false;
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(deLayMin, deLayMax);
            deLayMax = Mathf.Max(deLayMin, deLayMax - deLayStep);
        }

        private void Update()
        {
            
            
                if (Time.time >= m_LastSpawnedTime + m_delay)
                {
                    spawner.Spawn();
                    m_LastSpawnedTime = Time.time;

                RefreshDelay();
                }
            
        }
    }
}

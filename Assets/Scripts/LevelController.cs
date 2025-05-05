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

        public int score = 0;
        public int highScore = 0;

        private List<GameObject> m_stones = new List<GameObject>(16);

        private void Start()
        {
           m_LastSpawnedTime = Time.time;
            RefreshDelay();
            
        }

        private void OnStickHit()
        {
            score++;
            highScore = Mathf.Max(highScore, score);
            Debug.Log($"score: {score} - highScore: {highScore}");

        }

        private void OnEnable()
        {
            GameEvents.onStickHit += OnStickHit;
            score = 0;
        }

        private void OnDisable()
        {
            GameEvents.onStickHit -= OnStickHit;
        }

        private void GameOver()
        {
           Debug.Log("Game Over!");
           enabled = false;
        }

        public void ClearStones()
        {
            foreach (var stone in m_stones) 
            {
                Destroy(stone);
            
            }
            m_stones.Clear();
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
                    var stone = spawner.Spawn();
                m_stones.Add(stone);
                    m_LastSpawnedTime = Time.time;

                RefreshDelay();
                }
            
        }
    }
}

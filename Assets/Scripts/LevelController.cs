using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;
        private float m_delay = 0.5f;

        private float m_lastSpawnedTime = 0;

        public int score = 0;
        public int highScore = 0;

        private List<GameObject> m_stones  = new List<GameObject>(16);

        private void Start()
        {
            m_lastSpawnedTime = Time.time;
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
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }

        private void Update()
        {
                if (Time.time >= m_lastSpawnedTime + m_delay)
                {
                    var stone = spawner.Spawn();
                m_stones.Add(stone);
                    m_lastSpawnedTime = Time.time;
                RefreshDelay();
                }
        }
    }
}

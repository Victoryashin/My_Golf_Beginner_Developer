using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Golf
{
    public class SpawnerStone : MonoBehaviour
    {
        public GameObject[] prefabs;
        
        public GameObject Spawn()
        {
            var prefab = GetRandomPrefab();

            if (prefab == null )
            {
                return null;
            }
            return Instantiate(prefab, transform.position, Quaternion.identity);
        }

        private GameObject GetRandomPrefab()
        {
            if (prefabs.Length == 0)
            {
                return null;
            }

            int index = Random.Range(0, prefabs.Length);
            return prefabs[index];
        }

    }
}

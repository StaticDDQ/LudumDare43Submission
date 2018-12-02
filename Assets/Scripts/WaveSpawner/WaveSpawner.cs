using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static WaveSpawner instance;

    [System.Serializable]
	public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float delay;
    }
    public Wave[] waves;

    [System.Serializable]
    public class Spawner
    {
        public GameObject spawnPoint;
        public Animator gate;
        public Image indicator;
    }
    public Spawner[] spawnOrigins;

    public bool startSpawning = false;
    private bool currentlySpawning = false;

    private int nextWave = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        if(startSpawning && !currentlySpawning)
        {
            currentlySpawning = true;
            StartCoroutine(StartSpawning(waves[nextWave]));

        } else if(startSpawning && currentlySpawning)
        {

        }
    }

    private IEnumerator StartSpawning(Wave wave)
    {
        EnemyCounter.instance.SetAmount(wave.count);
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }

        startSpawning = false;
        currentlySpawning = false;

        yield break;
    }

    private void SpawnEnemy(Transform enemy)
    {

    }
}

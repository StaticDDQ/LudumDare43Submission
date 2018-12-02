using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour {

    public EnemyDifficulty difficulty;
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
        public Transform spawnPoint;
        public Animator indicator;
    }
    public Spawner[] spawnOrigins;

    private int nextWave = 0;
    private int spawnAmount = 1;
    private int miniRound = 0;
    private int totalRounds = 0;

    private List<int> uniqued;
    private List<int> finished;

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
        uniqued = new List<int>();
        finished = new List<int>();

        FillList();
    }

    private void FillList()
    {
        for (int i = 0; i < spawnOrigins.Length; i++)
        {
            uniqued.Add(i);
        }
        finished.Clear();
    }

    public void StartSpawn()
    {
        totalRounds++;

        if(totalRounds % 12 == 0)
        {
            difficulty.DamageIncreasedMultiplier += 0.1f;
            difficulty.DamageReducedMultiplier -= 0.1f;
        }  
        if(totalRounds % 6 == 0)
        {
            difficulty.ArmorGainReducedMultiplier -= 0.1f;
            difficulty.HealthGainReducedMultiplier -= 0.1f;
        }
        

        for(int i = 0; i < spawnAmount; i++)
        {
            int rand = uniqued[Random.Range(0, uniqued.Count)];
            finished.Add(rand);
            uniqued.Remove(rand);

            StartCoroutine(StartSpawning(waves[nextWave++], rand));
        }

        FillList();

        miniRound++;
        if(miniRound == 4)
        {
            miniRound = 0;
            if (spawnAmount == 3)
                spawnAmount = 1;
            else
                spawnAmount++;
        }

        if(totalRounds > 4)
        {
            nextWave = Random.Range(0, waves.Length);
        }
    }

    private IEnumerator StartSpawning(Wave wave, int spawnerPoint)
    {
        spawnOrigins[spawnerPoint].indicator.Play("ArrowPopUp");
        EnemyCounter.instance.SetAmount(wave.count);
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy, spawnerPoint);
            yield return new WaitForSeconds(wave.delay);
        }

        yield break;
    }

    private void SpawnEnemy(Transform enemy, int spawnerNum)
    {
        Instantiate(enemy, spawnOrigins[spawnerNum].spawnPoint.position, spawnOrigins[spawnerNum].spawnPoint.parent.rotation);
    }
}

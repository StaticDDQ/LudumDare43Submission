using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public EnemyDifficulty difficulty;

    public Text totalRoundsText;

    public Text hpEnemy;
    public Text atkEnemy;
    public Text atkPlayer;
    public Text hpRestore;
    public Text armorRestore;

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

    private int armorRestorePercent = 0;
    private int hpRestorePercent = 0;
    private int atkEnemyPercent = 0;
    private int atkPlayerPercent = 0;
    private int hpEnemyPercent = 0;

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

        difficulty.ResetMultipliers();

        armorRestorePercent = 0;
        hpRestorePercent = 0;
        atkEnemyPercent = 0;
        atkPlayerPercent = 0;
        hpEnemyPercent = 0;

        SetText();

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

    private void SetText()
    {
        armorRestore.text = "ARMOR RESTORE DOWN: " + armorRestorePercent + "%";
        hpRestore.text = "HP RESTORE DOWN: " + hpRestorePercent + "%";
        atkEnemy.text = "ENEMY ATK BOOST: " + atkEnemyPercent + "%";
        atkPlayer.text = "PLAYER ATK DOWN: " + atkPlayerPercent + "%";
        hpEnemy.text = "ENEMY HP BOOST: " + hpEnemyPercent + "%";
    }

    public void StartSpawn()
    {
        totalRoundsText.text = (++totalRounds).ToString();

        if(totalRounds % 12 == 0)
        {
            difficulty.ArmorGainReducedMultiplier -= 0.1f;
            difficulty.HealthGainReducedMultiplier -= 0.1f;
            armorRestorePercent += 10;
            hpRestorePercent += 10;
            SetText();
        }  
        if(totalRounds % 6 == 0)
        {
            difficulty.DamageIncreasedMultiplier += 0.05f;
            difficulty.DamageReducedMultiplier -= 0.05f;
            atkEnemyPercent += 5;
            atkPlayerPercent += 5;
            SetText();
        }
        if(totalRounds % 4 == 0)
        {
            difficulty.HealthIncreasedMultiplier += 0.05f;
            hpEnemyPercent += 5;
            SetText();
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

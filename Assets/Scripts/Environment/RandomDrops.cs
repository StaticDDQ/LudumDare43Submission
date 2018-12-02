using System.Collections.Generic;
using UnityEngine;

public class RandomDrops : MonoBehaviour {

    public static RandomDrops instance;
	[SerializeField] private List<GameObject> survival;
    [SerializeField] private List<GameObject> abilityDrop;
    [SerializeField] private List<GameObject> weaponDrops;
    [SerializeField] private Vector2 minRange;
    [SerializeField] private Vector2 maxRange;
    [SerializeField] private float survivalFreq = 10;
    [SerializeField] private float abilityFreq = 10;
    [SerializeField] private float weaponFreq = 10;
    [SerializeField] private int maxCapacity = 5;
    private int currCapacity = 0;
    private GameObject sur;
    private GameObject abt;
    private GameObject wpn;

    public bool canDrop = false;

    // Use this for initialization
    private void Start () {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        InvokeRepeating("SpawnSurvival", 5f, survivalFreq);
        InvokeRepeating("SpawnAbility", 15f, abilityFreq);
        InvokeRepeating("SpawnWeapon", 10f, weaponFreq);
    }

    private Vector2 GenerateRandomPoint()
    {
        float x = Random.Range(minRange.x, maxRange.x);
        float y = Random.Range(minRange.y, maxRange.y);
        return new Vector2(x, y);
    }

	public void SpawnSurvival()
    {
        if(sur != null)
        {
            Destroy(sur);
            currCapacity--;
        }

        if(canDrop && currCapacity < maxCapacity)
        {
            Vector2 newPos = GenerateRandomPoint();
            GameObject obj = survival[Random.Range(0, survival.Count)];
            sur = Instantiate(obj, newPos, Quaternion.identity);
            currCapacity++;
        }
    }

    public void SpawnAbility()
    {
        if(abt != null)
        {
            Destroy(abt);
            currCapacity--;
        }

        if (canDrop && currCapacity < maxCapacity)
        {
            Vector2 newPos = GenerateRandomPoint();
            GameObject obj = abilityDrop[Random.Range(0, abilityDrop.Count)];
            abt = Instantiate(obj, newPos, Quaternion.identity);
            currCapacity++;
        }
    }

    public void SpawnWeapon()
    {
        if(wpn != null)
        {
            Destroy(wpn);
            currCapacity--;
        }

        if (canDrop && currCapacity < maxCapacity)
        {
            Vector2 newPos = GenerateRandomPoint();
            GameObject obj = weaponDrops[Random.Range(0, weaponDrops.Count)];
            wpn = Instantiate(obj, newPos, Quaternion.identity);
            currCapacity++;
        }
    }

    public void ItemTaken()
    {
        if(currCapacity > 0)
            currCapacity--;
    }
}

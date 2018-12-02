using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDifficulty", menuName = "EnemyDifficulty")]
public class EnemyDifficulty : ScriptableObject
{

    public float DamageIncreasedMultiplier = 1f;
    public float DamageReducedMultiplier = 1f;
    public float HealthIncreasedMultiplier = 1f;
    public float ArmorGainReducedMultiplier = 1f;
    public float HealthGainReducedMultiplier = 1f;

    public void ResetMultipliers()
    {
        DamageIncreasedMultiplier = 1f;
        DamageReducedMultiplier = 1f;
        HealthIncreasedMultiplier = 1f;
        ArmorGainReducedMultiplier = 1f;
        HealthGainReducedMultiplier = 1f;
    }
}

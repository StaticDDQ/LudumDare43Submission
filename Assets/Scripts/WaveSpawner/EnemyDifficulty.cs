using UnityEngine;

[CreateAssetMenu(fileName = "WaveDifficulty", menuName = "WaveDifficulty")]
public class EnemyDifficulty : ScriptableObject {

    public float DamageIncreasedMultiplier = 1f;
    public float DamageReducedMultiplier = 1f;
    public float HealthIncreasedMultiplier = 1f;
    public float ArmorGainReducedMultiplier = 1f;
    public float HealthGainReducedMultiplier = 1f;
}

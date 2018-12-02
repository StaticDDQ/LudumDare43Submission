using UnityEngine;

public class GainUpgrade : MonoBehaviour {

    [SerializeField] private GameObject abilityIcon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            var icon = Instantiate(abilityIcon, collision.transform.position, Quaternion.identity, collision.transform);

            collision.transform.GetChild(0).GetComponent<AbilityManager>().AssignNewAbility(icon.GetComponent<SubGrade>());

            RandomDrops.instance.ItemTaken();
            Destroy(this.gameObject);
        }
    }
}

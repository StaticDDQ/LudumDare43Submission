using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float smooth = 0.15f;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        if(player != null)
        {
            Vector3 newPos = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * smooth);
        }
    }
}

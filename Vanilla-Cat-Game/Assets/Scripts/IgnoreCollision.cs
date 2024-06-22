using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    private PolygonCollider2D fishCollider;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6,8);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject fish = GameObject.FindGameObjectWithTag("Fish");

        
        playerCollider = player.GetComponent<BoxCollider2D>();
        fishCollider = fish.GetComponent<PolygonCollider2D>(); 

        Physics2D.IgnoreCollision(playerCollider, fishCollider);
    }
}

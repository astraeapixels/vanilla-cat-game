using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] private CutSceneManager cutSceneManager;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            cutSceneManager.PlayNextElement();
        }
    }
}

using System.Collections;
using UnityEngine;


public class CutSceneElements : MonoBehaviour
{   
    [SerializeField] private CutSceneManager cutSceneManager;
    [SerializeField] private float duration;

    public virtual void Execute()
    {
        
    }
    protected IEnumerator WaitAndAdavance()
    {
        yield return new WaitForSeconds(duration);
        cutSceneManager.PlayNextElement();
    }

}

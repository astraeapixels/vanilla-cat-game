using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private CutSceneElements[] cutSceneElements;
    private int numOfElements = -1;
    
    private void ExecuteCurrentElement()
    {
        if (numOfElements >= 0 && numOfElements < cutSceneElements.Length)
        {
            cutSceneElements[numOfElements].Execute();
        }
    }
    public void PlayNextElement()
    {
        numOfElements++;
        ExecuteCurrentElement();
    }
}

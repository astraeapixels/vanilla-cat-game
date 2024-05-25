using UnityEngine;

public class CutSceneTest : CutSceneElements
{
    public override void Execute()
    {
        StartCoroutine(WaitAndAdavance());
        Debug.Log("Executing" + name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectToResult : MonoBehaviour
{
    public void ToHappyEnd()
    {
        GlobalManager.SceneCode.ChangeScene(GlobalManager.SceneCode.HappyEnd);
    }

    public void ToBadEnd()
    {
        GlobalManager.SceneCode.ChangeScene(GlobalManager.SceneCode.BadEnd);
    }
}

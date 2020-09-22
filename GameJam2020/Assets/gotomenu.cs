using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotomenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToLevel(int sceneIndex)
    {
        LevelManager.instance.loadLevelAsyncWithIndex(sceneIndex);
    }
}

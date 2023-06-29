using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAudioManager : MonoBehaviour
{
    [SerializeField] GameObject firstBGM;
    [SerializeField] GameObject secondBGM;
    [SerializeField] GameObject thirdBGM;
    [SerializeField] GameObject BGMParent;
    private void Update()
    {
        if (GameManager.instance.MazeCount == 1 && MazeGameManager.instance.isStart)
        {
            firstBGM.SetActive(true);
        }
        if (GameManager.instance.MazeCount == 2 && MazeGameManager.instance.isStart)
        {
            secondBGM.SetActive(true);
        }
        if (GameManager.instance.MazeCount == 3 && MazeGameManager.instance.isStart)
        {
            thirdBGM.SetActive(true);
        }
        if (MazeGameManager.instance.isClear)
        {
            BGMParent.SetActive(false);
        }
    }

}

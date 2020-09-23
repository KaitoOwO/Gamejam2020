using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public static bool gameP;
    public static bool boolseguroP;

    public GameObject menuP, seguroP;

    private void Start()
    {
        menuP.SetActive(false);
        seguroP.SetActive(false);
    }

    public void SwitchPause()
    {
        if (gameP)
        {
            bntResume();
        }
        else
        {
            btnPause();
        }
    }

    void  bntResume()
    {
        menuP.SetActive(false);
        Time.timeScale = 1;
        gameP = false;
    }

    void btnPause()
    {
        menuP.SetActive(true);
        Time.timeScale = 0;
        gameP = true;
    }

    public void mPrincipal ()
    {
        Time.timeScale = 1;
        LevelManager.instance.loadLevelAsyncWithIndex(0);
    }

    public void panel2()
    {
        seguroP.SetActive(true);
    }

    public void salirPno()
    {
        seguroP.SetActive(false);
    }

    public void salirPsi()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScreenController : MonoBehaviour
{
    [SerializeField] GameObject MonsterCam;

    private float timer = 0;
    private bool monsterMode = false;

    private void Update()
    {
        timer += Time.deltaTime;

        if(!monsterMode && timer / 2.5f >= 1f)
        {
            MonsterCam.SetActive(true);
            monsterMode = !monsterMode;
            timer = 0;
        }
        else if (monsterMode && timer / 2f >= .5f)
        {
            MonsterCam.SetActive(false);
            monsterMode = !monsterMode;
            timer = 0;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}

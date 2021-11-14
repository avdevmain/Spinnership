using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text task_text;

    public GameObject currentResult;
    public TMP_Text result_text;
    public TMP_Text wave_text;
    public GameObject pauseMenu;
    public GameObject finishMenu;
    public GameObject SecondStar;
    public GameObject ThirdStar;
    public TMP_Text coin_reward;
    Sequence fadeObjSequence;
    private void Start() {
        fadeObjSequence = DOTween.Sequence();
        fadeObjSequence.Append(task_text.DOFade(1, 1f));
        fadeObjSequence.AppendInterval(1f);
        fadeObjSequence.Append(result_text.DOFade(1, 1f));
        fadeObjSequence.Append(task_text.DOFade(0,1f));
    }
    private Tween fadeObj;
    public void SetObjectiveTitle(string value)
    {
        currentResult.SetActive(true);
        task_text.text = value;
        StartCoroutine(FadeObj());
    }

    private IEnumerator FadeObj()
    {
        fadeObjSequence.Play();
        yield return null;
    }

    private Tween fadeWaves;
    public void UpdateWaveText(int value, int totalWaves)
    {
        wave_text.text = "Wave " + value + " / " + totalWaves; 
        fadeWaves = wave_text.DOFade(1, 0.5f);
        fadeWaves.SetDelay(1f);
        fadeWaves.onComplete += ()=> wave_text.DOFade(0,2f);
  

    }

    public void UpdatePercentageText(int value, int pwr)
    {
        result_text.text = value + "%";
        result_text.transform.DOShakePosition(0.2f, pwr);
    }


    public void ProcessFinish(int result)
    {
        finishMenu.SetActive(true);

        if (result > 70)
        {
            ThirdStar.SetActive(true);
            SecondStar.SetActive(true);
            coin_reward.text = "1,000";
        }
        else
        if (result > 30)
        {
            ThirdStar.SetActive(false);
            SecondStar.SetActive(true);
            coin_reward.text = "700";
        }
        else
        {   
            ThirdStar.SetActive(false);
            SecondStar.SetActive(false);
            coin_reward.text = "400";
        }
    }

}

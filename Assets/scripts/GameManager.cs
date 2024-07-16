using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverTextobj;
    [SerializeField] GameObject gameClearTextobj;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip clearSE;
    [SerializeField] AudioClip gameoverSE;
    private AudioSource audioSource;
    private const int MAX_SCORE = 9999;
    private int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString();
        audioSource = GetComponent<AudioSource>();
    }
    //スコア表示の処理
    public void AddScore(int val)
    {
        score += val;
        if(score> MAX_SCORE)
        {
            score = MAX_SCORE;
        }
        scoreText.text = score.ToString();
    }
    //ゲームオーバー、クリア時の処理
    public void GameOver()
    {
        gameOverTextobj.SetActive(true);
        audioSource.Stop();
        audioSource.PlayOneShot(gameoverSE);
        StartCoroutine(ReStartThiScene());
       
    }
    public void GameClear()
    {
        gameClearTextobj.SetActive(true);
        audioSource.Stop();
        audioSource.PlayOneShot(clearSE);
    }

    private IEnumerator ReStartThiScene()
    {
        yield return new WaitForSeconds(1.0f); // 遅延時間を設定する  
        Scene ThisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(ThisScene.name);
    }
}
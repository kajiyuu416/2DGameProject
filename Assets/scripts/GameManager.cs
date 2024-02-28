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
    //SE
    [SerializeField] AudioClip clearSE;
    [SerializeField] AudioClip gameoverSE;
    AudioSource audioSource;


    const int MAX_SCORE = 9999;
    int score = 0;

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
        Invoke("ReStartThiScene", 1f);
       
    }
    public void GameClear()
    {
        gameClearTextobj.SetActive(true);
        audioSource.Stop();
        audioSource.PlayOneShot(clearSE);
    }

    void ReStartThiScene()
    {
        Scene ThisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(ThisScene.name);

    }
}
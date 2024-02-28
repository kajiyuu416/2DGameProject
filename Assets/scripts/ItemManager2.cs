using UnityEngine;

public class ItemManager2 : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    //アイテムとプレイヤーが接触したらアイテムを消滅させる処理
    public void GetItem()
    {
        gameManager.AddScore(500);
        Destroy(this.gameObject);
    }
}


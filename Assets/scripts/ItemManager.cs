using UnityEngine;

public class ItemManager : MonoBehaviour
{
    GameManager gameManager;
  
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    //アイテムとプレイヤーが接触したらアイテムを消滅させる処理
    public void GetItem()
    {
        gameManager.AddScore(100);
        Destroy(this.gameObject);
    }
}

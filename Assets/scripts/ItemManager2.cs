using UnityEngine;

public class ItemManager2 : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] Items;
    //アイテムとプレイヤーが接触したらアイテムを消滅させる処理
    public void GetItem()
    {
        gameManager.AddScore(500);
        Destroy(this.gameObject);
    }
}


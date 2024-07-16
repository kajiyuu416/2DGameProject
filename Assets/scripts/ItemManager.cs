using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] Items;
    //アイテムとプレイヤーが接触したらアイテムを消滅させる処理
    public void GetItem()
    {
        gameManager.AddScore(100);
        Destroy(this.gameObject);
    }
}

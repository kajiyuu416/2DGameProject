using UnityEngine;

public class ItemManager2 : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    //�A�C�e���ƃv���C���[���ڐG������A�C�e�������ł����鏈��
    public void GetItem()
    {
        gameManager.AddScore(500);
        Destroy(this.gameObject);
    }
}


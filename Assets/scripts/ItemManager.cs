using UnityEngine;

public class ItemManager : MonoBehaviour
{
    GameManager gameManager;
  
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    //�A�C�e���ƃv���C���[���ڐG������A�C�e�������ł����鏈��
    public void GetItem()
    {
        gameManager.AddScore(100);
        Destroy(this.gameObject);
    }
}

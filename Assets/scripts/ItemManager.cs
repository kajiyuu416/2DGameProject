using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] Items;
    //�A�C�e���ƃv���C���[���ڐG������A�C�e�������ł����鏈��
    public void GetItem()
    {
        gameManager.AddScore(100);
        Destroy(this.gameObject);
    }
}

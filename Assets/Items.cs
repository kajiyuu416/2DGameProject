using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : ScriptableObject
{
    [SerializeField]
    string testString = "�����ScriptableObject�̃e�X�g�ł��B";

    public string TestString
    {
        get
        {
            return testString;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

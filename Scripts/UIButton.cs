using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject sceneController;
    private string functionToCall;
    private SpriteRenderer spriteRenderer;
    

    

    void Start()
    {
        spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject sceneController;
    private string functionToCall;
    private SpriteRenderer spriteRenderer;
    

    private void OnMouseEnter()
    {
        if(spriteRenderer != null) {
            spriteRenderer.color = Color.cyan;
        }
    }

    void Start()
    {
        spriteRenderer = sceneController.GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        
    }
}

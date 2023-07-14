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

    private void OnMouseExit()
    {
        if(spriteRenderer != null) {
            spriteRenderer.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        this.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }


    void Start()
    {
        spriteRenderer = sceneController.GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        
    }
}

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
        this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    private void OnMouseUp()
    {
        this.transform.localScale = Vector3.one;

        if(sceneController != null) {
            sceneController.SendMessage(functionToCall);
        }    
    }

    void Start()
    {
        spriteRenderer = sceneController.GetComponent<SpriteRenderer>();
        functionToCall = "RestartGame";
    }

   
    void Update()
    {
        
    }
}

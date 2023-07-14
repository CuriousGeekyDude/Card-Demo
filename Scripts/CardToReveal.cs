using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToReveal : MonoBehaviour
{

    [SerializeField] private GameObject CardBack = null;
    [SerializeField] public int imageID;
    [SerializeField] private CardInitializer sceneController;
    
    public void ActivateCardBack()
    {
        if(CardBack.activeSelf == false) {
            CardBack.SetActive(true);
        }
    }

    public void OnMouseDown()
    {
        sceneController.NotifyOfClick(imageID);
        if(CardBack.activeSelf == true) {
            CardBack.SetActive(false);
        }
        else { CardBack.SetActive(true); }
    }

    public void setImage(Sprite imageToSet)
    {
        this.transform.GetComponent<SpriteRenderer>().sprite = imageToSet;
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneController = GameObject.Find("CardInitializer").GetComponent<CardInitializer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

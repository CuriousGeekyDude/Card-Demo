using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToReveal : MonoBehaviour
{

    [SerializeField] private GameObject CardBack = null;
    [SerializeField] public int imageID;
    
    public void ActivateCardBack()
    {
        if(cardToDeactivate.activeSelf == false) {
            cardToDeactivate.SetActive(true);
        }
    }

    public void OnMouseDown()
    {
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

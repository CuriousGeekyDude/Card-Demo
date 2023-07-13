using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToReveal : MonoBehaviour
{

    [SerializeField] private GameObject CardBack = null;
    

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

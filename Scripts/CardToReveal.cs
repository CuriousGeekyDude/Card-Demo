using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToReveal : MonoBehaviour
{

    [SerializeField] private GameObject CardBack = null;
    private Sprite image;

    public void OnMouseDown()
    {
        if(CardBack.activeSelf == true) {
            CardBack.SetActive(false);
        }
        else { CardBack.SetActive(true); }
    }


    // Start is called before the first frame update
    void Start()
    {
        image = this.transform.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

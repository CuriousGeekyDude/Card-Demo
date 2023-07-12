using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInitializer : MonoBehaviour
{

    [SerializeField] private Sprite[] images = new Sprite[4];
    private CardToReveal card;
    private int[] numberOfTimesAnImageGotInit = new int[4];
    private bool toRestart = true;


    private int findNonZeroElementInIntArray(int index)
    {

        if(index == 0) {
            while(index != 4) {
                if(numberOfTimesAnImageGotInit[index] != 0) {
                    return index;
                }
                ++index;
            }
            return -1;
        }

        if(0 < index && index < 4) {
            var dummyVar = ++index;

            while(index != dummyVar) {
                if(index == 4) {
                    index = 0;
                }

                if(numberOfTimesAnImageGotInit[index] != 0) {
                    return index;
                }

                ++index;
            }
            return -1;
        }

        if(index < 0 || 4 <= index ) {
            return -1;
        }
        return -1;
    }


private void InitializeCards()
    {
        if(toRestart == true) {
            for(int i = 0; i < 8; ++i) {
                int index = Random.Range(0, 5);
                index = findNonZeroElementInIntArray(index);
                --numberOfTimesAnImageGotInit[index];
                imageObjects[i] = Instantiate(images[index]) as Sprite;
                
                if(i < 4) {
                    imageObjects[i].transform.position = new Vector3(-3.9 + i*1.7, 1.9f, 4.0f);
                }

                else {
                    imageObjects[i].transform.position = new Vector3(-3.9 + (i - 4)*1.7, -1.0f, 4.0f);   
                }
                
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

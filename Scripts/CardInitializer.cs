using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInitializer : MonoBehaviour
{

    [SerializeField] private Sprite[] images = new Sprite[4];
    private int[] imageIdInScene = new int[8];
    [SerializeField] private CardToReveal card;
    private int[] numberOfTimesAnImageGotInit = new int[4];
    private bool toRestart = true;

    void SetImageIdInScene(int index, int imageID)
    {
        imageIdInScene[index] = imageID;
    }
    int RandomPlusMinusOne()
    {
        int randomNumber = Random.Range(-1, 2);

        while(randomNumber == 0) {
            randomNumber = Random.Range(-1, 2);
        }

        return randomNumber;

    }

    void changeIndexValue(int valueOfChange, ref int index)
    {
        if(valueOfChange == 1) {
            ++index;
        }
        else { --index; }
    }

    private int findNonZeroElementInIntArray(int index, int valueOfChange)
    {

        if(0 <= index && index <= 3) {
            var containerOfIndex = index;

            if(numberOfTimesAnImageGotInit[index] != 0) {
                    return index;
            }

            changeIndexValue(valueOfChange, ref index);
            while(index != containerOfIndex) {
                if(index == -1) {
                    index = 3;
                }
                if(index == 4) {
                    index = 0;
                }

                if(numberOfTimesAnImageGotInit[index] != 0) {
                    return index;
                }

                changeIndexValue(valueOfChange, ref index);
            }
        }

        return -1;
    }


    private void InitializeCards()
    {
           toRestart = false; 
            for(int i = 0; i < 8; ++i) {
                int index = Random.Range(0, 4);
                index = findNonZeroElementInIntArray(index, RandomPlusMinusOne());
                if(index == -1) {  return; }
                --numberOfTimesAnImageGotInit[index];
                card = Instantiate(card) as CardToReveal;
               
                if(i < 4) {
                    card.transform.position = new Vector3(-3.9f + i*1.7f, 1.9f, 4.0f);
                }

                else {
                    card.transform.position = new Vector3(-3.9f + (i - 4)*1.7f, -1.0f, 4.0f);   
                }
                card.setImage(images[index]);
                SetImageIdInScene(i, index);
            }
        
    }

    void Start()
    {
        for(int i = 0; i < 4; ++i)
        {
            numberOfTimesAnImageGotInit[i] = 2;
        }

        InitializeCards();
    }

    void Update()
    {
        if(toRestart == true) {
            InitializeCards();
        }
    }
}

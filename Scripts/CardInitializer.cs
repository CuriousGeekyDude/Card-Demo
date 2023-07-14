using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInitializer : MonoBehaviour
{

    [SerializeField] private Sprite[] images = new Sprite[4];
    [SerializeField] private CardToReveal[] clonedCards= new CardToReveal[8];
    private int[] imageIdInScene = new int[8];
    [SerializeField] private CardToReveal card;
    private int[] cardIdClicked = new int[2];
    private int indexOfCardIdClicked;
    private bool toRestart = true;


    private bool CompareClickedCards()
    {
        if(cardIdClicked[0] == cardIdClicked[1]) {
            return true;
        }
        return false;
    }

    private IEnumerator ActivateCardWithDelay()
    {
        yield return new WaitForSeconds(1);

        for(int i = 0; i < 8; ++i) {
            clonedCards[i].ActivateCardBack();
        }
    }

    public void NotifyOfClick(int imageID)
    {
        cardIdClicked[indexOfCardIdClicked] = imageID;
        ++indexOfCardIdClicked;

        if(indexOfCardIdClicked == 2) {
            indexOfCardIdClicked = 0;
            if(CompareClickedCards() == false) {
                StartCoroutine(ActivateCardWithDelay());
            }
        }
    }

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

    private int findNonZeroElementInIntArray(int[] numberOfTimesAnImageGotInit, int index, int valueOfChange)
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

    private void initializeIntArray(int[] intArray,int valueToInitializeTo)
    {
        for(int i = 0; i < intArray.Length; ++i) {
            intArray[i] = valueToInitializeTo;
        }
    }
    private void InitializeCards()
    {
           int[] numberOfTimesAnImageGotInit = new int[4];
           initializeIntArray(numberOfTimesAnImageGotInit, 2);
           toRestart = false; 
            for(int i = 0; i < 8; ++i) {
                int index = Random.Range(0, 4);
                index = findNonZeroElementInIntArray(numberOfTimesAnImageGotInit , index, RandomPlusMinusOne());
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
                card.imageID = index;
                clonedCards[i] = card;
            }
        
    }

    void Start()
    {

        InitializeCards();
    }

    void Update()
    {
        if(toRestart == true) {
            InitializeCards();
        }
    }
}

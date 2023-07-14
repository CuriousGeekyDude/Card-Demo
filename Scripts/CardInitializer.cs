using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardInitializer : MonoBehaviour
{

    [SerializeField] private Sprite[] images = new Sprite[4];
    [SerializeField] private CardToReveal[] clonedCards= new CardToReveal[8];
    private int[] imageIdInScene = new int[8];
    [SerializeField] private CardToReveal card;
    private int[] cardIdClicked = new int[2];
    private int indexOfCardIdClicked;
    private int numberOfRevealedCards;
    [SerializeField] private TMP_Text scoreLabel;
    private int score;


    private bool CompareClickedCards()
    {
        if(cardIdClicked[0] == cardIdClicked[1]) {
            return true;
        }
        return false;
    }

    private (int,int) FindIndicesOfImageID(int imageID)
    {
        (int, int) indices = (0, 0);
        int numberOfIndicesFound = 0;
        for(int i = 0; i < 8; ++i) {
            if(imageIdInScene[i] == imageID) {
                ++numberOfIndicesFound;

                switch(numberOfIndicesFound) {
                    case 1:
                        indices.Item1 = i;
                        break;
                    case 2:
                        indices.Item2 = i;
                        break;
                }
            }
        }
        return indices;
    }

    private IEnumerator ActivateCardsWithDelay(int imageID_1, int imageID_2)
    {
        (int, int) imageID1_indices, imageID2_indices;
        imageID1_indices = FindIndicesOfImageID(imageID_1);
        imageID2_indices = FindIndicesOfImageID(imageID_2);
        numberOfRevealedCards -= 2;
        yield return new WaitForSeconds(1);


        for(int i = 0; i < 8; ++i) {
           if(i==imageID1_indices.Item1 || i==imageID1_indices.Item2 || i==imageID2_indices.Item1 || i==imageID2_indices.Item2) {
                clonedCards[i].ActivateCardBack();
           }
        }
    }

    public void NotifyOfClick(int imageID)
    {
        cardIdClicked[indexOfCardIdClicked] = imageID;
        ++indexOfCardIdClicked;
        ++numberOfRevealedCards;

        if(indexOfCardIdClicked == 2) {
            indexOfCardIdClicked = 0;
            if(CompareClickedCards() == false) {
                StartCoroutine(ActivateCardsWithDelay(cardIdClicked[0], cardIdClicked[1]));
            }
            else {
                ++score;
                scoreLabel.text = $"Score: {score}";
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

    private int ChooseIndexRandomly(int[] numberOfTimesAnImageGotInit, int seed)
    {
        int index = Random.Range(0, 4);
        index = findNonZeroElementInIntArray(numberOfTimesAnImageGotInit , index, seed);

        return index;
    }
    private void InitializeCards()
    {
           int[] numberOfTimesAnImageGotInit = new int[4];
           initializeIntArray(numberOfTimesAnImageGotInit, 2);
           numberOfRevealedCards = 0;
            for(int i = 0; i < 8; ++i) {
                int index = ChooseIndexRandomly(numberOfTimesAnImageGotInit, RandomPlusMinusOne());
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

    private IEnumerator pauseBeforeShuffling()
    {
        yield return new WaitForSeconds(1);

        for(int i = 0; i < 8; ++i) {
            clonedCards[i].imageID = imageIdInScene[i];
            clonedCards[i].setImage(images[imageIdInScene[i]]);
            clonedCards[i].ActivateCardBack();
        }
    }
    private void ShuffleCards()
    {
        for(int i = 0; i < 8; ++i) {
            int dummy_var = imageIdInScene[i];
            int randomIndex = Random.Range(i, imageIdInScene.Length);
            imageIdInScene[i] = imageIdInScene[randomIndex];
            imageIdInScene[randomIndex] = dummy_var;
        }

        StartCoroutine(pauseBeforeShuffling());
    }
    void Start()
    {
        InitializeCards();
    }

    void Update()
    {
        if(numberOfRevealedCards == 8) {
            numberOfRevealedCards = 0;
            ShuffleCards();
        }
    }
}

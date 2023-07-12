using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInitializer : MonoBehaviour
{

    [SerializeField] private Sprite[] images = new Sprite[4];
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

        if(4 < index ) {
            return -1;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

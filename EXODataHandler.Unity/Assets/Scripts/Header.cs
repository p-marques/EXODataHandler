using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Header : MonoBehaviour
{
    [SerializeField]
    public GameObject linkedDataZone;
    private GameObject LinkedDatazone { get => linkedDataZone; }

    //maybe enum ?
    private bool isSorted;
    private void FlipData(GameObject DataZone)
    {
        //need to flip all data according to the on that was picked e.g. everything starts sorted by
        // alphabetical order with planets, but i chose to sort by year of discovry i need to 
        //grab each discovery years index and feed it to the rows
        //1-  In short i must grab the column of the button that was pressed
        //2-  Sort that column
        //3-  feed its index to all the other rows
        //this sounds very heavy >C

    }
}

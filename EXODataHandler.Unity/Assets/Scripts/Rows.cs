using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rows : MonoBehaviour
{
    public GameObject[] dataRow;

    private GameObject[] DataRow { get => dataRow; }

    private GameObject[] arrayOfRows;

    //maybe enum ?
    private bool isSorted;
    public Rows(GameObject datarow, GameObject arrayofrows)
    {
        datarow = dataRow[8];
        arrayofrows = arrayOfRows[50];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rows : MonoBehaviour
{
    private GameObject[] dataRow;

    public GameObject[] DataRow { get => dataRow; }

    private GameObject[] arrayOfRows;

    //maybe enum ?
    private bool isSorted;
    public Rows(GameObject datarow, GameObject arrayofrows)
    {
        datarow = dataRow[8];
        arrayofrows = arrayOfRows[50];
    }
}

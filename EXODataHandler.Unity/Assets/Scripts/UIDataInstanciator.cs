using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This class is responsible for placing all the rows and columns of info
public class UIDataInstanciator : MonoBehaviour
{
    private int totalRows;
    // maxChildren will have to be set according to the amount of paramaters given by the file
    private byte maxChildren;
    private float random;

    [SerializeField]
    private GameObject rowPrefab, textPrefab;

    private  TextMeshProUGUI textComponent;

    //space between each column should be individual, and the colums transform should be at previousColumn.X + previousColumn.width
    //Column.width = longest object in column. (THIS INFORMATION MUST COME FROM DATACORE
    private void Start()
    {
        maxChildren = 8;
        totalRows = 20;
        GenerateData();
    }
    public void GenerateData() //should receive max rows and columns
    {
        for (int i = 0; i < totalRows; i++)
        {
            //generate row
            GameObject row = Instantiate(rowPrefab, new Vector3(gameObject.transform.position.x,
               gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            row.transform.SetParent(gameObject.transform);

            do
            {
                //generate each text object
                GameObject text = Instantiate(textPrefab);
                text.transform.SetParent(row.transform);
                //write in each text
                random = Random.Range(0.0f, 100000000.0f);
                textComponent = text.GetComponent<TextMeshProUGUI>();
                textComponent.text = $"{random}"; //Data goes here
            } while (row.transform.childCount != maxChildren);

        }
    }
}

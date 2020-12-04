using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This class is responsible for placing all the rows and columns of info
public class UIDataInstantiator : MonoBehaviour
{
    private byte totalRows;
    // maxChildren will have to be set according to the amount of paramaters given by the file
    private ushort maxChildren;

    private RectTransform headerTransform;
    private Vector3 scalechange;

    private float headerWidth;

    [SerializeField]
    private GameObject rowPrefab, textPrefab, headerPrefab, headerspot;

    private  TextMeshProUGUI textComponent;

    //space between each column should be individual, and the colums transform should be at previousColumn.X + previousColumn.width
    //Column.width = longest object in column. (THIS INFORMATION MUST COME FROM DATACORE
    private void Start()
    {
        maxChildren = 4000;
        totalRows = 8;
        SpawnHeaders(maxChildren);
    } 
    private void SpawnHeaders(int totalRows)
    {
        for (int i = 0; i < totalRows; i++)
        {

            headerTransform = headerPrefab.GetComponent<RectTransform>();
            headerWidth = headerTransform.sizeDelta.x + 15;

            GameObject header = Instantiate(headerPrefab, 
                new Vector3(headerspot.transform.position.x + headerWidth * i,
                headerspot.transform.position.y, headerspot.transform.position.z), Quaternion.identity);
            header.transform.SetParent(headerspot.transform);
            //THIS CANT BE HERE FIND A FIX vvvvvv
            scalechange = new Vector3(2, 2, 0);
            header.transform.localScale -= scalechange;
            //----------------------------------

            GameObject child = header.transform.GetChild(0).gameObject;
            textComponent = child.GetComponent<TextMeshProUGUI>();
            textComponent.text = "Nice"; //Name of parameter here

        }
        for (int i = 0; i < totalRows; i++)
        {
            MakeDataAppearOnHeader(headerspot);
        }
    }
    private void MakeDataAppearOnHeader(GameObject headerspot)
    {
        for (int i = 0; i < maxChildren; i++)
        {
            GameObject headerToFill = headerspot.transform.GetChild(i).gameObject; //this gets the header from header spawner
            GameObject DataZone = headerToFill.transform.GetChild(4).gameObject;
            GameObject textchild = Instantiate(textPrefab, new Vector3(DataZone.transform.position.x, //this child is 
                DataZone.transform.position.y, DataZone.transform.position.z), Quaternion.identity); //meant to be instantiated inside the data zone of headerTofill
            textchild.transform.SetParent(DataZone.transform);

            //write in each text
            textComponent = textchild.GetComponent<TextMeshProUGUI>();
            textComponent.text = $"{i}"; //Data goes here
        }
    }
}


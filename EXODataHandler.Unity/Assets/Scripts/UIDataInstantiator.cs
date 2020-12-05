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
    private GameObject textPrefab, headerPrefab, headerspot, dataZone;
    [SerializeField]
    private Header Header;

    private  TextMeshProUGUI textComponent;

    //space between each column should be individual, and the colums transform should be at previousColumn.X + previousColumn.width
    //Column.width = longest object in column. (THIS INFORMATION MUST COME FROM DATACORE
    private void Start()
    {
        maxChildren = 50;
        totalRows = 8;
        SpawnHeaders(totalRows);
    } 
    private void SpawnHeaders(int totalRows)
    {
        for (int i = 0; i < totalRows; i++)
        {

            headerTransform = headerPrefab.GetComponent<RectTransform>();
            headerWidth = headerTransform.sizeDelta.x + 15;

            GameObject _header = Instantiate(headerPrefab, 
                new Vector3(headerspot.transform.position.x + headerWidth * i,
                headerspot.transform.position.y, headerspot.transform.position.z), Quaternion.identity);
            _header.transform.SetParent(headerspot.transform);

            //THIS CANT BE HERE FIND A FIX vvvvvv
            scalechange = new Vector3(2, 2, 0);
            _header.transform.localScale -= scalechange;
            //----------------------------------

            GameObject child = _header.transform.GetChild(0).gameObject;
            textComponent = child.GetComponent<TextMeshProUGUI>();
            textComponent.text = "Nice"; //Name of parameter here

        }
        for (int i = 0; i < totalRows; i++)
        {
            GameObject _header = headerspot.transform.GetChild(i).gameObject;
            GameObject dataZoneSpawner = _header.transform.GetChild(4).gameObject;
            GameObject _dataZone = Instantiate(dataZone, new Vector3(dataZoneSpawner.transform.position.x, //this child is 
                dataZoneSpawner.transform.position.y, dataZoneSpawner.transform.position.z), Quaternion.identity);
            _dataZone.transform.SetParent(gameObject.transform);
            MakeDataAppearOnHeader(_dataZone);
        }
    }
    private void MakeDataAppearOnHeader(GameObject _dataZoneToFill)
    {
        for (int i = 0; i < maxChildren; i++)
        {
            //checking trying to find more headers than there are
            GameObject _textchild = Instantiate(textPrefab, new Vector3(_dataZoneToFill.transform.position.x, //this child is 
                _dataZoneToFill.transform.position.y, _dataZoneToFill.transform.position.z), Quaternion.identity); //meant to be instantiated inside the data zone of headerTofill
            _textchild.transform.SetParent(_dataZoneToFill.transform);

            //write in each text
            textComponent = _textchild.GetComponent<TextMeshProUGUI>();
            textComponent.text = $"{i}"; //Data goes here
        }
    }

    //Another problem arises
    //Headers must be parented on DataUI_vertical
    //DataZones must be Content yet somehow linked to each header
    //When DataZones are generated they get a property that links them to the Headers
    //
}


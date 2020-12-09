using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This class is responsible for placing all the headers and information on screen
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

    private Rows dataOnScreen;

    private  TextMeshProUGUI textComponent;

    //space between each column should be individual, and the colums transform should be at previousColumn.X + previousColumn.width
    //Column.width = longest object in column. (THIS INFORMATION MUST COME FROM DATACORE
    private void Start()
    {
        dataOnScreen = gameObject.GetComponent<Rows>();
        maxChildren = 100;
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
            Header header = _header.GetComponent<Header>();
            GameObject dataZoneSpawner = _header.transform.GetChild(4).gameObject;
            GameObject _dataZone = Instantiate(dataZone, new Vector3(dataZoneSpawner.transform.position.x, //this child is 
                dataZoneSpawner.transform.position.y, dataZoneSpawner.transform.position.z), Quaternion.identity);
            _dataZone.transform.SetParent(gameObject.transform);
            header.linkedDataZone = _dataZone;
            MakeDataAppear(_dataZone, i);
        }
    }
    private void MakeDataAppear(GameObject _dataZoneToFill, int i)
    {
        for (int j = 0; j < maxChildren; j++)
        {
            GameObject _textchild = Instantiate(textPrefab, new Vector3(_dataZoneToFill.transform.position.x, //this child is 
                _dataZoneToFill.transform.position.y, _dataZoneToFill.transform.position.z), Quaternion.identity); //meant to be instantiated inside the data zone of headerTofill
            _textchild.transform.SetParent(_dataZoneToFill.transform);

            //write in each text
            textComponent = _textchild.GetComponent<TextMeshProUGUI>();
            textComponent.text = $"{i}"; //Data goes here
        }
    }
    //if you scroll past half ? 
    // it instantiates more text where it left of... aka property
    // also destroys the ones that are before so it should be the first 25 and load another 25
    // 
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EXODataHandler.Core;
using EXODataHandler.API;
using EXODataHandler.API.Entities;

// This class is responsible for placing all the headers and information on screen
public class UIDataInstantiator : MonoBehaviour
{
    private byte totalRows;
    // maxChildren will have to be set according to the amount of paramaters given by the file
    private ushort maxChildren;

    [SerializeField]
    private ProgramStateEnum programState;

    private RectTransform headerTransform;
    private Vector3 scalechange;

    private bool headersOn;

    private float headerWidth;

    private int screenX;
    private int screenY;

    private EXODataSet allData;

    [SerializeField]
    private FilePathInput fileReader;

    [SerializeField]
    private GameObject textPrefab, headerPrefab, headerspot, dataZone;
    [SerializeField]
    private Header Header;

    private  TextMeshProUGUI textComponent;

    private string typeOfData;
    private void Start()
    {
        maxChildren = 50;
        totalRows = 8;
    }
    private void Update()
    {
    }
    public void SpawnHeaders(int totalRows) //planet list, or star list?
    {
        allData = fileReader.AllData;
        for (int i = 0; i < totalRows; i++)
        {
            headerTransform = headerPrefab.GetComponent<RectTransform>();
            headerWidth = headerTransform.sizeDelta.x + 15;

            GameObject _header = Instantiate(headerPrefab, 
                new Vector3(headerspot.transform.position.x + headerWidth * i,
                headerspot.transform.position.y, headerspot.transform.position.z), Quaternion.identity);
            _header.transform.SetParent(headerspot.transform);


            //THIS CANT BE HERE FIND A FIX vvvvvv
            //scalechange = new Vector3(2, 2, 0);
            //_header.transform.localScale -= scalechange;
            screenX = Screen.width;
            screenY = Screen.height;

            //----------------------------------
            //print(allData);
            GameObject child = _header.transform.GetChild(2).gameObject;
            textComponent = child.GetComponent<TextMeshProUGUI>();


            for (int z = 0; z < allData.DataStructure.Headers.Count; z++)
            {
                print(allData.DataStructure.Headers[z].Id);
            }

            if (totalRows == 8)
            {
                textComponent.text = allData.DataStructure.Headers[i].Id; //Name of parameter here
                typeOfData = "planets";
            }
            else
            {
                textComponent.text = allData.DataStructure.Headers[i+7].Id;
                typeOfData = "stars";
            }


        }
        for (int i = 0; i < totalRows; i++)
        {
            GameObject _header = headerspot.transform.GetChild(i).gameObject;
            Header header = _header.GetComponent<Header>();
            GameObject dataZoneSpawner = _header.transform.GetChild(4).gameObject;
            GameObject _dataZone = Instantiate(dataZone, new Vector3(dataZoneSpawner.transform.position.x +19, //this child is 
                dataZoneSpawner.transform.position.y, dataZoneSpawner.transform.position.z), Quaternion.identity);
            _dataZone.transform.SetParent(gameObject.transform);
            header.LinkedDataZone = _dataZone;
            MakeDataAppear(_dataZone, i, typeOfData);
        }
        headersOn = true;
    }
    private void MakeDataAppear(GameObject _dataZoneToFill, int i, string nameOfData) 
    {
        for (int j = 0; j < maxChildren; j++)
        {
            GameObject _textchild = Instantiate(textPrefab, new Vector3(_dataZoneToFill.transform.position.x, //this child is 
                _dataZoneToFill.transform.position.y, _dataZoneToFill.transform.position.z), Quaternion.identity); //meant to be instantiated inside the data zone of headerTofill
            _textchild.transform.SetParent(_dataZoneToFill.transform);

            //write in each text
            textComponent = _textchild.GetComponent<TextMeshProUGUI>();
            if (nameOfData == "planets")
            {
                switch (i)
                {
                    case 0:
                        textComponent.text = allData.Planets[j].Name;
                        break;
                    case 1:
                        textComponent.text = allData.Planets[j].Host.Name;
                        break;
                    case 2:
                        textComponent.text = allData.Planets[j].DiscoveryMethod.ToString();
                        break;
                    case 3:
                        textComponent.text = allData.Planets[j].DiscoveryYear.ToString();
                        break;
                    case 4:
                        textComponent.text = allData.Planets[j].Mass.ToString();
                        break;
                    case 5:
                        textComponent.text = allData.Planets[j].EquilibriumTemperature.ToString();
                        break;
                    case 6:
                        textComponent.text = allData.Planets[j].OrbitalPeriod.ToString();
                        break;
                    case 7:
                        textComponent.text = allData.Planets[j].Radius.ToString();
                        break;
                }  
            }
            else
            {
                switch (i)
                {
                    case 0:
                        textComponent.text = allData.Stars[j].Name;
                        break;
                    case 1:
                        textComponent.text = allData.Stars[j].SunDistance.ToString();
                        break;
                    case 2:
                        textComponent.text = allData.Stars[j].RotationPeriod.ToString();
                        break;
                    case 3:
                        textComponent.text = allData.Stars[j].Age.ToString();
                        break;
                    case 4:
                        textComponent.text = allData.Stars[j].Radius.ToString();
                        break;
                    case 5:
                        textComponent.text = allData.Stars[j].Mass.ToString();
                        break;
                    case 6:
                        textComponent.text = allData.Stars[j].RotationSpeed.ToString();
                        break;
                }
            }
        }
    }
    /*
     * 
     * 
     * 
     * 
    //if you scroll past half ? 
    // it instantiates more text where it left of... aka property
    // also destroys the ones that are before so it should be the first 25 and load another 25
    // */
}


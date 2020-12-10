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
    private int totalRows;
    // maxChildren will have to be set according to the amount of paramaters given by the file
    private int maxChildren;
    private int currentPage;

    [SerializeField]
    private ProgramStateEnum programState;

    private RectTransform headerTransform;
    private Vector3 scalechange;

    private float headerWidth;

    private int screenX;
    private int screenY;


    private EXODataSet allData;

    [SerializeField]
    private FilePathInput fileReader;

    
    //private GameObject[] dataZones;

    [SerializeField]
    private GameObject textPrefab, headerPrefab, headerspot, dataZone;
    [SerializeField]
    private Header Header;

    private  TextMeshProUGUI textComponent;

    private string typeOfData;
    private void Start()
    {
        //dataZones[0] = null;
        currentPage = 1;
        maxChildren = 50;
        totalRows = 3;
    }
    public void SpawnHeaders() //planet list, or star list?
    {
        allData = fileReader.AllData;
        print(allData.DataStructure.Headers.Count);
        print(allData.PlanetCount);
        totalRows = allData.DataStructure.Headers.Count;
        maxChildren = allData.PlanetCount;
        for (int i = 0; i < totalRows; i++)
        {
            headerTransform = headerPrefab.GetComponent<RectTransform>();
            headerWidth = headerTransform.sizeDelta.x;

            GameObject _header = Instantiate(headerPrefab, 
                new Vector3(headerspot.transform.position.x + headerWidth * i,
                headerspot.transform.position.y, headerspot.transform.position.z), Quaternion.identity);
            _header.transform.SetParent(headerspot.transform);

            //----------------------------------
            //print(allData);
            GameObject child = _header.transform.GetChild(2).gameObject;
            textComponent = child.GetComponent<TextMeshProUGUI>();
            textComponent.text = allData.DataStructure.Headers[i].Id;

            for (int z = 0; z < allData.DataStructure.Headers.Count; z++)
            {
                print(allData.DataStructure.Headers[z].Id);
            }

            // VVVVVVVVVV this isnt finished yet... it grabs all parameters which means it could grab parameters from other things if index is used
             /*
            if ()
            {
                textComponent.text = allData.DataStructure.Headers[i].Id; //Name of parameter here
                typeOfData = "planets";
            }
            else
            {
                textComponent.text = allData.DataStructure.Headers[i].Id;
                typeOfData = "stars";
            }*/
        }

        

        for (int i = 0; i < totalRows; i++)
        {
            GameObject _header = headerspot.transform.GetChild(i).gameObject;
            Header header = _header.GetComponent<Header>();
            GameObject dataZoneSpawner = _header.transform.GetChild(4).gameObject;
            GameObject _dataZone = Instantiate(dataZone, new Vector3(gameObject.transform.position.x + dataZoneSpawner.transform.position.x, //this child is 
                gameObject.transform.position.y, dataZoneSpawner.transform.position.z), Quaternion.identity);
            _dataZone.transform.SetParent(gameObject.transform);
            header.LinkedDataZone = _dataZone;

            MakeDataAppear(_dataZone, i, typeOfData);
        }

    }
    private void MakeDataAppear(GameObject _dataZoneToFill, int i, string typeOfData)  //receive header.text intead of i, and fix states accordingly
    {
        int j;
        for (j = maxChildren * (currentPage -1); j < maxChildren * currentPage; j++)
        {
            GameObject _textchild = Instantiate(textPrefab, new Vector3(_dataZoneToFill.transform.position.x, //this child is 
                _dataZoneToFill.transform.position.y, _dataZoneToFill.transform.position.z), Quaternion.identity); //meant to be instantiated inside the data zone of headerTofill
            _textchild.transform.SetParent(_dataZoneToFill.transform);

            //write in each text
            textComponent = _textchild.GetComponent<TextMeshProUGUI>();
            typeOfData = "planets";
            if (typeOfData == "planets")
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
}


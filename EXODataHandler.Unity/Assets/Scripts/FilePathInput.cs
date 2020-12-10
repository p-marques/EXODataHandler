using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using EXODataHandler.API;
using EXODataHandler.API.Entities;
using EXODataHandler.Core;
using TMPro;

public class FilePathInput : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI input;

    string fileName;
    string path;

    private EXODataSet allData;
    public EXODataSet AllData { get => allData; }

    private bool parseSucess;
    public bool ParseSucess { get => parseSucess; }

    IEXODataRepository repo;
    private void Start()
    {
        input = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        repo = new EXODataRepository();
    }

    public void ParseFile()
    {
        fileName = input.text;
        path = Path.Combine(Environment
             .GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        APIResponse<EXODataSet> response = repo.ParseFile(path);
        if (response.Success)
        {
            allData = response.Result;
            parseSucess = true;
        }
        else
        {
            //Message didnt work
        }    


    }
}

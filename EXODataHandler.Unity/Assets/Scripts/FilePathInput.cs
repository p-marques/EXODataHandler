using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using EXODataHandler.API;
using EXODataHandler.API.Entities;
using EXODataHandler.Core;
using TMPro;
using System.Text;

public class FilePathInput : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI input;

    [SerializeField]
    private GameObject menu1, menu2;

    string fileName;
    string path;

    private EXODataSet allData;
    public EXODataSet AllData { get => allData; }

    private bool parseSucess;
    public bool ParseSucess { get => parseSucess; }

    IEXODataRepository repo;
    private void Start()
    {
        menu1 = gameObject;
        repo = new EXODataRepository();
    }

    public void ParseFile()
    {
        Encoding aSCII = Encoding.ASCII;
        Encoding uNICODE = Encoding.Unicode;
        
        print("isparsing");
        input = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //fileName = "Exodata.csv";
        fileName = input.text;


        //TextMeshPro hack, adding random character at end of string
        if (!fileName.EndsWith(".csv"))
            fileName = fileName.Remove(fileName.Length - 1);

        path = Path.Combine(Environment
             .GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        APIResponse<EXODataSet> response = repo.ParseFile(path);


        if (response.Success)
        {
            allData = response.Result;
            parseSucess = true;
            menu1.SetActive(false);
            menu2.SetActive(true);
        }
        else
        {

            print(response.Message);
            print("noSucess");
        }    
    }
}

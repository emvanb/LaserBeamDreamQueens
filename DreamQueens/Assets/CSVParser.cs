using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class CSVParser : MonoBehaviour
{
    public TextAsset csvFile; // Reference of CSV file
    public InputField rollNoInputField;// Reference of rollno input field
    public InputField nameInputField; // Reference of name input filed
    public Text contentArea; // Reference of contentArea where records are displayed

    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = '\t'; // It defines field seperate chracter

    public List<TagParams> tParam = new List<TagParams>();

    void Start()
    {
        readData();
    }
    // Read data from CSV file
    private void readData()
    {
        string[] records = csvFile.text.Split(lineSeperater);
        foreach (string record in records)
        {
            TagParams nParam = new TagParams();


            string[] fields = record.Split(fieldSeperator);

            for (int i = 0; i < fields.Length; i++)
            {
                //TIME
                if(i==0)
                {
                    nParam.timeStamp = fields[i];
                }

                //COMMENT
                if (i == 1)
                {
                    Debug.Log("FOUND #" + fields[i].IndexOf("#", System.StringComparison.CurrentCulture));
                    string tS = fields[i].Substring(fields[i].IndexOf("#", System.StringComparison.CurrentCulture) + 1);
                    int trim = tS.IndexOf(" ", System.StringComparison.CurrentCulture);

                    nParam.content = fields[i].Substring(fields[i].IndexOf("#", System.StringComparison.CurrentCulture)+1);
                }
                //LOCATION
                if (i == 2)
                {
                    nParam.location = int.Parse(fields[i]);
                }
                //NAME
                if (i == 3)
                {
                    nParam.uName = fields[i];
                }
            }
            tParam.Add(nParam);
        }

        foreach(TagParams p in tParam)
        {
           //TagManager.tMan.PopulateTags(p);
        }
    }



    // Get path for given CSV file
    private static string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath;
#elif UNITY_ANDROID
return Application.persistentDataPath;// +fileName;
#elif UNITY_IPHONE
return GetiPhoneDocumentsPath();// +"/"+fileName;
#else
return Application.dataPath;// +"/"+ fileName;
#endif
    }
    // Get the path in iOS device
    private static string GetiPhoneDocumentsPath()
    {
        string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
        path = path.Substring(0, path.LastIndexOf('/'));
        return path + "/Documents";
    }

}
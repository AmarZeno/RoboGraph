using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Debugging : MonoBehaviour {

    public TextAsset DiagnosticFile;

    void Start()
    {
        CleanDebuggingFiles();
    }

    void Update()
    {

    }

    private void OnDestroy()
    {
       // WriteString(DiagnosticFile, speedData);
    }

    private void CleanDebuggingFiles()
    {
        WriteString(DiagnosticFile, "");
    }

    [MenuItem("Tools/Write file")]
    static void WriteString(TextAsset DiagnosticFile, string stringToWrite)
    {
        string path = AssetDatabase.GetAssetPath(DiagnosticFile);

        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(stringToWrite);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
      //  TextAsset asset = Resources.Load(path);

        //Print the text from the file
       // Debug.Log(asset.text);
    }

    public void WriteString(string stringToWrite)
    {
        string path = AssetDatabase.GetAssetPath(DiagnosticFile);

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(stringToWrite);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        //  TextAsset asset = Resources.Load(path);

        //Print the text from the file
        // Debug.Log(asset.text);
    }

    public void WriteStringToFile(TextAsset InDiagnosticFile, string stringToWrite)
    {
        string path = AssetDatabase.GetAssetPath(InDiagnosticFile);

        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(stringToWrite);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        //  TextAsset asset = Resources.Load(path);

        //Print the text from the file
        // Debug.Log(asset.text);
    }

    [MenuItem("Tools/Read file")]
    static void ReadString(TextAsset DiagnosticFile)
    {
        string path = AssetDatabase.GetAssetPath(DiagnosticFile);

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}

using System.IO;
using UnityEngine;

public class ClearingSave : MonoBehaviour
{
    public void DataCleaning()
    {
        PlayerPrefs.DeleteAll();
        if (File.Exists("lastscene.txt"))
        {
            File.Delete("lastscene.txt");
        }
    }
}

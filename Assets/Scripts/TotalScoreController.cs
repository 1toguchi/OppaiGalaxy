using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TotalScoreController : MonoBehaviour
{
    private TextAsset csvFile;

    // Use this for initialization
    void Start()
    {
        Text totalScore = GameObject.Find("TotalScore").GetComponent<Text>();

        totalScore.text = EnemyController.TotalScore.ToString();
        csvFile = Resources.Load("CSV/message") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        string input = reader.ReadToEnd();
        string[] del = {"\r\n"};
        string[] arr = input.Split(del, StringSplitOptions.None);

        GameObject.Find("Message").GetComponent<Text>().text = arr[Random.Range(0, arr.Length)];
    }
}
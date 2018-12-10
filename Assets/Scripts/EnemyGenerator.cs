using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject CircleEnemy;
    public GameObject InvadorEnemy;
    public GameObject InvadorEnemy3;
	public GameObject InvadorEnemy4;
	public GameObject InvadorEnemy5;

    private float _delta;
    private float _span = 1.0f;

    private Vector3 _respawnPosition1;
    private Vector3 _respawnPosition2;
    private Vector3 _respawnPosition3;
    private Vector3 _respawnPosition4;
    private Vector3 _respawnPosition5;

    private void Start()
    {
        _respawnPosition1 = GameObject.Find("RespawnPosition1").transform.position;
        _respawnPosition2 = GameObject.Find("RespawnPosition2").transform.position;
        _respawnPosition3 = GameObject.Find("RespawnPosition3").transform.position;
        _respawnPosition4 = GameObject.Find("RespawnPosition4").transform.position;
        _respawnPosition5 = GameObject.Find("RespawnPosition5").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy;

        _delta += Time.deltaTime;

        if (_delta >= _span)
        {
            var arr = new[] {2, 3, 4};
            var n = Random.Range(1, 4); // 1 2 3

            if (IsLastSpurt())
            {
                arr = new[] {1, 2, 3, 4, 5};
                n = Random.Range(1, 6);
				// 1 2 3 4 5

            }

            int[] randArray = arr.OrderBy(i => Guid.NewGuid()).ToArray();

            for (int i = 1; i < n; i++)
            {
                int randForEnemyType = Random.Range(0, 4); 
                enemy = ChoiceEnemyRandomly(randForEnemyType);
                var e = Instantiate(enemy, SelectRespawnPosRandomly(randArray[i]),
                    Quaternion.identity);
                GameObject emtpyObject = new GameObject();
                e.transform.parent = emtpyObject.transform;
            }

            _delta = 0.0f;
        }
    }


    private bool IsLastSpurt()
    {
        float time = GameObject.Find("Panel").GetComponent<PanelController>().Time;
        float lastSpurt = 148.0f - 30.0f; // BGMが終わる三十秒前にランダムの範囲を変更
		float _span = 0.5f;
        return time >= lastSpurt;
    }


    private Vector3 SelectRespawnPosRandomly(int randForRespawnPos)
    {
        Vector3 respawnPos;
        switch (randForRespawnPos)
        {
            case 1:
                respawnPos = _respawnPosition1;
                break;
            case 2:
                respawnPos = _respawnPosition2;
                break;
            case 3:
                respawnPos = _respawnPosition3;
                break;
            case 4:
                respawnPos = _respawnPosition4;
                break;
            case 5:
                respawnPos = _respawnPosition5;
                break;
            default:
                respawnPos = new Vector3(0, 0, 0);
                break;
        }

        return respawnPos;
    }

    private GameObject ChoiceEnemyRandomly(int randForEnemyType)
    {
        GameObject enemy;
        switch (randForEnemyType)
        {
            case 0:
                enemy = CircleEnemy;
                break;
            case 1:
                enemy = InvadorEnemy;
                break;
            case 2:                
                enemy = InvadorEnemy3;
                break;
			case 3:
			enemy = InvadorEnemy4;
			break;
			case 4:

			enemy = InvadorEnemy5;
			break;
            default:
                //todo 変えて
                enemy = InvadorEnemy;
                break;
        }

        return enemy;
    }
}
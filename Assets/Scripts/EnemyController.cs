using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public float MoveSpeed = 12.0f;
	public float FastMove = 36.0f;
    public int EnemyScore = 25;
    private GameObject ScoreText;
    public static int TotalScore = 0;
    private bool _isCollide = false;
    private bool _isRotate = false;
    private float _posX;
    private bool _transFlag = false;
    private bool _isSway = false;

    // Use this for initialization
    void Start()
    {
        ScoreText = GameObject.Find("ScoreText");
        float randomSpeed = Random.Range(3, 20);
        MoveSpeed += randomSpeed;
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            _isRotate = true;
        } else if (rand == 1)
        {
            _isSway = true;
        }

        _posX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
       transform.parent.Translate(Vector3.down * MoveSpeed * Time.deltaTime * 15.0f);

		if (_isRotate && name.Contains("CircleEnemy") && !_isCollide)
        {
            transform.RotateAround(transform.position, new Vector3(0,0,1), 10.0f);
        }

        if(!_isRotate && _isSway && name.Contains("Enemy_1") && !_isCollide) Sway();
		if(!_isRotate && _isSway && name.Contains("Enemy_3") && !_isCollide) Sway();
		if(!_isRotate && _isSway && name.Contains("Enemy_4") && !_isCollide) Sway();
		if(!_isRotate && _isSway && name.Contains("Enemy_5") && !_isCollide) Sway();
    }

    private void Sway()
    {
        float range = 50.0f;
        if (transform.position.x >= _posX + range)
        {
            _transFlag = true;
        }

        if (transform.position.x <= _posX - range)
        {
            _transFlag = false;
        }

        if (_transFlag)
        {
            transform.Translate(Vector3.left * 2);
        }
        else
        {
            transform.Translate(Vector3.right * 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oppai"))
        {
            _isCollide = true;

            GetComponent<ParticleSystem>().Play();
            TotalScore += EnemyScore;

            Text score_text = ScoreText.GetComponent<Text>();
            score_text.text = TotalScore.ToString();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1.0f);
        }
        else if (!other.CompareTag("Enemy"))
        {
        }
        else
        {
        }
    }
}
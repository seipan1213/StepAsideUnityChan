using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    public GameObject unitychan;
    private int startPos = -160;
    private int goalPos = 120;
    private float posRange = 3.4f;
    private float moto;

    // Use this for initialization
    void Start()
    {
        moto = unitychan.GetComponent<Transform>().position.z + 45;
    }

    // Update is called once per frame
    void Update()
    {
        if (unitychan.GetComponent<Transform>().position.z >= moto - 45 && moto <= goalPos) 
        {
            moto += 15;
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, moto);
                }
            }
            else
            {

                for (int j = -1; j < 2; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y,moto + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y,moto + offsetZ);
                    }
                }
            }
        }


    }
}
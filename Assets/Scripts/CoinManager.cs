using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinManager : MonoBehaviour
{
    CoinController coin;
    public List<GameObject> coinTake = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject coin in coinTake){
            coin.GetComponent<CoinController>().take = true;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstical_spwaner : MonoBehaviour
{
    [SerializeField]
    private GameObject coin_set;
    [SerializeField]
    private Transform[] obsticals_pos;
    [SerializeField]
    private GameObject[] obsticals;
    public float obstical_density = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform pos in obsticals_pos)
        {
            float rand = Random.value;
            GameObject Obs = obsticals[Random.Range(0, obsticals.Length)];
            Vector3 new_pos = new Vector3(pos.position.x, Obs.transform.position.y, pos.position.z);
            if (rand <= obstical_density)
            {
                Instantiate(Obs,new_pos,pos.rotation,transform);
            }
            else if(Random.value <= obstical_density)
            {
                Instantiate(coin_set, new_pos, coin_set.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

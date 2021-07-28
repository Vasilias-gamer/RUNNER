using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_repeat : MonoBehaviour
{
    [SerializeField]
    private GameObject platform_prefab;
    [SerializeField]
    private GameObject[] platform;
    private Vector3 next_sp = new Vector3(0,0,330);
    private float min_gap = 275;
    public GameObject last_spwaned_pf;
    public GameObject player;
    private int next_pf_index=0;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(player.transform.position, last_spwaned_pf.transform.position) < min_gap)
        {
            count++;
            if(platform_prefab.GetComponent<obstical_spwaner>().obstical_density < .8f)
                platform_prefab.GetComponent<obstical_spwaner>().obstical_density += Random.Range(0, count / 500);
            Destroy(platform[next_pf_index].gameObject);
            platform[next_pf_index] = Instantiate<GameObject>(platform_prefab, next_sp, Quaternion.identity);
            next_sp.z += 55;
            last_spwaned_pf = platform[next_pf_index++];
            next_pf_index = next_pf_index % platform.Length;
        }
    }
}

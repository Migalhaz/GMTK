using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportScript : MonoBehaviour
{
    [SerializeField] private GameObject lance;
    [SerializeField] public static bool lance_field = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (lance_field)
            {
                transform.position = lance.transform.position;

                //Destroy(lance);
                lance.SetActive(false);
                lance_field = false;
            }
        }
    }
}

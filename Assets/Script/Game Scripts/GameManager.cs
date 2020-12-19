using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.01f, 0.1f)]
    public float snowSpeed;
    float value = 0;
    void Start()
    {
        Shader.SetGlobalFloat("_SnowLevel", 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if(value <= 1f)
        {
            Shader.SetGlobalFloat("_SnowLevel", value);
            value += Time.deltaTime * snowSpeed;
        }
        
    }
}

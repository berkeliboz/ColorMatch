using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileScript : MonoBehaviour {

    private Material objectMaterial;
    public float timeModifier = 1f;
    public float timeModifier2 = 1f;


    public float timer = 2f;

    void Start()
    {
        objectMaterial = GetComponent<MeshRenderer>().materials[0];
    }

    void Update () {

        float xOffset = objectMaterial.mainTextureOffset.x + Time.deltaTime * timeModifier;
        float yOffset = objectMaterial.mainTextureOffset.y + Time.deltaTime * timeModifier2;
        Vector2 newOffset = new Vector2(xOffset, yOffset);

        if (timer <= 0)
        {
            setTextureVector(newOffset);
            timer = 2f;
            Debug.Log(newOffset);
        }

        objectMaterial.SetTextureOffset("_MainTex", newOffset);
        timer -= Time.deltaTime;



        
    }

    void setTextureVector(Vector2 vector)
    {
        if (vector.x > 0 && vector.y > 0)
            timeModifier *= -1; 
        else if (vector.x < 0 && vector.y > 0)
            timeModifier2 *= -1;
        else if (vector.x < 0 && vector.y < 0)
            timeModifier *= -1;
        else if (vector.x > 0 && vector.y < 0)
            timeModifier2 *= -1;
    }

}

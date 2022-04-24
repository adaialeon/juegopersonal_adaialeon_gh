using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
  public Transform target; 
    public Vector3 offset; 
    //vectores limitar camara x y z
    public Vector2 limitX;
    public Vector2 limitY;
    public float interpolationRatio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //posicion de la camara
        Vector3 santiPosition = target.position + offset;
        //eje horizontal
        float limitedXposition = Mathf.Clamp(santiPosition.x, limitX.x, limitX.y);
        //eje vertical
        float limitedYposition = Mathf.Clamp(santiPosition.y, limitY.x, limitY.y);
        //limites creados hacemos vector3
        Vector3 limitedPosition = new Vector3(limitedXposition, limitedYposition, santiPosition.z);
        //interpolamos la posicion de la camara (que se mueva enpplan bonito nos gusta)
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, limitedPosition, interpolationRatio);

        transform.position = lerpedPosition;
    }
}

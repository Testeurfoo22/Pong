using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDeplacementLettre : MonoBehaviour
{
    public float Vitesse = 1;
    float positionX;
    float positionY;

    Transform DepBalle;
    Rigidbody2D RBody;

    // Start is called before the first frame update
    void Awake()
    {
        DepBalle = gameObject.transform;
        RBody = gameObject.GetComponent<Rigidbody2D>();
        positionX = DepBalle.position.x;
        positionY = DepBalle.position.y;
    }
    private void OnEnable()
    {
        Vector2 vecteurPosition = new Vector2(positionX, positionY);
        DepBalle.position = vecteurPosition;
        RBody.velocity = Vector2.zero;
        float random = Random.Range(0f, 260f);
        Vector2 vecteurLettre = new Vector2(Mathf.Cos(random), Mathf.Sin(random));
        RBody.AddForce(vecteurLettre * Vitesse, ForceMode2D.Impulse);
    }
}

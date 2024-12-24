using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeBalleTexteDuo : MonoBehaviour
{
    public float Vitesse = 10;
    public int PointageFinal = 5;
    int PointageIni = 0;
    int Point;
    float Perdu = 10;

    public TextMeshPro PointageP1;
    public TextMeshPro PointageP2;
    public AudioClip SonMur;
    public AudioClip SonPlateforme;

    Transform DepBalle;
    Rigidbody2D RBody;
    AudioSource Son;

    public GameObject SceneVsHumain;
    public GameObject SceneAccueil;

    // Start is called before the first frame update
    void Awake()
    {
        DepBalle = gameObject.transform;
        RBody = gameObject.GetComponent<Rigidbody2D>();
        Son = gameObject.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        RBody.AddForce((Vector2.one) * Vitesse, ForceMode2D.Impulse);

        Point = PointageIni;
        PointageP1.text = Point.ToString();
        PointageP2.text = Point.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (DepBalle.position.x > Perdu) 
        {
            Son.Play();
            DepBalle.position = Vector2.zero;
            RBody.velocity = Vector2.zero;

            RBody.AddForce((-Vector2.one) * Vitesse, ForceMode2D.Impulse);

            Point++;
            PointageP2.text = Point.ToString();

            if (Point == PointageFinal)
            {
                SceneVsHumain.SetActive(false);
                SceneAccueil.SetActive(true);

            }
        }
        if (DepBalle.position.x < -Perdu)
        {
            Son.Play();
            DepBalle.position = Vector2.zero;
            RBody.velocity = Vector2.zero;
            RBody.AddForce((Vector2.one) * Vitesse, ForceMode2D.Impulse);

            Point++;
            PointageP1.text = Point.ToString();

            if (Point == PointageFinal)
            {
                SceneVsHumain.SetActive(false);
                SceneAccueil.SetActive(true);

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Plateforme")
        {
            Son.PlayOneShot(SonPlateforme, 0.3F);
        }
        else
        {
            Son.PlayOneShot(SonMur, 0.3F);
        }
    }
}

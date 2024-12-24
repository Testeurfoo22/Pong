using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeBalleTexte : MonoBehaviour
{
    public float Vitesse = 10;
    float VitesseJeu;
    public int PointageIni = 5;
    int Point;
    float Perdu = 10;

    public TextMeshPro Pointage;
    public AudioClip SonMur;
    public AudioClip SonPlateforme;

    Transform DepBalle;
    Rigidbody2D RBody;
    AudioSource Son;

    public GameObject SceneSolo;
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
        VitesseJeu = Vitesse;
        RBody.AddForce((Vector2.one) * VitesseJeu, ForceMode2D.Impulse);

        Point = PointageIni;
        Pointage.text = Point.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (DepBalle.position.x > Perdu)
        {
            Son.Play();
            DepBalle.position = Vector2.zero;
            RBody.velocity = Vector2.zero;
            VitesseJeu += VitesseJeu / 10;
            RBody.AddForce((-Vector2.one) * VitesseJeu, ForceMode2D.Impulse);

            Point--;
            Pointage.text = Point.ToString();

            if (Point == 0)
            {
                SceneSolo.SetActive(false);
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

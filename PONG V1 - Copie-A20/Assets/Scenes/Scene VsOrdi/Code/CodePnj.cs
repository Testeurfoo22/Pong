using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePnj : MonoBehaviour
{
    float Limite = 3.55F;

    public GameObject Balle;

    Transform DepPlateforme;

    // Start is called before the first frame update
    void Awake()
    {
        DepPlateforme = gameObject.transform;
    }

    private void OnEnable()
    {
        Vector2 DepPlateformePos = DepPlateforme.position;
        DepPlateforme.Translate(0F, (float)-DepPlateformePos.y, 0F);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 DepPlateformePos = DepPlateforme.position;

        DepPlateformePos.y = Balle.transform.position.y;

        DepPlateformePos.y = Mathf.Min(DepPlateformePos.y, Limite);
        DepPlateformePos.y = Mathf.Max(DepPlateformePos.y, -Limite);

        DepPlateforme.position = DepPlateformePos;
    }
}

using UnityEngine;
using System.Collections;

public class Colorize : MonoBehaviour {

    private HSBColor color;
    private float counter;

    [SerializeField]
    private float speed;
    [SerializeField]
    private MeshRenderer rend;
    [SerializeField]
    private Light dLight;
    


    private void Start()
    {
        color = new HSBColor(0, 1, 1, 0.5f);

    }

    private void Update()
    {

        counter += Time.deltaTime * speed;

        color.h = counter % 1f;

        Material m = rend.material;
        Color c = color.ToColor();

        dLight.color = c;
        c.a = 0.5f;
        m.color = c;
        m.SetColor("_EmissionColor", c);
        rend.material = m;
    }
}

using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Planet : MonoBehaviour 
{
	[SerializeField]
	private float maxTorque;
	private new Rigidbody2D rigidbody;

    //Longitud del drag
    [SerializeField]
    private float longitud;

    [SerializeField]
    private string fireButton;

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer;

    public GameObject particle;
    public Rigidbody rb;

    public void start()
    {
            LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
            lineRenderer.widthMultiplier = 0.2f;
            lineRenderer.numPositions = lengthOfLineRenderer;

            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
            lineRenderer.colorGradient = gradient;
    }

    private void Update()
    {
        if (lengthOfLineRenderer <= 1)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            var points = new Vector3[lengthOfLineRenderer];
            var t = Time.time;
            for (int i = 0; i < lengthOfLineRenderer; i++)
            {
                points[i] = new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f);
            }
            lineRenderer.SetPositions(points);
        }
            //Si presiono sobre el planeta llamar drag
            if (Input.GetButtonDown("fire1"))
                Drag();
    }


    private void Awake ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	private void Start () 
	{
		AddRandomTorque ();	
	}

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 10))
              print("Nuevo vector ");
    }

    private void AddRandomTorque ()
	{
		float torque = Random.Range (-maxTorque, maxTorque);
		rigidbody.AddTorque (torque);
	}

    private void Drag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        rb.AddForce(transform.forward * 500);
    }

}

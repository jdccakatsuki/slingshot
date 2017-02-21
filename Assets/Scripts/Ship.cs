using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Ship : MonoBehaviour 
{
	private new Rigidbody2D rigidbody;

	private void Awake () 
	{
		rigidbody = GetComponent<Rigidbody2D> ();	
	}

    private void update()
    {

    }
	

	private void LookTowards (Vector2 direction)
	{
		
		transform.localRotation = Quaternion.LookRotation (Vector3.forward, direction);
     
    }
}

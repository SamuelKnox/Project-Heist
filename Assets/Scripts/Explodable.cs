using UnityEngine;
using System.Collections.Generic;

/*
 * Attach to bombs to let them explode automatically (or on some signal).
 */
[RequireComponent (typeof (PolygonCollider2D))]
public class Explodable : MonoBehaviour {

	public bool automatic = true;
	public float autoTime = 3.0f;
	public float strengthPower = 1.0f;
	public float blastDiameter = 1.0f;	//area is not actually circular
	public Transform particlePrefab;
	//this field specifies the horizontal distance collider should cover

	private float mAutoTimer = 0.0f;
	private HashSet<GameObject> mSet;
	private PolygonCollider2D mCollider;

	// Use this for initialization
	void Awake () {
		mCollider = gameObject.GetComponent<PolygonCollider2D> ();
		Vector2[] points = new Vector2[4];
		points [0] = new Vector2 (1.0f, 0.0f) * blastDiameter / 2;
		points [1] = new Vector2 (0.0f, 1.0f) * blastDiameter / 4;
		points [2] = new Vector2 (-1.0f, 0.0f) * blastDiameter / 2;
		points [3] = new Vector2 (0.0f, -1.0f) * blastDiameter / 4;
		mCollider.points = points;
	}	

	void Start () {
		mSet = new HashSet<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (automatic) 
		{
			mAutoTimer += Time.deltaTime;
			if (mAutoTimer > autoTime)
				Destruct ();
		}
	}

	void Destruct() {
		foreach (GameObject obj in mSet) 
		{
			Breakable br = obj.GetComponent<Breakable>();
			if (br != null)
			{
				if (strengthPower >= br.strengthFactor)
					Destroy (obj);
			}
		}
		Vector3 position = transform.position;
		Destroy (gameObject);
		Instantiate (particlePrefab);
		particlePrefab.transform.position = position;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!mSet.Contains (other.transform.root.gameObject))
			mSet.Add (other.transform.root.gameObject);
	}

	void OnTriggerExit2D(Collider2D other) {
		if (mSet.Contains (other.transform.root.gameObject))
			mSet.Remove (other.transform.root.gameObject);
	}
}

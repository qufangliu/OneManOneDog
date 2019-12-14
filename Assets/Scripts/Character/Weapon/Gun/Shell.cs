using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

    public Rigidbody myRightbody;
    public float forceMin;
    public float forceMax;

    float lifetime = 4;
    float fadetime = 2;

	// Use this for initialization
	void Start () {
        float force = Random.Range(forceMin,forceMax);
        myRightbody.AddForce(transform.right*force);
        myRightbody.AddTorque(Random.insideUnitSphere * force);
        StartCoroutine(nameof(Fade));
	}
	
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(lifetime);
        float percent = 0;
        float fadeSpeed = 1 / fadetime;
        Material mat = GetComponent<Renderer>().material;
        Color initialColour = mat.color;

        while(percent < 1){
            percent += Time.deltaTime * fadeSpeed;
            mat.color = Color.Lerp(initialColour, Color.clear, percent);
            yield return null;
        }
        Destroy(gameObject);
    }
}

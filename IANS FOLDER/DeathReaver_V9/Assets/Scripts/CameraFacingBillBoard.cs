using UnityEngine;
using System.Collections;

public class CameraFacingBillBoard : MonoBehaviour 
{
	private Camera m_Camera;
	//public GameObject cc;
	//private Camera mainCam;

	// Use this for initialization
	void Start () 
	{
		m_Camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.back,
		                 m_Camera.transform.rotation * Vector3.up);


	}
}

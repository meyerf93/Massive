using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAtom : MonoBehaviour
{
    
	public GameObject Atom;
	public float rotateSpeed;
  
    // Update is called once per frame
    void Update()
    {
		Atom.transform.Rotate(rotateSpeed* Time.deltaTime, rotateSpeed * Time.deltaTime, rotateSpeed * Time.deltaTime); 

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CardInteraction : MonoBehaviour
{
	public GameObject Proton;
	public GameObject Neutron;
	public GameObject Up_Quark;
	public GameObject Down_Quark;
	public GameObject Strong_Force;
	public GameObject Weak_Positive_Force;

	public GameObject Proton_prefabs;
	public GameObject Neutron_prefabs;

	private GameObject[] go_raw;
	private Model model;
	private ConfigScene config;

	private Card Proton_card;
	private Card Neutron_card;
	private Card Up_Quark_card;
	private Card Down_Quark_card;
	private Card Strong_Force_card;
	private Card Weak_Positive_Force_card;

    private Vector2[] go_points;
    private GameObject[] go_n;

    private LineRenderer lineRenderer;
    private MeshFilter filter;

	private List<Card> temp_card_list;
	private List<GameObject> temp_list_gameObject;

	private GameObject temp_atom_strong_force;


    // Start is called before the first frame update
    void Start()
    {
        model = FindObjectOfType<Model>();
        config = model.GetConfigScene();

		lineRenderer = gameObject.GetComponent<LineRenderer>();
        filter = gameObject.GetComponent<MeshFilter>();

        Proton_card = config.Cards.Find(r => r.Name == Proton.name);
        Neutron_card = config.Cards.Find(r => r.Name == Neutron.name);
        Up_Quark_card = config.Cards.Find(r => r.Name == Up_Quark.name);
        Down_Quark_card = config.Cards.Find(r => r.Name == Down_Quark.name);
        Strong_Force_card = config.Cards.Find(r => r.Name == Strong_Force.name);
		Weak_Positive_Force_card = config.Cards.Find(r => r.Name == Weak_Positive_Force.name);


		temp_card_list = new List<Card>();
		temp_card_list.Add(Proton_card);
		temp_card_list.Add(Neutron_card);
		temp_card_list.Add(Up_Quark_card);
		temp_card_list.Add(Down_Quark_card);
		temp_card_list.Add(Strong_Force_card);
		temp_card_list.Add(Weak_Positive_Force_card);

		temp_list_gameObject = new List<GameObject>();
		temp_list_gameObject.Add(Up_Quark);
		temp_list_gameObject.Add(Down_Quark);
		temp_list_gameObject.Add(Strong_Force);


    }

    // Update is called once per frame
    void Update()
    {



		bool temp_visible = Weak_Positive_Force_card.isTracked;
		foreach(Card card in temp_card_list)
		{
			if(card.isTracked)
			{
				card.uiIsVisible = temp_visible;
			}
		}

		lineRenderer.enabled = false;
        
		if(Up_Quark_card.isTracked && Down_Quark_card.isTracked && Strong_Force_card.isTracked)
		{
			getAllAvailablePoints();
            drawLines();
            

			Debug.Log("J'ai détecter la création d'un proton ou d'un neutron");
		}
		else if (Up_Quark_card.isTracked && Down_Quark_card.isTracked 
		    || Up_Quark_card.isTracked && Strong_Force_card.isTracked 
		    || Down_Quark_card.isTracked && Strong_Force_card.isTracked)
        {
			getAllAvailablePoints();
            drawLines();
            Debug.Log("bonjour, j'ai détecter une combinaison");
        }
        else if (Down_Quark_card.isTracked)
        {
            Debug.Log("j'ai détecter un Down Quark");
        }
        else if (Up_Quark_card.isTracked)
        {
            Debug.Log("j'ai détecter un Up Quark");
        }
    }

    private void getAllAvailablePoints()
    {
        // Create new Vector2 and Text Lists
        List<Vector2> vertices2DList = new List<Vector2>();
        List<GameObject> oList = new List<GameObject>();

		foreach(Card element in temp_card_list)
		{
			if(element.isTracked)
			{
				GameObject temp_gameObj = temp_list_gameObject.Find(r => r.name == element.Name);

				vertices2DList.Add(new Vector2(temp_gameObj.transform.position.x, temp_gameObj.transform.position.y));
				oList.Add(temp_gameObj);
			}
		}

        // Convert to array
        go_points = vertices2DList.ToArray();
        go_n = oList.ToArray();
    }

    // Draw Mesh for Mesh Filter
    private void draw()
    {
        // Create Vector2 vertices
        Vector2[] vertices2D = go_points;

        // Use the triangulator to get indices for creating triangles
        Triangulator tr = new Triangulator(vertices2D);
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[vertices2D.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(go_n[i].transform.position.x, go_n[i].transform.position.y, go_n[i].transform.position.z);
        }

        // Create the mesh
        Mesh msh = new Mesh();
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.RecalculateNormals();
        msh.RecalculateBounds();

        // Set up game object with mesh;
        filter.mesh = msh;
    }

    // Draw Lines for Line Renderer
    private void drawLines()
    {
		lineRenderer.enabled = true;
        // Set positions size
        lineRenderer.positionCount = go_points.Length;

        // Set all line psitions
        for (int i = 0; i < go_points.Length; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(go_n[i].transform.position.x, go_n[i].transform.position.y, go_n[i].transform.position.z));
        }
    }
}
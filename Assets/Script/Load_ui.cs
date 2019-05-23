﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Load_ui : MonoBehaviour
{
	private ImageTargetBehaviour target;
	private Model model;

	public Text Titre;
	public Text Description;
	public Text Build;
	public Text Attack;
	public Text Defense;

    // Start is called before the first frame update
    void Start()
    {
		model = FindObjectOfType<Model>();
		target = GetComponent<Vuforia.ImageTargetBehaviour>();
        
		ConfigScene temp_conf = model.GetConfigScene();

		Debug.Log("Name : " + target.name);
		Card temp_card = temp_conf.Cards.Find(r => r.Name == target.name);

		displayUI(temp_card);
        
    }

	void displayUI(Card temp_card)
	{
		string temp_titre = temp_card.Name.Replace('_', ' ');
		Debug.Log("temp titre : " + temp_titre);
		Titre.text = temp_titre;
        Description.text = temp_card.Description;

        string temp_build = "Build : \r";

        foreach (InteractionElement element in temp_card.Characteristics.Build.Interactions)
        {
            temp_build += element.Name.Replace('_', ' ') + " : \r" + element.Description;
        }

        Build.text = temp_build;

        string temp_attack = "Attack : \r";

        foreach (InteractionElement element in temp_card.Characteristics.Attack.Interactions)
        {
            temp_attack += element.Name.Replace('_', ' ') + " : \r" + element.Description;
        }

        Attack.text = temp_attack;

        string temp_defense = "Defense : \r";

        foreach (InteractionElement element in temp_card.Characteristics.Defense.Interactions)
        {
            temp_defense += element.Name.Replace('_', ' ') + " : \r" + element.Description;
        }

        Defense.text = temp_defense;
    }
}

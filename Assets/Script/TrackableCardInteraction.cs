using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableCardInteraction : MonoBehaviour,ITrackableEventHandler
{   
    private TrackableBehaviour mTrackableBehaviour;
	private Model model;
	private ConfigScene config;
	private Card actual_card;
	private string Card_Name;

    void Start()
    {
		model = FindObjectOfType<Model>();
		Card_Name = name;

		config = model.GetConfigScene();
		actual_card = config.Cards.Find(r => r.Name == Card_Name);

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
			// Play audio when target is found
			actual_card.isTracked = true;
        }
        else
        {
            // Stop audio when target is lost
			actual_card.isTracked = false;
        }
    }
    
}

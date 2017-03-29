/**
 * SerialCommUnity (Serial Communication for Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

/**
 * Sample for reading using polling by yourself. In case you are fond of that.
 */
public class SampleUserPolling_JustRead : MonoBehaviour
{
    public SerialController serialController;

	public float speed0 = 1.0f; //vitese de référence
	private float speed = 1.0f; //Vitesse de déplacement effective
	private string messageprec = ""; //ici on stocke le message précédent pour les fonctions d'accélération en fn du temps
	private float t0 = 0.0f; //Stockera l'heure du début de l'action

    // Initialisation
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

	}

    // On exécute ne FixedUpdate pour avoir une vitesse de déplacement constante
    void FixedUpdate()
    {
        //On mémorise la direction du regard et la position du HMD dans l'EV
		Vector3 direction = GameObject.Find("CenterEyeAnchor").transform.forward;
        Vector3 temp = GameObject.Find("LMHeadMountedRig").transform.position;

        //On lit le message envoyé par Arduino
        string message = serialController.ReadSerialMessage();

		float deltatemps = 0.0f;//On stock la durée de l'action

        if (message == null)
            return;

        // On vérifie qu'on est bien connecté
		if (ReferenceEquals (message, SerialController.SERIAL_DEVICE_CONNECTED))
			Debug.Log ("Connection established");
		else if (ReferenceEquals (message, SerialController.SERIAL_DEVICE_DISCONNECTED))
			Debug.Log ("Connection attempt failed or disconnection detected");
		else {
            //Si le message change (et qu'on change donc de direction de déplacement, on réinitiliase 'deltatemp', la vitesse et on met à jour t0
			if (message != messageprec) {
				Debug.Log ("changement");
				deltatemps = 0.0f;
				t0 = Time.time;
				speed = 1.0f * speed0;
			}
            //Si on reste sur la même action, on vérifie la durée de l'ction et on met à jour la vitesse
			if (message == messageprec) {
				deltatemps = Time.time - t0;
				if (deltatemps > 3.0f && deltatemps < 6.0f) {
					speed = 2.0f * speed0;
				}
				if (deltatemps > 6.0f) {
					speed = 5.0f * speed0;
				}
			}

            //Selon le message, on se sert de la vitesse calculée pour se déplacer dans les différentes directions
			if (message == "avant") {
				temp.x += direction.x*speed;
				temp.z += direction.z*speed;
				GameObject.Find ("LMHeadMountedRig").transform.position = temp;
			}
			if (message == "arriere") {
				temp.x -= direction.x*speed;
				temp.z -= direction.z*speed;
				GameObject.Find ("LMHeadMountedRig").transform.position = temp;
			}
			if (message == "droite") {
				temp.x += direction.z*speed;
				temp.z -= direction.x*speed;
				GameObject.Find ("LMHeadMountedRig").transform.position = temp;
			}
			if (message == "gauche") {
				temp.x -= direction.z*speed;
				temp.z += direction.x*speed;
				GameObject.Find ("LMHeadMountedRig").transform.position = temp;
			}
			if (message == "haut") {
				temp.y += 1.0f*speed;
				GameObject.Find ("LMHeadMountedRig").transform.position = temp;
			}
			if (message == "bas") {
				temp.y -= 1.0f*speed;
				GameObject.Find ("LMHeadMountedRig").transform.position = temp;
			}

			messageprec = message;
		}
    }
}

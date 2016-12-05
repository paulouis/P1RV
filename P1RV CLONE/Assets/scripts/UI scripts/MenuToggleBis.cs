using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Leap.Unity.InputModule {
  public class MenuToggleBis : MonoBehaviour {
		public string MenuName;
	    public UnityEngine.UI.Image image;
		public Material OnMaterial; 
		public Material OffMaterial;
		public GameObject Menu;
		public GameObject PinchDraw;
		public Toggle ToggleObj;
		public Toggle ToggleEdit;
		public Toggle ToggleDraw;

	    public void SetToggle(Toggle toggle) {
			switch (MenuName){
			case "Objet":
				if (toggle.isOn) {
					
					image.material = OnMaterial;
					Menu.SetActive (true);
					ToggleEdit.isOn = false;
					ToggleDraw.isOn = false; 
				
				} 
				else {
					image.material = OffMaterial;
					Menu.SetActive (false);
				}
				break;
			case "Edit":
				if (toggle.isOn) {
					
					image.material = OnMaterial;
					Menu.SetActive (true);
					ToggleObj.isOn = false;
					ToggleDraw.isOn = false; 
				} 
				else {
					image.material = OffMaterial;
					Menu.SetActive (false);
				}
				break;

			case "Draw":
				if (toggle.isOn) {
					
					image.material = OnMaterial;
					Menu.SetActive (true);
					ToggleEdit.isOn = false;
					ToggleObj.isOn = false; 
					PinchDraw.SetActive (true);
				} else {
					image.material = OffMaterial;
					Menu.SetActive (false);
					PinchDraw.SetActive (false);
				}
				break;
				}
	  }
	}
}
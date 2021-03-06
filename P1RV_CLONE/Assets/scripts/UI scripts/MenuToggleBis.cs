using UnityEngine;
using UnityEngine.UI;
using System.Collections;
// permet de basculer entre les différents menus, ce script est attaché à chaque bouton du menu principal
// il active et désactive les fonctinnalités associées aux trois menus Objet,Edition,Dessin
namespace Leap.Unity.InputModule {
  public class MenuToggleBis : MonoBehaviour {
		public string MenuName;
	    public UnityEngine.UI.Image image;
		public Material OnMaterial; // colorer le bouton en rouge si il est actif
		public Material OffMaterial;
		public GameObject Menu;
		public GameObject PinchDraw; // objet activant le dessin PinchDraw
		public Toggle ToggleObj; // scripts des boutons associés aux trois menus
		public Toggle ToggleEdit;
		public Toggle ToggleDraw;

	    public void SetToggle(Toggle toggle) {
			switch (MenuName){
			case "Objet": // le script est le même pour chaque bouton et on fait un switch selon le type de menu
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
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Leap.Unity.InputModule {
  public class MenuToggle : MonoBehaviour {
		public string MenuName;
	    public UnityEngine.UI.Image imageObj;
		public UnityEngine.UI.Image imageEdit;
		public UnityEngine.UI.Image imageDraw;
		public Material OnMaterial; 
		public Material OffMaterial;
		public GameObject MenuObj;
		public GameObject MenuEdit;
		public GameObject MenuDraw; 

	    public void SetToggle(Toggle toggle) {
			switch (MenuName){
			case "Objet":
				if (toggle.isOn) {
					Debug.Log ("prout");
					imageObj.material = OnMaterial;
					imageEdit.material = OffMaterial;
					imageDraw.material = OffMaterial;

					MenuObj.SetActive (true);
					MenuEdit.SetActive (false);
					MenuDraw.SetActive (false);
				} else if (!toggle.isOn) {

					imageObj.material = OffMaterial;
					//imageEdit.material = OffMaterial;
					MenuObj.SetActive (false);	
					//MenuEdit.SetActive (false);

				}
				break;
			case "Edit":
				if (toggle.isOn) {

					imageObj.material = OffMaterial;
					imageEdit.material = OnMaterial;
					imageDraw.material = OffMaterial;

					MenuObj.SetActive (false);
					MenuEdit.SetActive (true);
					MenuDraw.SetActive (false);
				} else if (!toggle.isOn) {

					//imageObj.material = OffMaterial;
					imageEdit.material = OffMaterial;
					//MenuObj.SetActive (false);	
					MenuEdit.SetActive (false);

				}
				break;

			case "Draw":
				if (toggle.isOn) {

					imageObj.material = OffMaterial;
					imageEdit.material = OffMaterial;
					imageDraw.material = OnMaterial;

					MenuObj.SetActive (false);
					MenuEdit.SetActive (false);
					MenuDraw.SetActive (true);
				} else if (!toggle.isOn) {

					//imageObj.material = OffMaterial;
					imageDraw.material = OffMaterial;
					//MenuObj.SetActive (false);	
					MenuDraw.SetActive (false);

				}
				break;

				}
	  }
	}
}
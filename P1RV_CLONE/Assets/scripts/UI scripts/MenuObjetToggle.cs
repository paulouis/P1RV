using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Leap.Unity.InputModule {
  public class MenuObjetToggle : MonoBehaviour {
    public UnityEngine.UI.Image imageObj;
	public UnityEngine.UI.Image imageEdit;
	public Material OnMaterial; 
	public Material OffMaterial;
	public GameObject MenuObj;
	public GameObject MenuEdit;
    public void SetToggle(Toggle toggle) {
      if (toggle.isOn) {
        		
				imageObj.material = OnMaterial; 
				imageEdit.material = OffMaterial; 
				MenuObj.SetActive (true);
				MenuEdit.SetActive (false);
      } 
			else {

				imageObj.material = OffMaterial;
				imageEdit.material = OffMaterial; 
				MenuObj.SetActive (false);	
				MenuEdit.SetActive (false);
		
      }
    }
  }
}
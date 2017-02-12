using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Leap.Unity.InputModule {
  public class AddCube : MonoBehaviour {
    public UnityEngine.UI.Image image;
		public InstanceObjet script ; 
    public void SetToggle(Toggle toggle) {
      if (toggle.isOn) {
				script.Creer ();
      } else {
		
      }
    }
  }
}
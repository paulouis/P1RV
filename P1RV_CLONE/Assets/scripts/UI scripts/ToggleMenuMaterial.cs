﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Leap.Unity.InputModule
{
    public class ToggleMenuMaterial : MonoBehaviour
    {
        public UnityEngine.UI.Image image;
        public Material OnMaterial;
        public Material OffMaterial;
        public GameObject Menu;

        public void SetToggle(Toggle toggle)
        {
            if (toggle.isOn)
            {

                image.material = OnMaterial;
                Menu.SetActive(true);
                GameObject.Find("FeaturesManager").GetComponent<Edit>().SetMaterial = true;
            }
            else
            {
                image.material = OffMaterial;
                Menu.SetActive(false);
                GameObject.Find("FeaturesManager").GetComponent<Edit>().SetMaterial = false;
            }

        }
    }
}
﻿using UnityEngine;

namespace Leap.Unity
{

	/// <summary>
	/// Use this component on a Game Object to allow it to be manipulated by a pinch gesture.  The component
	/// allows rotation, translation, and scale of the object (RTS).
	/// </summary>
	public class LeapRTS_Prefab : MonoBehaviour
	{
		//Ajouter directement les PinchPoint au Script LeapRTS
		//****************************************************//
		private GameObject PinchLeft;
		private PinchDetector PinchLeftDetector;
		private GameObject PinchRight;
		private PinchDetector PinchRightDetector;
		//******************************************************//
		// Gérer les différentes méthodes d'interaction (rotate, scale ...)
		public GameObject FeatureM;
		public Edit FeatureMScript;

		/// /////////////////
	
		public enum RotationMethod
		{
			None,
			Single,
			Full
		}

		[SerializeField]
		private PinchDetector _pinchDetectorA;

		public PinchDetector PinchDetectorA
		{
			get
			{
				return _pinchDetectorA;
			}
			set
			{
				_pinchDetectorA = value;
			}
		}

		[SerializeField]
		private PinchDetector _pinchDetectorB;

		public PinchDetector PinchDetectorB
		{
			get
			{
				return _pinchDetectorB;
			}
			set
			{
				_pinchDetectorB = value;
			}
		}

		[SerializeField]
		private RotationMethod _oneHandedRotationMethod;

		[SerializeField]
		private RotationMethod _twoHandedRotationMethod;

		[SerializeField]
		private bool _allowScale = true;
		
		[Header("GUI Options")]
		[SerializeField]
		private KeyCode _toggleGuiState = KeyCode.None;

		[SerializeField]
		private bool _showGUI = true;

		private Transform _anchor;

		private float _defaultNearClip;
	
		//assigner les PinchLeft et PinchRight
		void Awake()
		{
			//Find pinchDetector Left and set it to the _pinchDetectorA variable
			PinchLeft = GameObject.Find("HandAttachments_Left/PinchPoint_L");
			PinchLeftDetector = PinchLeft.GetComponent<PinchDetector>();
			_pinchDetectorA = PinchLeftDetector;

			//Find pinchDetector Right and set it to the _pinchDetectorB variable
			PinchRight = GameObject.Find("HandAttachments_Right/PinchPoint_R");
			PinchRightDetector = PinchRight.GetComponent<PinchDetector>();
			_pinchDetectorB = PinchRightDetector;


			//If the pinch detectors have not been set, do not enable script;
			if (_pinchDetectorA == null || _pinchDetectorB == null)
			{
				Debug.LogWarning("Both Pinch Detectors of the LeapRTS component must be assigned. This component has been disabled.");
				enabled = false;
			}
		}

		void Start()
		{
			// on crée un GameObject "ancre" qui va être parent de notre objet à manipuler. Ensuite on effecute
			// les transformations sur ce Gameobjet "ancre" et par lien de parenté, l'objet est manipulé
			// on ne peut pas modifier directement l'objet manipl
			GameObject pinchControl = new GameObject("RTS Anchor");
			_anchor = pinchControl.transform;
			//_anchor.transform.parent = transform.parent;
			transform.parent = _anchor;
			FeatureM = GameObject.Find("FeaturesManager");
			FeatureMScript = FeatureM.GetComponent<Edit>();
		}

		void Update()
		{
			_allowScale = FeatureMScript.IsScaling; 
			//
			if (Input.GetKeyDown(_toggleGuiState))
			{
				_showGUI = !_showGUI;
			}

			bool didUpdate = false;
			if (_pinchDetectorA != null)
				didUpdate |= _pinchDetectorA.DidChangeFromLastFrame;
			if (_pinchDetectorB != null)
				didUpdate |= _pinchDetectorB.DidChangeFromLastFrame;

			if (didUpdate)
			{
				transform.SetParent(null, true);
			}

			if (_pinchDetectorA != null && _pinchDetectorA.IsActive &&
			    _pinchDetectorB != null && _pinchDetectorB.IsActive)
			{
				transformDoubleAnchor(); // méthode de manipulation à deux mains lorsque les deux mains sont actives
			}
			else if (_pinchDetectorA != null && _pinchDetectorA.IsActive)
			{
				transformSingleAnchor(_pinchDetectorA); // méthode de manipulation à une main si une seule main est active dans la scène
			}
			else if (_pinchDetectorB != null && _pinchDetectorB.IsActive)
			{
				transformSingleAnchor(_pinchDetectorB); // méthode de manipulation à une main si une seule main est active dans la scène
			}

			if (didUpdate)
			{
				transform.SetParent(_anchor, true);
			}
		}

		void OnGUI()
		{
			if (_showGUI)
			{
				GUILayout.Label("One Handed Settings");
				doRotationMethodGUI(ref _oneHandedRotationMethod);
				GUILayout.Label("Two Handed Settings");
				doRotationMethodGUI(ref _twoHandedRotationMethod);
				_allowScale = GUILayout.Toggle(_allowScale, "Allow Two Handed Scale");
			}
		}

		private void doRotationMethodGUI(ref RotationMethod rotationMethod)
		{
			GUILayout.BeginHorizontal();

			GUI.color = rotationMethod == RotationMethod.None ? Color.green : Color.white;
			if (GUILayout.Button("No Rotation"))
			{
				rotationMethod = RotationMethod.None;
			}

			GUI.color = rotationMethod == RotationMethod.Single ? Color.green : Color.white;
			if (GUILayout.Button("Single Axis"))
			{
				rotationMethod = RotationMethod.Single;
			}

			GUI.color = rotationMethod == RotationMethod.Full ? Color.green : Color.white;
			if (GUILayout.Button("Full Rotation"))
			{
				rotationMethod = RotationMethod.Full;
			}

			GUI.color = Color.white;

			GUILayout.EndHorizontal();
		}

		private void transformDoubleAnchor()
		{
			_anchor.position = (_pinchDetectorA.Position + _pinchDetectorB.Position) / 2.0f;


			if (FeatureMScript.IsRotating)
			{
				//// Méthode de Rotation

				Quaternion pp = Quaternion.Lerp(_pinchDetectorA.Rotation, _pinchDetectorB.Rotation, 0.5f);
				////// On freeze la translation /////// 

				Vector3 u = pp * Vector3.up;

				_anchor.LookAt(_pinchDetectorA.Position, u);
			}

			if (FeatureMScript.IsScaling)
			{
				_anchor.localScale = Vector3.one * Vector3.Distance(_pinchDetectorA.Position, _pinchDetectorB.Position);
			}
		}

		private void transformSingleAnchor(PinchDetector singlePinch)
		{
			_anchor.position = singlePinch.Position;

			switch (_oneHandedRotationMethod)
			{
				case RotationMethod.None:
					break;
				case RotationMethod.Single:
					Vector3 p = singlePinch.Rotation * Vector3.right;
					p.y = _anchor.position.y;
					_anchor.LookAt(p);
					break;
				case RotationMethod.Full:
					_anchor.rotation = singlePinch.Rotation;
					break;
			}

			_anchor.localScale = Vector3.one;
		}
	}
}

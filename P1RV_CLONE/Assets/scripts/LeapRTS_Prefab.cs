using UnityEngine;


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
            //Find pinchDetector Left and set it to the _pinchDetectorA variable
            PinchLeft = GameObject.Find("RigidRoundHand_L/PinchPointAlt_L");
            PinchLeftDetector = PinchLeft.GetComponent<PinchDetector>();
            _pinchDetectorA = PinchLeftDetector;

            //Find pinchDetector Right and set it to the _pinchDetectorB variable
            PinchRight = GameObject.Find("RigidRoundHand_R/PinchPointAlt_R");
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

            GameObject pinchControl = new GameObject("RTS Anchor");
            _anchor = pinchControl.transform;
            _anchor.transform.parent = transform.parent;
            transform.parent = _anchor;
            FeatureM = GameObject.Find("FeaturesManager");
            FeatureMScript = FeatureM.GetComponent<Edit>();
        }

        void Update()
        {
            ////////////////////////////////////////
            _allowScale = FeatureMScript.IsScaling;
            ///
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
                transformDoubleAnchor();
            }
            else if (_pinchDetectorA != null && _pinchDetectorA.IsActive)
            {
                transformSingleAnchor(_pinchDetectorA);
            }
            else if (_pinchDetectorB != null && _pinchDetectorB.IsActive)
            {
                transformSingleAnchor(_pinchDetectorB);
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
            /*
      switch (_twoHandedRotationMethod) {
        case RotationMethod.None:
          break;
        case RotationMethod.Single:
         // Vector3 p = _pinchDetectorA.Position;
         // p.y = _anchor.position.y;
         // _anchor.LookAt(p);
          break;
            case RotationMethod.Full:
                //// Méthode de Rotation

                    Quaternion pp = Quaternion.Lerp (_pinchDetectorA.Rotation, _pinchDetectorB.Rotation, 0.5f);
                    ////// On freeze la translation ///////

                    Vector3 u = pp * Vector3.up;
                    _anchor.LookAt (_pinchDetectorA.Position, u);

          break;
      }
*/

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




//
//
//
//
//
//
//
//namespace Leap.Unity
//{
//
//    /// <summary>
//    /// Use this component on a Game Object to allow it to be manipulated by a pinch gesture.  The component
//    /// allows rotation, translation, and scale of the object (RTS).
//    /// </summary>
//    public class LeapRTS_Prefab : MonoBehaviour
//    {
//        //Ajouter directement les PinchPoint au Script LeapRTS
//        //****************************************************//
//        private GameObject PinchLeft;
//        private PinchDetector PinchLeftDetector;
//        private GameObject PinchRight;
//        private PinchDetector PinchRightDetector;
//        //******************************************************//
//        // Gérer les différentes méthodes d'interaction (rotate, scale ...)
//        public GameObject FeatureM;
//        public Edit FeatureMScript;
//
//        /// /////////////////
//        public Vector3 OffsetPosA;
//        // Offset de position entre la main et l'objet
//        public Vector3 OffsetPosB;
//        public Quaternion OffsetRot;
//        public float OffsetScale;
//        private bool ResetOffsetA;
//        private bool ResetOffsetB;
//        private bool ResetOffsetRot;
//        private bool ResetOffsetScale;
//
//        /// ////////////
//        public Quaternion CurrentRot;
//
//        public enum RotationMethod
//        {
//            None,
//            Single,
//            Full
//        }
//
//        [SerializeField]
//        private PinchDetector _pinchDetectorA;
//
//        public PinchDetector PinchDetectorA
//        {
//            get
//            {
//                return _pinchDetectorA;
//            }
//            set
//            {
//                _pinchDetectorA = value;
//            }
//        }
//
//        [SerializeField]
//        private PinchDetector _pinchDetectorB;
//
//        public PinchDetector PinchDetectorB
//        {
//            get
//            {
//                return _pinchDetectorB;
//            }
//            set
//            {
//                _pinchDetectorB = value;
//            }
//        }
//
//        [SerializeField]
//        private RotationMethod _oneHandedRotationMethod;
//
//        [SerializeField]
//        private RotationMethod _twoHandedRotationMethod;
//
//        [SerializeField]
//        private bool _allowScale = true;
//
//        [Header("GUI Options")]
//        [SerializeField]
//        private KeyCode _toggleGuiState = KeyCode.None;
//
//        [SerializeField]
//        private bool _showGUI = true;
//
//        private Transform _anchor;
//
//        private float _defaultNearClip;
//
//        //assigner les PinchLeft et PinchRight
//        void Awake()
//        {
//            //Find pinchDetector Left and set it to the _pinchDetectorA variable
//            PinchLeft = GameObject.Find("RigidRoundHand_L/PinchPointAlt_L");
//            PinchLeftDetector = PinchLeft.GetComponent<PinchDetector>();
//            _pinchDetectorA = PinchLeftDetector;
//
//            //Find pinchDetector Right and set it to the _pinchDetectorB variable
//            PinchRight = GameObject.Find("RigidRoundHand_R/PinchPointAlt_R");
//            PinchRightDetector = PinchRight.GetComponent<PinchDetector>();
//            _pinchDetectorB = PinchRightDetector;
//
//
//            //If the pinch detectors have not been set, do not enable script;
//            if (_pinchDetectorA == null || _pinchDetectorB == null)
//            {
//                Debug.LogWarning("Both Pinch Detectors of the LeapRTS component must be assigned. This component has been disabled.");
//                enabled = false;
//            }
//        }
//
//        void Start()
//        {
//            // on crée un GameObject "ancre" qui va être parent de notre objet à manipuler. Ensuite on effecute
//            // les transformations sur ce Gameobjet "ancre" et par lien de parenté, l'objet est manipulé
//            // on ne peut pas modifier directement l'objet manipl
////            GameObject pinchControl = new GameObject("RTS Anchor");
////            _anchor = pinchControl.transform;
////            _anchor.transform.parent = transform.parent;
////            transform.parent = _anchor;
//            FeatureM = GameObject.Find("FeaturesManager");
//            FeatureMScript = FeatureM.GetComponent<Edit>();
//            OffsetPosA = new Vector3(0f, 0f, 0f); // Offset de position entre la main et l'objet
//            OffsetPosB = new Vector3(0f, 0f, 0f);
//            OffsetRot = Quaternion.identity;
//            OffsetScale = 1f;
//            ResetOffsetA = false;  // booléen de remise à zéro de l'offset lorsque l'on ne manipule plus
//            ResetOffsetB = false;
//            ResetOffsetRot = false;
//            ResetOffsetScale = false;
//
//            CurrentRot = Quaternion.identity;
//        }
//
//        /// //////////////////////////////DEBUT DE LA BOUCLE UPDATE////////////////////////////////
//
//        void Update()
//        {
//            _allowScale = FeatureMScript.IsScaling;
//            //
//            if (Input.GetKeyDown(_toggleGuiState))
//            {
//                _showGUI = !_showGUI;
//            }
//
//
//
//            bool didUpdate = false;
//            if (_pinchDetectorA != null)
//                didUpdate |= _pinchDetectorA.DidChangeFromLastFrame;
//            if (_pinchDetectorB != null)
//                didUpdate |= _pinchDetectorB.DidChangeFromLastFrame;
//
//
////////////////////////////////// GESTION DES OFFSETS ENTRE MAINS ET OBJET MANIPULE//////////////////////////
//            if (_pinchDetectorA != null && _pinchDetectorA.IsActive && !ResetOffsetA)
//            {
//                OffsetPosA = transform.position - _pinchDetectorA.Position;
//                ResetOffsetA = true;
//                // transform.SetParent(null, true);
//            }
//            if ((_pinchDetectorA == null || !_pinchDetectorA.IsActive) && ResetOffsetA)
//            {
//                OffsetPosA = new Vector3(0f, 0f, 0f);
//                ResetOffsetA = false;
//            }
//
//            if (_pinchDetectorB != null && _pinchDetectorB.IsActive && !ResetOffsetB)
//            {
//                OffsetPosB = transform.position - _pinchDetectorB.Position;
//                ResetOffsetB = true;
//                // transform.SetParent(null, true);
//            }
//            if ((_pinchDetectorB == null || !_pinchDetectorB.IsActive) && ResetOffsetB)
//            {
//                OffsetPosB = new Vector3(0f, 0f, 0f);
//                ResetOffsetB = false;
//            }
//
//            if (_pinchDetectorA != null && _pinchDetectorA.IsActive && _pinchDetectorB != null && _pinchDetectorB.IsActive && !ResetOffsetRot)
//            {
//                OffsetRot = transform.rotation * Quaternion.FromToRotation(_pinchDetectorA.transform.right, _pinchDetectorB.transform.right);
//                OffsetScale = Vector3.Distance(_pinchDetectorA.Position, _pinchDetectorB.Position);
//                ResetOffsetRot = true;
//                ResetOffsetScale = true;
//                CurrentRot = Quaternion.Lerp(_pinchDetectorA.Rotation, _pinchDetectorB.Rotation, 0.5f);
//
//                // transform.SetParent(null, true);
//            }
//            if ((_pinchDetectorA == null || !_pinchDetectorA.IsActive || _pinchDetectorB == null || !_pinchDetectorB.IsActive) && ResetOffsetRot)
//            {
//                OffsetRot = Quaternion.identity;
//                OffsetScale = 1f;
//                ResetOffsetRot = false;
//                ResetOffsetScale = false;
//            }
//
//            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//            ///////////////////////////////ACTIVER LES METHODES SELON LES PINCHS ACTIFS (DEUX MAINS OU UNE MAIN)///////////////////////////////
//            if (_pinchDetectorA != null && _pinchDetectorA.IsActive &&
//                _pinchDetectorB != null && _pinchDetectorB.IsActive)
//            {
//                transformDoubleAnchor(); // méthode de manipulation à deux mains lorsque les deux mains sont actives
//            }
//            else if (_pinchDetectorA != null && _pinchDetectorA.IsActive)
//            {
//                transformSingleAnchor(_pinchDetectorA, 'A'); // méthode de manipulation à une main si une seule main est active dans la scène
//            }
//            else if (_pinchDetectorB != null && _pinchDetectorB.IsActive)
//            {
//                transformSingleAnchor(_pinchDetectorB, 'B'); // méthode de manipulation à une main si une seule main est active dans la scène
//            }
//            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//            if (didUpdate)
//            {
//                //transform.SetParent(_anchor, true);
//            }
//        }
//
//        /// ////////////FIN DE L'UPDATE////////////////////////////////////////////////////////////
//
//        void OnGUI()
//        {
//            if (_showGUI)
//            {
//                GUILayout.Label("One Handed Settings");
//                doRotationMethodGUI(ref _oneHandedRotationMethod);
//                GUILayout.Label("Two Handed Settings");
//                doRotationMethodGUI(ref _twoHandedRotationMethod);
//                _allowScale = GUILayout.Toggle(_allowScale, "Allow Two Handed Scale");
//            }
//        }
//
//        private void doRotationMethodGUI(ref RotationMethod rotationMethod)
//        {
//            GUILayout.BeginHorizontal();
//
//            GUI.color = rotationMethod == RotationMethod.None ? Color.green : Color.white;
//            if (GUILayout.Button("No Rotation"))
//            {
//                rotationMethod = RotationMethod.None;
//            }
//
//            GUI.color = rotationMethod == RotationMethod.Single ? Color.green : Color.white;
//            if (GUILayout.Button("Single Axis"))
//            {
//                rotationMethod = RotationMethod.Single;
//            }
//
//            GUI.color = rotationMethod == RotationMethod.Full ? Color.green : Color.white;
//            if (GUILayout.Button("Full Rotation"))
//            {
//                rotationMethod = RotationMethod.Full;
//            }
//
//            GUI.color = Color.white;
//
//            GUILayout.EndHorizontal();
//        }
//
//        private void transformDoubleAnchor()
//        {
//            //_anchor.position = (_pinchDetectorA.Position + _pinchDetectorB.Position) / 2.0f;
//            transform.position = (_pinchDetectorA.Position + OffsetPosA + OffsetPosB + _pinchDetectorB.Position) / 2.0f;
//
//
//            if (FeatureMScript.IsRotating)
//            {
//
//
//                //// Méthode de Rotation
//                Quaternion pp1 = Quaternion.FromToRotation(_pinchDetectorA.transform.right, _pinchDetectorB.transform.right) * OffsetRot;
//                Quaternion pp = Quaternion.Slerp(_pinchDetectorA.Rotation, _pinchDetectorB.Rotation, 0.5f) * OffsetRot;
//                ////// On freeze la translation ///////
//
//                Vector3 u = pp * Vector3.up;
//                Vector3 u1 = pp1 * Vector3.up;
//
//                //_anchor.LookAt(_pinchDetectorA.Position);
//                transform.LookAt(_pinchDetectorA.Position, u1);
//                CurrentRot = Quaternion.Lerp(_pinchDetectorA.Rotation, _pinchDetectorB.Rotation, 0.5f);
//            }
//
//            if (FeatureMScript.IsScaling)
//            {
//
//                //_anchor.localScale = Vector3.one * Vector3.Distance(_pinchDetectorA.Position, _pinchDetectorB.Position);
//                transform.localScale = Vector3.one * (Vector3.Distance(_pinchDetectorA.Position, _pinchDetectorB.Position) / OffsetScale);
//            }
//        }
//
//        private void transformSingleAnchor(PinchDetector singlePinch, char PinchID)
//        {
//            //_anchor.position = singlePinch.Position;
//            if (PinchID == 'A')
//            {
//                transform.position = singlePinch.Position + OffsetPosA;
//            }
//            else
//            {
//                transform.position = singlePinch.Position + OffsetPosB;
//            }
//            switch (_oneHandedRotationMethod)
//            {
//                case RotationMethod.None:
//                    break;
//                case RotationMethod.Single:
//                    Vector3 p = singlePinch.Rotation * Vector3.right;
//                    p.y = _anchor.position.y;
//                    _anchor.LookAt(p);
//                    break;
//                case RotationMethod.Full:
//                    _anchor.rotation = singlePinch.Rotation;
//                    break;
//            }
//
//            //  _anchor.localScale = Vector3.one;
//        }
//    }
//}

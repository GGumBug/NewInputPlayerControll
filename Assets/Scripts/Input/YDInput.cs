//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Input/YDInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @YDInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @YDInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""YDInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""81be5b70-b37c-40eb-aeb6-54cc66f8d603"",
            ""actions"": [
                {
                    ""name"": ""MoveDestPos"",
                    ""type"": ""Value"",
                    ""id"": ""8cfe151e-79c3-4542-a36b-035e29fbe48b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""b22d206b-a6c1-4cb6-99e8-412a3ebadfc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e49e8b9-30bd-4816-93d3-666a57e22638"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDestPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57a3a501-6f8b-423f-8c91-05470d6b7ca7"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDestPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""301f7dad-95ab-4bd4-aed6-7566fd7d94a3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1d623d8-8e67-4deb-aaff-52e4721b3620"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""5a787c94-7b9c-457e-976f-e5258a2b6e96"",
            ""actions"": [
                {
                    ""name"": ""CameraRotation"",
                    ""type"": ""Value"",
                    ""id"": ""0bfd0ed3-f3ff-4c94-bb64-706d3360ee9b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""a0360432-f317-4322-b081-5c4b02aaa973"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch0Pos"",
                    ""type"": ""Value"",
                    ""id"": ""b748b080-7d15-4036-aeaf-dff41abefb78"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch1Pos"",
                    ""type"": ""Value"",
                    ""id"": ""dbaa2821-112c-4f8c-8358-1c2408438f97"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch0Press"",
                    ""type"": ""Button"",
                    ""id"": ""92b3fdc2-1cf0-4a5a-8965-d654e473aaf3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Touch1Press"",
                    ""type"": ""Button"",
                    ""id"": ""4e241cda-4494-41f3-b526-d322880c694d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef8a7025-a2a5-4a47-9969-19f9975c0992"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69f8b405-b676-4b2e-b4c5-1c813abb8a4c"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60cdb592-0a30-406a-8415-3ddf9ad288a4"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41b2dcbe-2df2-4604-b058-637bd6cc886d"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch0Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a3d732d-b8a2-4e94-a264-f080599c8880"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch1Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e010755-c669-43cb-82fc-6f7a4381c46e"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch0Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01695de1-5b2e-41c5-80aa-a77a1bc9413a"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch1Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MoveDestPos = m_Player.FindAction("MoveDestPos", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_CameraRotation = m_Camera.FindAction("CameraRotation", throwIfNotFound: true);
        m_Camera_Zoom = m_Camera.FindAction("Zoom", throwIfNotFound: true);
        m_Camera_Touch0Pos = m_Camera.FindAction("Touch0Pos", throwIfNotFound: true);
        m_Camera_Touch1Pos = m_Camera.FindAction("Touch1Pos", throwIfNotFound: true);
        m_Camera_Touch0Press = m_Camera.FindAction("Touch0Press", throwIfNotFound: true);
        m_Camera_Touch1Press = m_Camera.FindAction("Touch1Press", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_MoveDestPos;
    private readonly InputAction m_Player_Move;
    public struct PlayerActions
    {
        private @YDInput m_Wrapper;
        public PlayerActions(@YDInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveDestPos => m_Wrapper.m_Player_MoveDestPos;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @MoveDestPos.started += instance.OnMoveDestPos;
            @MoveDestPos.performed += instance.OnMoveDestPos;
            @MoveDestPos.canceled += instance.OnMoveDestPos;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @MoveDestPos.started -= instance.OnMoveDestPos;
            @MoveDestPos.performed -= instance.OnMoveDestPos;
            @MoveDestPos.canceled -= instance.OnMoveDestPos;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();
    private readonly InputAction m_Camera_CameraRotation;
    private readonly InputAction m_Camera_Zoom;
    private readonly InputAction m_Camera_Touch0Pos;
    private readonly InputAction m_Camera_Touch1Pos;
    private readonly InputAction m_Camera_Touch0Press;
    private readonly InputAction m_Camera_Touch1Press;
    public struct CameraActions
    {
        private @YDInput m_Wrapper;
        public CameraActions(@YDInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraRotation => m_Wrapper.m_Camera_CameraRotation;
        public InputAction @Zoom => m_Wrapper.m_Camera_Zoom;
        public InputAction @Touch0Pos => m_Wrapper.m_Camera_Touch0Pos;
        public InputAction @Touch1Pos => m_Wrapper.m_Camera_Touch1Pos;
        public InputAction @Touch0Press => m_Wrapper.m_Camera_Touch0Press;
        public InputAction @Touch1Press => m_Wrapper.m_Camera_Touch1Press;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void AddCallbacks(ICameraActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
            @CameraRotation.started += instance.OnCameraRotation;
            @CameraRotation.performed += instance.OnCameraRotation;
            @CameraRotation.canceled += instance.OnCameraRotation;
            @Zoom.started += instance.OnZoom;
            @Zoom.performed += instance.OnZoom;
            @Zoom.canceled += instance.OnZoom;
            @Touch0Pos.started += instance.OnTouch0Pos;
            @Touch0Pos.performed += instance.OnTouch0Pos;
            @Touch0Pos.canceled += instance.OnTouch0Pos;
            @Touch1Pos.started += instance.OnTouch1Pos;
            @Touch1Pos.performed += instance.OnTouch1Pos;
            @Touch1Pos.canceled += instance.OnTouch1Pos;
            @Touch0Press.started += instance.OnTouch0Press;
            @Touch0Press.performed += instance.OnTouch0Press;
            @Touch0Press.canceled += instance.OnTouch0Press;
            @Touch1Press.started += instance.OnTouch1Press;
            @Touch1Press.performed += instance.OnTouch1Press;
            @Touch1Press.canceled += instance.OnTouch1Press;
        }

        private void UnregisterCallbacks(ICameraActions instance)
        {
            @CameraRotation.started -= instance.OnCameraRotation;
            @CameraRotation.performed -= instance.OnCameraRotation;
            @CameraRotation.canceled -= instance.OnCameraRotation;
            @Zoom.started -= instance.OnZoom;
            @Zoom.performed -= instance.OnZoom;
            @Zoom.canceled -= instance.OnZoom;
            @Touch0Pos.started -= instance.OnTouch0Pos;
            @Touch0Pos.performed -= instance.OnTouch0Pos;
            @Touch0Pos.canceled -= instance.OnTouch0Pos;
            @Touch1Pos.started -= instance.OnTouch1Pos;
            @Touch1Pos.performed -= instance.OnTouch1Pos;
            @Touch1Pos.canceled -= instance.OnTouch1Pos;
            @Touch0Press.started -= instance.OnTouch0Press;
            @Touch0Press.performed -= instance.OnTouch0Press;
            @Touch0Press.canceled -= instance.OnTouch0Press;
            @Touch1Press.started -= instance.OnTouch1Press;
            @Touch1Press.performed -= instance.OnTouch1Press;
            @Touch1Press.canceled -= instance.OnTouch1Press;
        }

        public void RemoveCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface IPlayerActions
    {
        void OnMoveDestPos(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnCameraRotation(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnTouch0Pos(InputAction.CallbackContext context);
        void OnTouch1Pos(InputAction.CallbackContext context);
        void OnTouch0Press(InputAction.CallbackContext context);
        void OnTouch1Press(InputAction.CallbackContext context);
    }
}

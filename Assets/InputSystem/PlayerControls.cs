// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""6d95c801-aa94-4f1f-9d14-471a79293af4"",
            ""actions"": [
                {
                    ""name"": ""1"",
                    ""type"": ""Value"",
                    ""id"": ""5fe0c063-f4d0-42a5-a5b5-756685b07806"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""2"",
                    ""type"": ""Button"",
                    ""id"": ""16efd2a2-1156-41c0-95bb-647dd2cbc71c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""3"",
                    ""type"": ""Button"",
                    ""id"": ""0422a497-588f-4687-817d-8a7678c1279f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""4"",
                    ""type"": ""Button"",
                    ""id"": ""b509092a-df58-4b15-a868-af16db9ec402"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""5"",
                    ""type"": ""Button"",
                    ""id"": ""d9731244-d234-40d5-9b79-bb6deb3a1833"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""6"",
                    ""type"": ""Button"",
                    ""id"": ""d9499796-218e-4cdd-ac1a-851f64bb1e5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""7"",
                    ""type"": ""Button"",
                    ""id"": ""615d7ed2-a35c-4cbc-b1cf-36200bdbe2bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""8"",
                    ""type"": ""Button"",
                    ""id"": ""06426b07-f037-49ac-ac2e-1025bfc70eb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""9"",
                    ""type"": ""Button"",
                    ""id"": ""90b9f79b-1b41-4941-8262-a38515f4312d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f6fae97f-5850-4811-9873-13257228c797"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2887856-8dbf-4c2a-91dd-1b68b0d7ea64"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4b925dc-cad4-4e95-b7fc-e684525e154d"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eba933e5-41e7-4ad1-bdde-1865323e1a1d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ad69493-4cad-4817-8b01-285eaef42b87"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b324370-2cce-49c1-bca6-42aa0de655e7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7994dbde-b8b9-4720-8115-0d8c41f9ddf2"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f937322b-34b2-4219-a5d4-3cd3240eab3d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c52ba0bc-cae9-44b4-ad22-2a2b6086b936"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25a8e76f-2eac-4a11-bcff-94a8dd89f5ec"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16744901-0e3e-4f0a-8760-a914ffdeeb6c"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87452d4d-4a31-4d9a-9901-b373313a5513"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e4c818b-0dc9-4a02-9c84-550ee2e5334e"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cd227af-7ed0-4c8a-80ca-498888a5f6af"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""9"",
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
        m_Player__1 = m_Player.FindAction("1", throwIfNotFound: true);
        m_Player__2 = m_Player.FindAction("2", throwIfNotFound: true);
        m_Player__3 = m_Player.FindAction("3", throwIfNotFound: true);
        m_Player__4 = m_Player.FindAction("4", throwIfNotFound: true);
        m_Player__5 = m_Player.FindAction("5", throwIfNotFound: true);
        m_Player__6 = m_Player.FindAction("6", throwIfNotFound: true);
        m_Player__7 = m_Player.FindAction("7", throwIfNotFound: true);
        m_Player__8 = m_Player.FindAction("8", throwIfNotFound: true);
        m_Player__9 = m_Player.FindAction("9", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player__1;
    private readonly InputAction m_Player__2;
    private readonly InputAction m_Player__3;
    private readonly InputAction m_Player__4;
    private readonly InputAction m_Player__5;
    private readonly InputAction m_Player__6;
    private readonly InputAction m_Player__7;
    private readonly InputAction m_Player__8;
    private readonly InputAction m_Player__9;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @_1 => m_Wrapper.m_Player__1;
        public InputAction @_2 => m_Wrapper.m_Player__2;
        public InputAction @_3 => m_Wrapper.m_Player__3;
        public InputAction @_4 => m_Wrapper.m_Player__4;
        public InputAction @_5 => m_Wrapper.m_Player__5;
        public InputAction @_6 => m_Wrapper.m_Player__6;
        public InputAction @_7 => m_Wrapper.m_Player__7;
        public InputAction @_8 => m_Wrapper.m_Player__8;
        public InputAction @_9 => m_Wrapper.m_Player__9;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @_1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_1;
                @_1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_1;
                @_1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_1;
                @_2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_2;
                @_2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_2;
                @_2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_2;
                @_3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_3;
                @_3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_3;
                @_3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_3;
                @_4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_4;
                @_4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_4;
                @_4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_4;
                @_5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_5;
                @_5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_5;
                @_5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_5;
                @_6.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_6;
                @_6.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_6;
                @_6.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_6;
                @_7.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_7;
                @_7.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_7;
                @_7.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_7;
                @_8.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_8;
                @_8.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_8;
                @_8.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_8;
                @_9.started -= m_Wrapper.m_PlayerActionsCallbackInterface.On_9;
                @_9.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.On_9;
                @_9.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.On_9;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @_1.started += instance.On_1;
                @_1.performed += instance.On_1;
                @_1.canceled += instance.On_1;
                @_2.started += instance.On_2;
                @_2.performed += instance.On_2;
                @_2.canceled += instance.On_2;
                @_3.started += instance.On_3;
                @_3.performed += instance.On_3;
                @_3.canceled += instance.On_3;
                @_4.started += instance.On_4;
                @_4.performed += instance.On_4;
                @_4.canceled += instance.On_4;
                @_5.started += instance.On_5;
                @_5.performed += instance.On_5;
                @_5.canceled += instance.On_5;
                @_6.started += instance.On_6;
                @_6.performed += instance.On_6;
                @_6.canceled += instance.On_6;
                @_7.started += instance.On_7;
                @_7.performed += instance.On_7;
                @_7.canceled += instance.On_7;
                @_8.started += instance.On_8;
                @_8.performed += instance.On_8;
                @_8.canceled += instance.On_8;
                @_9.started += instance.On_9;
                @_9.performed += instance.On_9;
                @_9.canceled += instance.On_9;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void On_1(InputAction.CallbackContext context);
        void On_2(InputAction.CallbackContext context);
        void On_3(InputAction.CallbackContext context);
        void On_4(InputAction.CallbackContext context);
        void On_5(InputAction.CallbackContext context);
        void On_6(InputAction.CallbackContext context);
        void On_7(InputAction.CallbackContext context);
        void On_8(InputAction.CallbackContext context);
        void On_9(InputAction.CallbackContext context);
    }
}

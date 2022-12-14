//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Controlls/InputControlls.inputactions
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

public partial class @InputControlls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControlls"",
    ""maps"": [
        {
            ""name"": ""Click"",
            ""id"": ""f927692a-b08e-432c-bb7d-44179bac8748"",
            ""actions"": [
                {
                    ""name"": ""Clear"",
                    ""type"": ""Button"",
                    ""id"": ""1cb1bd0b-8391-404e-a16d-7637154187f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""725d72f5-e96b-4632-ad4c-de530746a95c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""80ec5bfa-cdeb-4dbd-8591-5af8c88a3e43"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d92a03c-6e4b-4c46-a0e9-439363b58f13"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Movement"",
            ""id"": ""39042c1e-b3a6-4a42-a8e7-559233a55f8a"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""e432efcf-1c7e-4f8e-b42c-13184fe933bf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""6ebcd63b-957d-4668-acfb-9e3a0b2ed0f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DeltaX"",
                    ""type"": ""Value"",
                    ""id"": ""56613f45-b545-4aa4-a587-93f05a4f233a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DeltaY"",
                    ""type"": ""Value"",
                    ""id"": ""75a99cb9-1603-4ef1-b72a-487ade2111ac"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""717e45bc-e16a-4738-aa1c-144167b9fd0e"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c392fc43-6e37-483f-9586-7534475dd58c"",
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
                    ""id"": ""29c14d37-4090-476b-909a-ed240491b753"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeltaX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""677d3c4e-a08c-45b6-945e-de5fbe204b58"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DeltaY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Click
        m_Click = asset.FindActionMap("Click", throwIfNotFound: true);
        m_Click_Clear = m_Click.FindAction("Clear", throwIfNotFound: true);
        m_Click_Select = m_Click.FindAction("Select", throwIfNotFound: true);
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Rotate = m_Movement.FindAction("Rotate", throwIfNotFound: true);
        m_Movement_Zoom = m_Movement.FindAction("Zoom", throwIfNotFound: true);
        m_Movement_DeltaX = m_Movement.FindAction("DeltaX", throwIfNotFound: true);
        m_Movement_DeltaY = m_Movement.FindAction("DeltaY", throwIfNotFound: true);
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

    // Click
    private readonly InputActionMap m_Click;
    private IClickActions m_ClickActionsCallbackInterface;
    private readonly InputAction m_Click_Clear;
    private readonly InputAction m_Click_Select;
    public struct ClickActions
    {
        private @InputControlls m_Wrapper;
        public ClickActions(@InputControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Clear => m_Wrapper.m_Click_Clear;
        public InputAction @Select => m_Wrapper.m_Click_Select;
        public InputActionMap Get() { return m_Wrapper.m_Click; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClickActions set) { return set.Get(); }
        public void SetCallbacks(IClickActions instance)
        {
            if (m_Wrapper.m_ClickActionsCallbackInterface != null)
            {
                @Clear.started -= m_Wrapper.m_ClickActionsCallbackInterface.OnClear;
                @Clear.performed -= m_Wrapper.m_ClickActionsCallbackInterface.OnClear;
                @Clear.canceled -= m_Wrapper.m_ClickActionsCallbackInterface.OnClear;
                @Select.started -= m_Wrapper.m_ClickActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_ClickActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_ClickActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_ClickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Clear.started += instance.OnClear;
                @Clear.performed += instance.OnClear;
                @Clear.canceled += instance.OnClear;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public ClickActions @Click => new ClickActions(this);

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Rotate;
    private readonly InputAction m_Movement_Zoom;
    private readonly InputAction m_Movement_DeltaX;
    private readonly InputAction m_Movement_DeltaY;
    public struct MovementActions
    {
        private @InputControlls m_Wrapper;
        public MovementActions(@InputControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Movement_Rotate;
        public InputAction @Zoom => m_Wrapper.m_Movement_Zoom;
        public InputAction @DeltaX => m_Wrapper.m_Movement_DeltaX;
        public InputAction @DeltaY => m_Wrapper.m_Movement_DeltaY;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnRotate;
                @Zoom.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnZoom;
                @DeltaX.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDeltaX;
                @DeltaX.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDeltaX;
                @DeltaX.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDeltaX;
                @DeltaY.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDeltaY;
                @DeltaY.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDeltaY;
                @DeltaY.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDeltaY;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @DeltaX.started += instance.OnDeltaX;
                @DeltaX.performed += instance.OnDeltaX;
                @DeltaX.canceled += instance.OnDeltaX;
                @DeltaY.started += instance.OnDeltaY;
                @DeltaY.performed += instance.OnDeltaY;
                @DeltaY.canceled += instance.OnDeltaY;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IClickActions
    {
        void OnClear(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IMovementActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnDeltaX(InputAction.CallbackContext context);
        void OnDeltaY(InputAction.CallbackContext context);
    }
}

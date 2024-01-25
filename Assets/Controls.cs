// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""3a380596-135e-458b-bd67-686996f09654"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9cd13d76-03b8-43eb-9de9-f299ac4ad1d2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""a75da7f5-6572-4f25-b552-74730db25c23"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""df4b3a6b-b628-4b2a-87af-2263cdea7ca5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""29d9794c-fb54-4e69-bb25-94056d36dbef"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9d0faeb5-9cc1-43ec-b5c3-1ae090a7fb7e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""526a3dae-df60-4855-af2c-afe427372970"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e397cf14-9373-461f-83c0-68d20fd4eb55"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""662fa480-5129-44ba-a44a-ad49cbf1f26f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""98d0a163-6042-4ddc-977b-b13297d3604c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab10e5d3-5c01-44ae-a961-35c2398179d8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Aiming = m_Gameplay.FindAction("Aiming", throwIfNotFound: true);
        m_Gameplay_Shooting = m_Gameplay.FindAction("Shooting", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Aiming;
    private readonly InputAction m_Gameplay_Shooting;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Aiming => m_Wrapper.m_Gameplay_Aiming;
        public InputAction @Shooting => m_Wrapper.m_Gameplay_Shooting;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Aiming.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAiming;
                @Shooting.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShooting;
                @Shooting.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShooting;
                @Shooting.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShooting;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @Shooting.started += instance.OnShooting;
                @Shooting.performed += instance.OnShooting;
                @Shooting.canceled += instance.OnShooting;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnShooting(InputAction.CallbackContext context);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFly : MonoBehaviour
{
    public float m_vertSpeed = 1f;
    public float m_hortSpeed = 1f;
    public float m_liftSpeed = 1f;

    private PlayerControls m_system;
    private GameObject m_camera;

    private bool m_wHeld;
    private bool m_aHeld;
    private bool m_sHeld;
    private bool m_dHeld;
    private bool m_spaceHeld;
    private bool m_shiftHeld;

    private void OnEnable()
    {
        m_system.Enable();
    }

    private void OnDisable()
    {
        m_system.Disable();
    }

    private void Awake()
    {
        m_system = new PlayerControls();
        m_system.Camera.W.performed += ctx => m_wHeld = true;
        m_system.Camera.A.performed += ctx => m_aHeld = true;
        m_system.Camera.S.performed += ctx => m_sHeld = true;
        m_system.Camera.D.performed += ctx => m_dHeld = true;

        m_system.Camera.Space.performed += ctx => m_spaceHeld = true;
        m_system.Camera.Shift.performed += ctx => m_shiftHeld = true;

        m_system.Camera.W.canceled += ctx => m_wHeld = false;
        m_system.Camera.A.canceled += ctx => m_aHeld = false;
        m_system.Camera.S.canceled += ctx => m_sHeld = false;
        m_system.Camera.D.canceled += ctx => m_dHeld = false;

        m_system.Camera.Space.canceled += ctx => m_spaceHeld = false;
        m_system.Camera.Shift.canceled += ctx => m_shiftHeld = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_camera = gameObject;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        HandleW();
        HandleA();
        HandleS();
        HandleD();
        HandleSpace();
        HandleShift();
    }

    private void HandleW()
    {
        if (m_wHeld)
        {
            m_camera.transform.Translate(m_vertSpeed * Time.deltaTime * transform.forward);
        }
    }

    private void HandleA()
    {
        if (m_aHeld)
        {
            m_camera.transform.Translate(m_hortSpeed * Time.deltaTime * -transform.right);
        }
    }

    private void HandleS()
    {
        if (m_sHeld)
        {
            m_camera.transform.Translate(m_vertSpeed * Time.deltaTime * -transform.forward);
        }
    }

    private void HandleD()
    {
        if (m_dHeld)
        {
            m_camera.transform.Translate(m_hortSpeed * Time.deltaTime * transform.right);
        }
    }

    private void HandleSpace()
    {
        if (m_spaceHeld)
        {
            m_camera.transform.Translate(m_liftSpeed * Time.deltaTime * transform.up);
        }
    }

    private void HandleShift() 
    {
        if (m_shiftHeld) 
        {
            m_camera.transform.Translate(m_liftSpeed * Time.deltaTime * -transform.up);
        }
    }
}

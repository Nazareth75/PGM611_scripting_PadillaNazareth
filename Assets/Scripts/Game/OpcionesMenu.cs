using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpcionesMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelOpciones;
    private GameObject seleccionAnterior;

    public void vamosAjugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void AbrirOpciones()
    {
        if (panelOpciones == null) return;
        if (EventSystem.current != null)
            seleccionAnterior = EventSystem.current.currentSelectedGameObject;
        panelOpciones.SetActive(true);
        var cerrar = panelOpciones.GetComponentInChildren<Button>();
        if (cerrar != null && EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(cerrar.gameObject);
    }

    public void CerrarOpciones()
    {
        if (panelOpciones == null) return;
        panelOpciones.SetActive(false);
        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(seleccionAnterior);
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

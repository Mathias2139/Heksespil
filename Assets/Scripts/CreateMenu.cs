using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using MA.Events;
using UnityEngine.UI;

public class CreateMenu : MonoBehaviour
{
    [MenuItem("GameObject/ Heksespil/Minigame",false,10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject ui = new GameObject("Custom UI Object");
        GameObject go = new GameObject("Custom Game Object");
        

        // Add custom Components
        Minigame minigame = go.AddComponent<Minigame>();
        IntListener listener = go.AddComponent<IntListener>();
        Canvas canvas = ui.AddComponent<Canvas>();
        CanvasScaler canvasScaler = ui.AddComponent<CanvasScaler>();
        

        //Assign default values for Components & name Gameobject
        go.gameObject.name = "New Minigame";
        ui.gameObject.name = "Minigame UI";
        minigame.minigameName = "Minigame navn her!";
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
        canvas.planeDistance = 7;
        canvas.sortingOrder = 1;

        //Parent UI to minigame
        ui.transform.SetParent(go.transform);
       
        

        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system

        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}

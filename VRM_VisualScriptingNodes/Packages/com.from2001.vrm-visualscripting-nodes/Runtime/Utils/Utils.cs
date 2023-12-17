using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;
using System.Collections.Generic;

namespace VisualScriptingNodes
{
    public class Utils : MonoBehaviour
    {
        /// <summary>
        /// Return true if current OS is VisionOS.
        /// </summary>
        /// <returns></returns>
        public static bool IsVisionOS()
        {
            //When operatingSystem is "visionOS", return true
            if (SystemInfo.operatingSystem.Contains("visionOS")) return true;
            if (Application.platform == RuntimePlatform.VisionOS) return true;
#if UNITY_VISIONOS
            return true;
#else
            return false;
#endif
        }

        /// <summary>
        /// Return all GameObjects in scene.
        /// </summary>
        /// <returns></returns>
        public static List<GameObject> GetAllObjectsInScene()
        {
            List<GameObject> objectsInScene = new List<GameObject>();
            foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
            {
                objectsInScene.Add(obj);
                GetChildObjects(obj, ref objectsInScene);
            }
            return objectsInScene;

            static void GetChildObjects(GameObject obj, ref List<GameObject> objectsInScene)
            {
                foreach (Transform child in obj.transform)
                {
                    objectsInScene.Add(child.gameObject);
                    GetChildObjects(child.gameObject, ref objectsInScene);
                }
            }
        }

        /// <summary>
        /// Change all shaders of GameObject to new one.
        /// This method is intended to be used for VRM and glTF models on VisionOS.
        /// </summary>
        /// <param name="targetObject"></param>
        /// <param name="newShader">"Universal Render Pipeline/Unlit", "Universal Render Pipeline/Lit", etc.</param>
        /// <param name="texturePropertyName_old">Set "_MainTex" for Built-in shader</param>
        /// <param name="texturePropertyName_new">Set "_BaseMap" for URP Shader</param>
        public static void ChangeShadersWithTexture(GameObject targetObject, string newShader = "Universal Render Pipeline/Unlit", string texturePropertyName_old = "_MainTex", string texturePropertyName_new = "_BaseMap")
        {
            SkinnedMeshRenderer[] skinedMeshrenderers = targetObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer renderer in skinedMeshrenderers) foreach (Material mat in renderer.materials) ChangeShader(mat, newShader);

            MeshRenderer[] meshrenderers = targetObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in meshrenderers) foreach (Material mat in renderer.materials) ChangeShader(mat, newShader);

            void ChangeShader(Material mat, string shaderName)
            {
                if (mat.HasProperty(texturePropertyName_old))
                {
                    Texture texture = mat.GetTexture(texturePropertyName_old);
                    mat.shader = Shader.Find(shaderName);
                    mat.SetTexture(texturePropertyName_new, texture);
                }
                else
                {
                    mat.shader = Shader.Find(newShader);
                }
            }
        }

        /// <summary>
        /// Change all URP/MToon10 shaders of GameObject to URP/Unlit.
        /// This method is intended to be used for VRM models on VisionOS.
        /// </summary>
        /// <param name="targetObject"></param>
        public static void ChangeMtoon10ShaderToUnlitOfGameobject(GameObject targetObject)
        {
            SkinnedMeshRenderer[] skinedMeshrenderers = targetObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer renderer in skinedMeshrenderers) foreach (Material mat in renderer.materials) ChangeMToon10ShaderToUnlit(mat);

            MeshRenderer[] meshrenderers = targetObject.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in meshrenderers) foreach (Material mat in renderer.materials) ChangeMToon10ShaderToUnlit(mat);
        }

        /// <summary>
        /// Change URP/MToon10 shader to URP/Unlit shader.
        /// </summary>
        /// <param name="mat_original"></param>
        static void ChangeMToon10ShaderToUnlit(Material mat_original)
        {
            if (mat_original.shader.name != "VRM10/Universal Render Pipeline/MToon10")
            {
                return; // Exit if the shader is not MToon10
            }

            // Create a temporary copy of the material to extract properties
            Material tempMat = new(mat_original);

            // Create a new material with the Unlit shader
            Material newMat = new(Shader.Find("Universal Render Pipeline/Unlit"));

            // Change the shader
            newMat.shader = Shader.Find("Universal Render Pipeline/Unlit");

            // Transfer texture and color properties
            if (tempMat.HasProperty("_MainTex") && newMat.HasProperty("_BaseMap"))
            {
                newMat.SetTexture("_BaseMap", tempMat.GetTexture("_MainTex"));
            }
            if (tempMat.HasProperty("_Color") && newMat.HasProperty("_BaseColor"))
            {
                newMat.SetColor("_BaseColor", tempMat.GetColor("_Color"));
            }

            // Transfer alpha cutoff property
            if (tempMat.HasProperty("_Cutoff"))
            {
                newMat.SetFloat("_Cutoff", tempMat.GetFloat("_Cutoff"));
            }

            // Handle Surface Type (Opaque/Transparent)
            bool isTransparent = tempMat.GetFloat("_AlphaMode") > 0 || tempMat.GetFloat("_TransparentWithZWrite") > 0;
            if (isTransparent)
            {
                newMat.SetFloat("_Surface", 1.0f); // Set to Transparent
                newMat.SetFloat("_AlphaClip", 1.0f); // Enable Alpha Clipping
            }
            else
            {
                newMat.SetFloat("_Surface", 0.0f); // Set to Opaque
                newMat.SetFloat("_AlphaClip", 0.0f); // Disable Alpha Clipping
            }

            // Set blend modes for transparent materials
            if (isTransparent)
            {
                newMat.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
                newMat.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                newMat.SetFloat("_ZWrite", 0.0f); // Typically, ZWrite is off for transparent materials
            }

            // Dispose of the temporary material
            UnityEngine.Object.DestroyImmediate(tempMat);

            // Additional blend mode settings can be adjusted here if needed

            // Apply the new material
            mat_original = newMat;
        }


    }
}
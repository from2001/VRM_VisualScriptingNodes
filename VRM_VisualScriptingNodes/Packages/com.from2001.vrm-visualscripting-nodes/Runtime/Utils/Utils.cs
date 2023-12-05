using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace VisualScriptingNodes
{
    public class Utils : MonoBehaviour
    {
        static public int addTest(int a, int b)
        {
            return a + b;
        }



        public static Shader GetShaderForErrorReplacement(string shaderType = "Unlit")
        {
            Shader retShader = null;
            retShader = shaderType switch
            {
                "Unlit" => Shader.Find(GraphicsSettings.currentRenderPipeline is UniversalRenderPipelineAsset
                                 ? "Universal Render Pipeline/Unlit" : "Unlit/Texture"),
                "Lit" => Shader.Find(GraphicsSettings.currentRenderPipeline is UniversalRenderPipelineAsset
                                 ? "Universal Render Pipeline/Lit" : "Standard"),
                _ => Shader.Find(GraphicsSettings.currentRenderPipeline is UniversalRenderPipelineAsset
                                 ? "Universal Render Pipeline/Unlit" : "Unlit/Texture"),
            };
            return retShader;
        }


        // GameObjectとその子孫のマテリアルのシェーダーを再帰的に置き換えるヘルパーメソッド
        public static void ReplaceErrorShaders(GameObject obj, Shader replacementShader)
        {
            if (obj.TryGetComponent<Renderer>(out var renderer))
            {
                foreach (Material mat in renderer.materials)
                {
                    //if (mat.shader == null || Shader.Find(mat.shader.name) == null)
                    //{
                    mat.shader = replacementShader;
                    //}
                }
            }

            // 子GameObjectに対しても同じ処理を行う
            foreach (Transform child in obj.transform)
            {
                ReplaceErrorShaders(child.gameObject, replacementShader);
            }
        }




    }
}
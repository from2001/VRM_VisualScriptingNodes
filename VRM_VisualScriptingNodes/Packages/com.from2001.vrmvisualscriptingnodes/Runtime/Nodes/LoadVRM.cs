using UnityEngine;
using Unity.VisualScripting;
using UniVRM10;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace VrmVisualScriptingNodes
{
    [UnitShortTitle("Load VRM")]
    [UnitTitle("Load VRM")]
    [UnitCategory("VRM")]
    [UnitSubtitle("Load VRM with URL")]
    public class LoadVRM : Unit
    {
        [DoNotSerialize]
        public ControlInput inputTrigger;

        [DoNotSerialize]
        public ControlOutput outputTrigger;

        [DoNotSerialize]
        public ValueInput VrmURL;

        [DoNotSerialize]
        public ValueOutput result;

        private Vrm10Instance resultValue;
        protected override void Definition()
        {
            inputTrigger = ControlInput("inputTrigger", Enter);
            outputTrigger = ControlOutput("outputTrigger");

            VrmURL = ValueInput<string>("VrmURL", "https://test.psychic-vr-lab.com/temp/temp.vrm");
            result = ValueOutput<Vrm10Instance>("result", (flow) => resultValue);
        }

        private ControlOutput Enter(Flow flow)
        {
            string url = flow.GetValue<string>(VrmURL);
            Vrm10Instance vrmInstance = null;
            UniTask.Create(async () =>
            {
                vrmInstance = await LoadVrm(url);
                Debug.Log(vrmInstance.Vrm.Meta.Name);
            }
            ).Forget();
            resultValue = vrmInstance;
            return outputTrigger;
        }

        /// <summary>
        /// Load VRM from URL
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        private async UniTask<Vrm10Instance> LoadVrm(string URL)
        {
            byte[] VrmBytes = null;
            UnityWebRequest request = UnityWebRequest.Get(URL);
            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                VrmBytes = request.downloadHandler.data;
            }
            Vrm10Instance vrmInstance = await Vrm10.LoadBytesAsync(
                VrmBytes,
                canLoadVrm0X: true,
                materialGenerator: GraphicsSettings.currentRenderPipeline is UniversalRenderPipelineAsset
                    ? new UrpVrm10MaterialDescriptorGenerator() : null
             );
            return vrmInstance;
        }








    }






}



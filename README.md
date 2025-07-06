# VRM Visual Scripting Nodes

## Unity Visual Scripting node library for VRM models

### Features

- Load VRM models with URL
- Get meta information of VRM models
- VisionOS Support (Shaders will be replace with Unlit untill official shader support. Build with Polyspatial)

<img width="698" alt="vrm_node" src="https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/33e7c2fb-c75d-45ab-966d-e925b8717466">

<img width="749" alt="Screenshot 2024-01-10 at 23 54 40" src="https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/612b2a32-9139-49ab-97e2-c25bcf2e9104">

## Install via OpenUPM command-line interface

```shell
# Install openupm-cli
npm install -g openupm-cli

# Go to your unity project directory
cd YOUR_UNITY_PROJECT_DIR

# Install package:
openupm add com.from2001.vrm-visualscripting-nodes
```

## How to Use

This Visual Scripting Graph shows how to load VRM with URL and attach animation as well as getting meta information of the VRM model. LoadVRM node only works with Coroutine checked in On Start Event triger node.

Notice: Check "Coroutine" in the "On Start Event" triger node.

![Script Graph](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/a0055284-7ad1-434c-80c3-f1f91c25881f)

## Samples

These samples can be imported.

1. Load vrm
2. Attach animation
3. Get meta information

![InstallSamples](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/31c42fde-8b71-46e5-a4d5-a488015ca379)

## ToDo

Implemented features of [VRM-1.0 APIs](https://vrm-c.github.io/UniVRM/ja/vrm1/api_update.html#expression) for Visual Scripting node.

- ~~Load~~
- ~~VisionOS Support (Partially supported)~~
- ~~Improve Shader replacement for VisionOS Support~~
- Expression
- LookAt
  - Gaze
  - SetYawPitch
- ~~Set target location~~

Add some useful features

- ~~Cache data in local storage~~

## Repositories

- [GitHub](https://github.com/from2001/com.from2001.vrm-visualscripting-nodes/)
- [OpenUPM](https://openupm.com/packages/com.from2001.vrm-visualscripting-nodes/)

## Others

### Vision OS Support

Materials are replaced with [PolySpatialEnvironmentDiffuseShader](https://github.com/segurvita/PolySpatialEnvironmentDiffuseShader) shader materials on visionOS. Many thanks to [segurvita](https://github.com/segurvita).

### Avoid Multiple scripted importers error

If you want to use [glTFast Visual Scripting Nodes](https://openupm.com/packages/com.from2001.gltfast-visualscripting-nodes/) and [VRM Visual Scripting Nodes](https://openupm.com/packages/com.from2001.vrm-visualscripting-nodes/) in a same project, add two Scripting Define Symbols in `Project Settings` > `Player` > `Other Settings` > `Script Compilation` > `Scripting Define Symbols`

`UNIGLTF_DISABLE_DEFAULT_GLTF_IMPORTER`
`UNIGLTF_DISABLE_DEFAULT_GLB_IMPORTER`

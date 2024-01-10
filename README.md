# VRM Visual Scripting Nodes

## Unity Visual Scripting node library for VRM models

### Features

- Load VRM models with URL
- Get meta information of VRM models

<img width="698" alt="vrm_node" src="https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/33e7c2fb-c75d-45ab-966d-e925b8717466">

<img width="749" alt="Screenshot 2024-01-10 at 23 54 40" src="https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/612b2a32-9139-49ab-97e2-c25bcf2e9104">

## Install Option A: via OpenUPM command-line interface

```shell
# Install openupm-cli
npm install -g openupm-cli

# Go to your unity project directory
cd YOUR_UNITY_PROJECT_DIR

# Install package:
openupm add com.from2001.vrm-visualscripting-nodes
```

## Install Option B: via Unity package manager

### 1. Setup scoped registories

Open "Edit - Project Settings - Package Manager" on your Unity project.

Add Scoped Registories and click "Apply".

Name: `OpenUPM`
URL: `https://package.openupm.com`
Scopes:
`com.cysharp.unitask`
`com.from2001.vrm-visualscripting-nodes`
`com.openupm`
`com.vrmc.gltf`
`com.vrmc.vrm`
`com.vrmc.vrmshaders`

![Project Settings](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/595b1d91-4435-4195-9b6d-1ca6b43113ce)

### 2. Install VRM Visual Scripting Node Package with Package Manager

![Package Manager](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/2809ed0b-61a8-47d9-bdb0-24335ac60163)

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

Implement features of [VRM-1.0 APIs](https://vrm-c.github.io/UniVRM/ja/vrm1/api_update.html#expression)

- ~~Load~~
- ~~VisionOS Support (Partially supported)~~
- ~~Improve Shader replacement for VisionOS Support~~
- Expression
- LookAt
  - Gaze
  - SetYawPitch
- ~~Set target location~~

Add some useful features

- Cache data in local storage
- Runtime load anim file

## Repositories

- [GitHub](https://github.com/from2001/com.from2001.vrm-visualscripting-nodes/)
- [OpenUPM](https://openupm.com/packages/com.from2001.vrm-visualscripting-nodes/)

## Others

### Vision OS Support

Shaders are replaced with `Universal Render Pipeline/Lit` shader on ViisonOS

### Avoid Multiple scripted importers error

If you want to use [glTFast Visual Scripting Nodes](https://openupm.com/packages/com.from2001.gltfast-visualscripting-nodes/) and [VRM Visual Scripting Nodes](https://openupm.com/packages/com.from2001.vrm-visualscripting-nodes/) in a same project, add two Scripting Define Symbols in `Project Settings` > `Player` > `Other Settings` > `Script Compilation` > `Scripting Define Symbols`

`UNIGLTF_DISABLE_DEFAULT_GLTF_IMPORTER`
`UNIGLTF_DISABLE_DEFAULT_GLB_IMPORTER`

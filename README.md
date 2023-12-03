# VRM Visual Scripting Nodes

## Unity Visual Scripting node library for VRM models

### Features

- Load VRM models with URL
- Get meta information of VRM models

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

### 1, Setup scoped registories

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

![Project Settings](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/682f1f2a-e061-4de5-a020-13d98ab2bf89)

### 2, Install VRM Visual Scripting Node Package with Package Manager

![Package Manager](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/2809ed0b-61a8-47d9-bdb0-24335ac60163)

## How to Use

This Visual Scripting Graph shows how to load VRM with URL and attach animation as well as getting meta information of the VRM model. LoadVRM node only works with Coroutine checked in On Start Event triger node.

Notice: Check "Coroutine" in "On Start Event" triger node.

![Script Graph](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/a0055284-7ad1-434c-80c3-f1f91c25881f)

## Samples

These samples can be imported.

1. Load vrm
2. Attach animation
3. Get meta information

![InstallSamples](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/31c42fde-8b71-46e5-a4d5-a488015ca379)

## ToDO

Implement features of [VRM-1.0 APIs](https://vrm-c.github.io/UniVRM/ja/vrm1/api_update.html#expression)

- ~~Load~~
- Expression
- LookAt
  - Gaze
  - SetYawPitch

Add some useful features

- Cache data in local storage

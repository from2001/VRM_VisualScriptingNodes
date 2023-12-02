# VRM_VisualScriptingNodes

Unity Visual Scripting node library for VRM

# Installation

## 1, Setup scoped registories

Open "Edit - Project Settings - Package Manager" on your Unity project.

Add Scoped Registories and click "Apply".

Name: `OpenUPM`  
URL: `https://package.openupm.com`  
Scopes:   
 `com.from2001.vrmvisualscriptingnodes`  
 `com.vrmc`  
 `com.cysharp.unitask`

![](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/da298940-5dfb-472a-baaf-7d3d613b962e)

## 2, Install VRM Visual Scripting Node Package

Install the unity package with the github package URL (This prcess will be replace when this repository is registered in OpenUPM)

- `Window` -> `Package Manager` -> `+` -> `Add package from git URL...`

[`https://github.com/from2001/VRM_VisualScriptingNodes.git?path=VRM_VisualScriptingNodes/Packages/com.from2001.vrmvisualscriptingnodes`](https://github.com/from2001/VRM_VisualScriptingNodes.git?path=VRM_VisualScriptingNodes/Packages/com.from2001.vrmvisualscriptingnodes)

# How to Use

This Visual Scripting Graph shows how to load VRM with URL and attach animation as well as getting meta information of the VRM model. LoadVRM node only works with Coroutine checked in On Start Event triger node.

![](https://github.com/from2001/VRM_VisualScriptingNodes/assets/387880/a0055284-7ad1-434c-80c3-f1f91c25881f)

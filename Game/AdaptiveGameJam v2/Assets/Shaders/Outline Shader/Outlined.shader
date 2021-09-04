Shader "Unlit/Outlined"
{
    Properties
    {
        _Thickness("Thickness", Float) = 1 // The amount to extrude the outline mesh
        _Colour("Colour", Color) = (1,1,1,1) // The outline colour
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeLine" }
        LOD 100

        Pass
        {
           Name "Outlined"
           // Cull front faces
        Cull Front

        HLSLPROGRAM
        // Standard URP Requirements
#pragma prefer_hlslcc gles
#pragma exclude_renderers d3d11_9x

        // Register our functions
#pragma vertex Vertex
#pragma fragment Fragment

        // Include our logic
#include "Outlined.hlsl"


        ENDHLSL
        }
    }
}

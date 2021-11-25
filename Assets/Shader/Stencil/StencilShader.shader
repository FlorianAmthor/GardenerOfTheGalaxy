// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/StenciMask"
{
    SubShader{
        // Render the mask after regular geometry, but before masked geometry and
        // transparent things.
        Tags {"RenderType" = "Opaque" "Queue" = "Geometry-100" }

        // Don't draw in the RGBA channels; just the depth buffer
        ColorMask 0

        //ZWrite On
       // Cull Off
         //ZTest Greater
        /*
        ZTest Greater

       
        ZWrite On
        */
       // Cull Off
         //ZTest Greater
        ZWrite Off

        Stencil
             {
                 Ref 1
                 Comp Always
                 //Pass Invert
             }

        // Do nothing specific in the pass:
        Pass {
            /*
                Cull Back //Make 2 sided
               
                */
           // ZWrite On
           // ZTest Greater
           // Cull Off
        
        
        }
    }
}
﻿Shader "Custom/CustomMove" {
	Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _ScrollXSpeed("X Scroll Speed", Range(0, 10)) = 0.2
        _ScrollYSpeed("Y Scroll Speed", Range(0, 10)) = 0.2
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed _ScrollXSpeed;
        fixed _ScrollYSpeed;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed2 scrollValue = fixed2(_ScrollXSpeed * _Time.y, _ScrollYSpeed * _Time.y);

            float2 scrolledUV = IN.uv_MainTex + scrollValue;

            scrolledUV = frac(scrolledUV);

            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, scrolledUV) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

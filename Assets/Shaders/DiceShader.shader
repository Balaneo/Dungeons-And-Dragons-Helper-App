Shader "Custom/DiceShader" 
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0


		_EmissiveColour("Emissive Colour", Color) = (0,0,0,0)
		_EmissiveMask("Emissive Mask", 2D) = "black" {}
		_EmissiveStrength("Emissive Strength", float) = 0.0
		_EmissivePulseRate("Emissive Pule Rate", float) = 1.0
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#include "UnityCG.cginc"
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		sampler2D _EmissiveMask;

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _EmissiveColour;
		float _EmissiveStrength;
		float _EmissivePulseRate;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_EmissiveMask;
		};

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf(Input IN, inout SurfaceOutputStandard o)
		{

			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;

			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;

			// Emissive comes from adding emissive colour to base colour multiplied by emissive mask

			float s = _EmissiveStrength * ((sin(_Time[1] * _EmissivePulseRate) + 1.0) * 0.5);
			half4 a = tex2D(_EmissiveMask, IN.uv_EmissiveMask);
			fixed4 e = _EmissiveColour * s;
			o.Emission = lerp(0, e.rgb, a.r);
		}
		ENDCG
	}
}

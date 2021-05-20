Shader "Custom/TextureShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", 2D) = "white" {}
		_Metallic("Metallic", 2D) = "white" {}
		_Opacity("Opacity",2D) = "white" {}
		_Cutoff("Cutoff"      , Range(0, 1)) = 0.5

		_BumpMap("Normal Map"  , 2D) = "bump" {}
		_BumpScale("Normal Scale", Range(0, 1)) = 1.0
	}
		SubShader
		{
			Tags
			{
				"Queue" = "AlphaTest"
				"RenderType" = "Transparent"
			}

			Cull Off
			LOD 300

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

		sampler2D _MainTex;
		half _Metallic;
		half _Glossiness;
		half _Opacity;
		fixed _Cutoff;

		sampler2D _BumpMap;
		half _BumpScale;

			struct Input
			{
				float2 uv_MainTex : TEXCOOD0;
			};

			//half _Glossiness;
			fixed4 _Color;
			UNITY_INSTANCING_BUFFER_START(Props)
			UNITY_INSTANCING_BUFFER_END(Props)

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
				o.Albedo = c.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				//clip(c.a - _Cutoff);
				o.Alpha = c.a;

				fixed4 n = tex2D(_BumpMap, IN.uv_MainTex);
				o.Normal = UnpackScaleNormal(n, _BumpScale);
			}
			ENDCG
		}
			FallBack "Diffuse"
}

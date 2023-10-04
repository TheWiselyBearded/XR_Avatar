Shader "Custom/SH_Eyes_Heavy" {
	Properties {
	//Base Properties
		[NoScaleOffset]_MainTex ("Albedo (RGB)", 2D) = "white" {}
		[NoScaleOffset]_MRH ("MRH", 2D) = "white" {}
		[NoScaleOffset]_Normal ("Normal", 2D) = "white" {}

	//Cornea Properties
		_CorneaGlossiness ("Cornea Glossiness", Range(0,1)) = 0.95
		_CorneaColor ("Cornea Color", Color) = (0,0,0,0)
		[NoScaleOffset]_CorneaNormal ("Cornea Normal", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		//Base Pass
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		sampler2D _MainTex, _Normal, _MRH;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		half _NormalScale;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float3 normalTex = UnpackNormal(tex2D(_Normal, IN.uv_MainTex));
			o.Normal = normalTex;
			fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex);
			half3 mrhTex = tex2D(_MRH, IN.uv_MainTex);

			o.Albedo = baseColor;
			o.Metallic = mrhTex.r;
			o.Smoothness = (1-mrhTex.g)*0.5;
			o.Alpha = 1;
		}
		ENDCG

		//Cornea Pass

		Blend one one

		CGPROGRAM
		#pragma surface surf Standard 

		sampler2D _CorneaNormal;

		struct Input{
			float2 uv_CorneaNormal;
		};

		half _CorneaGlossiness;
		half4 _CorneaColor;

		void surf (Input IN, inout SurfaceOutputStandard o){
		
			float3 normalTex = UnpackNormal(tex2D(_CorneaNormal, IN.uv_CorneaNormal));
		
			o.Albedo = _CorneaColor;
			o.Smoothness = _CorneaGlossiness;
			o.Normal = normalTex;
		}
		ENDCG

	}
	FallBack "Diffuse"
}

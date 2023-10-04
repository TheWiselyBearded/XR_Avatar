// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Dreamscape/SH_MIB_Cloth"
{
	Properties
	{
		_DIFF_MET_SMO("DIFF_MET_SMO", 2D) = "white" {}
		_NOMA("NOMA", 2D) = "white" {}
		_Detail_Add("Detail_Add", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Detail_Add;
		uniform float4 _Detail_Add_ST;
		uniform sampler2D _NOMA;
		uniform float4 _NOMA_ST;
		uniform sampler2D _DIFF_MET_SMO;
		uniform float4 _DIFF_MET_SMO_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Detail_Add = i.uv_texcoord * _Detail_Add_ST.xy + _Detail_Add_ST.zw;
			float4 tex2DNode36 = tex2D( _Detail_Add, uv_Detail_Add );
			float2 uv_NOMA = i.uv_texcoord * _NOMA_ST.xy + _NOMA_ST.zw;
			float4 tex2DNode35 = tex2D( _NOMA, uv_NOMA );
			float4 lerpResult24 = lerp( tex2DNode36 , float4(0.4980392,0.5019608,1,1) , tex2DNode35.b);
			o.Normal = BlendNormals( UnpackNormal( lerpResult24 ) , UnpackNormal( tex2DNode35 ) );
			float2 uv_DIFF_MET_SMO = i.uv_texcoord * _DIFF_MET_SMO_ST.xy + _DIFF_MET_SMO_ST.zw;
			float4 tex2DNode34 = tex2D( _DIFF_MET_SMO, uv_DIFF_MET_SMO );
			float3 temp_cast_2 = (tex2DNode34.r).xxx;
			o.Albedo = temp_cast_2;
			o.Metallic = tex2DNode34.g;
			o.Smoothness = ( tex2DNode34.b * tex2DNode36.b );
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16700
94;69;1281;788;1544.885;519.9911;3.005393;True;True
Node;AmplifyShaderEditor.ColorNode;23;-633.5297,867.4449;Float;False;Constant;_Color0;Color 0;3;0;Create;True;0;0;False;0;0.4980392,0.5019608,1,1;0,0,0,0;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;36;-696.652,652.0209;Float;True;Property;_Detail_Add;Detail_Add;2;0;Create;True;0;0;False;0;a8c9eed3b969c164584be6f59c4bd1a9;a8c9eed3b969c164584be6f59c4bd1a9;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;35;-684.0526,1060.029;Float;True;Property;_NOMA;NOMA;1;0;Create;True;0;0;False;0;cad2625b553eee84aaa22c18ccb3f7ed;cad2625b553eee84aaa22c18ccb3f7ed;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;24;-274.0686,774.7327;Float;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;34;-642.0151,219.2033;Float;True;Property;_DIFF_MET_SMO;DIFF_MET_SMO;0;0;Create;True;0;0;False;0;597a3624635ca6a448435e79c5675c5d;597a3624635ca6a448435e79c5675c5d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.UnpackScaleNormalNode;19;-264.1527,1091.449;Float;False;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.UnpackScaleNormalNode;22;19.1874,764.3216;Float;True;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;46;602.0703,683.454;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BlendNormalsNode;20;375.5248,774.6452;Float;True;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1310.381,595.4109;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Dreamscape/SH_MIB_Cloth;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;24;0;36;0
WireConnection;24;1;23;0
WireConnection;24;2;35;3
WireConnection;19;0;35;0
WireConnection;22;0;24;0
WireConnection;46;0;34;3
WireConnection;46;1;36;3
WireConnection;20;0;22;0
WireConnection;20;1;19;0
WireConnection;0;0;34;1
WireConnection;0;1;20;0
WireConnection;0;3;34;2
WireConnection;0;4;46;0
ASEEND*/
//CHKSM=A629A08E23DFC858E19C8AE69B7C3D01A2F284BA
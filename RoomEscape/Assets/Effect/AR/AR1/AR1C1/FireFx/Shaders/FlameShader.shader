// Made with Amplify Shader Editor v1.9.0.2
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Amplify_Shader/FlameShader"
{
	Properties
	{
		_NoiseTex("NoiseTex", 2D) = "white" {}
		_Noise_Upanner("Noise_Upanner", Range( -1 , 1)) = 0
		_Noise_Vpanner("Noise_Vpanner", Range( -1 , 1)) = -0.1599843
		_Step_Value("Step_Value", Float) = 0.06
		[HDR]_Tint_Color("Tint_Color", Color) = (1,1,1,0)
		_Dissolve_Value("Dissolve_Value", Range( -2 , 1)) = -0.3801624
		[Toggle(_USE_CUSTOM_ON)] _Use_custom("Use_custom", Float) = 0
		_MainTex("MainTex", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma shader_feature_local _USE_CUSTOM_ON
		#pragma surface surf Unlit alpha:fade keepalpha noshadow noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float4 vertexColor : COLOR;
			float4 uv_texcoord;
		};

		uniform float4 _Tint_Color;
		uniform float _Step_Value;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform sampler2D _NoiseTex;
		uniform float _Noise_Upanner;
		uniform float _Noise_Vpanner;
		uniform float4 _NoiseTex_ST;
		uniform float _Dissolve_Value;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			o.Emission = ( _Tint_Color * i.vertexColor ).rgb;
			float4 uvs_MainTex = i.uv_texcoord;
			uvs_MainTex.xy = i.uv_texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
			float2 appendResult9 = (float2(_Noise_Upanner , _Noise_Vpanner));
			float4 uvs_NoiseTex = i.uv_texcoord;
			uvs_NoiseTex.xy = i.uv_texcoord.xy * _NoiseTex_ST.xy + _NoiseTex_ST.zw;
			float2 panner11 = ( 1.0 * _Time.y * appendResult9 + uvs_NoiseTex.xy);
			#ifdef _USE_CUSTOM_ON
				float staticSwitch19 = i.uv_texcoord.z;
			#else
				float staticSwitch19 = _Dissolve_Value;
			#endif
			o.Alpha = ( i.vertexColor.a * saturate( step( _Step_Value , ( tex2D( _MainTex, uvs_MainTex.xy ).r * ( tex2D( _NoiseTex, panner11 ).r + staticSwitch19 ) ) ) ) );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=19002
6.666667;6;1266.667;645;3158.1;452.1921;2.783612;True;False
Node;AmplifyShaderEditor.CommentaryNode;2;-3827.974,86.94909;Inherit;False;822.2601;813.9734;panner;5;11;10;9;6;5;;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-3776.372,427.1382;Float;False;Property;_Noise_Upanner;Noise_Upanner;1;0;Create;True;0;0;0;False;0;False;0;-0.09;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;5;-3777.974,641.9227;Float;False;Property;_Noise_Vpanner;Noise_Vpanner;2;0;Create;True;0;0;0;False;0;False;-0.1599843;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;10;-3538.194,136.9491;Inherit;False;0;16;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;9;-3537.508,433.3933;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;11;-3276.713,170.2566;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;14;-2877.368,632.8918;Float;False;Property;_Dissolve_Value;Dissolve_Value;5;0;Create;True;0;0;0;False;0;False;-0.3801624;0;-2;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;17;-2775.413,849.591;Inherit;False;0;4;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;16;-2995.024,184.7687;Inherit;True;Property;_NoiseTex;NoiseTex;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;19;-2474.089,635.5184;Float;False;Property;_Use_custom;Use_custom;6;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;30;-1848.586,232.2071;Inherit;False;0;29;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;29;-1537.933,281.2533;Inherit;True;Property;_MainTex;MainTex;7;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;20;-2137.378,509.6093;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;21;-1056,80;Float;True;Property;_Step_Value;Step_Value;3;0;Create;True;0;0;0;False;0;False;0.06;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;31;-1203.106,458.9055;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;23;-819.1259,285.0299;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;26;-584.3994,278.6033;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;25;-306.2331,-192.8287;Float;False;Property;_Tint_Color;Tint_Color;4;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,0;0.05660379,0.0008009956,0.002793945,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;24;-364.8819,41.7703;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;28;-66.17924,219.0833;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-71.63432,-117.8115;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;299.2159,-123.8134;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;Amplify_Shader/FlameShader;False;False;False;False;True;True;True;True;True;True;True;True;False;False;True;False;False;False;False;False;False;Off;0;False;;0;False;;False;0;False;;0;False;;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;18;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;False;2;5;False;;10;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;False;;0;0;0;False;0.1;False;;0;False;;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;9;0;6;0
WireConnection;9;1;5;0
WireConnection;11;0;10;0
WireConnection;11;2;9;0
WireConnection;16;1;11;0
WireConnection;19;1;14;0
WireConnection;19;0;17;3
WireConnection;29;1;30;0
WireConnection;20;0;16;1
WireConnection;20;1;19;0
WireConnection;31;0;29;1
WireConnection;31;1;20;0
WireConnection;23;0;21;0
WireConnection;23;1;31;0
WireConnection;26;0;23;0
WireConnection;28;0;24;4
WireConnection;28;1;26;0
WireConnection;27;0;25;0
WireConnection;27;1;24;0
WireConnection;0;2;27;0
WireConnection;0;9;28;0
ASEEND*/
//CHKSM=2C9C7DB6BA800535A7D73D4B13295AE2B482CCED
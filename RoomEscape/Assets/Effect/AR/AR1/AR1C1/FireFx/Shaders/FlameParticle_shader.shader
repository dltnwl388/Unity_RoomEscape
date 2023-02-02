// Made with Amplify Shader Editor v1.9.0.2
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Amplify_Shader/FlameParticle_Shader"
{
	Properties
	{
		_Main_tex("Main_tex", 2D) = "white" {}
		[HDR]_Tint_Color("Tint_Color", Color) = (1,1,1,0)
		_Main_Power("Main_Power", Range( 1 , 10)) = 1
		_Main_intensity("Main_intensity", Range( 1 , 10)) = 1
		_Opacity("Opacity", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Unlit alpha:fade keepalpha noshadow noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform float4 _Tint_Color;
		uniform sampler2D _Main_tex;
		uniform float _Main_Power;
		uniform float _Main_intensity;
		uniform float _Opacity;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float4 tex2DNode1 = tex2D( _Main_tex, i.uv_texcoord );
			o.Emission = ( ( _Tint_Color * ( pow( tex2DNode1.r , _Main_Power ) * _Main_intensity ) ) * i.vertexColor ).rgb;
			o.Alpha = ( i.vertexColor.a * ( tex2DNode1.r * _Opacity ) );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=19002
6.666667;6;1266.667;645;1826.802;564.4158;1.681939;True;False
Node;AmplifyShaderEditor.CommentaryNode;12;-1943.866,-356.6998;Inherit;False;585.8906;371.3903;Comment;2;7;9;Power;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;13;-2855.133,-280.0051;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;11;-1267.669,-297.95;Inherit;False;513.5688;337.0092;Comment;2;10;8;Intensity;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-1902.874,-267.143;Inherit;False;Property;_Main_Power;Main_Power;2;0;Create;True;0;0;0;False;0;False;1;1;1;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-2483.388,-293.6472;Inherit;True;Property;_Main_tex;Main_tex;0;0;Create;True;0;0;0;False;0;False;-1;bf1c16cc71eee11488c150babfcf12e0;bf1c16cc71eee11488c150babfcf12e0;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;53;-2281.191,299.2973;Inherit;False;623.0441;298.6998;Comment;2;52;51;Opacity;1,1,1,1;0;0
Node;AmplifyShaderEditor.PowerNode;7;-1609.311,-279.3819;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;6;-704.8459,-337.2953;Inherit;False;653.4969;457;Comment;4;3;2;5;4;Color;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-1248.67,-209.4725;Inherit;False;Property;_Main_intensity;Main_intensity;3;0;Create;True;0;0;0;False;0;False;1;1;1;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-654.8459,-287.2953;Inherit;False;Property;_Tint_Color;Tint_Color;1;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,0;4,4,4,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-973.0517,-231.7844;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;52;-2231.191,355.2255;Inherit;False;Property;_Opacity;Opacity;4;0;Create;True;0;0;0;False;0;False;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;51;-1921.866,349.2972;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;4;-415.8459,-82.29535;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-399.8459,-188.2953;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-214.6824,-158.3465;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;54;-216.6273,135.9881;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-62.76063,-116.1239;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;Amplify_Shader/FlameParticle_Shader;False;False;False;False;True;True;True;True;True;True;True;True;False;False;True;False;False;False;False;False;False;Off;2;False;;0;False;;False;0;False;;0;False;;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;18;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;False;2;5;False;;10;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;False;;0;0;0;False;0.1;False;;0;False;;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;1;1;13;0
WireConnection;7;0;1;1
WireConnection;7;1;9;0
WireConnection;8;0;7;0
WireConnection;8;1;10;0
WireConnection;51;0;1;1
WireConnection;51;1;52;0
WireConnection;3;0;2;0
WireConnection;3;1;8;0
WireConnection;5;0;3;0
WireConnection;5;1;4;0
WireConnection;54;0;4;4
WireConnection;54;1;51;0
WireConnection;0;2;5;0
WireConnection;0;9;54;0
ASEEND*/
//CHKSM=3A79D7ED9631767EA325C12A18A0187C7F155ED9
Shader "Custom/VertexShader" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Cutoff("Cut",Range(0,1)) = 0.5

	}
		SubShader{
		   Tags {"Queue" = "AlphaTest" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout"}
			LOD 150

			CGPROGRAM
			#pragma surface surf Lambert vertex:vert alphatest:_Cutoff

			#pragma target 3.0


			struct Input {
				float2 uv_MainTex;
				float3 vertexColor; // Vertex color stored here by vert() method
			};

			struct v2f {
			  float4 pos : SV_POSITION;
			  fixed4 color : COLOR;
			};

			void vert(inout appdata_full v, out Input o)
			{
				UNITY_INITIALIZE_OUTPUT(Input,o);
				o.vertexColor = v.color; // Save the Vertex Color in the Input for the surf() method
			}

			sampler2D _MainTex;

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;

			void surf(Input IN, inout SurfaceOutput o)
			{
				// Albedo comes from a texture tinted by color
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb * IN.vertexColor; // Combine normal color with the vertex color
				// Metallic and smoothness come from slider variables
				o.Alpha = c.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}
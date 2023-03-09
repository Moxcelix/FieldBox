Shader"Custom/TransparentVertexShader" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Base (RGB) Trans (A)", 2D) = "white" {}
	}
		SubShader
	{

			Tags { "Queue" = "Overlay" "IgnoreProjector" = "True" "RenderType" = "TransparentCutout" }
			LOD 100

		Pass {
				ZWrite On
				ZTest On
				Blend  zero one
		}

		CGPROGRAM
		//#pragma surface surf Standard vertex:vert fullforwardshadows alphatest : _Cutoff 
	   // #pragma target 3.0
		#pragma surface surf Lambert alpha:fade vertex:vert
		// fullforwardshadows

		struct Input {
			float2 uv_MainTex;
			float3 vertexColor;
		};

	   struct v2f {
		  float4 pos : SV_POSITION;
		  fixed4 color : COLOR;
		};

		void vert(inout appdata_full v, out Input o) {
		   UNITY_INITIALIZE_OUTPUT(Input,o);
			o.vertexColor = v.color;
		 }

		 sampler2D _MainTex;
		 float _vertStrength;
		 fixed4 _Color;
		fixed4 c;

		 void surf(Input IN, inout SurfaceOutput o) {
			 c = tex2D(_MainTex, IN.uv_MainTex);

			 o.Albedo = c.rgb * IN.vertexColor;
			 o.Alpha = c.a * _Color.a;
		 }
		 ENDCG


	}
		FallBack "Transparent/Cutout/Diffuse"
}
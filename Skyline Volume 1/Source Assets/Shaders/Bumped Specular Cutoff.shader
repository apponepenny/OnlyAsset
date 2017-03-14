Shader "NVYVE/Bumped Spec Cutoff" {
	Properties {
		_MainTint ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Spec Color", Color) = (1,1,1,1)
		_SpecPower ("Shininess", Float) = 0
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
		_NormalTex ("Normal Tex (RGB)", 2D) = "bump" {}
		_Trans ("Opacity Mask", 2D) = "white" {}
		_Cutoff ("Cutoff Value", Range(0,1)) = 0.5
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Cull Off
		
		CGPROGRAM
		#pragma surface surf BlinnPhong alphatest:_Cutoff
		#pragma target 3.0
		
		sampler2D _MainTex, _NormalTex, _Trans;
		float _SpecPower;
		float4 _MainTint, _SpecTint;

		struct Input {
			float2 uv_MainTex;
			float2 uv_NormalTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 n = tex2D (_NormalTex, IN.uv_NormalTex);
			half a = tex2D (_Trans, IN.uv_NormalTex);
			o.Specular = _SpecPower;
			o.Gloss = c.a;
			o.Normal = UnpackNormal(n);
			o.Albedo = c.rgb * _MainTint;
			o.Alpha = a;
		}
		ENDCG
	} 
	FallBack "Specular"
}

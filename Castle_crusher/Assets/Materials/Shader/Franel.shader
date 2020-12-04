Shader "Custom/Franel"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _MyColor ("Shine Color", Color) = (1,1,1,1)
        _Shininess ("Shinness", Range(0.01, 3)) = 1
        _Bump("Bump", 2D)="bump" {}


    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _Bump;
        float _Shininess;
        fixed4 _MyColor;


        struct Input
        {
            float2 uv_MainTex;
            float2 uv_Bump;
            float3 viewDir;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Bump));
            half factor = dot(normalize(IN.viewDir), o.Normal);
            //half factor = normalize(IN.viewDir);

            o.Albedo = c.rgb + _MyColor * (_Shininess-factor * _Shininess);
            // Metallic and smoothness come from slider variables
            o.Emission.rgb = _MyColor * (_Shininess - factor * _Shininess);
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

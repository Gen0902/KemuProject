Shader "Custom/CloudSurface"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _NoiseTex("Noise Texture", 2D) = "white"{}
        _Speed("Cloud Speed", Range(0,1)) = 0
        _Amount("Amount", Range(0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _NoiseTex;
        float4 _NoiseTex_ST;
        half _Amount;
        half _Speed;

        struct Input
        {
            float2 uv_MainTex;
            float displacementValue;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        void vert(appdata_full v, out Input o) {

            float value = tex2Dlod(_NoiseTex, v.texcoord*7).x * _Amount;
            v.vertex.xyz += v.normal.xyz * value * .3; //Expand

            UNITY_INITIALIZE_OUTPUT(Input, o);
            o.displacementValue = value;
        }

        //UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {

            // off set anim
            fixed offX = _Speed * _Time;
            fixed offY = _Speed * _Time;
            fixed offUV = fixed2(offX, offY);

            fixed2 uvOffset = IN.uv_MainTex + offUV;

            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D(_MainTex, uvOffset);//* _Color;
            o.Albedo = c.rgb;// lerp(c.rgb * c.a, float3(1, 1, 1), IN.displacementValue);

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

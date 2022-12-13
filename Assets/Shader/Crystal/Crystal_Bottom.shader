Shader "Unlit/Crystal_Bottom"
{
    Properties
    {
        _MainTex("TextureMain", 2D) = "white" { }
        _Pattern("TexturePattern", 2D) = "white" { }
        _ColorA("ColorA", Color) = (1, 1, 1, 1)
        _ColorB("ColorB", Color) = (1, 1, 1, 1)
        _Scale("UV Scale", Float) = 1.0
        _Offset("UV offset", Float) = 0
    }
        SubShader
{
     Tags {
     "RenderType" = "Opaque"
     //"Queue" = "Transparent"
}
     LOD 200

        Pass
        {
         cull off



            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define TAU 6.28318530718



            # include "UnityCG.cginc"


            float _Scale;
            float _Offset;

            struct meshdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            float GetWave(float2 uv)
            {
                float2 uvcentered = (uv * 2 - 1);
                float radiusdistance = max(0.1, length(uvcentered));
                float wave = cos((radiusdistance - _Time.y * 0.1) * 5 * TAU);
                wave *= (1 - radiusdistance);
                return wave;
            }

            struct v2f
            {
                float2 uv : TEXCOORD0;

                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _Pattern;
            float4 _MainTex_ST;
            float4 _ColorA;
            float4 _ColorB;

            v2f vert(meshdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = (v.uv + _Offset) * _Scale;

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                 // sample the texture
                float4 mainTex = tex2D(_MainTex, i.uv);
                float4 pattern = tex2D(_Pattern, i.uv).x;

                float4 outCol = lerp(_ColorA, mainTex, pattern);
                float flash = sin(_Time.y * 5) * 0.1 + 1;





                return GetWave(outCol) * flash * _ColorA;
    
}
ENDCG
        }
}
}

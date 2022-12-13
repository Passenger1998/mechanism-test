Shader "Unlit/SpaceShipShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _ColorA("ColorA", Color) = (1,1,1,1)
        _ColorB("ColorB", Color) = (1,1,1,1)
        _ColorStart("ColorStart", Range(0,1)) = 0
        _ColorEnd("ColorEnd", Range(0, 1)) = 1
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
                #define TAU 6.28318530718

                struct meshdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                    float3 normal : NORMAL;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                    float3 normal : TEXCOORD1;
                    float3 WorldPos : TEXCOORD2;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float3 _ColorA;
                float3 _ColorB;
                float3 _ColorStart;
                float3 _ColorEnd;






                v2f vert(meshdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    o.normal = UnityObjectToWorldNormal(v.normal);
                    o.WorldPos = mul(unity_ObjectToWorld, v.vertex);

                    return o;
                }



                float Inverselerp(float a, float b, float v)
                {
                    return((v - a) / (b - a));

                }



                float4 frag(v2f i) : SV_Target
                {
                    // sample the texture
                    //float4 col = tex2D(_MainTex, i.uv);
                    float3 gradient = lerp(_ColorA, _ColorB, i.normal);

                    float colorLerpStation = lerp(_ColorStart, _ColorEnd, i.normal);
                    //fresnal
                    float3 N = normalize(i.normal);
                    float3 V = normalize(_WorldSpaceCameraPos - i.WorldPos);
                    float3 fresnal = step(0.8,1 - dot(V, N));
                    //flash
                    float flash = (sin(_Time.y * 3) * 0.5 + 0.5) * TAU;
                    fresnal *= flash;





                    return float4 (fresnal,1) + float4(gradient,1) + float4(1,1,1,1) * colorLerpStation;
                }
                ENDCG
            }
        }
}

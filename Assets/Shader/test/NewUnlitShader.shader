Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
     _MainTex2("Texture 2", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
            };

            sampler2D _MainTex;
            sampler2D _MainTex2;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
               // o.vertex = UnityObjectToClipPos(v.vertex);
                v.vertex = mul(UNITY_MATRIX_M, v.vertex);

                float4 poOffset = tex2Dlod(_MainTex, float4(v.uv.x,v.uv.y,0.0f,0.0f));
                v.vertex.y += 0.1f*sin(_Time.z+ (poOffset.z*10.0f));

                float2 UVOffset1 = float2(0.01, 0.0f);
                float2 UVOffset2 = float2(-0.01, 0.0f);
                float2 UVOffset3 = float2(0.0, 0.01f);
                float2 UVOffset4 = float2(0.0, -0.01f);

                float poOffset1 = tex2Dlod(_MainTex, float4(v.uv.x+0.01f, v.uv.y, 0.0f, 0.0f)).x;
                poOffset1 += 0.1f * sin(_Time.z + (poOffset1 * 10.0f));
                float poOffset2 = tex2Dlod(_MainTex, float4(v.uv.x-0.01f, v.uv.y, 0.0f, 0.0f)).x;
                poOffset2 += 0.1f * sin(_Time.z + (poOffset2 * 10.0f));
                float poOffset3 = tex2Dlod(_MainTex, float4(v.uv.x, v.uv.y+0.01f, 0.0f, 0.0f)).x;
                poOffset += 0.1f * sin(_Time.z + (poOffset3 * 10.0f));
                float poOffset4 = tex2Dlod(_MainTex, float4(v.uv.x, v.uv.y-0.01f, 0.0f, 0.0f)).x;
                poOffset4 += 0.1f * sin(_Time.z + (poOffset4 * 10.0f));

                float3 dir1 = float3(0.50f, poOffset1 - poOffset2, 0.0f);
                float3 dir2 = float3(0.0f, poOffset3 - poOffset4, 0.50f);


                o.normal = normalize(cross(dir2, dir1));
                o.vertex = mul(UNITY_MATRIX_VP, v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                //no need to dot with verical light
                float lightamount = i.normal.y;
                fixed4 col = lightamount*  tex2D(_MainTex2, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}

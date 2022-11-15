Shader "Unlit/Texture"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Pattern("Texture", 2D) = "white" {}
        _WaveAmp("WaveAmp", Range(0, 1)) = 0
        _Color("Color", Color) = (1,1,1,1)
        
    }
    SubShader
    {
        Tags { "RenderType"="Transparent"
               "Queue" = "Transparent"
        }
        LOD 100

        Pass
        {   Blend One One
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define TAU 6.28318530718
            #include "UnityCG.cginc"
            

            float _WaveAmp;
            float _Color;
           
            struct meshdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1; //create a float3 about worldposition, texcoord1 is only used to store data
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;//contains values of scale, offset
            sampler2D _Pattern;
            float4 _Pattern_ST;


            float GetWave(float2 uv)
             {
                  float2 uvcentered = (uv * 2 - 1); 
                  float radiusdistance = length(uvcentered);
                  float wave = cos((radiusdistance - _Time.y * 0.1) * 5 * TAU);
                  wave *= (1 - radiusdistance); 
                  return wave;
             }

            v2f vert (meshdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, float4 (v.vertex.xyz,1));//use multipliation functions to multiply matrix, change from object matrix to world matrix

            
               
                return o;
                
            }

            float4 frag (v2f i) : SV_Target
            {
                // sample the texture
                
                //float2 topDownProjection = i.worldPos.xz;
                //float4 water = tex2D(_MainTex, i.uv);
                //float withpattern = tex2D(_Pattern, i.uv).x;
                //float4 finalColor = lerp(_ColorA, water, withpattern);
                
                //shape *= (1-i.uv.x);
               // return float4 (topDownProjection,0,1)
                //float4 finalcolor = lerp(_ColorA, _ColorB, i.uv.y);
                // GetWave(finalColor) *= pattern;

                float pattern = tex2D(_Pattern, i.uv).x;
                float4 fade = tex2D(_MainTex, i.uv);
                float4 finalColor = lerp(_Color, fade, pattern);
             

                
                return GetWave(finalColor);


            }
            ENDCG
        }
    }
}

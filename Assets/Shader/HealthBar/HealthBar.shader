Shader "Unlit/HealthBar"
{
    Properties
    {
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        _Health("Health", range(0,1)) = 1

    }
        SubShader
    {
        Tags { "RenderType" = "Opaque"
              // "Queue" = "Transparent"
        
        
        
        }
        LOD 100


        

        Pass
        {   //ZWrite Off
            cull off
            //Alpha blend: src*srcAlpha + dst *(1-srcAlpha)
            //Blend SrcAlpha OneMinusSrcAlpha
            // Alpha blending




            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            

            #include "UnityCG.cginc"
            

            struct meshdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Health;



            v2f vert (meshdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
               
                return o;
            }




            float InverseLerp(float a, float b, float v) {
                return (v - a) / (b - a);
            }


            float4 frag (v2f i) : SV_Target
            {

                // sample the texture
                float4 col = tex2D(_MainTex, i.uv);
                
                float thealthBarCol = saturate(InverseLerp(0.2, 0.8, _Health)); // use inverselerp to set the value from 0.2 tp 0.8
                float3 healthBarCol = lerp(float4(1, 0, 0, 1), float4(0, 1, 0, 1), thealthBarCol); // use lerp to set the color


               

                float3 bgCol = float4(0, 0, 0, 1);
                float healthBarMask = _Health > i.uv.x;
               // clip(healthBarMask - 0.001); // use clip to not render something, the stuff is the () is going to be renderred
                float3 outCol = lerp(bgCol, healthBarCol, healthBarMask);

                if (_Health < 0.25) 
                {

                    float flash = sin(_Time.y * 5) * 0.5 + 1; // add the flesh to the object;
                    outCol *= flash;

                }
                
               
                return float4 (outCol,0);
            }
            ENDCG
        }
    }
}

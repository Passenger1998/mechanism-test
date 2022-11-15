Shader "Unlit/Light"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Gloss("Gloss", range(0,1)) =0.5
        _Gloss1("Gloss1", range(0,1)) = 0.5
        _Color("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass //the base pass of shader is always for directioal light, if want to include other types of light, could introduce a new pass(which can be directional or other types)
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
       
            #include "UnityCG.cginc"
            #include "Lighting.cginc"// to use the _WorldSpaceLightPos0, should include "Lighting.cginc" and "AutoLight.cginc"
            #include "AutoLight.cginc"

            struct meshdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL; // pass normal to v2f
                

            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD1; //pass normal to vertex shader
                float3 WorldPos : TEXCOORD2; // pass worldPos to vertex shader

            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Gloss;
            float _Gloss1;
            float4 _Color;



            v2f vert (meshdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = UnityObjectToWorldNormal(v.normal); // pass normal to fragment shader, use world normal
                o.WorldPos = mul(unity_ObjectToWorld, v.vertex); //define worldpos, and pass it to fragment shader
                return o;
               

            }

            float4 frag(v2f i) : SV_Target
            {
                // sample the texture
                //float4 col = tex2D(_MainTex, i.uv);

                // diffuse lighting - lambertion equation
                float3 N = normalize(i.normal); // the normal should be normallized is because of adding glossy to specular light(dont know the real reason)
                float3 L = _WorldSpaceLightPos0.xyz;  // _WorldSpaceLightPos0 is float4 , if the light is directial light then it's (world space direction, 0),other lights(world space position, 1)
                // should make sure that the light is from the object surface to the light source, if the object has color(and could be adjusted along the light(xyz)),it's correct
                float3 lambert = max(0, dot(N, L));
                float disfusseExponent = (exp2(_Gloss1 * 6) + 2); // glossy1 remap
                float3 diffuseLight = pow(lambert, disfusseExponent);
                diffuseLight *= _LightColor0.xyz;// use dot product(lambertion equation) to create the diffuseLight // use max to range the value from 0, to the dot product to aviod the negative value
                // or could use a saturate here(clamp value from 0 to 1 is exactly what max do )



                //specular lighting - phong equation

                float3 V = normalize(_WorldSpaceCameraPos - i.WorldPos); // get the distance between camera and the fragment(both in world space) //use normalize to make it only a vecter
                float3 R = reflect(-L, N); // reflect is a build in function to calculate the reflection of light on a object's surface, -L means we need to reserve the light direction, N is the normal
                float3 specularlight = max(0,dot(V, R));
                specularlight = pow(specularlight, _Gloss); // use pow function to add gloss to specularlight


                //specular lighting - Blinn Phong euqation
                float3 H = normalize(L + V);
                float3 specularlight1 = max(0,dot(H, N)) * (lambert>0); // multiple lambert to debug the light(in the back side)
                float specularexponent = (exp2(_Gloss * 6) + 2); // gloss remap
                specularlight1 = pow(specularlight1, specularexponent) * _Gloss; // use * _Gloss to approximate energy conservation
                specularlight1 *= _LightColor0.xyz;
                                                                        // use swizzling to tranfer a float to float4 // use specularlight1 + diffuseLight to composit light
                                                                         // use diffuselight* _Color to add color on diffuse light, genelly don't use specularlight*_Color unless the 
                                                                           // material is metalic

                float3 fresnal = step(0.6, (1 - dot(V, N)) ) * (sin(_Time.y * 2.5) * 0.5 + 0.5);

                    
                    
                    //(1-dot(V, N))        // use dot(V, N) to add fresnal, 
                

                return float4(specularlight1 + diffuseLight * _Color +fresnal, 1);
                 







            }
            ENDCG
        }
    }
}

Shader "Unlit/Shader1"
{
    Properties //input data,the material of the mesh
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Value("Value", Float) = 1.0 //it defines a property called value
        _Color("Color", Color) = (1,1,1,1)
        
       
        _WaveAmp("WaveAmp", Range(0, 1)) = 0

        _Scale("UV Scale", Float) = 1.0
        _Offset("UV offset", Float) = 0
        




    }
        SubShader
    {
        Tags { "RenderType" = "Transparent"
               "Queue" = "Transparent"
        
        
             }

              // tag to inform unity pipeline what type this is
               
                // render order; skybox - opaque - transparent - overlay
        
   
        
         // it has different tags, opaque means geomatry; 
        LOD 100

        Pass
        { //hlsl coding language 
            //ZWrite Off
            //cull off
            Blend One One
            CGPROGRAM
            #pragma vertex vert   // this is the vertex shader, which call the function of vert 
            #pragma fragment frag // this is the fragment shader, which call the function frag
            // make fog work
            #pragma multi_compile_fog
            #define TAU 6.28318530718
            #include "UnityCG.cginc"

            float4 _Color; //use a varaibe to call the property defined before;
            
            float _Scale;
            float _Offset;
            float _ColorStart;
            float _ColorEnd;
            float _WaveAmp;




            struct Meshdata // define per-vertex mesh data
            {
                float4 vertex : POSITION; // when dealing with mesh data, usually use float4 // vertex position // : means pass the position value to the vertex
                float2 uv0 : TEXCOORD0; // uv coordinates, which part of the texture is projected to which part of the mesh // uv channel 0 //uv0 diffuse/normal map textures 
                // float2 uv1 : TEXCOORD1; // uv channel 1 // uv1 coordinates lightmap coordinates 
                // float2 uv2 : TEXCOORD2; // uv channel 2
                // normal means the direction of the vertex is pointing
                float3 normals : NORMAL;
                // the normal direction contains three directions data so it naturally a float3
                // float4 color : COLOR;
               // float4 tangent : TANGENT;
                // unity first three component is the direction of the tangent, the forth component contains a sin information, like weather or not it flipped or if uvs are mirrored



            };

            struct v2f //v2f means the data passed from vertex shader to fragment shader // the data need to be passed is because the normal is only have on the vertex, but the fragement is a area of pixels, there are somewhere maybe dont contain normals, but the eg. color need to
                // be blended over here, so it need to be interpolating 
            {
                float2 uv0  : TEXCOORD0;
                //float2 uv1  : TEXCOORD1;
                //float2 uv2  : TEXCOORD2;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION; //SV_means clip space position //convert from local space to clip space
                float3 normal : TEXCOORD1; // in the v2f(interpolator) the texcoord1 is only a index, but in meshdata the texcood means specifically the uv coordinate

                    

            };

            sampler2D _MainTex;
            float4 _MainTex_ST;


            float GetWave (float2 uv0) 
            {
                float2 uvcentered = (uv0 * 2 - 1); // transfer the uv from (0,1) to (-1,1); (0,1)x2-1 = (-1,1);
                float radiusdistance = length(uvcentered); // use each vertex's distance from center to create the shape

               // return float4 (radiusdistance.xxx, 1);


                float shape = cos((radiusdistance - _Time.y * 0.1) * 5 * TAU);//TAU make sure that the cos is in a whole peried
                //float topBottomRemover = (abs(i.normal.y) < 0.999);


                float wave = shape;
                wave *= (1 - radiusdistance)*2; // fade out in the four edges

                //use 1- to reverse the uv coordinate
                // t *= i.uv0.y is used to fade out, 0 is black, 1 is white
                //_Color.a = 0.5f;
                return wave;
            }


            v2f vert (Meshdata v) // we can access the normals and uv coordinates in this function, eg normal map
            {
                v2f o; // o means output

                //float wave = cos(((v.uv0.y*0.5f) - _Time.y * 0.1) * 5 * TAU);
               // float wave2 = cos(((v.uv0.x*0.5f) + _Time.y * 0.1) * 5 * TAU);
               // v.vertex.y = wave * wave2 * _WaveAmp;
                //v.vertex.y = GetWave(v.uv0)*_WaveAmp;
                o.vertex = UnityObjectToClipPos(v.vertex);// convert from local space to clip space
                // if it is o.vertex = v.vertex; the it gona be stucked to the camera. it usually be used as the post-porcessing, shince the post processing stuff is a global thing, it could be ike a filter on the camera
                o.normal = UnityObjectToWorldNormal(v.normals); // pass the normals from the meshdata
                // unityobjecttoworldnormal means tranfer the normals from the mesh matrix to world matrix by multiply by shaders
                // it usually be finished in the vertex shader since the we want to optimize the shader spead. so we make the computer to consider the vertex in mesh
                // rather the pixels(fragment)
                o.uv0 = (v.uv0 + _Offset)  * _Scale;
                //uv coordnate is basically put a 2D texture on a 3D mesh

                  

            
                
                return o;
            }


            // float (32 bit float)
            // half(16 bit float)
            //fixed (lower precision) -1 to 1
            // float 4 ->half4 -> fixed4
            // float4x4 -> half4x4 (matrix 4x4)

            // create the inverselerp function
            float Inverselerp(float a, float b, float v) 
            {
                return((v - a) / (b - a));

            }

            fixed4 frag(v2f i) : SV_Target // the : means the data should be passed to frame buffer

            {

                // the vertex on the uv is two dimention vector
                //float2 uvcentered = (i.uv0 * 2 - 1); // transfer the uv from (0,1) to (-1,1); (0,1)x2-1 = (-1,1);
                //float radiusdistance = length(uvcentered); // use each vertex's distance from center to create the shape

               // return float4 (radiusdistance.xxx, 1);


                //float shape = cos((radiusdistance -_Time.y * 0.1) * 5 * TAU)*0.5 + 0.5;//TAU make sure that the cos is in a whole peried
                //float topBottomRemover = (abs(i.normal.y) < 0.999);


                //float wave = shape;
                //wave *= (1-radiusdistance)*2; // fade out in the four edges

                //use 1- to reverse the uv coordinate
                // t *= i.uv0.y is used to fade out, 0 is black, 1 is white
                //_Color.a = 0.5f;
                return GetWave(i.uv0)*_Color;

           

            }
            ENDCG
        }
    }
}

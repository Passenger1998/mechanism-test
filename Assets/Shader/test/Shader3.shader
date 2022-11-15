Shader "Unlit/Shader1"
{
    Properties //input data,the material of the mesh
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Value("Value", Float) = 1.0 //it defines a property called value
        _ColorA("ColorA", Color) = (1,1,1,1)
        _ColorB("ColorB", Color) = (1,1,1,1)
        //_ColorStart("ColorStart", Range(0,1)) = 0;
        //_ColorEnd("ColorEnd", Range(0, 1)) = 1;

        _Scale("UV Scale", Float) = 1.0
        _Offset("UV offset", Float) = 0
        




    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" } // it has different tags, opaque means transparent; 
        LOD 100

        Pass
        { //hlsl coding language 
            CGPROGRAM
            #pragma vertex vert   // this is the vertex shader, which call the function of vert 
            #pragma fragment frag // this is the fragment shader, which call the function frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            float4 _ColorA; //use a varaibe to call the property defined before;
            float4 _ColorB;
            float _Scale;
            float _Offset;
           // float _ColorStart;
            //float _ColorEnd;



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
              
            v2f vert (Meshdata v) // we can access the normals and uv coordinates in this function, eg normal map
            {
                v2f o; // o means output
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




            fixed4 frag(v2f i) : SV_Target // the : means the data should be passed to frame buffer

            {   // float4 myValue;
               //  float2 othervalue = myValue.gr; //swizzling

                // blend between two colors based on x arxs of the uv coordinates, colorA and B are two colors an the i.uv.x is the interpeateor

                // lerp
                float4 outColor = lerp(_ColorA, _ColorB, i.uv0.x);
                //return _Color;
                return outColor;
            // color = vertex, use colors to see how the uv is mapped on the mesh 

            }
            ENDCG
        }
    }
}

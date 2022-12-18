#include "UnityCG.cginc"
#include "Lighting.cginc"// to use the _WorldSpaceLightPos0, should include "Lighting.cginc" and "AutoLight.cginc"
#include "AutoLight.cginc"
#define TAU 6.28318530718
#define USE_LIGHTING
struct meshdata
{
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;
    float3 normal : NORMAL;
    float4 tangent : TANGENT; //xyz is dirction, w is tangent sign

};

struct v2f
{
    float2 uv : TEXCOORD0;

    float4 vertex : SV_POSITION;
    float3 normal : TEXCOORD1;
    float3 WorldPos : TEXCOORD2;
    float3 tangent : TEXCOORD3;
    float3 bitangent : TEXCOORD4;
    LIGHTING_COORDS(5,6)


};

sampler2D  _SpaceShipAlbedo;
sampler2D _SpaceShipNormals;
float4  _SpaceShipAlbedo_ST;
float _Gloss;
float _Gloss1;
float4 _Color;



v2f vert(meshdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = TRANSFORM_TEX(v.uv, _SpaceShipAlbedo);
    o.normal = UnityObjectToWorldNormal(v.normal);
    o.tangent = UnityObjectToWorldDir(v.tangent.xyz);
    o.bitangent = cross(o.normal, o.tangent);
    o.bitangent *= v.tangent.w * unity_WorldTransformParams.w; //filp the uv, either be 1 or -1, handle flipping and mirroring
    o.WorldPos = mul(unity_ObjectToWorld, v.vertex);

    
    TRANSFER_VERTEX_TO_FRAGMENT(o);//lighting
    return o;

}

float4 frag(v2f i) : SV_Target
{
    // sample the texture
    float3 spaceshipColor = tex2D(_SpaceShipAlbedo, i.uv);
    //Tint
    float3 surfaceColor = spaceshipColor * _Color.rgb * (sin(_Time.y * 3) * 0.3 + 0.5) * TAU;
    float3 tangentSpaceNormal = UnpackNormal(tex2D(_SpaceShipNormals, i.uv))*0.5+0.5;
    float3x3 mtxTangToWorld = {
        i.tangent.x, i.bitangent.x, i.normal.x,
        i.tangent.y, i.bitangent.y, i.normal.y,
        i.tangent.z, i.bitangent.z, i.normal.z

    };
    float3 N = mul(tangentSpaceNormal, mtxTangToWorld);

    #ifdef USE_LIGHTING

        // diffuse lighting - lambertion equation
        //float3 N = normalize(i.normal);
        float3 L = UnityWorldSpaceLightDir(i.WorldPos);
        float attenuation = LIGHT_ATTENUATION(i);
        float3 lambert = max(0, dot(N, L));
        float disfusseExponent = (exp2(_Gloss1 * 6) + 2);
        float3 diffuseLight = pow(lambert, disfusseExponent);
        diffuseLight *= attenuation * _LightColor0.xyz;





        //specular lighting - Blinn Phong euqation
        float3 R = reflect(-L, N);
        float3 V = normalize(_WorldSpaceCameraPos - i.WorldPos);
        float3 H = normalize(L + V);
        float3 specularlight1 = max(0,dot(H, N)) * (lambert > 0);
        float specularexponent = (exp2(_Gloss * 6) + 2);
        specularlight1 = pow(specularlight1, specularexponent) * _Gloss;
        specularlight1 *= attenuation * _LightColor0.xyz;

 
        //float3 fresnal = step(0.6, (1 - dot(V, N))) * (sin(_Time.y * 2.5) * 0.5 + 0.5);






        return float4(specularlight1 + diffuseLight* surfaceColor, 1);

    #else
        #ifdef IS_IN_BASE_PATH

            return float4 (surfaceColor,1);
        #else
            return 0;
        #endif



    #endif




   










}

#include "UnityCG.cginc"
#include "Lighting.cginc"// to use the _WorldSpaceLightPos0, should include "Lighting.cginc" and "AutoLight.cginc"
#include "AutoLight.cginc"

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
float _Gloss;
float _Gloss1;
float4 _Color;



v2f vert(meshdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
    o.normal = UnityObjectToWorldNormal(v.normal);
    o.WorldPos = mul(unity_ObjectToWorld, v.vertex);
    return o;


}

float4 frag(v2f i) : SV_Target
{
    // sample the texture
    //float4 col = tex2D(_MainTex, i.uv);

    // diffuse lighting - lambertion equation
    float3 N = normalize(i.normal);
    float3 L = _WorldSpaceLightPos0.xyz;
    float3 lambert = max(0, dot(N, L));
    float disfusseExponent = (exp2(_Gloss1 * 6) + 2);
    float3 diffuseLight = pow(lambert, disfusseExponent);
    diffuseLight *= _LightColor0.xyz;





    //specular lighting - Blinn Phong euqation
    float3 R = reflect(-L, N);
    float3 V = normalize(_WorldSpaceCameraPos - i.WorldPos);
    float3 H = normalize(L + V);
    float3 specularlight1 = max(0,dot(H, N)) * (lambert > 0);
    float specularexponent = (exp2(_Gloss * 6) + 2);
    specularlight1 = pow(specularlight1, specularexponent) * _Gloss;
    specularlight1 *= _LightColor0.xyz;


    //float3 fresnal = step(0.6, (1 - dot(V, N))) * (sin(_Time.y * 2.5) * 0.5 + 0.5);






    return float4(specularlight1 + diffuseLight * _Color, 1);










}

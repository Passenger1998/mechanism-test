Shader "Unlit/MainTextureSpaceShip_Shader"
{
    Properties
    {
        _SpaceShipAlbedo("SpaceShip Albedo", 2D) = "white" {}
        _SpaceShipNormals("SpaceShip Normal", 2D) = "bump" {}
        //_Gloss("Gloss", range(0,1)) = 0.5
        _Gloss1("Gloss1", range(0,1)) = 0.5
        _Color("Color", Color) = (1,1,1,1)
        
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100


            //Base pass
            Pass
            {
                Tags { "Lightmode" = "ForwardBase" }
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #define IS_IN_BASE_PATH
                #include "FGLighting.cginc"
                ENDCG

            }


            //Add pass
            Pass
            {
                Tags { "Lightmode" = "ForwardAdd" }
                Blend One One
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fwdadd
                #include "FGLighting.cginc"
                ENDCG
               
            }
        }
            
}
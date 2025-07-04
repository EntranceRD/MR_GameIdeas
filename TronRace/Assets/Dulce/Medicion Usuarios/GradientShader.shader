Shader "Custom/GradientShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Gradient("Gradient", Range(0, 1)) = 1
    }
        SubShader
        {
            Tags {"Queue" = "Transparent" }
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t
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
                float _Gradient;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                half4 frag(v2f i) : SV_Target
                {
                    half4 col = tex2D(_MainTex, i.uv);
                    col.rgb *= _Gradient;
                    return col;
                }
                ENDCG
            }
        }
}

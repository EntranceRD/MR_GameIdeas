Shader "Custom/OutlineAuraGlow"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _StrokeColor("Stroke Color", Color) = (0, 0.5, 1, 1)
        _AuraColor("Aura Color", Color) = (1, 0, 0, 1)
        _AuraDistance("Aura Pixels", Float) = 30
    }

        SubShader
        {
            Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
            LOD 100
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            Lighting Off

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float4 _MainTex_TexelSize;
                float4 _StrokeColor;
                float4 _AuraColor;
                float _AuraDistance;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 vertex : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                float GetAlpha(float2 uv)
                {
                    return tex2D(_MainTex, clamp(uv, 0.0, 1.0)).a;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float centerAlpha = GetAlpha(i.uv);

                // If this is stroke, return stroke color
                if (centerAlpha >= 0.8)
                    return _StrokeColor;

                // If this is inside the shape (hollow center), return transparent
                // We assume hollow center will be surrounded by pixels with alpha > 0
                // So, if this pixel is fully transparent but surrounded closely by high alpha, it is inside
                float insideCheck = 0.0;
                int innerSampleCount = 8;
                float2 offsetStep = _MainTex_TexelSize.xy * 2.0;

                for (int j = 0; j < innerSampleCount; j++)
                {
                    float angle = UNITY_TWO_PI * j / innerSampleCount;
                    float2 offset = float2(cos(angle), sin(angle)) * offsetStep;
                    insideCheck += GetAlpha(i.uv + offset) >= 0.8 ? 1 : 0;
                }

                if (insideCheck >= 4.0) // Surrounded → inside shape
                    return float4(0, 0, 0, 0);

                // Otherwise, we are outside → check for aura

                float maxGlow = 0.0;
                int steps = 16;
                int maxSteps = 30;
                //float pixelRadius = _AuraDistance;
                float2 texelSize = _MainTex_TexelSize.xy;

                for (int j = 1; j <= maxSteps; j++)
                {
                    float distAlpha = 0.0;
                    //float fade = 1.0 - (float(j) / float(maxSteps));
                    for (int k = 0; k < steps; k++)
                    {
                        float angle = UNITY_TWO_PI * k / steps;
                        float2 offset = float2(cos(angle), sin(angle)) * (j * texelSize);
                        float a = GetAlpha(i.uv - offset); // look inward
                        if (a >= 0.8)
                        {
                            float fade = saturate(1.0 - float(j) / float(maxSteps));
                            distAlpha = fade;
                            //distAlpha = saturate(1.0 - j / pixelRadius);
                            break;
                        }
                    }

                    maxGlow = max(maxGlow, distAlpha);
                    if (maxGlow > 0) break; // early exit for performance
                }

                if (maxGlow > 0)
                    //return float4(1,1,0,1);
                    return float4(_AuraColor.rgb, _AuraColor.a * maxGlow);

                return float4(0, 0, 0, 0); // fully transparent
            }
            ENDCG
        }
        }
}

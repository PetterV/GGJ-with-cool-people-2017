Shader "Unlit/SonarShader" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_DistRatio ("DistanceFromChar", Float ) = 0.5

		//_DissolveAmount ("Dissolve Ammount", Range(0,1) ) = 0
		_MaxLength ("Max Length", Float ) = 10
		_PulseWidth ("Width", Float ) = 2.0
	}

	SubShader {
		Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
		Pass {
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM

			//Vertices, normal, color, uv

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction

			#include "UnityCG.cginc"

			struct appdata{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f{
				float4 position : SV_POSITION;
				float4 worldPos : TEXCOORD0;
			};

			sampler2D _MainTex;
			float _DissolveAmount;
			float _MaxLength;
			float _PulseWidth;
			float _DistRatio;

			//float4x4 position = unity_ObjectToWorld;


			//Build the object
			v2f vertexFunction(appdata IN){
				v2f OUT;

				OUT.position = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.worldPos = mul(unity_ObjectToWorld, IN.vertex);

				return OUT;
			}

			//Fragment
			//Color it in
			fixed4 fragmentFunction(v2f IN) : SV_Target{
				float desiredDist = _DistRatio * _MaxLength;
				float dist = distance(
								IN.worldPos,
               					float4(0.0, 0.0, 0.0, 1.0)
               					);

				if ( dist < desiredDist && dist > desiredDist - _PulseWidth )
				{
					if ( dist == 0 )
					{
						return float4(0.0, 1.0, 1.0, 1.0 );
					}

					float howfarfrom = _PulseWidth / desiredDist - dist;

					float ratio = ( desiredDist - dist );
					float alpha = lerp(0.0, 1.0, ratio );
					return float4(0, 1.0, 1.0, alpha );
				}

				//float distratio = clamp ( dist / _MaxLength, 0.0, 1.0 );
				//dissolve = lerp( 0.0, 1.0, distratio );
				float4 texColor = float4(1.0, 1.0, 0.0, 0.0 );

				return texColor;
			} 

			ENDCG
		}
	}
}

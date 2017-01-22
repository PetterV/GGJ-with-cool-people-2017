Shader "Unlit/SonarShader1" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_DistRatio ("DistanceFromChar", Float ) = 0.5
		_PlayerPos ( "Player position", Vector ) = (0,0,0,0)

		//_DissolveAmount ("Dissolve Ammount", Range(0,1) ) = 0
		_MaxLength ("Max Length", Float ) = 10
		_FadePoint ("Fade point", Range(0,1) ) = 0.8
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
			float _FadePoint;
			float _PulseWidth;
			float _DistRatio;
			float4 _PlayerPos;

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
				float maxdist = _DistRatio * _MaxLength;
				float dist = distance( IN.worldPos, _PlayerPos );
				
				//fade from halfway point
				float alphaMult = 1;
				float fadepoint = _MaxLength * _FadePoint;

				if( dist > fadepoint )
				{
					alphaMult = ( _MaxLength - dist ) / ( _MaxLength - fadepoint );
				}

				if ( dist < maxdist && dist > maxdist - _PulseWidth )
				{
					if ( dist == 0 || dist == maxdist )
					{
						return float4(1.0, 1.0, 1.0, 1.0 * alphaMult);
					}
					else if ( dist > maxdist - ( _PulseWidth / 5.0 ) )
					{
						float minDist = maxdist - _PulseWidth / 5.0;
						float alpha = ( ( maxdist - dist ) / ( maxdist - minDist ) );
						return float4(1, 1.0, 1.0, alpha * alphaMult);
					}

					float minDist = maxdist - _PulseWidth;
					float alpha = 1.0 - ( ( maxdist - dist ) / ( maxdist - minDist ) );
					return float4(1, 1.0, 1.0, alpha * alphaMult );
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

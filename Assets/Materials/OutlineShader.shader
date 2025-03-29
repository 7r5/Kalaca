Shader "Custom/GlowOutlineShader"
{
    SubShader
    {
        Tags { "Queue"="Overlay" }
        
        // Pass para el contorno (glow)
        Pass
        {
            Name "OUTLINE"
            ZWrite On
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            // Configuraci�n para dibujar el contorno
            Offset 10, 10  // Aumenta la distancia de los v�rtices para crear el contorno
            Cull Front  // Dibuja solo las caras traseras para crear el contorno
            Lighting Off  // Desactiva la iluminaci�n para el contorno
            Fog { Mode Off }  // Desactiva la niebla si est� activada

            // Aqu� estamos asignando el color del contorno
            // Puedes cambiar este color a tu gusto, aqu� es verde
            Color (0, 1, 0, 1) // Verde, pero puedes cambiarlo a cualquier color

            SetTexture[_MainTex]
            {
                combine primary
            }

            // Color del contorno (puedes ajustar el color aqu�)
        }

      
    }

    FallBack "Diffuse"
}

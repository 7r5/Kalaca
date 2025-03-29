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

            // Configuración para dibujar el contorno
            Offset 10, 10  // Aumenta la distancia de los vértices para crear el contorno
            Cull Front  // Dibuja solo las caras traseras para crear el contorno
            Lighting Off  // Desactiva la iluminación para el contorno
            Fog { Mode Off }  // Desactiva la niebla si está activada

            // Aquí estamos asignando el color del contorno
            // Puedes cambiar este color a tu gusto, aquí es verde
            Color (0, 1, 0, 1) // Verde, pero puedes cambiarlo a cualquier color

            SetTexture[_MainTex]
            {
                combine primary
            }

            // Color del contorno (puedes ajustar el color aquí)
        }

      
    }

    FallBack "Diffuse"
}

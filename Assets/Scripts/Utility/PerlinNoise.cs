using UnityEngine;
using Random = UnityEngine.Random;

public class PerlinNoise
{
    #region --Fields / Properties--
    
    /// <summary>
    /// Controls the random X offset of the Perlin noise graph.
    /// </summary>
    private static float _xOffset;
    
    /// <summary>
    /// Controls the random Y offset of the Perlin noise graph.
    /// </summary>
    private static float _yOffset;

    #endregion

    #region --Custom Methods--

    /// <summary>
    /// Calculate random values to be used from the Perlin noise graph and return their values as a Vector3.
    /// </summary>
    private static Vector3 CalculatePerlinNoise()
    {
        _xOffset += .1f;
        _yOffset += .1f;
        
        float _random = Random.Range(-5.0f, 5.0f);
        float _perlinNoise = Mathf.PerlinNoise(_xOffset, _yOffset);

        Vector3 _position = Vector3.zero;
        _position.x += _perlinNoise * _random;
        _random = Random.Range(-5.0f, 5.0f);
        _position.y += _perlinNoise * _random;
        _position.z += Random.Range(_position.x, _position.y);

        return _position;
    }

    public static Vector3 GetPerlinNoise()
    {
        return CalculatePerlinNoise();
    }
    
    #endregion
}

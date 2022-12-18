using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace APIShift.AsepriteAnimationWorkflow
{
  [Serializable]
  public class AsepriteImporterSettings
  {
    const string CannotBeChanged = "(对于Aseprite导入不能更改)";

    private static Dictionary<SpriteAlignment, Vector2> _fixedPivots
      = new Dictionary<SpriteAlignment, Vector2>
      {
        [SpriteAlignment.Center] = new Vector2(0.5f, 0.5f),
        [SpriteAlignment.TopLeft] = new Vector2(0f, 1f),
        [SpriteAlignment.TopCenter] = new Vector2(0.5f, 1f),
        [SpriteAlignment.TopRight] = new Vector2(1f, 1f),
        [SpriteAlignment.LeftCenter] = new Vector2(0f, 0.5f),
        [SpriteAlignment.RightCenter] = new Vector2(1f, 0.5f),
        [SpriteAlignment.BottomLeft] = new Vector2(0f, 0f),
        [SpriteAlignment.BottomCenter] = new Vector2(0.5f, 0f),
        [SpriteAlignment.BottomRight] = new Vector2(1f, 0f)
      };

    [Tooltip(CannotBeChanged)]
    public TextureImporterType TextureType = TextureImporterType.Sprite;

    [Tooltip(CannotBeChanged)]
    public TextureImporterShape TextureShape = TextureImporterShape.Texture2D;

    [Tooltip(CannotBeChanged)]
    public SpriteImportMode SpriteMode = SpriteImportMode.Multiple;

    [Tooltip("在Sprite中的多少个像素对应于世界中的一个单位。")]
    public int PixelsPerUnit = 100;

    [Tooltip("要生成的Sprite网格的类型。")]
    public SpriteMeshType MeshType = SpriteMeshType.Tight;

    [Range(0, 32)]
    [Tooltip("在生成的网格中，要在Sprite周围留下多少空白区域。")]
    public uint ExtrudeEdges = 1;

    [Tooltip("Sprite在其局部空间的支点。")]
    public SpriteAlignment Pivot = SpriteAlignment.Center;

    [SerializeField]
    private Vector2 _pivot = new Vector2(0.5f, 0.5f);
    public Vector2 PivotValue
    {
      get => _fixedPivots.TryGetValue(Pivot, out Vector2 result) ? result : _pivot;
      set => _pivot = value;
    }

    [Tooltip("从Sprite的轮廓生成一个默认的物理学形状。")]
    public bool GeneratePhysicsShape = true;

    public TextureWrapMode WrapMode = TextureWrapMode.Clamp;

    public FilterMode FilterMode = FilterMode.Point;

    [Range(0, 32)]
    [Tooltip(CannotBeChanged)]
    public int AnisoLevel = 1;

    [Range(0, 32)]
    [Tooltip("在生成的Sprite的边缘增加额外的像素空间。(枢轴被调整以适应)")]
    public int InnerPadding = 0;
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using Sirenix.OdinInspector;

[ExecuteAlways]
public class PicLine : ImmediateModeShapeDrawer
{
    [SerializeField][Range(-9, 9)] float _xOnTimeline = 0;
    float TIMELINEHEIGHT = 1f;

    public override void DrawShapes(Camera cam)
    {
        using (Draw.Command(cam))
        {
            PolylinePath polylinePath = new PolylinePath();

            polylinePath.AddPoint((Vector2)transform.position);
            polylinePath.AddPoint(new Vector2(_xOnTimeline, TIMELINEHEIGHT));

            Draw.Polyline(polylinePath, false, 0.025f, Color.white);
        }

    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using Sirenix.OdinInspector;

[ExecuteAlways]
public class PicLine : ImmediateModeShapeDrawer
{
    [SerializeField][Range(-9, 9)] float _xOnTimeline = 0;
    float TIMELINEHEIGHT = 0f;

    public override void DrawShapes(Camera cam)
    {
        using (Draw.Command(cam, UnityEngine.Rendering.Universal.RenderPassEvent.BeforeRenderingOpaques))
        {
            PolylinePath polylinePath = new PolylinePath();

            polylinePath.AddPoint(new Vector3(transform.position.x, transform.position.y, 1));
            polylinePath.AddPoint(new Vector3(_xOnTimeline, TIMELINEHEIGHT, 1));

            Draw.Polyline(polylinePath, false, 0.025f, Color.white);
        }

    }

}



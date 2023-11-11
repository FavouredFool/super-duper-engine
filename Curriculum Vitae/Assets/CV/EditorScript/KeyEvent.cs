using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using Sirenix.OdinInspector;

[ExecuteAlways]
public class KeyEvent : ImmediateModeShapeDrawer
{
    [SerializeField][Range(-9, 9)] float _xOnTimeline = 0;

    [SerializeField] bool _isRange = false;
    [SerializeField][Range(-9, 9)][EnableIf("_isRange")] float _x2OnTimeline = 0;
    [SerializeField][Range(0, 2)][EnableIf("_isRange")] float _distanceFromTimeline = 0.2f;


    float TIMELINEHEIGHT = 0f;

    public override void DrawShapes(Camera cam)
    {
        using (Draw.Command(cam, UnityEngine.Rendering.Universal.RenderPassEvent.BeforeRenderingOpaques))
        {
            PolylinePath polylinePath = new PolylinePath();

            polylinePath.AddPoint(new Vector3(transform.position.x, transform.position.y, 1));
            polylinePath.AddPoint(new Vector3(_xOnTimeline, transform.position.y, 1));
            polylinePath.AddPoint(new Vector3(_xOnTimeline, TIMELINEHEIGHT, 1));

            Draw.Polyline(polylinePath, false, 0.025f, Color.white);

            if (_isRange)
            {
                PolylinePath path2 = new PolylinePath();

                float height = (TIMELINEHEIGHT - _distanceFromTimeline);

                path2.AddPoint(new Vector3(_x2OnTimeline, TIMELINEHEIGHT, 1));
                path2.AddPoint(new Vector3(_x2OnTimeline, height, 1));
                path2.AddPoint(new Vector3(_xOnTimeline, height, 1));

                Draw.Polyline(path2, false, 0.025f, Color.white);
            }
        }

    }

}



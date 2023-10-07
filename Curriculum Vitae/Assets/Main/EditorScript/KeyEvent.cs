using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using Sirenix.OdinInspector;

[ExecuteAlways]
public class KeyEvent : ImmediateModeShapeDrawer
{
    [SerializeField][Range(-8, 8)] float _xOnTimeline = 0;

    [SerializeField] bool _isRange = false;
    [SerializeField][Range(-8, 8)][EnableIf("_isRange")] float _x2OnTimeline = 0;
    [SerializeField][Range(0, 2)][EnableIf("_isRange")] float _distanceFromTimeline = 0.2f;


    float TIMELINEHEIGHT = 1f;

    public override void DrawShapes(Camera cam)
    {
        using (Draw.Command(cam))
        {
            PolylinePath polylinePath = new PolylinePath();

            polylinePath.AddPoint((Vector2)transform.position);
            polylinePath.AddPoint(new Vector2(_xOnTimeline, transform.position.y));
            polylinePath.AddPoint(new Vector2(_xOnTimeline, TIMELINEHEIGHT));

            Draw.Polyline(polylinePath, false, 0.025f, Color.white);

            if (_isRange)
            {
                PolylinePath path2 = new PolylinePath();

                float height = (TIMELINEHEIGHT - _distanceFromTimeline);

                path2.AddPoint(new Vector2(_x2OnTimeline, TIMELINEHEIGHT));
                path2.AddPoint(new Vector2(_x2OnTimeline, height));
                path2.AddPoint(new Vector2(_xOnTimeline, height));

                Draw.Polyline(path2, false, 0.025f, Color.white);
            }
        }

    }

}



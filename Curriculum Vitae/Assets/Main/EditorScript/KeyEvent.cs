using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;


[ExecuteAlways]
public class KeyEvent : ImmediateModeShapeDrawer
{
    [SerializeField] [Range(-8, 8)] float _xOnTimeline = 0;

    public override void DrawShapes(Camera cam)
    {

        using (Draw.Command(cam))
        {
            PolylinePath polylinePath = new PolylinePath();

            polylinePath.AddPoint((Vector2)transform.position);
            polylinePath.AddPoint(new Vector2(_xOnTimeline, transform.position.y));
            polylinePath.AddPoint(new PolylinePoint(new Vector2(_xOnTimeline, 0)));

            Draw.Polyline(polylinePath, false, 0.025f, Color.white);
        }

    }

}



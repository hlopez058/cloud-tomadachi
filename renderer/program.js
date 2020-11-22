


function draw_strokes(ctx,strokes) {
    for (i = 0; i < strokes.length; ++i)
    {   
        points = strokes[i]
        ctx.beginPath();
        ctx.moveTo(points[0].X, points[0].Y);
        for (k = 1; k < points.length; ++k)
        {
            p = points[k]
            ctx.lineTo(p.X, p.Y);
        }
        ctx.stroke();
    }
}




function get_strokes() {
    p = [
        new PointF(57, 80),
        new PointF(74, 71),
        new PointF(97, 70),
        new PointF(113, 78)
    ]
    
    q = [
        new PointF(61, 47),
        new PointF(81, 49),
        new PointF(100, 61),
        new PointF(115,80)
    ]
    
    u = [
        new PointF(57, 60),
        new PointF(74, 51),
        new PointF(97, 50),
        new PointF(113, 58)
    ]
    return [p,q,u];
}


class PointF{
    constructor(X, Y) {
        this.X = X;
        this.Y = Y;
      }
}

function TweenCurves(p, q,t) {
    var s = 1 - t;
    var r = [];
    for (i = 0; i < r.length; ++i)
    {
        r[i].append(new PointF(p[i].X * s + q[i].X * t, p[i].Y * s + q[i].Y * t));
    }
    return r;
}

function get_tweened_stroke(strokes,t) {
    var tweens = t
    var k=0
    while(tweens.length > 1){
        k = k+1
        for (i = 0; i < strokes.length +1 ; i++)
        {
            s1 = strokes[i]
            s2 = strokes[i+1]
            tweens.append(TweenCurves(s1,s2,t[i]/(t[k]+t[i])))
        }
    }

    return tweens[0];
}

var c = document.getElementById("myCanvas");
var ctx = c.getContext("2d");
strokes = get_strokes();
draw_strokes(ctx,strokes)

//var t = [0.3, 0.5, 0.2];
//t_stroke = get_tweened_stroke(strokes,t)
//draw_strokes(ctx,t_stroke)




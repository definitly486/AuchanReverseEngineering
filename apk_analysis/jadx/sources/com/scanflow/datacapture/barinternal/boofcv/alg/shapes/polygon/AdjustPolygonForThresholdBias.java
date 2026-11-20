package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon;

import com.scanflow.datacapture.barinternal.georegression.geometry.UtilLine2D_F64;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPolygons2D_F64;
import com.scanflow.datacapture.barinternal.georegression.metric.Intersection2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;

/* JADX INFO: loaded from: classes.dex */
public class AdjustPolygonForThresholdBias {
    private final DogArray segments = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.AdjustPolygonForThresholdBias$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new LineSegment2D_F64();
        }
    });
    private final LineGeneral2D_F64 ga = new LineGeneral2D_F64();
    private final LineGeneral2D_F64 gb = new LineGeneral2D_F64();
    private final Point2D_F64 intersection = new Point2D_F64();

    public void process(Polygon2D_F64 polygon2D_F64, boolean z) {
        int i;
        int i2;
        int size = polygon2D_F64.size();
        this.segments.resize(size);
        int i3 = size - 1;
        int i4 = i3;
        int i5 = 0;
        while (i5 < size) {
            if (z) {
                i2 = i5;
            } else {
                i2 = i4;
                i4 = i5;
            }
            Point2D_F64 point2D_F64 = polygon2D_F64.get(i4);
            Point2D_F64 point2D_F65 = polygon2D_F64.get(i2);
            double d = point2D_F65.x - point2D_F64.x;
            double d2 = point2D_F65.y - point2D_F64.y;
            double dSqrt = Math.sqrt((d * d) + (d2 * d2));
            if (dSqrt == 0.0d) {
                throw new RuntimeException("Two identical corners!");
            }
            if (d < 0.0d) {
                d = 0.0d;
            }
            if (d2 > 0.0d) {
                d2 = 0.0d;
            }
            LineSegment2D_F64 lineSegment2D_F64 = (LineSegment2D_F64) this.segments.get(i4);
            Point2D_F64 point2D_F66 = lineSegment2D_F64.a;
            int i6 = i5;
            double d3 = d2 / dSqrt;
            point2D_F66.x = point2D_F64.x - d3;
            double d4 = d / dSqrt;
            point2D_F66.y = point2D_F64.y + d4;
            Point2D_F64 point2D_F67 = lineSegment2D_F64.b;
            point2D_F67.x = point2D_F65.x - d3;
            point2D_F67.y = point2D_F65.y + d4;
            i5 = i6 + 1;
            i4 = i6;
        }
        int i7 = i3;
        for (int i8 = 0; i8 < size; i8++) {
            if (z) {
                i = i8;
            } else {
                i = i7;
                i7 = i8;
            }
            UtilLine2D_F64.convert((LineSegment2D_F64) this.segments.get(i7), this.ga);
            UtilLine2D_F64.convert((LineSegment2D_F64) this.segments.get(i), this.gb);
            if (Intersection2D_F64.intersection(this.ga, this.gb, this.intersection) != null && this.intersection.distance2(polygon2D_F64.get(i)) < 20.0d) {
                polygon2D_F64.get(i).setTo(this.intersection);
            }
            i7 = i8;
        }
        UtilPolygons2D_F64.removeAdjacentDuplicates(polygon2D_F64, 1.0E-8d);
    }
}

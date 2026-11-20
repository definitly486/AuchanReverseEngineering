package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge;

import com.scanflow.datacapture.barinternal.georegression.metric.Distance2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineParametric2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class MaximumLineDistance implements SplitSelector {
    LineParametric2D_F64 line = new LineParametric2D_F64();

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.SplitSelector
    public void selectSplitPoint(List list, int i, int i2, PolylineSplitMerge.SplitResults splitResults) {
        PolylineSplitMerge.assignLine(list, i, i2, this.line);
        if (i2 >= i) {
            splitResults.index = i;
            splitResults.score = -1.0d;
            for (int i3 = i + 1; i3 < i2; i3++) {
                Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i3);
                double dDistanceSq = Distance2D_F64.distanceSq(this.line, point2D_I32.x, point2D_I32.y);
                if (dDistanceSq > splitResults.score) {
                    splitResults.score = dDistanceSq;
                    splitResults.index = i3;
                }
            }
            return;
        }
        splitResults.index = i;
        splitResults.score = -1.0d;
        int size = (list.size() - i) + i2;
        for (int i4 = 1; i4 < size; i4++) {
            int size2 = (i + i4) % list.size();
            Point2D_I32 point2D_I33 = (Point2D_I32) list.get(size2);
            double dDistanceSq2 = Distance2D_F64.distanceSq(this.line, point2D_I33.x, point2D_I33.y);
            if (dDistanceSq2 > splitResults.score) {
                splitResults.score = dDistanceSq2;
                splitResults.index = size2;
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.SplitSelector
    public int compareScore(double d, double d2) {
        if (d > d2) {
            return 1;
        }
        return d < d2 ? -1 : 0;
    }
}

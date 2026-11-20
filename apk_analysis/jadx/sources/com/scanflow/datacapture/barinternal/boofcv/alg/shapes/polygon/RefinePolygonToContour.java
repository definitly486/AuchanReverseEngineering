package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon;

import com.scanflow.datacapture.barinternal.georegression.fitting.line.FitLine_I32;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilLine2D_F64;
import com.scanflow.datacapture.barinternal.georegression.metric.Intersection2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LinePolar2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class RefinePolygonToContour {
    private final List work = new ArrayList();
    private final LinePolar2D_F64 polar = new LinePolar2D_F64();
    private final DogArray lines = new DogArray(new RefinePolygonToContour$$ExternalSyntheticLambda0());

    public void process(List list, DogArray_I32 dogArray_I32, Polygon2D_F64 polygon2D_F64) {
        int i;
        int i2;
        int i3 = dogArray_I32.size - 1;
        int i4 = 0;
        int i5 = 0;
        while (true) {
            i = dogArray_I32.size;
            if (i4 >= i) {
                break;
            }
            if (dogArray_I32.get(i3) > dogArray_I32.get(i4)) {
                i5++;
            }
            i3 = i4;
            i4++;
        }
        boolean z = i5 > 1;
        polygon2D_F64.vertexes.resize(i);
        this.lines.resize(dogArray_I32.size);
        int i6 = dogArray_I32.size - 1;
        int i7 = 0;
        while (true) {
            i2 = dogArray_I32.size;
            if (i7 >= i2) {
                break;
            }
            int i8 = dogArray_I32.get(i6);
            int i9 = dogArray_I32.get(i7);
            if (z) {
                i9 = i8;
                i8 = i9;
            }
            if (i8 > i9) {
                this.work.clear();
                while (i8 < list.size()) {
                    this.work.add((Point2D_I32) list.get(i8));
                    i8++;
                }
                for (int i10 = 0; i10 < i9; i10++) {
                    this.work.add((Point2D_I32) list.get(i10));
                }
                List list2 = this.work;
                FitLine_I32.polar(list2, 0, list2.size(), this.polar);
            } else {
                FitLine_I32.polar(list, i8, i9 - i8, this.polar);
            }
            UtilLine2D_F64.convert(this.polar, (LineGeneral2D_F64) this.lines.get(i6));
            i6 = i7;
            i7++;
        }
        int i11 = i2 - 1;
        for (int i12 = 0; i12 < dogArray_I32.size; i12++) {
            Intersection2D_F64.intersection((LineGeneral2D_F64) this.lines.get(i11), (LineGeneral2D_F64) this.lines.get(i12), polygon2D_F64.get(i12));
            i11 = i12;
        }
    }
}

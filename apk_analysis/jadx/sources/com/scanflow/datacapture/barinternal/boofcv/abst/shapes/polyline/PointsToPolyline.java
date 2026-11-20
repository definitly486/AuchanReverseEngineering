package com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline;

import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public interface PointsToPolyline {
    int getMinimumSides();

    boolean isLoop();

    boolean process(List list, DogArray_I32 dogArray_I32);

    void setConvex(boolean z);

    void setMaximumSides(int i);

    void setMinimumSides(int i);
}

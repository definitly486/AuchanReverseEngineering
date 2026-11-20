package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;

/* JADX INFO: loaded from: classes.dex */
public interface RefinePolygonToGray {
    boolean refine(Polygon2D_F64 polygon2D_F64, Polygon2D_F64 polygon2D_F65);

    void setImage(ImageGray imageGray);
}

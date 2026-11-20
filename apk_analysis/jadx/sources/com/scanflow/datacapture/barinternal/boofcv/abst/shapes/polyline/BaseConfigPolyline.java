package com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline;

import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public abstract class BaseConfigPolyline implements Serializable {
    public boolean loops = true;
    public int minimumSides = 3;
    public int maximumSides = Integer.MAX_VALUE;
    public boolean convex = true;
}

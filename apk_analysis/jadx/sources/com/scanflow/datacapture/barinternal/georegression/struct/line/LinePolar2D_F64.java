package com.scanflow.datacapture.barinternal.georegression.struct.line;

import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public class LinePolar2D_F64 implements Serializable {
    public double angle;
    public double distance;

    public String toString() {
        return getClass().getSimpleName() + "{ d = " + this.distance + " angle = " + this.angle + " }";
    }
}

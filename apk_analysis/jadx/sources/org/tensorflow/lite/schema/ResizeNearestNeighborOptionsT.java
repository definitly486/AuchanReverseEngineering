package org.tensorflow.lite.schema;

/* JADX INFO: loaded from: classes4.dex */
public class ResizeNearestNeighborOptionsT {
    private boolean alignCorners = false;
    private boolean halfPixelCenters = false;

    public boolean getAlignCorners() {
        return this.alignCorners;
    }

    public void setAlignCorners(boolean z) {
        this.alignCorners = z;
    }

    public boolean getHalfPixelCenters() {
        return this.halfPixelCenters;
    }

    public void setHalfPixelCenters(boolean z) {
        this.halfPixelCenters = z;
    }
}

package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon;

import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS;
import com.scanflow.datacapture.barinternal.boofcv.factory.interpolate.FactoryInterpolation;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.BorderType;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class ContourEdgeIntensity {
    private final int contourSamples;
    private float edgeInsideAverage;
    private float edgeOutsideAverage;
    private int imageHeight;
    private int imageWidth;
    private final InterpolatePixelS sampler;
    private final int tangentSamples;
    private final float tangentStep;

    public float getEdgeInsideAverage() {
        return this.edgeInsideAverage;
    }

    public float getEdgeOutsideAverage() {
        return this.edgeOutsideAverage;
    }

    public ContourEdgeIntensity(int i, int i2, double d, Class cls) {
        this.contourSamples = i;
        this.tangentSamples = i2;
        this.tangentStep = (float) d;
        this.sampler = FactoryInterpolation.bilinearPixelS(cls, BorderType.EXTENDED);
    }

    public void setImage(ImageGray imageGray) {
        this.sampler.setImage(imageGray);
        this.imageWidth = imageGray.width;
        this.imageHeight = imageGray.height;
    }

    public void process(List list, boolean z) {
        float f;
        if (this.imageWidth == 0) {
            throw new RuntimeException("You didn't call setImage()");
        }
        boolean z2 = true;
        int size = list.size() <= this.contourSamples ? 1 : list.size() / this.contourSamples;
        int iMax = Math.max(1, Math.min(size / 2, 5));
        float f2 = 0.0f;
        this.edgeInsideAverage = 0.0f;
        this.edgeOutsideAverage = 0.0f;
        int i = 0;
        int i2 = 0;
        for (int i3 = 0; i3 < list.size(); i3 += size) {
            Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i3);
            Point2D_I32 point2D_I33 = (Point2D_I32) list.get((i3 + iMax) % list.size());
            float f3 = point2D_I33.x - point2D_I32.x;
            float f4 = point2D_I33.y - point2D_I32.y;
            float fSqrt = (float) Math.sqrt((f3 * f3) + (f4 * f4));
            float f5 = f3 / fSqrt;
            float f6 = f4 / fSqrt;
            int i4 = 0;
            while (i4 < this.tangentSamples) {
                i4++;
                float f7 = i4 * this.tangentStep;
                float f8 = f7 * f6;
                float f9 = point2D_I32.x + f8;
                boolean z3 = z2;
                float f10 = f7 * f5;
                float f11 = point2D_I32.y - f10;
                if (f9 < f2 || f11 < f2) {
                    f = f2;
                } else {
                    f = f2;
                    if (f9 <= this.imageWidth - 1 && f11 <= this.imageHeight - 1) {
                        this.edgeOutsideAverage += this.sampler.get(f9, f11);
                        i++;
                    }
                }
                float f12 = point2D_I32.x - f8;
                float f13 = point2D_I32.y + f10;
                if (f12 >= f && f13 >= f && f12 <= this.imageWidth - 1 && f13 <= this.imageHeight - 1) {
                    this.edgeInsideAverage += this.sampler.get(f12, f13);
                    i2++;
                }
                z2 = z3;
                f2 = f;
            }
        }
        float f14 = this.edgeOutsideAverage / i;
        this.edgeOutsideAverage = f14;
        float f15 = this.edgeInsideAverage / i2;
        this.edgeInsideAverage = f15;
        if (z) {
            return;
        }
        this.edgeOutsideAverage = f15;
        this.edgeInsideAverage = f14;
    }
}

package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.edge;

import com.scanflow.datacapture.barinternal.boofcv.misc.BoofMiscOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;

/* JADX INFO: loaded from: classes.dex */
public class ScoreLineSegmentEdge extends BaseIntegralEdge {
    double averageDown;
    double averageUp;
    int numSamples;
    int samplesInside;

    public ScoreLineSegmentEdge(int i, Class cls) {
        super(cls);
        this.numSamples = i;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.shapes.edge.BaseIntegralEdge
    public void setImage(ImageGray imageGray) {
        this.integralImage.wrap(imageGray);
        this.integral.setImage(this.integralImage);
    }

    public double computeAverageDerivative(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65, double d, double d2) {
        int i = 0;
        this.samplesInside = 0;
        this.averageDown = 0.0d;
        this.averageUp = 0.0d;
        while (true) {
            int i2 = this.numSamples;
            if (i >= i2) {
                break;
            }
            double d3 = point2D_F65.x;
            double d4 = point2D_F64.x;
            double d5 = i;
            double d6 = (((d3 - d4) * d5) / ((double) (i2 - 1))) + d4;
            double d7 = point2D_F65.y;
            double d8 = point2D_F64.y;
            double d9 = (((d7 - d8) * d5) / ((double) (i2 - 1))) + d8;
            double d10 = d6 + d;
            double d11 = d9 + d2;
            if (BoofMiscOps.isInside(this.integralImage.getWidth(), this.integralImage.getHeight(), d10, d11)) {
                double d12 = d6 - d;
                double d13 = d9 - d2;
                if (BoofMiscOps.isInside(this.integralImage.getWidth(), this.integralImage.getHeight(), d12, d13)) {
                    this.samplesInside++;
                    double dCompute = this.integral.compute(d6, d9, d10, d11);
                    double dCompute2 = this.integral.compute(d6, d9, d12, d13);
                    this.averageUp += dCompute;
                    this.averageDown += dCompute2;
                }
            }
            i++;
        }
        int i3 = this.samplesInside;
        if (i3 == 0) {
            return 0.0d;
        }
        double d14 = this.averageUp / ((double) i3);
        this.averageUp = d14;
        double d15 = this.averageDown / ((double) i3);
        this.averageDown = d15;
        return d14 - d15;
    }

    public int getSamplesInside() {
        return this.samplesInside;
    }

    public double getAverageUp() {
        return this.averageUp;
    }

    public double getAverageDown() {
        return this.averageDown;
    }
}

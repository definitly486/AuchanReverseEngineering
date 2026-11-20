package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon;

import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.edge.EdgeIntensityPolygon;
import com.scanflow.datacapture.barinternal.boofcv.misc.MovingAverage;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class DetectPolygonBinaryGrayRefine {
    AdjustPolygonForThresholdBias adjustForBias;
    DetectPolygonFromContour detector;
    private final EdgeIntensityPolygon edgeIntensity;
    double minimumRefineEdgeIntensity;
    private final RefinePolygonToContour refineContour;
    private final RefinePolygonToGray refineGray;
    private final Polygon2D_F64 work = new Polygon2D_F64();
    MovingAverage milliAdjustBias = new MovingAverage(0.8d);

    public DetectPolygonBinaryGrayRefine(DetectPolygonFromContour detectPolygonFromContour, RefinePolygonToContour refinePolygonToContour, RefinePolygonToGray refinePolygonToGray, double d, boolean z) {
        this.detector = detectPolygonFromContour;
        this.refineContour = refinePolygonToContour;
        this.refineGray = refinePolygonToGray;
        this.minimumRefineEdgeIntensity = d;
        if (z) {
            this.adjustForBias = new AdjustPolygonForThresholdBias();
        }
        this.edgeIntensity = new EdgeIntensityPolygon(1.0d, 1.5d, 15, detectPolygonFromContour.getInputType());
    }

    public void process(ImageGray imageGray, GrayU8 grayU8) {
        this.detector.process(imageGray, grayU8);
        RefinePolygonToGray refinePolygonToGray = this.refineGray;
        if (refinePolygonToGray != null) {
            refinePolygonToGray.setImage(imageGray);
        }
        this.edgeIntensity.setImage(imageGray);
        long jNanoTime = System.nanoTime();
        DogArray foundInfo = this.detector.getFoundInfo();
        if (this.adjustForBias != null) {
            int minimumSides = getMinimumSides();
            for (int size = foundInfo.size() - 1; size >= 0; size--) {
                Polygon2D_F64 polygon2D_F64 = ((DetectPolygonFromContour.Info) foundInfo.get(size)).polygon;
                this.adjustForBias.process(polygon2D_F64, this.detector.isOutputClockwiseUpY());
                if (polygon2D_F64.size() < minimumSides) {
                    foundInfo.remove(size);
                }
            }
        }
        this.milliAdjustBias.update((System.nanoTime() - jNanoTime) * 1.0E-6d);
    }

    public boolean refine(DetectPolygonFromContour.Info info) {
        boolean z = false;
        if (this.edgeIntensity.computeEdge(info.polygon, !this.detector.isOutputClockwiseUpY())) {
            double averageOutside = this.edgeIntensity.getAverageOutside() - this.edgeIntensity.getAverageInside();
            if (this.refineContour != null) {
                this.refineContour.process(this.detector.getContour(info), info.splits, this.work);
                AdjustPolygonForThresholdBias adjustPolygonForThresholdBias = this.adjustForBias;
                if (adjustPolygonForThresholdBias != null) {
                    adjustPolygonForThresholdBias.process(this.work, this.detector.isOutputClockwiseUpY());
                }
                if (this.edgeIntensity.computeEdge(this.work, !this.detector.isOutputClockwiseUpY())) {
                    double averageOutside2 = this.edgeIntensity.getAverageOutside() - this.edgeIntensity.getAverageInside();
                    if (averageOutside2 > averageOutside) {
                        info.edgeInside = this.edgeIntensity.getAverageInside();
                        info.edgeOutside = this.edgeIntensity.getAverageOutside();
                        info.polygon.setTo(this.work);
                        z = true;
                        averageOutside = averageOutside2;
                    }
                }
            }
            if (this.refineGray != null) {
                this.work.vertexes.resize(info.polygon.size());
                if (this.refineGray.refine(info.polygon, this.work) && this.edgeIntensity.computeEdge(this.work, !this.detector.isOutputClockwiseUpY()) && (this.edgeIntensity.getAverageOutside() - this.edgeIntensity.getAverageInside()) * 1.5d > averageOutside) {
                    info.edgeInside = this.edgeIntensity.getAverageInside();
                    info.edgeOutside = this.edgeIntensity.getAverageOutside();
                    info.polygon.setTo(this.work);
                    return true;
                }
            }
        }
        return z;
    }

    public List getPolygonInfo() {
        return this.detector.getFoundInfo().toList();
    }

    public Class getInputType() {
        return this.detector.getInputType();
    }

    public int getMinimumSides() {
        return this.detector.getMinimumSides();
    }

    public DetectPolygonFromContour getDetector() {
        return this.detector;
    }

    public double getMilliAdjustBias() {
        return this.milliAdjustBias.getAverage();
    }
}

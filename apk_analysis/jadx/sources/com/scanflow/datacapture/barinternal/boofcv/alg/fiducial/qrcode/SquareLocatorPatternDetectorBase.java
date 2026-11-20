package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourFinder;
import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonBinaryGrayRefine;
import com.scanflow.datacapture.barinternal.boofcv.factory.interpolate.FactoryInterpolation;
import com.scanflow.datacapture.barinternal.boofcv.misc.MovingAverage;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.BorderType;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import java.io.PrintStream;

/* JADX INFO: loaded from: classes.dex */
public abstract class SquareLocatorPatternDetectorBase {
    protected InterpolatePixelS interpolate;
    protected DetectPolygonBinaryGrayRefine squareDetector;
    protected double maxContourFraction = 1.3333333333333333d;
    protected MovingAverage profilingMS = new MovingAverage(0.8d);
    protected PrintStream verbose = null;

    protected abstract void findLocatorPatternsFromSquares();

    public DetectPolygonBinaryGrayRefine getSquareDetector() {
        return this.squareDetector;
    }

    public MovingAverage getProfilingMS() {
        return this.profilingMS;
    }

    protected SquareLocatorPatternDetectorBase(DetectPolygonBinaryGrayRefine detectPolygonBinaryGrayRefine) {
        this.squareDetector = detectPolygonBinaryGrayRefine;
        detectPolygonBinaryGrayRefine.getDetector().setConvex(true);
        detectPolygonBinaryGrayRefine.getDetector().setOutputClockwiseUpY(false);
        detectPolygonBinaryGrayRefine.getDetector().setNumberOfSides(4, 4);
        this.interpolate = FactoryInterpolation.bilinearPixelS(detectPolygonBinaryGrayRefine.getInputType(), BorderType.EXTENDED);
    }

    public void process(ImageGray imageGray, GrayU8 grayU8) {
        configureContourDetector(imageGray);
        this.interpolate.setImage(imageGray);
        this.squareDetector.process(imageGray, grayU8);
        long jNanoTime = System.nanoTime();
        findLocatorPatternsFromSquares();
        this.profilingMS.update((System.nanoTime() - jNanoTime) * 1.0E-6d);
    }

    protected void configureContourDetector(ImageGray imageGray) {
        int iMin = (int) (((double) Math.min(imageGray.width, imageGray.height)) * this.maxContourFraction);
        BinaryContourFinder contourFinder = this.squareDetector.getDetector().getContourFinder();
        contourFinder.setMaxContour(ConfigLength.fixed(iMin));
        contourFinder.setSaveInnerContour(false);
    }
}

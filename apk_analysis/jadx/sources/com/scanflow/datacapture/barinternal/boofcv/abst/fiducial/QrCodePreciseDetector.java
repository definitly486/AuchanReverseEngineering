package com.scanflow.datacapture.barinternal.boofcv.abst.fiducial;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourHelper;
import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary;
import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeDecoderImage;
import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodePositionPatternDetector;
import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodePositionPatternGraphGenerator;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonFromContour;
import com.scanflow.datacapture.barinternal.boofcv.misc.MovingAverage;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class QrCodePreciseDetector implements QrCodeDetector {
    BinaryContourHelper contourHelper;
    QrCodeDecoderImage decoder;
    QrCodePositionPatternDetector detectPositionPatterns;
    Class imageType;
    InputToBinary inputToBinary;
    QrCodePositionPatternGraphGenerator graphPositionPatterns = new QrCodePositionPatternGraphGenerator();
    boolean profiler = false;
    protected MovingAverage milliBinary = new MovingAverage(0.8d);
    protected MovingAverage milliDecoding = new MovingAverage(0.8d);

    public QrCodePositionPatternGraphGenerator getGraphPositionPatterns() {
        return this.graphPositionPatterns;
    }

    public QrCodeDecoderImage getDecoder() {
        return this.decoder;
    }

    public QrCodePreciseDetector(InputToBinary inputToBinary, QrCodePositionPatternDetector qrCodePositionPatternDetector, String str, String str2, boolean z, Class cls) {
        this.inputToBinary = inputToBinary;
        this.detectPositionPatterns = qrCodePositionPatternDetector;
        this.decoder = new QrCodeDecoderImage(str, str2, cls);
        this.imageType = cls;
        this.contourHelper = new BinaryContourHelper(qrCodePositionPatternDetector.getSquareDetector().getDetector().getContourFinder(), z);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.fiducial.QrCodeDetector
    public void process(ImageGray imageGray) {
        long jNanoTime = System.nanoTime();
        this.contourHelper.reshape(imageGray.width, imageGray.height);
        this.inputToBinary.process(imageGray, this.contourHelper.withoutPadding());
        this.milliBinary.update((System.nanoTime() - jNanoTime) * 1.0E-6d);
        if (this.profiler) {
            System.out.printf("qrcode: binary %5.2f ", Double.valueOf(this.milliBinary.getAverage()));
        }
        this.detectPositionPatterns.process(imageGray, this.contourHelper.padded());
        List list = this.detectPositionPatterns.getPositionPatterns().toList();
        this.graphPositionPatterns.process(list);
        if (this.profiler) {
            DetectPolygonFromContour detector = this.detectPositionPatterns.getSquareDetector().getDetector();
            System.out.printf(" contour %5.1f shapes %5.1f adjust_bias %5.2f PosPat %6.2f", Double.valueOf(detector.getMilliContour()), Double.valueOf(detector.getMilliShapes()), Double.valueOf(this.detectPositionPatterns.getSquareDetector().getMilliAdjustBias()), Double.valueOf(this.detectPositionPatterns.getProfilingMS().getAverage()));
        }
        long jNanoTime2 = System.nanoTime();
        this.decoder.process(list, imageGray);
        this.milliDecoding.update((System.nanoTime() - jNanoTime2) * 1.0E-6d);
        if (this.profiler) {
            System.out.printf(" decoding %5.1f\n", Double.valueOf(this.milliDecoding.getAverage()));
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.fiducial.QrCodeDetector
    public List getDetections() {
        return this.decoder.getSuccesses();
    }
}

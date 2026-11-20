package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixelS;
import com.scanflow.datacapture.barinternal.boofcv.core.image.border.FactoryImageBorder;
import com.scanflow.datacapture.barinternal.boofcv.factory.interpolate.FactoryInterpolation;
import com.scanflow.datacapture.barinternal.boofcv.struct.border.BorderType;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F32;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_F32;

/* JADX INFO: loaded from: classes.dex */
public class QrCodeBinaryGridReader {
    int imageHeight;
    int imageWidth;
    InterpolatePixelS interpolate;
    QrCode qr;
    float threshold;
    QrCodeBinaryGridToPixel transformGrid = new QrCodeBinaryGridToPixel();
    Point2D_F32 pixel = new Point2D_F32();

    public QrCodeBinaryGridToPixel getTransformGrid() {
        return this.transformGrid;
    }

    public QrCodeBinaryGridReader(Class cls) {
        InterpolatePixelS interpolatePixelSNearestNeighborPixelS = FactoryInterpolation.nearestNeighborPixelS(cls);
        this.interpolate = interpolatePixelSNearestNeighborPixelS;
        interpolatePixelSNearestNeighborPixelS.setBorder(FactoryImageBorder.single(BorderType.EXTENDED, cls));
    }

    public void setImage(ImageGray imageGray) {
        this.interpolate.setImage(imageGray);
        this.imageWidth = imageGray.width;
        this.imageHeight = imageGray.height;
    }

    public void setMarker(QrCode qrCode) {
        this.qr = qrCode;
        this.transformGrid.addAllFeatures(qrCode);
        this.transformGrid.removeOutsideCornerFeatures();
        this.transformGrid.computeTransform();
        this.threshold = ((float) ((qrCode.threshCorner + qrCode.threshDown) + qrCode.threshRight)) / 3.0f;
    }

    public void setSquare(Polygon2D_F64 polygon2D_F64, float f) {
        this.qr = null;
        this.transformGrid.setTransformFromSquare(polygon2D_F64);
        this.threshold = f;
    }

    public void setMarkerUnknownVersion(QrCode qrCode, float f) {
        this.qr = null;
        this.transformGrid.setTransformFromLinesSquare(qrCode);
        this.threshold = f;
    }

    public void imageToGrid(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65) {
        this.transformGrid.imageToGrid(point2D_F64.x, point2D_F64.y, point2D_F65);
    }

    public void gridToImage(double d, double d2, Point2D_F64 point2D_F64) {
        this.transformGrid.gridToImage((float) d, (float) d2, this.pixel);
        Point2D_F32 point2D_F32 = this.pixel;
        point2D_F64.x = point2D_F32.x;
        point2D_F64.y = point2D_F32.y;
    }

    public float read(float f, float f2) {
        this.transformGrid.gridToImage(f, f2, this.pixel);
        InterpolatePixelS interpolatePixelS = this.interpolate;
        Point2D_F32 point2D_F32 = this.pixel;
        return interpolatePixelS.get(point2D_F32.x, point2D_F32.y);
    }

    public void readBitIntensity(int i, int i2, DogArray_F32 dogArray_F32) {
        float f = i + 0.5f;
        float f2 = i2 + 0.5f;
        this.transformGrid.gridToImage(f - 0.2f, f2, this.pixel);
        InterpolatePixelS interpolatePixelS = this.interpolate;
        Point2D_F32 point2D_F32 = this.pixel;
        dogArray_F32.add(interpolatePixelS.get(point2D_F32.x, point2D_F32.y));
        this.transformGrid.gridToImage(f + 0.2f, f2, this.pixel);
        InterpolatePixelS interpolatePixelS2 = this.interpolate;
        Point2D_F32 point2D_F33 = this.pixel;
        dogArray_F32.add(interpolatePixelS2.get(point2D_F33.x, point2D_F33.y));
        this.transformGrid.gridToImage(f, f2 - 0.2f, this.pixel);
        InterpolatePixelS interpolatePixelS3 = this.interpolate;
        Point2D_F32 point2D_F34 = this.pixel;
        dogArray_F32.add(interpolatePixelS3.get(point2D_F34.x, point2D_F34.y));
        this.transformGrid.gridToImage(f, 0.2f + f2, this.pixel);
        InterpolatePixelS interpolatePixelS4 = this.interpolate;
        Point2D_F32 point2D_F35 = this.pixel;
        dogArray_F32.add(interpolatePixelS4.get(point2D_F35.x, point2D_F35.y));
        this.transformGrid.gridToImage(f, f2, this.pixel);
        InterpolatePixelS interpolatePixelS5 = this.interpolate;
        Point2D_F32 point2D_F36 = this.pixel;
        dogArray_F32.add(interpolatePixelS5.get(point2D_F36.x, point2D_F36.y));
    }

    public int readBit(int i, int i2) {
        float f = i + 0.5f;
        float f2 = i2 + 0.5f;
        this.transformGrid.gridToImage(f - 0.2f, f2, this.pixel);
        InterpolatePixelS interpolatePixelS = this.interpolate;
        Point2D_F32 point2D_F32 = this.pixel;
        float f3 = interpolatePixelS.get(point2D_F32.x, point2D_F32.y);
        this.transformGrid.gridToImage(f + 0.2f, f2, this.pixel);
        InterpolatePixelS interpolatePixelS2 = this.interpolate;
        Point2D_F32 point2D_F33 = this.pixel;
        float f4 = interpolatePixelS2.get(point2D_F33.x, point2D_F33.y);
        this.transformGrid.gridToImage(f, f2 - 0.2f, this.pixel);
        InterpolatePixelS interpolatePixelS3 = this.interpolate;
        Point2D_F32 point2D_F34 = this.pixel;
        float f5 = interpolatePixelS3.get(point2D_F34.x, point2D_F34.y);
        this.transformGrid.gridToImage(f, 0.2f + f2, this.pixel);
        InterpolatePixelS interpolatePixelS4 = this.interpolate;
        Point2D_F32 point2D_F35 = this.pixel;
        float f6 = interpolatePixelS4.get(point2D_F35.x, point2D_F35.y);
        this.transformGrid.gridToImage(f, f2, this.pixel);
        InterpolatePixelS interpolatePixelS5 = this.interpolate;
        Point2D_F32 point2D_F36 = this.pixel;
        float f7 = interpolatePixelS5.get(point2D_F36.x, point2D_F36.y);
        float f8 = this.threshold;
        int i3 = f3 < f8 ? 1 : 0;
        if (f4 < f8) {
            i3++;
        }
        if (f5 < f8) {
            i3++;
        }
        if (f6 < f8) {
            i3++;
        }
        if (f7 < f8) {
            i3++;
        }
        return i3 >= 3 ? 1 : 0;
    }
}

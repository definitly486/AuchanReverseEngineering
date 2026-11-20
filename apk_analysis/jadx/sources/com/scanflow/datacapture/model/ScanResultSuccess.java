package com.scanflow.datacapture.model;

import android.graphics.PointF;
import android.graphics.RectF;
import com.scanflow.datacapture.barinternal.c.a;
import com.scanflow.datacapture.utils.BarcodeFormat;
import java.util.ArrayList;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class ScanResultSuccess {
    private final BarcodeFormat barcodeFormat;
    private final RectF boundingBox;
    private final boolean isLongDistance;
    private final String modelScanType;
    private ArrayList<PointF> points;
    private final String text;

    public ScanResultSuccess(String text, BarcodeFormat barcodeFormat, boolean z, ArrayList<PointF> points, RectF boundingBox, String modelScanType) {
        Intrinsics.checkNotNullParameter(text, "text");
        Intrinsics.checkNotNullParameter(barcodeFormat, "barcodeFormat");
        Intrinsics.checkNotNullParameter(points, "points");
        Intrinsics.checkNotNullParameter(boundingBox, "boundingBox");
        Intrinsics.checkNotNullParameter(modelScanType, "modelScanType");
        this.text = text;
        this.barcodeFormat = barcodeFormat;
        this.isLongDistance = z;
        this.points = points;
        this.boundingBox = boundingBox;
        this.modelScanType = modelScanType;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public static /* synthetic */ ScanResultSuccess copy$default(ScanResultSuccess scanResultSuccess, String str, BarcodeFormat barcodeFormat, boolean z, ArrayList arrayList, RectF rectF, String str2, int i, Object obj) {
        if ((i & 1) != 0) {
            str = scanResultSuccess.text;
        }
        if ((i & 2) != 0) {
            barcodeFormat = scanResultSuccess.barcodeFormat;
        }
        if ((i & 4) != 0) {
            z = scanResultSuccess.isLongDistance;
        }
        if ((i & 8) != 0) {
            arrayList = scanResultSuccess.points;
        }
        if ((i & 16) != 0) {
            rectF = scanResultSuccess.boundingBox;
        }
        if ((i & 32) != 0) {
            str2 = scanResultSuccess.modelScanType;
        }
        RectF rectF2 = rectF;
        String str3 = str2;
        return scanResultSuccess.copy(str, barcodeFormat, z, arrayList, rectF2, str3);
    }

    public final String component1() {
        return this.text;
    }

    public final BarcodeFormat component2() {
        return this.barcodeFormat;
    }

    public final boolean component3() {
        return this.isLongDistance;
    }

    public final ArrayList<PointF> component4() {
        return this.points;
    }

    public final RectF component5() {
        return this.boundingBox;
    }

    public final String component6() {
        return this.modelScanType;
    }

    public final ScanResultSuccess copy(String text, BarcodeFormat barcodeFormat, boolean z, ArrayList<PointF> points, RectF boundingBox, String modelScanType) {
        Intrinsics.checkNotNullParameter(text, "text");
        Intrinsics.checkNotNullParameter(barcodeFormat, "barcodeFormat");
        Intrinsics.checkNotNullParameter(points, "points");
        Intrinsics.checkNotNullParameter(boundingBox, "boundingBox");
        Intrinsics.checkNotNullParameter(modelScanType, "modelScanType");
        return new ScanResultSuccess(text, barcodeFormat, z, points, boundingBox, modelScanType);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof ScanResultSuccess)) {
            return false;
        }
        ScanResultSuccess scanResultSuccess = (ScanResultSuccess) obj;
        return Intrinsics.areEqual(this.text, scanResultSuccess.text) && this.barcodeFormat == scanResultSuccess.barcodeFormat && this.isLongDistance == scanResultSuccess.isLongDistance && Intrinsics.areEqual(this.points, scanResultSuccess.points) && Intrinsics.areEqual(this.boundingBox, scanResultSuccess.boundingBox) && Intrinsics.areEqual(this.modelScanType, scanResultSuccess.modelScanType);
    }

    public final BarcodeFormat getBarcodeFormat() {
        return this.barcodeFormat;
    }

    public final RectF getBoundingBox() {
        return this.boundingBox;
    }

    public final String getModelScanType() {
        return this.modelScanType;
    }

    public final ArrayList<PointF> getPoints() {
        return this.points;
    }

    public final String getText() {
        return this.text;
    }

    public int hashCode() {
        return this.modelScanType.hashCode() + ((this.boundingBox.hashCode() + ((this.points.hashCode() + a.a(this.isLongDistance, (this.barcodeFormat.hashCode() + (this.text.hashCode() * 31)) * 31, 31)) * 31)) * 31);
    }

    public final boolean isLongDistance() {
        return this.isLongDistance;
    }

    public final void setPoints(ArrayList<PointF> arrayList) {
        Intrinsics.checkNotNullParameter(arrayList, "<set-?>");
        this.points = arrayList;
    }

    public String toString() {
        return "ScanResultSuccess(text=" + this.text + ", barcodeFormat=" + this.barcodeFormat + ", isLongDistance=" + this.isLongDistance + ", points=" + this.points + ", boundingBox=" + this.boundingBox + ", modelScanType=" + this.modelScanType + ')';
    }
}

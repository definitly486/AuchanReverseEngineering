package com.scanflow.ui.ar;

import android.graphics.RectF;
import android.util.Size;
import androidx.annotation.Keep;
import com.scanflow.datacapture.model.OneOFManyCodesScanResults;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
@Keep
public final class ArObject {
    private final int bboxcolor;
    private final RectF boundingBox;
    private OneOFManyCodesScanResults decodedResult;
    private boolean showtickimage;
    private final int sourceRotationDegrees;
    private final Size sourceSize;
    private final String trackingId;

    public ArObject(String trackingId, RectF boundingBox, Size sourceSize, int i, int i2, OneOFManyCodesScanResults oneOFManyCodesScanResults, boolean z) {
        Intrinsics.checkNotNullParameter(trackingId, "trackingId");
        Intrinsics.checkNotNullParameter(boundingBox, "boundingBox");
        Intrinsics.checkNotNullParameter(sourceSize, "sourceSize");
        this.trackingId = trackingId;
        this.boundingBox = boundingBox;
        this.sourceSize = sourceSize;
        this.sourceRotationDegrees = i;
        this.bboxcolor = i2;
        this.decodedResult = oneOFManyCodesScanResults;
        this.showtickimage = z;
    }

    public static /* synthetic */ ArObject copy$default(ArObject arObject, String str, RectF rectF, Size size, int i, int i2, OneOFManyCodesScanResults oneOFManyCodesScanResults, boolean z, int i3, Object obj) {
        if ((i3 & 1) != 0) {
            str = arObject.trackingId;
        }
        if ((i3 & 2) != 0) {
            rectF = arObject.boundingBox;
        }
        if ((i3 & 4) != 0) {
            size = arObject.sourceSize;
        }
        if ((i3 & 8) != 0) {
            i = arObject.sourceRotationDegrees;
        }
        if ((i3 & 16) != 0) {
            i2 = arObject.bboxcolor;
        }
        if ((i3 & 32) != 0) {
            oneOFManyCodesScanResults = arObject.decodedResult;
        }
        if ((i3 & 64) != 0) {
            z = arObject.showtickimage;
        }
        OneOFManyCodesScanResults oneOFManyCodesScanResults2 = oneOFManyCodesScanResults;
        boolean z2 = z;
        int i4 = i2;
        Size size2 = size;
        return arObject.copy(str, rectF, size2, i, i4, oneOFManyCodesScanResults2, z2);
    }

    public final String component1() {
        return this.trackingId;
    }

    public final RectF component2() {
        return this.boundingBox;
    }

    public final Size component3() {
        return this.sourceSize;
    }

    public final int component4() {
        return this.sourceRotationDegrees;
    }

    public final int component5() {
        return this.bboxcolor;
    }

    public final OneOFManyCodesScanResults component6() {
        return this.decodedResult;
    }

    public final boolean component7() {
        return this.showtickimage;
    }

    public final ArObject copy(String trackingId, RectF boundingBox, Size sourceSize, int i, int i2, OneOFManyCodesScanResults oneOFManyCodesScanResults, boolean z) {
        Intrinsics.checkNotNullParameter(trackingId, "trackingId");
        Intrinsics.checkNotNullParameter(boundingBox, "boundingBox");
        Intrinsics.checkNotNullParameter(sourceSize, "sourceSize");
        return new ArObject(trackingId, boundingBox, sourceSize, i, i2, oneOFManyCodesScanResults, z);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof ArObject)) {
            return false;
        }
        ArObject arObject = (ArObject) obj;
        return Intrinsics.areEqual(this.trackingId, arObject.trackingId) && Intrinsics.areEqual(this.boundingBox, arObject.boundingBox) && Intrinsics.areEqual(this.sourceSize, arObject.sourceSize) && this.sourceRotationDegrees == arObject.sourceRotationDegrees && this.bboxcolor == arObject.bboxcolor && Intrinsics.areEqual(this.decodedResult, arObject.decodedResult) && this.showtickimage == arObject.showtickimage;
    }

    public final int getBboxcolor() {
        return this.bboxcolor;
    }

    public final RectF getBoundingBox() {
        return this.boundingBox;
    }

    public final OneOFManyCodesScanResults getDecodedResult() {
        return this.decodedResult;
    }

    public final boolean getShowtickimage() {
        return this.showtickimage;
    }

    public final int getSourceRotationDegrees() {
        return this.sourceRotationDegrees;
    }

    public final Size getSourceSize() {
        return this.sourceSize;
    }

    public final String getTrackingId() {
        return this.trackingId;
    }

    public int hashCode() {
        int iHashCode = (Integer.hashCode(this.bboxcolor) + ((Integer.hashCode(this.sourceRotationDegrees) + ((this.sourceSize.hashCode() + ((this.boundingBox.hashCode() + (this.trackingId.hashCode() * 31)) * 31)) * 31)) * 31)) * 31;
        OneOFManyCodesScanResults oneOFManyCodesScanResults = this.decodedResult;
        return Boolean.hashCode(this.showtickimage) + ((iHashCode + (oneOFManyCodesScanResults == null ? 0 : oneOFManyCodesScanResults.hashCode())) * 31);
    }

    public final void setDecodedResult(OneOFManyCodesScanResults oneOFManyCodesScanResults) {
        this.decodedResult = oneOFManyCodesScanResults;
    }

    public final void setShowtickimage(boolean z) {
        this.showtickimage = z;
    }

    public String toString() {
        return "ArObject(trackingId=" + this.trackingId + ", boundingBox=" + this.boundingBox + ", sourceSize=" + this.sourceSize + ", sourceRotationDegrees=" + this.sourceRotationDegrees + ", bboxcolor=" + this.bboxcolor + ", decodedResult=" + this.decodedResult + ", showtickimage=" + this.showtickimage + ')';
    }

    public /* synthetic */ ArObject(String str, RectF rectF, Size size, int i, int i2, OneOFManyCodesScanResults oneOFManyCodesScanResults, boolean z, int i3, DefaultConstructorMarker defaultConstructorMarker) {
        this(str, rectF, size, i, (i3 & 16) != 0 ? -1 : i2, (i3 & 32) != 0 ? null : oneOFManyCodesScanResults, z);
    }
}

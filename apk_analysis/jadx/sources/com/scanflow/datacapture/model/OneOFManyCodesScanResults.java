package com.scanflow.datacapture.model;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class OneOFManyCodesScanResults {
    private final String decodedFormat;
    private final String decodedValue;

    public OneOFManyCodesScanResults(String decodedValue, String decodedFormat) {
        Intrinsics.checkNotNullParameter(decodedValue, "decodedValue");
        Intrinsics.checkNotNullParameter(decodedFormat, "decodedFormat");
        this.decodedValue = decodedValue;
        this.decodedFormat = decodedFormat;
    }

    public static /* synthetic */ OneOFManyCodesScanResults copy$default(OneOFManyCodesScanResults oneOFManyCodesScanResults, String str, String str2, int i, Object obj) {
        if ((i & 1) != 0) {
            str = oneOFManyCodesScanResults.decodedValue;
        }
        if ((i & 2) != 0) {
            str2 = oneOFManyCodesScanResults.decodedFormat;
        }
        return oneOFManyCodesScanResults.copy(str, str2);
    }

    public final String component1() {
        return this.decodedValue;
    }

    public final String component2() {
        return this.decodedFormat;
    }

    public final OneOFManyCodesScanResults copy(String decodedValue, String decodedFormat) {
        Intrinsics.checkNotNullParameter(decodedValue, "decodedValue");
        Intrinsics.checkNotNullParameter(decodedFormat, "decodedFormat");
        return new OneOFManyCodesScanResults(decodedValue, decodedFormat);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof OneOFManyCodesScanResults)) {
            return false;
        }
        OneOFManyCodesScanResults oneOFManyCodesScanResults = (OneOFManyCodesScanResults) obj;
        return Intrinsics.areEqual(this.decodedValue, oneOFManyCodesScanResults.decodedValue) && Intrinsics.areEqual(this.decodedFormat, oneOFManyCodesScanResults.decodedFormat);
    }

    public final String getDecodedFormat() {
        return this.decodedFormat;
    }

    public final String getDecodedValue() {
        return this.decodedValue;
    }

    public int hashCode() {
        return this.decodedFormat.hashCode() + (this.decodedValue.hashCode() * 31);
    }

    public String toString() {
        return "OneOFManyCodesScanResults(decodedValue=" + this.decodedValue + ", decodedFormat=" + this.decodedFormat + ')';
    }
}

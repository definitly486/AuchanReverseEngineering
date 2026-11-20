package androidx.collection;

/* JADX INFO: compiled from: FloatFloatPair.kt */
/* JADX INFO: loaded from: classes.dex */
public final class FloatFloatPair {
    public final long packedValue;

    /* JADX INFO: renamed from: equals-impl, reason: not valid java name */
    public static boolean m57equalsimpl(long j, Object obj) {
        return (obj instanceof FloatFloatPair) && j == ((FloatFloatPair) obj).m60unboximpl();
    }

    /* JADX INFO: renamed from: hashCode-impl, reason: not valid java name */
    public static int m58hashCodeimpl(long j) {
        return Long.hashCode(j);
    }

    public boolean equals(Object obj) {
        return m57equalsimpl(this.packedValue, obj);
    }

    public int hashCode() {
        return m58hashCodeimpl(this.packedValue);
    }

    /* JADX INFO: renamed from: unbox-impl, reason: not valid java name */
    public final /* synthetic */ long m60unboximpl() {
        return this.packedValue;
    }

    /* JADX INFO: renamed from: toString-impl, reason: not valid java name */
    public static String m59toStringimpl(long j) {
        return '(' + Float.intBitsToFloat((int) (j >> 32)) + ", " + Float.intBitsToFloat((int) (j & 4294967295L)) + ')';
    }

    public String toString() {
        return m59toStringimpl(this.packedValue);
    }
}

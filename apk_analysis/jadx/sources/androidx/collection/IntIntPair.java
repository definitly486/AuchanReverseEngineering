package androidx.collection;

/* JADX INFO: compiled from: IntIntPair.kt */
/* JADX INFO: loaded from: classes.dex */
public final class IntIntPair {
    public final long packedValue;

    /* JADX INFO: renamed from: equals-impl, reason: not valid java name */
    public static boolean m61equalsimpl(long j, Object obj) {
        return (obj instanceof IntIntPair) && j == ((IntIntPair) obj).m66unboximpl();
    }

    /* JADX INFO: renamed from: getFirst-impl, reason: not valid java name */
    public static final int m62getFirstimpl(long j) {
        return (int) (j >> 32);
    }

    /* JADX INFO: renamed from: getSecond-impl, reason: not valid java name */
    public static final int m63getSecondimpl(long j) {
        return (int) (j & 4294967295L);
    }

    /* JADX INFO: renamed from: hashCode-impl, reason: not valid java name */
    public static int m64hashCodeimpl(long j) {
        return Long.hashCode(j);
    }

    public boolean equals(Object obj) {
        return m61equalsimpl(this.packedValue, obj);
    }

    public int hashCode() {
        return m64hashCodeimpl(this.packedValue);
    }

    /* JADX INFO: renamed from: unbox-impl, reason: not valid java name */
    public final /* synthetic */ long m66unboximpl() {
        return this.packedValue;
    }

    /* JADX INFO: renamed from: toString-impl, reason: not valid java name */
    public static String m65toStringimpl(long j) {
        return '(' + m62getFirstimpl(j) + ", " + m63getSecondimpl(j) + ')';
    }

    public String toString() {
        return m65toStringimpl(this.packedValue);
    }
}

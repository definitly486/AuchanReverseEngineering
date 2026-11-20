package androidx.collection;

/* JADX INFO: compiled from: SieveCache.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SieveCacheKt {
    private static final long[] EmptyNodes = new long[0];

    public static final int getDst(long j) {
        return (int) (j & 4294967295L);
    }

    public static final int getNextNode(long j) {
        return (int) (j & 2147483647L);
    }

    public static final int getPreviousNode(long j) {
        return (int) ((j >> 31) & 2147483647L);
    }

    public static final int getSrc(long j) {
        return (int) ((j >> 32) & 4294967295L);
    }

    public static final int getVisited(long j) {
        return (int) ((j >> 62) & 1);
    }

    public static final long[] getEmptyNodes() {
        return EmptyNodes;
    }
}

package androidx.room;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import java.util.concurrent.locks.ReentrantLock;
import kotlin.enums.EnumEntries;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: InvalidationTracker.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ObservedTableStates {
    private final ReentrantLock lock = new ReentrantLock();
    private boolean needsSync;
    private final boolean[] tableObservedState;
    private final long[] tableObserversCount;

    /* JADX INFO: compiled from: InvalidationTracker.kt */
    public enum ObserveOp {
        NO_OP,
        ADD,
        REMOVE;

        private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());
    }

    public ObservedTableStates(int i) {
        this.tableObserversCount = new long[i];
        this.tableObservedState = new boolean[i];
    }

    public final ObserveOp[] getTablesToSync$room_runtime_release() {
        ObserveOp observeOp;
        ReentrantLock reentrantLock = this.lock;
        reentrantLock.lock();
        try {
            if (!this.needsSync) {
                return null;
            }
            this.needsSync = false;
            int length = this.tableObserversCount.length;
            ObserveOp[] observeOpArr = new ObserveOp[length];
            int i = 0;
            boolean z = false;
            while (i < length) {
                boolean z2 = true;
                boolean z3 = this.tableObserversCount[i] > 0;
                boolean[] zArr = this.tableObservedState;
                if (z3 != zArr[i]) {
                    zArr[i] = z3;
                    observeOp = z3 ? ObserveOp.ADD : ObserveOp.REMOVE;
                } else {
                    z2 = z;
                    observeOp = ObserveOp.NO_OP;
                }
                observeOpArr[i] = observeOp;
                i++;
                z = z2;
            }
            return z ? observeOpArr : null;
        } finally {
            reentrantLock.unlock();
        }
    }

    public final boolean onObserverAdded$room_runtime_release(int[] tableIds) {
        Intrinsics.checkNotNullParameter(tableIds, "tableIds");
        ReentrantLock reentrantLock = this.lock;
        reentrantLock.lock();
        try {
            boolean z = false;
            for (int i : tableIds) {
                long[] jArr = this.tableObserversCount;
                long j = jArr[i];
                jArr[i] = 1 + j;
                if (j == 0) {
                    z = true;
                    this.needsSync = true;
                }
            }
            reentrantLock.unlock();
            return z;
        } catch (Throwable th) {
            reentrantLock.unlock();
            throw th;
        }
    }

    public final boolean onObserverRemoved$room_runtime_release(int[] tableIds) {
        Intrinsics.checkNotNullParameter(tableIds, "tableIds");
        ReentrantLock reentrantLock = this.lock;
        reentrantLock.lock();
        try {
            boolean z = false;
            for (int i : tableIds) {
                long[] jArr = this.tableObserversCount;
                long j = jArr[i];
                jArr[i] = j - 1;
                if (j == 1) {
                    z = true;
                    this.needsSync = true;
                }
            }
            reentrantLock.unlock();
            return z;
        } catch (Throwable th) {
            reentrantLock.unlock();
            throw th;
        }
    }

    public final void resetTriggerState$room_runtime_release() {
        ReentrantLock reentrantLock = this.lock;
        reentrantLock.lock();
        try {
            ArraysKt.fill$default(this.tableObservedState, false, 0, 0, 6, (Object) null);
            this.needsSync = true;
            Unit unit = Unit.INSTANCE;
        } finally {
            reentrantLock.unlock();
        }
    }

    public final void forceNeedSync$room_runtime_release() {
        ReentrantLock reentrantLock = this.lock;
        reentrantLock.lock();
        try {
            this.needsSync = true;
            Unit unit = Unit.INSTANCE;
        } finally {
            reentrantLock.unlock();
        }
    }
}

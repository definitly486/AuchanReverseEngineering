package com.scanflow.datacapture.barinternal.androidx.room.concurrent;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.concurrent.atomic.AtomicInteger;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: CloseBarrier.kt */
/* JADX INFO: loaded from: classes.dex */
public final class CloseBarrier {
    private final AtomicInteger blockers;
    private final Function0 closeAction;
    private final AtomicBoolean closeInitiated;

    public CloseBarrier(Function0 closeAction) {
        Intrinsics.checkNotNullParameter(closeAction, "closeAction");
        this.closeAction = closeAction;
        this.blockers = new AtomicInteger(0);
        this.closeInitiated = new AtomicBoolean(false);
    }

    private final boolean isClosed() {
        return this.closeInitiated.get();
    }

    public final boolean block$room_runtime_release() {
        synchronized (this) {
            if (isClosed()) {
                return false;
            }
            this.blockers.incrementAndGet();
            return true;
        }
    }

    public final void unblock$room_runtime_release() {
        synchronized (this) {
            this.blockers.decrementAndGet();
            if (this.blockers.get() < 0) {
                throw new IllegalStateException("Unbalanced call to unblock() detected.");
            }
            Unit unit = Unit.INSTANCE;
        }
    }

    public final void close$room_runtime_release() {
        synchronized (this) {
            if (this.closeInitiated.compareAndSet(false, true)) {
                Unit unit = Unit.INSTANCE;
                while (this.blockers.get() != 0) {
                }
                this.closeAction.invoke();
            }
        }
    }
}

package androidx.room;

import java.lang.ref.WeakReference;
import java.util.Set;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: InvalidationTracker.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class WeakObserver extends InvalidationTracker.Observer {
    private final WeakReference delegateRef;
    private final InvalidationTracker tracker;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public WeakObserver(InvalidationTracker tracker, InvalidationTracker.Observer delegate) {
        super(delegate.getTables$room_runtime_release());
        Intrinsics.checkNotNullParameter(tracker, "tracker");
        Intrinsics.checkNotNullParameter(delegate, "delegate");
        this.tracker = tracker;
        this.delegateRef = new WeakReference(delegate);
    }

    @Override // androidx.room.InvalidationTracker.Observer
    public void onInvalidated(Set tables) {
        Intrinsics.checkNotNullParameter(tables, "tables");
        InvalidationTracker.Observer observer = (InvalidationTracker.Observer) this.delegateRef.get();
        if (observer == null) {
            this.tracker.removeObserver(this);
        } else {
            observer.onInvalidated(tables);
        }
    }
}

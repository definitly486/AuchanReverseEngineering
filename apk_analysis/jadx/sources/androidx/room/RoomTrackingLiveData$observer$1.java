package androidx.room;

import com.scanflow.datacapture.barinternal.androidx.arch.core.executor.ArchTaskExecutor;
import java.util.Set;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: RoomTrackingLiveData.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class RoomTrackingLiveData$observer$1 extends InvalidationTracker.Observer {
    final /* synthetic */ RoomTrackingLiveData this$0;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    RoomTrackingLiveData$observer$1(String[] strArr, RoomTrackingLiveData roomTrackingLiveData) {
        super(strArr);
        this.this$0 = roomTrackingLiveData;
    }

    @Override // androidx.room.InvalidationTracker.Observer
    public void onInvalidated(Set tables) {
        Intrinsics.checkNotNullParameter(tables, "tables");
        ArchTaskExecutor archTaskExecutor = ArchTaskExecutor.getInstance();
        final RoomTrackingLiveData roomTrackingLiveData = this.this$0;
        archTaskExecutor.executeOnMainThread(new Runnable() { // from class: androidx.room.RoomTrackingLiveData$observer$1$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                RoomTrackingLiveData.access$invalidated(roomTrackingLiveData);
            }
        });
    }
}

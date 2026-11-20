package com.scanflow.ui.ar;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public class ArObjectTracker {
    private ArObjectTracker pipedTracked;
    private final List<ArObjectTrackingListener> trackingListeners = new ArrayList();

    public interface ArObjectTrackingListener {
        void onObjectTracked(ArObject arObject);

        void onObjectTracked(ArrayList<ArObject> arrayList);
    }

    public final ArObjectTracker addTrackingListener(ArObjectTrackingListener listener) {
        Intrinsics.checkNotNullParameter(listener, "listener");
        this.trackingListeners.add(listener);
        return this;
    }

    public final void clearListenersAndPipe() {
        this.trackingListeners.clear();
        ArObjectTracker arObjectTracker = this.pipedTracked;
        if (arObjectTracker != null) {
            arObjectTracker.clearListenersAndPipe();
        }
        this.pipedTracked = null;
    }

    public final ArObjectTracker pipe(ArObjectTracker otherTracker) {
        Intrinsics.checkNotNullParameter(otherTracker, "otherTracker");
        this.pipedTracked = otherTracker;
        return otherTracker;
    }

    public void processObject(ArObject arObject) {
        publish(arObject);
    }

    public final void publish(ArObject arObject) {
        ArObjectTracker arObjectTracker = this.pipedTracked;
        if (arObjectTracker != null) {
            arObjectTracker.processObject(arObject);
        }
        Iterator<T> it = this.trackingListeners.iterator();
        while (it.hasNext()) {
            ((ArObjectTrackingListener) it.next()).onObjectTracked(arObject);
        }
    }

    public final boolean removeTrackingListener(ArObjectTrackingListener listener) {
        Intrinsics.checkNotNullParameter(listener, "listener");
        return this.trackingListeners.remove(listener);
    }

    public final ArObjectTracker addTrackingListener(final Function1<? super ArObject, Unit> listener) {
        Intrinsics.checkNotNullParameter(listener, "listener");
        addTrackingListener(new ArObjectTrackingListener() { // from class: com.scanflow.ui.ar.ArObjectTracker.addTrackingListener.1
            @Override // com.scanflow.ui.ar.ArObjectTracker.ArObjectTrackingListener
            public void onObjectTracked(ArObject arObject) {
                listener.invoke(arObject);
            }

            @Override // com.scanflow.ui.ar.ArObjectTracker.ArObjectTrackingListener
            public void onObjectTracked(ArrayList<ArObject> arObject) {
                Intrinsics.checkNotNullParameter(arObject, "arObject");
            }
        });
        return this;
    }

    public void processObject(ArrayList<ArObject> arObject) {
        Intrinsics.checkNotNullParameter(arObject, "arObject");
        publish(arObject);
    }

    public final void publish(ArrayList<ArObject> arObject) {
        Intrinsics.checkNotNullParameter(arObject, "arObject");
        ArObjectTracker arObjectTracker = this.pipedTracked;
        if (arObjectTracker != null) {
            arObjectTracker.processObject(arObject);
        }
        Iterator<T> it = this.trackingListeners.iterator();
        while (it.hasNext()) {
            ((ArObjectTrackingListener) it.next()).onObjectTracked(arObject);
        }
    }
}

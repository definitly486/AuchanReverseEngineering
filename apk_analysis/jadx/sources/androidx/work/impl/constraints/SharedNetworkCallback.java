package androidx.work.impl.constraints;

import android.net.ConnectivityManager;
import android.net.Network;
import android.net.NetworkCapabilities;
import android.net.NetworkRequest;
import androidx.work.Logger;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: WorkConstraintsTracker.kt */
/* JADX INFO: loaded from: classes.dex */
final class SharedNetworkCallback extends ConnectivityManager.NetworkCallback {
    public static final SharedNetworkCallback INSTANCE = new SharedNetworkCallback();
    private static final Object requestsLock = new Object();
    private static final Map requests = new LinkedHashMap();

    private SharedNetworkCallback() {
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public void onCapabilitiesChanged(Network network, NetworkCapabilities networkCapabilities) {
        List<Map.Entry> list;
        ConstraintsState constraintsNotMet;
        Intrinsics.checkNotNullParameter(network, "network");
        Intrinsics.checkNotNullParameter(networkCapabilities, "networkCapabilities");
        Logger.get().debug(WorkConstraintsTrackerKt.TAG, "NetworkRequestConstraintController onCapabilitiesChanged callback");
        synchronized (requestsLock) {
            list = CollectionsKt.toList(requests.entrySet());
        }
        for (Map.Entry entry : list) {
            Function1 function1 = (Function1) entry.getKey();
            if (((NetworkRequest) entry.getValue()).canBeSatisfiedBy(networkCapabilities)) {
                constraintsNotMet = ConstraintsState.ConstraintsMet.INSTANCE;
            } else {
                constraintsNotMet = new ConstraintsState.ConstraintsNotMet(7);
            }
            function1.invoke(constraintsNotMet);
        }
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public void onLost(Network network) {
        List list;
        Intrinsics.checkNotNullParameter(network, "network");
        Logger.get().debug(WorkConstraintsTrackerKt.TAG, "NetworkRequestConstraintController onLost callback");
        synchronized (requestsLock) {
            list = CollectionsKt.toList(requests.keySet());
        }
        Iterator it = list.iterator();
        while (it.hasNext()) {
            ((Function1) it.next()).invoke(new ConstraintsState.ConstraintsNotMet(7));
        }
    }

    public final Function0 addCallback(final ConnectivityManager connManager, NetworkRequest networkRequest, final Function1 onConstraintState) {
        Intrinsics.checkNotNullParameter(connManager, "connManager");
        Intrinsics.checkNotNullParameter(networkRequest, "networkRequest");
        Intrinsics.checkNotNullParameter(onConstraintState, "onConstraintState");
        synchronized (requestsLock) {
            try {
                Map map = requests;
                boolean zIsEmpty = map.isEmpty();
                map.put(onConstraintState, networkRequest);
                if (zIsEmpty) {
                    Logger.get().debug(WorkConstraintsTrackerKt.TAG, "NetworkRequestConstraintController register shared callback");
                    connManager.registerDefaultNetworkCallback(this);
                }
                Unit unit = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
        return new Function0() { // from class: androidx.work.impl.constraints.SharedNetworkCallback.addCallback.2
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(0);
            }

            @Override // kotlin.jvm.functions.Function0
            public /* bridge */ /* synthetic */ Object invoke() {
                m155invoke();
                return Unit.INSTANCE;
            }

            /* JADX INFO: renamed from: invoke, reason: collision with other method in class */
            public final void m155invoke() {
                Object obj = SharedNetworkCallback.requestsLock;
                Function1 function1 = onConstraintState;
                ConnectivityManager connectivityManager = connManager;
                SharedNetworkCallback sharedNetworkCallback = this;
                synchronized (obj) {
                    try {
                        SharedNetworkCallback.requests.remove(function1);
                        if (SharedNetworkCallback.requests.isEmpty()) {
                            Logger.get().debug(WorkConstraintsTrackerKt.TAG, "NetworkRequestConstraintController unregister shared callback");
                            connectivityManager.unregisterNetworkCallback(sharedNetworkCallback);
                        }
                        Unit unit2 = Unit.INSTANCE;
                    } catch (Throwable th2) {
                        throw th2;
                    }
                }
            }
        };
    }
}

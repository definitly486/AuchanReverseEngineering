package io.appmetrica.analytics.networktasks.internal;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.coreapi.internal.io.IExecutionPolicy;
import io.appmetrica.analytics.network.internal.NetworkClientServiceLocator;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class NetworkServiceLocator implements NetworkServiceLifecycleObserver {
    public static final Companion Companion = new Companion(null);
    private static volatile NetworkServiceLocator b;
    private final NetworkCore a;

    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        public final NetworkServiceLocator getInstance() {
            NetworkServiceLocator networkServiceLocator = NetworkServiceLocator.b;
            if (networkServiceLocator != null) {
                return networkServiceLocator;
            }
            Intrinsics.throwUninitializedPropertyAccessException("instance");
            return null;
        }

        public final void init(Context context, IExecutionPolicy iExecutionPolicy) {
            if (NetworkServiceLocator.b == null) {
                synchronized (NetworkServiceLocator.class) {
                    try {
                        if (NetworkServiceLocator.b == null) {
                            NetworkServiceLocator.b = new NetworkServiceLocator(iExecutionPolicy);
                        }
                        Unit unit = Unit.INSTANCE;
                    } catch (Throwable th) {
                        throw th;
                    }
                }
            }
            NetworkClientServiceLocator.init(context);
        }

        private Companion() {
        }

        public final void init(NetworkServiceLocator networkServiceLocator) {
            NetworkServiceLocator.b = networkServiceLocator;
        }
    }

    public NetworkServiceLocator(IExecutionPolicy iExecutionPolicy) {
        NetworkCore networkCore = new NetworkCore(iExecutionPolicy);
        networkCore.setName("IAA-NC");
        networkCore.start();
        this.a = networkCore;
    }

    public static final NetworkServiceLocator getInstance() {
        return Companion.getInstance();
    }

    public static final void init(Context context, IExecutionPolicy iExecutionPolicy) {
        Companion.init(context, iExecutionPolicy);
    }

    public final NetworkCore getNetworkCore() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.NetworkServiceLifecycleObserver
    public void onCreate() {
    }

    @Override // io.appmetrica.analytics.networktasks.internal.NetworkServiceLifecycleObserver
    public void onDestroy() {
        this.a.stopTasks();
    }

    public static final void init(NetworkServiceLocator networkServiceLocator) {
        Companion.init(networkServiceLocator);
    }
}
